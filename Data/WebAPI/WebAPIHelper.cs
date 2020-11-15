namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Data.Models;

    public static class WebAPIHelper
    {
        public static async Task<IEnumerable<Organization>> GetOrganizations()
        {
            using (HttpClient client = GetHttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("Organizations"))
                {
                    response.EnsureSuccessStatusCode();

                    IEnumerable<Organization> result = await response.Content.ReadAsAsync<List<Organization>>();
                    return result;
                }
            }
        }

        public static async Task<IEnumerable<Employee>> GetEmployeesByOrganizationId(int id)
        {
            using (HttpClient client = GetHttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync($"Organizations/{id}/Employees"))
                {
                    response.EnsureSuccessStatusCode();

                    IEnumerable<Employee> result = await response.Content.ReadAsAsync<List<Employee>>();
                    return result;
                }
            }
        }

        public static async Task<IEnumerable<Employee>> ImportEmployeesByOrganizationId(int id, IEnumerable<Employee> employeeList)
        {
            using (HttpClient client = GetHttpClient())
            {
                using (HttpResponseMessage response = await client.PostAsJsonAsync($"Organizations/{id}/Employees", employeeList))
                {
                    response.EnsureSuccessStatusCode();

                    IEnumerable<Employee> result = await response.Content.ReadAsAsync<List<Employee>>();
                    return result;
                }
            }
        }

        private static HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
