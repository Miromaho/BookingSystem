using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookingSys
{
    public partial class BookingForm : Form
    {
        private DataBase _db;
        private LessonEvent _le;
        public BookingForm()
        {
            _db = new DataBase();
            _le = new LessonEvent();
            InitializeComponent();
            _le.InitializeLessonStatusIndicator(this, _db);
        }

        private void LoadData(object sender, EventArgs e)
        {
            var classrooms = _db.GetClassrooms();
            ClassroomsList.DisplayMember = "Name";
            ClassroomsList.ValueMember = "Id";
            ClassroomsList.DataSource = classrooms;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            AutForm autForm = new AutForm();
            this.Hide();
            autForm.Show();
        }

        private void RentButton_Click(object sender, EventArgs e)
                        => _db.Rent(this);

        private void ClassroomsList_MouseMove(object sender, MouseEventArgs e) 
                        => ClassroomsList.DropDownStyle = ComboBoxStyle.DropDownList;

        private void Lesson_choice_MouseMove(object sender, MouseEventArgs e) 
                        => Lesson_choice.DropDownStyle = ComboBoxStyle.DropDownList;

        private void BookingForm_FormClosed(object sender, FormClosedEventArgs e)
                        => Application.Exit();

    }
}
