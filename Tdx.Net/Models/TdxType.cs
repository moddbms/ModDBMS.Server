using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdx.Net.Models
{
    public enum TdxType
    {
        Guid,
        String,
        Bool,
        Int16,
        Int32,
        Int64,
        Int128,
        Float32,
        Float64,
        ScientificNumber,
        Decimal128,
        DateTime,
        TdxObject,
        RawJson,
        RawXml,
        Array,
        Binary,
        Prodedure,

        Dynamic,
        //Expression
    }
}
