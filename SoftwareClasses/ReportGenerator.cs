using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.SoftwareClasses
{
    internal class ReportGenerator
    {
        public static void ExportToCSV(DataTable dt, string filePath)
        {
            StringBuilder sb = new StringBuilder();

            // Header row
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i].ColumnName);
                if (i < dt.Columns.Count - 1) sb.Append(",");
            }
            sb.AppendLine();

            // Data rows
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append(row[i].ToString().Replace(",", " "));
                    if (i < dt.Columns.Count - 1) sb.Append(",");
                }
                sb.AppendLine();
            }

            File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
        }

    }
}
