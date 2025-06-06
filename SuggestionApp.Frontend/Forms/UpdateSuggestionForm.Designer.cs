namespace SuggestionApp.Frontend.Forms
{
    partial class UpdateSuggestionForm
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
            label2 = new Label();
            label3 = new Label();
            nameLable = new Label();
            lastNameLable = new Label();
            productLable = new Label();
            suggestionTxtBox = new TextBox();
            label4 = new Label();
            radioRejected = new RadioButton();
            radioUnderReview = new RadioButton();
            radioPending = new RadioButton();
            radioAccepted = new RadioButton();
            updateStatusButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(50, 52);
            label1.Name = "label1";
            label1.Size = new Size(42, 25);
            label1.TabIndex = 0;
            label1.Text = "Ime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 111);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 1;
            label2.Text = "Prezime";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 172);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
            label3.TabIndex = 2;
            label3.Text = "Proizvod";
            // 
            // nameLable
            // 
            nameLable.AutoSize = true;
            nameLable.Location = new Point(168, 52);
            nameLable.Name = "nameLable";
            nameLable.Size = new Size(42, 25);
            nameLable.TabIndex = 3;
            nameLable.Text = "123";
            // 
            // lastNameLable
            // 
            lastNameLable.AutoSize = true;
            lastNameLable.Location = new Point(168, 111);
            lastNameLable.Name = "lastNameLable";
            lastNameLable.Size = new Size(42, 25);
            lastNameLable.TabIndex = 4;
            lastNameLable.Text = "123";
            // 
            // productLable
            // 
            productLable.AutoSize = true;
            productLable.Location = new Point(168, 172);
            productLable.Name = "productLable";
            productLable.Size = new Size(42, 25);
            productLable.TabIndex = 5;
            productLable.Text = "123";
            // 
            // suggestionTxtBox
            // 
            suggestionTxtBox.Location = new Point(366, 59);
            suggestionTxtBox.Name = "suggestionTxtBox";
            suggestionTxtBox.ReadOnly = true;
            suggestionTxtBox.Size = new Size(312, 31);
            suggestionTxtBox.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(116, 262);
            label4.Name = "label4";
            label4.Size = new Size(60, 25);
            label4.TabIndex = 7;
            label4.Text = "Status";
            // 
            // radioRejected
            // 
            radioRejected.AutoSize = true;
            radioRejected.Location = new Point(222, 262);
            radioRejected.Name = "radioRejected";
            radioRejected.Size = new Size(121, 29);
            radioRejected.TabIndex = 8;
            radioRejected.TabStop = true;
            radioRejected.Text = "ODBIJENO";
            radioRejected.UseVisualStyleBackColor = true;
            // 
            // radioUnderReview
            // 
            radioUnderReview.AutoSize = true;
            radioUnderReview.Location = new Point(389, 258);
            radioUnderReview.Name = "radioUnderReview";
            radioUnderReview.Size = new Size(191, 29);
            radioUnderReview.TabIndex = 9;
            radioUnderReview.TabStop = true;
            radioUnderReview.Text = "NA RAZMATRANJU";
            radioUnderReview.UseVisualStyleBackColor = true;
            // 
            // radioPending
            // 
            radioPending.AutoSize = true;
            radioPending.Location = new Point(598, 258);
            radioPending.Name = "radioPending";
            radioPending.Size = new Size(140, 29);
            radioPending.TabIndex = 10;
            radioPending.TabStop = true;
            radioPending.Text = "NA ČEKANJU";
            radioPending.UseVisualStyleBackColor = true;
            // 
            // radioAccepted
            // 
            radioAccepted.AutoSize = true;
            radioAccepted.Location = new Point(775, 258);
            radioAccepted.Name = "radioAccepted";
            radioAccepted.Size = new Size(145, 29);
            radioAccepted.TabIndex = 11;
            radioAccepted.TabStop = true;
            radioAccepted.Text = "PRIHVAĆENO";
            radioAccepted.UseVisualStyleBackColor = true;
            // 
            // updateStatusButton
            // 
            updateStatusButton.Location = new Point(407, 363);
            updateStatusButton.Name = "updateStatusButton";
            updateStatusButton.Size = new Size(271, 34);
            updateStatusButton.TabIndex = 12;
            updateStatusButton.Text = "Promjeni status";
            updateStatusButton.UseVisualStyleBackColor = true;
            updateStatusButton.Click += updateStatusButton_Click;
            // 
            // UpdateSuggestionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 450);
            Controls.Add(updateStatusButton);
            Controls.Add(radioAccepted);
            Controls.Add(radioPending);
            Controls.Add(radioUnderReview);
            Controls.Add(radioRejected);
            Controls.Add(label4);
            Controls.Add(suggestionTxtBox);
            Controls.Add(productLable);
            Controls.Add(lastNameLable);
            Controls.Add(nameLable);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UpdateSuggestionForm";
            Text = "UpdateSuggestionForm";
            Load += UpdateSuggestionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label nameLable;
        private Label lastNameLable;
        private Label productLable;
        private TextBox suggestionTxtBox;
        private Label label4;
        private RadioButton radioRejected;
        private RadioButton radioUnderReview;
        private RadioButton radioPending;
        private RadioButton radioAccepted;
        private Button updateStatusButton;
    }
}
