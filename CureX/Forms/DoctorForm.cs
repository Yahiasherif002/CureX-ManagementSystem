using Backend.Models.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CureX.Forms
{
    public partial class DoctorForm : Form
    {
        private readonly HttpClient _client = new HttpClient();
        private const string BaseApiUrl = "https://localhost:7072/api/appointment";
        

        public DoctorForm()
        {
            InitializeComponent();
            LoadTodayAppointments();
        }

        private async void LoadTodayAppointments()
        {
            try
            {
                var response = await _client.GetAsync($"{BaseApiUrl}/today");
                response.EnsureSuccessStatusCode();

                var appointments = await response.Content.ReadFromJsonAsync<List<Appointment>>();
                dataGridViewAppointments.DataSource = appointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientContact.Text))
            {
                MessageBox.Show("Please enter a patient contact number");
                return;
            }

            try
            {
                var response = await _client.GetAsync($"{BaseApiUrl}?patientContact={txtPatientContact.Text}");
                response.EnsureSuccessStatusCode();

                var appointments = await response.Content.ReadFromJsonAsync<List<Appointment>>();
                dataGridViewAppointments.DataSource = appointments;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search failed: {ex.Message}");
            }
        }

        private async void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dataGridViewAppointments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an appointment");
                return;
            }

            var selectedAppointment = (Appointment)dataGridViewAppointments.SelectedRows[0].DataBoundItem;

            var request = new UpdateStatusRequest
            {
                PatientContact = selectedAppointment.PatientContact,
                Status = cmbStatus.SelectedItem.ToString()
            };

            try
            {
                var response = await _client.PutAsJsonAsync($"{BaseApiUrl}/update-status", request);
                response.EnsureSuccessStatusCode();

                MessageBox.Show("Status updated successfully");
                LoadTodayAppointments(); // Refresh the list
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed: {ex.Message}");
            }
        }

        // Appointment class to match API DTO
        public class Appointment
        {
            public int Id { get; set; }
            public string PatientContact { get; set; }
            public DateTime AppointmentDate { get; set; }
            public string Status { get; set; }
        }

        // Update status request DTO
        public class UpdateStatusRequest
        {
            public string PatientContact { get; set; }
            public string Status { get; set; }
        }

        private void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
