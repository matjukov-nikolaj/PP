using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using lw04;

namespace lw04
{
	public partial class InputForm : Form
	{
		private readonly InputFormController controller;

		public InputForm(InputFormModel model)
		{
			InitializeComponent();

			controller = new InputFormController(model);
			SubscribeToEvents();
		}

		private void SubscribeToEvents()
		{
			controller.ListCreated += ShowTimeList;
			inputText.TextChanged += controller.OnInputFileNameChanged;
			outputText.TextChanged += controller.OnOutputFileNameChanged;
			iterationsText.TextChanged += controller.OnIterationsChanged;
			send.MouseClick += (sender, EventArgs) =>
			{
				if (inputText.Text.ToString() != "" && outputText.Text.ToString() != "" && iterationsText.Text.ToString() != "")
				{
					controller.OnGetResultButtonClicked(sender, EventArgs, asyncCheckBox.Checked);
				}
			}; ;
		}

		public void ShowTimeList(List<long> times, bool isAsync)
		{
			MessageBox.Show($"Work { (isAsync ? "async" : "sync") }:\n avg: { times.Sum(time => time) / times.Count }");

			timeList.Items.Clear();
			foreach (var item in times)
			{
				timeList.Items.Add(item.ToString());
			}
		}
	}
}
