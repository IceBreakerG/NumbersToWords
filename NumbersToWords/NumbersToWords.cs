using System;
using System.Collections.Generic;
using System.Text;

namespace NumbersToWords
{
	public static class NumbersToWords
	{
		private static List<string> Numerals = new List<string>() { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
		private static List<string> Positions = new List<string>() { "Hundred", "Thousand", "Million", "Billion", "Trillion", "Quadrillion", "Quintillion", "Sextillion", "Septillion", "Octillion", "Nonillion", "Decillion" };
		private const string DoubleFixedPoint = "###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###,###.00";

		/// <summary>
		/// Converts a number into its gramatical representation.
		/// </summary>
		/// <param name="number">The number to convert.</param>
		/// <param name="includeDollarsAndCents">Set to true to include the word "Dollars and " and, if there are any, the cents (ie. 19/100) at the end of the string.</param>
		/// <returns>The gramatical representation of the specified number (ie. If 777, Seven Hundred Seventy Seven).</returns>
		public static string ConvertNumberToWords(string number, bool includeDollarsAndCents = false)
		{
			var sb = new StringBuilder();
			var DecimalValue = number.Split('.')[1];
			var DigitGroup = number.Remove(number.IndexOf('.')).Split(',');
			var DigitGroupLength = DigitGroup.Length;

			if (number == "0.00")
				return $"{GetNumeral(0)} Dollars";

			for (int index = 0; index < DigitGroupLength; ++index)
			{
				int Digit = int.Parse(DigitGroup[index]);
				int LeadingDigit = Digit / 100;     //ie. #__
				int DigitRemnant = Digit % 100;     //ie. _##

				if (LeadingDigit > 0 || DigitRemnant > 0)
				{
					if (Digit >= 100)
					{
						sb.Append($"{GetNumeral(LeadingDigit)} ");
						sb.Append($"{GetPosition(0)} ");

						if (DigitRemnant > 20)
						{
							int Tens = DigitRemnant / 10;   //ie. _#_
							int Ones = DigitRemnant % 10;   //ie. __#

							//The index for the numeral is 20 + the leading digit - 2 since the index for Twenty is 20, Thirty is 21, etc.
							sb.Append($"{GetNumeral(20 + (Tens - 2))} ");

							if (Ones > 0)
								sb.Append($"{GetNumeral(Ones)} ");
						}
						else
						{
							if (DigitRemnant > 0)
								sb.Append($"{GetNumeral(DigitRemnant)} ");
						}
					}
					else
					{
						if (DigitRemnant > 20)
						{
							int one = DigitRemnant / 10;
							int two = DigitRemnant % 10;

							//The index for the numeral is 20 + the leading digit - 2 since the index for Twenty is 20, Thirty is 21, etc.
							sb.Append($"{GetNumeral(20 + (one - 2))} ");

							if (two > 0)
								sb.Append($"{GetNumeral(two)} ");
						}
						else
						{
							if (DigitRemnant > 0)
								sb.Append($"{GetNumeral(DigitRemnant)} ");
						}
					}

					//Gets the Position of the number
					if (DigitGroupLength > 1 && DigitGroupLength - index > 1)
						sb.Append($"{GetPosition(DigitGroupLength - index)} ");
				}


				//Gets the decimals remaining if there are any
				if (DigitGroupLength - index == 1 && includeDollarsAndCents)
				{
					var Dollar = DigitGroup[0] == "1" ? "Dollar" : "Dollars";
					sb.Append($"{Dollar} and {DecimalValue}/{100} ");
				}
			}

			return sb.ToString();
		}

		/// <summary>
		/// Returns the position of the current index (ie. Hundred, Thousand, Million, etc).
		/// </summary>
		/// <param name="index">The current index of the position to get.</param>
		/// <returns>The position of the current index.</returns>
		private static string GetPosition(int index)
		{
			return (index == 0) ? Positions[index] : Positions[index - 1];
		}

		/// <summary>
		/// Returns the numeral name of the current number.
		/// </summary>
		/// <param name="number">The current number to retrieve the numeral name of.</param>
		/// <returns>The numeral name of the current number.</returns>
		private static string GetNumeral(int number)
		{
			return Numerals[number];
		}
	}
}