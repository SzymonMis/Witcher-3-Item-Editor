using System.Text;
using System.Xml;

namespace W3_Item_Editor
{
	public partial class MainForm : Form
	{
		private XmlDocument xmlToEdit;

		public MainForm()
		{
			InitializeComponent();
			InitializeCustomComponents();
		}

		private void InitializeCustomComponents()
		{
			// TO DO: Refactor This sh*t
			// Some work need to make this window scale properly.
			// Simplify this ugly bastard

			// Menu Bar
			var menuStrip = new MenuStrip();
			var fileMenu = new ToolStripMenuItem("File");
			var openFile = new ToolStripMenuItem("Open");
			var saveFile = new ToolStripMenuItem("Save");

			openFile.Click += OpenFile_Click;
			saveFile.Click += SaveFile_Click;

			fileMenu.DropDownItems.Add(openFile);
			fileMenu.DropDownItems.Add(saveFile);
			menuStrip.Items.Add(fileMenu);

			this.MainMenuStrip = menuStrip;
			this.Controls.Add(menuStrip);

			// Buttons // TODO Remove this sh*t
			buttonAdd.Text = "Add Attribute";
			buttonEdit.Text = "Edit Attribute";
			buttonRemove.Text = "Remove Selected";

			// Events xd
			buttonAdd.Click += (sender, e) => AddAttribute();
			buttonEdit.Click += (sender, e) => EditAttribute();
			buttonRemove.Click += (sender, e) => RemoveAttribute();

			listBox.DoubleClick += (sender, e) => EditAttribute();
			itemsView.AfterSelect += (sender, e) => ShowItemDetails(e);
		}

		private void AddAttribute()
		{
			if (itemsView.SelectedNode?.Tag is XmlNode selectedNode)
			{
				// Prompt user for new attribute name and value						
				var attrName = Prompt.ShowDialog("Enter attribute name:");

				if (string.IsNullOrEmpty(attrName))
				{
					return;
				}

				var attrValue = Prompt.ShowDialog("Enter attribute value:");

				// Update XML and UI
				XmlAttribute newAttr = xmlToEdit.CreateAttribute(attrName);
				newAttr.Value = attrValue;
				selectedNode.Attributes.Append(newAttr);

				// Update ListBox
				listBox.Items.Add($"{attrName}=\"{attrValue}\"");
			}
		}

		private void ShowItemDetails(TreeViewEventArgs e)
		{
			if (e.Node.Tag is XmlNode selectedNode)
			{
				textBox1.Text = GetNodeAttributesString(selectedNode);
				listBox.Items.Clear();
				if (selectedNode.Attributes != null)
				{
					foreach (XmlAttribute attr in selectedNode.Attributes)
					{
						listBox.Items.Add($"{attr.Name}=\"{attr.Value}\"");
					}
				}
			}
		}

		private void RemoveAttribute()
		{
			if (listBox.SelectedItem != null)
			{
				var selectedAttribute = listBox.SelectedItem.ToString();
				listBox.Items.Remove(selectedAttribute);
				if (itemsView.SelectedNode?.Tag is XmlNode selectedNode)
				{
					var attrName = selectedAttribute.Split('=')[0];
					selectedNode.Attributes.RemoveNamedItem(attrName);
				}
			}
		}

		private void EditAttribute()
		{
			if (listBox.SelectedItem != null)
			{
				// Get the current item text
				string currentItem = listBox.SelectedItem.ToString();

				// Split the current item to extract attribute name and value
				string[] parts = currentItem.Split('=');

				if (parts.Length == 2)
				{
					string attrName = parts[0].Trim();
					string currentValue = parts[1].Trim('"');

					// Prompt user for new attribute name and value						
					var newAttrValue = Prompt.EditAttribute(attrName, currentValue);

					if (!string.IsNullOrEmpty(newAttrValue))
					{
						// Update list box item
						string editedItem = $"{attrName}=\"{newAttrValue}\"";
						int selectedIndex = listBox.SelectedIndex;
						listBox.Items[selectedIndex] = editedItem;

						// Update XML attribute if treeView1 selected node is valid
						if (itemsView.SelectedNode?.Tag is XmlNode selectedNode)
						{
							// Find the attribute and update its value
							XmlAttribute attributeToUpdate = selectedNode.Attributes[attrName];
							if (attributeToUpdate != null)
							{
								attributeToUpdate.Value = newAttrValue;
							}
						}
					}
				}
			}
		}

		private void OpenFile_Click(object sender, EventArgs e)
		{
			using (var openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					xmlToEdit = new XmlDocument();
					xmlToEdit.Load(openFileDialog.FileName);
					PopulateTreeView(xmlToEdit);
				}
			}
		}

		private void SaveFile_Click(object sender, EventArgs e)
		{
			using (var saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					xmlToEdit.Save(saveFileDialog.FileName);
				}
			}
		}

		private void PopulateTreeView(XmlDocument xmlDoc)
		{
			itemsView.Nodes.Clear();
			XmlNode rootNode = xmlDoc.DocumentElement;
			TreeNode rootTreeNode = new TreeNode(rootNode.ChildNodes[0].Name);
			rootTreeNode.Tag = rootNode;
			itemsView.Nodes.Add(rootTreeNode);
			PopulateTreeNodes(rootNode.ChildNodes[0], rootTreeNode);
		}

		private void PopulateTreeNodes(XmlNode xmlNode, TreeNode treeNode)
		{
			foreach (XmlNode childNode in xmlNode.ChildNodes)
			{
				TreeNode childTreeNode = new TreeNode($"[{childNode.Name}] {GetNodeAttributesString(childNode)}");
				childTreeNode.Tag = childNode;
				if (childNode.Name != "#comment")
				{
					treeNode.Nodes.Add(childTreeNode);
				}
				PopulateTreeNodes(childNode, childTreeNode);
			}
		}

		private string GetNodeAttributesString(XmlNode xmlNode)
		{
			StringBuilder attributesString = new StringBuilder();
			if (xmlNode.Attributes != null)
			{
				foreach (XmlAttribute attr in xmlNode.Attributes)
				{
					attributesString.Append($"{attr.Value}, ");
					break;
				}
			}

			if (attributesString.Length > 0)
			{
				attributesString.Length -= 2;
			}

			return attributesString.ToString();
		}
	}
}