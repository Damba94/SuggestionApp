namespace SuggestionApp.Frontend.Forms
{
    partial class AddUserForm
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
            submitUserButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtFirstName = new TextBox();
            txtEmail = new TextBox();
            txtLastName = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // submitUserButton
            // 
            submitUserButton.Location = new Point(327, 363);
            submitUserButton.Name = "submitUserButton";
            submitUserButton.Size = new Size(112, 34);
            submitUserButton.TabIndex = 0;
            submitUserButton.Text = "Dodaj";
            submitUserButton.UseVisualStyleBackColor = true;
            submitUserButton.Click += submitUserButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(96, 64);
            label1.Name = "label1";
            label1.Size = new Size(42, 25);
            label1.TabIndex = 1;
            label1.Text = "Ime";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 112);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 2;
            label2.Text = "Prezime";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(96, 170);
            label3.Name = "label3";
            label3.Size = new Size(54, 25);
            label3.TabIndex = 3;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 232);
            label4.Name = "label4";
            label4.Size = new Size(91, 25);
            label4.TabIndex = 4;
            label4.Text = "Username";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(96, 297);
            label5.Name = "label5";
            label5.Size = new Size(71, 25);
            label5.TabIndex = 5;
            label5.Text = "Lozinka";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(221, 58);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(230, 31);
            txtFirstName.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(221, 164);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(230, 31);
            txtEmail.TabIndex = 7;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(221, 106);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(230, 31);
            txtLastName.TabIndex = 8;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(221, 226);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(230, 31);
            txtUsername.TabIndex = 9;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(221, 291);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(230, 31);
            txtPassword.TabIndex = 10;
            // 
            // AddUserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtLastName);
            Controls.Add(txtEmail);
            Controls.Add(txtFirstName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(submitUserButton);
            Name = "AddUserForm";
            Text = "AddUserForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button submitUserButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtFirstName;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private TextBox txtUsername;
        private TextBox txtPassword;
    }
}