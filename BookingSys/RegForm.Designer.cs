namespace BookingSys
{
    partial class RegForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            RegisterButton = new Button();
            lab = new Label();
            label5 = new Label();
            label6 = new Label();
            Login = new TextBox();
            Password = new TextBox();
            Email = new TextBox();
            PassCheck = new CheckBox();
            ToAutForm = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 128, 0);
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(321, 111);
            label1.TabIndex = 0;
            label1.Text = "Регистрация";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RegisterButton
            // 
            RegisterButton.BackColor = Color.FromArgb(192, 255, 192);
            RegisterButton.FlatStyle = FlatStyle.Flat;
            RegisterButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            RegisterButton.ForeColor = SystemColors.ActiveCaptionText;
            RegisterButton.Location = new Point(58, 353);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(200, 64);
            RegisterButton.TabIndex = 8;
            RegisterButton.Text = "Зарегестрироваться";
            RegisterButton.UseVisualStyleBackColor = false;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // lab
            // 
            lab.AutoSize = true;
            lab.Location = new Point(58, 130);
            lab.Name = "lab";
            lab.Size = new Size(41, 15);
            lab.TabIndex = 10;
            lab.Text = "Логин";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(58, 193);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 12;
            label5.Text = "Пароль";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(58, 284);
            label6.Name = "label6";
            label6.Size = new Size(113, 15);
            label6.TabIndex = 13;
            label6.Text = "Электронная почта";
            // 
            // Login
            // 
            Login.BackColor = SystemColors.InactiveBorder;
            Login.BorderStyle = BorderStyle.FixedSingle;
            Login.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Login.ForeColor = SystemColors.InactiveCaptionText;
            Login.Location = new Point(58, 148);
            Login.Multiline = true;
            Login.Name = "Login";
            Login.Size = new Size(200, 31);
            Login.TabIndex = 15;
            // 
            // Password
            // 
            Password.BackColor = SystemColors.InactiveBorder;
            Password.BorderStyle = BorderStyle.FixedSingle;
            Password.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Password.ForeColor = SystemColors.InactiveCaptionText;
            Password.Location = new Point(58, 211);
            Password.Multiline = true;
            Password.Name = "Password";
            Password.PasswordChar = '*';
            Password.Size = new Size(200, 31);
            Password.TabIndex = 16;
            // 
            // Email
            // 
            Email.BackColor = SystemColors.InactiveBorder;
            Email.BorderStyle = BorderStyle.FixedSingle;
            Email.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Email.ForeColor = SystemColors.InactiveCaptionText;
            Email.Location = new Point(58, 302);
            Email.Multiline = true;
            Email.Name = "Email";
            Email.Size = new Size(200, 31);
            Email.TabIndex = 17;
            // 
            // PassCheck
            // 
            PassCheck.FlatStyle = FlatStyle.Flat;
            PassCheck.ForeColor = SystemColors.ActiveCaptionText;
            PassCheck.Location = new Point(58, 248);
            PassCheck.Name = "PassCheck";
            PassCheck.Size = new Size(122, 19);
            PassCheck.TabIndex = 18;
            PassCheck.Text = "Показать пароль";
            PassCheck.UseVisualStyleBackColor = true;
            PassCheck.CheckedChanged += PassCheck_CheckedChanged;
            // 
            // ToAutForm
            // 
            ToAutForm.AutoSize = true;
            ToAutForm.Location = new Point(99, 433);
            ToAutForm.Name = "ToAutForm";
            ToAutForm.Size = new Size(105, 15);
            ToAutForm.TabIndex = 19;
            ToAutForm.TabStop = true;
            ToAutForm.Text = "Уже есть аккаунт?";
            ToAutForm.LinkClicked += ToAutForm_LinkClicked_1;
            // 
            // RegForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(320, 457);
            Controls.Add(ToAutForm);
            Controls.Add(PassCheck);
            Controls.Add(Email);
            Controls.Add(Password);
            Controls.Add(Login);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(lab);
            Controls.Add(RegisterButton);
            Controls.Add(label1);
            ForeColor = SystemColors.ActiveCaptionText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "RegForm";
            Text = "Регистрация";
            TransparencyKey = SystemColors.ButtonHighlight;
            FormClosed += RegForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button RegisterButton;
        private Label lab;
        private Label label5;
        private Label label6;
        private CheckBox PassCheck;
        private LinkLabel ToAutForm;
        internal TextBox Password;
        internal TextBox Email;
        internal TextBox Login;
    }
}
