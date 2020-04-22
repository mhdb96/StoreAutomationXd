namespace StoreAutomationUI
{
    partial class add_activity_entry
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
            this.ID = new MetroFramework.Controls.MetroTextBox();
            this.desc = new MetroFramework.Controls.MetroTextBox();
            this.ammount = new MetroFramework.Controls.MetroTextBox();
            this.activityList = new MetroFramework.Controls.MetroComboBox();
            this.cancel = new MetroFramework.Controls.MetroButton();
            this.addActivityBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // ID
            // 
            // 
            // 
            // 
            this.ID.CustomButton.Image = null;
            this.ID.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.ID.CustomButton.Name = "";
            this.ID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ID.CustomButton.TabIndex = 1;
            this.ID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ID.CustomButton.UseSelectable = true;
            this.ID.CustomButton.Visible = false;
            this.ID.Enabled = false;
            this.ID.Lines = new string[0];
            this.ID.Location = new System.Drawing.Point(161, 227);
            this.ID.MaxLength = 32767;
            this.ID.Name = "ID";
            this.ID.PasswordChar = '\0';
            this.ID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ID.SelectedText = "";
            this.ID.SelectionLength = 0;
            this.ID.SelectionStart = 0;
            this.ID.ShortcutsEnabled = true;
            this.ID.Size = new System.Drawing.Size(98, 23);
            this.ID.TabIndex = 0;
            this.ID.UseSelectable = true;
            this.ID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // desc
            // 
            // 
            // 
            // 
            this.desc.CustomButton.Image = null;
            this.desc.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.desc.CustomButton.Name = "";
            this.desc.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.desc.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.desc.CustomButton.TabIndex = 1;
            this.desc.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.desc.CustomButton.UseSelectable = true;
            this.desc.CustomButton.Visible = false;
            this.desc.Lines = new string[0];
            this.desc.Location = new System.Drawing.Point(161, 256);
            this.desc.MaxLength = 45;
            this.desc.Name = "desc";
            this.desc.PasswordChar = '\0';
            this.desc.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.desc.SelectedText = "";
            this.desc.SelectionLength = 0;
            this.desc.SelectionStart = 0;
            this.desc.ShortcutsEnabled = true;
            this.desc.Size = new System.Drawing.Size(276, 23);
            this.desc.TabIndex = 1;
            this.desc.UseSelectable = true;
            this.desc.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.desc.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ammount
            // 
            // 
            // 
            // 
            this.ammount.CustomButton.Image = null;
            this.ammount.CustomButton.Location = new System.Drawing.Point(76, 1);
            this.ammount.CustomButton.Name = "";
            this.ammount.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ammount.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ammount.CustomButton.TabIndex = 1;
            this.ammount.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ammount.CustomButton.UseSelectable = true;
            this.ammount.CustomButton.Visible = false;
            this.ammount.Lines = new string[0];
            this.ammount.Location = new System.Drawing.Point(161, 285);
            this.ammount.MaxLength = 10;
            this.ammount.Name = "ammount";
            this.ammount.PasswordChar = '\0';
            this.ammount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ammount.SelectedText = "";
            this.ammount.SelectionLength = 0;
            this.ammount.SelectionStart = 0;
            this.ammount.ShortcutsEnabled = true;
            this.ammount.Size = new System.Drawing.Size(98, 23);
            this.ammount.TabIndex = 2;
            this.ammount.UseSelectable = true;
            this.ammount.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ammount.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.ammount.Click += new System.EventHandler(this.ammount_Click);
            this.ammount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ammount_KeyPress);
            // 
            // activityList
            // 
            this.activityList.FormattingEnabled = true;
            this.activityList.ItemHeight = 24;
            this.activityList.Location = new System.Drawing.Point(161, 130);
            this.activityList.Name = "activityList";
            this.activityList.Size = new System.Drawing.Size(121, 30);
            this.activityList.TabIndex = 3;
            this.activityList.UseSelectable = true;
            // 
            // cancel
            // 
            this.cancel.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.cancel.Location = new System.Drawing.Point(603, 370);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(96, 39);
            this.cancel.Style = MetroFramework.MetroColorStyle.Green;
            this.cancel.TabIndex = 26;
            this.cancel.Text = "Cancel";
            this.cancel.UseSelectable = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // addActivityBtn
            // 
            this.addActivityBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.addActivityBtn.Location = new System.Drawing.Point(501, 370);
            this.addActivityBtn.Name = "addActivityBtn";
            this.addActivityBtn.Size = new System.Drawing.Size(96, 39);
            this.addActivityBtn.Style = MetroFramework.MetroColorStyle.Green;
            this.addActivityBtn.TabIndex = 25;
            this.addActivityBtn.Text = "Add";
            this.addActivityBtn.UseSelectable = true;
            this.addActivityBtn.Click += new System.EventHandler(this.addActivityBtn_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(24, 130);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(53, 20);
            this.metroLabel1.TabIndex = 27;
            this.metroLabel1.Text = "Activity";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(21, 227);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(22, 20);
            this.metroLabel2.TabIndex = 28;
            this.metroLabel2.Text = "ID";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(21, 259);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(79, 20);
            this.metroLabel3.TabIndex = 29;
            this.metroLabel3.Text = "Description";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(24, 288);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(58, 20);
            this.metroLabel4.TabIndex = 30;
            this.metroLabel4.Text = "Amount";
            // 
            // add_activity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.addActivityBtn);
            this.Controls.Add(this.activityList);
            this.Controls.Add(this.ammount);
            this.Controls.Add(this.desc);
            this.Controls.Add(this.ID);
            this.Name = "add_activity";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Add an Activity";
            this.Load += new System.EventHandler(this.add_activity_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox ID;
        private MetroFramework.Controls.MetroTextBox desc;
        private MetroFramework.Controls.MetroTextBox ammount;
        private MetroFramework.Controls.MetroComboBox activityList;
        private MetroFramework.Controls.MetroButton cancel;
        private MetroFramework.Controls.MetroButton addActivityBtn;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}