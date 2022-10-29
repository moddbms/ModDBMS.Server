using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdx.Net.Models
{
    public abstract class TdxValue
    {
        public TdxType Type;
    }

    public sealed class TdxGuidValue : TdxValue
    {
        public Guid Value;
    }
    public sealed class TdxStringValue : TdxValue
    {
        public string Value;
        public Encoding Encoding = Encoding.Unicode;
    }

    public sealed class TdxBoolValue : TdxValue
    {

    }

    public sealed class TdxInt32Value : TdxValue
    {
        public int Value;
    }


}
