namespace SuggestionApp.Frontend.Forms
{
    partial class AddProductForm
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
            label1 = new Label();
            txtProductName = new TextBox();
            addProductButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(105, 116);
            label1.Name = "label1";
            label1.Size = new Size(140, 25);
            label1.TabIndex = 0;
            label1.Text = "Naziv proizvoda";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(318, 118);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(242, 31);
            txtProductName.TabIndex = 1;
            // 
            // addProductButton
            // 
            addProductButton.Location = new Point(202, 287);
            addProductButton.Name = "addProductButton";
            addProductButton.Size = new Size(299, 34);
            addProductButton.TabIndex = 2;
            addProductButton.Text = "Dodaj proizvod";
            addProductButton.UseVisualStyleBackColor = true;
            addProductButton.Click += addProductButton_Click;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(addProductButton);
            Controls.Add(txtProductName);
            Controls.Add(label1);
            Name = "AddProductForm";
            Text = "AddProductForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtProductName;
        private Button addProductButton;
    }
}