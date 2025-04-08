using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.Logging;

namespace BookingSys
{
    public partial class RegForm : Form
    {
        private DataBase _db;
        public RegForm()
        {
            _db = new DataBase();
            InitializeComponent();
        }

        public void RegisterButton_Click(object sender, EventArgs e) 
                        => _db.MiniRegisterCheck(this);
        private void PassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PassCheck.Checked)
                Password.UseSystemPasswordChar = true;
            else
                Password.UseSystemPasswordChar = false;
        }
        private void ToAutForm_LinkClicked_1(object sender, EventArgs e)
        {
            this.Hide();
            AutForm autoForm = new AutForm();
            autoForm.Show();
        }

        private void RegForm_FormClosed(object sender, FormClosedEventArgs e) 
                        => Application.Exit();
        
    }
}
