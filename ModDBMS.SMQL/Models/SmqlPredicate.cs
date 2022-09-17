using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdx.Net.Models;

namespace ModDBMS.SMQL.Models
{
    public class SmqlPredicate
    {

    }

    public class SmqlCondition
    {
        public Type ConditionType;

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

        }
    }


    public class SmqlSameTypeCondition : SmqlCondition
    {
        public TdxType 
    }

    public class SmqlXQueryCondition : SmqlCondition
    {
        public IEnumerable<SmqlPredicate> XQueries { get; set; }
    }

}
