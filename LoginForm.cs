using System;
using System.Windows.Forms;

namespace TicketsApp
{
    public partial class LoginForm : Form
    {

        private TextBox txtEmail;

        public LoginForm()
        {
            InitializeComponent();
            this.FormClosing += LoginForm_FormClosing;
            this.KeyDown += LoginForm_KeyDown;
            txtUsername.KeyDown += LoginForm_KeyDown;
            txtPassword.KeyDown += LoginForm_KeyDown;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            User user = UserService.Login(username, password);

            if (user != null)
            {
                if (user.Type == "Admin")
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else
                {
                    UserForm userForm = new UserForm(user);
                    userForm.Show();
                }

                this.Hide();
                return;
            }

            MessageBox.Show("Log in fail! Please check your username and password.");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email.");
                return;
            }

            bool isEmailSent = UserService.SendPasswordResetEmail(email);

            if (isEmailSent)
            {
                MessageBox.Show("Password reset email sent! Please check your inbox.");
            }
            else
            {
                MessageBox.Show("Error: Email not found.");
            }
        }
        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            ResetPasswordForm resetPasswordForm = new ResetPasswordForm();
            resetPasswordForm.ShowDialog();
        }
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void txtUsername_TextChanged(object sender, EventArgs e) { }
        private void LoginForm_Load(object sender, EventArgs e) { }
        private void lblNoAccount_Click(object sender, EventArgs e) { }
        private void lblPassword_Click(object sender, EventArgs e) { }
        private void lblUsername_Click(object sender, EventArgs e) { }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            // if (result == DialogResult.Yes)
            // {
            //     this.Dispose();
            //     Application.Exit();
            // }
            // else
            // {
            //     e.Cancel = true;
            // }
        }
    }
}