using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsSample.DataLayer;
using WindowsFormsSample.LogicLayer;

namespace WindowsFormsSample.PresentationLayer
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

        private void dataContextTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataContext.DataContextType = GetDataContextType();
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

            dataContextTypeComboBox.DataSource = Enum.GetNames(typeof(DataContextType));
            DataContext.DataContextType = GetDataContextType();
        }

        private DataContextType GetDataContextType()
        {
            return (DataContextType)Enum.Parse(typeof(DataContextType), dataContextTypeComboBox.SelectedValue.ToString());
        }

        /// <summary>
        /// Load organization items from database.
        /// </summary>
        private void LoadOrganizationFromDb()
        {
            IEnumerable<IOrganization> organizationList = DataContext.GetOrganizationList();
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
            IEnumerable<IEmployee> employeeList = DataContext.GetEmployeeListByOrganizationId(organizationId);
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
