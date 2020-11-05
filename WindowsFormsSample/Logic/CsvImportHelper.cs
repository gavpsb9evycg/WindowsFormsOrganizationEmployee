using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsSample.Logic
{
    /// <summary>
    /// Csv import helper class.
    /// </summary>
    public static class CsvImportHelper
    {
        /// <summary>
        /// Import employees items from csv file.
        /// </summary>
        public static void ImportEmployeesFromCsv(int organizationId)
        {
            string fileName = GetFileName();
            if (string.IsNullOrWhiteSpace(fileName))
                return;

            IEnumerable<IEmployee> employeeList = GetEmployeeListFromCsv(fileName);
            DataContext.Current.ImportDataToDb(organizationId, employeeList);
        }

        /// <summary>
        /// Get employee items from csv file.
        /// </summary>
        public static IEnumerable<IEmployee> GetEmployeeListFromCsv(string fileName)
        {
            var employeeList = new List<IEmployee>();

            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                // Check whether there is a header.
                if (line.Contains(Consts.CsvHeader))
                    continue;

                string[] parts = line.Split(',');

                // Check csv part count.
                if (parts.Length != Consts.CsvPartCount)
                    continue;

                var item = new Employee
                {
                    LastName = parts[0],
                    Name = parts[1],
                    MiddleName = parts[2],
                    DateOfBirth = DateTime.ParseExact(parts[3], "yyyyMMdd", null),
                    PassportSeries = parts[4],
                    PassportNumber = parts[5],
                    Comment = parts[6],
                };

                employeeList.Add(item);
            }

            return employeeList;
        }

        /// <summary>
        /// Get file name for import data.
        /// </summary>
        /// <returns></returns>
        private static string GetFileName()
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = Consts.CsvFilter,
                FilterIndex = 0,
                RestoreDirectory = true,
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = dialog.FileName;
                return selectedFileName;
            }

            return string.Empty;
        }
    }
}
