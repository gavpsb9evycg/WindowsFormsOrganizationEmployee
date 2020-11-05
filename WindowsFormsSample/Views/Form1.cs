namespace WindowsFormsSample.Views
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Data;
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

        #region Event handlers
        private void loadOrganizationFromDbButton_Click(object sender, EventArgs e)
        {
            this.LoadOrganizationFromDb();
        }

        private void importFromCsvButton_Click(object sender, EventArgs e)
        {
            ImportEmployeesFromCsv();

            // Refresh employee list.
            this.employeeDataGridView.DataSource = this.GetEmployeeListByOrganizationId();
            MessageBox.Show("Data have been imported and refreshed");
        }

        private void exportToCsvButton_Click(object sender, EventArgs e)
        {
            this.ExportEmployeesToCsv();
        }

        private void dgvOrganization_SelectionChanged(object sender, EventArgs e)
        {
            this.employeeDataGridView.DataSource = this.GetEmployeeListByOrganizationId();
        }

        private void dataProviderTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataContext.Current.DataProviderType = this.GetDataProviderType();
        }
        #endregion

        /// <summary>
        /// Init properties.
        /// </summary>
        private void Init()
        {
            this.InitGridProperties(this.organizationDataGridView);
            this.InitGridProperties(this.employeeDataGridView);

            this.SetEnabledProperties(false);

            DataContext.Current.Init(Consts.ConnectionString);

            this.dataProviderTypeComboBox.DataSource = Enum.GetNames(typeof(DataProviderType));
            DataContext.Current.DataProviderType = this.GetDataProviderType();
        }

        private void InitGridProperties(DataGridView dataGridView)
        {
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.ReadOnly = true;
        }

        private DataProviderType GetDataProviderType()
        {
            object selectedValue = this.dataProviderTypeComboBox.SelectedValue;

            return selectedValue != null
                ? (DataProviderType) Enum.Parse(typeof(DataProviderType), selectedValue.ToString())
                : DataProviderType.SqlClient;
        }

        /// <summary>
        /// Load organization items from database.
        /// </summary>
        private void LoadOrganizationFromDb()
        {
            IEnumerable<IOrganization> organizationList = DataContext.Current.GetOrganizationList();
            this.organizationDataGridView.DataSource = organizationList;

            this.SetEnabledProperties(true);
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
        private void ImportEmployeesFromCsv()
        {
            int organizationId = this.GetSelectedOrganizationId();
            CsvImportHelper.ImportEmployeesFromCsv(organizationId);
        }

        /// <summary>
        /// Export employees items to csv file.
        /// </summary>
        private void ExportEmployeesToCsv()
        {
            IEnumerable<IEmployee> employeeList = this.GetEmployeeListByOrganizationId();
            CsvExportHelper.ExportEmployeesToCsv(employeeList);
        }

        /// <summary>
        /// Get employee list by organization id.
        /// </summary>
        private IEnumerable<IEmployee> GetEmployeeListByOrganizationId()
        {
            int organizationId = this.GetSelectedOrganizationId();
            IEnumerable<IEmployee> employeeList = DataContext.Current.GetEmployeeListByOrganizationId(organizationId);
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
