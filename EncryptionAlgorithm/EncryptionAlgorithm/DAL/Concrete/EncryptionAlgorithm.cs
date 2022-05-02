using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Numerics;
using EncryptionAlgorithm.DAL.Abstract;
using EncryptionAlgorithm.Models;

namespace EncryptionAlgorithm.DAL.Concrete
{
    public class EncryptionAlg : IEncryptionAlgorithm
    {
        public BigInteger encryptMessage(decimal a, int e, int n)
        {
            BigInteger n2 = (BigInteger)n;

            BigInteger b = (BigInteger)a;

            BigInteger c = (BigInteger.Pow(b, e) % n2);

            return c;
        }
        public BigInteger decryptMessage(decimal a, int e, int n)
        {
            BigInteger n2 = (BigInteger)n;

            BigInteger b = (BigInteger)a;

            BigInteger c = (BigInteger.Pow(b, e) % n2);

            return c;
        }
    }
}
