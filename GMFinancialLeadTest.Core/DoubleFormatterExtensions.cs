using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GMFinancialLeadTest.Core
{
    public static class DoubleFormatterExtensions
    {
        public static string FormatAsCurrenty(this double value)
        {
            return string.Format("{0:C2}", value);
        }
    }
}
