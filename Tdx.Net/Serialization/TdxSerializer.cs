using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdx.Net.Models;

namespace Tdx.Net.Serialization
{
    public static class TdxSerializer
    {
        public static List<byte> SerializeDocument(TdxDocument document, TdxMap map)
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
        public static byte[] GetPropertyBytes(TdxProperty property, TdxMap map)
        {
            // property start flag
            var endBytes = new List<byte>(new byte[]
            {
                255,
                236
            });

            endBytes.AddRange(GetPropertyHeaderBytes(property, map));
            endBytes.AddRange(GetPropertyValueBytes(property.Value));
            
            //var 

        }

        public static byte[] GetPropertyHeaderBytes(TdxProperty property, TdxMap map)
        {
            var mapId = map.MapData[property.Name].KeyId;
            
            //var eBytes = new List<byte>();
            var tBytes = new List<byte>(BitConverter.GetBytes(mapId));



            //eBytes.AddRange();
        }

        public static byte[] GetPropertyValueBytes(TdxValue value)
        {

        }

        public static class TdxValueSerializers
        {
            public static byte[] GetIntBytes()
            {

            }
        }
    }
}
