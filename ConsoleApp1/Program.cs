using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
//			PoprawPlikCSV();
			Learn.InitiateLearn();
		}

		private static void PoprawPlikCSV()
		{
			var path = @"C:\dev\SauronTeam\ConsoleApp1\Data\DataForTest.csv";
			var lines = File.ReadAllLines(path);
			for (int x = 0; x < lines.Length; x++)
			{
				var tab = lines[x].Split(';').ToList();
				for (int i = 0; i < tab.Count; i++)
				{
					tab[i] = tab[i].Contains(",") ? tab[i].Replace(",", ".") : tab[i];
//					if(tab[i].Contains("."))
//						tab[i] = Convert.ToDecimal(tab[i].Replace(".", ",")).ToString("F").Replace(",", ".");
				}

				lines[x] = String.Join(";", tab);
			}

			File.WriteAllLines(path, lines);
		}
	}
}
