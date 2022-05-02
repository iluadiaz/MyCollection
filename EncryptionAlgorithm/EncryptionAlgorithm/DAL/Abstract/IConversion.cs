using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAlgorithm.DAL.Abstract
{
    public interface IConversion
    {
        public string StringToBinary(string? data);
    }
}
