using Newtonsoft.Json;
using SuggestionApp.Api.Dtos.ProductDtos;
using SuggestionApp.Frontend.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuggestionApp.Frontend.Forms
{
    public partial class AddProductForm : Form
    {
        public AddProductForm()
        {
            InitializeComponent();
        }

        private async void addProductButton_Click(object sender, EventArgs e)
        {
            var baseUrl = Properties.Settings.Default.ApiBaseUrl;

            var prodact = new CreateProductRequest
            {
                Name = txtProductName.Text
            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionStorage.Token);

            var json = JsonConvert.SerializeObject(prodact);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync($"{baseUrl}/auth/register", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    MessageBox.Show("Korisnik je dodan!");
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
