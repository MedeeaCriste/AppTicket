using System;
using System.Windows.Forms;

namespace TicketsApp
{
    public partial class ResetPasswordForm : Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
            btnSendCode.Click += BtnSendCode_Click; 
            btnResetPassword.Click += BtnResetPassword_Click; 
        }

        private void BtnSendCode_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text; 

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email is required."); 
                return;
            }

           
            if (UserService.EmailExists(email))
            {
                
                bool codeSent = UserService.SendPasswordResetEmail(email);

                if (codeSent)
                {
                    MessageBox.Show("A reset code has been sent to your email."); 
                }
                else
                {
                    MessageBox.Show("Error sending reset code. Please try again."); 
                }
            }
            else
            {
                MessageBox.Show("Email does not exist.");
            }
        }

        private void BtnResetPassword_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text; 
            string code = txtCode.Text; 
            string newPassword = txtNewPassword.Text;

            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter the code and the new password."); 
                return;
            }

            
            bool isResetSuccessful = UserService.VerifyResetCode(email, code, newPassword);

            if (isResetSuccessful)
            {
                MessageBox.Show("Password has been reset successfully.");
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Invalid reset code. Please try again.");
            }
        }
    }
}
