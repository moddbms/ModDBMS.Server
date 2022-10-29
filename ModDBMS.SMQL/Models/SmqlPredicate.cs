using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdx.Net.Models;

namespace ModDBMS.SMQL.Models
{
    // example smql:
    // select Username from Users where Id == 3201 && DateCreated < '01/12/2005' && type(SomeProperty) is int32;

    public class SmqlPredicate
    {
        public bool HasConditions = false;
        public List<SmqlCondition> Conditions;
    }

    public class SmqlCondition
    {
        public Type ConditionType;
        public string PropertyName;
        public TdxValue Value;

        public enum Type
        {
            SameType = 0,
            Equals = 1,
            NotEquals = 2,
            True = 3,
            False = 4,
            XQuery = 5,
            InArray = 6,
            NotInArray = 7,
            ArrayCount = 8,
            LessThan = 9,
            MoreThan = 10,
            LessOrEqual = 11,
            MoreOrEqual = 12
        }
    }

    public class SmqlSameTypeCondition : SmqlCondition
    {
        //public TdxType 
    }

    public class SmqlXQueryCondition : SmqlCondition
    {
        public IEnumerable<SmqlPredicate> XQueries { get; set; }
    }

}
