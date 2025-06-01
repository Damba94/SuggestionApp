using Newtonsoft.Json;
using SuggestionApp.Api.Dtos.ProductDtos;
using SuggestionApp.Frontend.Helpers;
using System.Net.Http.Headers;

namespace SuggestionApp.Frontend.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            string currentRole = SessionStorage.Role;

            UiHelper.SetButtonVisibility(getProductsButton, currentRole, "ADMIN", "USER");
            UiHelper.SetButtonVisibility(createSuggestionButton, currentRole, "ADMIN", "USER");
            UiHelper.SetButtonVisibility(addProductButton, currentRole, "ADMIN");
            UiHelper.SetButtonVisibility(addUserButton, currentRole, "ADMIN");
        }
        private async void getProductsButton_Click(object sender, EventArgs e)
        {
            var baseUrl = Properties.Settings.Default.ApiBaseUrl;
            var token = SessionStorage.Token;

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"{baseUrl}/product/getAll");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<GetAllProductsResponse>>(json);

                LoadProducts(products);
            }
            else
            {
                MessageBox.Show("Failed to load products: " + response.StatusCode);
            }
        }

        private void LoadProducts(List<GetAllProductsResponse> products)
        {
            dataGridViewProducts.DataSource = products;

            dataGridViewProducts.ReadOnly = true;
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.AllowUserToDeleteRows = false;

            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProducts.MultiSelect = false;

            dataGridViewProducts.Columns["Id"].Visible = false;
        }

        private void createSuggestionButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo odaberite jedan produkt prije kreiranja prijedloga.");
                return;
            }

            var selectedRow = dataGridViewProducts.SelectedRows[0];
            var product = (GetAllProductsResponse)selectedRow.DataBoundItem;
            var productId = product.Id;

            var suggestionForm = new SuggestionForm(productId);
            suggestionForm.ShowDialog();
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            var addUserFormn = new AddUserForm();
            addUserFormn.ShowDialog();
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            var addProductForm = new AddProductForm();
            addProductForm.ShowDialog();
        }
    }

}
