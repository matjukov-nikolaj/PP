using System;
using System.Windows.Forms;

namespace lw04
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				InputFormModel model = new InputFormModel();
				Application.Run(new InputForm(model));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
