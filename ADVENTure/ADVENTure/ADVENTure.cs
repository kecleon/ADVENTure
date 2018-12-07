using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADVENTure
{
	public class ADVENTure
	{
		public static void Main(string[] args)
		{
			day2p1();
			Console.ReadLine();
		}

		public static void day1p1()
		{
			string[] lines = File.ReadAllLines("input/day1.txt");
			int runningCount = 0;
			foreach (string line in lines)
			{
				if (line.Length == 1) { continue; }

				if (line.StartsWith("+"))
				{
					int addAmount = 0;
					if (int.TryParse(line.Substring(1), out addAmount))
					{
						runningCount += addAmount;
					}
					else
					{
						Console.WriteLine("Failed to parse: " + line);
					}
				}
				else if (line.StartsWith("-"))
				{
					int subAmount = 0;
					if (int.TryParse(line.Substring(1), out subAmount))
					{
						runningCount -= subAmount;
					}
					else
					{
						Console.WriteLine("Failed to parse: " + line);
					}
				}
				else
				{
					Console.WriteLine("WTF BOOM: " + line);
				}
			}
			Console.WriteLine("Result: " + runningCount);
		}

		public static void day1p2()
		{
			string[] lines = File.ReadAllLines("input/day1.txt");
			int runningCount = 0;
			List<int> list = new List<int>();
			bool duplicateFound = false;
			do
			{
				foreach (string line in lines)
				{
					if (line.Length == 1) { continue; }

					if (line.StartsWith("+"))
					{
						int addAmount = 0;
						if (int.TryParse(line.Substring(1), out addAmount))
						{
							runningCount += addAmount;
						}
						else
						{
							Console.WriteLine("Failed to parse: " + line);
						}
					}
					else if (line.StartsWith("-"))
					{
						int subAmount = 0;
						if (int.TryParse(line.Substring(1), out subAmount))
						{
							runningCount -= subAmount;
						}
						else
						{
							Console.WriteLine("Failed to parse: " + line);
						}
					}
					else
					{
						Console.WriteLine("WTF BOOM:" + line);
					}

					if (list.Contains(runningCount))
					{
						Console.WriteLine($"First repeat: {runningCount},");
						duplicateFound = true;
						break;
					}
					list.Add(runningCount);
				}
				//Console.WriteLine("Result: " + runningCount);
			} while (!duplicateFound);
		}

		public static void day2p1()
		{
			string[] lines = File.ReadAllLines("input/day2.txt");
			long checksum = 0;

			List<Dictionary<char, int>> LineCharCountList = new List<Dictionary<char, int>>();
			foreach (string line in lines)
			{
				Dictionary<char, int> CharCount = new Dictionary<char, int>();

				foreach (char c in line)
				{
					if (CharCount.ContainsKey(c))
					{
						CharCount[c]++;
					}
					else
					{
						CharCount.Add(c, 1);
					}
					//Console.Write(CharCount[c]);
				}

				//Console.WriteLine("");
				LineCharCountList.Add(CharCount);
			}

			Dictionary<int, int> Repeats = new Dictionary<int, int>();

			int twos = 0;
			int threes = 0;

			foreach (Dictionary<char, int> count in LineCharCountList)
			{
				int localtwos = 0;
				int localthrees = 0;

				foreach (KeyValuePair<char, int> entry in count)
				{
					if (entry.Value == 2)
					{
						localtwos++;
					}
					else if (entry.Value == 3)
					{
						localthrees++;
					}
				}
				//Console.WriteLine($"Twos: {localtwos}, Threes: {localthrees}");

				if (localtwos > 0)
				{
					twos++;
				}
				if (localthrees > 0)
				{
					threes++;
				}
			}

			checksum = twos * threes;
			Console.WriteLine($"ALL Twos: {twos}, Threes: {threes}");
			Console.WriteLine("Result: " + checksum);
		}
	}
}
