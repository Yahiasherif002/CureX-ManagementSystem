namespace CureX.Forms
{
    partial class DoctorForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewAppointments;
        private System.Windows.Forms.TextBox txtPatientContact;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Label lblPatientContact;
        private System.Windows.Forms.Label lblStatus;

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
            dataGridViewAppointments = new DataGridView();
            txtPatientContact = new TextBox();
            btnSearch = new Button();
            cmbStatus = new ComboBox();
            btnUpdateStatus = new Button();
            lblPatientContact = new Label();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAppointments
            // 
            dataGridViewAppointments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAppointments.Location = new Point(12, 12);
            dataGridViewAppointments.Name = "dataGridViewAppointments";
            dataGridViewAppointments.Size = new Size(600, 200);
            dataGridViewAppointments.TabIndex = 0;
            // 
            // txtPatientContact
            // 
            txtPatientContact.Location = new Point(12, 230);
            txtPatientContact.Name = "txtPatientContact";
            txtPatientContact.Size = new Size(150, 20);
            txtPatientContact.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(170, 228);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Pending", "Completed", "Cancelled" });
            cmbStatus.Location = new Point(12, 270);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(150, 21);
            cmbStatus.TabIndex = 3;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.Location = new Point(170, 268);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(75, 23);
            btnUpdateStatus.TabIndex = 4;
            btnUpdateStatus.Text = "Update Status";
            btnUpdateStatus.UseVisualStyleBackColor = true;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // lblPatientContact
            // 
            lblPatientContact.AutoSize = true;
            lblPatientContact.Location = new Point(12, 210);
            lblPatientContact.Name = "lblPatientContact";
            lblPatientContact.Size = new Size(85, 13);
            lblPatientContact.TabIndex = 5;
            lblPatientContact.Text = "Patient Contact:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(12, 250);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(40, 13);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status:";
            // 
            // DoctorForm
            // 
            ClientSize = new Size(634, 311);
            Controls.Add(lblStatus);
            Controls.Add(lblPatientContact);
            Controls.Add(btnUpdateStatus);
            Controls.Add(cmbStatus);
            Controls.Add(btnSearch);
            Controls.Add(txtPatientContact);
            Controls.Add(dataGridViewAppointments);
            Name = "DoctorForm";
            Text = "Doctor Dashboard";
            ((System.ComponentModel.ISupportInitialize)dataGridViewAppointments).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
