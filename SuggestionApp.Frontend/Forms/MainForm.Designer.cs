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
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Location = new Point(21, 147);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.RowHeadersWidth = 62;
            dataGridViewProducts.Size = new Size(427, 265);
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
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1141, 626);
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
        }

        #endregion

        private DataGridView dataGridViewProducts;
        private Button getProductsButton;
        private Button createSuggestionButton;
        private Button addUserButton;
        private Button addProductButton;
    }
}
