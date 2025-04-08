using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text.RegularExpressions;

namespace BookingSys
{
    public class DataBase
    {
        internal string ConnectToDB = @"Data Source=DESKTOP-D6PEI4T;Initial Catalog=BookingSystem;Integrated Security=True;TrustServerCertificate=True";
        
        //------------------Код для формы регистрации пользователя------------------------
        private SqlDataAdapter QueryExecute(string query)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectToDB);
                connection.Open();
                SqlDataAdapter sda = new SqlDataAdapter(query, connection);
                sda.SelectCommand.ExecuteNonQuery();

                MessageBox.Show("Вы зарегестрированы!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return sda;
            }
            catch
            {
                MessageBox.Show("Возникла ошибка при регистрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool IsUserExists(string login)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE username = @login";

            var parameters = new Dictionary<string, object>
            {
                 { "@login", login }
            };

            int count = Convert.ToInt32(ExecuteScalar(query, parameters));
            return count > 0;
        }

        private object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectToDB))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value);
                }

                connection.Open();
                return command.ExecuteScalar();
            }
        }
        public void MiniRegisterCheck(RegForm regform)
        {
            var reglogin = regform.Login.Text;
            var regpassword = regform.Password.Text;
            var regmail = regform.Email.Text;

            if (string.IsNullOrEmpty(reglogin) || string.IsNullOrEmpty(regpassword) || string.IsNullOrEmpty(regmail))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!ValidEmail(regmail))
            {
                MessageBox.Show("Ваш адрес электронной почты указан неверно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsUserExists(reglogin))
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Hashing gh = new Hashing();
            var AddUserData = $"INSERT INTO Users (UserName, Password, Email) VALUES ('{regform.Login.Text}', '{gh.Hash(regform.Password.Text)}', '{regform.Email.Text}')";
            QueryExecute(AddUserData);
        }
        private bool ValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        //------------------Код для формы авторизации пользователя------------------------
        private bool AuthorizeUser(string loginOrEmail, string autpass)
        {
            bool isAuthorized = false;

            var dbAdd = new DataBase();
            var getHash = new Hashing();

            using (SqlConnection connection = new SqlConnection(dbAdd.ConnectToDB))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE (username = @loginOrEmail OR email = @loginOrEmail) AND password = @password", connection))
                {
                    command.Parameters.AddWithValue("@loginOrEmail", loginOrEmail);
                    command.Parameters.AddWithValue("@password", getHash.Hash(autpass));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["password"].ToString() == getHash.Hash(autpass))
                            {
                                isAuthorized = true;
                                CurrentUser.UserId = reader.GetInt32(0);
                                CurrentUser.UserName = reader.GetString(1);
                                MessageBox.Show("Вход выполнен успешно!", "Успех",
                                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            return isAuthorized;
        }
        public void MiniAuthorizationCheck(BookingForm bookform, AutForm autform)
        {
            var loginOrEmail = autform.AutLogin.Text;
            var password = autform.AutPass.Text;
            if (loginOrEmail == string.Empty || password == string.Empty)
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (AuthorizeUser(loginOrEmail, password))
            {
                bookform.Show();
                autform.Hide();
            }
            else
                MessageBox.Show("Неверный логин или пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //------------------Код для формы бронирования аудиторий------------------------
        public List<ClassroomItem> GetClassrooms()
        {
            List<ClassroomItem> classrooms = new List<ClassroomItem>();
            string query = "SELECT classroom_id, name FROM Classrooms";

            using (SqlConnection connection = new SqlConnection(ConnectToDB))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    classrooms.Add(new ClassroomItem
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
            }
            return classrooms;
        }
        public void Rent(BookingForm form)
        {
            try
            {
                int selectedRoomId = Convert.ToInt32(form.ClassroomsList.SelectedValue);
                DateTime bookingDate = form.RentDate.Value.Date;
                string lesson = form.Lesson_choice.Text;

                if (UserBookedThisClassroom(CurrentUser.UserId, selectedRoomId, bookingDate, lesson))
                {
                    MessageBox.Show("Вы уже бронировали эту аудиторию на выбранную пару", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (ClassroomBookedOnLesson(selectedRoomId, bookingDate, lesson))
                {
                    MessageBox.Show("Эта аудитория уже забронирована на выбранную пару", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (bookingDate < DateTime.Today)
                {
                    MessageBox.Show("Нельзя бронировать аудиторию на прошедшую дату", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "INSERT INTO Bookings (user_id, classroom_id, booking_time, lesson) VALUES (@user_id, @classroom_id, @booking_time, @lesson)";

                using (SqlConnection connection = new SqlConnection(ConnectToDB))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", CurrentUser.UserId);
                    command.Parameters.AddWithValue("@classroom_id", selectedRoomId);
                    command.Parameters.AddWithValue("@booking_time", bookingDate);
                    command.Parameters.AddWithValue("@lesson", form.Lesson_choice.Text);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show($"Аудитория {selectedRoomId} забронированна!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при бронировании: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool UserBookedThisClassroom(int userId, int classroomId, DateTime bookingDate, string lesson)
        {
            string query = @"SELECT COUNT(*) FROM Bookings 
           WHERE user_id = @user_id 
           AND classroom_id = @classroom_id
           AND CONVERT(date, booking_time) = @booking_date
           AND lesson = @lesson";

            using (SqlConnection connection = new SqlConnection(ConnectToDB))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@user_id", userId);
                command.Parameters.AddWithValue("@classroom_id", classroomId);
                command.Parameters.AddWithValue("@booking_date", bookingDate);
                command.Parameters.AddWithValue("@lesson", lesson);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }

        private bool ClassroomBookedOnLesson(int classroom_id, DateTime booking_date, string lesson)
        {
            string query = @"SELECT COUNT(*) FROM Bookings 
           WHERE classroom_id = @classroom_id 
           AND CONVERT(date, booking_time) = @booking_date
           AND lesson = @lesson";

            using (SqlConnection connection = new SqlConnection(ConnectToDB))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@classroom_id", classroom_id);
                command.Parameters.AddWithValue("@booking_date", booking_date);
                command.Parameters.AddWithValue("@lesson", lesson);

                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());

                return count > 0;
            }
        }
    }
}