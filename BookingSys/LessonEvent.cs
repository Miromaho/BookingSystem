using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSys
{
    public class LessonEvent
    {
        public void InitializeLessonStatusIndicator(BookingForm form_event, DataBase dataBase)
        {
            Label lesson_lebel = new Label();
            lesson_lebel.Name = "lblBookingStatus";
            lesson_lebel.AutoSize = true;
            lesson_lebel.Font = new Font("Arial", 10, FontStyle.Bold);
            lesson_lebel.Location = new Point(form_event.Lesson_choice.Right + 10, form_event.Lesson_choice.Top);
            form_event.Controls.Add(lesson_lebel);

            // здесь прооисходит подписка на события
            form_event.ClassroomsList.SelectedIndexChanged += (sender, e) => UpdateBookingStatus(form_event, dataBase);
            form_event.RentDate.ValueChanged += (sender, e) => UpdateBookingStatus(form_event, dataBase);
            form_event.Lesson_choice.SelectedValueChanged += (sender, e) => UpdateBookingStatus(form_event, dataBase);

            //обновление статуса
            UpdateBookingStatus(form_event, dataBase);
        }

        public void UpdateBookingStatus(BookingForm form_event, DataBase dataBase)
        {
            if (form_event.ClassroomsList.SelectedItem == null || form_event.RentDate.Value == null || form_event.Lesson_choice.SelectedItem == null)
                return;

            try
            {
                var classroom_status = form_event.Controls.Find("lblBookingStatus", true).FirstOrDefault() as Label;
                if (classroom_status == null) return;

                int selectedRoomId = Convert.ToInt32(form_event.ClassroomsList.SelectedValue);
                DateTime bookingDate = form_event.RentDate.Value.Date;
                string lesson = form_event.Lesson_choice.Text;

                if (dataBase.ClassroomBookedOnLesson(selectedRoomId, bookingDate, lesson))
                {
                    classroom_status.Text = "Аудитория занята";
                    classroom_status.ForeColor = Color.Red;
                }
                else
                {
                    classroom_status.Text = "Аудитория свободна";
                    classroom_status.ForeColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при проверке статуса: {ex.Message}");
            }
        }
    }
}