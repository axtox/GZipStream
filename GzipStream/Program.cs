﻿using System;
using System.Diagnostics;
using System.IO;

namespace GzipStreamDemo
{
	class Program
	{
		static int Main(string[] args)
		{
			Stopwatch sw = new Stopwatch();
			if (args.Length == 3)
			{
				try
				{
					Console.Clear();
					Console.WriteLine("\nConverting...\n\npress CTRL + C to cancel");
					sw.Start();
					var processThread = new ThreadProcessClass(args);
					sw.Stop();
					if (Constants.Aborted)
					{
						Console.WriteLine("\n\nPROCESS ABORTED!\n");
						Constants.ReturnValue = 1;
					}
					else { Console.WriteLine("\n\nDONE!\n"); Constants.ReturnValue = 0; }

					Console.WriteLine("ELAPSED TIME: {1} ms ({0:F} min)", (double)(sw.Elapsed.TotalMilliseconds / 60000), sw.ElapsedMilliseconds);
					return Constants.ReturnValue;
				}
				catch (WrongCommandException wae) { Console.WriteLine(wae); return 1; }
				catch (FileNotFoundException fnfe) { Console.WriteLine(fnfe.Message); return 1; }
				catch (IOException ioe) { Console.WriteLine(ioe.Message); return 1; }
				catch (Exception e) { Console.WriteLine(e.Message); return 1; }

			}
			else
			{
				Console.WriteLine("\nWrong number of input arguments!\n---------------\n" +
							"Usage example: \n\t(*) compress [FILE_PATH] [ZIP_PATH]\n\t(*)" +
							" decompress [ZIP_PATH] [FILE_PATH]");
				return 1;
			}
		}
	}
}
