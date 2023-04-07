namespace DB_course.View
{
    partial class WarehouseAdminForm
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
            if(disposing && (components != null))
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.productsPage = new System.Windows.Forms.TabPage();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.addProductPage = new System.Windows.Forms.TabPage();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textPlaceId = new System.Windows.Forms.TextBox();
            this.textInventoryNumber = new System.Windows.Forms.TextBox();
            this.textDateProduction = new System.Windows.Forms.TextBox();
            this.textDateCome = new System.Windows.Forms.TextBox();
            this.textProductName = new System.Windows.Forms.TextBox();
            this.textProductId = new System.Windows.Forms.TextBox();
            this.PlacePage = new System.Windows.Forms.TabPage();
            this.deletePlaceBtn = new System.Windows.Forms.Button();
            this.updatePlaceBtn = new System.Windows.Forms.Button();
            this.addPlaceBtn = new System.Windows.Forms.Button();
            this.searchPlaceBtn = new System.Windows.Forms.Button();
            this.searchPlaceTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.PlaceComponent = new System.Windows.Forms.TabPage();
            this.cancelPlaceBtn = new System.Windows.Forms.Button();
            this.savePlaceBtn = new System.Windows.Forms.Button();
            this.StayPlaceText = new System.Windows.Forms.TextBox();
            this.sizePlaceText = new System.Windows.Forms.TextBox();
            this.laerPlaceText = new System.Windows.Forms.TextBox();
            this.placeIdText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Stay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.productsPage.SuspendLayout();
            this.addProductPage.SuspendLayout();
            this.PlacePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.PlaceComponent.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 53);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(811, 448);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(827, 55);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(107, 45);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.productsPage);
            this.tabControl1.Controls.Add(this.addProductPage);
            this.tabControl1.Controls.Add(this.PlacePage);
            this.tabControl1.Controls.Add(this.PlaceComponent);
            this.tabControl1.Location = new System.Drawing.Point(8, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(961, 608);
            this.tabControl1.TabIndex = 2;
            // 
            // productsPage
            // 
            this.productsPage.Controls.Add(this.buttonAdd);
            this.productsPage.Controls.Add(this.buttonSearch);
            this.productsPage.Controls.Add(this.textSearch);
            this.productsPage.Controls.Add(this.dataGridView1);
            this.productsPage.Controls.Add(this.buttonDelete);
            this.productsPage.Location = new System.Drawing.Point(4, 34);
            this.productsPage.Name = "productsPage";
            this.productsPage.Padding = new System.Windows.Forms.Padding(3);
            this.productsPage.Size = new System.Drawing.Size(953, 570);
            this.productsPage.TabIndex = 0;
            this.productsPage.Text = "productsPage";
            this.productsPage.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.Location = new System.Drawing.Point(827, 108);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(107, 38);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearch.Location = new System.Drawing.Point(827, 8);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(107, 38);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // textSearch
            // 
            this.textSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSearch.Location = new System.Drawing.Point(7, 7);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(809, 31);
            this.textSearch.TabIndex = 2;
            // 
            // addProductPage
            // 
            this.addProductPage.Controls.Add(this.buttonCancel);
            this.addProductPage.Controls.Add(this.buttonSave);
            this.addProductPage.Controls.Add(this.label6);
            this.addProductPage.Controls.Add(this.label5);
            this.addProductPage.Controls.Add(this.label4);
            this.addProductPage.Controls.Add(this.label3);
            this.addProductPage.Controls.Add(this.label2);
            this.addProductPage.Controls.Add(this.label1);
            this.addProductPage.Controls.Add(this.textPlaceId);
            this.addProductPage.Controls.Add(this.textInventoryNumber);
            this.addProductPage.Controls.Add(this.textDateProduction);
            this.addProductPage.Controls.Add(this.textDateCome);
            this.addProductPage.Controls.Add(this.textProductName);
            this.addProductPage.Controls.Add(this.textProductId);
            this.addProductPage.Location = new System.Drawing.Point(4, 34);
            this.addProductPage.Name = "addProductPage";
            this.addProductPage.Padding = new System.Windows.Forms.Padding(3);
            this.addProductPage.Size = new System.Drawing.Size(953, 570);
            this.addProductPage.TabIndex = 1;
            this.addProductPage.Text = "addProductPage";
            this.addProductPage.UseVisualStyleBackColor = true;
            this.addProductPage.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(449, 428);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(107, 38);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(260, 428);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(107, 38);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(280, 262);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "PlaceId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "InventoryNumber";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "DateCome";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "DateProduction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "ProductName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "ProductId";
            // 
            // textPlaceId
            // 
            this.textPlaceId.Location = new System.Drawing.Point(350, 248);
            this.textPlaceId.Name = "textPlaceId";
            this.textPlaceId.Size = new System.Drawing.Size(150, 31);
            this.textPlaceId.TabIndex = 5;
            // 
            // textInventoryNumber
            // 
            this.textInventoryNumber.Location = new System.Drawing.Point(350, 203);
            this.textInventoryNumber.Name = "textInventoryNumber";
            this.textInventoryNumber.Size = new System.Drawing.Size(150, 31);
            this.textInventoryNumber.TabIndex = 4;
            // 
            // textDateProduction
            // 
            this.textDateProduction.Location = new System.Drawing.Point(350, 158);
            this.textDateProduction.Name = "textDateProduction";
            this.textDateProduction.Size = new System.Drawing.Size(150, 31);
            this.textDateProduction.TabIndex = 3;
            // 
            // textDateCome
            // 
            this.textDateCome.Location = new System.Drawing.Point(350, 113);
            this.textDateCome.Name = "textDateCome";
            this.textDateCome.Size = new System.Drawing.Size(150, 31);
            this.textDateCome.TabIndex = 2;
            // 
            // textProductName
            // 
            this.textProductName.Location = new System.Drawing.Point(350, 68);
            this.textProductName.Name = "textProductName";
            this.textProductName.Size = new System.Drawing.Size(150, 31);
            this.textProductName.TabIndex = 1;
            // 
            // textProductId
            // 
            this.textProductId.Location = new System.Drawing.Point(350, 23);
            this.textProductId.Name = "textProductId";
            this.textProductId.Size = new System.Drawing.Size(150, 31);
            this.textProductId.TabIndex = 0;
            // 
            // PlacePage
            // 
            this.PlacePage.Controls.Add(this.deletePlaceBtn);
            this.PlacePage.Controls.Add(this.updatePlaceBtn);
            this.PlacePage.Controls.Add(this.addPlaceBtn);
            this.PlacePage.Controls.Add(this.searchPlaceBtn);
            this.PlacePage.Controls.Add(this.searchPlaceTextBox);
            this.PlacePage.Controls.Add(this.dataGridView2);
            this.PlacePage.Location = new System.Drawing.Point(4, 34);
            this.PlacePage.Name = "PlacePage";
            this.PlacePage.Size = new System.Drawing.Size(953, 570);
            this.PlacePage.TabIndex = 2;
            this.PlacePage.Text = "PlacePage";
            this.PlacePage.UseVisualStyleBackColor = true;
            // 
            // deletePlaceBtn
            // 
            this.deletePlaceBtn.Location = new System.Drawing.Point(736, 123);
            this.deletePlaceBtn.Name = "deletePlaceBtn";
            this.deletePlaceBtn.Size = new System.Drawing.Size(112, 34);
            this.deletePlaceBtn.TabIndex = 5;
            this.deletePlaceBtn.Text = "Delete";
            this.deletePlaceBtn.UseVisualStyleBackColor = true;
            // 
            // updatePlaceBtn
            // 
            this.updatePlaceBtn.Location = new System.Drawing.Point(736, 83);
            this.updatePlaceBtn.Name = "updatePlaceBtn";
            this.updatePlaceBtn.Size = new System.Drawing.Size(112, 34);
            this.updatePlaceBtn.TabIndex = 4;
            this.updatePlaceBtn.Text = "Update";
            this.updatePlaceBtn.UseVisualStyleBackColor = true;
            // 
            // addPlaceBtn
            // 
            this.addPlaceBtn.Location = new System.Drawing.Point(736, 43);
            this.addPlaceBtn.Name = "addPlaceBtn";
            this.addPlaceBtn.Size = new System.Drawing.Size(112, 34);
            this.addPlaceBtn.TabIndex = 3;
            this.addPlaceBtn.Text = "Add";
            this.addPlaceBtn.UseVisualStyleBackColor = true;
            // 
            // searchPlaceBtn
            // 
            this.searchPlaceBtn.Location = new System.Drawing.Point(736, 3);
            this.searchPlaceBtn.Name = "searchPlaceBtn";
            this.searchPlaceBtn.Size = new System.Drawing.Size(112, 34);
            this.searchPlaceBtn.TabIndex = 2;
            this.searchPlaceBtn.Text = "Search";
            this.searchPlaceBtn.UseVisualStyleBackColor = true;
            // 
            // searchPlaceTextBox
            // 
            this.searchPlaceTextBox.Location = new System.Drawing.Point(3, 3);
            this.searchPlaceTextBox.Name = "searchPlaceTextBox";
            this.searchPlaceTextBox.Size = new System.Drawing.Size(727, 31);
            this.searchPlaceTextBox.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 40);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            this.dataGridView2.RowTemplate.Height = 33;
            this.dataGridView2.Size = new System.Drawing.Size(727, 526);
            this.dataGridView2.TabIndex = 0;
            // 
            // PlaceComponent
            // 
            this.PlaceComponent.Controls.Add(this.Stay);
            this.PlaceComponent.Controls.Add(this.label9);
            this.PlaceComponent.Controls.Add(this.label8);
            this.PlaceComponent.Controls.Add(this.label7);
            this.PlaceComponent.Controls.Add(this.cancelPlaceBtn);
            this.PlaceComponent.Controls.Add(this.savePlaceBtn);
            this.PlaceComponent.Controls.Add(this.StayPlaceText);
            this.PlaceComponent.Controls.Add(this.sizePlaceText);
            this.PlaceComponent.Controls.Add(this.laerPlaceText);
            this.PlaceComponent.Controls.Add(this.placeIdText);
            this.PlaceComponent.Location = new System.Drawing.Point(4, 34);
            this.PlaceComponent.Name = "PlaceComponent";
            this.PlaceComponent.Size = new System.Drawing.Size(953, 570);
            this.PlaceComponent.TabIndex = 3;
            this.PlaceComponent.Text = "PlaceComponent";
            this.PlaceComponent.UseVisualStyleBackColor = true;
            // 
            // cancelPlaceBtn
            // 
            this.cancelPlaceBtn.Location = new System.Drawing.Point(463, 378);
            this.cancelPlaceBtn.Name = "cancelPlaceBtn";
            this.cancelPlaceBtn.Size = new System.Drawing.Size(112, 34);
            this.cancelPlaceBtn.TabIndex = 5;
            this.cancelPlaceBtn.Text = "Cancel";
            this.cancelPlaceBtn.UseVisualStyleBackColor = true;
            // 
            // savePlaceBtn
            // 
            this.savePlaceBtn.Location = new System.Drawing.Point(246, 378);
            this.savePlaceBtn.Name = "savePlaceBtn";
            this.savePlaceBtn.Size = new System.Drawing.Size(112, 34);
            this.savePlaceBtn.TabIndex = 4;
            this.savePlaceBtn.Text = "Save";
            this.savePlaceBtn.UseVisualStyleBackColor = true;
            // 
            // StayPlaceText
            // 
            this.StayPlaceText.Location = new System.Drawing.Point(517, 273);
            this.StayPlaceText.Name = "StayPlaceText";
            this.StayPlaceText.Size = new System.Drawing.Size(150, 31);
            this.StayPlaceText.TabIndex = 3;
            // 
            // sizePlaceText
            // 
            this.sizePlaceText.Location = new System.Drawing.Point(210, 259);
            this.sizePlaceText.Name = "sizePlaceText";
            this.sizePlaceText.Size = new System.Drawing.Size(150, 31);
            this.sizePlaceText.TabIndex = 2;
            // 
            // laerPlaceText
            // 
            this.laerPlaceText.Location = new System.Drawing.Point(517, 156);
            this.laerPlaceText.Name = "laerPlaceText";
            this.laerPlaceText.Size = new System.Drawing.Size(150, 31);
            this.laerPlaceText.TabIndex = 1;
            // 
            // placeIdText
            // 
            this.placeIdText.Location = new System.Drawing.Point(215, 149);
            this.placeIdText.Name = "placeIdText";
            this.placeIdText.Size = new System.Drawing.Size(150, 31);
            this.placeIdText.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Id";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(110, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 25);
            this.label8.TabIndex = 7;
            this.label8.Text = "Size";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(442, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 25);
            this.label9.TabIndex = 8;
            this.label9.Text = "Layer";
            // 
            // Stay
            // 
            this.Stay.AutoSize = true;
            this.Stay.Location = new System.Drawing.Point(442, 273);
            this.Stay.Name = "Stay";
            this.Stay.Size = new System.Drawing.Size(45, 25);
            this.Stay.TabIndex = 9;
            this.Stay.Text = "Stay";
            // 
            // WarehouseAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 637);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "WarehouseAdminForm";
            this.Text = "WarehouseAdminModel";
            this.Load += new System.EventHandler(this.WarehouseAdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.productsPage.ResumeLayout(false);
            this.productsPage.PerformLayout();
            this.addProductPage.ResumeLayout(false);
            this.addProductPage.PerformLayout();
            this.PlacePage.ResumeLayout(false);
            this.PlacePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.PlaceComponent.ResumeLayout(false);
            this.PlaceComponent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonDelete;
        private TabControl tabControl1;
        private TabPage productsPage;
        private TextBox textSearch;
        private TabPage addProductPage;
        private Label label1;
        private TextBox textPlaceId;
        private TextBox textInventoryNumber;
        private TextBox textDateProduction;
        private TextBox textDateCome;
        private TextBox textProductName;
        private TextBox textProductId;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button buttonCancel;
        private Button buttonSave;
        private Button buttonAdd;
        private Button buttonSearch;
        private TabPage PlacePage;
        private TabPage PlaceComponent;
        private Button searchPlaceBtn;
        private TextBox searchPlaceTextBox;
        private DataGridView dataGridView2;
        private Button deletePlaceBtn;
        private Button updatePlaceBtn;
        private Button addPlaceBtn;
        private TextBox StayPlaceText;
        private TextBox sizePlaceText;
        private TextBox laerPlaceText;
        private TextBox placeIdText;
        private Button cancelPlaceBtn;
        private Button savePlaceBtn;
        private Label Stay;
        private Label label9;
        private Label label8;
        private Label label7;
    }
}