namespace VTYS_Mobilay_Magazasi
{
    partial class add_orders
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
            this.cusList = new MetroFramework.Controls.MetroComboBox();
            this.proList = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.ID = new MetroFramework.Controls.MetroTextBox();
            this.Price = new MetroFramework.Controls.MetroTextBox();
            this.Qty = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.cancel = new MetroFramework.Controls.MetroButton();
            this.addOrderBtn = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroDateTime1 = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // cusList
            // 
            this.cusList.FormattingEnabled = true;
            this.cusList.ItemHeight = 24;
            this.cusList.Location = new System.Drawing.Point(143, 91);
            this.cusList.Name = "cusList";
            this.cusList.Size = new System.Drawing.Size(202, 30);
            this.cusList.Style = MetroFramework.MetroColorStyle.Orange;
            this.cusList.TabIndex = 0;
            this.cusList.UseSelectable = true;
            this.cusList.SelectedIndexChanged += new System.EventHandler(this.cusList_SelectedIndexChanged);
            // 
            // proList
            // 
            this.proList.FormattingEnabled = true;
            this.proList.ItemHeight = 24;
            this.proList.Location = new System.Drawing.Point(143, 128);
            this.proList.Name = "proList";
            this.proList.Size = new System.Drawing.Size(202, 30);
            this.proList.Style = MetroFramework.MetroColorStyle.Orange;
            this.proList.TabIndex = 1;
            this.proList.UseSelectable = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(10, 138);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(117, 20);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "choose a product";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(10, 101);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(127, 20);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "choose a customer";
            // 
            // ID
            // 
            // 
            // 
            // 
            this.ID.CustomButton.Image = null;
            this.ID.CustomButton.Location = new System.Drawing.Point(97, 1);
            this.ID.CustomButton.Name = "";
            this.ID.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ID.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ID.CustomButton.TabIndex = 1;
            this.ID.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ID.CustomButton.UseSelectable = true;
            this.ID.CustomButton.Visible = false;
            this.ID.Enabled = false;
            this.ID.Lines = new string[0];
            this.ID.Location = new System.Drawing.Point(143, 259);
            this.ID.MaxLength = 32767;
            this.ID.Name = "ID";
            this.ID.PasswordChar = '\0';
            this.ID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ID.SelectedText = "";
            this.ID.SelectionLength = 0;
            this.ID.SelectionStart = 0;
            this.ID.ShortcutsEnabled = true;
            this.ID.Size = new System.Drawing.Size(119, 23);
            this.ID.TabIndex = 4;
            this.ID.UseSelectable = true;
            this.ID.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ID.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Price
            // 
            // 
            // 
            // 
            this.Price.CustomButton.Image = null;
            this.Price.CustomButton.Location = new System.Drawing.Point(97, 1);
            this.Price.CustomButton.Name = "";
            this.Price.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.Price.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Price.CustomButton.TabIndex = 1;
            this.Price.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Price.CustomButton.UseSelectable = true;
            this.Price.CustomButton.Visible = false;
            this.Price.Lines = new string[0];
            this.Price.Location = new System.Drawing.Point(143, 304);
            this.Price.MaxLength = 32767;
            this.Price.Name = "Price";
            this.Price.PasswordChar = '\0';
            this.Price.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Price.SelectedText = "";
            this.Price.SelectionLength = 0;
            this.Price.SelectionStart = 0;
            this.Price.ShortcutsEnabled = true;
            this.Price.Size = new System.Drawing.Size(119, 23);
            this.Price.TabIndex = 5;
            this.Price.UseSelectable = true;
            this.Price.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Price.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Price_KeyPress);
            // 
            // Qty
            // 
            // 
            // 
            // 
            this.Qty.CustomButton.Image = null;
            this.Qty.CustomButton.Location = new System.Drawing.Point(97, 1);
            this.Qty.CustomButton.Name = "";
            this.Qty.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.Qty.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Qty.CustomButton.TabIndex = 1;
            this.Qty.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Qty.CustomButton.UseSelectable = true;
            this.Qty.CustomButton.Visible = false;
            this.Qty.Lines = new string[0];
            this.Qty.Location = new System.Drawing.Point(143, 345);
            this.Qty.MaxLength = 32767;
            this.Qty.Name = "Qty";
            this.Qty.PasswordChar = '\0';
            this.Qty.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Qty.SelectedText = "";
            this.Qty.SelectionLength = 0;
            this.Qty.SelectionStart = 0;
            this.Qty.ShortcutsEnabled = true;
            this.Qty.Size = new System.Drawing.Size(119, 23);
            this.Qty.TabIndex = 6;
            this.Qty.UseSelectable = true;
            this.Qty.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Qty.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.Qty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Qty_KeyPress);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(10, 262);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(63, 20);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Order ID";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(10, 307);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(40, 20);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Price";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(10, 348);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(31, 20);
            this.metroLabel5.TabIndex = 9;
            this.metroLabel5.Text = "Qty";
            // 
            // cancel
            // 
            this.cancel.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.cancel.Location = new System.Drawing.Point(669, 388);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(96, 39);
            this.cancel.Style = MetroFramework.MetroColorStyle.Green;
            this.cancel.TabIndex = 24;
            this.cancel.Text = "Cancel";
            this.cancel.UseSelectable = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // addOrderBtn
            // 
            this.addOrderBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.addOrderBtn.Location = new System.Drawing.Point(567, 388);
            this.addOrderBtn.Name = "addOrderBtn";
            this.addOrderBtn.Size = new System.Drawing.Size(96, 39);
            this.addOrderBtn.Style = MetroFramework.MetroColorStyle.Green;
            this.addOrderBtn.TabIndex = 23;
            this.addOrderBtn.Text = "Add";
            this.addOrderBtn.UseSelectable = true;
            this.addOrderBtn.Click += new System.EventHandler(this.addOrderBtn_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton1.Location = new System.Drawing.Point(448, 91);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(123, 30);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroButton1.TabIndex = 25;
            this.metroButton1.Text = "Add a customer";
            this.metroButton1.UseSelectable = true;
            // 
            // metroDateTime1
            // 
            this.metroDateTime1.Location = new System.Drawing.Point(143, 397);
            this.metroDateTime1.MinimumSize = new System.Drawing.Size(0, 30);
            this.metroDateTime1.Name = "metroDateTime1";
            this.metroDateTime1.Size = new System.Drawing.Size(271, 30);
            this.metroDateTime1.TabIndex = 27;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(10, 410);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(36, 20);
            this.metroLabel6.TabIndex = 28;
            this.metroLabel6.Text = "date";
            // 
            // add_orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.metroDateTime1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.addOrderBtn);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.Qty);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.proList);
            this.Controls.Add(this.cusList);
            this.Name = "add_orders";
            this.Style = MetroFramework.MetroColorStyle.Orange;
            this.Text = "add_orders";
            this.Load += new System.EventHandler(this.add_orders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox cusList;
        private MetroFramework.Controls.MetroComboBox proList;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox ID;
        private MetroFramework.Controls.MetroTextBox Price;
        private MetroFramework.Controls.MetroTextBox Qty;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton cancel;
        private MetroFramework.Controls.MetroButton addOrderBtn;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroDateTime metroDateTime1;
        private MetroFramework.Controls.MetroLabel metroLabel6;
    }
}