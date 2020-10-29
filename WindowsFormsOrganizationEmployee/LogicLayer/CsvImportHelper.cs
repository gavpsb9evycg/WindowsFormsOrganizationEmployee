using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WindowsFormsSample.DataLayer;
using WindowsFormsSample.Items;

namespace WindowsFormsSample.LogicLayer
{
    /// <summary>
    /// Csv import helper class
    /// </summary>
    public static class CsvImportHelper
    {
        /// <summary>
        /// Import employees items from csv file
        /// </summary>
        public static void ImportEmployeesFromCsv(Int32 organizationId)
        {
            String fileName = GetFileName();
            if (String.IsNullOrWhiteSpace(fileName))
                return;

            List<EmployeeItem> employeeList = GetEmployeeListFromCsv(fileName);
            EmployeeImportToDb.ImportDataToDb(organizationId, employeeList);
        }

        /// <summary>
        /// Get file name for import data
        /// </summary>
        /// <returns></returns>
        private static String GetFileName()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Csv files (*.csv)|*.csv",
                FilterIndex = 0,
                RestoreDirectory = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String selectedFileName = dialog.FileName;
                return selectedFileName;
            }

            return String.Empty;
        }

        /// <summary>
        /// Get employee items from csv file
        /// </summary>
        public static List<EmployeeItem> GetEmployeeListFromCsv(String fileName)
        {
            List<EmployeeItem> result = new List<EmployeeItem>();

            String[] lines = File.ReadAllLines(fileName);

            foreach (String line in lines)
            {
                //check whether there is a header
                if (line.StartsWith("LastName,Name,MiddleName"))
                    continue;

                String[] parts = line.Split(',');

                //check whether there are 7 items
                if (parts.Length != 7)
                    continue;

                EmployeeItem item = new EmployeeItem
                {
                    LastName = parts[0],
                    Name = parts[1],
                    MiddleName = parts[2],
                    DateOfBirth = DateTime.ParseExact(parts[3], "yyyyMMdd", null),
                    PassportSeries = parts[4],
                    PassportNumber = parts[5],
                    Comment = parts[6]
                };

                result.Add(item);
            }

            return result;
        }
    }
}
