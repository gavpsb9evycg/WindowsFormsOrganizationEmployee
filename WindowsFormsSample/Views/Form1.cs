namespace WindowsFormsSample.Views
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Data;
    using Data.Models;
    using WindowsFormsSample.Logic;

    /// <summary>
    /// Main form.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            this.Init();
        }

        private async void LoadOrganizationFromDbButton_Click(object sender, EventArgs e)
        {
            this.organizationDataGridView.DataSource = await WebAPIHelper.GetOrganizations();
            this.SetEnabledProperties(true);
        }

        private async void ImportFromCsvButton_Click(object sender, EventArgs e)
        {
            await this.ImportEmployeesFromCsv();

            // Refresh employee list.
            this.employeeDataGridView.DataSource = await this.GetEmployeeListByOrganizationId();
            MessageBox.Show("Data have been imported and refreshed");
        }

        private void ExportToCsvButton_Click(object sender, EventArgs e)
        {
            this.ExportEmployeesToCsv();
        }

        private async void DgvOrganization_SelectionChanged(object sender, EventArgs e)
        {
            this.employeeDataGridView.DataSource = await this.GetEmployeeListByOrganizationId();
        }

        /// <summary>
        /// Init properties.
        /// </summary>
        private void Init()
        {
            this.InitGridProperties(this.organizationDataGridView);
            this.InitGridProperties(this.employeeDataGridView);

            this.SetEnabledProperties(false);
        }

        private void InitGridProperties(DataGridView dataGridView)
        {
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = true;
        }

        /// <summary>
        /// Set Enabled properties.
        /// </summary>
        private void SetEnabledProperties(bool isEnabled)
        {
            this.importFromCsvButton.Enabled = isEnabled;
            this.exportToCsvButton.Enabled = isEnabled;
        }

        /// <summary>
        /// Import employees items from csv file.
        /// </summary>
        private async Task<IEnumerable<Employee>> ImportEmployeesFromCsv()
        {
            int organizationId = this.GetSelectedOrganizationId();
            return await CsvImportHelper.ImportEmployeesFromCsv(organizationId);
        }

        /// <summary>
        /// Export employees items to csv file.
        /// </summary>
        private async void ExportEmployeesToCsv()
        {
            IEnumerable<Employee> employeeList = await this.GetEmployeeListByOrganizationId();
            CsvExportHelper.ExportEmployeesToCsv(employeeList);
        }

        /// <summary>
        /// Get employee list by organization id.
        /// </summary>
        private async Task<IEnumerable<Employee>> GetEmployeeListByOrganizationId()
        {
            int organizationId = this.GetSelectedOrganizationId();
            IEnumerable<Employee> employeeList = await WebAPIHelper.GetEmployeesByOrganizationId(organizationId);
            return employeeList;
        }

        /// <summary>
        /// Get selected organization id. MultiSelect property should be false.
        /// </summary>
        private int GetSelectedOrganizationId()
        {
            int organizationId = 0;

            foreach (DataGridViewRow row in this.organizationDataGridView.SelectedRows)
            {
                organizationId = (int)row.Cells[0].Value;
            }

            return organizationId;
        }
    }
}
