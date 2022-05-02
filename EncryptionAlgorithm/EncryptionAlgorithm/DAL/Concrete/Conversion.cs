using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionAlgorithm.Models;
using EncryptionAlgorithm.DAL.Abstract;

namespace EncryptionAlgorithm.DAL.Concrete
{
    public class Conversion : IConversion
    {
        public string StringToBinary(string? data)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
    }
}
