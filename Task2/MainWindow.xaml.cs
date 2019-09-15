using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Threading;

namespace Task2
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private async Task UpdateTasksAsync()
		{
			var index = 1;
			while (true)
			{
				await Task.Delay(index + 500);

				index++;

				ListBoxProcess.Items.Clear();

				var procList = Process.GetProcesses();
				List<Process> SortedList = procList.OrderBy(o => o.ProcessName).ToList();
				foreach (var process in SortedList)
				{
					ListBoxProcess.Items.Add($"{process.ProcessName} {process.Id} {process.PeakWorkingSet64}");
				}
			}
		}

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;

			UpdateTasksAsync();
		}
	}
}
