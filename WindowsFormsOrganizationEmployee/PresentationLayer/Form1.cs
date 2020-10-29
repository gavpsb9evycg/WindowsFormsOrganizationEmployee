using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WindowsFormsOrganizationEmployee.DataLayer;
using WindowsFormsOrganizationEmployee.Items;
using WindowsFormsOrganizationEmployee.LogicLayer;

namespace WindowsFormsOrganizationEmployee.PresentationLayer
{
    /// <summary>
    /// Main form
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        #region Event handlers
        private void btnLoadOrganizationFromDb_Click(object sender, EventArgs e)
        {
            LoadOrganizationFromDb();
        }

        private void btnImportFromCsv_Click(object sender, EventArgs e)
        {
            ImportEmployeesFromCsv();

            //refresh employee list
            dgvlblEmployee.DataSource = GetEmployeeListByOrganizationId();
            MessageBox.Show("Data have been imported and refreshed");
        }

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            ExportEmployeesToCsv();
        }

        private void dgvOrganization_SelectionChanged(object sender, EventArgs e)
        {
            dgvlblEmployee.DataSource = GetEmployeeListByOrganizationId();
        }
        #endregion

        /// <summary>
        /// Init properties
        /// </summary>
        private void Init()
        {
            //Init organization grid properties
            dgvOrganization.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrganization.MultiSelect = false;
            dgvOrganization.ReadOnly = true;

            //Init employee grid properties
            dgvlblEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvlblEmployee.ReadOnly = true;

            SetEnabledProperties(false);
        }

        /// <summary>
        /// Load organization items from database
        /// </summary>
        private void LoadOrganizationFromDb()
        {
            List<OrganizationItem> organizationList = OrganizationRetriever.GetOrganizationList();
            dgvOrganization.DataSource = organizationList;

            SetEnabledProperties(true);
        }

        /// <summary>
        /// Set Enabled properties
        /// </summary>
        private void SetEnabledProperties(Boolean isEnabled)
        {
            btnImportFromCsv.Enabled = isEnabled;
            btnExportToCsv.Enabled = isEnabled;
        }

        /// <summary>
        /// Import employees items from csv file
        /// </summary>
        private void ImportEmployeesFromCsv()
        {
            Int32 organizationId = GetSelectedOrganizationId();
            CsvImportHelper.ImportEmployeesFromCsv(organizationId);
        }

        /// <summary>
        /// Export employees items to csv file
        /// </summary>
        private void ExportEmployeesToCsv()
        {
            List<EmployeeItem> employeeList = GetEmployeeListByOrganizationId();
            CsvExportHelper.ExportEmployeesToCsv(employeeList);
        }

        /// <summary>
        /// Get employee list
        /// </summary>
        private List<EmployeeItem> GetEmployeeListByOrganizationId()
        {
            Int32 organizationId = GetSelectedOrganizationId();
            List<EmployeeItem> employeeList = EmployeeRetriever.GetEmployeeListFromDbByOrganizationId(organizationId);
            return employeeList;
        }

        /// <summary>
        /// Get selected organization id. MultiSelect property should be false
        /// </summary>
        public int GetSelectedOrganizationId()
        {
            Int32 organizationId = 0;

            foreach (DataGridViewRow row in dgvOrganization.SelectedRows)
            {
                organizationId = (Int32)row.Cells[0].Value;
            }

            return organizationId;
        }
    }
}
