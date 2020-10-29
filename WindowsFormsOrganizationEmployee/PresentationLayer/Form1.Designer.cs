namespace WinFormsOrganizationEmployee.PresentationLayer
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
            this.dgvOrganization = new System.Windows.Forms.DataGridView();
            this.dgvlblEmployee = new System.Windows.Forms.DataGridView();
            this.lblOrganization = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.btnLoadFromDb = new System.Windows.Forms.Button();
            this.btnImportFromCsv = new System.Windows.Forms.Button();
            this.btnExportToCsv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlblEmployee)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOrganization
            // 
            this.dgvOrganization.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrganization.Location = new System.Drawing.Point(12, 29);
            this.dgvOrganization.MultiSelect = false;
            this.dgvOrganization.Name = "dgvOrganization";
            this.dgvOrganization.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOrganization.Size = new System.Drawing.Size(798, 227);
            this.dgvOrganization.TabIndex = 0;
            this.dgvOrganization.SelectionChanged += new System.EventHandler(this.dgvOrganization_SelectionChanged);
            // 
            // dgvlblEmployee
            // 
            this.dgvlblEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvlblEmployee.Location = new System.Drawing.Point(15, 289);
            this.dgvlblEmployee.Name = "dgvlblEmployee";
            this.dgvlblEmployee.Size = new System.Drawing.Size(795, 220);
            this.dgvlblEmployee.TabIndex = 1;
            // 
            // lblOrganization
            // 
            this.lblOrganization.AutoSize = true;
            this.lblOrganization.Location = new System.Drawing.Point(9, 9);
            this.lblOrganization.Name = "lblOrganization";
            this.lblOrganization.Size = new System.Drawing.Size(66, 13);
            this.lblOrganization.TabIndex = 2;
            this.lblOrganization.Text = "Organization";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(12, 267);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(53, 13);
            this.lblEmployee.TabIndex = 3;
            this.lblEmployee.Text = "Employee";
            // 
            // btnLoadFromDb
            // 
            this.btnLoadFromDb.Location = new System.Drawing.Point(118, 3);
            this.btnLoadFromDb.Name = "btnLoadFromDb";
            this.btnLoadFromDb.Size = new System.Drawing.Size(109, 23);
            this.btnLoadFromDb.TabIndex = 4;
            this.btnLoadFromDb.Text = "Load from database";
            this.btnLoadFromDb.UseVisualStyleBackColor = true;
            this.btnLoadFromDb.Click += new System.EventHandler(this.btnLoadOrganizationFromDb_Click);
            // 
            // btnImportFromCsv
            // 
            this.btnImportFromCsv.Location = new System.Drawing.Point(233, 3);
            this.btnImportFromCsv.Name = "btnImportFromCsv";
            this.btnImportFromCsv.Size = new System.Drawing.Size(101, 23);
            this.btnImportFromCsv.TabIndex = 5;
            this.btnImportFromCsv.Text = "Import from csv";
            this.btnImportFromCsv.UseVisualStyleBackColor = true;
            this.btnImportFromCsv.Click += new System.EventHandler(this.btnImportFromCsv_Click);
            // 
            // btnExportToCsv
            // 
            this.btnExportToCsv.Location = new System.Drawing.Point(340, 3);
            this.btnExportToCsv.Name = "btnExportToCsv";
            this.btnExportToCsv.Size = new System.Drawing.Size(100, 23);
            this.btnExportToCsv.TabIndex = 6;
            this.btnExportToCsv.Text = "Export to csv";
            this.btnExportToCsv.UseVisualStyleBackColor = true;
            this.btnExportToCsv.Click += new System.EventHandler(this.btnExportToCsv_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 521);
            this.Controls.Add(this.btnExportToCsv);
            this.Controls.Add(this.btnImportFromCsv);
            this.Controls.Add(this.btnLoadFromDb);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblOrganization);
            this.Controls.Add(this.dgvlblEmployee);
            this.Controls.Add(this.dgvOrganization);
            this.Name = "Form1";
            this.Text = "OrganizationEmployee";
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvlblEmployee)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrganization;
        private System.Windows.Forms.DataGridView dgvlblEmployee;
        private System.Windows.Forms.Label lblOrganization;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Button btnLoadFromDb;
        private System.Windows.Forms.Button btnImportFromCsv;
        private System.Windows.Forms.Button btnExportToCsv;
    }
}

