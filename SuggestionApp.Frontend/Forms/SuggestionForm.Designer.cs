namespace SuggestionApp.Frontend.Forms
{
    partial class SuggestionForm
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
            suggestionTextBox = new RichTextBox();
            suggestionSubmitButton = new Button();
            SuspendLayout();
            // 
            // suggestionTextBox
            // 
            suggestionTextBox.Location = new Point(76, 35);
            suggestionTextBox.Name = "suggestionTextBox";
            suggestionTextBox.Size = new Size(559, 298);
            suggestionTextBox.TabIndex = 1;
            suggestionTextBox.Text = "";
            suggestionTextBox.TextChanged += suggestionTextBox_TextChanged;
            // 
            // suggestionSubmitButton
            // 
            suggestionSubmitButton.Location = new Point(87, 375);
            suggestionSubmitButton.Name = "suggestionSubmitButton";
            suggestionSubmitButton.Size = new Size(112, 34);
            suggestionSubmitButton.TabIndex = 2;
            suggestionSubmitButton.Text = "Pošalji";
            suggestionSubmitButton.UseVisualStyleBackColor = true;
            suggestionSubmitButton.Click += suggestionSubmitButton_Click;
            // 
            // SuggestionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(suggestionSubmitButton);
            Controls.Add(suggestionTextBox);
            Name = "SuggestionForm";
            Text = "SuggestionForm";
            Load += SuggestionForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox suggestionTextBox;
        private Button suggestionSubmitButton;
    }
}