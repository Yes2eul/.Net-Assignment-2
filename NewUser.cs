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
    public partial class NewUser : Form
    {
        LoginScreen loginScreen;

        public NewUser(LoginScreen loginScreen)
        {
            InitializeComponent();
            this.loginScreen = loginScreen;
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            dateOfBirthPicker.Format = DateTimePickerFormat.Custom;
            dateOfBirthPicker.MaxDate = DateTime.Today;
        }

        private bool UsernameExists(string username)
        {
            string[] users = File.ReadAllLines("login.txt");
            foreach (string user in users)
            {
                string[] separator = { ",", " " };
                string[] userInfo = user.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                if (username == userInfo[0])
                    return true;
            }
            return false;
        }
        private void pw_textBox_TextChanged(object sender, EventArgs e)
        {
            pw_textBox.PasswordChar = '*';
        }

        private void pw2_textBox_TextChanged(object sender, EventArgs e)
        {
            pw2_textBox.PasswordChar = '*';
        }

        private void sub_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fn_textBox.Text) || string.IsNullOrEmpty(ln_textBox.Text))
            {
                MessageBox.Show("Name cannot be blank.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (string.IsNullOrEmpty(un_textBox.Text))
            {
                MessageBox.Show("Username cannot be blank.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (UsernameExists(un_textBox.Text))
            {
                MessageBox.Show("Username already exists.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (string.IsNullOrEmpty(pw_textBox.Text) || string.IsNullOrEmpty(pw2_textBox.Text))
            {
                MessageBox.Show("Password cannot be blank.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (pw_textBox.Text != pw2_textBox.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (userTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select user type.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                dateOfBirthPicker.CustomFormat = "dd-MM-yyyy";
                File.AppendAllText("login.txt", $"\n{un_textBox.Text},{pw_textBox.Text}," +
                    $"{userTypeComboBox.SelectedItem},{fn_textBox.Text},{ln_textBox.Text}," +
                    $"{dateOfBirthPicker.Text}");
                MessageBox.Show("Account created successfully.", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                loginScreen.Show();
            }
        }

        private void cc_button_Click(object sender, EventArgs e)
        {
            Close();
            loginScreen.Show();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewUser));
            this.signup_label = new System.Windows.Forms.Label();
            this.un_label = new System.Windows.Forms.Label();
            this.pw_label = new System.Windows.Forms.Label();
            this.fn_label = new System.Windows.Forms.Label();
            this.ln_label = new System.Windows.Forms.Label();
            this.pw2_label = new System.Windows.Forms.Label();
            this.fn_textBox = new System.Windows.Forms.TextBox();
            this.ln_textBox = new System.Windows.Forms.TextBox();
            this.un_textBox = new System.Windows.Forms.TextBox();
            this.pw_textBox = new System.Windows.Forms.TextBox();
            this.pw2_textBox = new System.Windows.Forms.TextBox();
            this.sub_button = new System.Windows.Forms.Button();
            this.cc_button = new System.Windows.Forms.Button();
            this.dateOfBirthPicker = new System.Windows.Forms.DateTimePicker();
            this.userTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ut_label = new System.Windows.Forms.Label();
            this.dob_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // signup_label
            // 
            this.signup_label.AutoSize = true;
            this.signup_label.Font = new System.Drawing.Font("Malgun Gothic", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.signup_label.Location = new System.Drawing.Point(500, 50);
            this.signup_label.Name = "signup_label";
            this.signup_label.Size = new System.Drawing.Size(247, 71);
            this.signup_label.TabIndex = 0;
            this.signup_label.Text = "SIGN UP";
            // 
            // un_label
            // 
            this.un_label.AutoSize = true;
            this.un_label.Location = new System.Drawing.Point(324, 407);
            this.un_label.Name = "un_label";
            this.un_label.Size = new System.Drawing.Size(147, 32);
            this.un_label.TabIndex = 1;
            this.un_label.Text = "USER NAME";
            // 
            // pw_label
            // 
            this.pw_label.AutoSize = true;
            this.pw_label.Location = new System.Drawing.Point(325, 511);
            this.pw_label.Name = "pw_label";
            this.pw_label.Size = new System.Drawing.Size(144, 32);
            this.pw_label.TabIndex = 2;
            this.pw_label.Text = "PASSWORD";
            // 
            // fn_label
            // 
            this.fn_label.AutoSize = true;
            this.fn_label.Location = new System.Drawing.Point(325, 166);
            this.fn_label.Name = "fn_label";
            this.fn_label.Size = new System.Drawing.Size(149, 32);
            this.fn_label.TabIndex = 3;
            this.fn_label.Text = "FIRST NAME";
            // 
            // ln_label
            // 
            this.ln_label.AutoSize = true;
            this.ln_label.Location = new System.Drawing.Point(708, 166);
            this.ln_label.Name = "ln_label";
            this.ln_label.Size = new System.Drawing.Size(144, 32);
            this.ln_label.TabIndex = 4;
            this.ln_label.Text = "LAST NAME";
            // 
            // pw2_label
            // 
            this.pw2_label.AutoSize = true;
            this.pw2_label.Location = new System.Drawing.Point(708, 511);
            this.pw2_label.Name = "pw2_label";
            this.pw2_label.Size = new System.Drawing.Size(259, 32);
            this.pw2_label.TabIndex = 5;
            this.pw2_label.Text = "CONFIRM PASSWORD";
            // 
            // fn_textBox
            // 
            this.fn_textBox.Location = new System.Drawing.Point(325, 201);
            this.fn_textBox.Name = "fn_textBox";
            this.fn_textBox.Size = new System.Drawing.Size(271, 39);
            this.fn_textBox.TabIndex = 6;
            // 
            // ln_textBox
            // 
            this.ln_textBox.Location = new System.Drawing.Point(708, 201);
            this.ln_textBox.Name = "ln_textBox";
            this.ln_textBox.Size = new System.Drawing.Size(272, 39);
            this.ln_textBox.TabIndex = 7;
            // 
            // un_textBox
            // 
            this.un_textBox.Location = new System.Drawing.Point(324, 443);
            this.un_textBox.Name = "un_textBox";
            this.un_textBox.Size = new System.Drawing.Size(271, 39);
            this.un_textBox.TabIndex = 8;
            // 
            // pw_textBox
            // 
            this.pw_textBox.Location = new System.Drawing.Point(324, 546);
            this.pw_textBox.Name = "pw_textBox";
            this.pw_textBox.Size = new System.Drawing.Size(271, 39);
            this.pw_textBox.TabIndex = 9;
            this.pw_textBox.TextChanged += new System.EventHandler(this.pw_textBox_TextChanged);
            // 
            // pw2_textBox
            // 
            this.pw2_textBox.Location = new System.Drawing.Point(708, 546);
            this.pw2_textBox.Name = "pw2_textBox";
            this.pw2_textBox.Size = new System.Drawing.Size(272, 39);
            this.pw2_textBox.TabIndex = 10;
            this.pw2_textBox.TextChanged += new System.EventHandler(this.pw2_textBox_TextChanged);
            // 
            // sub_button
            // 
            this.sub_button.BackColor = System.Drawing.Color.LightBlue;
            this.sub_button.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sub_button.ForeColor = System.Drawing.Color.Black;
            this.sub_button.Location = new System.Drawing.Point(439, 641);
            this.sub_button.Name = "sub_button";
            this.sub_button.Size = new System.Drawing.Size(150, 46);
            this.sub_button.TabIndex = 11;
            this.sub_button.Text = "SUBMIT";
            this.sub_button.UseVisualStyleBackColor = false;
            this.sub_button.Click += new System.EventHandler(this.sub_button_Click);
            // 
            // cc_button
            // 
            this.cc_button.BackColor = System.Drawing.Color.White;
            this.cc_button.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cc_button.ForeColor = System.Drawing.Color.Gray;
            this.cc_button.Location = new System.Drawing.Point(670, 641);
            this.cc_button.Name = "cc_button";
            this.cc_button.Size = new System.Drawing.Size(150, 46);
            this.cc_button.TabIndex = 12;
            this.cc_button.Text = "CANCEL";
            this.cc_button.UseVisualStyleBackColor = false;
            this.cc_button.Click += new System.EventHandler(this.cc_button_Click);
            // 
            // dateOfBirthPicker
            // 
            this.dateOfBirthPicker.Location = new System.Drawing.Point(324, 307);
            this.dateOfBirthPicker.Name = "dateOfBirthPicker";
            this.dateOfBirthPicker.Size = new System.Drawing.Size(400, 39);
            this.dateOfBirthPicker.TabIndex = 13;
            // 
            // userTypeComboBox
            // 
            this.userTypeComboBox.FormattingEnabled = true;
            this.userTypeComboBox.Items.AddRange(new object[] {
            "View",
            "Edit"});
            this.userTypeComboBox.Location = new System.Drawing.Point(708, 442);
            this.userTypeComboBox.Name = "userTypeComboBox";
            this.userTypeComboBox.Size = new System.Drawing.Size(272, 40);
            this.userTypeComboBox.TabIndex = 14;
            // 
            // ut_label
            // 
            this.ut_label.AutoSize = true;
            this.ut_label.Location = new System.Drawing.Point(708, 407);
            this.ut_label.Name = "ut_label";
            this.ut_label.Size = new System.Drawing.Size(132, 32);
            this.ut_label.TabIndex = 15;
            this.ut_label.Text = "USER TYPE";
            // 
            // dob_label
            // 
            this.dob_label.AutoSize = true;
            this.dob_label.Location = new System.Drawing.Point(324, 272);
            this.dob_label.Name = "dob_label";
            this.dob_label.Size = new System.Drawing.Size(184, 32);
            this.dob_label.TabIndex = 16;
            this.dob_label.Text = "DATE OF BIRTH";
            // 
            // NewUser
            // 
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(1254, 729);
            this.Controls.Add(this.dob_label);
            this.Controls.Add(this.ut_label);
            this.Controls.Add(this.userTypeComboBox);
            this.Controls.Add(this.dateOfBirthPicker);
            this.Controls.Add(this.cc_button);
            this.Controls.Add(this.sub_button);
            this.Controls.Add(this.pw2_textBox);
            this.Controls.Add(this.pw_textBox);
            this.Controls.Add(this.un_textBox);
            this.Controls.Add(this.ln_textBox);
            this.Controls.Add(this.fn_textBox);
            this.Controls.Add(this.pw2_label);
            this.Controls.Add(this.ln_label);
            this.Controls.Add(this.fn_label);
            this.Controls.Add(this.pw_label);
            this.Controls.Add(this.un_label);
            this.Controls.Add(this.signup_label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewUser";
            this.Text = "New User";
            this.Load += new System.EventHandler(this.NewUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
