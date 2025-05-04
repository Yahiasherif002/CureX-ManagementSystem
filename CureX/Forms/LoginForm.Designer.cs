namespace CureX.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Required designer variable.
        /// </summary>

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            loginButton = new Button();
            passwordLabel = new Label();
            roleComboBox = new ComboBox();
            passwordTextBox = new TextBox();
            roleLabel = new Label();
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label7 = new Label();
            button1 = new Button();
            panel4 = new Panel();
            pictureBox3 = new PictureBox();
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            label6 = new Label();
            Closebtn = new Button();
            label8 = new Label();
            label9 = new Label();
            linkLabel1 = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(41, 128, 185);
            loginButton.Cursor = Cursors.Hand;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(6, 330);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(148, 35);
            loginButton.TabIndex = 2;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            passwordLabel.Location = new Point(45, 11);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(93, 21);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password:";
            // 
            // roleComboBox
            // 
            roleComboBox.BackColor = SystemColors.Control;
            roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            roleComboBox.ForeColor = Color.FromArgb(41, 128, 185);
            roleComboBox.FormattingEnabled = true;
            roleComboBox.Items.AddRange(new object[] { "Doctor", "Receptionist" });
            roleComboBox.Location = new Point(159, 9);
            roleComboBox.Name = "roleComboBox";
            roleComboBox.Size = new Size(288, 25);
            roleComboBox.TabIndex = 0;
            roleComboBox.SelectedIndexChanged += roleComboBox_SelectedIndexChanged;
            // 
            // passwordTextBox
            // 
            passwordTextBox.BackColor = SystemColors.Control;
            passwordTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.ForeColor = Color.FromArgb(41, 128, 185);
            passwordTextBox.Location = new Point(134, 14);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(288, 16);
            passwordTextBox.TabIndex = 1;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.TextChanged += passwordTextBox_TextChanged;
            // 
            // roleLabel
            // 
            roleLabel.AutoSize = true;
            roleLabel.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            roleLabel.Location = new Point(45, 14);
            roleLabel.Name = "roleLabel";
            roleLabel.Size = new Size(50, 21);
            roleLabel.TabIndex = 3;
            roleLabel.Text = "Role:";
            roleLabel.Click += roleLabel_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(41, 128, 185);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 530);
            panel1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(190, 493);
            label5.Name = "label5";
            label5.Size = new Size(110, 17);
            label5.TabIndex = 10;
            label5.Text = "جميع الحقوق محفوظة";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(65, 476);
            label4.Name = "label4";
            label4.Size = new Size(235, 17);
            label4.TabIndex = 9;
            label4.Text = "نظام كيروكس منتج ل شركة ابداعات تكنولوجيه";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(111, 317);
            label3.Name = "label3";
            label3.Size = new Size(109, 34);
            label3.TabIndex = 8;
            label3.Text = "System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(60, 277);
            label2.Name = "label2";
            label2.Size = new Size(120, 40);
            label2.TabIndex = 7;
            label2.Text = "CureX";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(70, 244);
            label1.Name = "label1";
            label1.Size = new Size(190, 34);
            label1.TabIndex = 6;
            label1.Text = "Welcome to ";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.doctor2;
            pictureBox1.Location = new Point(60, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(174, 168);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(linkLabel1);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(Closebtn);
            panel2.Controls.Add(loginButton);
            panel2.Dock = DockStyle.Fill;
            panel2.Font = new Font("Microsoft Sans Serif", 8.25F);
            panel2.Location = new Point(300, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(450, 530);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // label7
            // 
            label7.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Silver;
            label7.Location = new Point(32, 453);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 11;
            label7.Text = "Support";
            label7.Click += label7_Click_1;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(41, 128, 185);
            button1.Location = new Point(185, 337);
            button1.Name = "button1";
            button1.Size = new Size(137, 25);
            button1.TabIndex = 10;
            button1.Text = "Forget password";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Control;
            panel4.Controls.Add(pictureBox3);
            panel4.Controls.Add(passwordTextBox);
            panel4.Controls.Add(passwordLabel);
            panel4.Location = new Point(0, 265);
            panel4.Name = "panel4";
            panel4.Size = new Size(450, 45);
            panel4.TabIndex = 9;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.user__1_;
            pictureBox3.Location = new Point(15, 12);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(24, 24);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 7;
            pictureBox3.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(roleComboBox);
            panel3.Controls.Add(roleLabel);
            panel3.Location = new Point(0, 214);
            panel3.Name = "panel3";
            panel3.Size = new Size(450, 45);
            panel3.TabIndex = 8;
            panel3.Paint += panel3_Paint;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.user;
            pictureBox2.Location = new Point(15, 11);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(24, 24);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(41, 128, 185);
            label6.Location = new Point(6, 140);
            label6.Name = "label6";
            label6.Size = new Size(316, 34);
            label6.TabIndex = 7;
            label6.Text = "Login to your account";
            label6.Click += label6_Click_1;
            // 
            // Closebtn
            // 
            Closebtn.Cursor = Cursors.Hand;
            Closebtn.FlatAppearance.BorderSize = 0;
            Closebtn.FlatStyle = FlatStyle.Flat;
            Closebtn.Font = new Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Closebtn.ForeColor = Color.FromArgb(41, 128, 185);
            Closebtn.Location = new Point(410, 0);
            Closebtn.Name = "Closebtn";
            Closebtn.Size = new Size(40, 40);
            Closebtn.TabIndex = 5;
            Closebtn.Text = "X";
            Closebtn.UseVisualStyleBackColor = true;
            Closebtn.Click += Closebtn_Click;
            // 
            // label8
            // 
            label8.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Silver;
            label8.Location = new Point(32, 473);
            label8.Name = "label8";
            label8.Size = new Size(187, 20);
            label8.TabIndex = 12;
            label8.Text = "Technological Creations ©";
            label8.Click += label8_Click;
            // 
            // label9
            // 
            label9.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Silver;
            label9.Location = new Point(32, 493);
            label9.Name = "label9";
            label9.Size = new Size(112, 28);
            label9.TabIndex = 13;
            label9.Text = "For Support :";
            label9.Click += label9_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.ForeColor = Color.FromArgb(41, 128, 185);
            linkLabel1.LinkColor = Color.FromArgb(41, 128, 185);
            linkLabel1.Location = new Point(121, 492);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(161, 17);
            linkLabel1.TabIndex = 14;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "yahyasheriif@gmail.com";
            // 
            // LoginForm
            // 
            ClientSize = new Size(750, 530);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Verdana", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Curex Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }
        private Button loginButton;
        private Label passwordLabel;
        private ComboBox roleComboBox;
        private TextBox passwordTextBox;
        private Label roleLabel;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label1;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label label4;
        private Button Closebtn;
        private Label label6;
        private Panel panel4;
        private Panel panel3;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private Button button1;
        private Label label7;
        private Label label9;
        private Label label8;
        private LinkLabel linkLabel1;
    }
}