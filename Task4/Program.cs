using System;
using System.IO;


namespace Task4
{
	class Program
	{
		static void Main(string[] args)
		{
			var hdDirectoryInWhichToSearch = new DirectoryInfo(@"c:\");
			FileSystemInfo[] files = new FileSystemInfo[0];
			try
			{
				files = hdDirectoryInWhichToSearch.GetFileSystemInfos();
			}
			catch (Exception e)
			{
				Console.WriteLine($"ERROR: {e.Message}");
			}

			if (files.Length > 0)
			{
				PrintFilesInfoDirectory(files);
			}
		}

		private static void PrintFilesInfoDirectory(FileSystemInfo[] files)
		{
			foreach (var file in files)
			{
				Console.WriteLine($"{file.FullName} \n" +
								$"\tДата создания: {file.CreationTime} \n" +
								$"\tРасширение: {file.Extension} \n" +
								$"\tДата последнего открытия: {file.LastAccessTime} \n" +
								$"\tДата последнего изменения: {file.LastWriteTime} \n\n");
			}
		}
	}
}
