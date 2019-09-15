using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System;

namespace Task1
{
	class Program
	{
		private static readonly int limitProcess = 5;

		static void Main(string[] args)
		{
			var notepadsProcess = new List<Process>();
			for (var i = 0; i < limitProcess; i++)
			{
				notepadsProcess.Add(StartNotepadProcess());
			}

			if (notepadsProcess.Count == 0)
			{
				return;
			}

			Thread.Sleep(TimerMS());

			foreach (var notepadProcess in notepadsProcess)
			{
				CloseNotepad(notepadProcess);
			}
		}

		private static Process StartNotepadProcess()
		{
			return Process.Start("notepad.exe");
		}

		private static int TimerMS()
		{
			return 2000;
		}

		private static void CloseNotepad(Process processNotepad)
		{
			if (processNotepad == null || processNotepad.HasExited)
			{
				return;
			}

			processNotepad.CloseMainWindow();
		}
	}
}

