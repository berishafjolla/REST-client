namespace Swensen.Ior.Forms
{
    partial class BasicAuthentication
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.basicUsername = new System.Windows.Forms.TextBox();
            this.basicPassword = new System.Windows.Forms.TextBox();
            this.basicSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // basicUsername
            // 
            this.basicUsername.Location = new System.Drawing.Point(126, 42);
            this.basicUsername.Name = "basicUsername";
            this.basicUsername.Size = new System.Drawing.Size(215, 20);
            this.basicUsername.TabIndex = 2;
            // 
            // basicPassword
            // 
            this.basicPassword.Location = new System.Drawing.Point(126, 81);
            this.basicPassword.Name = "basicPassword";
            this.basicPassword.PasswordChar = '*';
            this.basicPassword.Size = new System.Drawing.Size(215, 20);
            this.basicPassword.TabIndex = 3;
            // 
            // basicSubmit
            // 
            this.basicSubmit.Location = new System.Drawing.Point(265, 124);
            this.basicSubmit.Name = "basicSubmit";
            this.basicSubmit.Size = new System.Drawing.Size(75, 23);
            this.basicSubmit.TabIndex = 4;
            this.basicSubmit.Text = "Submit";
            this.basicSubmit.UseVisualStyleBackColor = true;
            this.basicSubmit.Click += new System.EventHandler(this.basicSubmit_Click);
            // 
            // BasicAuthentication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 177);
            this.Controls.Add(this.basicSubmit);
            this.Controls.Add(this.basicPassword);
            this.Controls.Add(this.basicUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BasicAuthentication";
            this.Text = "Basic Authentication Credentials";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox basicUsername;
        private System.Windows.Forms.TextBox basicPassword;
        private System.Windows.Forms.Button basicSubmit;
    }
}