using ShinROSE_Dev_Workshop.STB;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop.STL
{
	public class STLForm : Form
	{
		public struct ID
		{
			public string stringID;

			public uint id;
		}

		public struct STLEntry
		{
			public string text;

			public string comment;

			public string quest1;

			public string quest2;
		}

		private IContainer components = null;

		private SplitContainer splitContainer1;

		private ToolStripMenuItem fileToolStripMenuItem;

		private ToolStripMenuItem loadToolStripMenuItem;

		private ToolStripMenuItem saveToolStripMenuItem;

		private ToolStripMenuItem saveAsToolStripMenuItem;

		private ToolStripMenuItem exitToolStripMenuItem;

		private ToolStripMenuItem toolsToolStripMenuItem;

		private ToolStripMenuItem goToToolStripMenuItem;

		private ToolStripMenuItem searchToolStripMenuItem;

		private MenuStrip menuStrip;

		private OpenFileDialog openFileDialog;

		private SaveFileDialog saveFileDialog;

		private ContextMenuStrip contextMenuStrip;

		private ToolStripMenuItem addRowAboveMenuItem;

		private ToolStripMenuItem addRowsBelowMenuItem;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem deletedRowMenuItem;

		private ToolStripMenuItem clearRowMenuItem;

		private TextBox InfotextBox;

		private Label InfoLabel;

		private ListBox InfolistBox;

		private Button InfoButton;

		private StatusStrip statusStrip;

		private ToolStripStatusLabel toolStripStatusLabel;

		private ToolStripSeparator toolStripSeparator1;

		private CheckBox checkBoxLangage;

		private ComboBox comboBoxlangage;

		private DataGridView dataGridView;

		private string[] search_result;

		public string stlType;

		public uint entry_count;

		public STLForm.ID[] ids;

		public uint language_count;

		public uint[] language_offsets;

		public uint[,] entry_offsets;

		public STLForm.STLEntry[,] Entries;

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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(STLForm));
			this.splitContainer1 = new SplitContainer();
			this.comboBoxlangage = new ComboBox();
			this.checkBoxLangage = new CheckBox();
			this.statusStrip = new StatusStrip();
			this.toolStripStatusLabel = new ToolStripStatusLabel();
			this.dataGridView = new DataGridView();
			this.contextMenuStrip = new ContextMenuStrip(this.components);
			this.addRowAboveMenuItem = new ToolStripMenuItem();
			this.addRowsBelowMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.clearRowMenuItem = new ToolStripMenuItem();
			this.deletedRowMenuItem = new ToolStripMenuItem();
			this.menuStrip = new MenuStrip();
			this.fileToolStripMenuItem = new ToolStripMenuItem();
			this.loadToolStripMenuItem = new ToolStripMenuItem();
			this.saveToolStripMenuItem = new ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new ToolStripMenuItem();
			this.exitToolStripMenuItem = new ToolStripMenuItem();
			this.toolsToolStripMenuItem = new ToolStripMenuItem();
			this.goToToolStripMenuItem = new ToolStripMenuItem();
			this.searchToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.InfoButton = new Button();
			this.InfolistBox = new ListBox();
			this.InfotextBox = new TextBox();
			this.InfoLabel = new Label();
			this.openFileDialog = new OpenFileDialog();
			this.saveFileDialog = new SaveFileDialog();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.statusStrip.SuspendLayout();
			((ISupportInitialize)this.dataGridView).BeginInit();
			this.contextMenuStrip.SuspendLayout();
			this.menuStrip.SuspendLayout();
			base.SuspendLayout();
			this.splitContainer1.Dock = DockStyle.Fill;
			this.splitContainer1.Location = new Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Panel1.Controls.Add(this.comboBoxlangage);
			this.splitContainer1.Panel1.Controls.Add(this.checkBoxLangage);
			this.splitContainer1.Panel1.Controls.Add(this.statusStrip);
			this.splitContainer1.Panel1.Controls.Add(this.dataGridView);
			this.splitContainer1.Panel1.Controls.Add(this.menuStrip);
			this.splitContainer1.Panel2.Controls.Add(this.InfoButton);
			this.splitContainer1.Panel2.Controls.Add(this.InfolistBox);
			this.splitContainer1.Panel2.Controls.Add(this.InfotextBox);
			this.splitContainer1.Panel2.Controls.Add(this.InfoLabel);
			this.splitContainer1.Size = new Size(672, 566);
			this.splitContainer1.SplitterDistance = 640;
			this.splitContainer1.TabIndex = 2;
			this.comboBoxlangage.Enabled = false;
			this.comboBoxlangage.FormattingEnabled = true;
			this.comboBoxlangage.Location = new Point(244, 12);
			this.comboBoxlangage.Name = "comboBoxlangage";
			this.comboBoxlangage.Size = new Size(117, 21);
			this.comboBoxlangage.TabIndex = 5;
			this.comboBoxlangage.Text = "English";
			this.checkBoxLangage.AutoSize = true;
			this.checkBoxLangage.Location = new Point(367, 14);
			this.checkBoxLangage.Name = "checkBoxLangage";
			this.checkBoxLangage.Size = new Size(86, 17);
			this.checkBoxLangage.TabIndex = 4;
			this.checkBoxLangage.Text = "Multilangage";
			this.checkBoxLangage.UseVisualStyleBackColor = true;
			this.checkBoxLangage.CheckedChanged += new EventHandler(this.checkBoxLangage_CheckedChanged);
			this.statusStrip.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripStatusLabel
			});
			this.statusStrip.Location = new Point(0, 544);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new Size(640, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "Statut :";
			this.toolStripStatusLabel.Name = "toolStripStatusLabel";
			this.toolStripStatusLabel.Size = new Size(44, 17);
			this.toolStripStatusLabel.Text = "Statut :";
			this.dataGridView.AllowUserToAddRows = false;
			this.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.ContextMenuStrip = this.contextMenuStrip;
			this.dataGridView.ImeMode = ImeMode.NoControl;
			this.dataGridView.Location = new Point(28, 37);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RightToLeft = RightToLeft.No;
			this.dataGridView.Size = new Size(609, 498);
			this.dataGridView.TabIndex = 0;
			this.dataGridView.ColumnHeaderMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseDoubleClick);
			this.dataGridView.CellMouseClick += new DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);
			this.dataGridView.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dataGridView_ColumnHeaderMouseClick);
			this.dataGridView.KeyDown += new KeyEventHandler(this.dataGridView_KeyDown);
			this.dataGridView.RowHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dataGridView_RowHeaderMouseClick);
			this.contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.addRowAboveMenuItem,
				this.addRowsBelowMenuItem,
				this.toolStripSeparator2,
				this.clearRowMenuItem,
				this.deletedRowMenuItem
			});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new Size(168, 98);
			this.addRowAboveMenuItem.Enabled = false;
			this.addRowAboveMenuItem.Name = "addRowAboveMenuItem";
			this.addRowAboveMenuItem.Size = new Size(167, 22);
			this.addRowAboveMenuItem.Text = "Add Rows Above";
			this.addRowAboveMenuItem.Click += new EventHandler(this.addRowAboveMenuItem_Click);
			this.addRowsBelowMenuItem.Enabled = false;
			this.addRowsBelowMenuItem.Name = "addRowsBelowMenuItem";
			this.addRowsBelowMenuItem.Size = new Size(167, 22);
			this.addRowsBelowMenuItem.Text = "Add Rows Below";
			this.addRowsBelowMenuItem.Click += new EventHandler(this.addRowsBelowMenuItem_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(164, 6);
			this.clearRowMenuItem.Enabled = false;
			this.clearRowMenuItem.Name = "clearRowMenuItem";
			this.clearRowMenuItem.Size = new Size(167, 22);
			this.clearRowMenuItem.Text = "Clear Rows";
			this.clearRowMenuItem.Click += new EventHandler(this.clearRowMenuItem_Click);
			this.deletedRowMenuItem.Enabled = false;
			this.deletedRowMenuItem.Name = "deletedRowMenuItem";
			this.deletedRowMenuItem.Size = new Size(167, 22);
			this.deletedRowMenuItem.Text = "Deleted Row";
			this.deletedRowMenuItem.Click += new EventHandler(this.deletedRowMenuItem_Click);
			this.menuStrip.AllowMerge = false;
			this.menuStrip.BackColor = SystemColors.Control;
			this.menuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.fileToolStripMenuItem,
				this.toolsToolStripMenuItem
			});
			this.menuStrip.Location = new Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new Size(640, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip";
			this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.loadToolStripMenuItem,
				this.saveToolStripMenuItem,
				this.saveAsToolStripMenuItem,
				this.exitToolStripMenuItem
			});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new Size(124, 22);
			this.loadToolStripMenuItem.Text = "Load";
			this.loadToolStripMenuItem.Click += new EventHandler(this.loadToolStripMenuItem_Click);
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new Size(124, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new Size(124, 22);
			this.saveAsToolStripMenuItem.Text = "Save As";
			this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new Size(124, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click_1);
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.goToToolStripMenuItem,
				this.searchToolStripMenuItem,
				this.toolStripSeparator1
			});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new Size(44, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			this.goToToolStripMenuItem.Name = "goToToolStripMenuItem";
			this.goToToolStripMenuItem.Size = new Size(118, 22);
			this.goToToolStripMenuItem.Text = "Go to";
			this.goToToolStripMenuItem.Click += new EventHandler(this.goToToolStripMenuItem_Click);
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new Size(118, 22);
			this.searchToolStripMenuItem.Text = "Search";
			this.searchToolStripMenuItem.Click += new EventHandler(this.searchToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(115, 6);
			this.InfoButton.Location = new Point(89, 63);
			this.InfoButton.Name = "InfoButton";
			this.InfoButton.Size = new Size(73, 30);
			this.InfoButton.TabIndex = 4;
			this.InfoButton.Text = "Go";
			this.InfoButton.UseVisualStyleBackColor = true;
			this.InfoButton.Visible = false;
			this.InfoButton.Click += new EventHandler(this.InfoButton_Click_1);
			this.InfolistBox.FormattingEnabled = true;
			this.InfolistBox.Location = new Point(6, 63);
			this.InfolistBox.Name = "InfolistBox";
			this.InfolistBox.Size = new Size(244, 199);
			this.InfolistBox.TabIndex = 3;
			this.InfolistBox.Visible = false;
			this.InfolistBox.SelectedIndexChanged += new EventHandler(this.InfolistBox_SelectedIndexChanged);
			this.InfotextBox.Location = new Point(6, 37);
			this.InfotextBox.Name = "InfotextBox";
			this.InfotextBox.Size = new Size(244, 20);
			this.InfotextBox.TabIndex = 1;
			this.InfotextBox.Text = "0";
			this.InfotextBox.Visible = false;
			this.InfotextBox.TextChanged += new EventHandler(this.InfotextBox_TextChanged);
			this.InfoLabel.AutoSize = true;
			this.InfoLabel.Location = new Point(3, 11);
			this.InfoLabel.Name = "InfoLabel";
			this.InfoLabel.Size = new Size(64, 13);
			this.InfoLabel.TabIndex = 0;
			this.InfoLabel.Text = "Go to Row :";
			this.InfoLabel.Visible = false;
			this.openFileDialog.Filter = "STL Files|*.stl|All Files|*.*";
			this.saveFileDialog.Filter = "STL Files|*.stl|All Files|*.*";
			base.AutoScaleMode = AutoScaleMode.Inherit;
			base.ClientSize = new Size(672, 566);
			base.Controls.Add(this.splitContainer1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "STLForm";
			this.Text = "LTBForm";
			base.Resize += new EventHandler(this.STLForm_Resize);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			this.splitContainer1.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((ISupportInitialize)this.dataGridView).EndInit();
			this.contextMenuStrip.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			base.ResumeLayout(false);
		}

		private string ReadBString(ref BinaryReader fh)
		{
			int num = (int)fh.ReadByte();
			if (num > 128)
			{
				num |= (int)fh.ReadByte() << 7;
			}
			return Encoding.UTF8.GetString(fh.ReadBytes(num));
		}

		public void Load_STL(string FileName)
		{
			BinaryReader binaryReader = new BinaryReader(new FileStream(FileName, FileMode.Open));
			this.stlType = this.ReadBString(ref binaryReader);
			this.dataGridView.ColumnCount = 2;
			this.dataGridView.Columns[0].Name = "ID";
			this.dataGridView.Columns[1].Name = "English";
			this.dataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
			this.dataGridView.RowHeadersWidth = 80;
			if (this.stlType == "ITST01")
			{
				this.dataGridView.ColumnCount = 3;
				this.dataGridView.Columns[2].Name = "Description";
				this.dataGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			else if (this.stlType == "QEST01")
			{
				this.dataGridView.ColumnCount = 5;
				this.dataGridView.Columns[3].Name = "Quest (1)";
				this.dataGridView.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
				this.dataGridView.Columns[4].Name = "Quest (2)";
				this.dataGridView.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
			}
			this.entry_count = binaryReader.ReadUInt32();
			this.ids = new STLForm.ID[this.entry_count];
			int num = 0;
			while ((long)num < (long)((ulong)this.entry_count))
			{
				this.ids[num].stringID = this.ReadBString(ref binaryReader);
				this.ids[num].id = binaryReader.ReadUInt32();
				num++;
			}
			int num2 = 0;
			num = 0;
			while ((long)num != (long)((ulong)this.entry_count))
			{
				if ((ulong)this.ids[num].id > (ulong)((long)num2))
				{
					num2 = (int)this.ids[num].id;
				}
				num++;
			}
			this.dataGridView.RowCount = num2 + 1;
			for (num = 0; num != num2 + 1; num++)
			{
				this.dataGridView.Rows[num].HeaderCell.Value = num.ToString();
			}
			num = 0;
			while ((long)num < (long)((ulong)this.entry_count))
			{
				this.dataGridView.Rows[(int)this.ids[num].id].Cells[0].Value = this.ids[num].stringID;
				num++;
			}
			this.language_count = binaryReader.ReadUInt32();
			this.language_offsets = new uint[this.language_count];
			num = 0;
			while ((long)num < (long)((ulong)this.language_count))
			{
				int num3 = num;
				if (num3 != 1)
				{
					this.comboBoxlangage.Items.Add("Langage " + num);
				}
				else
				{
					this.comboBoxlangage.Items.Add("English ");
				}
				this.language_offsets[num] = binaryReader.ReadUInt32();
				num++;
			}
			this.entry_offsets = new uint[(int)((UIntPtr)this.language_count), (int)((UIntPtr)this.entry_count)];
			this.Entries = new STLForm.STLEntry[(int)((UIntPtr)this.language_count), (int)((UIntPtr)this.entry_count)];
			num = 0;
			int num4;
			while ((long)num < (long)((ulong)this.language_count))
			{
				binaryReader.BaseStream.Seek((long)((ulong)this.language_offsets[num]), SeekOrigin.Begin);
				num4 = 0;
				while ((long)num4 < (long)((ulong)this.entry_count))
				{
					this.entry_offsets[num, num4] = binaryReader.ReadUInt32();
					num4++;
				}
				num++;
			}
			num = 0;
			while ((long)num < (long)((ulong)this.language_count))
			{
				num4 = 0;
				while ((long)num4 < (long)((ulong)this.entry_count))
				{
					binaryReader.BaseStream.Seek((long)((ulong)this.entry_offsets[num, num4]), SeekOrigin.Begin);
					this.Entries[num, num4].text = this.ReadBString(ref binaryReader);
					if (this.stlType == "QEST01" || this.stlType == "ITST01")
					{
						this.Entries[num, num4].comment = this.ReadBString(ref binaryReader);
						if (this.stlType == "QEST01")
						{
							this.Entries[num, num4].quest1 = this.ReadBString(ref binaryReader);
							this.Entries[num, num4].quest2 = this.ReadBString(ref binaryReader);
						}
					}
					num4++;
				}
				num++;
			}
			num4 = 0;
			while ((long)num4 < (long)((ulong)this.entry_count))
			{
				this.dataGridView.Rows[(int)this.ids[num4].id].Cells[1].Value = this.Entries[1, num4].text;
				if (this.stlType == "QEST01" || this.stlType == "ITST01")
				{
					this.dataGridView.Rows[(int)this.ids[num4].id].Cells[2].Value = this.Entries[1, num4].comment;
					if (this.stlType == "QEST01")
					{
						this.dataGridView.Rows[(int)this.ids[num4].id].Cells[3].Value = this.Entries[1, num4].quest1;
						this.dataGridView.Rows[(int)this.ids[num4].id].Cells[2].Value = this.Entries[1, num4].quest2;
					}
				}
				num4++;
			}
			binaryReader.Close();
		}

		public STLForm()
		{
			this.InitializeComponent();
		}

		private void addRowsToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void dataGridView_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			ShinROSE_Dev_Workshop.STB.Userdialog userdialog = new ShinROSE_Dev_Workshop.STB.Userdialog();
			userdialog.textBoxInfo.Text = this.dataGridView.Columns[e.ColumnIndex].Name;
			if (userdialog.ShowDialog() == DialogResult.OK)
			{
				this.dataGridView.Columns[e.ColumnIndex].Name = userdialog.textBoxInfo.Text;
			}
		}

		private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			base.Close();
		}

		private void loadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.Load_STL(this.openFileDialog.FileName);
			}
			this.Text = "STL : \"" + this.openFileDialog.FileName + "\"";
		}

		private void goToToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!this.goToToolStripMenuItem.Checked)
			{
				this.goToToolStripMenuItem.Checked = true;
				this.searchToolStripMenuItem.Checked = false;
				base.Size = new Size(910, 600);
				this.dataGridView.Width = 609;
				this.dataGridView.Height = 498;
				this.splitContainer1.SplitterDistance = 640;
				this.InfoLabel.Text = "Go to Row :";
				this.InfoLabel.Visible = true;
				this.InfotextBox.Text = "0";
				this.InfotextBox.Visible = true;
				this.InfoButton.Text = "Go";
				this.InfoButton.Visible = true;
				this.InfolistBox.Visible = false;
			}
			else
			{
				this.goToToolStripMenuItem.Checked = false;
				base.Size = new Size(680, 600);
				this.dataGridView.Width = 609;
				this.dataGridView.Height = 498;
				this.splitContainer1.SplitterDistance = 640;
				this.InfoLabel.Visible = false;
				this.InfotextBox.Text = "0";
				this.InfotextBox.Visible = false;
				this.InfoButton.Text = "Go";
				this.InfoButton.Visible = false;
				this.InfolistBox.Visible = false;
			}
		}

		private void InfoButton_Click(object sender, EventArgs e)
		{
			if (this.InfoLabel.Text == "Go to Row :")
			{
				this.dataGridView.FirstDisplayedScrollingRowIndex = Convert.ToInt32(this.InfotextBox.Text);
				this.dataGridView.Rows[Convert.ToInt32(this.InfotextBox.Text)].Selected = true;
			}
		}

		private void searchToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!this.searchToolStripMenuItem.Checked)
			{
				this.searchToolStripMenuItem.Checked = true;
				this.goToToolStripMenuItem.Checked = false;
				base.Size = new Size(910, 600);
				this.splitContainer1.SplitterDistance = 640;
				this.dataGridView.Width = 609;
				this.dataGridView.Height = 498;
				this.InfoLabel.Text = "Search :";
				this.InfoLabel.Visible = true;
				this.InfotextBox.Text = "";
				this.InfotextBox.Visible = true;
				this.InfoButton.Visible = false;
				this.InfolistBox.Visible = true;
			}
			else
			{
				this.searchToolStripMenuItem.Checked = false;
				base.Size = new Size(680, 600);
				this.splitContainer1.SplitterDistance = 640;
				this.dataGridView.Width = 609;
				this.dataGridView.Height = 498;
				this.InfoLabel.Text = "Search :";
				this.InfoLabel.Visible = false;
				this.InfotextBox.Text = "";
				this.InfotextBox.Visible = false;
				this.InfoButton.Visible = false;
				this.InfolistBox.Visible = false;
			}
		}

		private void InfotextBox_TextChanged(object sender, EventArgs e)
		{
			if (this.InfoLabel.Text == "Search :")
			{
				this.InfolistBox.Items.Clear();
				string text = this.InfotextBox.Text;
				if (text.Length > 1)
				{
					int num;
					for (num = 0; num != this.dataGridView.RowCount; num++)
					{
						for (int num2 = 0; num2 != this.dataGridView.ColumnCount; num2++)
						{
							if (this.dataGridView.Rows[num].Cells[num2].Value != null)
							{
								if (this.dataGridView.Rows[num].Cells[num2].Value.ToString().Contains(text))
								{
									this.InfolistBox.Items.Add(string.Concat(new object[]
									{
										" Row[",
										num,
										"], Column[",
										num2,
										1,
										"] : \"",
										this.dataGridView.Rows[num].Cells[num2].Value.ToString(),
										"\""
									}));
								}
							}
						}
					}
					this.search_result = new string[num];
					int num3 = 0;
					for (int num4 = 0; num4 != this.dataGridView.RowCount; num4++)
					{
						for (int num5 = 0; num5 != this.dataGridView.ColumnCount; num5++)
						{
							if (this.dataGridView.Rows[num4].Cells[num5].Value != null)
							{
								if (this.dataGridView.Rows[num4].Cells[num5].Value.ToString().Contains(text))
								{
									this.search_result[num3] = num4.ToString();
									num3++;
								}
							}
						}
					}
				}
			}
		}

		private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			this.addRowAboveMenuItem.Enabled = true;
			this.addRowsBelowMenuItem.Enabled = true;
			this.deletedRowMenuItem.Enabled = true;
			this.clearRowMenuItem.Enabled = true;
		}

		private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			this.addRowAboveMenuItem.Enabled = false;
			this.addRowsBelowMenuItem.Enabled = false;
			this.deletedRowMenuItem.Enabled = false;
			this.clearRowMenuItem.Enabled = false;
		}

		private void dataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			this.addRowAboveMenuItem.Enabled = false;
			this.addRowsBelowMenuItem.Enabled = false;
			this.deletedRowMenuItem.Enabled = false;
			this.clearRowMenuItem.Enabled = false;
		}

		private void addRowAboveMenuItem_Click(object sender, EventArgs e)
		{
			Userdialog userdialog = new Userdialog();
			userdialog.Text = "Add Rows";
			userdialog.LabelInfo.Text = "Rows count :";
			userdialog.textBoxInfo.Text = "1";
			if (userdialog.ShowDialog() == DialogResult.OK)
			{
				for (int num = 0; num != Convert.ToInt32(userdialog.textBoxInfo.Text); num++)
				{
					this.dataGridView.Rows.Insert(this.dataGridView.SelectedRows[0].Index, new object[0]);
				}
				for (int num = 0; num != this.dataGridView.Rows.Count; num++)
				{
					this.dataGridView.Rows[num].HeaderCell.Value = num.ToString();
				}
			}
		}

		private void addRowsBelowMenuItem_Click(object sender, EventArgs e)
		{
			Userdialog userdialog = new Userdialog();
			userdialog.Text = "Add Rows";
			userdialog.LabelInfo.Text = "Rows count :";
			userdialog.textBoxInfo.Text = "1";
			if (userdialog.ShowDialog() == DialogResult.OK)
			{
				for (int num = 0; num != Convert.ToInt32(userdialog.textBoxInfo.Text); num++)
				{
					this.dataGridView.Rows.Insert(this.dataGridView.SelectedRows[0].Index + 1, new object[0]);
				}
				for (int num = 0; num != this.dataGridView.Rows.Count; num++)
				{
					this.dataGridView.Rows[num].HeaderCell.Value = num.ToString();
				}
			}
		}

		private void deletedRowMenuItem_Click(object sender, EventArgs e)
		{
			this.dataGridView.Rows.RemoveAt(this.dataGridView.SelectedRows[0].Index);
			for (int num = 0; num != this.dataGridView.Rows.Count; num++)
			{
				this.dataGridView.Rows[num].HeaderCell.Value = num.ToString();
			}
		}

		private void clearRowMenuItem_Click(object sender, EventArgs e)
		{
			for (int num = 0; num != this.dataGridView.SelectedRows.Count; num++)
			{
				for (int num2 = 0; num2 != this.dataGridView.SelectedRows[num].Cells.Count; num2++)
				{
					this.dataGridView.SelectedRows[num].Cells[num2].Value = "";
				}
			}
		}

		private void copyRowsMenuItem_Click(object sender, EventArgs e)
		{
			this.copy();
		}

		private void pasteRowsMenuItem_Click(object sender, EventArgs e)
		{
			this.paste_click();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.save_stl(this.saveFileDialog.FileName);
			}
			this.Text = "STL : \"" + this.saveFileDialog.FileName + "\"";
		}

		public void save_stl(string path)
		{
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create));
			binaryWriter.Write(Convert.ToByte(this.stlType.Length));
			byte[] bytes = Encoding.UTF8.GetBytes(this.stlType);
			binaryWriter.Write(bytes, 0, bytes.Length);
			this.entry_count = 0u;
			int num;
			for (num = 0; num != this.dataGridView.RowCount; num++)
			{
				if (this.dataGridView.Rows[num].Cells[0].Value != null)
				{
					this.entry_count += 1u;
				}
			}
			binaryWriter.Write(this.entry_count);
			this.ids = new STLForm.ID[this.entry_count];
			int num2 = 0;
			for (num = 0; num != this.dataGridView.RowCount; num++)
			{
				if (this.dataGridView.Rows[num].Cells[0].Value != null)
				{
					this.ids[num2].stringID = this.dataGridView.Rows[num].Cells[0].Value.ToString();
					byte[] bytes2 = Encoding.UTF8.GetBytes(this.dataGridView.Rows[num].Cells[0].Value.ToString());
					binaryWriter.Write(Convert.ToByte(bytes2.Length));
					binaryWriter.Write(bytes2, 0, bytes2.Length);
					this.ids[num2].id = Convert.ToUInt32(num);
					binaryWriter.Write(num);
					num2++;
				}
			}
			binaryWriter.Write(this.language_count);
			int value = Convert.ToInt32(binaryWriter.BaseStream.Position + (long)((ulong)(this.language_count * 4u)));
			num = 0;
			while ((long)num != (long)((ulong)this.language_count))
			{
				binaryWriter.Write(value);
				num++;
			}
			int offset = Convert.ToInt32(binaryWriter.BaseStream.Position);
			num = 0;
			while ((long)num != (long)((ulong)this.entry_count))
			{
				binaryWriter.Write(Convert.ToInt32(0));
				num++;
			}
			int[] array = new int[this.entry_count];
			num = 0;
			while ((long)num != (long)((ulong)this.entry_count))
			{
				array[num] = Convert.ToInt32(binaryWriter.BaseStream.Position);
				if (this.dataGridView.Rows[Convert.ToInt32(this.ids[num].id)].Cells[1].Value != null)
				{
					byte[] bytes2 = Encoding.Default.GetBytes(this.dataGridView.Rows[Convert.ToInt32(this.ids[num].id)].Cells[1].Value.ToString());
					if (bytes2.Length < 128)
					{
						binaryWriter.Write(Convert.ToByte(bytes2.Length));
					}
					else
					{
						if (bytes2.Length < 256)
						{
							binaryWriter.Write(Convert.ToByte(bytes2.Length / 128));
						}
						else
						{
							binaryWriter.Write((int)(Convert.ToByte(bytes2.Length / 128 - 1) * 128));
						}
						binaryWriter.Write(Convert.ToByte(bytes2.Length));
					}
					binaryWriter.Write(bytes2, 0, bytes2.Length);
				}
				else
				{
					binaryWriter.Write(Convert.ToByte(0));
				}
				if (this.stlType == "QEST01" || this.stlType == "ITST01")
				{
					if (this.dataGridView.Rows[Convert.ToInt32(this.ids[num].id)].Cells[2].Value != null)
					{
						byte[] bytes3 = Encoding.Default.GetBytes(this.dataGridView.Rows[Convert.ToInt32(this.ids[num].id)].Cells[2].Value.ToString());
						if (bytes3.Length < 128)
						{
							binaryWriter.Write(Convert.ToByte(bytes3.Length));
						}
						else
						{
							if (bytes3.Length < 256)
							{
								binaryWriter.Write(Convert.ToByte(bytes3.Length / 128));
							}
							else
							{
								binaryWriter.Write((int)(Convert.ToByte(bytes3.Length / 128 - 1) * 128));
							}
							binaryWriter.Write(Convert.ToByte(bytes3.Length));
						}
						binaryWriter.Write(bytes3, 0, bytes3.Length);
					}
					else
					{
						binaryWriter.Write(Convert.ToByte(0));
					}
					if (this.stlType == "QEST01")
					{
						if (this.dataGridView.Rows[Convert.ToInt32(this.ids[num].id)].Cells[3].Value != null)
						{
							byte[] bytes4 = Encoding.Default.GetBytes(this.dataGridView.Rows[Convert.ToInt32(this.ids[num].id)].Cells[3].Value.ToString());
							if (bytes4.Length < 128)
							{
								binaryWriter.Write(Convert.ToByte(bytes4.Length));
							}
							else
							{
								if (bytes4.Length < 256)
								{
									binaryWriter.Write(Convert.ToByte(bytes4.Length / 128));
								}
								else
								{
									binaryWriter.Write((int)(Convert.ToByte(bytes4.Length / 128 - 1) * 128));
								}
								binaryWriter.Write(Convert.ToByte(bytes4.Length));
							}
							binaryWriter.Write(bytes4, 0, bytes4.Length);
						}
						else
						{
							binaryWriter.Write(Convert.ToByte(0));
						}
						if (this.dataGridView.Rows[Convert.ToInt32(this.ids[num].id)].Cells[3].Value != null)
						{
							byte[] bytes5 = Encoding.Default.GetBytes(this.dataGridView.Rows[Convert.ToInt32(this.ids[num].id)].Cells[4].Value.ToString());
							if (bytes5.Length < 128)
							{
								binaryWriter.Write(Convert.ToByte(bytes5.Length));
							}
							else
							{
								if (bytes5.Length < 256)
								{
									binaryWriter.Write(Convert.ToByte(bytes5.Length / 128));
								}
								else
								{
									binaryWriter.Write((int)(Convert.ToByte(bytes5.Length / 128 - 1) * 128));
								}
								binaryWriter.Write(Convert.ToByte(bytes5.Length));
							}
							binaryWriter.Write(bytes5, 0, bytes5.Length);
						}
						else
						{
							binaryWriter.Write(Convert.ToByte(0));
						}
					}
				}
				num++;
			}
			binaryWriter.Seek(offset, SeekOrigin.Begin);
			num = 0;
			while ((long)num != (long)((ulong)this.entry_count))
			{
				binaryWriter.Write(array[num]);
				num++;
			}
			binaryWriter.Close();
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string[] array = this.Text.Split(new char[]
			{
				'"'
			});
			this.save_stl(array[1]);
		}

		private void dataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.C)
			{
				this.copy();
				e.Handled = true;
			}
			else if (e.Control && e.KeyCode == Keys.V)
			{
				this.paste();
			}
		}

		private void copy()
		{
			DataObject clipboardContent = this.dataGridView.GetClipboardContent();
			Clipboard.SetDataObject(clipboardContent);
		}

		private void paste()
		{
			string text = Clipboard.GetText();
			char[] array = text.ToCharArray();
			text = "";
			for (int i = 0; i != array.Length; i++)
			{
				if (array[i] == '\r')
				{
					array[i] = ' ';
				}
				text += array[i];
			}
			string[] array2 = text.Split(new char[]
			{
				'\n'
			});
			int num = this.dataGridView.CurrentCell.RowIndex;
			int columnIndex = this.dataGridView.CurrentCell.ColumnIndex;
			for (int num2 = 0; num2 != array2.Length; num2++)
			{
				if (num >= this.dataGridView.RowCount || array2[num2].Length <= 0)
				{
					break;
				}
				string[] array3 = array2[num2].Split(new char[]
				{
					'\t'
				});
				for (int i = 0; i < array3.GetLength(0); i++)
				{
					if (columnIndex + i >= this.dataGridView.ColumnCount)
					{
						break;
					}
					this.dataGridView[columnIndex + i, num].Value = Convert.ChangeType(array3[i], this.dataGridView[columnIndex + i, num].ValueType);
				}
				num++;
			}
		}

		private void paste_click()
		{
			string text = Clipboard.GetText();
			string[] array = text.Split(new char[]
			{
				'\n'
			});
			int num = this.dataGridView.CurrentCell.RowIndex;
			int columnIndex = this.dataGridView.CurrentCell.ColumnIndex;
			for (int num2 = 0; num2 != array.Length; num2++)
			{
				if (num >= this.dataGridView.RowCount || array[num2].Length <= 0)
				{
					break;
				}
				string[] array2 = array[num2].Split(new char[]
				{
					'\t'
				});
				for (int i = 1; i < array2.GetLength(0); i++)
				{
					if (i >= this.dataGridView.ColumnCount)
					{
						break;
					}
					this.dataGridView[i, num].Value = Convert.ChangeType(array2[i], this.dataGridView[i, num].ValueType);
				}
				num++;
			}
		}

		private void InfoButton_Click_1(object sender, EventArgs e)
		{
			try
			{
				this.dataGridView.FirstDisplayedScrollingRowIndex = Convert.ToInt32(this.InfotextBox.Text);
				this.dataGridView.Rows[Convert.ToInt32(this.InfotextBox.Text)].Selected = true;
			}
			catch (Exception var_0_48)
			{
				this.toolStripStatusLabel.Text = "Invalid row";
			}
		}

		private void InfolistBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.search_result.Length > 0)
			{
				int num = Convert.ToInt32(this.search_result[this.InfolistBox.SelectedIndex]);
				this.dataGridView.FirstDisplayedScrollingRowIndex = num;
				this.dataGridView.Rows[Convert.ToInt32(num)].Selected = true;
			}
		}

		private void checkBoxLangage_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkBoxLangage.Checked)
			{
				this.comboBoxlangage.Enabled = true;
			}
			else
			{
				this.comboBoxlangage.Enabled = false;
			}
		}

		private void STLForm_Resize(object sender, EventArgs e)
		{
			int num = base.Width - 680;
			int num2 = base.Height - 600;
			this.dataGridView.Width = 609 + num;
			this.dataGridView.Height = 498 + num2;
			this.splitContainer1.SplitterDistance = 640 + num;
		}
	}
}
