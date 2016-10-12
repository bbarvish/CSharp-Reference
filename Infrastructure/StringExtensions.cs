using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class StringExtensions
    {
        public static bool ToBoolean(this string sourceString)
        {
            if (string.IsNullOrEmpty(sourceString))
                return false;

            return Convert.ToBoolean(sourceString);
        }
    }
}
