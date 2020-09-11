using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using _10092020;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CSVReader
{
    [Route("[controller]")]
    public class CSVReadController : Controller
    {
        ICSVReader _csvReader;
        public CSVReadController(ICSVReader csvReader)
        {
            _csvReader = csvReader;
        }

        [HttpPost]
        public string Initialize([FromBody] RequestBody requestBody)
        {
            SimpleCondition condition = new SimpleCondition();
            //Need to parse query string using shunting yard algorithm and convert to ICondition.
            var token = _csvReader.Initialize(requestBody.ColumnNames, requestBody.csvName, condition);
            return token;
        }

        // GET api/values/5
        [HttpGet("{token}/{numRows}")]
        public string ReadRows(string token, int numRows)
        {
            List<QueryResult> queryResults;
            int rows = _csvReader.ReadRows(numRows, out queryResults, token);
            QueryResultResponse queryResponse = new QueryResultResponse();
            queryResponse.queryResult = queryResults;
            queryResponse.numRows = rows;
            string result = JsonConvert.SerializeObject(queryResponse);
            return result;
        }

        [HttpGet]
        public string Welcome()
        {
            RequestBody requestBody = new RequestBody();
            var result = "Usage: \n API 1 (Initialize): Method = Post, RequestBody example = " + JsonConvert.SerializeObject(requestBody);
            result += "\n API 2 (ReadRows) CSVRead/{token}/{NumberOfRowsToRead}";
            return result;
        }

    }
}
