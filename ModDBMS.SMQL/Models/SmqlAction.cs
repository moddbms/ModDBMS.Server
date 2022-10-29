using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdx.Net.Models;

namespace ModDBMS.SMQL.Models
{
    public class SmqlActionData
    {
        public Type ActionType;

        public enum Type
        {
            Read,
            Insert,
            Update,
            Delete,
        }
    }

    public sealed class ReadActionData : SmqlActionData
    {
        public List<string> PropertyNames;
    }

    public sealed class InsertActionData : SmqlActionData
    {
        
        public List<TdxDocument> Documents;
    }

    public sealed class UpdateActionData : SmqlActionData
    {

    }

    public sealed class DeleteActionData : SmqlActionData 
    {

    }

    public sealed class ResultOutputOptions
    {
        public List<OutputRequest> Outputs;

        public sealed class OutputRequest
        {

            public enum Type
            {
                Inserted,
                Deleted,
            }
        }
    }
}
