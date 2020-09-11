using System;
using System.Collections.Generic;

namespace _10092020
{
    public class CustomCsvReader : ICSVReader
    {
        public CustomCsvReader()
        {

        }

        public string Initialize(List<string> columnNames, string csvName, ICondition filterCriteria)
        {
            return TokenGenerator.GenerateToken();
        }

        public int ReadRows(int rows, out List<QueryResult> results, string token)
        {
            results = new List<QueryResult>();
            for (int i = 0; i < rows - 1; ++i)
            {
                QueryResult qr = new QueryResult();

                qr.row.Add("EmployeeID", "1234");
                qr.row.Add("EmployeeName", "Custom Name");

                results.Add(qr);
            }
            return results.Count;
        }
    }
}
