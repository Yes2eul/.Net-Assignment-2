using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _13978248_Assignment_2
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void LoginScreen_Load(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            bool loginSuccessful = false;
            string[] users = File.ReadAllLines("login.txt");
            foreach (string user in users)
            {
                string[] separator = { ",", " " };
                string[] userInfo = user.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (username_textBox.Text == userInfo[0] && password_textBox.Text == userInfo[1])
                {
                    loginSuccessful = true;
                    Hide();
                    new TextEditor(this, $"{userInfo[3]} {userInfo[4]}", userInfo[2]).Show();
                    break;
                }
            }
            if (!loginSuccessful)
                MessageBox.Show("Incorrect username or password.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);

            password_textBox.Text = string.Empty;
        }

        private void password_textBox_TextChanged(object sender, EventArgs e)
        {
            password_textBox.PasswordChar = '*';
        }

        private void signup_button_Click(object sender, EventArgs e)
        {
            Hide();
            new NewUser(this).Show();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginScreen));
            this.welcome_label = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.login_button = new System.Windows.Forms.Button();
            this.signup_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcome_label
            // 
            this.welcome_label.AutoSize = true;
            this.welcome_label.Font = new System.Drawing.Font("Malgun Gothic", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.welcome_label.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.welcome_label.Location = new System.Drawing.Point(500, 50);
            this.welcome_label.Name = "welcome_label";
            this.welcome_label.Size = new System.Drawing.Size(295, 71);
            this.welcome_label.TabIndex = 0;
            this.welcome_label.Text = "WELCOME";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.BackColor = System.Drawing.Color.MintCream;
            this.username_label.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.username_label.Image = ((System.Drawing.Image)(resources.GetObject("username_label.Image")));
            this.username_label.Location = new System.Drawing.Point(426, 235);
            this.username_label.Name = "username_label";
            this.username_label.Padding = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.username_label.Size = new System.Drawing.Size(75, 49);
            this.username_label.TabIndex = 1;
            this.username_label.Text = "     ";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.BackColor = System.Drawing.Color.MintCream;
            this.password_label.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.password_label.Image = ((System.Drawing.Image)(resources.GetObject("password_label.Image")));
            this.password_label.Location = new System.Drawing.Point(409, 322);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(108, 45);
            this.password_label.TabIndex = 2;
            this.password_label.Text = "        ";
            // 
            // username_textBox
            // 
            this.username_textBox.BackColor = System.Drawing.SystemColors.Window;
            this.username_textBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.username_textBox.Location = new System.Drawing.Point(488, 237);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(350, 39);
            this.username_textBox.TabIndex = 3;
            this.username_textBox.Text = "Enter Username";
            // 
            // password_textBox
            // 
            this.password_textBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.password_textBox.Location = new System.Drawing.Point(488, 324);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(350, 39);
            this.password_textBox.TabIndex = 4;
            this.password_textBox.Text = "Enter Password";
            this.password_textBox.TextChanged += new System.EventHandler(this.password_textBox_TextChanged);
            // 
            // login_button
            // 
            this.login_button.BackColor = System.Drawing.Color.LightBlue;
            this.login_button.Font = new System.Drawing.Font("Malgun Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.login_button.ForeColor = System.Drawing.Color.Black;
            this.login_button.Location = new System.Drawing.Point(409, 440);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(444, 46);
            this.login_button.TabIndex = 5;
            this.login_button.Text = "LOGIN";
            this.login_button.UseVisualStyleBackColor = false;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // signup_button
            // 
            this.signup_button.BackColor = System.Drawing.Color.Azure;
            this.signup_button.Font = new System.Drawing.Font("Malgun Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.signup_button.Location = new System.Drawing.Point(409, 534);
            this.signup_button.Name = "signup_button";
            this.signup_button.Size = new System.Drawing.Size(444, 46);
            this.signup_button.TabIndex = 6;
            this.signup_button.Text = "SIGN UP";
            this.signup_button.UseVisualStyleBackColor = false;
            this.signup_button.Click += new System.EventHandler(this.signup_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.BackColor = System.Drawing.Color.White;
            this.exit_button.Font = new System.Drawing.Font("Malgun Gothic", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.exit_button.ForeColor = System.Drawing.Color.Gray;
            this.exit_button.Location = new System.Drawing.Point(993, 623);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(150, 63);
            this.exit_button.TabIndex = 7;
            this.exit_button.Text = "EXIT";
            this.exit_button.UseVisualStyleBackColor = false;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // LoginScreen
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1254, 729);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.signup_button);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.welcome_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginScreen";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}