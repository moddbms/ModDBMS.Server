using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tdx.Net.Models
{
    public interface ITdxValue
    {
        public bool IsNull { get; set; }
        public IEnumerable<byte> GetBytes();

        public static abstract TdxValue FromBytes(byte[] bytes);
    }

    public abstract class TdxValue : ITdxValue
    {
        public TdxType Type;
        public bool IsNull { get; set; }

        public abstract IEnumerable<byte> GetBytes();

        public static TdxValue FromBytes(byte[] bytes)
        {
            return default;
        }

        //static
        public static IEnumerable<byte> NullValue => new byte[] {1};
        protected static List<byte> ValueHeader => new() {0};
    }

    public sealed class TdxNullValue : TdxValue
    {
        public override IEnumerable<byte> GetBytes() => NullValue;
    }

    public sealed class TdxGuidValue : TdxValue
    {
        public Guid? Value;

        public override IEnumerable<byte> GetBytes()
        {
            if (IsNull || Value is null) return NullValue;
            var bytes = ValueHeader;
            bytes.AddRange(Value.Value.ToByteArray());

            return bytes;
        }
    }

    public sealed class TdxStringValue : TdxValue
    {
        public string Value;

        /// <summary>
        /// Supported encodings are UTF-8, UTF-32 and Unicode
        /// </summary>
        public Encoding VirtualEncoding;
        public TdxStringValueEncodingType EncodingType;

        public override IEnumerable<byte> GetBytes()
        {
            if (IsNull || Value is null) return NullValue;

            var bytes = ValueHeader;

            var stringData = EncodingType switch
            {
                TdxStringValueEncodingType.UTF8 => Encoding.UTF8.GetBytes(Value),
                TdxStringValueEncodingType.UTF32 => Encoding.UTF32.GetBytes(Value),
                TdxStringValueEncodingType.Unicode => Encoding.Unicode.GetBytes(Value),
                _ => throw new Exception("[CHANGE EXCEPTION TYPE] Text format not supported, select one of UTF8/UTF32/Unicode")
            };

            bytes.AddRange(BitConverter.GetBytes(stringData.Length));
            bytes.AddRange(stringData);

            return bytes;
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
        public bool? Value;
        public override IEnumerable<byte> GetBytes()
        {
            if (IsNull || Value is null) return NullValue;

            var bytes = new List<byte>()
            {
                0,
                Value.Value ? (byte)1 : (byte)0
            };

            return bytes;
        }
    }

    public sealed class TdxInt16Value : TdxValue
    {
        public short? Value;
        public override IEnumerable<byte> GetBytes()
        {
            if (IsNull || Value is null) return NullValue;

            var bytes = ValueHeader;
            bytes.AddRange(BitConverter.GetBytes(Value.Value));
            
            return bytes;
        }
    }
    public sealed class TdxUInt16Value : TdxValue
    {
        public ushort? Value;
        public override IEnumerable<byte> GetBytes()
        {
            if (IsNull || Value is null) return NullValue;

            var bytes = ValueHeader;
            bytes.AddRange(BitConverter.GetBytes(Value.Value));

            return bytes;
        }
    }

    public sealed class TdxInt32Value : TdxValue
    {
        public int? Value;
        public override IEnumerable<byte> GetBytes()
        {
            if (IsNull || Value is null) return NullValue;

            var bytes = ValueHeader;
            bytes.AddRange(BitConverter.GetBytes(Value.Value));

            return bytes;
        }
    }

    public sealed class TdxUInt32Value : TdxValue
    {
        public uint? Value;
        public override IEnumerable<byte> GetBytes()
        {
            if (IsNull || Value is null) return NullValue;

            var bytes = ValueHeader;
            bytes.AddRange(BitConverter.GetBytes(Value.Value));

            return bytes;
        }
    }

    public sealed class TdxInt64Value : TdxValue
    {
        public long? Value;
        public override IEnumerable<byte> GetBytes()
        {
            if (IsNull || Value is null) return NullValue;

            var bytes = ValueHeader;
            bytes.AddRange(BitConverter.GetBytes(Value.Value));

            return bytes;
        }
    }
    public sealed class TdxUInt64Value : TdxValue
    {
        public ulong? Value;
        public override IEnumerable<byte> GetBytes()
        {
            if (IsNull || Value is null) return NullValue;

            var bytes = ValueHeader;
            bytes.AddRange(BitConverter.GetBytes(Value.Value));

            return bytes;
        }
    }
    public sealed class TdxInt128Value : TdxValue
    {
        public Int128? Value;
        public override IEnumerable<byte> GetBytes()
        {
            if (IsNull || Value is null) return NullValue;

            var bytes = ValueHeader;
            var stringData = Encoding.ASCII.GetBytes(Value.Value.ToString());
            bytes.AddRange(BitConverter.GetBytes(stringData.Length));
            bytes.AddRange(stringData);

            return bytes;
        }
    }
    public sealed class TdxUInt128Value : TdxValue
    {
        public UInt128? Value;
        public override IEnumerable<byte> GetBytes()
        {
            if (IsNull || Value is null) return NullValue;

            var bytes = ValueHeader;
            var stringData = Encoding.ASCII.GetBytes(Value.Value.ToString());
            bytes.AddRange(BitConverter.GetBytes(stringData.Length));
            bytes.AddRange(stringData);

            return bytes;
        }
    }
}
