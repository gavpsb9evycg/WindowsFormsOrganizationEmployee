using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WinFormsOrganizationEmployee.Items;

namespace WinFormsOrganizationEmployee.DataLayer
{
    /// <summary>
    /// Import data to Employee table
    /// </summary>
    public static class EmployeeImportToDb
    {
        /// <summary>
        /// Import employee items into Employee table
        /// </summary>
        public static void ImportDataToDb(Int32 organizationId, List<EmployeeItem> employeeList)
        {
            using (SqlConnection connection = new SqlConnection(Context.ConnectionString))
            {
                connection.Open();

                foreach (EmployeeItem item in employeeList)
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "usp_InsertEmployee";
                        command.Parameters.Add(new SqlParameter("OrganizationId", SqlDbType.Int) {Value = organizationId});
                        command.Parameters.Add(new SqlParameter("LastName", SqlDbType.NVarChar) {Value = item.LastName});
                        command.Parameters.Add(new SqlParameter("Name", SqlDbType.NVarChar) { Value = item.Name});
                        command.Parameters.Add(new SqlParameter("MiddleName", SqlDbType.NVarChar) { Value = item.MiddleName});
                        command.Parameters.Add(new SqlParameter("DateOfBirth", SqlDbType.DateTime) { Value = item.DateOfBirth});
                        command.Parameters.Add(new SqlParameter("PassportSeries", SqlDbType.NVarChar) { Value = item.PassportSeries});
                        command.Parameters.Add(new SqlParameter("PassportNumber", SqlDbType.NVarChar) { Value = item.PassportNumber});
                        command.Parameters.Add(new SqlParameter("Comment", SqlDbType.NVarChar) { Value = item.Comment});

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
