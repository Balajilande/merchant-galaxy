using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace merchantgalaxy.Roman
{
        /// <summary>
        /// This class defines the Roman Numeral System.
        /// </summary>
        public class Roman 
        {
                private const string alphabet = "IVXLCDM";

                public static string GetAlphabet()
                {
                        return alphabet;
                }

                public static bool IsSmaller(string first, string second)
                {
                        return alphabet.IndexOf(first, StringComparison.OrdinalIgnoreCase) < 
                                alphabet.IndexOf(second, StringComparison.OrdinalIgnoreCase);
                }
        }
}
