using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NumbersToWords
{
	class Program
	{
		static void Main(string[] args)
		{
			bool Escape = false;
			string number = "";
			string main = "";
			decimal num = 0.00m;

			//Test loop to test the output of the NumbersToWords class
			while (main != "q" && main != "Q")
			{
				while (!Escape)
				{
					Console.Write("Enter the number you want to convert to words (or Press Q to quit): ");
					number = Console.ReadLine();

					if (number == "q" || number == "Q")
					{
						main = number;
						Escape = true;
					}
					else
					{
						Escape = decimal.TryParse(number, out num);

						Stopwatch sw = new Stopwatch();
						sw.Start();

						Console.WriteLine($"\n{NumbersToWords.ConvertNumberToWords(num.ToString("N2"))}\n");

						sw.Stop();

						Console.WriteLine($"Total Time: {sw.Elapsed.ToString()}");
					}
				}

				Escape = false;
			}

			/*
			 * Examples of different numbers.  Uncomment these if you would like to run them to test the output.
			 */
			//decimal n1 = 8000000.00m;
			//decimal n2 = 78965.00m;
			//decimal n3 = 147852.00m;
			//decimal n4 = 789654123369.00m;
			//decimal n5 = 4862159732587439.00m;
			//decimal n6 = 1478523698574456788491.00m;
			//decimal n7 = 2369857418959498984651546.00m;
			//decimal n8 = 1472369857418959498984651546.00m;
			//decimal n9 = 19956782369857418959498984651.00m;
			//decimal n10 = 2369857418959498984651546.00m;
			//decimal n11 = 79228162514264337593543950335.00m;

			//Console.WriteLine($"\n{ConvertNumberToWords(num.ToString("N2"))}\n");
			//Console.WriteLine($"\n{ConvertNumberToWords(n1.ToString("N2"))}\n");
			//Console.WriteLine($"\n{ConvertNumberToWords(n2.ToString("N2"))}\n");
			//Console.WriteLine($"\n{ConvertNumberToWords(n3.ToString("N2"))}\n");
			//Console.WriteLine($"\n{ConvertNumberToWords(n4.ToString("N2"))}\n");
			//Console.WriteLine($"\n{ConvertNumberToWords(n5.ToString("N2"))}\n");
			//Console.WriteLine($"\n{ConvertNumberToWords(n6.ToString("N2"))}\n");
			//Console.WriteLine($"\n{ConvertNumberToWords(n7.ToString("N2"))}\n");
			//Console.WriteLine($"\n{ConvertNumberToWords(n8.ToString("N2"))}\n");
			//Console.WriteLine($"\n{ConvertNumberToWords(n9.ToString("N2"))}\n");
			//Console.WriteLine($"\n{ConvertNumberToWords(n10.ToString("N2"))}\n");
			//Console.WriteLine($"\n{ConvertNumberToWords(n11.ToString("N2"))}\n");

			Console.Write("Press any key to continue");
			Console.ReadKey();
		}
	}
}