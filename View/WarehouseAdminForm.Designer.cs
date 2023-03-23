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
            this.textSearch = new System.Windows.Forms.TextBox();
            this.addProductPage = new System.Windows.Forms.TabPage();
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.productsPage.SuspendLayout();
            this.addProductPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(5, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(541, 269);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(552, 33);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 27);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.productsPage);
            this.tabControl1.Controls.Add(this.addProductPage);
            this.tabControl1.Location = new System.Drawing.Point(32, 15);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(738, 365);
            this.tabControl1.TabIndex = 2;
            // 
            // productsPage
            // 
            this.productsPage.Controls.Add(this.buttonAdd);
            this.productsPage.Controls.Add(this.buttonSearch);
            this.productsPage.Controls.Add(this.textSearch);
            this.productsPage.Controls.Add(this.dataGridView1);
            this.productsPage.Controls.Add(this.buttonDelete);
            this.productsPage.Location = new System.Drawing.Point(4, 24);
            this.productsPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productsPage.Name = "productsPage";
            this.productsPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.productsPage.Size = new System.Drawing.Size(730, 337);
            this.productsPage.TabIndex = 0;
            this.productsPage.Text = "productsPage";
            this.productsPage.UseVisualStyleBackColor = true;
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(5, 4);
            this.textSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(541, 23);
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
            this.addProductPage.Location = new System.Drawing.Point(4, 24);
            this.addProductPage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addProductPage.Name = "addProductPage";
            this.addProductPage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addProductPage.Size = new System.Drawing.Size(730, 337);
            this.addProductPage.TabIndex = 1;
            this.addProductPage.Text = "addProductPage";
            this.addProductPage.UseVisualStyleBackColor = true;
            this.addProductPage.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 157);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "PlaceId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(140, 130);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "InventoryNumber";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "DateCome";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "DateProduction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "ProductName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "ProductId";
            // 
            // textPlaceId
            // 
            this.textPlaceId.Location = new System.Drawing.Point(245, 149);
            this.textPlaceId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textPlaceId.Name = "textPlaceId";
            this.textPlaceId.Size = new System.Drawing.Size(106, 23);
            this.textPlaceId.TabIndex = 5;
            // 
            // textInventoryNumber
            // 
            this.textInventoryNumber.Location = new System.Drawing.Point(245, 122);
            this.textInventoryNumber.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textInventoryNumber.Name = "textInventoryNumber";
            this.textInventoryNumber.Size = new System.Drawing.Size(106, 23);
            this.textInventoryNumber.TabIndex = 4;
            // 
            // textDateProduction
            // 
            this.textDateProduction.Location = new System.Drawing.Point(245, 95);
            this.textDateProduction.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textDateProduction.Name = "textDateProduction";
            this.textDateProduction.Size = new System.Drawing.Size(106, 23);
            this.textDateProduction.TabIndex = 3;
            // 
            // textDateCome
            // 
            this.textDateCome.Location = new System.Drawing.Point(245, 68);
            this.textDateCome.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textDateCome.Name = "textDateCome";
            this.textDateCome.Size = new System.Drawing.Size(106, 23);
            this.textDateCome.TabIndex = 2;
            // 
            // textProductName
            // 
            this.textProductName.Location = new System.Drawing.Point(245, 41);
            this.textProductName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textProductName.Name = "textProductName";
            this.textProductName.Size = new System.Drawing.Size(106, 23);
            this.textProductName.TabIndex = 1;
            // 
            // textProductId
            // 
            this.textProductId.Location = new System.Drawing.Point(245, 14);
            this.textProductId.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textProductId.Name = "textProductId";
            this.textProductId.Size = new System.Drawing.Size(106, 23);
            this.textProductId.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(182, 257);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(314, 257);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(552, 5);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(552, 65);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // WarehouseAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "WarehouseAdminForm";
            this.Text = "WarehouseAdminModel";
            this.Load += new System.EventHandler(this.WarehouseAdminForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.productsPage.ResumeLayout(false);
            this.productsPage.PerformLayout();
            this.addProductPage.ResumeLayout(false);
            this.addProductPage.PerformLayout();
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
    }
}