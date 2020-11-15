namespace Data.SqlClient
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Data.Models;
    using Microsoft.Data.SqlClient;

    /// <summary>
    /// SqlClient Helper.
    /// </summary>
    public class SqlClientHelper
    {
        public IEnumerable<Organization> GetOrganizationList()
        {
            var organizationList = new List<Organization>();

            using (var connection = new SqlConnection(Consts.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "usp_GetOrganizationList";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var item = new Organization
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Inn = reader["Inn"].ToString(),
                                LegalAddress = reader["LegalAddress"].ToString(),
                                PhysicalAddress = reader["PhysicalAddress"].ToString(),
                                Comment = reader["Comment"].ToString(),
                            };

                            organizationList.Add(item);
                        }
                    }
                }
            }

            return organizationList;
        }

        public IEnumerable<Employee> GetEmployeeListByOrganizationId(int organizationId)
        {
            var employeeList = new List<Employee>();

            using (var connection = new SqlConnection(Consts.ConnectionString))
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
                            var employee = new Employee
                            {
                                Id = (int)reader["Id"],
                                LastName = reader["LastName"].ToString(),
                                Name = reader["Name"].ToString(),
                                MiddleName = reader["MiddleName"].ToString(),
                                DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString()),
                                PassportSeries = reader["PassportSeries"].ToString(),
                                PassportNumber = reader["PassportNumber"].ToString(),
                                Comment = reader["Comment"].ToString(),
                            };

                            employeeList.Add(employee);
                        }
                    }
                }
            }

            return employeeList;
        }

        public void ImportDataToDb(int organizationId, IEnumerable<Employee> employeeList)
        {
            using (var connection = new SqlConnection(Consts.ConnectionString))
            {
                connection.Open();

                foreach (Employee employee in employeeList)
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
            command.Parameters.Add(new SqlParameter(parameterName, dbType) {Value = value});
        }
    }
}
