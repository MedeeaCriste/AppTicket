using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TicketsApp
{
    public partial class UserForm : Form
    {
        private User currentUser;

        public UserForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadUserTickets();
            this.FormClosing += UserForm_FormClosing;
        }

        private void LoadUserTickets()
        {
            List<Ticket> userTickets = TicketService.GetUserTickets(currentUser);
            lstUserTickets.Items.Clear();

            foreach (var ticket in userTickets)
            {
                lstUserTickets.Items.Add($"#{ticket.Id} - {ticket.Title} - {ticket.Status}"); 
            }
        }

        private void btnSubmitTicket_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string description = txtDescription.Text;

            Ticket newTicket = new Ticket(0, title, description, currentUser); 
            if (TicketService.CreateTicket(newTicket))
            {
                MessageBox.Show("Ticket submitted successfully!");
                LoadUserTickets();
            }
            else
            {
                MessageBox.Show("Failed to submit ticket.");
            }

            txtTitle.Clear();
            txtDescription.Clear();
        }
        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            //DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    this.Dispose();
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
