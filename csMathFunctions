/* 
       Computer Science Math Functions
	  Author: Stephen DeMaria
	  email: stephendemaria@hotmail.com
 
	  This program includes CS math functions for data manipulation.  Using 
	  the function, changeOfBase(), numerical data, represented as a string,
	  can be converted from any base to any base between 2 and 36.

	  This program also has the capability of taking an an integer number
	  and building a sequence of bytes that can be stored in little or big
	  endian byte order.  Using displayByteSequence(), you have the option
	  to display a byte sequence to the console in decimal or hexadecimal,
	  delimited by the user's choice of a comma, space and comma, or no
	  delimiter at all.

 */

using System;
using System.Text;

namespace CSMathFunctions
{
	class DataManipulation
	{
		static void Main()
		{

			var test = new DataManipulation();
			int intToConvert = 59304;

			// test 1
			Console.WriteLine("Big Endian Byte Sequence");
			byte[] sampleByteSequence = test.intToByteSequence( intToConvert, 3, true );
			Console.Write( "{0} = ", intToConvert );
			test.displayByteSequence( sampleByteSequence, 2, 1, false );

			// test 2
			Console.WriteLine();
			Console.WriteLine("Little Endian Byte Sequence");
			sampleByteSequence = test.intToByteSequence(intToConvert, 3, false);
			Console.Write("{0} = ", intToConvert);
			test.displayByteSequence(sampleByteSequence, 2, 1, false);

			// test 3
			Console.WriteLine();
			Console.WriteLine( "Convert Hexadecimal Digit Expressed as Unicode String to Decimal Digit" );
			byte testInput = 97;
			int testOutput = test.baseXtoBaseTen(testInput);
			Console.WriteLine("Decimal Code Value {1} = {0}", testOutput, testInput );

			// test 4
			Console.WriteLine();
			string input = "010100100010101010";
			int inputBase = 2;
			int outputBase = 16;
			Console.WriteLine("Convert the base-{1} string, {0}, to a base-{2} value.", input, inputBase, outputBase );
			string output = test.changeOfBase( inputBase, outputBase, input);
			Console.WriteLine( "{1} base-{0} = {3} base-{2}", inputBase, input, outputBase, output );

		}  // end main

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



		/* This function takes a digit in base-x, baseXdigit, and converts it to
		 * a number in base-10, decimal.
		 * 
		 * Valid bases are between base-2, binary, and base-36.  Hexadecimal uses
		 * digits which range from 0 to f, inclusive, where 0-9 represent the first
		 * ten digits and a-f represent the digits 11-16.  Likewise, the digits a-z
		 * denote the digits 11-36 in a base-36 number system.
		 * 
		 * baseXdigit accepts unicode ascii values between 48-57, inclusive, and 97-123,
		 * inclusive, to denote a digit in up to a base-36 number system.  This
		 * function outputs -1 and an error message if baseXdigit does not fall
		 * within the valid range.
		 */
		byte[] code = { 48, 49, 50, 51, 52, 53, 54, 55, 56, 57,
				  97, 98, 99, 100, 101, 102, 103, 104, 105,
				  106, 107, 108, 109, 110, 111, 112, 113,
				  114, 115, 116, 117, 118, 119, 120, 121,
				  122, 123 };
		public int baseXtoBaseTen( byte baseXdigit )
		{

			int index = -1;

			// is baseXinput between 48 and 57, inclusive?
			bool between48and57 = (baseXdigit >= 48) & (baseXdigit <= 57);

			// is baseXinput between 97 and 123 inclusive?
			bool between97and123 = (baseXdigit >= 97) & (baseXdigit <= 123);

			// validate that baseXinput is within a valid range
			if ( between48and57 ^ between97and123)
			{

				// search for number in array and return index
				index = Array.IndexOf(code, baseXdigit);

			}
			else
			{

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("ERROR: input is not within the valid range of 48-123.");
				Console.ResetColor();

			}

			return index;

		}
		/* This funtion takes a decimal digit, 0-9, and transforms it to a unicode character
		 * so that it can be put back in a string.
		 */
		public byte base10toBasex( int base10digit )
		{

			return code[base10digit];

		}

