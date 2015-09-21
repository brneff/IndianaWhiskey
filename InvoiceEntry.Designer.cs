namespace IndianaWhiskey
{
    partial class InvoiceEntry
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpItemsOnInvoice = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboUOM = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboMaterial = new System.Windows.Forms.ComboBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompanyAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dteInvoice = new System.Windows.Forms.DateTimePicker();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pageHeader1 = new IndianaWhiskey.PageHeader();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.txtInvoiceNumber = new System.Windows.Forms.TextBox();
            this.dgMaterials = new System.Windows.Forms.DataGridView();
            this.grpItemsOnInvoice.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMaterials)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(359, 476);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 38);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(545, 476);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 38);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // grpItemsOnInvoice
            // 
            this.grpItemsOnInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.grpItemsOnInvoice.Controls.Add(this.dgMaterials);
            this.grpItemsOnInvoice.Location = new System.Drawing.Point(12, 337);
            this.grpItemsOnInvoice.Name = "grpItemsOnInvoice";
            this.grpItemsOnInvoice.Size = new System.Drawing.Size(620, 132);
            this.grpItemsOnInvoice.TabIndex = 11;
            this.grpItemsOnInvoice.TabStop = false;
            this.grpItemsOnInvoice.Text = "Materials on this Invoice";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cboUOM);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboMaterial);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 110);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Material to Invoice";
            // 
            // cboUOM
            // 
            this.cboUOM.FormattingEnabled = true;
            this.cboUOM.Location = new System.Drawing.Point(288, 39);
            this.cboUOM.Name = "cboUOM";
            this.cboUOM.Size = new System.Drawing.Size(189, 25);
            this.cboUOM.TabIndex = 20;
            this.cboUOM.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboUOM_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(285, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Unit of Measure";
            // 
            // cboMaterial
            // 
            this.cboMaterial.FormattingEnabled = true;
            this.cboMaterial.Location = new System.Drawing.Point(9, 39);
            this.cboMaterial.Name = "cboMaterial";
            this.cboMaterial.Size = new System.Drawing.Size(270, 25);
            this.cboMaterial.TabIndex = 18;
            this.cboMaterial.SelectedIndexChanged += new System.EventHandler(this.cboMaterial_SelectedIndexChanged);
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(486, 39);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(58, 24);
            this.txtQty.TabIndex = 17;
            this.txtQty.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtQty_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(483, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Qty";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Material (type new or select existing)";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(486, 70);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 27);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtInvoiceNumber);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dteInvoice);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCompanyAddress);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboCompany);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(620, 120);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Invoice Information";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(222, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Company (type new or select existing)";
            // 
            // cboCompany
            // 
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(9, 40);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(270, 25);
            this.cboCompany.TabIndex = 19;
            this.cboCompany.SelectedIndexChanged += new System.EventHandler(this.cboCompany_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Address";
            // 
            // txtCompanyAddress
            // 
            this.txtCompanyAddress.Location = new System.Drawing.Point(288, 40);
            this.txtCompanyAddress.Multiline = true;
            this.txtCompanyAddress.Name = "txtCompanyAddress";
            this.txtCompanyAddress.Size = new System.Drawing.Size(189, 74);
            this.txtCompanyAddress.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(483, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Date";
            // 
            // dteInvoice
            // 
            this.dteInvoice.CustomFormat = "MM/dd/yyyy";
            this.dteInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dteInvoice.Location = new System.Drawing.Point(486, 40);
            this.dteInvoice.Name = "dteInvoice";
            this.dteInvoice.Size = new System.Drawing.Size(124, 24);
            this.dteInvoice.TabIndex = 23;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(552, 39);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(58, 24);
            this.txtCost.TabIndex = 22;
            this.txtCost.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCost_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(549, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Cost";
            // 
            // pageHeader1
            // 
            this.pageHeader1.BackColor = System.Drawing.Color.DimGray;
            this.pageHeader1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageHeader1.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageHeader1.Location = new System.Drawing.Point(0, 2);
            this.pageHeader1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pageHeader1.Name = "pageHeader1";
            this.pageHeader1.Size = new System.Drawing.Size(600, 86);
            this.pageHeader1.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(483, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 24;
            this.label8.Text = "Invoice #";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(452, 476);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(87, 38);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "&Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // txtInvoiceNumber
            // 
            this.txtInvoiceNumber.Location = new System.Drawing.Point(486, 87);
            this.txtInvoiceNumber.Name = "txtInvoiceNumber";
            this.txtInvoiceNumber.Size = new System.Drawing.Size(124, 24);
            this.txtInvoiceNumber.TabIndex = 23;
            // 
            // dgMaterials
            // 
            this.dgMaterials.AllowUserToAddRows = false;
            this.dgMaterials.AllowUserToOrderColumns = true;
            this.dgMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMaterials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgMaterials.Location = new System.Drawing.Point(3, 20);
            this.dgMaterials.Name = "dgMaterials";
            this.dgMaterials.ReadOnly = true;
            this.dgMaterials.Size = new System.Drawing.Size(614, 109);
            this.dgMaterials.TabIndex = 0;
            // 
            // InvoiceEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(663, 527);
            this.ControlBox = false;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpItemsOnInvoice);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pageHeader1);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "InvoiceEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grpItemsOnInvoice.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMaterials)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private PageHeader pageHeader1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpItemsOnInvoice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboUOM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMaterial;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dteInvoice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompanyAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox txtInvoiceNumber;
        private System.Windows.Forms.DataGridView dgMaterials;
    }
}