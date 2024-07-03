namespace W3_Item_Editor
{
	public static class Prompt
	{
		// TO DO: Refactor This sh**t
		// Try to merge both function int more generic one.

		public static string EditAttribute(string attribute, string value)
		{
			Form prompt = new Form()
			{
				Width = 335,
				Height = 140,
				FormBorderStyle = FormBorderStyle.FixedDialog,
				Text = "Edit Attribute",
				StartPosition = FormStartPosition.CenterScreen
			};

			Label textLabel = new Label() { Left = 10, Top = 10, Width = 300, Text = $"Editing: [{attribute}] current value: {value}" };
			TextBox inputBox = new TextBox() { Left = 10, Top = 35, Width = 300 };
			Button confirmation = new Button() { Text = "Save", Left = 10, Width = 100, Top = 70, DialogResult = DialogResult.OK };
			Button cancelation = new Button() { Text = "Cancel", Left = 115, Width = 100, Top = 70, DialogResult = DialogResult.OK };

			confirmation.Click += (sender, e) => { prompt.Close(); };

			prompt.Controls.Add(textLabel);
			prompt.Controls.Add(inputBox);
			prompt.Controls.Add(confirmation);
			prompt.Controls.Add(cancelation);
			prompt.AcceptButton = confirmation;
			prompt.CancelButton = cancelation;

			return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
		}

		public static string ShowDialog(string caption)
		{
			Form prompt = new Form()
			{
				Width = 285,
				Height = 130,
				FormBorderStyle = FormBorderStyle.FixedDialog,
				Text = caption,
				StartPosition = FormStartPosition.CenterScreen
			};

			Label textLabel = new Label() { Left = 10, Top = 10, Width = 250, Text = caption };
			TextBox textBox = new TextBox() { Left = 10, Top = 30, Width = 250 };
			Button confirmation = new Button() { Text = "Ok", Left = 85, Width = 100, Top = 65, DialogResult = DialogResult.OK };

			confirmation.Click += (sender, e) => { prompt.Close(); };

			prompt.Controls.Add(textBox);
			prompt.Controls.Add(confirmation);
			prompt.Controls.Add(textLabel);
			prompt.AcceptButton = confirmation;

			return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
		}
	}
}