namespace SuggestionApp.Frontend.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridViewProducts = new DataGridView();
            getProductsButton = new Button();
            createSuggestionButton = new Button();
            addUserButton = new Button();
            addProductButton = new Button();
            mySuggestionsButton = new Button();
            comboBoxUsers = new ComboBox();
            getSuggestionsByIdButton = new Button();
            getAllSuggestions = new Button();
            dateTimePicker1 = new DateTimePicker();
            enumCombobox = new ComboBox();
            useDateCheckbox = new CheckBox();
            logOutButton = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Location = new Point(52, 250);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowHeadersWidth = 62;
            dataGridViewProducts.Size = new Size(645, 333);
            dataGridViewProducts.TabIndex = 0;
            // 
            // getProductsButton
            // 
            getProductsButton.Location = new Point(41, 36);
            getProductsButton.Name = "getProductsButton";
            getProductsButton.Size = new Size(112, 34);
            getProductsButton.TabIndex = 1;
            getProductsButton.Text = "Proizvodi";
            getProductsButton.UseVisualStyleBackColor = true;
            getProductsButton.Click += getProductsButton_Click;
            // 
            // createSuggestionButton
            // 
            createSuggestionButton.Location = new Point(41, 92);
            createSuggestionButton.Name = "createSuggestionButton";
            createSuggestionButton.Size = new Size(112, 35);
            createSuggestionButton.TabIndex = 2;
            createSuggestionButton.Text = "Prijedlog";
            createSuggestionButton.UseMnemonic = false;
            createSuggestionButton.UseVisualStyleBackColor = true;
            createSuggestionButton.Click += createSuggestionButton_Click;
            // 
            // addUserButton
            // 
            addUserButton.Location = new Point(707, 28);
            addUserButton.Name = "addUserButton";
            addUserButton.Size = new Size(237, 34);
            addUserButton.TabIndex = 3;
            addUserButton.Text = "Dodaj korisnika";
            addUserButton.UseVisualStyleBackColor = true;
            addUserButton.Click += addUserButton_Click;
            // 
            // addProductButton
            // 
            addProductButton.Location = new Point(707, 93);
            addProductButton.Name = "addProductButton";
            addProductButton.Size = new Size(237, 34);
            addProductButton.TabIndex = 4;
            addProductButton.Text = "Dodaj proizvod";
            addProductButton.UseVisualStyleBackColor = true;
            addProductButton.Click += addProductButton_Click;
            // 
            // mySuggestionsButton
            // 
            mySuggestionsButton.Location = new Point(236, 36);
            mySuggestionsButton.Name = "mySuggestionsButton";
            mySuggestionsButton.Size = new Size(212, 34);
            mySuggestionsButton.TabIndex = 5;
            mySuggestionsButton.Text = "Moji prijedlozi";
            mySuggestionsButton.UseVisualStyleBackColor = true;
            mySuggestionsButton.Click += mySuggestionsButton_Click;
            // 
            // comboBoxUsers
            // 
            comboBoxUsers.FormattingEnabled = true;
            comboBoxUsers.Location = new Point(863, 235);
            comboBoxUsers.Name = "comboBoxUsers";
            comboBoxUsers.Size = new Size(182, 33);
            comboBoxUsers.TabIndex = 6;
            comboBoxUsers.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // getSuggestionsByIdButton
            // 
            getSuggestionsByIdButton.Location = new Point(1129, 233);
            getSuggestionsByIdButton.Name = "getSuggestionsByIdButton";
            getSuggestionsByIdButton.Size = new Size(235, 34);
            getSuggestionsByIdButton.TabIndex = 8;
            getSuggestionsByIdButton.Text = "filtriraj";
            getSuggestionsByIdButton.UseVisualStyleBackColor = true;
            getSuggestionsByIdButton.Click += getSuggestionsByIdButton_Click;
            // 
            // getAllSuggestions
            // 
            getAllSuggestions.Location = new Point(1129, 169);
            getAllSuggestions.Name = "getAllSuggestions";
            getAllSuggestions.Size = new Size(191, 34);
            getAllSuggestions.TabIndex = 9;
            getAllSuggestions.Text = "Svi prijedlozi";
            getAllSuggestions.UseVisualStyleBackColor = true;
            getAllSuggestions.Click += getAllSuggestions_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(745, 307);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(300, 31);
            dateTimePicker1.TabIndex = 10;
            // 
            // enumCombobox
            // 
            enumCombobox.FormattingEnabled = true;
            enumCombobox.Location = new Point(863, 369);
            enumCombobox.Name = "enumCombobox";
            enumCombobox.Size = new Size(182, 33);
            enumCombobox.TabIndex = 11;
            // 
            // useDateCheckbox
            // 
            useDateCheckbox.AutoSize = true;
            useDateCheckbox.Location = new Point(1119, 311);
            useDateCheckbox.Name = "useDateCheckbox";
            useDateCheckbox.Size = new Size(143, 29);
            useDateCheckbox.TabIndex = 13;
            useDateCheckbox.Text = "koristi datum";
            useDateCheckbox.UseVisualStyleBackColor = true;
            // 
            // logOutButton
            // 
            logOutButton.Location = new Point(1177, 561);
            logOutButton.Name = "logOutButton";
            logOutButton.Size = new Size(112, 34);
            logOutButton.TabIndex = 14;
            logOutButton.Text = "Odjava";
            logOutButton.UseVisualStyleBackColor = true;
            logOutButton.Click += logOutButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1411, 667);
            Controls.Add(logOutButton);
            Controls.Add(useDateCheckbox);
            Controls.Add(enumCombobox);
            Controls.Add(dateTimePicker1);
            Controls.Add(getAllSuggestions);
            Controls.Add(getSuggestionsByIdButton);
            Controls.Add(comboBoxUsers);
            Controls.Add(mySuggestionsButton);
            Controls.Add(addProductButton);
            Controls.Add(addUserButton);
            Controls.Add(createSuggestionButton);
            Controls.Add(getProductsButton);
            Controls.Add(dataGridViewProducts);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewProducts;
        private Button getProductsButton;
        private Button createSuggestionButton;
        private Button addUserButton;
        private Button addProductButton;
        private Button mySuggestionsButton;
        private ComboBox comboBoxUsers;
        private Button getSuggestionsByIdButton;
        private Button getAllSuggestions;
        private DateTimePicker dateTimePicker1;
        private ComboBox enumCombobox;
        private CheckBox useDateCheckbox;
        private Button logOutButton;
    }
}
