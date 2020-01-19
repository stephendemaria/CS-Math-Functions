/* 
       Number to Byte Sequence
	  Author: Stephen DeMaria
	  email: stephendemaria@hotmail.com
 
	  This program takes an integer number and builds a sequence of bytes
	  that can be stored in a file in little or big endian byte order.
	  It includes the option to display the sequence of bytes to the console
	  in decimal or hexadecimal, delimited by the user's choice of a comma,
	  space and comma, or no delimiter at all.

 */

using System;

namespace convertDataType
{
	class numberToByteSequence
	{
		static void Main()
		{

			var test = new numberToByteSequence();
			int intToConvert = 59304;

			Console.WriteLine("Big Endian Byte Sequence");
			byte[] sampleByteSequence = test.intToByteSequence( intToConvert, 3, true );
			Console.Write( "{0} = ", intToConvert );
			test.displayByteSequence( sampleByteSequence, 2, 1, false );

			Console.WriteLine();
			Console.WriteLine("Little Endian Byte Sequence");
			sampleByteSequence = test.intToByteSequence(intToConvert, 3, false);
			Console.Write("{0} = ", intToConvert);
			test.displayByteSequence(sampleByteSequence, 2, 1, false);

		}

		/* intToByteSequence()
		 * bool endianness: denotes byte order
		    *  false = Little endian  (lowest order byte will be in array position 0)
		    *  true = Big endian    (highest order byte will be in array position 0)
		    *  
		 *  maxBytes = the maximum number of bytes that will be returned by the function.
		    *  If an insufficient number of bytes are specified, the program displays an error message to the console.
		 */
		public byte[] intToByteSequence( long i, int maxBytes, bool endianness )
		{

			byte[] outputByteSequence = new byte[maxBytes];
			int byteNumber = maxBytes - 1;
			int counter = 0;

			if (endianness == false)
			{

				counter = maxBytes - 1;

			}
			else if (endianness == true)
			{

				// do not change counter value in this case

			}

			int bytesNeeded = (int)Math.Ceiling(Math.Log(i, 256));

			if (bytesNeeded <= maxBytes)
			{

				// build outputByteSequence
				while ( (counter < maxBytes) & (counter > -1))
				{

					if (Math.Pow(256, byteNumber) > i)
					{

						outputByteSequence[counter] = 0;

					}
					else if (Math.Pow(256, byteNumber) <= i)
					{

						outputByteSequence[counter] = (byte)(i / Math.Pow(256, byteNumber));
						i -= (long)(Math.Pow(256, byteNumber) * outputByteSequence[counter]);

					}

					byteNumber--;

					if (endianness == true)
					{

						counter++;

					}
					else if (endianness == false)
					{

						counter--;

					}
					

				}

			}
			else
			{

				if (maxBytes == 1)
				{

					Console.WriteLine("ERROR: {0} can not be represented with {1} byte.", i, maxBytes);

				}
				else if (maxBytes != 1)
				{

					Console.WriteLine("ERROR: {0} can not be represented with {1} bytes.", i, maxBytes);

				}

			}

			return outputByteSequence;

		}  // end intToByteSequence()

		/* displayByteSequence()
		 * int type:
		    * 1 = decimal display
		    * 2 = hexadecimal display with 0x before each byte
		    * 3 = hexadecimal display with no 0x
		 * int delimiter
		    * 0 = no delimiter
		    * 1 = spaces and commas
		    * 2 = spaces only
		 * bool braces
		    * true = add opening { and closing } braces
		    * false = no braces
		 */
		public void displayByteSequence( Byte[] displayThisArray, int type, int delimiter, bool braces )
		{

			int counter = 0;

			if (braces == true)
			{

				Console.Write( "{ " );

			}

			while (counter < displayThisArray.Length)
			{

				if (type == 1)
				{

					Console.Write(displayThisArray[counter]);

				}
				else if (type == 2)
				{

					Console.Write($"0x{displayThisArray[counter],0:x}");

				}
				else if (type == 3)
				{

					Console.Write($"{displayThisArray[counter],0:x}");

				}		

				counter++;

				if ( counter != displayThisArray.Length )
				{

					if (delimiter == 0)
					{

						// do nothing; no delimiter

					}
					else if (delimiter == 1)
					{

						Console.Write(", ");

					}
					else if (delimiter == 2)
					{

						Console.Write(" ");

					}
					

				}

			}

			if (braces == true)
			{

				Console.Write(" }");

			}

			Console.WriteLine();

		}  // end displayByteSequence

	}
}
