using System;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MyForm());
		}
	}
}
