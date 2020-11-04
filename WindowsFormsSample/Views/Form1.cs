using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsSample.Data;
using WindowsFormsSample.Logic;

namespace WindowsFormsSample.Views
{
    /// <summary>
    /// Main form.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        #region Event handlers
        private void loadOrganizationFromDbButton_Click(object sender, EventArgs e)
        {
            LoadOrganizationFromDb();
        }

        private void importFromCsvButton_Click(object sender, EventArgs e)
        {
            ImportEmployeesFromCsv();

            // Refresh employee list.
            employeeDataGridView.DataSource = GetEmployeeListByOrganizationId();
            MessageBox.Show("Data have been imported and refreshed");
        }

        private void exportToCsvButton_Click(object sender, EventArgs e)
        {
            ExportEmployeesToCsv();
        }

        private void dgvOrganization_SelectionChanged(object sender, EventArgs e)
        {
            employeeDataGridView.DataSource = GetEmployeeListByOrganizationId();
        }

        private void dataProviderTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataContext.Current.DataProviderType = GetDataProviderType();
        }
        #endregion

        /// <summary>
        /// Init properties.
        /// </summary>
        private void Init()
        {
            // Init organization grid properties.
            organizationDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            organizationDataGridView.MultiSelect = false;
            organizationDataGridView.ReadOnly = true;

            // Init employee grid properties.
            employeeDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            employeeDataGridView.ReadOnly = true;

            SetEnabledProperties(false);

            DataContext.Current.Init();

            dataProviderTypeComboBox.DataSource = Enum.GetNames(typeof(DataProviderType));
            DataContext.Current.DataProviderType = GetDataProviderType();
        }

        private DataProviderType GetDataProviderType()
        {
            return (DataProviderType)Enum.Parse(typeof(DataProviderType), dataProviderTypeComboBox.SelectedValue.ToString());
        }

        /// <summary>
        /// Load organization items from database.
        /// </summary>
        private void LoadOrganizationFromDb()
        {
            IEnumerable<IOrganization> organizationList = DataContext.Current.GetOrganizationList();
            organizationDataGridView.DataSource = organizationList;

            SetEnabledProperties(true);
        }

        /// <summary>
        /// Set Enabled properties.
        /// </summary>
        private void SetEnabledProperties(bool isEnabled)
        {
            importFromCsvButton.Enabled = isEnabled;
            exportToCsvButton.Enabled = isEnabled;
        }

        /// <summary>
        /// Import employees items from csv file.
        /// </summary>
        private void ImportEmployeesFromCsv()
        {
            int organizationId = GetSelectedOrganizationId();
            CsvImportHelper.ImportEmployeesFromCsv(organizationId);
        }

        /// <summary>
        /// Export employees items to csv file.
        /// </summary>
        private void ExportEmployeesToCsv()
        {
            IEnumerable<IEmployee> employeeList = GetEmployeeListByOrganizationId();
            CsvExportHelper.ExportEmployeesToCsv(employeeList);
        }

        /// <summary>
        /// Get employee list by organization id.
        /// </summary>
        private IEnumerable<IEmployee> GetEmployeeListByOrganizationId()
        {
            int organizationId = GetSelectedOrganizationId();
            IEnumerable<IEmployee> employeeList = DataContext.Current.GetEmployeeListByOrganizationId(organizationId);
            return employeeList;
        }

        /// <summary>
        /// Get selected organization id. MultiSelect property should be false.
        /// </summary>
        private int GetSelectedOrganizationId()
        {
            int organizationId = 0;

            foreach (DataGridViewRow row in organizationDataGridView.SelectedRows)
            {
                organizationId = (int)row.Cells[0].Value;
            }

            return organizationId;
        }
    }
}
