using System.Diagnostics;
using System.Threading;
using System;

namespace Task3
{
	class Program
	{
		private static readonly int limitProcess = 5;

		static void Main(string[] args)
		{			
			Thread.Sleep(TimerMS(3));

			StartNotepadProcess();
		}

		private static Process StartNotepadProcess()
		{
			return Process.Start("notepad.exe");
		}

		private static int TimerMS(int second)
		{
			return Math.Abs(1000 * second);
		}
	}
}

