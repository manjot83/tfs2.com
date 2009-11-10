using System;
using System.Text;
using Centro.Inflector;

namespace TFS.Models.Reports
{
    public class CsvReportGenerator
    {
        private ICsvReport report;

        public CsvReportGenerator(ICsvReport report)
        {
            this.report = report;
        }

        public string GenerateCsv()
        {
            var table = report.ConvertToTable();
            var content = new StringBuilder();
            var columnCount = table.Columns.Count;
            // Header
            for (int i = 0; i < columnCount; i++)
            {
                var column = table.Columns[i];
                var lastColumn = i == columnCount - 1;
                content.Append(column.ColumnName.Replace(",", ";"));
                if (!lastColumn)
                    content.Append(" ,");
                else
                    content.Append(Environment.NewLine);
            }
            // Rows
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];
                for (int j = 0; j < columnCount; j++)
                {
                    var lastColumn = j == columnCount - 1;
                    content.Append(row[j].ToString().Replace(",", ";"));
                    if (!lastColumn)
                        content.Append(" ,");
                    else
                        content.Append(Environment.NewLine);
                }
            }
            content.Append(Environment.NewLine);
            return content.ToString();
        }

        public byte[] GenerateReport()
        {
            return Encoding.ASCII.GetBytes(GenerateCsv());
        }
    }
}
