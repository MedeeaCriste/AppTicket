using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicketsApp
{
    public partial class RegistrationForm : Form
    {
        private TextBox txtEmail;

        public RegistrationForm()
        {
            InitializeComponent();

            this.FormClosing += RegistrationForm_FormClosing;
            this.KeyDown += RegistrationForm_KeyDown;
            txtUsername.KeyDown += RegistrationForm_KeyDown;
            txtPassword.KeyDown += RegistrationForm_KeyDown;
            txtEmail.KeyDown += RegistrationForm_KeyDown;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username is required.");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password is required.");
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email is required.");
                return;
            }

            if (UserService.UserExists(username))
            {
                MessageBox.Show("Username already exists!");
                return;
            }

            if (UserService.EmailExists(email))
            {
                MessageBox.Show("Email already exists!");
                return;
            }

            bool isCreated = UserService.CreateAccount(username, password, email);
            if (isCreated)
            {
                MessageBox.Show("Account created successfully!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error occurred during registration.");
            }
        }

        private void RegistrationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister_Click(sender, e);
            }
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void RegistrationForm_Load(object sender, EventArgs e) { }

        private void OnEnterTextbox(object sender, EventArgs e)
        {
            var txtBox = sender as TextBox;
            if (txtBox != null)
            {
                txtBox.ForeColor = Color.FromArgb(0, 102, 204);
                txtBox.BackColor = Color.White;
            }
        }

        private void OnLeaveTextbox(object sender, EventArgs e)
        {
            var txtBox = sender as TextBox;
            if (txtBox != null)
            {
                txtBox.ForeColor = Color.Gray;
                txtBox.BackColor = Color.White;
            }
        }
    }
}
