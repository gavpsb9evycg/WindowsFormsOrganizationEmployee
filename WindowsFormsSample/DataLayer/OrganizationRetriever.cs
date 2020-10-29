using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsSample.Items;

namespace WindowsFormsSample.DataLayer
{
    /// <summary>
    /// Data retriever from Organization table
    /// </summary>
    public static class OrganizationRetriever
    {
        /// <summary>
        /// Get organization items from database
        /// </summary>
        public static List<OrganizationItem> GetOrganizationList()
        {
            List<OrganizationItem> result = new List<OrganizationItem>();

            using (SqlConnection connection = new SqlConnection(Context.ConnectionString))
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
                            OrganizationItem item = new OrganizationItem
                            {
                                Id = (Int32)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Inn = reader["Inn"].ToString(),
                                LegalAddress = reader["LegalAddress"].ToString(),
                                PhysicalAddress = reader["PhysicalAddress"].ToString(),
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
