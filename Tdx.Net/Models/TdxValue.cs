using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdx.Net.Models
{
    public class TdxValue
    {
        public TdxType Type;
    }

    public class TdxGuidValue : TdxValue
    {
        public Guid Value;
    }

    public class TdxStringValue : TdxValue
    {
        public string Value;
        public Encoding Encoding = Encoding.Unicode;
    }
}
