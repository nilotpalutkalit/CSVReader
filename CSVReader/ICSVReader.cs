using System;
using System.Collections.Generic;

namespace _10092020
{
    enum OperationType
    {
        Eq,
        Gt,
        Lt
    }

    enum ConditionType
    {
        Simple,
        Complex

    }

    public interface ICondition
    {
        public bool Evaluate(Dictionary<string, string> row);
    }

    class SimpleCondition : ICondition
    {
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public OperationType operation { get; set; }
        public bool Evaluate(Dictionary<string, string> row)
        {
            if(row.ContainsKey(AttributeName))
            {
                bool result = false;
                string value = "";
                row.TryGetValue(AttributeName, out value);

                switch(operation)
                {
                    case OperationType.Eq:
                        result = value.Equals(AttributeValue, StringComparison.OrdinalIgnoreCase);
                        break;

                        // considering data type as string so not implementing gt and lt for now
                    case OperationType.Gt:
                        break;
                    case OperationType.Lt:
                        break;
                }

                return result;
            }
            return false;
        }


    }
    class ComplexCondition : ICondition
    {
        List<ICondition> conditions;
        QueryGroupType GroupType;


        public bool Evaluate(Dictionary<string, string> row)
        {
            bool lastResult = true;
            if(GroupType == QueryGroupType.Or)
            {
                lastResult = false;
            }
            foreach(var condition in conditions)
            {
                switch (GroupType)
                {
                    case QueryGroupType.And:
                        lastResult = lastResult && condition.Evaluate(row);
                        break;
                        ;
                    case QueryGroupType.Or:
                        lastResult = lastResult || condition.Evaluate(row);
                        break;
                }
            }
            return lastResult;
        }
    }
    enum QueryGroupType
    {
        And,
        Or
    }
    

    
    public interface ICSVReader
    {
        public string Initialize(List<string> columnNames, string csvName, ICondition filterCriteria);
        public int ReadRows(int rows, out List<QueryResult> results, string token);
    }
}
