using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TicketsApp
{
    public partial class AdminForm : Form
    {
        private List<Ticket> tickets;

        public AdminForm()
        {
            InitializeComponent();
            LoadTickets();
            this.KeyDown += AdminForm_KeyDown;
            dgvTickets.KeyDown += AdminForm_KeyDown;
        }

        private void AdminForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnResolveTicket_Click(sender, e);
            }
        }

        private void LoadTickets()
        {
            tickets = TicketService.GetAllTickets();
            dgvTickets.DataSource = null;
            dgvTickets.DataSource = tickets;
        }

        private void btnResolveTicket_Click(object sender, EventArgs e)
        {
            if (dgvTickets.SelectedRows.Count > 0)
            {
                var selectedTicket = (Ticket)dgvTickets.SelectedRows[0].DataBoundItem;
                selectedTicket.Status = "Closed";

                bool updated = TicketService.UpdateTicket(selectedTicket);

                if (updated)
                {
                    MessageBox.Show($"Ticket '{selectedTicket.Title}' closed successfully.");
                    TicketService.SendTicketClosedEmail(selectedTicket);
                }
                else
                {
                    MessageBox.Show("Failed to close the ticket. Please try again.");
                }

                LoadTickets();
            }
            else
            {
                MessageBox.Show("Please select a ticket to resolve.");
            }
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
