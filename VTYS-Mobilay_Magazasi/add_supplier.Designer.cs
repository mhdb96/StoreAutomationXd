namespace VTYS_Mobilay_Magazasi
{
    partial class add_supplier
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
            this.cancel = new MetroFramework.Controls.MetroButton();
            this.addSupplierBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.districtList = new MetroFramework.Controls.MetroComboBox();
            this.provinceList = new MetroFramework.Controls.MetroComboBox();
            this.adress = new MetroFramework.Controls.MetroTextBox();
            this.telephone = new MetroFramework.Controls.MetroTextBox();
            this.name = new MetroFramework.Controls.MetroTextBox();
            this.ID = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.cancel.Location = new System.Drawing.Point(664, 521);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(96, 39);
            this.cancel.Style = MetroFramework.MetroColorStyle.Green;
            this.cancel.TabIndex = 44;
            this.cancel.Text = "Cancel";
            this.cancel.UseSelectable = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // addSupplierBtn
            // 
            this.addSupplierBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.addSupplierBtn.Location = new System.Drawing.Point(562, 521);
            this.addSupplierBtn.Name = "addSupplierBtn";
            this.addSupplierBtn.Size = new System.Drawing.Size(96, 39);
            this.addSupplierBtn.Style = MetroFramework.MetroColorStyle.Green;
            this.addSupplierBtn.TabIndex = 43;
            this.addSupplierBtn.Text = "Add";
            this.addSupplierBtn.UseSelectable = true;
            this.addSupplierBtn.Click += new System.EventHandler(this.addSupplierBtn_Click);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(23, 506);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(51, 20);
            this.metroLabel8.TabIndex = 42;
            this.metroLabel8.Text = "District";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(23, 443);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(63, 20);
            this.metroLabel7.TabIndex = 41;
            this.metroLabel7.Text = "Province";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(23, 374);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(51, 20);
            this.metroLabel6.TabIndex = 40;
            this.metroLabel6.Text = "Adress";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(23, 268);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(74, 20);
            this.metroLabel4.TabIndex = 38;
            this.metroLabel4.Text = "Telephone";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(23, 160);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(47, 20);
            this.metroLabel2.TabIndex = 36;
            this.metroLabel2.Text = "Name";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(23, 113);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(22, 20);
            this.metroLabel1.TabIndex = 35;
            this.metroLabel1.Text = "ID";
            // 
            // districtList
            // 
            this.districtList.FormattingEnabled = true;
            this.districtList.ItemHeight = 24;
            this.districtList.Location = new System.Drawing.Point(173, 506);
            this.districtList.Name = "districtList";
            this.districtList.Size = new System.Drawing.Size(121, 30);
            this.districtList.Style = MetroFramework.MetroColorStyle.Purple;
            this.districtList.TabIndex = 34;
            this.districtList.UseSelectable = true;
            // 
            // provinceList
            // 
            this.provinceList.FormattingEnabled = true;
            this.provinceList.ItemHeight = 24;
            this.provinceList.Location = new System.Drawing.Point(173, 443);
            this.provinceList.Name = "provinceList";
            this.provinceList.Size = new System.Drawing.Size(121, 30);
            this.provinceList.Style = MetroFramework.MetroColorStyle.Purple;
            this.provinceList.TabIndex = 33;
            this.provinceList.UseSelectable = true;
            this.provinceList.SelectedIndexChanged += new System.EventHandler(this.provinceList_SelectedIndexChanged);
            // 
            // adress
            // 
            // 
            // 
            // 
            this.adress.CustomButton.Image = null;
            this.adress.CustomButton.Location = new System.Drawing.Point(150, 2);
            this.adress.CustomButton.Name = "";
            this.adress.CustomButton.Size = new System.Drawing.Size(51, 51);
            this.adress.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.adress.CustomButton.TabIndex = 1;
            this.adress.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.adress.CustomButton.UseSelectable = true;
            this.adress.CustomButton.Visible = false;
            this.adress.Lines = new string[0];
            this.adress.Location = new System.Drawing.Point(173, 371);
            this.adress.MaxLength = 255;
            this.adress.Multiline = true;
            this.adress.Name = "adress";
            this.adress.PasswordChar = '\0';
            this.adress.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.adress.SelectedText = "";
            this.adress.SelectionLength = 0;
            this.adress.SelectionStart = 0;
            this.adress.ShortcutsEnabled = true;
            this.adress.Size = new System.Drawing.Size(204, 56);
            this.adress.TabIndex = 32;
            this.adress.UseSelectable = true;
            this.adress.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.adress.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // telephone
            // 
            // 
            // 
            // 
            this.telephone.CustomButton.Image = null;
            this.telephone.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.telephone.CustomButton.Name = "";
            this.telephone.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.telephone.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.telephone.CustomButton.TabIndex = 1;
            this.telephone.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.telephone.CustomButton.UseSelectable = true;
            this.telephone.CustomButton.Visible = false;
            this.telephone.Lines = new string[0];
            this.telephone.Location = new System.Drawing.Point(173, 265);
            this.telephone.MaxLength = 10;
            this.telephone.Name = "telephone";
            this.telephone.PasswordChar = '\0';
            this.telephone.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.telephone.SelectedText = "";
            this.telephone.SelectionLength = 0;
            this.telephone.SelectionStart = 0;
            this.telephone.ShortcutsEnabled = true;
            this.telephone.Size = new System.Drawing.Size(121, 23);
            this.telephone.TabIndex = 30;
            this.telephone.UseSelectable = true;
            this.telephone.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.telephone.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.telephone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telephone_KeyPress);
            // 
            // name
            // 
            // 
            // 
            // 
            this.name.CustomButton.Image = null;
            this.name.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.name.CustomButton.Name = "";
            this.name.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.name.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.name.CustomButton.TabIndex = 1;
            this.name.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.name.CustomButton.UseSelectable = true;
            this.name.CustomButton.Visible = false;
            this.name.Lines = new string[0];
            this.name.Location = new System.Drawing.Point(173, 157);
            this.name.MaxLength = 45;
            this.name.Name = "name";
            this.name.PasswordChar = '\0';
            this.name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.name.SelectedText = "";
            this.name.SelectionLength = 0;
            this.name.SelectionStart = 0;
            this.name.ShortcutsEnabled = true;
            this.name.Size = new System.Drawing.Size(121, 23);
            this.name.TabIndex = 28;
            this.name.UseSelectable = true;
            this.name.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.name.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ID
            // 
            // 
            // 
            // 
            this.ID.CustomButton.Image = null;
            this.ID.CustomButton.Location = new System.Drawing.Point(99, 1);
            this.ID.CustomButton.Name = "";
            this.ID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ID.CustomButton.TabIndex = 1;
            this.ID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ID.CustomButton.UseSelectable = true;
            this.ID.CustomButton.Visible = false;
            this.ID.Lines = new string[0];
            this.ID.Location = new System.Drawing.Point(173, 110);
            this.ID.MaxLength = 45;
            this.ID.Name = "ID";
            this.ID.PasswordChar = '\0';
            this.ID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ID.SelectedText = "";
            this.ID.SelectionLength = 0;
            this.ID.SelectionStart = 0;
            this.ID.ShortcutsEnabled = true;
            this.ID.Size = new System.Drawing.Size(121, 23);
            this.ID.TabIndex = 27;
            this.ID.UseSelectable = true;
            this.ID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // add_supplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 613);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.addSupplierBtn);
            this.Controls.Add(this.metroLabel8);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.districtList);
            this.Controls.Add(this.provinceList);
            this.Controls.Add(this.adress);
            this.Controls.Add(this.telephone);
            this.Controls.Add(this.name);
            this.Controls.Add(this.ID);
            this.Name = "add_supplier";
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Text = "add_supplier";
            this.Load += new System.EventHandler(this.add_supplier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton cancel;
        private MetroFramework.Controls.MetroButton addSupplierBtn;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox districtList;
        private MetroFramework.Controls.MetroComboBox provinceList;
        private MetroFramework.Controls.MetroTextBox adress;
        private MetroFramework.Controls.MetroTextBox telephone;
        private MetroFramework.Controls.MetroTextBox name;
        private MetroFramework.Controls.MetroTextBox ID;
    }
}