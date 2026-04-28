
using System.Windows.Forms;

namespace TicketsApp
{
    partial class AdminForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.Button btnResolveTicket;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.btnResolveTicket = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTickets
            // 
            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.AllowUserToDeleteRows = false;
            this.dgvTickets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTickets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTickets.BackgroundColor = System.Drawing.Color.White;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.Location = new System.Drawing.Point(12, 12);
            this.dgvTickets.MultiSelect = false;
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.ReadOnly = true;
            this.dgvTickets.RowHeadersWidth = 51;
            this.dgvTickets.RowTemplate.Height = 24;
            this.dgvTickets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTickets.Size = new System.Drawing.Size(1071, 454);
            this.dgvTickets.TabIndex = 0;
            // 
            // btnResolveTicket
            // 
            this.btnResolveTicket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResolveTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnResolveTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResolveTicket.FlatAppearance.BorderSize = 0;
            this.btnResolveTicket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.btnResolveTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResolveTicket.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnResolveTicket.ForeColor = System.Drawing.Color.White;
            this.btnResolveTicket.Location = new System.Drawing.Point(12, 472);
            this.btnResolveTicket.Name = "btnResolveTicket";
            this.btnResolveTicket.Size = new System.Drawing.Size(1071, 45);
            this.btnResolveTicket.TabIndex = 1;
            this.btnResolveTicket.Text = "Resolve Ticket";
            this.btnResolveTicket.UseVisualStyleBackColor = false;
            this.btnResolveTicket.Click += new System.EventHandler(this.btnResolveTicket_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1095, 550);
            this.Controls.Add(this.btnResolveTicket);
            this.Controls.Add(this.dgvTickets);
            this.Name = "AdminForm";
            this.Text = "Admin Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.ResumeLayout(false);

        }

       
    }
}
