namespace LoginForm
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            txt_password = new TextBox();
            txt_username = new TextBox();
            Username = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.DeepSkyBlue;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txt_password);
            panel1.Controls.Add(txt_username);
            panel1.Controls.Add(Username);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(115, 78);
            panel1.Name = "panel1";
            panel1.Size = new Size(1078, 578);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(469, 223);
            label3.Name = "label3";
            label3.Size = new Size(61, 20);
            label3.TabIndex = 8;
            label3.Text = "Sign Up";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(309, 223);
            label2.Name = "label2";
            label2.Size = new Size(163, 20);
            label2.TabIndex = 7;
            label2.Text = "Don't have an account?";
            // 
            // button1
            // 
            button1.BackColor = Color.Azure;
            button1.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(309, 191);
            button1.Name = "button1";
            button1.Size = new Size(206, 29);
            button1.TabIndex = 6;
            button1.Text = "Log In";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(309, 115);
            label1.Name = "label1";
            label1.Size = new Size(85, 18);
            label1.TabIndex = 4;
            label1.Text = "Password";
            label1.Click += label1_Click_1;
            // 
            // txt_password
            // 
            txt_password.Location = new Point(309, 136);
            txt_password.Multiline = true;
            txt_password.Name = "txt_password";
            txt_password.PasswordChar = '*';
            txt_password.Size = new Size(206, 34);
            txt_password.TabIndex = 3;
            // 
            // txt_username
            // 
            txt_username.Location = new Point(309, 64);
            txt_username.Multiline = true;
            txt_username.Name = "txt_username";
            txt_username.Size = new Size(206, 34);
            txt_username.TabIndex = 2;
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Font = new Font("Stencil", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Username.Location = new Point(309, 43);
            Username.Name = "Username";
            Username.Size = new Size(85, 18);
            Username.TabIndex = 1;
            Username.Text = "Username";
            Username.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(263, 240);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Login
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumTurquoise;
            ClientSize = new Size(1315, 780);
            Controls.Add(panel1);
            MaximizeBox = false;
            MaximumSize = new Size(1333, 827);
            MinimizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "+";
            WindowState = FormWindowState.Maximized;
            FormClosing += Login_FormClosing;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txt_username;
        private Label Username;
        private PictureBox pictureBox1;
        private Label label1;
        private TextBox txt_password;
        private Button button1;
        private Label label3;
        private Label label2;
    }
}
