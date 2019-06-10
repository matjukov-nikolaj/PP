using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace lw04
{
	public sealed class InputFormController
	{
		private InputFormModel model;
		private int iter;

		public event Action<List<long>, bool> ListCreated;

		public InputFormController(InputFormModel data)
		{
			model = data;
		}

		public void OnIterationsChanged(object sender, EventArgs e)
		{
			var textBox = (TextBox)sender;
			if (textBox.TextLength != 0 && int.TryParse(textBox.Text, out var value))
			{
				iter = value;
			}
			else
			{
				textBox.Text = "0";
				iter = 0;
			}
		}

		public void OnInputFileNameChanged(object sender, EventArgs e)
		{
			var textBox = (TextBox)sender;
			model.inFileName = textBox.Text;
		}

		public void OnOutputFileNameChanged(object sender, EventArgs e)
		{
			var textBox = (TextBox)sender;
			model.outFileName = textBox.Text;
		}

		public async void OnGetResultButtonClicked(object sender, MouseEventArgs e, bool isAsync)
		{
			var iterationsTimeList = new List<long>();
			for (var i = 0; i < iter; ++i)
			{
				var timer = Stopwatch.StartNew();
				if (isAsync)
				{
					await model.WriteDataFromUrlAsync();
				}
				else
				{
					var thread = new Thread(model.WriteDataFromUrlSync);
					thread.Start();
					thread.Join();
				}
				
				timer.Stop();
				iterationsTimeList.Add(timer.ElapsedMilliseconds);
			}

			ListCreated?.Invoke(iterationsTimeList, isAsync);			
		}
	}
}
