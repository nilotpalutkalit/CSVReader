using System;
using System.Collections.Generic;

namespace _10092020
{
    public class QueryResult
    {
        public Dictionary<string, string> row { get; set; }

        public QueryResult()
        {

            row = new Dictionary<string, string>();
        }
    }
}
