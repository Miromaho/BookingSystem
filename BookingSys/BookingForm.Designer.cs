namespace BookingSys
{
    partial class BookingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            ClassroomsList = new ComboBox();
            label3 = new Label();
            RentButton = new Button();
            label4 = new Label();
            RentDate = new DateTimePicker();
            Logout = new Button();
            Lesson_choice = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 128, 0);
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(0, -1);
            label1.Name = "label1";
            label1.Size = new Size(417, 131);
            label1.TabIndex = 0;
            label1.Text = "Бронирование Учебных Аудиторий";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(23, 293);
            label2.Name = "label2";
            label2.Size = new Size(309, 21);
            label2.TabIndex = 1;
            label2.Text = "Выберите пару которую хотите забронировать";
            // 
            // ClassroomsList
            // 
            ClassroomsList.FormattingEnabled = true;
            ClassroomsList.Location = new Point(23, 183);
            ClassroomsList.Name = "ClassroomsList";
            ClassroomsList.Size = new Size(169, 23);
            ClassroomsList.TabIndex = 3;
            ClassroomsList.Click += LoadData;
            ClassroomsList.MouseMove += ClassroomsList_MouseMove;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            label3.Location = new Point(23, 155);
            label3.Name = "label3";
            label3.Size = new Size(357, 25);
            label3.TabIndex = 4;
            label3.Text = "Выберите аудиторию которую хотите забронировать";
            // 
            // RentButton
            // 
            RentButton.BackColor = Color.FromArgb(192, 255, 192);
            RentButton.FlatStyle = FlatStyle.Flat;
            RentButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            RentButton.Location = new Point(25, 382);
            RentButton.Name = "RentButton";
            RentButton.Size = new Size(200, 64);
            RentButton.TabIndex = 5;
            RentButton.Text = "Забронировать";
            RentButton.UseVisualStyleBackColor = false;
            RentButton.Click += RentButton_Click;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(24, 223);
            label4.Name = "label4";
            label4.Size = new Size(201, 21);
            label4.TabIndex = 6;
            label4.Text = "Выберите дату бронирования";
            // 
            // RentDate
            // 
            RentDate.Location = new Point(23, 247);
            RentDate.Name = "RentDate";
            RentDate.Size = new Size(200, 23);
            RentDate.TabIndex = 7;
            // 
            // Logout
            // 
            Logout.BackColor = Color.FromArgb(192, 255, 192);
            Logout.FlatStyle = FlatStyle.Flat;
            Logout.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Logout.Location = new Point(254, 382);
            Logout.Name = "Logout";
            Logout.Size = new Size(126, 64);
            Logout.TabIndex = 8;
            Logout.Text = "Выйти из аккаунта";
            Logout.UseVisualStyleBackColor = false;
            Logout.Click += Logout_Click;
            // 
            // Lesson_choice
            // 
            Lesson_choice.FormattingEnabled = true;
            Lesson_choice.Items.AddRange(new object[] { "1 Пара (8:30-10:00)", "2 Пара (10:10-11:40)", "3 Пара (12:00-13:30)", "4 Пара (13:40-15:10)", "5 Пара (15:20-16:50)", "6 Пара (16:55-18:25)", "7 Пара (18:30-20:00)", "8 Пара (20:05-21:35)" });
            Lesson_choice.Location = new Point(23, 317);
            Lesson_choice.Name = "Lesson_choice";
            Lesson_choice.Size = new Size(169, 23);
            Lesson_choice.TabIndex = 9;
            Lesson_choice.MouseMove += Lesson_choice_MouseMove;
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(417, 463);
            Controls.Add(Lesson_choice);
            Controls.Add(Logout);
            Controls.Add(RentDate);
            Controls.Add(label4);
            Controls.Add(RentButton);
            Controls.Add(label3);
            Controls.Add(ClassroomsList);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "BookingForm";
            Text = "BookingForm";
            FormClosed += BookingForm_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button RentButton;
        private Label label4;
        private Button Logout;
        internal ComboBox Lesson_choice;
        internal DateTimePicker RentDate;
        internal ComboBox ClassroomsList;
    }
}