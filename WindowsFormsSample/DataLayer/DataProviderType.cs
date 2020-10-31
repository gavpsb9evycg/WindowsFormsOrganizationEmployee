namespace WindowsFormsSample.DataLayer
{
    /// <summary>
    /// Type of the data provider.
    /// </summary>
    public enum DataProviderType
    {
        /// <summary>
        /// SqlClient data provider.
        /// </summary>
        SqlClient = 1,

        /// <summary>
        /// Entity Framework Core data provider.
        /// </summary>
        EntityFrameworkCore,
    }
}
