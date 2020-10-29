using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsOrganizationEmployee.Items;

namespace WindowsFormsOrganizationEmployee.DataLayer
{
    /// <summary>
    /// Data retriever from Employee table
    /// </summary>
    public static class EmployeeRetriever
    {
        /// <summary>
        /// Get employee items from database according selected organization id
        /// </summary>
        public static List<EmployeeItem> GetEmployeeListFromDbByOrganizationId(Int32 organizationId)
        {
            List<EmployeeItem> result = new List<EmployeeItem>();

            using (SqlConnection connection = new SqlConnection(Context.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_GetEmployeeList";
                    command.Parameters.Add(new SqlParameter("OrganizationId", SqlDbType.Int) { Value = organizationId });

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EmployeeItem item = new EmployeeItem
                            {
                                Id = (Int32)reader["Id"],
                                LastName = reader["LastName"].ToString(),
                                Name = reader["Name"].ToString(),
                                MiddleName = reader["MiddleName"].ToString(),
                                DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                                PassportSeries = reader["PassportSeries"].ToString(),
                                PassportNumber = reader["PassportNumber"].ToString(),
                                Comment = reader["Comment"].ToString()
                            };

                            result.Add(item);
                        }
                    }
                }
            }

            return result;
        }
    }
}
