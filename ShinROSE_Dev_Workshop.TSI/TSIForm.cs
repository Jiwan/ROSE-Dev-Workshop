using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop.TSI
{
	public class TSIForm : Form
	{
		private IContainer components = null;

		private StatusStrip statusStrip;

		private ToolStripStatusLabel StatusLabel;

		private MenuStrip menuStrip;

		private ToolStripMenuItem fileToolStripMenuItem;

		private ToolStripMenuItem openToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem saveToolStripMenuItem;

		private ToolStripMenuItem saveAsToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem exitToolStripMenuItem;

		private PropertyGrid propertyGrid;

		private TreeView treeView;

		private OpenFileDialog openFileDialog;

		private ContextMenuStrip contextMenuStrip;

		private ToolStripMenuItem addDdsToolStripMenuItem;

		private ToolStripMenuItem addElementToolStripMenuItem;

		private ToolStripMenuItem removeDdsToolStripMenuItem;

		private ToolStripMenuItem copyDDSToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripMenuItem removeElementToolStripMenuItem;

		private ToolStripMenuItem copyElementToolStripMenuItem;

		private Label label;

		private Label label1;

		private Label label2;

		private ToolStripMenuItem pasteDDSToolStripMenuItem;

		private ToolStripMenuItem pasteElementToolStripMenuItem;

		private Panel panel;

		private PictureBox pictureBox;

		private SaveFileDialog saveFileDialog;

		private bool mouse_select = false;

		private bool preview = false;

		private short dds_count;

		private short totalelement_count;

		private List<dds> ListDDS = new List<dds>();

		private dds copyDDS;

		private dds.dds_element copyelement;

		private Graphics graphics;

		private GraphicsStream gs;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TSIForm));
			this.statusStrip = new StatusStrip();
			this.StatusLabel = new ToolStripStatusLabel();
			this.menuStrip = new MenuStrip();
			this.fileToolStripMenuItem = new ToolStripMenuItem();
			this.openToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.saveToolStripMenuItem = new ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.exitToolStripMenuItem = new ToolStripMenuItem();
			this.propertyGrid = new PropertyGrid();
			this.treeView = new TreeView();
			this.contextMenuStrip = new ContextMenuStrip(this.components);
			this.addDdsToolStripMenuItem = new ToolStripMenuItem();
			this.removeDdsToolStripMenuItem = new ToolStripMenuItem();
			this.copyDDSToolStripMenuItem = new ToolStripMenuItem();
			this.pasteDDSToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator3 = new ToolStripSeparator();
			this.addElementToolStripMenuItem = new ToolStripMenuItem();
			this.removeElementToolStripMenuItem = new ToolStripMenuItem();
			this.copyElementToolStripMenuItem = new ToolStripMenuItem();
			this.pasteElementToolStripMenuItem = new ToolStripMenuItem();
			this.openFileDialog = new OpenFileDialog();
			this.label = new Label();
			this.label1 = new Label();
			this.label2 = new Label();
			this.panel = new Panel();
			this.pictureBox = new PictureBox();
			this.saveFileDialog = new SaveFileDialog();
			this.statusStrip.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.panel.SuspendLayout();
			((ISupportInitialize)this.pictureBox).BeginInit();
			base.SuspendLayout();
			this.statusStrip.Items.AddRange(new ToolStripItem[]
			{
				this.StatusLabel
			});
			this.statusStrip.Location = new Point(0, 446);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new Size(892, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new Size(44, 17);
			this.StatusLabel.Text = "Statut :";
			this.menuStrip.AllowMerge = false;
			this.menuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.fileToolStripMenuItem
			});
			this.menuStrip.Location = new Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new Size(892, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip1";
			this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.openToolStripMenuItem,
				this.toolStripSeparator1,
				this.saveToolStripMenuItem,
				this.saveAsToolStripMenuItem,
				this.toolStripSeparator2,
				this.exitToolStripMenuItem
			});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new Size(123, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(120, 6);
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new Size(123, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new Size(123, 22);
			this.saveAsToolStripMenuItem.Text = "Save as";
			this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(120, 6);
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new Size(123, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
			this.propertyGrid.Location = new Point(673, 43);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new Size(220, 300);
			this.propertyGrid.TabIndex = 2;
			this.propertyGrid.Click += new EventHandler(this.propertyGrid_Click);
			this.propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
			this.treeView.ContextMenuStrip = this.contextMenuStrip;
			this.treeView.Location = new Point(12, 43);
			this.treeView.Name = "treeView";
			this.treeView.Size = new Size(235, 300);
			this.treeView.TabIndex = 3;
			this.treeView.AfterSelect += new TreeViewEventHandler(this.treeView_AfterSelect);
			this.contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.addDdsToolStripMenuItem,
				this.removeDdsToolStripMenuItem,
				this.copyDDSToolStripMenuItem,
				this.pasteDDSToolStripMenuItem,
				this.toolStripSeparator3,
				this.addElementToolStripMenuItem,
				this.removeElementToolStripMenuItem,
				this.copyElementToolStripMenuItem,
				this.pasteElementToolStripMenuItem
			});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new Size(166, 186);
			this.addDdsToolStripMenuItem.Enabled = false;
			this.addDdsToolStripMenuItem.Name = "addDdsToolStripMenuItem";
			this.addDdsToolStripMenuItem.Size = new Size(165, 22);
			this.addDdsToolStripMenuItem.Text = "Add DDS";
			this.addDdsToolStripMenuItem.Click += new EventHandler(this.addDdsToolStripMenuItem_Click);
			this.removeDdsToolStripMenuItem.Enabled = false;
			this.removeDdsToolStripMenuItem.Name = "removeDdsToolStripMenuItem";
			this.removeDdsToolStripMenuItem.Size = new Size(165, 22);
			this.removeDdsToolStripMenuItem.Text = "Remove DDS";
			this.removeDdsToolStripMenuItem.Click += new EventHandler(this.removeDdsToolStripMenuItem_Click);
			this.copyDDSToolStripMenuItem.Enabled = false;
			this.copyDDSToolStripMenuItem.Name = "copyDDSToolStripMenuItem";
			this.copyDDSToolStripMenuItem.Size = new Size(165, 22);
			this.copyDDSToolStripMenuItem.Text = "Copy DDS";
			this.copyDDSToolStripMenuItem.Click += new EventHandler(this.copyDDSToolStripMenuItem_Click);
			this.pasteDDSToolStripMenuItem.Enabled = false;
			this.pasteDDSToolStripMenuItem.Name = "pasteDDSToolStripMenuItem";
			this.pasteDDSToolStripMenuItem.Size = new Size(165, 22);
			this.pasteDDSToolStripMenuItem.Text = "Paste DDS ";
			this.pasteDDSToolStripMenuItem.Click += new EventHandler(this.pasteDDSToolStripMenuItem_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new Size(162, 6);
			this.addElementToolStripMenuItem.Enabled = false;
			this.addElementToolStripMenuItem.Name = "addElementToolStripMenuItem";
			this.addElementToolStripMenuItem.Size = new Size(165, 22);
			this.addElementToolStripMenuItem.Text = "Add element";
			this.addElementToolStripMenuItem.Click += new EventHandler(this.addElementToolStripMenuItem_Click);
			this.removeElementToolStripMenuItem.Enabled = false;
			this.removeElementToolStripMenuItem.Name = "removeElementToolStripMenuItem";
			this.removeElementToolStripMenuItem.Size = new Size(165, 22);
			this.removeElementToolStripMenuItem.Text = "Remove element";
			this.removeElementToolStripMenuItem.Click += new EventHandler(this.removeElementToolStripMenuItem_Click);
			this.copyElementToolStripMenuItem.Enabled = false;
			this.copyElementToolStripMenuItem.Name = "copyElementToolStripMenuItem";
			this.copyElementToolStripMenuItem.Size = new Size(165, 22);
			this.copyElementToolStripMenuItem.Text = "Copy element";
			this.copyElementToolStripMenuItem.Click += new EventHandler(this.copyElementToolStripMenuItem_Click);
			this.pasteElementToolStripMenuItem.Enabled = false;
			this.pasteElementToolStripMenuItem.Name = "pasteElementToolStripMenuItem";
			this.pasteElementToolStripMenuItem.Size = new Size(165, 22);
			this.pasteElementToolStripMenuItem.Text = "Paste element";
			this.pasteElementToolStripMenuItem.Click += new EventHandler(this.pasteElementToolStripMenuItem_Click);
			this.openFileDialog.Filter = "TSI Files|*.tsi|All Files|*.*";
			this.label.AutoSize = true;
			this.label.Location = new Point(12, 25);
			this.label.Name = "label";
			this.label.Size = new Size(32, 13);
			this.label.TabIndex = 4;
			this.label.Text = "Dds :";
			this.label1.AutoSize = true;
			this.label1.Location = new Point(252, 24);
			this.label1.Name = "label1";
			this.label1.Size = new Size(51, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Preview :";
			this.label2.AutoSize = true;
			this.label2.Location = new Point(670, 24);
			this.label2.Name = "label2";
			this.label2.Size = new Size(72, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Element Info :";
			this.panel.AutoScroll = true;
			this.panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.panel.Controls.Add(this.pictureBox);
			this.panel.Location = new Point(255, 43);
			this.panel.Name = "panel";
			this.panel.Size = new Size(400, 400);
			this.panel.TabIndex = 8;
			this.panel.Scroll += new ScrollEventHandler(this.panel_Scroll);
			this.pictureBox.Cursor = Cursors.Cross;
			this.pictureBox.Location = new Point(3, 3);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new Size(300, 300);
			this.pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseClick += new MouseEventHandler(this.pictureBox_MouseClick);
			this.saveFileDialog.Filter = "TSI Files|*.tsi|All Files|*.*";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(892, 468);
			base.Controls.Add(this.panel);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label);
			base.Controls.Add(this.treeView);
			base.Controls.Add(this.statusStrip);
			base.Controls.Add(this.propertyGrid);
			base.Controls.Add(this.menuStrip);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.menuStrip;
			base.MaximizeBox = false;
			base.Name = "TSIForm";
			this.Text = "TSI :";
			base.Activated += new EventHandler(this.TSIForm_Activated);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.contextMenuStrip.ResumeLayout(false);
			this.panel.ResumeLayout(false);
			this.panel.PerformLayout();
			((ISupportInitialize)this.pictureBox).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public TSIForm()
		{
			this.InitializeComponent();
		}

		private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
		{
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.load_tsi(this.openFileDialog.FileName);
			}
			this.Text = "TSI : \"" + this.openFileDialog.FileName + "\"";
		}

		public void load_tsi(string path)
		{
			this.treeView.Nodes.Clear();
			this.ListDDS.Clear();
			BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open));
			this.dds_count = binaryReader.ReadInt16();
			for (int num = 0; num != (int)this.dds_count; num++)
			{
				dds dds = new dds();
				short count = binaryReader.ReadInt16();
				dds.path = Encoding.UTF7.GetString(binaryReader.ReadBytes((int)count));
				this.treeView.Nodes.Add("Dds : \"" + dds.path + "\"");
				dds.colour_key = binaryReader.ReadInt32();
				this.ListDDS.Add(dds);
			}
			this.totalelement_count = binaryReader.ReadInt16();
			for (int num = 0; num != (int)this.dds_count; num++)
			{
				this.ListDDS[num].ddselement_count = binaryReader.ReadInt16();
				for (int num2 = 0; num2 != (int)this.ListDDS[num].ddselement_count; num2++)
				{
					dds.dds_element dds_element = new dds.dds_element();
					dds_element.Load_element(ref binaryReader);
					this.ListDDS[num].ListDDS_element.Add(dds_element);
					this.treeView.Nodes[num].Nodes.Add(dds_element.name);
				}
			}
			this.propertyGrid.SelectedObject = this.ListDDS[0].ListDDS_element[0];
			binaryReader.Close();
		}

		private void save_tsi(string path)
		{
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create));
			binaryWriter.Write(Convert.ToInt16(this.ListDDS.Count));
			int num = 0;
			for (int num2 = 0; num2 != this.ListDDS.Count; num2++)
			{
				binaryWriter.Write(Convert.ToInt16(this.ListDDS[num2].path.Length));
				byte[] bytes = Encoding.Default.GetBytes(this.ListDDS[num2].path);
				binaryWriter.Write(bytes, 0, bytes.Length);
				binaryWriter.Write(this.ListDDS[num2].colour_key);
				num += this.ListDDS[num2].ListDDS_element.Count;
			}
			binaryWriter.Write(Convert.ToInt16(num));
			for (int num2 = 0; num2 != this.ListDDS.Count; num2++)
			{
				binaryWriter.Write(Convert.ToInt16(this.ListDDS[num2].ListDDS_element.Count));
				for (int num3 = 0; num3 != this.ListDDS[num2].ListDDS_element.Count; num3++)
				{
					binaryWriter.Write(this.ListDDS[num2].ListDDS_element[num3].ownerid);
					binaryWriter.Write(this.ListDDS[num2].ListDDS_element[num3].x1);
					binaryWriter.Write(this.ListDDS[num2].ListDDS_element[num3].y1);
					binaryWriter.Write(this.ListDDS[num2].ListDDS_element[num3].x2);
					binaryWriter.Write(this.ListDDS[num2].ListDDS_element[num3].y2);
					binaryWriter.Write(this.ListDDS[num2].ListDDS_element[num3].colour);
					byte[] bytes2 = Encoding.Default.GetBytes(this.ListDDS[num2].ListDDS_element[num3].name);
					binaryWriter.Write(bytes2, 0, 32);
				}
			}
			binaryWriter.Close();
		}

		private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (this.treeView.SelectedNode.Level == 0)
			{
				TreeNode treeNode = this.treeView.SelectedNode;
				this.addDdsToolStripMenuItem.Enabled = true;
				this.removeDdsToolStripMenuItem.Enabled = true;
				this.copyDDSToolStripMenuItem.Enabled = true;
				this.pasteDDSToolStripMenuItem.Enabled = true;
				this.addElementToolStripMenuItem.Enabled = true;
				this.removeElementToolStripMenuItem.Enabled = false;
				this.copyElementToolStripMenuItem.Enabled = false;
				this.pasteElementToolStripMenuItem.Enabled = false;
				this.propertyGrid.SelectedObject = this.ListDDS[treeNode.Index];
				string[] array = this.Text.Split(new char[]
				{
					'"'
				});
				string path = array[1];
				string str = Convert.ToString(Directory.GetParent(path));
				this.load_image(str + "\\" + this.ListDDS[treeNode.Index].path);
			}
			if (this.treeView.SelectedNode.Level == 1)
			{
				this.addDdsToolStripMenuItem.Enabled = false;
				this.removeDdsToolStripMenuItem.Enabled = false;
				this.copyDDSToolStripMenuItem.Enabled = false;
				this.pasteDDSToolStripMenuItem.Enabled = false;
				this.addElementToolStripMenuItem.Enabled = true;
				this.removeElementToolStripMenuItem.Enabled = true;
				this.copyElementToolStripMenuItem.Enabled = true;
				this.pasteElementToolStripMenuItem.Enabled = true;
				TreeNode selectedNode = this.treeView.SelectedNode;
				TreeNode treeNode = selectedNode.Parent;
				this.propertyGrid.SelectedObject = this.ListDDS[treeNode.Index].ListDDS_element[selectedNode.Index];
				string[] array = this.Text.Split(new char[]
				{
					'"'
				});
				string path = array[1];
				string str = Convert.ToString(Directory.GetParent(path));
				this.load_image(str + "\\" + this.ListDDS[treeNode.Index].path);
				if (this.preview)
				{
					this.loadRect(this.ListDDS[treeNode.Index].ListDDS_element[selectedNode.Index].x1, this.ListDDS[treeNode.Index].ListDDS_element[selectedNode.Index].y1, this.ListDDS[treeNode.Index].ListDDS_element[selectedNode.Index].x2, this.ListDDS[treeNode.Index].ListDDS_element[selectedNode.Index].y2);
				}
			}
		}

		private void addDdsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.treeView.Nodes.Add("Dds : \"New node\"");
			this.treeView.Refresh();
			dds dds = new dds();
			dds.colour_key = 0;
			dds.path = "New node";
			dds.ddselement_count = 0;
			dds dds2 = new dds();
			dds2.path = "New node";
			dds2.colour_key = 0;
			this.ListDDS.Add(dds2);
		}

		private void removeDdsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ListDDS.RemoveAt(this.treeView.SelectedNode.Index);
			for (int num = this.treeView.SelectedNode.Index; num != this.ListDDS.Count; num++)
			{
				for (int num2 = 0; num2 != this.ListDDS[num].ListDDS_element.Count; num2++)
				{
					dds.dds_element expr_4D = this.ListDDS[num].ListDDS_element[num2];
					expr_4D.ownerid -= 1;
				}
			}
			this.treeView.Nodes.Remove(this.treeView.SelectedNode);
		}

		private void copyDDSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.copyDDS = this.ListDDS[this.treeView.SelectedNode.Index];
		}

		private void pasteDDSToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ListDDS[this.treeView.SelectedNode.Index] = this.copyDDS;
			this.treeView.SelectedNode.Text = "Dds : \"" + this.ListDDS[this.treeView.SelectedNode.Index].path + "\"";
			this.treeView.SelectedNode.Nodes.Clear();
			for (int num = 0; num != (int)this.ListDDS[this.treeView.SelectedNode.Index].ddselement_count; num++)
			{
				this.treeView.SelectedNode.Nodes.Add(this.ListDDS[this.treeView.SelectedNode.Index].ListDDS_element[num].nom);
			}
		}

		private void addElementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			dds.dds_element dds_element = new dds.dds_element();
			dds_element.colour = 0;
			dds_element.name = "New element";
			dds_element.ownerid = 0;
			dds_element.x1 = 0;
			dds_element.x2 = 0;
			dds_element.y1 = 0;
			dds_element.y2 = 0;
			if (this.treeView.SelectedNode.Level == 1)
			{
				TreeNode selectedNode = this.treeView.SelectedNode;
				TreeNode treeNode = selectedNode.Parent;
				dds_element.ownerid = Convert.ToInt16(treeNode.Index);
				this.ListDDS[treeNode.Index].ListDDS_element.Add(dds_element);
				treeNode.Nodes.Add("New element");
			}
			else if (this.treeView.SelectedNode.Level == 0)
			{
				TreeNode treeNode = this.treeView.SelectedNode;
				dds_element.ownerid = Convert.ToInt16(treeNode.Index);
				this.ListDDS[treeNode.Index].ListDDS_element.Add(dds_element);
				treeNode.Nodes.Add("New element");
			}
		}

		private void removeElementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.treeView.SelectedNode;
			TreeNode parent = selectedNode.Parent;
			this.ListDDS[parent.Index].ListDDS_element.RemoveAt(selectedNode.Index);
			this.treeView.Nodes.Remove(selectedNode);
		}

		private void copyElementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.treeView.SelectedNode;
			TreeNode parent = selectedNode.Parent;
			this.copyelement = this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index];
		}

		private void pasteElementToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.treeView.SelectedNode;
			TreeNode parent = selectedNode.Parent;
			this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index] = this.copyelement;
			selectedNode.Text = this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].name;
		}

		private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			if (this.propertyGrid.SelectedObject.GetType() == typeof(dds))
			{
				dds dds = (dds)this.propertyGrid.SelectedObject;
				this.treeView.SelectedNode.Text = "Dds : \"" + dds.path + "\"";
			}
			if (this.propertyGrid.SelectedObject.GetType() == typeof(dds.dds_element))
			{
				dds.dds_element dds_element = (dds.dds_element)this.propertyGrid.SelectedObject;
				this.treeView.SelectedNode.Text = dds_element.name;
				TreeNode selectedNode = this.treeView.SelectedNode;
				TreeNode parent = selectedNode.Parent;
				if (this.preview)
				{
					this.loadRect(this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].x1, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].y1, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].x2, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].y2);
				}
			}
		}

		public void load_image(string DDS)
		{
			if (this.gs != null)
			{
				this.gs.Dispose();
			}
			try
			{
				PresentParameters presentParameters = new PresentParameters();
				presentParameters.SwapEffect = SwapEffect.Discard;
				Format format = Manager.Adapters[0].CurrentDisplayMode.Format;
				presentParameters.Windowed = true;
				Device device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, new PresentParameters[]
				{
					presentParameters
				});
				Texture texture = TextureLoader.FromFile(device, DDS);
				this.gs = TextureLoader.SaveToStream(ImageFileFormat.Png, texture);
				texture.Dispose();
				this.pictureBox.Image = Image.FromStream(this.gs);
				device.Dispose();
				this.gs.Close();
				this.preview = true;
			}
			catch (Exception var_4_BB)
			{
				this.preview = false;
			}
		}

		public void loadRect(int x1, int y1, int x2, int y2)
		{
			this.pictureBox.Refresh();
			Graphics graphics = this.pictureBox.CreateGraphics();
			graphics.DrawRectangle(Pens.Red, x1, y1, x2 - x1, y2 - y1);
			Rectangle rect = new Rectangle(x1, y1, x2 - x1, y2 - y1);
			graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 0, 0)), rect);
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.save_tsi(this.saveFileDialog.FileName);
			}
			this.Text = "TSI : \"" + this.saveFileDialog.FileName + "\"";
		}

		private void pictureBox_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.preview)
			{
				if (this.treeView.SelectedNode.Level == 1)
				{
					TreeNode selectedNode = this.treeView.SelectedNode;
					TreeNode parent = selectedNode.Parent;
					if (!this.mouse_select)
					{
						this.pictureBox.Refresh();
						Graphics graphics = this.pictureBox.CreateGraphics();
						graphics.DrawRectangle(Pens.Black, e.X, e.Y, 5, 5);
						this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].x1 = e.X;
						this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].y1 = e.Y;
						this.propertyGrid.Refresh();
						this.StatusLabel.Text = "Select the second point please";
						this.mouse_select = true;
					}
					else if (this.mouse_select)
					{
						this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].x2 = e.X;
						this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].y2 = e.Y;
						this.loadRect(this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].x1, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].y1, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].x2, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].y2);
						this.propertyGrid.Refresh();
						this.StatusLabel.Text = "Statut :";
						this.mouse_select = false;
					}
				}
			}
		}

		private void panel_Scroll(object sender, ScrollEventArgs e)
		{
			if (this.preview)
			{
				if (this.treeView.SelectedNode.Level == 1)
				{
					TreeNode selectedNode = this.treeView.SelectedNode;
					TreeNode parent = selectedNode.Parent;
					this.loadRect(this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].x1, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].y1, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].x2, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].y2);
				}
			}
		}

		private void TSIForm_Activated(object sender, EventArgs e)
		{
			if (this.preview)
			{
				if (this.treeView.SelectedNode.Level == 1)
				{
					TreeNode selectedNode = this.treeView.SelectedNode;
					TreeNode parent = selectedNode.Parent;
					this.loadRect(this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].x1, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].y1, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].x2, this.ListDDS[parent.Index].ListDDS_element[selectedNode.Index].y2);
				}
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void propertyGrid_Click(object sender, EventArgs e)
		{
		}

		private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
		{
		}
	}
}
