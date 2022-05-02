using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Numerics;
using EncryptionAlgorithm.DAL.Abstract;
using EncryptionAlgorithm.DAL.Concrete;
using EncryptionAlgorithm.Models;

//code from old styling
namespace EncryptionAlgorithm
{
	class Program 
	{
		static void Main(string[] args)
		{

			EncryptionModels encryption = new EncryptionModels();
			Conversion convert = new Conversion();

			//sets up keys
			//int e = (int)publicKey();

			//decimal d = privateKey();

			Console.WriteLine("What is the message you wish to encrypt?");
			encryption.Message = Console.ReadLine();
			//take user input
			//string msg = Console.ReadLine();
			//make it into binary so we do the maths on it
			encryption.MessageInBinary = convert.StringToBinary(encryption.Message);


			//prepare binary for maths
			encryption.Characters = encryption.Message.ToCharArray();
			string[] binaryCode = new string[encryption.Characters[encryption.Characters.Length / 4]];

			encryption.Binary = encryption.OrganizeBinary(binaryCode, encryption.Characters);
			//int counter = 0;
			//int index = 0;


			////oganizing the binary
			//for (int i = 0; i < characters.Length; i++)
			//{
			//	if (counter == 8)
			//	{
			//		counter = 0;
			//		index++;
			//	}

			//	binaryCode[index] += characters[i];

			//	counter++;
			//}
			//organized binary turning into hex 
			//decimal[] hexDataA = new decimal[characters.Length / 8 + 1];
			//BigInteger[] hexDataB = new BigInteger[characters.Length / 8 + 1];

			encryption.HexDataA = new decimal[encryption.Characters.Length / 8 + 1];
			encryption.HexDataB = new BigInteger[encryption.Characters.Length / 8 + 1];

			//for (int i = 0; i < hexDataA.Length; i++)
			//{
			//	hexDataA[i] = Convert.ToInt32(binaryCode[i], 2);
			//	hexDataA[i] = Convert.ToDecimal(hexDataA[i]);

			//}

			encryption.HexDataA = encryption.HexDataASetUp(encryption.HexDataA, encryption.Binary);

			//int n2 = (int)returnN();
			////outputs hex value
			//Console.WriteLine("This is the original message: ");
			//for (int i = 0; i < hexDataA.Length; i++)
			//{
			//	Console.WriteLine(hexDataA[i]);

			//}
			////outputs encrypted message
			//Console.WriteLine();
			//Console.WriteLine("This is the Encrypted message: ");

			//BigInteger[] tempArray = new BigInteger[hexDataA.Length];
			//BigInteger c = 0;

			//for (int i = 0; i < hexDataA.Length; i++)
			//{
			//	c = encryptMessage(hexDataA[i], e, n2);

			//	tempArray[i] = c;

			//	Console.WriteLine(c);

			//}

			//int tempD = (int)d;
			////outputs decrypted message
			//Console.WriteLine("This is the Decrypted message: ");

			//for (int i = 0; i < hexDataA.Length; i++)
			//{
			//	decimal c1 = (decimal)c;

			//	int tempArrayI = (int)tempArray[i];

			//	BigInteger m = decryptMessage(tempArrayI, tempD, n2);

			//	tempArray[i] = m;

			//	Console.WriteLine(m);

			//}

			//Console.Write("This is the message converted to a word: ");
			//string word = " ";

			//for (int i = 0; i < hexDataA.Length; i++)
			//{
			//	int m1 = (int)tempArray[i];
			//	char t1 = Convert.ToChar(m1);
			//	word += t1.ToString();

			//}

			Console.WriteLine("stuff");

		}
	}
}