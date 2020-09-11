using System;
using System.Collections.Generic;
using _10092020;

namespace CSVReader
{
    public class QueryResultResponse
    {
        public List<QueryResult> queryResult { get; set; }
        public int numRows { get; set; }
        public QueryResultResponse()
        {
        }
    }
}
