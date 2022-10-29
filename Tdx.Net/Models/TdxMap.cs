using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdx.Net.Models
{
    internal class TdxMap
    {
        public Dictionary<string, TdxMapData> MapData;
    }

    public class TdxMapData
    {
        public string Key;
        public ushort KeyId;
    }
}
