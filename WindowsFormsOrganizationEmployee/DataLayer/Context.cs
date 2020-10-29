using System;

namespace WindowsFormsSample.DataLayer
{
    public static class Context
    {
        //commented because of Unit test. When Unit test run, there is the exception - ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).FilePath	error CS0103: The name 'ConfigurationManager does not exist in the current context
        public static String ConnectionString { get; } = "Data Source=.;Initial Catalog=OrganizationEmployee;Integrated Security=True"; // ConfigurationManager.ConnectionStrings["OrganizationEmployee"].ConnectionString;
    }
}
