namespace GoldenCoinChallan
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageNewChallan = new System.Windows.Forms.TabPage();
            this.textBoxPackingSlip = new System.Windows.Forms.TextBox();
            this.labelPackingSlip = new System.Windows.Forms.Label();
            this.groupBoxChallanPackingSlip = new System.Windows.Forms.GroupBox();
            this.radioButtonPackingSlipTransfer = new System.Windows.Forms.RadioButton();
            this.radioButtonNewChallan = new System.Windows.Forms.RadioButton();
            this.buttonResetChallan = new System.Windows.Forms.Button();
            this.labelDealerDetails = new System.Windows.Forms.Label();
            this.dateNewChallan = new System.Windows.Forms.DateTimePicker();
            this.labelNewChallanNumber = new System.Windows.Forms.Label();
            this.labelNewChallanRemark = new System.Windows.Forms.Label();
            this.textBoxNewChallanRemark = new System.Windows.Forms.TextBox();
            this.buttonNewChallanInsert = new System.Windows.Forms.Button();
            this.labelDealerName = new System.Windows.Forms.Label();
            this.comboBoxDealerName = new System.Windows.Forms.ComboBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.dgvNewChallan = new System.Windows.Forms.DataGridView();
            this.ItemNameFilter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Size_35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_65 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_75_XS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_78 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_80_S = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_85_M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_90_L = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_95_XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_100_2XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_105_3XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_110_4XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_120_6XL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Size_Misc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageChallanPrint = new System.Windows.Forms.TabPage();
            this.btnGenChallan = new System.Windows.Forms.Button();
            this.btnTallyExport = new System.Windows.Forms.Button();
            this.buttonChallanPrintRefresh = new System.Windows.Forms.Button();
            this.dgvChallanList = new System.Windows.Forms.DataGridView();
            this.dgvTextBoxDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTextBoxBillNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTextBoxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTextBoxQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewChallanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aA_2023_2024DataSet = new GoldenCoinChallan.AA_2023_2024DataSet();
            this.textBoxChallan = new System.Windows.Forms.TextBox();
            this.reportViewerChallanPrint = new Microsoft.Reporting.WinForms.ReportViewer();
            this.labelStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblChallanProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabPageGodownTransfer = new System.Windows.Forms.TabPage();
            this.dgvGodownTrfPSlips = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vwGodownTrfSlipsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnGetGodownTrfSlips = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dgvGodownTrfDetail = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarkDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viewChallanPrintBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewChallanPrintTableAdapter = new GoldenCoinChallan.AA_2023_2024DataSetTableAdapters.ViewChallanPrintTableAdapter();
            this.tableAdapterManager = new GoldenCoinChallan.AA_2023_2024DataSetTableAdapters.TableAdapterManager();
            this.aA_2023_2024DataSet1 = new GoldenCoinChallan.AA_2023_2024DataSet();
            this.vwGodownTrfSlipsTableAdapter = new GoldenCoinChallan.AA_2023_2024DataSetTableAdapters.vwGodownTrfSlipsTableAdapter();
            this.viewChallanListTableAdapter1 = new GoldenCoinChallan.AA_2023_2024DataSetTableAdapters.ViewChallanListTableAdapter();
            this.newChallanItemTableAdapter1 = new GoldenCoinChallan.AA_2023_2024DataSetTableAdapters.NewChallanItemTableAdapter();
            this.newChallanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageNewChallan.SuspendLayout();
            this.groupBoxChallanPackingSlip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewChallan)).BeginInit();
            this.tabPageChallanPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallanList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChallanListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aA_2023_2024DataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabPageGodownTransfer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGodownTrfPSlips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwGodownTrfSlipsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGodownTrfDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChallanPrintBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aA_2023_2024DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newChallanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Challan No.";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageNewChallan);
            this.tabControl1.Controls.Add(this.tabPageChallanPrint);
            this.tabControl1.Controls.Add(this.tabPageGodownTransfer);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1264, 681);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageNewChallan
            // 
            this.tabPageNewChallan.Controls.Add(this.textBoxPackingSlip);
            this.tabPageNewChallan.Controls.Add(this.labelPackingSlip);
            this.tabPageNewChallan.Controls.Add(this.groupBoxChallanPackingSlip);
            this.tabPageNewChallan.Controls.Add(this.buttonResetChallan);
            this.tabPageNewChallan.Controls.Add(this.labelDealerDetails);
            this.tabPageNewChallan.Controls.Add(this.dateNewChallan);
            this.tabPageNewChallan.Controls.Add(this.labelNewChallanNumber);
            this.tabPageNewChallan.Controls.Add(this.labelNewChallanRemark);
            this.tabPageNewChallan.Controls.Add(this.textBoxNewChallanRemark);
            this.tabPageNewChallan.Controls.Add(this.buttonNewChallanInsert);
            this.tabPageNewChallan.Controls.Add(this.labelDealerName);
            this.tabPageNewChallan.Controls.Add(this.comboBoxDealerName);
            this.tabPageNewChallan.Controls.Add(this.labelTotal);
            this.tabPageNewChallan.Controls.Add(this.dgvNewChallan);
            this.tabPageNewChallan.Location = new System.Drawing.Point(4, 22);
            this.tabPageNewChallan.Name = "tabPageNewChallan";
            this.tabPageNewChallan.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNewChallan.Size = new System.Drawing.Size(1256, 655);
            this.tabPageNewChallan.TabIndex = 2;
            this.tabPageNewChallan.Text = "New Challan";
            this.tabPageNewChallan.UseVisualStyleBackColor = true;
            this.tabPageNewChallan.Enter += new System.EventHandler(this.tabPageNewChallan_Enter);
            // 
            // textBoxPackingSlip
            // 
            this.textBoxPackingSlip.Location = new System.Drawing.Point(446, 7);
            this.textBoxPackingSlip.Name = "textBoxPackingSlip";
            this.textBoxPackingSlip.Size = new System.Drawing.Size(184, 20);
            this.textBoxPackingSlip.TabIndex = 19;
            this.textBoxPackingSlip.Visible = false;
            // 
            // labelPackingSlip
            // 
            this.labelPackingSlip.AutoSize = true;
            this.labelPackingSlip.Location = new System.Drawing.Point(375, 9);
            this.labelPackingSlip.Name = "labelPackingSlip";
            this.labelPackingSlip.Size = new System.Drawing.Size(66, 13);
            this.labelPackingSlip.TabIndex = 18;
            this.labelPackingSlip.Text = "Packing Slip";
            this.labelPackingSlip.Visible = false;
            // 
            // groupBoxChallanPackingSlip
            // 
            this.groupBoxChallanPackingSlip.Controls.Add(this.radioButtonPackingSlipTransfer);
            this.groupBoxChallanPackingSlip.Controls.Add(this.radioButtonNewChallan);
            this.groupBoxChallanPackingSlip.Location = new System.Drawing.Point(5, 1);
            this.groupBoxChallanPackingSlip.Name = "groupBoxChallanPackingSlip";
            this.groupBoxChallanPackingSlip.Size = new System.Drawing.Size(354, 30);
            this.groupBoxChallanPackingSlip.TabIndex = 17;
            this.groupBoxChallanPackingSlip.TabStop = false;
            // 
            // radioButtonPackingSlipTransfer
            // 
            this.radioButtonPackingSlipTransfer.AutoSize = true;
            this.radioButtonPackingSlipTransfer.Location = new System.Drawing.Point(121, 6);
            this.radioButtonPackingSlipTransfer.Name = "radioButtonPackingSlipTransfer";
            this.radioButtonPackingSlipTransfer.Size = new System.Drawing.Size(126, 17);
            this.radioButtonPackingSlipTransfer.TabIndex = 1;
            this.radioButtonPackingSlipTransfer.Text = "Packing Slip Transfer";
            this.radioButtonPackingSlipTransfer.UseVisualStyleBackColor = true;
            this.radioButtonPackingSlipTransfer.CheckedChanged += new System.EventHandler(this.radioButtonPackingSlipTransfer_CheckedChanged);
            // 
            // radioButtonNewChallan
            // 
            this.radioButtonNewChallan.AutoSize = true;
            this.radioButtonNewChallan.Checked = true;
            this.radioButtonNewChallan.Location = new System.Drawing.Point(7, 8);
            this.radioButtonNewChallan.Name = "radioButtonNewChallan";
            this.radioButtonNewChallan.Size = new System.Drawing.Size(85, 17);
            this.radioButtonNewChallan.TabIndex = 0;
            this.radioButtonNewChallan.TabStop = true;
            this.radioButtonNewChallan.Text = "New Challan";
            this.radioButtonNewChallan.UseVisualStyleBackColor = true;
            this.radioButtonNewChallan.CheckedChanged += new System.EventHandler(this.radioButtonNewChallan_CheckedChanged);
            // 
            // buttonResetChallan
            // 
            this.buttonResetChallan.Location = new System.Drawing.Point(1109, 451);
            this.buttonResetChallan.Name = "buttonResetChallan";
            this.buttonResetChallan.Size = new System.Drawing.Size(139, 35);
            this.buttonResetChallan.TabIndex = 16;
            this.buttonResetChallan.Text = "&Reset Challan";
            this.buttonResetChallan.UseVisualStyleBackColor = true;
            this.buttonResetChallan.Click += new System.EventHandler(this.buttonResetChallan_Click);
            // 
            // labelDealerDetails
            // 
            this.labelDealerDetails.AutoEllipsis = true;
            this.labelDealerDetails.AutoSize = true;
            this.labelDealerDetails.BackColor = System.Drawing.Color.LightCyan;
            this.labelDealerDetails.Font = new System.Drawing.Font("Calibri", 12F);
            this.labelDealerDetails.Location = new System.Drawing.Point(5, 34);
            this.labelDealerDetails.MaximumSize = new System.Drawing.Size(750, 0);
            this.labelDealerDetails.Name = "labelDealerDetails";
            this.labelDealerDetails.Size = new System.Drawing.Size(0, 19);
            this.labelDealerDetails.TabIndex = 15;
            // 
            // dateNewChallan
            // 
            this.dateNewChallan.CustomFormat = "dd-mm-yyyy";
            this.dateNewChallan.Enabled = false;
            this.dateNewChallan.Location = new System.Drawing.Point(1109, 244);
            this.dateNewChallan.Name = "dateNewChallan";
            this.dateNewChallan.Size = new System.Drawing.Size(139, 20);
            this.dateNewChallan.TabIndex = 14;
            // 
            // labelNewChallanNumber
            // 
            this.labelNewChallanNumber.AutoSize = true;
            this.labelNewChallanNumber.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelNewChallanNumber.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.labelNewChallanNumber.Location = new System.Drawing.Point(1109, 217);
            this.labelNewChallanNumber.Name = "labelNewChallanNumber";
            this.labelNewChallanNumber.Size = new System.Drawing.Size(87, 19);
            this.labelNewChallanNumber.TabIndex = 13;
            this.labelNewChallanNumber.Text = "Challan No.";
            // 
            // labelNewChallanRemark
            // 
            this.labelNewChallanRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelNewChallanRemark.Location = new System.Drawing.Point(754, 4);
            this.labelNewChallanRemark.Name = "labelNewChallanRemark";
            this.labelNewChallanRemark.Size = new System.Drawing.Size(73, 22);
            this.labelNewChallanRemark.TabIndex = 12;
            this.labelNewChallanRemark.Text = "Remarks";
            // 
            // textBoxNewChallanRemark
            // 
            this.textBoxNewChallanRemark.Location = new System.Drawing.Point(759, 29);
            this.textBoxNewChallanRemark.Multiline = true;
            this.textBoxNewChallanRemark.Name = "textBoxNewChallanRemark";
            this.textBoxNewChallanRemark.Size = new System.Drawing.Size(489, 108);
            this.textBoxNewChallanRemark.TabIndex = 3;
            // 
            // buttonNewChallanInsert
            // 
            this.buttonNewChallanInsert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonNewChallanInsert.Location = new System.Drawing.Point(1109, 147);
            this.buttonNewChallanInsert.Name = "buttonNewChallanInsert";
            this.buttonNewChallanInsert.Size = new System.Drawing.Size(139, 58);
            this.buttonNewChallanInsert.TabIndex = 4;
            this.buttonNewChallanInsert.Text = "&Insert Challan";
            this.buttonNewChallanInsert.UseVisualStyleBackColor = true;
            this.buttonNewChallanInsert.Click += new System.EventHandler(this.buttonNewChallanInsert_Click);
            // 
            // labelDealerName
            // 
            this.labelDealerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerName.Location = new System.Drawing.Point(5, 101);
            this.labelDealerName.Name = "labelDealerName";
            this.labelDealerName.Size = new System.Drawing.Size(60, 45);
            this.labelDealerName.TabIndex = 9;
            this.labelDealerName.Text = "Dealer Name";
            // 
            // comboBoxDealerName
            // 
            this.comboBoxDealerName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBoxDealerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxDealerName.FormattingEnabled = true;
            this.comboBoxDealerName.IntegralHeight = false;
            this.comboBoxDealerName.ItemHeight = 16;
            this.comboBoxDealerName.Location = new System.Drawing.Point(68, 113);
            this.comboBoxDealerName.Name = "comboBoxDealerName";
            this.comboBoxDealerName.Size = new System.Drawing.Size(685, 24);
            this.comboBoxDealerName.TabIndex = 1;
            this.comboBoxDealerName.DropDown += new System.EventHandler(this.comboBoxDealerName_DropDown);
            this.comboBoxDealerName.SelectedIndexChanged += new System.EventHandler(this.comboBoxDealerName_SelectedIndexChanged);
            this.comboBoxDealerName.TextUpdate += new System.EventHandler(this.comboBoxDealerName_TextUpdated);
            this.comboBoxDealerName.Enter += new System.EventHandler(this.comboBoxDealerName_Enter);
            this.comboBoxDealerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxDealerName_KeyPress);
            this.comboBoxDealerName.Leave += new System.EventHandler(this.comboBoxDealerName_Leave);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelTotal.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.labelTotal.Location = new System.Drawing.Point(1109, 283);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(37, 17);
            this.labelTotal.TabIndex = 7;
            this.labelTotal.Text = "Total";
            // 
            // dgvNewChallan
            // 
            this.dgvNewChallan.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dgvNewChallan.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNewChallan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvNewChallan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewChallan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemNameFilter,
            this.ItemName,
            this.Size_35,
            this.Size_40,
            this.Size_45,
            this.Size_50,
            this.Size_55,
            this.Size_60,
            this.Size_65,
            this.Size_70,
            this.Size_75_XS,
            this.Size_78,
            this.Size_80_S,
            this.Size_85_M,
            this.Size_90_L,
            this.Size_95_XL,
            this.Size_100_2XL,
            this.Size_105_3XL,
            this.Size_110_4XL,
            this.Size_120_6XL,
            this.Size_Misc,
            this.UnitName,
            this.rowTotal});
            this.dgvNewChallan.Location = new System.Drawing.Point(3, 147);
            this.dgvNewChallan.MultiSelect = false;
            this.dgvNewChallan.Name = "dgvNewChallan";
            this.dgvNewChallan.RowHeadersWidth = 24;
            this.dgvNewChallan.Size = new System.Drawing.Size(1100, 339);
            this.dgvNewChallan.TabIndex = 2;
            this.dgvNewChallan.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNewChallan_CellEnter);
            this.dgvNewChallan.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvNewChallan_EditingControlShowing);
            this.dgvNewChallan.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvNewChallan_RowsRemoved);
            this.dgvNewChallan.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvNewChallan_UserDeletingRow);
            this.dgvNewChallan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvNewChallan_KeyDown);
            // 
            // ItemNameFilter
            // 
            this.ItemNameFilter.Frozen = true;
            this.ItemNameFilter.HeaderText = "Item Name Filter";
            this.ItemNameFilter.Name = "ItemNameFilter";
            // 
            // ItemName
            // 
            this.ItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ItemName.Frozen = true;
            this.ItemName.HeaderText = "Item Name";
            this.ItemName.MinimumWidth = 300;
            this.ItemName.Name = "ItemName";
            this.ItemName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ItemName.Width = 300;
            // 
            // Size_35
            // 
            this.Size_35.Frozen = true;
            this.Size_35.HeaderText = "35";
            this.Size_35.MaxInputLength = 3;
            this.Size_35.Name = "Size_35";
            this.Size_35.ReadOnly = true;
            this.Size_35.Width = 30;
            // 
            // Size_40
            // 
            this.Size_40.Frozen = true;
            this.Size_40.HeaderText = "40";
            this.Size_40.MaxInputLength = 3;
            this.Size_40.Name = "Size_40";
            this.Size_40.ReadOnly = true;
            this.Size_40.Width = 30;
            // 
            // Size_45
            // 
            this.Size_45.Frozen = true;
            this.Size_45.HeaderText = "45";
            this.Size_45.MaxInputLength = 3;
            this.Size_45.Name = "Size_45";
            this.Size_45.ReadOnly = true;
            this.Size_45.Width = 30;
            // 
            // Size_50
            // 
            this.Size_50.Frozen = true;
            this.Size_50.HeaderText = "50";
            this.Size_50.MaxInputLength = 3;
            this.Size_50.Name = "Size_50";
            this.Size_50.ReadOnly = true;
            this.Size_50.Width = 30;
            // 
            // Size_55
            // 
            this.Size_55.Frozen = true;
            this.Size_55.HeaderText = "55";
            this.Size_55.MaxInputLength = 3;
            this.Size_55.Name = "Size_55";
            this.Size_55.ReadOnly = true;
            this.Size_55.Width = 30;
            // 
            // Size_60
            // 
            this.Size_60.Frozen = true;
            this.Size_60.HeaderText = "60";
            this.Size_60.MaxInputLength = 3;
            this.Size_60.Name = "Size_60";
            this.Size_60.ReadOnly = true;
            this.Size_60.Width = 30;
            // 
            // Size_65
            // 
            this.Size_65.Frozen = true;
            this.Size_65.HeaderText = "65";
            this.Size_65.MaxInputLength = 3;
            this.Size_65.Name = "Size_65";
            this.Size_65.ReadOnly = true;
            this.Size_65.Width = 30;
            // 
            // Size_70
            // 
            this.Size_70.Frozen = true;
            this.Size_70.HeaderText = "70";
            this.Size_70.MaxInputLength = 3;
            this.Size_70.Name = "Size_70";
            this.Size_70.ReadOnly = true;
            this.Size_70.Width = 30;
            // 
            // Size_75_XS
            // 
            this.Size_75_XS.Frozen = true;
            this.Size_75_XS.HeaderText = "75";
            this.Size_75_XS.MaxInputLength = 3;
            this.Size_75_XS.Name = "Size_75_XS";
            this.Size_75_XS.ReadOnly = true;
            this.Size_75_XS.Width = 30;
            // 
            // Size_78
            // 
            this.Size_78.Frozen = true;
            this.Size_78.HeaderText = "78";
            this.Size_78.MaxInputLength = 3;
            this.Size_78.Name = "Size_78";
            this.Size_78.ReadOnly = true;
            this.Size_78.Width = 30;
            // 
            // Size_80_S
            // 
            this.Size_80_S.Frozen = true;
            this.Size_80_S.HeaderText = "80";
            this.Size_80_S.MaxInputLength = 3;
            this.Size_80_S.Name = "Size_80_S";
            this.Size_80_S.ReadOnly = true;
            this.Size_80_S.Width = 30;
            // 
            // Size_85_M
            // 
            this.Size_85_M.Frozen = true;
            this.Size_85_M.HeaderText = "85";
            this.Size_85_M.MaxInputLength = 3;
            this.Size_85_M.Name = "Size_85_M";
            this.Size_85_M.ReadOnly = true;
            this.Size_85_M.Width = 30;
            // 
            // Size_90_L
            // 
            this.Size_90_L.Frozen = true;
            this.Size_90_L.HeaderText = "90";
            this.Size_90_L.MaxInputLength = 3;
            this.Size_90_L.Name = "Size_90_L";
            this.Size_90_L.ReadOnly = true;
            this.Size_90_L.Width = 30;
            // 
            // Size_95_XL
            // 
            this.Size_95_XL.Frozen = true;
            this.Size_95_XL.HeaderText = "95";
            this.Size_95_XL.MaxInputLength = 3;
            this.Size_95_XL.Name = "Size_95_XL";
            this.Size_95_XL.ReadOnly = true;
            this.Size_95_XL.Width = 30;
            // 
            // Size_100_2XL
            // 
            this.Size_100_2XL.Frozen = true;
            this.Size_100_2XL.HeaderText = "100";
            this.Size_100_2XL.MaxInputLength = 3;
            this.Size_100_2XL.Name = "Size_100_2XL";
            this.Size_100_2XL.ReadOnly = true;
            this.Size_100_2XL.Width = 30;
            // 
            // Size_105_3XL
            // 
            this.Size_105_3XL.Frozen = true;
            this.Size_105_3XL.HeaderText = "105";
            this.Size_105_3XL.MaxInputLength = 3;
            this.Size_105_3XL.Name = "Size_105_3XL";
            this.Size_105_3XL.ReadOnly = true;
            this.Size_105_3XL.Width = 30;
            // 
            // Size_110_4XL
            // 
            this.Size_110_4XL.Frozen = true;
            this.Size_110_4XL.HeaderText = "110";
            this.Size_110_4XL.MaxInputLength = 3;
            this.Size_110_4XL.Name = "Size_110_4XL";
            this.Size_110_4XL.ReadOnly = true;
            this.Size_110_4XL.Width = 30;
            // 
            // Size_120_6XL
            // 
            this.Size_120_6XL.Frozen = true;
            this.Size_120_6XL.HeaderText = "120";
            this.Size_120_6XL.MaxInputLength = 3;
            this.Size_120_6XL.Name = "Size_120_6XL";
            this.Size_120_6XL.ReadOnly = true;
            this.Size_120_6XL.Width = 30;
            // 
            // Size_Misc
            // 
            this.Size_Misc.HeaderText = "Misc";
            this.Size_Misc.MaxInputLength = 3;
            this.Size_Misc.Name = "Size_Misc";
            this.Size_Misc.ReadOnly = true;
            this.Size_Misc.Width = 30;
            // 
            // UnitName
            // 
            this.UnitName.HeaderText = "UNIT";
            this.UnitName.Name = "UnitName";
            this.UnitName.ReadOnly = true;
            this.UnitName.Width = 48;
            // 
            // rowTotal
            // 
            this.rowTotal.HeaderText = "Total";
            this.rowTotal.MaxInputLength = 3;
            this.rowTotal.Name = "rowTotal";
            this.rowTotal.ReadOnly = true;
            this.rowTotal.Width = 48;
            // 
            // tabPageChallanPrint
            // 
            this.tabPageChallanPrint.Controls.Add(this.btnGenChallan);
            this.tabPageChallanPrint.Controls.Add(this.btnTallyExport);
            this.tabPageChallanPrint.Controls.Add(this.buttonChallanPrintRefresh);
            this.tabPageChallanPrint.Controls.Add(this.dgvChallanList);
            this.tabPageChallanPrint.Controls.Add(this.textBoxChallan);
            this.tabPageChallanPrint.Controls.Add(this.reportViewerChallanPrint);
            this.tabPageChallanPrint.Controls.Add(this.labelStatus);
            this.tabPageChallanPrint.Controls.Add(this.panel1);
            this.tabPageChallanPrint.Location = new System.Drawing.Point(4, 22);
            this.tabPageChallanPrint.Name = "tabPageChallanPrint";
            this.tabPageChallanPrint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageChallanPrint.Size = new System.Drawing.Size(1256, 655);
            this.tabPageChallanPrint.TabIndex = 0;
            this.tabPageChallanPrint.Text = "Challan Print";
            this.tabPageChallanPrint.UseVisualStyleBackColor = true;
            // 
            // btnGenChallan
            // 
            this.btnGenChallan.BackColor = System.Drawing.Color.GreenYellow;
            this.btnGenChallan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnGenChallan.Location = new System.Drawing.Point(170, 6);
            this.btnGenChallan.Name = "btnGenChallan";
            this.btnGenChallan.Size = new System.Drawing.Size(145, 30);
            this.btnGenChallan.TabIndex = 6;
            this.btnGenChallan.Text = "&Generate Challan";
            this.btnGenChallan.UseVisualStyleBackColor = false;
            this.btnGenChallan.Click += new System.EventHandler(this.btnGenChallan_Click);
            // 
            // btnTallyExport
            // 
            this.btnTallyExport.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTallyExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.btnTallyExport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTallyExport.Location = new System.Drawing.Point(323, 6);
            this.btnTallyExport.Name = "btnTallyExport";
            this.btnTallyExport.Size = new System.Drawing.Size(145, 30);
            this.btnTallyExport.TabIndex = 2;
            this.btnTallyExport.Text = "Export Tally &XML";
            this.btnTallyExport.UseVisualStyleBackColor = false;
            this.btnTallyExport.Click += new System.EventHandler(this.btnTallyExport_Click);
            // 
            // buttonChallanPrintRefresh
            // 
            this.buttonChallanPrintRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.buttonChallanPrintRefresh.Location = new System.Drawing.Point(1026, 4);
            this.buttonChallanPrintRefresh.Name = "buttonChallanPrintRefresh";
            this.buttonChallanPrintRefresh.Size = new System.Drawing.Size(199, 30);
            this.buttonChallanPrintRefresh.TabIndex = 8;
            this.buttonChallanPrintRefresh.Text = "Refresh Challan List";
            this.buttonChallanPrintRefresh.UseVisualStyleBackColor = true;
            this.buttonChallanPrintRefresh.Click += new System.EventHandler(this.buttonChallanPrintRefresh_Click);
            // 
            // dgvChallanList
            // 
            this.dgvChallanList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvChallanList.AutoGenerateColumns = false;
            this.dgvChallanList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChallanList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTextBoxDate,
            this.dgvTextBoxBillNo,
            this.dgvTextBoxName,
            this.dgvTextBoxQty});
            this.dgvChallanList.DataSource = this.viewChallanListBindingSource;
            this.dgvChallanList.Location = new System.Drawing.Point(787, 38);
            this.dgvChallanList.Name = "dgvChallanList";
            this.dgvChallanList.Size = new System.Drawing.Size(466, 614);
            this.dgvChallanList.TabIndex = 7;
            this.dgvChallanList.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewChallanPrintDataGridView_RowEnter);
            // 
            // dgvTextBoxDate
            // 
            this.dgvTextBoxDate.DataPropertyName = "BillDate";
            this.dgvTextBoxDate.HeaderText = "Date";
            this.dgvTextBoxDate.Name = "dgvTextBoxDate";
            this.dgvTextBoxDate.ReadOnly = true;
            // 
            // dgvTextBoxBillNo
            // 
            this.dgvTextBoxBillNo.DataPropertyName = "BillNo";
            this.dgvTextBoxBillNo.HeaderText = "BillNo";
            this.dgvTextBoxBillNo.Name = "dgvTextBoxBillNo";
            // 
            // dgvTextBoxName
            // 
            this.dgvTextBoxName.DataPropertyName = "Name";
            this.dgvTextBoxName.HeaderText = "Name";
            this.dgvTextBoxName.Name = "dgvTextBoxName";
            // 
            // dgvTextBoxQty
            // 
            this.dgvTextBoxQty.DataPropertyName = "TotQty";
            this.dgvTextBoxQty.HeaderText = "TotQty";
            this.dgvTextBoxQty.Name = "dgvTextBoxQty";
            // 
            // viewChallanListBindingSource
            // 
            this.viewChallanListBindingSource.DataMember = "ViewChallanList";
            this.viewChallanListBindingSource.DataSource = this.aA_2023_2024DataSet;
            // 
            // aA_2023_2024DataSet
            // 
            this.aA_2023_2024DataSet.DataSetName = "AA_2023_2024DataSet";
            this.aA_2023_2024DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBoxChallan
            // 
            this.textBoxChallan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxChallan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxChallan.Location = new System.Drawing.Point(7, 8);
            this.textBoxChallan.MaxLength = 7;
            this.textBoxChallan.Name = "textBoxChallan";
            this.textBoxChallan.Size = new System.Drawing.Size(159, 26);
            this.textBoxChallan.TabIndex = 5;
            this.textBoxChallan.Text = "CH/0542";
            // 
            // reportViewerChallanPrint
            // 
            this.reportViewerChallanPrint.AutoSize = true;
            this.reportViewerChallanPrint.DocumentMapWidth = 1;
            this.reportViewerChallanPrint.LocalReport.ReportEmbeddedResource = "GoldenCoinChallan.Report_ChallanPrint.rdlc";
            this.reportViewerChallanPrint.Location = new System.Drawing.Point(4, 38);
            this.reportViewerChallanPrint.Name = "reportViewerChallanPrint";
            this.reportViewerChallanPrint.ServerReport.BearerToken = null;
            this.reportViewerChallanPrint.Size = new System.Drawing.Size(772, 614);
            this.reportViewerChallanPrint.TabIndex = 4;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelStatus.Location = new System.Drawing.Point(475, 11);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(0, 20);
            this.labelStatus.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.lblChallanProgress);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1250, 652);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // lblChallanProgress
            // 
            this.lblChallanProgress.AutoSize = true;
            this.lblChallanProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChallanProgress.Location = new System.Drawing.Point(364, 193);
            this.lblChallanProgress.Name = "lblChallanProgress";
            this.lblChallanProgress.Size = new System.Drawing.Size(528, 37);
            this.lblChallanProgress.TabIndex = 0;
            this.lblChallanProgress.Text = "Challan is being loaded…Kindly wait!";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(268, 269);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(721, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Value = 75;
            // 
            // tabPageGodownTransfer
            // 
            this.tabPageGodownTransfer.Controls.Add(this.dgvGodownTrfPSlips);
            this.tabPageGodownTransfer.Controls.Add(this.btnGetGodownTrfSlips);
            this.tabPageGodownTransfer.Controls.Add(this.dtpTo);
            this.tabPageGodownTransfer.Controls.Add(this.dtpFrom);
            this.tabPageGodownTransfer.Controls.Add(this.dgvGodownTrfDetail);
            this.tabPageGodownTransfer.Location = new System.Drawing.Point(4, 22);
            this.tabPageGodownTransfer.Name = "tabPageGodownTransfer";
            this.tabPageGodownTransfer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGodownTransfer.Size = new System.Drawing.Size(1256, 655);
            this.tabPageGodownTransfer.TabIndex = 1;
            this.tabPageGodownTransfer.Text = "Godown Transfer";
            this.tabPageGodownTransfer.UseVisualStyleBackColor = true;
            // 
            // dgvGodownTrfPSlips
            // 
            this.dgvGodownTrfPSlips.AllowUserToAddRows = false;
            this.dgvGodownTrfPSlips.AllowUserToDeleteRows = false;
            this.dgvGodownTrfPSlips.AutoGenerateColumns = false;
            this.dgvGodownTrfPSlips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGodownTrfPSlips.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn17});
            this.dgvGodownTrfPSlips.DataSource = this.vwGodownTrfSlipsBindingSource;
            this.dgvGodownTrfPSlips.Location = new System.Drawing.Point(882, 73);
            this.dgvGodownTrfPSlips.Name = "dgvGodownTrfPSlips";
            this.dgvGodownTrfPSlips.ReadOnly = true;
            this.dgvGodownTrfPSlips.RowHeadersVisible = false;
            this.dgvGodownTrfPSlips.ShowEditingIcon = false;
            this.dgvGodownTrfPSlips.Size = new System.Drawing.Size(227, 639);
            this.dgvGodownTrfPSlips.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "Remark";
            this.dataGridViewTextBoxColumn17.HeaderText = "Packing Slip No.";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 120;
            // 
            // vwGodownTrfSlipsBindingSource
            // 
            this.vwGodownTrfSlipsBindingSource.DataMember = "vwGodownTrfSlips";
            this.vwGodownTrfSlipsBindingSource.DataSource = this.aA_2023_2024DataSet;
            // 
            // btnGetGodownTrfSlips
            // 
            this.btnGetGodownTrfSlips.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGetGodownTrfSlips.Font = new System.Drawing.Font("Calibri Light", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetGodownTrfSlips.ForeColor = System.Drawing.Color.White;
            this.btnGetGodownTrfSlips.Location = new System.Drawing.Point(882, 11);
            this.btnGetGodownTrfSlips.Name = "btnGetGodownTrfSlips";
            this.btnGetGodownTrfSlips.Size = new System.Drawing.Size(221, 52);
            this.btnGetGodownTrfSlips.TabIndex = 3;
            this.btnGetGodownTrfSlips.Text = "Fetch Godown Transfer PSlip Data";
            this.btnGetGodownTrfSlips.UseVisualStyleBackColor = false;
            this.btnGetGodownTrfSlips.Click += new System.EventHandler(this.btnGetGodownTrfSlips_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(520, 34);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 2;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(171, 34);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // dgvGodownTrfDetail
            // 
            this.dgvGodownTrfDetail.AllowUserToAddRows = false;
            this.dgvGodownTrfDetail.AllowUserToDeleteRows = false;
            this.dgvGodownTrfDetail.AutoGenerateColumns = false;
            this.dgvGodownTrfDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGodownTrfDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn,
            this.billNoDataGridViewTextBoxColumn,
            this.remarkDataGridViewTextBoxColumn,
            this.totQtyDataGridViewTextBoxColumn,
            this.ItemDesc,
            this.qtyDataGridViewTextBoxColumn,
            this.Unit});
            this.dgvGodownTrfDetail.DataSource = this.vwGodownTrfSlipsBindingSource;
            this.dgvGodownTrfDetail.Location = new System.Drawing.Point(91, 69);
            this.dgvGodownTrfDetail.Name = "dgvGodownTrfDetail";
            this.dgvGodownTrfDetail.ReadOnly = true;
            this.dgvGodownTrfDetail.RowHeadersVisible = false;
            this.dgvGodownTrfDetail.Size = new System.Drawing.Size(704, 639);
            this.dgvGodownTrfDetail.TabIndex = 0;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // billNoDataGridViewTextBoxColumn
            // 
            this.billNoDataGridViewTextBoxColumn.DataPropertyName = "BillNo";
            this.billNoDataGridViewTextBoxColumn.HeaderText = "BillNo";
            this.billNoDataGridViewTextBoxColumn.Name = "billNoDataGridViewTextBoxColumn";
            this.billNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // remarkDataGridViewTextBoxColumn
            // 
            this.remarkDataGridViewTextBoxColumn.DataPropertyName = "Remark";
            this.remarkDataGridViewTextBoxColumn.HeaderText = "Remark";
            this.remarkDataGridViewTextBoxColumn.Name = "remarkDataGridViewTextBoxColumn";
            this.remarkDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totQtyDataGridViewTextBoxColumn
            // 
            this.totQtyDataGridViewTextBoxColumn.DataPropertyName = "TotQty";
            this.totQtyDataGridViewTextBoxColumn.HeaderText = "TotQty";
            this.totQtyDataGridViewTextBoxColumn.Name = "totQtyDataGridViewTextBoxColumn";
            this.totQtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ItemDesc
            // 
            this.ItemDesc.DataPropertyName = "ItemDesc";
            this.ItemDesc.HeaderText = "ItemDesc";
            this.ItemDesc.Name = "ItemDesc";
            this.ItemDesc.ReadOnly = true;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // viewChallanPrintBindingSource
            // 
            this.viewChallanPrintBindingSource.DataMember = "ViewChallanPrint";
            this.viewChallanPrintBindingSource.DataSource = this.aA_2023_2024DataSet;
            // 
            // viewChallanPrintTableAdapter
            // 
            this.viewChallanPrintTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = GoldenCoinChallan.AA_2023_2024DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // aA_2023_2024DataSet1
            // 
            this.aA_2023_2024DataSet1.DataSetName = "AA_2023_2024DataSet";
            this.aA_2023_2024DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vwGodownTrfSlipsTableAdapter
            // 
            this.vwGodownTrfSlipsTableAdapter.ClearBeforeFill = true;
            // 
            // viewChallanListTableAdapter1
            // 
            this.viewChallanListTableAdapter1.ClearBeforeFill = true;
            // 
            // newChallanItemTableAdapter1
            // 
            this.newChallanItemTableAdapter1.ClearBeforeFill = true;
            // 
            // newChallanBindingSource
            // 
            this.newChallanBindingSource.DataMember = "ViewNewChallan";
            this.newChallanBindingSource.DataSource = this.aA_2023_2024DataSet;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Santani Godown Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.tabControl1.ResumeLayout(false);
            this.tabPageNewChallan.ResumeLayout(false);
            this.tabPageNewChallan.PerformLayout();
            this.groupBoxChallanPackingSlip.ResumeLayout(false);
            this.groupBoxChallanPackingSlip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewChallan)).EndInit();
            this.tabPageChallanPrint.ResumeLayout(false);
            this.tabPageChallanPrint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChallanList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChallanListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aA_2023_2024DataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPageGodownTransfer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGodownTrfPSlips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vwGodownTrfSlipsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGodownTrfDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewChallanPrintBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aA_2023_2024DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newChallanBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private AA_2023_2024DataSet aA_2023_2024DataSet;
        private System.Windows.Forms.BindingSource viewChallanPrintBindingSource;
        private AA_2023_2024DataSetTableAdapters.ViewChallanPrintTableAdapter viewChallanPrintTableAdapter;
        private AA_2023_2024DataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private AA_2023_2024DataSet aA_2023_2024DataSet1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGodownTransfer;
        private System.Windows.Forms.DataGridView dgvGodownTrfDetail;
        private System.Windows.Forms.BindingSource vwGodownTrfSlipsBindingSource;
        private AA_2023_2024DataSetTableAdapters.vwGodownTrfSlipsTableAdapter vwGodownTrfSlipsTableAdapter;
        private System.Windows.Forms.Button btnGetGodownTrfSlips;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn billNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarkDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridView dgvGodownTrfPSlips;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.TabPage tabPageChallanPrint;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblChallanProgress;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnGenChallan;
        private System.Windows.Forms.DataGridView dgvChallanList;
        private System.Windows.Forms.TextBox textBoxChallan;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerChallanPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTextBoxDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTextBoxBillNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTextBoxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTextBoxQty;
        private System.Windows.Forms.BindingSource viewChallanListBindingSource;
        private AA_2023_2024DataSetTableAdapters.ViewChallanListTableAdapter viewChallanListTableAdapter1;
        private System.Windows.Forms.TabPage tabPageNewChallan;
        private System.Windows.Forms.DataGridView dgvNewChallan;
        private AA_2023_2024DataSetTableAdapters.NewChallanItemTableAdapter newChallanItemTableAdapter1;
        private System.Windows.Forms.BindingSource newChallanBindingSource;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelDealerName;
        private System.Windows.Forms.ComboBox comboBoxDealerName;
        private System.Windows.Forms.Button buttonNewChallanInsert;
        private System.Windows.Forms.TextBox textBoxNewChallanRemark;
        private System.Windows.Forms.Label labelNewChallanRemark;
        private System.Windows.Forms.Label labelNewChallanNumber;
        private System.Windows.Forms.DateTimePicker dateNewChallan;
        private System.Windows.Forms.Button buttonChallanPrintRefresh;
        private System.Windows.Forms.Label labelDealerDetails;
        private System.Windows.Forms.Button buttonResetChallan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNameFilter;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_35;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_40;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_45;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_50;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_55;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_60;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_65;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_70;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_75_XS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_78;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_80_S;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_85_M;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_90_L;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_95_XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_100_2XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_105_3XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_110_4XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_120_6XL;
        private System.Windows.Forms.DataGridViewTextBoxColumn Size_Misc;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowTotal;
        private System.Windows.Forms.Button btnTallyExport;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.GroupBox groupBoxChallanPackingSlip;
        private System.Windows.Forms.RadioButton radioButtonPackingSlipTransfer;
        private System.Windows.Forms.RadioButton radioButtonNewChallan;
        private System.Windows.Forms.TextBox textBoxPackingSlip;
        private System.Windows.Forms.Label labelPackingSlip;
    }
}

