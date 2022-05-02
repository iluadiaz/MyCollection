using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionAlgorithm.Models;

namespace EncryptionAlgorithm.DAL.Abstract
{
    internal interface IGetKeys
    {
        public decimal modInverse(decimal a, decimal b);
        public decimal gcd(decimal a, decimal b);
        public decimal returnN(EncryptionModels data);
        public decimal publicKey(EncryptionModels data);
        public decimal privateKey(EncryptionModels data);
    }
}
