using System;
using System.Drawing;
using System.Windows.Forms;

namespace TicketsApp
{
    partial class UserForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox lstUserTickets;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnSubmitTicket;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblUserTickets;

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
            this.lstUserTickets = new System.Windows.Forms.ListBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnSubmitTicket = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblUserTickets = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstUserTickets
            // 
            this.lstUserTickets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstUserTickets.BackColor = System.Drawing.Color.White;
            this.lstUserTickets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lstUserTickets.FormattingEnabled = true;
            this.lstUserTickets.ItemHeight = 16;
            this.lstUserTickets.Location = new System.Drawing.Point(295, 350);
            this.lstUserTickets.Name = "lstUserTickets";
            this.lstUserTickets.Size = new System.Drawing.Size(387, 180);
            this.lstUserTickets.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.BackColor = System.Drawing.Color.White;
            this.txtTitle.ForeColor = System.Drawing.Color.Gray;
            this.txtTitle.Location = new System.Drawing.Point(295, 49);
            this.txtTitle.Multiline = true;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(387, 29);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.Enter += new System.EventHandler(this.OnEnterTextbox);
            this.txtTitle.Leave += new System.EventHandler(this.OnLeaveTextbox);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtDescription.Location = new System.Drawing.Point(295, 127);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(387, 117);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Enter += new System.EventHandler(this.OnEnterTextbox);
            this.txtDescription.Leave += new System.EventHandler(this.OnLeaveTextbox);
            // 
            // btnSubmitTicket
            // 
            this.btnSubmitTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitTicket.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnSubmitTicket.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitTicket.FlatAppearance.BorderSize = 0;
            this.btnSubmitTicket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.btnSubmitTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitTicket.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.btnSubmitTicket.ForeColor = System.Drawing.Color.White;
            this.btnSubmitTicket.Location = new System.Drawing.Point(295, 262);
            this.btnSubmitTicket.Name = "btnSubmitTicket";
            this.btnSubmitTicket.Size = new System.Drawing.Size(387, 33);
            this.btnSubmitTicket.TabIndex = 3;
            this.btnSubmitTicket.Text = "Submit Ticket";
            this.btnSubmitTicket.UseVisualStyleBackColor = false;
            this.btnSubmitTicket.Click += new System.EventHandler(this.btnSubmitTicket_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblTitle.Location = new System.Drawing.Point(291, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(58, 24);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Title:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblDescription.Location = new System.Drawing.Point(291, 91);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(125, 24);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Description:";
            // 
            // lblUserTickets
            // 
            this.lblUserTickets.AutoSize = true;
            this.lblUserTickets.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblUserTickets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblUserTickets.Location = new System.Drawing.Point(291, 311);
            this.lblUserTickets.Name = "lblUserTickets";
            this.lblUserTickets.Size = new System.Drawing.Size(130, 24);
            this.lblUserTickets.TabIndex = 6;
            this.lblUserTickets.Text = "Your tickets:";
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(968, 551);
            this.Controls.Add(this.lblUserTickets);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSubmitTicket);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lstUserTickets);
            this.Name = "UserForm";
            this.Text = "User Form";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

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
