using System;
using System.Collections.Generic;

namespace CSVReader
{
    public class RequestBody
    {
        public List<string> ColumnNames { get; set; }
        public string csvName { get; set; } = "CSVPath";
        public string queryString { get; set; } = "Query string using & | < > =";



        public RequestBody()
        {
            ColumnNames = new List<string>();
            ColumnNames.Add("Column1");
            ColumnNames.Add("Column2");
        }
    }
}
