namespace W3_Item_Editor
{
	public static class Prompt
	{
		public static string ShowDialog(string text, string caption = "Input")
		{
			Form prompt = new Form()
			{
				Width = 500,
				Height = 150,
				FormBorderStyle = FormBorderStyle.FixedDialog,
				Text = caption,
				StartPosition = FormStartPosition.CenterScreen
			};

			Label textLabel = new Label() { Left = 10, Top = 10, Width = 460, Text = text };
			TextBox textBox = new TextBox() { Left = 10, Top = 40, Width = 460 };
			Button confirmation = new Button() { Text = "Save", Left = 10, Width = 100, Top = 80, DialogResult = DialogResult.OK };
			Button cancel = new Button() { Text = "Cancel", Left = 120, Width = 100, Top = 80, DialogResult = DialogResult.Cancel };

			confirmation.Click += (sender, e) => { prompt.Close(); };
			cancel.Click += (sender, e) => { prompt.Close(); };

			prompt.Controls.Add(textBox);
			prompt.Controls.Add(confirmation);
			prompt.Controls.Add(cancel);
			prompt.Controls.Add(textLabel);
			prompt.AcceptButton = confirmation;

			return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
		}

		public static string EditAttribute(string attribute, string value) => ShowDialog($"Editing: [{attribute}] current value: {value}", "Edit Attribute");
	}
}