namespace lw04
{
	partial class InputForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.iterationsText = new System.Windows.Forms.TextBox();
			this.asyncCheckBox = new System.Windows.Forms.CheckBox();
			this.iterLabel = new System.Windows.Forms.Label();
			this.outLabel = new System.Windows.Forms.Label();
			this.outputText = new System.Windows.Forms.TextBox();
			this.inLabel = new System.Windows.Forms.Label();
			this.inputText = new System.Windows.Forms.TextBox();
			this.send = new System.Windows.Forms.Button();
			this.timeList = new System.Windows.Forms.ListBox();
			this.timeLabel = new System.Windows.Forms.Label();

			this.SuspendLayout();
			
			// 
			// inLabel
			// 
			this.inLabel.AutoSize = true;
			this.inLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.inLabel.Location = new System.Drawing.Point(10, 10);
			this.inLabel.Name = "inLabel";
			this.inLabel.Size = new System.Drawing.Size(150, 30);
			this.inLabel.Text = "Input file name";
			// 
			// inputText
			// 
			this.inputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.inputText.Location = new System.Drawing.Point(210, 10);
			this.inputText.Name = "inputText";
			this.inputText.Size = new System.Drawing.Size(350, 30);
			// 
			// outLabel
			// 
			this.outLabel.AutoSize = true;
			this.outLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.outLabel.Location = new System.Drawing.Point(10, 60);
			this.outLabel.Name = "outLabel";
			this.outLabel.Size = new System.Drawing.Size(150, 30);
			this.outLabel.Text = "Output file name";
			// 
			// outputText
			// 
			this.outputText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.outputText.Location = new System.Drawing.Point(210, 60);
			this.outputText.Name = "outputText";
			this.outputText.Size = new System.Drawing.Size(350, 30);
			// 
			// iterLabel
			// 
			this.iterLabel.AutoSize = true;
			this.iterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.iterLabel.Location = new System.Drawing.Point(10, 110);
			this.iterLabel.Name = "iterLabel";
			this.iterLabel.Size = new System.Drawing.Size(150, 30);
			this.iterLabel.Text = "Iterations";
			// 
			// iterationsText
			// 
			this.iterationsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.iterationsText.Location = new System.Drawing.Point(210, 110);
			this.iterationsText.Name = "iterationsText";
			this.iterationsText.Size = new System.Drawing.Size(350, 30);
			// 
			// asyncCheckBox
			// 
			this.asyncCheckBox.AutoSize = true;
			this.asyncCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.asyncCheckBox.Location = new System.Drawing.Point(310, 150);
			this.asyncCheckBox.Name = "asyncCheckBox";
			this.asyncCheckBox.Size = new System.Drawing.Size(100, 40);
			this.asyncCheckBox.Text = "async";
			this.asyncCheckBox.UseVisualStyleBackColor = true;
			
			// 
			// timeLabel
			// 
			this.timeLabel.AutoSize = true;
			this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.timeLabel.Location = new System.Drawing.Point(10, 200);
			this.timeLabel.Name = "timeLabel";
			this.timeLabel.Size = new System.Drawing.Size(150, 30);
			this.timeLabel.TabIndex = 13;
			this.timeLabel.Text = "Time";
			
			// 
			// timeList
			// 
			this.timeList.FormattingEnabled = true;
			this.timeList.ItemHeight = 16;
			this.timeList.Location = new System.Drawing.Point(210, 200);
			this.timeList.Name = "timeList";
			this.timeList.Size = new System.Drawing.Size(350, 150);
			
			// 
			// send
			// 
			this.send.Location = new System.Drawing.Point(210, 370);
			this.send.Name = "send";
			this.send.Size = new System.Drawing.Size(200, 50);
			this.send.Text = "Send";
			this.send.UseVisualStyleBackColor = true;

			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ClientSize = new System.Drawing.Size(600, 450);
			
			this.Controls.Add(this.inLabel);
			this.Controls.Add(this.inputText);
			this.Controls.Add(this.outLabel);
			this.Controls.Add(this.outputText);
			this.Controls.Add(this.iterLabel);
			this.Controls.Add(this.iterationsText);
			this.Controls.Add(this.asyncCheckBox);
			this.Controls.Add(this.timeLabel);
			this.Controls.Add(this.timeList);		
			this.Controls.Add(this.send);
			
			this.Name = "InputForm";
			this.Text = "lw04";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox asyncCheckBox;
		private System.Windows.Forms.Label iterLabel;
		private System.Windows.Forms.Label outLabel;
		private System.Windows.Forms.TextBox outputText;
		private System.Windows.Forms.Label inLabel;
		private System.Windows.Forms.TextBox inputText;
		private System.Windows.Forms.Button send;
		private System.Windows.Forms.TextBox iterationsText;
		private System.Windows.Forms.ListBox timeList;
		private System.Windows.Forms.Label timeLabel;
	}
}