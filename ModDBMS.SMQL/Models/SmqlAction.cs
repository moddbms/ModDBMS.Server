using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IEnumerable<string> Fields;
    }

    public sealed class InsertActionData : SmqlActionData
    {

    }

    public sealed class UpdateActionData : SmqlActionData
    {

    }

    public sealed class DeleteActionData : SmqlActionData 
    {

    }

    public sealed class ResultOutputOptions
    {
        public IEnumerable<OutputRequest> Outputs;

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
