using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsSample.Items;

namespace WindowsFormsSample.DataLayer.SqlClient
{
    public static class OrganizationContext
    {
        /// <summary>
        /// Get organization items from database.
        /// </summary>
        public static IEnumerable<IOrganization> GetOrganizationList()
        {
            var organizationList = new List<IOrganization>();

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
                            var item = new OrganizationItem
                            {
                                Id = (int)reader["Id"],
                                Name = reader["Name"].ToString(),
                                Inn = reader["Inn"].ToString(),
                                LegalAddress = reader["LegalAddress"].ToString(),
                                PhysicalAddress = reader["PhysicalAddress"].ToString(),
                                Comment = reader["Comment"].ToString()
                            };

                            organizationList.Add(item);
                        }
                    }
                }
            }

            return organizationList;
        }
    }
}
