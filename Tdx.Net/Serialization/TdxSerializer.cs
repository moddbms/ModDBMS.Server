using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdx.Net.Models;

namespace Tdx.Net.Serialization
{
    public class TdxSerializer
    {
        public List<byte> SerializeDocument(TdxDocument document, TdxMap map)
        {
            var endBytes = new List<byte>();
            var transientBytes = new List<byte>();

            foreach (var property in document.Properties)
            {
                transientBytes.AddRange(GetPropertyBytes(property.Value, map));
            }
        }

        /// <summary>
        /// Requires existing map key ID
        /// </summary>
        /// <param name="property"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public byte[] GetPropertyBytes(TdxProperty property, TdxMap map)
        {
            var endBytes = new List<byte>();
            //var 

            var mapId = map.MapData[property.Name].KeyId;

            var idBytes = BitConverter.GetBytes(mapId);


        }

        public byte[] GetValueBytes(TdxValue value)
        {

        }
    }
}
