﻿using System;
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
			day1p1();
			Console.ReadLine();
		}

		public static void day1p1()
		{
			string[] lines = File.ReadAllLines("day1.txt");
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
	}
}