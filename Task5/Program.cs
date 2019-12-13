using System;
using System.IO;
using System.Threading;


namespace Task5
{
	class Program
	{
		const int timeInteval = 5000;


		static void Main()
		{
			var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var filename = "log.txt";
			var timerInterval = GetCurrectUnixTime();

			ClearLogFile(docPath, filename);

			while (true)
			{
				using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, filename), true))
				{
					outputFile.WriteLine($"{GetCurrectUnixTime()}\n");
				}

				if (GetCurrectUnixTime() > timerInterval + timeInteval)
				{
					timerInterval = GetCurrectUnixTime() + timeInteval;
					File.Move($"{docPath}/{filename}", ($"{docPath}/archives/{GetFormatNameLogFileArchive()}_{filename}"));
					ClearLogFile(docPath, filename);
				}

				Console.WriteLine($"{GetCurrectUnixTime()} {timerInterval + timeInteval}");

				Thread.Sleep(1000);
			}
		}

		private static long GetCurrectUnixTime()
		{
			return ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeMilliseconds();
		}

		private static string GetFormatNameLogFileArchive()
		{
			var time = DateTime.Now;
			string formattedTime = time.ToString("dd_MM_yyyy_hh_mm_ss");

			return formattedTime;
		}

		private static void ClearLogFile(string docPath, string filename)
		{
			using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, filename)))
			{
				outputFile.Write("");
			}
		}
	}
}
