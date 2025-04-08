namespace BookingSys
{
    partial class AutForm
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
            ToRegForm = new LinkLabel();
            AutLogin = new TextBox();
            AutPass = new TextBox();
            label3 = new Label();
            label4 = new Label();
            AutButton = new Button();
            CheckPass = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(255, 128, 0);
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(1, 1);
            label1.Name = "label1";
            label1.Size = new Size(318, 100);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ToRegForm
            // 
            ToRegForm.AutoSize = true;
            ToRegForm.Location = new Point(121, 338);
            ToRegForm.Name = "ToRegForm";
            ToRegForm.Size = new Size(83, 15);
            ToRegForm.TabIndex = 2;
            ToRegForm.TabStop = true;
            ToRegForm.Text = "Нет аккаунта?";
            ToRegForm.LinkClicked += ToRegForm_LinkClicked;
            // 
            // AutLogin
            // 
            AutLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AutLogin.Location = new Point(66, 136);
            AutLogin.Multiline = true;
            AutLogin.Name = "AutLogin";
            AutLogin.Size = new Size(193, 33);
            AutLogin.TabIndex = 3;
            // 
            // AutPass
            // 
            AutPass.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            AutPass.Location = new Point(66, 203);
            AutPass.Multiline = true;
            AutPass.Name = "AutPass";
            AutPass.PasswordChar = '*';
            AutPass.Size = new Size(193, 33);
            AutPass.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 118);
            label3.Name = "label3";
            label3.Size = new Size(123, 15);
            label3.TabIndex = 5;
            label3.Text = "Логин или ваш Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 185);
            label4.Name = "label4";
            label4.Size = new Size(49, 15);
            label4.TabIndex = 6;
            label4.Text = "Пароль";
            // 
            // AutButton
            // 
            AutButton.BackColor = Color.FromArgb(192, 255, 192);
            AutButton.FlatStyle = FlatStyle.Flat;
            AutButton.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            AutButton.Location = new Point(66, 269);
            AutButton.Name = "AutButton";
            AutButton.Size = new Size(193, 66);
            AutButton.TabIndex = 7;
            AutButton.Text = "Авторизоваться";
            AutButton.UseVisualStyleBackColor = false;
            AutButton.Click += AutButton_Click;
            // 
            // CheckPass
            // 
            CheckPass.AutoSize = true;
            CheckPass.FlatStyle = FlatStyle.Flat;
            CheckPass.Location = new Point(72, 242);
            CheckPass.Name = "CheckPass";
            CheckPass.Size = new Size(116, 19);
            CheckPass.TabIndex = 8;
            CheckPass.Text = "Показать пароль";
            CheckPass.UseVisualStyleBackColor = true;
            CheckPass.CheckedChanged += CheckPass_CheckedChanged;
            // 
            // AutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(319, 362);
            Controls.Add(CheckPass);
            Controls.Add(AutButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(AutPass);
            Controls.Add(AutLogin);
            Controls.Add(ToRegForm);
            Controls.Add(label1);
            Name = "AutForm";
            Text = "AutoForm";
            FormClosed += AutForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private LinkLabel ToRegForm;
        private Label label3;
        private Label label4;
        private Button AutButton;
        private CheckBox CheckPass;
        internal TextBox AutLogin;
        internal TextBox AutPass;
    }
}