		/* This function changes the base of a number from base x (frombase)
		 * to base-y (toBase)
		 * 
		 * Valid bases are between base-2, binary, and base-36.
		 * */
		public string changeOfBase(int fromBase, int toBase, string input)
		{

			int remainder;
			int placeValue = input.Length - 1;
			int decimalValue = 0;
			var inputByteSequence = new byte[input.Length];
			string outputString;

			// convert string to a byte sequence for further processing
			inputByteSequence = Encoding.ASCII.GetBytes( input );
			int counter = 0;   // change endianness of inputByteSequence somehow to get rid of this and counter++ in loop

			// check that inputByteSequence contains only valid values between 0 and fromBase
			int inputValidatorCounter = 0;
			bool greaterThanOrEqualToZero;
			bool lessThanFromBase;
			bool validByteSequence = true;  // true until proven false
			while ( inputValidatorCounter < input.Length )
			{

				greaterThanOrEqualToZero = baseXtoBaseTen(inputByteSequence[inputValidatorCounter]) >= 0;
				lessThanFromBase = baseXtoBaseTen(inputByteSequence[inputValidatorCounter]) < fromBase;
				validByteSequence = greaterThanOrEqualToZero & lessThanFromBase;

				// detect invalid value
				if (validByteSequence != true )
				{

					Console.WriteLine();
					Console.ForegroundColor = ConsoleColor.Red;
					char c = (char)inputByteSequence[inputValidatorCounter];
					char maxFromBaseRange = (char)base10toBasex(fromBase - 1);
					Console.WriteLine("ERROR: Invalid value found in input string: {0}", c );
					Console.WriteLine( "{0} is not in the base-{1} range of 0-{2}", c, fromBase, maxFromBaseRange );
					Console.WriteLine( "All values higher than {0}, must be removed from input string.", maxFromBaseRange );
					Console.WriteLine();
					Console.ResetColor();

					// break the loop
					inputValidatorCounter = input.Length;

				}

				inputValidatorCounter++;

			}

			// validate fromBase and toBase to include values from 2-36
			bool fromBaseBetween2and36 = ( fromBase >= 2 ) & ( fromBase <= 36 );
			bool toBaseBetween2and36 = ( toBase >= 2 ) & ( toBase <= 36 );

			if (fromBaseBetween2and36 & toBaseBetween2and36 & validByteSequence)
			{

				// convert input to decimal
				while (placeValue != -1)
				{

					decimalValue += (int)(Math.Pow(fromBase, placeValue)) * baseXtoBaseTen(inputByteSequence[counter]);
					placeValue--;
					counter++;

				}

				// if toBase is decimal, then we need no further processing to convert it to another base
				if (toBase != 10)
				{

					// calculate the number of digits needed for outputByteSequence
					// a number has n digits in base-x how many digits will it have in base-y in the worst case?
					// log sub(base-y)( (base-x)^n )
					// in the case that this log yeilds a decimal, use the ceiling function to go to the next highest integer
					double base_x = (double)fromBase;
					double base_y = (double)toBase;
					double n = (double)input.Length;
					int digitsInBaseY = (int)Math.Ceiling( Math.Log(Math.Pow(base_x, n), base_y) );

					// change the size of outputByteSequence array based on the number of digits it may require
					var outputByteSequence = new byte[digitsInBaseY];

					placeValue = 0;

					while (decimalValue != 0)
					{

						remainder = decimalValue % toBase;
						outputByteSequence[placeValue] = base10toBasex(remainder);
						decimalValue = decimalValue / toBase;
						placeValue++;

					}

					Array.Reverse(outputByteSequence);
					outputString = Encoding.ASCII.GetString(outputByteSequence);

				}
				else
				{

					outputString = decimalValue.ToString();

				}

			}
			else
			{

				Console.ForegroundColor = ConsoleColor.Red;
				if (fromBaseBetween2and36 == false )
				{

					Console.WriteLine( "ERROR: fromBase and toBase must be within the range 2 and 36, inclusive." );
					Console.WriteLine( "ERROR: fromBase is set to: {0}", fromBase );

				}

				if ( toBaseBetween2and36 == false )
				{

					Console.WriteLine("ERROR: fromBase and toBase must be within the range 2 and 36, inclusive.");
					Console.WriteLine("ERROR: toBase is set to: {0}", toBase);

				}

				Console.ResetColor();

				outputString = "ERROR";

			}

			return outputString;

		}  // end changeOfBase()

	}  // end class numberToByteSequence

}  // end namespace convertDataType
