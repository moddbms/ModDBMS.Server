using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModDBMS.SMQL.Models
{
    public struct SmqlAction
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

    public struct ReadAction
    {
        public string[] Fields;

    }
}
