using Newtonsoft.Json;
using SuggestionApp.Api.Dtos.AuthDtos;
using SuggestionApp.Frontend.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SuggestionApp.Frontend.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private async void LoginButtn_Click(object sender, EventArgs e)
        {
            var baseUrl = Properties.Settings.Default.ApiBaseUrl;

            var payload = new LoginRequest
            {
                UserName = txtUsername.Text,
                Password = txtPassword.Text,
            };

            using var client = new HttpClient();

            var json = JsonConvert.SerializeObject(payload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{baseUrl}/auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);

                    var handler = new JwtSecurityTokenHandler();
                    var jwtToken = handler.ReadJwtToken(loginResponse.Jwt);
                    var role = jwtToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;

                    SessionStorage.Token = loginResponse.Jwt;
                    SessionStorage.Role = role;

                    MessageBox.Show("Login successful!");

                    var mainForm = new MainForm();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Login failed: {errorContent}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}
