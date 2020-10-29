using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WindowsFormsSample.Items;

namespace WindowsFormsSample.LogicLayer
{
    /// <summary>
    /// Csv export helper class
    /// </summary>
    public static class CsvExportHelper
    {
        /// <summary>
        /// Export employees items to csv file
        /// </summary>
        public static void ExportEmployeesToCsv(List<EmployeeItem> employeeList, String exportFilePath = "", Boolean isOpenFile = false)
        {
            if (!IsValid(employeeList, exportFilePath))
                return;

            StringBuilder dataBuilder = CreateExportData(employeeList);

            ExportDataToFile(dataBuilder, exportFilePath, isOpenFile);
        }

        /// <summary>
        /// Check is valid
        /// </summary>
        /// <returns></returns>
        private static bool IsValid(List<EmployeeItem> employeeList, String exportFilePath)
        {
            if (employeeList == null)
                return false;

            //check if the data to export exists
            if (employeeList.Count == 0)
            {
                MessageBox.Show("There is no data to export");
                return false;
            }

            //check if the export path is correct
            if (!String.IsNullOrWhiteSpace(exportFilePath))
            {
                if (!File.Exists(exportFilePath))
                {
                    MessageBox.Show("The export path doesn't exist");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Create data for export
        /// </summary>
        /// <returns></returns>
        private static StringBuilder CreateExportData(List<EmployeeItem> employeeList)
        {
            StringBuilder sb = new StringBuilder();

            //create header
            sb.AppendFormat("Id,LastName,Name,MiddleName,DateOfBirth,PassportSeries,PassportNumber,Comment\r\n");

            //create body
            foreach (EmployeeItem item in employeeList)
            {
                sb.AppendFormat($"{item.Id},{item.LastName},{item.Name},{item.MiddleName},{item.DateOfBirth:yyyyMMdd},{item.PassportSeries},{item.PassportNumber},{item.Comment}\r\n");
            }

            return sb;
        }

        /// <summary>
        /// Export data to file
        /// </summary>
        private static void ExportDataToFile(StringBuilder dataBuilder, String path, Boolean isOpenFile)
        {
            if (String.IsNullOrWhiteSpace(path))
                path = $"export_{DateTime.Now:HHmmss.fff}.csv";

            try
            {
                File.WriteAllText(path, dataBuilder.ToString(), GetUtf8WithoutBom());

                if (isOpenFile)
                    Process.Start(path);

                MessageBox.Show($"Data have been exported successfully. ExportFilePath: {path}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data haven't been exported. Exception: {ex.Message}");
            }
        }

        private static Encoding GetUtf8WithoutBom()
        {
            UTF8Encoding utf8WithoutBom = new UTF8Encoding(false);
            return utf8WithoutBom;
        }
    }
}
