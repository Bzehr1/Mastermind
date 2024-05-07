using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    internal class Guess
    {
        public int Id { get; set; }
        public string Value { get; set; } = string.Empty;

        public string Result { get; set; } = string.Empty;

        public string Error { get; set;} = string.Empty;

        public Guess(int id, string value, string result, string error)
        {
            Id = id;
            Value = value;
            Result = result;
            Error = error;
        }

    }
}
