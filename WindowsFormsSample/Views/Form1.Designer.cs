namespace WindowsFormsSample.Views
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
            this.organizationDataGridView = new System.Windows.Forms.DataGridView();
            this.employeeDataGridView = new System.Windows.Forms.DataGridView();
            this.organizationLabel = new System.Windows.Forms.Label();
            this.employeeLabel = new System.Windows.Forms.Label();
            this.loadFromDbButton = new System.Windows.Forms.Button();
            this.importFromCsvButton = new System.Windows.Forms.Button();
            this.exportToCsvButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.organizationDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // organizationDataGridView
            // 
            this.organizationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.organizationDataGridView.Location = new System.Drawing.Point(14, 33);
            this.organizationDataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.organizationDataGridView.MultiSelect = false;
            this.organizationDataGridView.Name = "organizationDataGridView";
            this.organizationDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.organizationDataGridView.Size = new System.Drawing.Size(931, 262);
            this.organizationDataGridView.TabIndex = 0;
            this.organizationDataGridView.SelectionChanged += new System.EventHandler(this.DgvOrganization_SelectionChanged);
            // 
            // employeeDataGridView
            // 
            this.employeeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeDataGridView.Location = new System.Drawing.Point(18, 333);
            this.employeeDataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.employeeDataGridView.Name = "employeeDataGridView";
            this.employeeDataGridView.Size = new System.Drawing.Size(927, 254);
            this.employeeDataGridView.TabIndex = 1;
            // 
            // organizationLabel
            // 
            this.organizationLabel.AutoSize = true;
            this.organizationLabel.Location = new System.Drawing.Point(10, 10);
            this.organizationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.organizationLabel.Name = "organizationLabel";
            this.organizationLabel.Size = new System.Drawing.Size(75, 15);
            this.organizationLabel.TabIndex = 2;
            this.organizationLabel.Text = "Organization";
            // 
            // employeeLabel
            // 
            this.employeeLabel.AutoSize = true;
            this.employeeLabel.Location = new System.Drawing.Point(14, 308);
            this.employeeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.employeeLabel.Name = "employeeLabel";
            this.employeeLabel.Size = new System.Drawing.Size(59, 15);
            this.employeeLabel.TabIndex = 3;
            this.employeeLabel.Text = "Employee";
            // 
            // loadFromDbButton
            // 
            this.loadFromDbButton.Location = new System.Drawing.Point(138, 3);
            this.loadFromDbButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.loadFromDbButton.Name = "loadFromDbButton";
            this.loadFromDbButton.Size = new System.Drawing.Size(127, 27);
            this.loadFromDbButton.TabIndex = 4;
            this.loadFromDbButton.Text = "Load from database";
            this.loadFromDbButton.UseVisualStyleBackColor = true;
            this.loadFromDbButton.Click += new System.EventHandler(this.LoadOrganizationFromDbButton_Click);
            // 
            // importFromCsvButton
            // 
            this.importFromCsvButton.Location = new System.Drawing.Point(272, 3);
            this.importFromCsvButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.importFromCsvButton.Name = "importFromCsvButton";
            this.importFromCsvButton.Size = new System.Drawing.Size(118, 27);
            this.importFromCsvButton.TabIndex = 5;
            this.importFromCsvButton.Text = "Import from csv";
            this.importFromCsvButton.UseVisualStyleBackColor = true;
            this.importFromCsvButton.Click += new System.EventHandler(this.ImportFromCsvButton_Click);
            // 
            // exportToCsvButton
            // 
            this.exportToCsvButton.Location = new System.Drawing.Point(397, 3);
            this.exportToCsvButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.exportToCsvButton.Name = "exportToCsvButton";
            this.exportToCsvButton.Size = new System.Drawing.Size(117, 27);
            this.exportToCsvButton.TabIndex = 6;
            this.exportToCsvButton.Text = "Export to csv";
            this.exportToCsvButton.UseVisualStyleBackColor = true;
            this.exportToCsvButton.Click += new System.EventHandler(this.ExportToCsvButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 601);
            this.Controls.Add(this.exportToCsvButton);
            this.Controls.Add(this.importFromCsvButton);
            this.Controls.Add(this.loadFromDbButton);
            this.Controls.Add(this.employeeLabel);
            this.Controls.Add(this.organizationLabel);
            this.Controls.Add(this.employeeDataGridView);
            this.Controls.Add(this.organizationDataGridView);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "OrganizationEmployee";
            ((System.ComponentModel.ISupportInitialize)(this.organizationDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView organizationDataGridView;
        private System.Windows.Forms.DataGridView employeeDataGridView;
        private System.Windows.Forms.Label organizationLabel;
        private System.Windows.Forms.Label employeeLabel;
        private System.Windows.Forms.Button loadFromDbButton;
        private System.Windows.Forms.Button importFromCsvButton;
        private System.Windows.Forms.Button exportToCsvButton;
    }
}

