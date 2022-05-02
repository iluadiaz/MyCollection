using System;
using System.IO;
using LinkedQueue;
using QueuedInterface;

namespace HW2
{
	 public class Program
    {
         private static void printUsage()
        {
            Console.WriteLine("Usage is:\n" + 
			"\tjava Main C inputfile outputfile\n\n" +
			"Where:" + 
			"  C is the column number to fit to\n" +
			"  inputfile is the input text file \n" +
			"  outputfile is the new output file base name containing the wrapped text.\n" +
			"e.g. java Main 72 myfile.txt myfile_wrapped.txt");
        }
          public static void Main(string[] args)
        {
                  int c = 72;
                  string inputFileName = "";
                  string outPutFileName = "output.txt";                  

                  if(args.Length != 4)
                  {
                      printUsage();
                      Environment.Exit(1);
                  }
                  try
                  {
				   c = Convert.ToInt32(args[1]);
                   inputFileName = args[2];
                   outPutFileName = args[3];
                  }
                  catch(FileNotFoundException)
                {
                    Console.WriteLine("Could not find the input file.");
			        Environment.Exit(1);
                }
                  catch(Exception)
		{
			Console.WriteLine("Something is wrong with the input.");
			printUsage();
            Environment.Exit(1);
		}	
        // Read words and their lengths into these vectors
    QueueInterface<String> words = new LinkedQueue<String>();

            //Read input file, tokenize by whitespace
			using(StreamReader reader = new StreamReader(inputFileName))
			{
				string word;
            while((word = reader.ReadLine()) != null)
            {	
				words.push( word);
            }
			}
            // At this point the input text file has now been placed, word by word, into a FIFO queue
            // Each word does not have whitespaces included, but does have punctuation, numbers, etc.
            //* ------------------ Start here ---------------------- *//
            // As an example, do a simple wrap

        int spacesRemaining = wrapSimply(words, c, outPutFileName);
		Console.WriteLine("Total spaces remaining (Greedy): " + spacesRemaining );
		
	 } // End main()
	
	// /*-----------------------------------------------------------------------
	// 	Greedy Algorithm (Non-optimal i.e. approximate or heuristic solution)
	//   -----------------------------------------------------------------------*/
	
	// /**
	// 	As an example only, write out the file directly to the output with _simple_ wrapping,
	// 	i.e. adding spaces between words and moving to the next line if a word would go past the
	// 	indicated column number C.  This will fail if any word length exceeds the column limit C,
	// 	but it still goes ahead and just puts one word on that line.
	// */

	 private static int wrapSimply( QueueInterface<String> words, int columnLength, String outputFilename )
	 {
         StreamWriter writeFile;
	 	 try
	 	 {
            writeFile = new StreamWriter(outputFilename);
			writeFile.Flush();
			writeFile.Close();
			GC.Collect();
	 	}
             catch( FileNotFoundException)
	 	{
	 		 Console.WriteLine("Cannot create or open " + outputFilename +
	 					" for writing.  Using standard output instead." );

	 	}
		 	 	int col = 1;
	 	int spacesRemaining = 0;// Running count of spaces left at the end of lines
		using(FileStream file = new FileStream(outputFilename, FileMode.OpenOrCreate, FileAccess.Write)) 
		using(writeFile = new StreamWriter(file))//(new  File.Open(outputFilename, FileMode.Append, FileAccess.Write, FileShare.Read)))
		{
	 	while( !words.isEmpty())
	 	{
            string str = words.peek();
	 		int len = str.Length;
	 		// See if we need to wrap to the next line
	 		if( col == 1 )
	 		{
                writeFile.WriteLine(str);
                col += len;
	 			words.pop();
	 		}
	 		else if( (col + len) >= columnLength )
	 		{
	 			// go to the next line
                writeFile.WriteLine();
	 			spacesRemaining += ( columnLength - col ) + 1;
	 			col = 1;
	 		}
	 		else
	 		{	
                 // Typical case of printing the next word on the same line
	 			writeFile.Write(" ");
                writeFile.WriteLine(str);
	 			col += (len + 1);
	 			words.pop();
			 }
         } 
		 }
	 	writeFile.Close();
	 	return spacesRemaining;
	 } // end wrapSimply
} // End class Main
}
