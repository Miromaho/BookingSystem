namespace BookingSys
{
    public partial class AutForm : Form
    {
        private DataBase _db;
        private BookingForm bookform;
        public AutForm()
        {
            bookform = new BookingForm();
            _db = new DataBase();
            InitializeComponent();
        }

        private void AutButton_Click(object sender, EventArgs e) 
                        => _db.MiniAuthorizationCheck(bookform, this);
        
        private void CheckPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckPass.Checked)
                AutPass.UseSystemPasswordChar = true;
            else
                AutPass.UseSystemPasswordChar = false;
        }
        private void ToRegForm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            RegForm regForm = new RegForm();
            regForm.ShowDialog();
        }

        private void AutForm_FormClosed(object sender, FormClosedEventArgs e) 
                        => Application.Exit();
                       
    }
}