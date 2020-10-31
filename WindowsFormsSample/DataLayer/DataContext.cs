using System.Collections.Generic;
using WindowsFormsSample.DataLayer.EntityFramework;
using WindowsFormsSample.DataLayer.SqlClient;

namespace WindowsFormsSample.DataLayer
{
    /// <summary>
    /// Routing data context.
    /// </summary>
    public class DataContext
    {
        private static DataContext current;
        private readonly Dictionary<DataProviderType, IDataContext> dataProviderContext = new Dictionary<DataProviderType, IDataContext>();

        private DataContext()
        {
        }

        /// <summary>
        /// Gets instance of DataContext class.
        /// </summary>
        public static DataContext Current
        {
            get
            {
                if (current == null)
                {
                    current = new DataContext();
                }

                return current;
            }
        }

        /// <summary>
        /// Gets or sets type of the data provider.
        /// </summary>
        public DataProviderType DataProviderType { get; set; }

        /// <summary>
        /// Initialization.
        /// </summary>
        public void Init()
        {
            this.dataProviderContext.Add(DataProviderType.SqlClient, new SqlClientContext());
            this.dataProviderContext.Add(DataProviderType.EntityFrameworkCore, new EntityContext());
        }

        /// <summary>
        /// Get organization items from database.
        /// </summary>
        /// <returns>Returns a collection of organization.</returns>
        public IEnumerable<IOrganization> GetOrganizationList()
        {
            return this.dataProviderContext[this.DataProviderType].GetOrganizationList();
        }

        /// <summary>
        /// Get employee items from database according selected organization id.
        /// </summary>
        /// <param name="organizationId">the id of the organization</param>
        /// <returns>Returns a collection of employees.</returns>
        public IEnumerable<IEmployee> GetEmployeeListByOrganizationId(int organizationId)
        {
            return this.dataProviderContext[this.DataProviderType].GetEmployeeListByOrganizationId(organizationId);
        }

        /// <summary>
        /// Import employee items into database.
        /// </summary>
        /// <param name="organizationId">the id of the organization</param>
        /// <param name="employeeList">a collection of employees for import</param>
        public void ImportDataToDb(int organizationId, IEnumerable<IEmployee> employeeList)
        {
            this.dataProviderContext[this.DataProviderType].ImportDataToDb(organizationId, employeeList);
        }
    }
}
