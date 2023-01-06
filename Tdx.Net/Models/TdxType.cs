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
        UInt16,
        Int32,
        UInt32,
        Int64,
        UInt64,
        /// <summary>
        /// Stored as an ASCII string
        /// </summary>
        Int128,
        /// <summary>
        /// Stored as an ASCII string
        /// </summary>
        UInt128,
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
        Null,
        Dynamic,
        //Expression
    }
}
