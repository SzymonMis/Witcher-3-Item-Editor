namespace W3_Item_Editor
{
	partial class MainForm
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
			splitContainer1 = new SplitContainer();
			itemsView = new TreeView();
			buttonAdd = new Button();
			buttonRemove = new Button();
			buttonEdit = new Button();
			labelElementName = new Label();
			listBox = new ListBox();
			textBox1 = new TextBox();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.IsSplitterFixed = true;
			splitContainer1.Location = new Point(0, 0);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.BackColor = Color.FromArgb(64, 64, 64);
			splitContainer1.Panel1.Controls.Add(itemsView);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.BackColor = Color.FromArgb(64, 64, 64);
			splitContainer1.Panel2.Controls.Add(buttonAdd);
			splitContainer1.Panel2.Controls.Add(buttonRemove);
			splitContainer1.Panel2.Controls.Add(buttonEdit);
			splitContainer1.Panel2.Controls.Add(labelElementName);
			splitContainer1.Panel2.Controls.Add(listBox);
			splitContainer1.Panel2.Controls.Add(textBox1);
			splitContainer1.Size = new Size(1243, 602);
			splitContainer1.SplitterDistance = 410;
			splitContainer1.TabIndex = 0;
			// 
			// itemsView
			// 
			itemsView.BackColor = SystemColors.WindowFrame;
			itemsView.Dock = DockStyle.Fill;
			itemsView.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			itemsView.ForeColor = SystemColors.Window;
			itemsView.Location = new Point(0, 0);
			itemsView.Name = "itemsView";
			itemsView.Size = new Size(410, 602);
			itemsView.TabIndex = 0;
			// 
			// buttonAdd
			// 
			buttonAdd.Location = new Point(8, 533);
			buttonAdd.Name = "buttonAdd";
			buttonAdd.Size = new Size(108, 23);
			buttonAdd.TabIndex = 6;
			buttonAdd.Text = "Add Attribute";
			buttonAdd.UseVisualStyleBackColor = true;
			// 
			// buttonRemove
			// 
			buttonRemove.Location = new Point(119, 533);
			buttonRemove.Name = "buttonRemove";
			buttonRemove.Size = new Size(108, 23);
			buttonRemove.TabIndex = 5;
			buttonRemove.Text = "Remove Attribute";
			buttonRemove.UseVisualStyleBackColor = true;
			// 
			// buttonEdit
			// 
			buttonEdit.Location = new Point(233, 533);
			buttonEdit.Name = "buttonEdit";
			buttonEdit.Size = new Size(108, 23);
			buttonEdit.TabIndex = 4;
			buttonEdit.Text = "Edit Attribute";
			buttonEdit.UseVisualStyleBackColor = true;
			// 
			// labelElementName
			// 
			labelElementName.AutoSize = true;
			labelElementName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			labelElementName.ForeColor = SystemColors.ButtonHighlight;
			labelElementName.Location = new Point(8, 17);
			labelElementName.Name = "labelElementName";
			labelElementName.Size = new Size(92, 15);
			labelElementName.TabIndex = 3;
			labelElementName.Text = "Element Name:";
			// 
			// listBox
			// 
			listBox.BackColor = SystemColors.ControlDarkDark;
			listBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			listBox.ForeColor = SystemColors.Window;
			listBox.FormattingEnabled = true;
			listBox.ItemHeight = 15;
			listBox.Location = new Point(8, 43);
			listBox.Name = "listBox";
			listBox.Size = new Size(808, 484);
			listBox.TabIndex = 1;
			// 
			// textBox1
			// 
			textBox1.BackColor = SystemColors.ControlDarkDark;
			textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
			textBox1.ForeColor = SystemColors.Window;
			textBox1.Location = new Point(119, 14);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(697, 23);
			textBox1.TabIndex = 0;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlDarkDark;
			ClientSize = new Size(1243, 602);
			Controls.Add(splitContainer1);
			MaximizeBox = false;
			MaximumSize = new Size(1259, 641);
			MinimumSize = new Size(1259, 641);
			Name = "MainForm";
			Text = "Witcher 3 [Item Editor]";
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView itemsView;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ListBox listBox;
		private Label labelElementName;
		private Button buttonRemove;
		private Button buttonEdit;
		private Button buttonAdd;
	}
}
