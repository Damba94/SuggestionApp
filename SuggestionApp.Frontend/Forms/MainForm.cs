using Newtonsoft.Json;
using SuggestionApp.Api.Dtos.ProductDtos;
using SuggestionApp.Frontend.Dtos.SuggestionDtos;
using SuggestionApp.Frontend.Dtos.User;
using SuggestionApp.Frontend.Helpers;
using System.Net.Http.Headers;
using System.Web;

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
            UiHelper.SetButtonVisibility(createSuggestionButton, currentRole, "USER");
            UiHelper.SetButtonVisibility(addProductButton, currentRole, "ADMIN");
            UiHelper.SetButtonVisibility(addUserButton, currentRole, "ADMIN");
            UiHelper.SetButtonVisibility(mySuggestionsButton, currentRole, "USER");
            UiHelper.SetButtonVisibility(getSuggestionButton, currentRole, "ADMIN");
            UiHelper.SetButtonVisibility(getSuggestionsByIdButton, currentRole, "ADMIN");
            UiHelper.SetButtonVisibility(getAllSuggestions, currentRole, "ADMIN");
            UiHelper.SetCheckBoxVisibility(useDateCheckbox, currentRole, "ADMIN");
            UiHelper.SetComboBoxVisibility(comboBoxUsers, currentRole, "ADMIN");
            UiHelper.SetComboBoxVisibility(enumCombobox, currentRole, "ADMIN");
            UiHelper.SetDatePickerVisibility(dateTimePicker1, currentRole, "ADMIN");
            if(SessionStorage.Role == "ADMIN")
                LoadUsersIntoComboBox();
            LoadStatusIntoCobobox();
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

        private void LoadSuggestionsByUser(List<GetAllSuggestionsByUserIdResponse> suggestions)
        {
            dataGridViewProducts.DataSource = suggestions;

            dataGridViewProducts.ReadOnly = true;
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.AllowUserToDeleteRows = false;

            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProducts.MultiSelect = false;

            dataGridViewProducts.Columns["SuggestionId"].Visible = false;
        }

        private void LoadSuggestions(List<GetAllSuggestionResponse> suggestions)
        {
            dataGridViewProducts.DataSource = suggestions;

            dataGridViewProducts.ReadOnly = true;
            dataGridViewProducts.AllowUserToAddRows = false;
            dataGridViewProducts.AllowUserToDeleteRows = false;

            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProducts.MultiSelect = false;

            dataGridViewProducts.Columns["SuggestionId"].Visible = false;
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

        private async void mySuggestionsButton_Click(object sender, EventArgs e)
        {
            var baseUrl = Properties.Settings.Default.ApiBaseUrl;
            var token = SessionStorage.Token;

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"{baseUrl}/suggestion/mySuggestions");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var suggestions = JsonConvert.DeserializeObject<List<GetAllSuggestionsByUserIdResponse>>(json);

                LoadSuggestionsByUser(suggestions);
            }
            else
            {
                MessageBox.Show("neuspjelo: " + response.StatusCode);
            }
        }


        private async Task LoadUsersIntoComboBox()
        {
            var baseUrl = Properties.Settings.Default.ApiBaseUrl;
            var token = SessionStorage.Token;

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"{baseUrl}/user/getAll");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<GetAllUsersResult>>(json);

                users.Insert(0, new GetAllUsersResult
                {
                    UserId = null,
                    FirstName = "Odaberi",
                    LastName = ""
                });

                var displayList = users
                   .Select(u => new
                   {
                       UserId = u.UserId,
                       FullName = $"{u.FirstName} {u.LastName}"
                   })
                    .ToList();

                comboBoxUsers.DataSource = displayList;
                comboBoxUsers.DisplayMember = "FullName";
                comboBoxUsers.ValueMember = "UserId";
            }
            else
            {
                MessageBox.Show("Failed to load users: " + response.StatusCode);
            }
        }
        public void LoadStatusIntoCobobox()
        {
            var items = new List<SuggestionStatusComboBox>
            {
                new SuggestionStatusComboBox { Text = "— Odaberi —", Value = null }
            };

            items.AddRange(Enum.GetValues(typeof(SuggestionStatus))
                .Cast<SuggestionStatus>()
                .Select(status => new SuggestionStatusComboBox
                {
                    Text = status.ToString(),
                    Value = status
                }));

            enumCombobox.DataSource = items;
            enumCombobox.DisplayMember = "Text";
            enumCombobox.ValueMember = "Value";

        }

        private async void getSuggestionsByIdButton_Click(object sender, EventArgs e)
        {
            var selectedUserId = comboBoxUsers.SelectedValue?.ToString();

            var selectidStatus = enumCombobox.SelectedValue?.ToString();

            string? productId = null;

            if (dataGridViewProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewProducts.SelectedRows[0];
                var product = (GetAllProductsResponse)selectedRow.DataBoundItem;
                productId = product.Id.ToString();
            }

            var query = HttpUtility.ParseQueryString(string.Empty);

            if (!string.IsNullOrWhiteSpace(selectedUserId))
                query["userId"] = selectedUserId;

            if (!string.IsNullOrWhiteSpace(selectidStatus))
                query["status"] = selectidStatus;

            if (productId != null)
                query["productId"] = productId;

            if (useDateCheckbox.Checked)
                query["date"] = dateTimePicker1.Value.ToString("yyyy-MM-dd");


            var baseUrl = Properties.Settings.Default.ApiBaseUrl;
            var token = SessionStorage.Token;

            var uriBuilder = new UriBuilder($"{baseUrl}/suggestion/filter")
            {
                Query = query.ToString()
            };

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync(uriBuilder.ToString());

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var suggestions = JsonConvert.DeserializeObject<List<GetAllSuggestionsByUserIdResponse>>(json);

                LoadSuggestionsByUser(suggestions);
            }
            else
            {
                MessageBox.Show("neuspjelo: " + response.StatusCode);
            }

        }

        private async void getAllSuggestions_Click(object sender, EventArgs e)
        {
            var baseUrl = Properties.Settings.Default.ApiBaseUrl;
            var token = SessionStorage.Token;

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"{baseUrl}/suggestion/getAll");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var suggestions = JsonConvert.DeserializeObject<List<GetAllSuggestionResponse>>(json);

                LoadSuggestions(suggestions);
            }
            else
            {
                MessageBox.Show("neuspjelo: " + response.StatusCode);
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            SessionStorage.Token = null;
            var loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private async void getSuggestionButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo odaberite jedan prijedlog .");
                return;
            }

            var selectedRow = dataGridViewProducts.SelectedRows[0];
            var suggestion = (GetAllSuggestionResponse)selectedRow.DataBoundItem;
            var suggestionId = suggestion.SuggestionId;

            var baseUrl = Properties.Settings.Default.ApiBaseUrl;
            var token = SessionStorage.Token;

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"{baseUrl}/suggestion/suggestion?suggestionId={suggestionId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var suggestions = JsonConvert.DeserializeObject<GetSuggestionByIdResponse>(json);

                var form = new UpdateSuggestionForm(suggestions);
                form.Show();
            }
            else
            {
                MessageBox.Show("neuspjelo: " + response.StatusCode);
            }
        }
    }
}


