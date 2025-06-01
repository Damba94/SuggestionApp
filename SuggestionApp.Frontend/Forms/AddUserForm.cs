using Newtonsoft.Json;
using SuggestionApp.Api.Dtos.AuthDtos;
using SuggestionApp.Frontend.Helpers;
using System.Net.Http.Headers;
using System.Text;

namespace SuggestionApp.Frontend.Forms
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        private async void submitUserButton_Click(object sender, EventArgs e)
        {
            var baseUrl = Properties.Settings.Default.ApiBaseUrl;

            var payload = new RegisterRequest
            {
                UserName = txtUsername.Text,
                Password = txtPassword.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionStorage.Token);

            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{baseUrl}/auth/register", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Korisnik je dodan!");

                    var mainForm = new MainForm();
                    this.Hide();
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"neuspješno : {errorContent}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
