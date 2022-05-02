using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Numerics;

namespace EncryptionAlgorithm.DAL.Abstract
{
    public interface IEncryptionAlgorithm
    {
        public BigInteger encryptMessage(decimal a, int e, int n);
        public BigInteger decryptMessage(decimal a, int e, int n);
    }

}
