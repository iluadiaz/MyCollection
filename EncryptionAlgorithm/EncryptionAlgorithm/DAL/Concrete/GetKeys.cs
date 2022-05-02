using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionAlgorithm.DAL.Abstract;
using System.Numerics;
using EncryptionAlgorithm.Models;

namespace EncryptionAlgorithm.DAL.Concrete
{
    public class GetKeys : IGetKeys
    {        
        public decimal modInverse(decimal a, decimal b)
        {
            for (decimal x = 1; x < b; x++)
                if (((a % b) * (x % b)) % b == 1)
                    return x;
            return 1;
        }
        public decimal gcd(decimal a, decimal b)
        {
            if (a == 0)
                return b;
            return gcd(b % a, a);
        }
        public decimal returnN(EncryptionModels data)
        {
            return data.n;
        }
        public decimal publicKey(EncryptionModels data)
        {
            while (data.e < data.phi)
            {
                if (gcd(data.e, data.phi) == 1)
                    break;
                else
                    data.e++;
            }
            return data.e;
        }
        public decimal privateKey(EncryptionModels data)
        {
            return modInverse(data.e, data.phi);

        }
    }
}
