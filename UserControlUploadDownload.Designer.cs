namespace GoldenCoinChallan
{
    partial class ucUploadDownload
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.btnUploadTallyPurchaseExcel = new System.Windows.Forms.Button();
            this.btnUploadTallyPSlipExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // btnUploadTallyPurchaseExcel
            // 
            this.btnUploadTallyPurchaseExcel.Location = new System.Drawing.Point(166, 34);
            this.btnUploadTallyPurchaseExcel.Name = "btnUploadTallyPurchaseExcel";
            this.btnUploadTallyPurchaseExcel.Size = new System.Drawing.Size(118, 45);
            this.btnUploadTallyPurchaseExcel.TabIndex = 0;
            this.btnUploadTallyPurchaseExcel.Text = "Upload Tally PURCHASE Excel";
            this.btnUploadTallyPurchaseExcel.UseVisualStyleBackColor = true;
            this.btnUploadTallyPurchaseExcel.Click += new System.EventHandler(this.btnUploadTallyPurchaseExcel_Click);
            // 
            // btnUploadTallyPSlipExcel
            // 
            this.btnUploadTallyPSlipExcel.Location = new System.Drawing.Point(166, 109);
            this.btnUploadTallyPSlipExcel.Name = "btnUploadTallyPSlipExcel";
            this.btnUploadTallyPSlipExcel.Size = new System.Drawing.Size(118, 45);
            this.btnUploadTallyPSlipExcel.TabIndex = 1;
            this.btnUploadTallyPSlipExcel.Text = "Upload Tally PACKING SLIP Excel";
            this.btnUploadTallyPSlipExcel.UseVisualStyleBackColor = true;
            // 
            // ucUploadDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUploadTallyPSlipExcel);
            this.Controls.Add(this.btnUploadTallyPurchaseExcel);
            this.Name = "ucUploadDownload";
            this.Size = new System.Drawing.Size(810, 386);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnUploadTallyPurchaseExcel;
        private System.Windows.Forms.Button btnUploadTallyPSlipExcel;
    }
}
