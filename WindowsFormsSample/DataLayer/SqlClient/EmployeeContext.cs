using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsSample.Items;

namespace WindowsFormsSample.DataLayer.SqlClient
{
    public static class EmployeeContext
    {
        /// <summary>
        /// Get employee items from database according selected organization id.
        /// </summary>
        public static IEnumerable<IEmployee> GetEmployeeListFromDbByOrganizationId(int organizationId)
        {
            var employeeList = new List<IEmployee>();

            using (var connection = new SqlConnection(Consts.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_GetEmployeeList";
                    command.Parameters.Add(new SqlParameter("OrganizationId", SqlDbType.Int) {Value = organizationId});

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employee = new EmployeeItem
                            {
                                Id = (int)reader["Id"],
                                LastName = reader["LastName"].ToString(),
                                Name = reader["Name"].ToString(),
                                MiddleName = reader["MiddleName"].ToString(),
                                DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                                PassportSeries = reader["PassportSeries"].ToString(),
                                PassportNumber = reader["PassportNumber"].ToString(),
                                Comment = reader["Comment"].ToString()
                            };

                            employeeList.Add(employee);
                        }
                    }
                }
            }

            return employeeList;
        }

        /// <summary>
        /// Import employee items into Employee table.
        /// </summary>
        public static void ImportDataToDb(int organizationId, IEnumerable<IEmployee> employeeList)
        {
            using (var connection = new SqlConnection(Consts.ConnectionString))
            {
                connection.Open();

                foreach (IEmployee employee in employeeList)
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "usp_InsertEmployee";

                        AddParameter(command, "OrganizationId", SqlDbType.Int, organizationId);
                        AddParameter(command, "LastName", SqlDbType.NVarChar, employee.LastName);
                        AddParameter(command, "Name", SqlDbType.NVarChar, employee.Name);
                        AddParameter(command, "MiddleName", SqlDbType.NVarChar, employee.MiddleName);
                        AddParameter(command, "DateOfBirth", SqlDbType.DateTime, employee.DateOfBirth);
                        AddParameter(command, "PassportSeries", SqlDbType.NVarChar, employee.PassportSeries);
                        AddParameter(command, "PassportNumber", SqlDbType.NVarChar, employee.PassportNumber);
                        AddParameter(command, "Comment", SqlDbType.NVarChar, employee.Comment);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private static void AddParameter(SqlCommand command, string parameterName, SqlDbType dbType, object value)
        {
            command.Parameters.Add(new SqlParameter(parameterName, dbType) { Value = value });
        }
    }
}
