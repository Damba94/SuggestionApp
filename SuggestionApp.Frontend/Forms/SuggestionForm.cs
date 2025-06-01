using Newtonsoft.Json;
using SuggestionApp.Api.Dtos.SuggestionDtos;
using SuggestionApp.Frontend.Helpers;
using System.Net.Http.Headers;
using System.Text;

namespace SuggestionApp.Frontend.Forms
{
    public partial class SuggestionForm : Form
    {
        private readonly int _productId;
        public SuggestionForm(int productId)
        {
            InitializeComponent();
            _productId = productId;
        }

        private void SuggestionForm_Load(object sender, EventArgs e)
        {

        }

        private async void suggestionSubmitButton_Click(object sender, EventArgs e)
        {
            var suggestionText = suggestionTextBox.Text;
            var baseUrl = Properties.Settings.Default.ApiBaseUrl;

            var suggestionRequest = new CreateSuggestionRequest
            {
                ProductId = _productId,
                Text = suggestionText
            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionStorage.Token);

            var json = JsonConvert.SerializeObject(suggestionRequest);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{baseUrl}//suggestion", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Prijedlog uspješno poslan!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Greška pri slanju prijedloga.");
            }
        }

        private void suggestionTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
