using Newtonsoft.Json;
using SuggestionApp.Api.Dtos.SuggestionDtos;
using SuggestionApp.Frontend.Dtos.SuggestionDtos;
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
    public partial class UpdateSuggestionForm : Form
    {
        private readonly GetSuggestionByIdResponse _getSuggestionByIdResponse;
        public UpdateSuggestionForm(GetSuggestionByIdResponse getSuggestionByIdResponse)
        {
            InitializeComponent();
            _getSuggestionByIdResponse = getSuggestionByIdResponse;
        }

        private void UpdateSuggestionForm_Load(object sender, EventArgs e)
        {
            nameLable.Text = _getSuggestionByIdResponse.FirstName;
            lastNameLable.Text = _getSuggestionByIdResponse.LastName;
            productLable.Text = _getSuggestionByIdResponse.ProductName;
            suggestionTxtBox.Text = _getSuggestionByIdResponse.SugestionTxt;

            var status = _getSuggestionByIdResponse.Status;

            switch (status)
            {
                case SuggestionStatus.Pending:
                    radioPending.Checked = true;
                    break;
                case SuggestionStatus.Accepted:
                    radioAccepted.Checked = true;
                    break;
                case SuggestionStatus.Rejected:
                    radioRejected.Checked = true;
                    break;
                case SuggestionStatus.UnderReview:
                    radioUnderReview.Checked = true;
                    break;
            }
        }

        private async void updateStatusButton_Click(object sender, EventArgs e)
        {
            SuggestionStatus? selectedStatus = null;

            if (radioPending.Checked) selectedStatus = SuggestionStatus.Pending;
            else if (radioAccepted.Checked) selectedStatus = SuggestionStatus.Accepted;
            else if (radioRejected.Checked) selectedStatus = SuggestionStatus.Rejected;
            else if (radioUnderReview.Checked) selectedStatus = SuggestionStatus.UnderReview;

            if (selectedStatus == null)
            {
                MessageBox.Show("Odaberi status prije spremanja!");
                return;
            }


            var baseUrl = Properties.Settings.Default.ApiBaseUrl;

            var suggestion = new ChangeSuggestionStatusRequest
            {
                SuggestionId=_getSuggestionByIdResponse.SuggestionId,
                Status=(int)selectedStatus.Value,

            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionStorage.Token);

            var json = JsonConvert.SerializeObject(suggestion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PatchAsync($"{baseUrl}/suggestion/status", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    MessageBox.Show("Status je promjenjen!");
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
