using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Numerics;
using EncryptionAlgorithm.DAL.Abstract;
using EncryptionAlgorithm.DAL.Concrete;
using System.Numerics;

namespace EncryptionAlgorithm.Models
{
    public class EncryptionModels
    {
        public decimal      p                 = 0;
        public decimal      q                 = 0;
        public int          e                 = 0;
        public decimal      n                 = 0;
        public decimal      phi               = 0;
        public decimal      d                 = 0;
        public int          publicKey         = 0;
        public BigInteger   encryptedMessage  = 0;
        public BigInteger   decryptMessage    = 0;
        public string?      Message           = null;
        public string       MessageInBinary   = null;

        public EncryptionAlg Encryption  = null;
        public GetKeys       GetKey      = null;
        public Conversion    Conversions = null;

        public char[]       Characters = null;
        public string[]     Binary     = null;

        public decimal[]    HexDataA   = null;
        public BigInteger[] HexDataB   = null;
        public string[] OrganizeBinary(string[] y, char[] z)
        {
            int counter = 0;
            int index = 0;


            //oganizing the binary
            for (int i = 0; i < z.Length; i++)
            {
                if (counter == 8)
                {
                    counter = 0;
                    index++;
                }

                y[index] += z[i];

                counter++;
            }
            return y;
        }

        public decimal[] HexDataASetUp(decimal[] a, string[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = Convert.ToInt32(b[i], 2);
                a[i] = Convert.ToDecimal(a[i]);

            }
            return a;
        }
    }

}


