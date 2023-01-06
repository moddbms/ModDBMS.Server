using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdx.Net.Models
{
    public interface ITdxValue
    {
        public byte[] GetBytes();

        public static abstract TdxValue FromBytes(byte[] bytes);
    }

    public abstract class TdxValue : ITdxValue
    {
        public TdxType Type;

        public abstract byte[] GetBytes();

        //public static TdxValue FromBytes(byte[] bytes)
        //{
        //    return
        //}
    }

    public sealed class TdxNullValue : TdxValue
    {

        public override byte[] GetBytes() => new byte[] { 1, 0 };
    }

    public sealed class TdxGuidValue : TdxValue
    {
        public Guid Value;

        public override byte[] GetBytes() => Value.ToByteArray();
    }
    public sealed class TdxStringValue : TdxValue
    {
        public string Value;

        /// <summary>
        /// Supported encodings are UTF-8, UTF-32 and Unicode
        /// </summary>
        public Encoding VirtualEncoding;
        public TdxStringValueEncodingType EncodingType;

        public override byte[] GetBytes()
        {
            switch (EncodingType)
            {
                case TdxStringValueEncodingType.UTF8:
                    return Encoding.UTF8.GetBytes(Value);
                case TdxStringValueEncodingType.UTF32:
                    return Encoding.UTF32.GetBytes(Value);
                case TdxStringValueEncodingType.Unicode:
                    return Encoding.Unicode.GetBytes(Value);
            }
        }

        public enum TdxStringValueEncodingType
        {
            Unicode,
            UTF8,
            UTF32
        }
    }

    public sealed class TdxBoolValue : TdxValue
    {
        public bool Value;
        public override byte[] GetBytes()
        {

        }
    }

    public sealed class TdxInt32Value : TdxValue
    {
        public int Value;
        public override byte[] GetBytes()
        {

        }
    }


}
