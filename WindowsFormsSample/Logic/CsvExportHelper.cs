using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WindowsFormsSample.Data;
using Microsoft.EntityFrameworkCore.Internal;

namespace WindowsFormsSample.Logic
{
    /// <summary>
    /// Csv export helper class.
    /// </summary>
    public static class CsvExportHelper
    {
        /// <summary>
        /// Export employees items to csv file.
        /// </summary>
        public static void ExportEmployeesToCsv(IEnumerable<IEmployee> employeeList, string exportPath = "", bool isOpenFile = false)
        {
            if (!IsValid(employeeList, exportPath))
                return;

            StringBuilder dataBuilder = CreateExportData(employeeList);

            ExportToFile(dataBuilder, exportPath, isOpenFile);
        }

        /// <summary>
        /// Check is valid.
        /// </summary>
        /// <returns></returns>
        private static bool IsValid(IEnumerable<IEmployee> employeeList, string exportPath)
        {
            if (employeeList == null)
            {
                return false;
            }

            // Check if the data to export exists.
            if (!employeeList.Any())
            {
                MessageBox.Show("There is no data to export");
                return false;
            }

            // Check if the export exportPath is correct.
            if (!string.IsNullOrWhiteSpace(exportPath))
            {
                if (!File.Exists(exportPath))
                {
                    MessageBox.Show("The export exportPath doesn't exist");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Create data for export.
        /// </summary>
        /// <returns></returns>
        private static StringBuilder CreateExportData(IEnumerable<IEmployee> employeeList)
        {
            var dataBuilder = new StringBuilder();

            // Create header.
            dataBuilder.AppendFormat($"Id,{Consts.CsvHeader}\r\n");

            // Create body.
            foreach (IEmployee item in employeeList)
            {
                dataBuilder.AppendFormat($"{item.Id},{item.LastName},{item.Name},{item.MiddleName},{item.DateOfBirth:yyyyMMdd},{item.PassportSeries},{item.PassportNumber},{item.Comment}\r\n");
            }

            return dataBuilder;
        }

        /// <summary>
        /// Export data to file.
        /// </summary>
        private static void ExportToFile(StringBuilder dataBuilder, string exportPath, bool isOpenFile)
        {
            if (string.IsNullOrWhiteSpace(exportPath))
            {
                exportPath = $"export_{DateTime.Now:HHmmss.fff}.csv";
            }

            try
            {
                File.WriteAllText(exportPath, dataBuilder.ToString(), GetUtf8WithoutBom());

                if (isOpenFile)
                {
                    Process.Start(exportPath);
                }

                MessageBox.Show($"Data have been exported successfully. ExportPath: {exportPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data haven't been exported. Exception: {ex.Message}");
            }
        }

        private static Encoding GetUtf8WithoutBom()
        {
            var utf8WithoutBom = new UTF8Encoding(false);
            return utf8WithoutBom;
        }
    }
}
