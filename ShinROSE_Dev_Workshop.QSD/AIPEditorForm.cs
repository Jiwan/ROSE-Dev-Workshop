using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop.QSD
{
	public class AIPEditorForm : Form
	{
		private struct Blck
		{
			public int record_count;

			public string block_name;

			public AIPEditorForm.rcrd[] record;

			public bool deleted;
		}

		private struct rcrd
		{
			public byte if_else;

			public bool deleted;

			public int condition_count;

			public int action_count;

			public string record_name;

			public AIPEditorForm.cdtn[] condition;

			public AIPEditorForm.actn[] action;
		}

		private struct cdtn
		{
			public bool deleted;

			public int length;

			public int command;

			public byte[] data;
		}

		private struct actn
		{
			public bool deleted;

			public int length;

			public int command;

			public byte[] data;
		}

		private int file_version;

		private int block_count;

		private string qsd_name;

		private string executableDirectoryName;

		private AIPEditorForm.Blck[] block;

		private IContainer components = null;

		private MenuStrip menuStrip;

		private ToolStripMenuItem fileToolStripMenuItem;

		private ToolStripMenuItem openToolStripMenuItem;

		private ToolStripMenuItem exitToolStripMenuItem;

		private StatusStrip statusStrip1;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem saveToolStripMenuItem;

		private ToolStripMenuItem saveAsToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem toolsToolStripMenuItem;

		private ToolStripMenuItem searchToolStripMenuItem;

		private Label labelQSDName;

		private TextBox textBoxQSDName;

		private TreeView treeView;

		private Label labelFileVersion;

		private Label labelBlockCount;

		private GroupBox groupBoxData;

		private GroupBox groupBoxInfo;

		private OpenFileDialog openFileDialog;

		private RichTextBox richTextBoxDataDump;

		private Label labelDataDump2;

		private DataGridView dataGridView;

		private Button buttonConditionApply;

		private ContextMenuStrip contextMenuStripBlock;

		private ToolStripMenuItem renameToolStripMenuItem;

		private ToolStripMenuItem deletedToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripMenuItem addToolStripMenuItem;

		private ContextMenuStrip contextMenuStripRecord;

		private ToolStripMenuItem RenameRecordtoolStripMenuItem;

		private ToolStripMenuItem DeletedRecordtoolStripMenuItem;

		private ContextMenuStrip contextMenuStripCondition;

		private ToolStripMenuItem AddConditiontoolStripMenuItem;

		private ContextMenuStrip contextMenuStripAction;

		private ToolStripMenuItem toolStripMenuItem4;

		private ToolStripMenuItem addBlockToolStripMenuItem;

		private ToolStripStatusLabel StatusLabel;

		private SaveFileDialog saveFileDialog;

		private ContextMenuStrip contextMenuStripData;

		private ToolStripMenuItem changeByToolStripMenuItem;

		private ToolStripMenuItem deletedToolStripMenuItem1;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem newToolStripMenuItem;

		public AIPEditorForm()
		{
			this.InitializeComponent();
			string executablePath = Application.ExecutablePath;
			FileInfo fileInfo = new FileInfo(executablePath);
			this.executableDirectoryName = fileInfo.DirectoryName;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.treeView.Nodes.Clear();
				this.load_qsd_info(this.openFileDialog.FileName);
				this.Text = "QSD :\"" + this.openFileDialog.FileName + "\"";
				this.StatusLabel.Text = "Statut : " + this.openFileDialog.FileName + "succefully load";
			}
			this.contextMenuStripAction.Enabled = true;
			this.contextMenuStripCondition.Enabled = true;
			this.contextMenuStripData.Enabled = true;
			this.contextMenuStripRecord.Enabled = true;
			this.contextMenuStripBlock.Enabled = true;
			this.textBoxQSDName.Enabled = true;
		}

		public void load_qsd_info(string path)
		{
			this.contextMenuStripAction.Enabled = true;
			this.contextMenuStripCondition.Enabled = true;
			this.contextMenuStripData.Enabled = true;
			this.contextMenuStripRecord.Enabled = true;
			this.contextMenuStripBlock.Enabled = true;
			this.textBoxQSDName.Enabled = true;
			BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open), Encoding.GetEncoding("EUC-KR"));
			this.file_version = binaryReader.ReadInt32();
			this.labelFileVersion.Text = "File version :" + this.file_version.ToString();
			this.block_count = binaryReader.ReadInt32();
			this.labelBlockCount.Text = "Block count :" + this.block_count.ToString();
			short count = binaryReader.ReadInt16();
			this.qsd_name = Encoding.UTF7.GetString(binaryReader.ReadBytes((int)count));
			this.textBoxQSDName.Text = this.qsd_name;
			this.block = new AIPEditorForm.Blck[this.block_count];
			for (int num = 0; num != this.block_count; num++)
			{
				this.block[num].record_count = binaryReader.ReadInt32();
				count = binaryReader.ReadInt16();
				this.block[num].block_name = Encoding.UTF7.GetString(binaryReader.ReadBytes((int)count));
				this.treeView.Nodes.Add(this.block[num].block_name);
				this.block[num].record = new AIPEditorForm.rcrd[this.block[num].record_count];
				for (int num2 = 0; num2 != this.block[num].record_count; num2++)
				{
					this.block[num].record[num2].if_else = binaryReader.ReadByte();
					this.block[num].record[num2].condition_count = binaryReader.ReadInt32();
					this.block[num].record[num2].action_count = binaryReader.ReadInt32();
					count = binaryReader.ReadInt16();
					this.block[num].record[num2].record_name = Encoding.UTF7.GetString(binaryReader.ReadBytes((int)count));
					this.treeView.Nodes[num].Nodes.Add(this.block[num].record[num2].record_name);
					this.treeView.Nodes[num].Nodes[num2].Nodes.Add("Condition(" + this.block[num].record[num2].condition_count.ToString() + ")");
					this.treeView.Nodes[num].Nodes[num2].Nodes.Add("Action(" + this.block[num].record[num2].action_count.ToString() + ")");
					this.block[num].record[num2].condition = new AIPEditorForm.cdtn[this.block[num].record[num2].condition_count];
					for (int num3 = 0; num3 != this.block[num].record[num2].condition_count; num3++)
					{
						this.block[num].record[num2].condition[num3].length = binaryReader.ReadInt32();
						this.block[num].record[num2].condition[num3].command = binaryReader.ReadInt32();
						this.block[num].record[num2].condition[num3].data = new byte[this.block[num].record[num2].condition[num3].length - 8];
						this.block[num].record[num2].condition[num3].data = binaryReader.ReadBytes(this.block[num].record[num2].condition[num3].length - 8);
						Condition condition = new Condition();
						string text = condition.find_condition_name("0x" + this.block[num].record[num2].condition[num3].command.ToString("X"), this.executableDirectoryName);
						this.treeView.Nodes[num].Nodes[num2].Nodes[0].Nodes.Add(text);
					}
					this.block[num].record[num2].action = new AIPEditorForm.actn[this.block[num].record[num2].action_count];
					for (int num4 = 0; num4 != this.block[num].record[num2].action_count; num4++)
					{
						this.block[num].record[num2].action[num4].length = binaryReader.ReadInt32();
						this.block[num].record[num2].action[num4].command = binaryReader.ReadInt32();
						this.block[num].record[num2].action[num4].data = new byte[this.block[num].record[num2].action[num4].length - 8];
						this.block[num].record[num2].action[num4].data = binaryReader.ReadBytes(this.block[num].record[num2].action[num4].length - 8);
						Action action = new Action();
						string text = action.find_action_name("0x" + this.block[num].record[num2].action[num4].command.ToString("X"), this.executableDirectoryName);
						this.treeView.Nodes[num].Nodes[num2].Nodes[1].Nodes.Add(text);
					}
				}
			}
			binaryReader.Close();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (this.treeView.SelectedNode.Level == 0)
			{
				this.treeView.ContextMenuStrip = this.contextMenuStripBlock;
			}
			else if (this.treeView.SelectedNode.Level == 1)
			{
				this.treeView.ContextMenuStrip = this.contextMenuStripRecord;
			}
			else if (this.treeView.SelectedNode.Level == 2 && this.treeView.SelectedNode.Index == 0)
			{
				this.treeView.ContextMenuStrip = this.contextMenuStripCondition;
			}
			else if (this.treeView.SelectedNode.Level == 2 && this.treeView.SelectedNode.Index == 1)
			{
				this.treeView.ContextMenuStrip = this.contextMenuStripAction;
			}
			else if (this.treeView.SelectedNode.Level == 3)
			{
				this.treeView.ContextMenuStrip = this.contextMenuStripData;
				TreeNode parent = this.treeView.SelectedNode.Parent;
				if (parent.Index == 0)
				{
					TreeNode parent2 = parent.Parent;
					TreeNode parent3 = parent2.Parent;
					this.richTextBoxDataDump.Text = "";
					this.richTextBoxDataDump.Text = this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].data[0].ToString("X");
					for (int num = 1; num != this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].data.Length; num++)
					{
						this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-" + this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].data[num].ToString("X");
					}
					string[] array = new string[0];
					string[] array2 = new string[0];
					Condition condition = new Condition();
					if (condition.part_count("0x" + this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].command.ToString("X"), ref array, ref array2, this.executableDirectoryName))
					{
						this.richTextBoxDataDump.Enabled = false;
						this.dataGridView.Show();
						this.dataGridView.ColumnCount = array.Length;
						int num2 = 0;
						for (int num = 0; num != array.Length; num++)
						{
							this.dataGridView.Columns[num].Name = array[num] + " (" + array2[num] + ")";
							if (array2[num] == "Int32")
							{
								int num3 = BitConverter.ToInt32(this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].data, num2);
								this.dataGridView.Rows[0].Cells[num].Value = num3.ToString();
								num2 += 4;
							}
							else if (array2[num] == "Byte")
							{
								byte b = this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].data[num2];
								this.dataGridView.Rows[0].Cells[num].Value = b.ToString();
								num2++;
							}
							else if (array2[num] == "Int16")
							{
								short num4 = BitConverter.ToInt16(this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].data, num2);
								this.dataGridView.Rows[0].Cells[num].Value = num4.ToString();
								num2 += 2;
							}
							else if (array2[num] == "Operator32")
							{
								string value = this.byte_to_operator(this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].data[num2]);
								this.dataGridView.Rows[0].Cells[num].Value = value;
								num2 += 4;
							}
							else if (array2[num] == "Operator16")
							{
								string value = this.byte_to_operator(this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].data[num2]);
								this.dataGridView.Rows[0].Cells[num].Value = value;
								num2 += 2;
							}
							else if (array2[num] == "Operator")
							{
								string value = this.byte_to_operator(this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].data[num2]);
								this.dataGridView.Rows[0].Cells[num].Value = value;
								num2++;
							}
							else if (array2[num] == "Trigger")
							{
								short num5 = BitConverter.ToInt16(this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].data, num2);
								if (num5 >= 2)
								{
									num2 += 2;
									int num6 = 0;
									for (int num7 = 0; num7 != (int)(num5 - 2); num7++)
									{
										num6 += (int)(this.block[parent3.Index].record[parent2.Index].condition[this.treeView.SelectedNode.Index].data[num2] - 30);
									}
									this.dataGridView.Rows[0].Cells[num].Value = num6;
									num2 += (int)num5;
								}
							}
							else
							{
								this.dataGridView.Rows[0].Cells[num].Value = "Null(Give it a value rapidly)";
							}
						}
					}
					else
					{
						this.richTextBoxDataDump.Enabled = true;
						this.dataGridView.Hide();
					}
				}
				else if (parent.Index == 1)
				{
					TreeNode parent2 = parent.Parent;
					TreeNode parent3 = parent2.Parent;
					this.richTextBoxDataDump.Text = "";
					this.richTextBoxDataDump.Text = this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].data[0].ToString("X");
					for (int num = 1; num != this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].data.Length; num++)
					{
						this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-" + this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].data[num].ToString("X");
					}
					string[] array = new string[0];
					string[] array2 = new string[0];
					Action action = new Action();
					if (action.part_count("0x" + this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].command.ToString("X"), ref array, ref array2, this.executableDirectoryName))
					{
						this.richTextBoxDataDump.Enabled = false;
						this.dataGridView.Show();
						this.dataGridView.ColumnCount = array.Length;
						int num2 = 0;
						for (int num = 0; num != array.Length; num++)
						{
							this.dataGridView.Columns[num].Name = array[num] + " (" + array2[num] + ")";
							if (array2[num] == "Int32")
							{
								int num3 = BitConverter.ToInt32(this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].data, num2);
								this.dataGridView.Rows[0].Cells[num].Value = num3.ToString();
								num2 += 4;
							}
							else if (array2[num] == "Byte")
							{
								byte b = this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].data[num2];
								this.dataGridView.Rows[0].Cells[num].Value = b.ToString();
								num2++;
							}
							else if (array2[num] == "Int16")
							{
								short num4 = BitConverter.ToInt16(this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].data, num2);
								this.dataGridView.Rows[0].Cells[num].Value = num4.ToString();
								num2 += 2;
							}
							else if (array2[num] == "Operator32")
							{
								string value = this.byte_to_operator(this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].data[num2]);
								this.dataGridView.Rows[0].Cells[num].Value = value;
								num2 += 4;
							}
							else if (array2[num] == "Operator16")
							{
								string value = this.byte_to_operator(this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].data[num2]);
								this.dataGridView.Rows[0].Cells[num].Value = value;
								num2 += 2;
							}
							else if (array2[num] == "Operator")
							{
								string value = this.byte_to_operator(this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].data[num2]);
								this.dataGridView.Rows[0].Cells[num].Value = value;
								num2++;
							}
							else if (array2[num] == "Trigger")
							{
								short num5 = BitConverter.ToInt16(this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].data, num2);
								if (num5 >= 2)
								{
									num2 += 2;
									string text = "";
									for (int num7 = 0; num7 != (int)(num5 - 1); num7++)
									{
										text += ((int)(this.block[parent3.Index].record[parent2.Index].action[this.treeView.SelectedNode.Index].data[num2] - 48)).ToString();
										num2++;
									}
									this.dataGridView.Rows[0].Cells[num].Value = text;
									num2 += (int)num5;
								}
								else
								{
									this.dataGridView.Rows[0].Cells[num].Value = "Null(Give it a value rapidly)";
								}
							}
						}
					}
					else
					{
						this.richTextBoxDataDump.Enabled = true;
						this.dataGridView.Hide();
					}
				}
			}
		}

		private void addBlockToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.block_count++;
			AIPEditorForm.Blck[] array = new AIPEditorForm.Blck[this.block_count];
			for (int num = 0; num != this.block.Length; num++)
			{
				array[num] = this.block[num];
			}
			this.block = new AIPEditorForm.Blck[this.block_count];
			for (int num = 0; num != array.Length; num++)
			{
				this.block[num] = array[num];
			}
			this.block[this.block_count - 1].block_name = "New block";
			this.block[this.block_count - 1].record_count = 0;
			this.block[this.block_count - 1].record = new AIPEditorForm.rcrd[0];
			this.treeView.Nodes.Add("New Block");
		}

		private void renameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Description description = new Description();
			description.labelName.Text = "New name";
			description.textBox.Text = this.treeView.SelectedNode.Text;
			if (description.ShowDialog() == DialogResult.OK)
			{
				this.treeView.SelectedNode.Text = description.textBox.Text;
				this.block[this.treeView.SelectedNode.Index].block_name = description.textBox.Text;
			}
		}

		private void deletedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.treeView.SelectedNode.Text != "<*DELETED*>")
			{
				this.block_count--;
				this.block[this.treeView.SelectedNode.Index].deleted = true;
				TreeNode selectedNode = this.treeView.SelectedNode;
				selectedNode.Text = "<*DELETED*>";
				selectedNode.ForeColor = Color.Red;
				selectedNode.Nodes.Clear();
			}
		}

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AIPEditorForm.rcrd[] array = new AIPEditorForm.rcrd[this.treeView.SelectedNode.Nodes.Count + 1];
			for (int num = 0; num != this.block[this.treeView.SelectedNode.Index].record_count; num++)
			{
				array[num] = this.block[this.treeView.SelectedNode.Index].record[num];
			}
			this.block[this.treeView.SelectedNode.Index].record = new AIPEditorForm.rcrd[this.block[this.treeView.SelectedNode.Index].record_count + 1];
			this.block[this.treeView.SelectedNode.Index].record_count = this.block[this.treeView.SelectedNode.Index].record_count + 1;
			for (int num = 0; num != this.block[this.treeView.SelectedNode.Index].record.Length; num++)
			{
				this.block[this.treeView.SelectedNode.Index].record[num] = array[num];
			}
			this.block[this.treeView.SelectedNode.Index].record[this.block[this.treeView.SelectedNode.Index].record_count - 1].action_count = 0;
			this.block[this.treeView.SelectedNode.Index].record[this.block[this.treeView.SelectedNode.Index].record_count - 1].condition_count = 0;
			this.block[this.treeView.SelectedNode.Index].record[this.block[this.treeView.SelectedNode.Index].record_count - 1].if_else = 0;
			this.block[this.treeView.SelectedNode.Index].record[this.block[this.treeView.SelectedNode.Index].record_count - 1].record_name = "New record";
			this.block[this.treeView.SelectedNode.Index].record[this.block[this.treeView.SelectedNode.Index].record_count - 1].condition = new AIPEditorForm.cdtn[0];
			this.block[this.treeView.SelectedNode.Index].record[this.block[this.treeView.SelectedNode.Index].record_count - 1].action = new AIPEditorForm.actn[0];
			TreeNode treeNode = new TreeNode();
			treeNode.Text = "New record";
			treeNode.Nodes.Add("Condition(0)");
			treeNode.Nodes.Add("Action(0)");
			this.treeView.SelectedNode.Nodes.Add(treeNode);
		}

		private void RenameRecordtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			Description description = new Description();
			description.labelName.Text = "New name";
			description.textBox.Text = this.treeView.SelectedNode.Text;
			if (description.ShowDialog() == DialogResult.OK)
			{
				this.treeView.SelectedNode.Text = description.textBox.Text;
				this.block[this.treeView.SelectedNode.Parent.Index].record[this.treeView.SelectedNode.Index].record_name = description.textBox.Text;
			}
		}

		private void AddConditiontoolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode parent = this.treeView.SelectedNode.Parent;
			TreeNode parent2 = parent.Parent;
			AIPEditorForm.cdtn[] array = new AIPEditorForm.cdtn[this.block[parent2.Index].record[parent.Index].condition_count];
			for (int num = 0; num != this.block[parent2.Index].record[parent.Index].condition_count; num++)
			{
				array[num] = this.block[parent2.Index].record[parent.Index].condition[num];
			}
			AIPEditorForm.rcrd[] expr_DF_cp_0 = this.block[parent2.Index].record;
			int expr_DF_cp_1 = parent.Index;
			expr_DF_cp_0[expr_DF_cp_1].condition_count = expr_DF_cp_0[expr_DF_cp_1].condition_count + 1;
			this.block[parent2.Index].record[parent.Index].condition = new AIPEditorForm.cdtn[this.block[parent2.Index].record[parent.Index].condition_count];
			for (int num = 0; num != array.Length; num++)
			{
				this.block[parent2.Index].record[parent.Index].condition[num] = array[num];
			}
			this.block[parent2.Index].record[parent.Index].condition[array.Length].command = 0;
			byte[] array2 = new byte[4];
			byte[] data = array2;
			this.block[parent2.Index].record[parent.Index].condition[array.Length].data = data;
			this.treeView.SelectedNode.Nodes.Add("New condition");
			this.treeView.SelectedNode.Text = "Condition(" + this.treeView.SelectedNode.Nodes.Count.ToString() + ")";
		}

		private void toolStripMenuItem4_Click(object sender, EventArgs e)
		{
			TreeNode parent = this.treeView.SelectedNode.Parent;
			TreeNode parent2 = parent.Parent;
			AIPEditorForm.actn[] array = new AIPEditorForm.actn[this.block[parent2.Index].record[parent.Index].action_count];
			for (int num = 0; num != this.block[parent2.Index].record[parent.Index].action_count; num++)
			{
				array[num] = this.block[parent2.Index].record[parent.Index].action[num];
			}
			AIPEditorForm.rcrd[] expr_DF_cp_0 = this.block[parent2.Index].record;
			int expr_DF_cp_1 = parent.Index;
			expr_DF_cp_0[expr_DF_cp_1].action_count = expr_DF_cp_0[expr_DF_cp_1].action_count + 1;
			this.block[parent2.Index].record[parent.Index].action = new AIPEditorForm.actn[this.block[parent2.Index].record[parent.Index].action_count];
			for (int num = 0; num != array.Length; num++)
			{
				this.block[parent2.Index].record[parent.Index].action[num] = array[num];
			}
			this.block[parent2.Index].record[parent.Index].action[array.Length].command = 0;
			byte[] array2 = new byte[4];
			byte[] data = array2;
			this.block[parent2.Index].record[parent.Index].action[array.Length].data = data;
			this.treeView.SelectedNode.Nodes.Add("New action");
			this.treeView.SelectedNode.Text = "Action(" + this.treeView.SelectedNode.Nodes.Count.ToString() + ")";
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox aboutBox = new AboutBox();
			aboutBox.ShowDialog();
		}

		private void DeletedRecordtoolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.treeView.SelectedNode.Text != "<*DELETED*>")
			{
				AIPEditorForm.Blck[] expr_46_cp_0 = this.block;
				int expr_46_cp_1 = this.treeView.SelectedNode.Parent.Index;
				expr_46_cp_0[expr_46_cp_1].record_count = expr_46_cp_0[expr_46_cp_1].record_count - 1;
				this.block[this.treeView.SelectedNode.Parent.Index].record[this.treeView.SelectedNode.Index].deleted = true;
				TreeNode selectedNode = this.treeView.SelectedNode;
				selectedNode.Text = "<*DELETED*>";
				selectedNode.ForeColor = Color.Green;
				selectedNode.Nodes.Clear();
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.save_qsd(this.saveFileDialog.FileName);
				this.Text = "QSD : \"" + this.saveFileDialog.FileName + "\"";
				this.StatusLabel.Text = "Statut : Save " + this.saveFileDialog.FileName;
			}
		}

		private void save_qsd(string path)
		{
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create));
			binaryWriter.Write(this.file_version);
			binaryWriter.Write(this.block_count);
			binaryWriter.Write(Convert.ToInt16(this.qsd_name.Length));
			byte[] bytes = Encoding.Default.GetBytes(this.qsd_name);
			binaryWriter.Write(bytes, 0, bytes.Length);
			for (int num = 0; num != this.block.Length; num++)
			{
				if (!this.block[num].deleted)
				{
					binaryWriter.Write(this.block[num].record_count);
					binaryWriter.Write(Convert.ToInt16(this.block[num].block_name.Length));
					byte[] bytes2 = Encoding.Default.GetBytes(this.block[num].block_name);
					binaryWriter.Write(bytes2, 0, bytes2.Length);
					for (int num2 = 0; num2 != this.block[num].record.Length; num2++)
					{
						if (!this.block[num].record[num2].deleted)
						{
							binaryWriter.Write(this.block[num].record[num2].if_else);
							binaryWriter.Write(this.block[num].record[num2].condition_count);
							binaryWriter.Write(this.block[num].record[num2].action_count);
							binaryWriter.Write(Convert.ToInt16(this.block[num].record[num2].record_name.Length));
							byte[] bytes3 = Encoding.Default.GetBytes(this.block[num].record[num2].record_name);
							binaryWriter.Write(bytes3, 0, bytes3.Length);
							for (int num3 = 0; num3 != this.block[num].record[num2].condition.Length; num3++)
							{
								if (!this.block[num].record[num2].condition[num3].deleted)
								{
									binaryWriter.Write(this.block[num].record[num2].condition[num3].length);
									binaryWriter.Write(this.block[num].record[num2].condition[num3].command);
									binaryWriter.Write(this.block[num].record[num2].condition[num3].data);
								}
							}
							for (int num3 = 0; num3 != this.block[num].record[num2].action.Length; num3++)
							{
								if (!this.block[num].record[num2].action[num3].deleted)
								{
									binaryWriter.Write(this.block[num].record[num2].action[num3].length);
									binaryWriter.Write(this.block[num].record[num2].action[num3].command);
									binaryWriter.Write(this.block[num].record[num2].action[num3].data);
								}
							}
						}
					}
				}
			}
			binaryWriter.Close();
		}

		private void changeByToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = this.treeView.SelectedNode;
			TreeNode parent = selectedNode.Parent;
			TreeNode parent2 = parent.Parent;
			TreeNode parent3 = parent2.Parent;
			if (parent.Index == 0)
			{
				ChangeDataDialog changeDataDialog = new ChangeDataDialog();
				changeDataDialog.import_opcode_condition(this.executableDirectoryName);
				if (changeDataDialog.ShowDialog() == DialogResult.OK)
				{
					selectedNode.Text = changeDataDialog.data_select + " (" + changeDataDialog.opcode_select + ")";
					if (changeDataDialog.data_select == "Unknow Opcode")
					{
						this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].command = int.Parse(changeDataDialog.opcode_select.Remove(0, 2), NumberStyles.HexNumber);
						this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].length = 8;
						this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data = new byte[1];
					}
					else
					{
						string[] array = new string[0];
						string[] array2 = new string[0];
						Condition condition = new Condition();
						condition.part_count(changeDataDialog.opcode_select, ref array, ref array2, this.executableDirectoryName);
						this.dataGridView.ColumnCount = array.Length;
						this.richTextBoxDataDump.Text = "";
						this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].command = int.Parse(changeDataDialog.opcode_select.Remove(0, 2), NumberStyles.HexNumber);
						int num = 0;
						for (int num2 = 0; num2 != array.Length; num2++)
						{
							if (array2[num2] == "Int32")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "0-0-0-0";
								num += 4;
								this.dataGridView.Rows[0].Cells[num2].Value = 0;
							}
							else if (array2[num2] == "Byte")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-0";
								num++;
								this.dataGridView.Rows[0].Cells[num2].Value = 0;
							}
							else if (array2[num2] == "Int16")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-0-0";
								num += 2;
								this.dataGridView.Rows[0].Cells[num2].Value = 0;
							}
							else if (array2[num2] == "Operator32")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "0-0-0-0";
								num += 4;
								this.dataGridView.Rows[0].Cells[num2].Value = "==";
							}
							else if (array2[num2] == "Operator16")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-0-0";
								num += 2;
								this.dataGridView.Rows[0].Cells[num2].Value = "==";
							}
							else if (array2[num2] == "Operator")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-0";
								num++;
								this.dataGridView.Rows[0].Cells[num2].Value = "==";
							}
							else if (array2[num2] == "Trigger")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-02-0-30-0-0";
								num += 5;
								this.dataGridView.Rows[0].Cells[num2].Value = "Null(Give it a value rapidly)";
							}
						}
						this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].length = num + 8;
						this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data = new byte[num];
					}
				}
			}
			else if (parent.Index == 1)
			{
				ChangeDataDialog changeDataDialog = new ChangeDataDialog();
				changeDataDialog.import_opcode_action(this.executableDirectoryName);
				if (changeDataDialog.ShowDialog() == DialogResult.OK)
				{
					selectedNode.Text = changeDataDialog.data_select + " (" + changeDataDialog.opcode_select + ")";
					if (changeDataDialog.data_select == "Unknow Opcode")
					{
						this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].command = int.Parse(changeDataDialog.opcode_select.Remove(0, 2), NumberStyles.HexNumber);
						this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].length = 8;
						this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data = new byte[1];
					}
					else
					{
						string[] array = new string[0];
						string[] array2 = new string[0];
						Action action = new Action();
						action.part_count(changeDataDialog.opcode_select, ref array, ref array2, this.executableDirectoryName);
						this.dataGridView.ColumnCount = array.Length;
						this.richTextBoxDataDump.Text = "";
						this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].command = int.Parse(changeDataDialog.opcode_select.Remove(0, 2), NumberStyles.HexNumber);
						int num = 0;
						for (int num2 = 0; num2 != array.Length; num2++)
						{
							if (array2[num2] == "Int32")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "0-0-0-0";
								num += 4;
								this.dataGridView.Rows[0].Cells[num2].Value = 0;
							}
							else if (array2[num2] == "Byte")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-0";
								num++;
								this.dataGridView.Rows[0].Cells[num2].Value = 0;
							}
							else if (array2[num2] == "Int16")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-0";
								num += 2;
								this.dataGridView.Rows[0].Cells[num2].Value = 0;
							}
							else if (array2[num2] == "Operator32")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "0-0-0-0";
								num += 4;
								this.dataGridView.Rows[0].Cells[num2].Value = "==";
							}
							else if (array2[num2] == "Operator16")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-0-0";
								num += 2;
								this.dataGridView.Rows[0].Cells[num2].Value = "==";
							}
							else if (array2[num2] == "Operator")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-0";
								num++;
								this.dataGridView.Rows[0].Cells[num2].Value = "==";
							}
							else if (array2[num2] == "Trigger")
							{
								this.dataGridView.Columns[num2].Name = array[num2] + " (" + array2[num2] + ")";
								this.richTextBoxDataDump.Text = this.richTextBoxDataDump.Text + "-02-0-30-0-0";
								num += 5;
								this.dataGridView.Rows[0].Cells[num2].Value = "Null(Give it a value rapidly)";
							}
						}
						this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].length = num + 8;
						this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data = new byte[num];
					}
				}
			}
		}

		private void deletedToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (this.treeView.SelectedNode.Text != "<*DELETED*>")
			{
				TreeNode selectedNode = this.treeView.SelectedNode;
				TreeNode parent = selectedNode.Parent;
				TreeNode parent2 = parent.Parent;
				TreeNode parent3 = parent2.Parent;
				selectedNode.Text = "<*DELETED*>";
				selectedNode.ForeColor = Color.Blue;
				selectedNode.Nodes.Clear();
				if (parent.Index == 0)
				{
					AIPEditorForm.rcrd[] expr_A1_cp_0 = this.block[parent3.Index].record;
					int expr_A1_cp_1 = parent2.Index;
					expr_A1_cp_0[expr_A1_cp_1].condition_count = expr_A1_cp_0[expr_A1_cp_1].condition_count - 1;
					this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].deleted = true;
				}
				else if (parent.Index == 1)
				{
					AIPEditorForm.rcrd[] expr_11C_cp_0 = this.block[parent3.Index].record;
					int expr_11C_cp_1 = parent2.Index;
					expr_11C_cp_0[expr_11C_cp_1].action_count = expr_11C_cp_0[expr_11C_cp_1].action_count - 1;
					this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].deleted = true;
				}
			}
		}

		private void buttonConditionApply_Click(object sender, EventArgs e)
		{
			if (this.treeView.SelectedNode.Level == 3)
			{
				TreeNode selectedNode = this.treeView.SelectedNode;
				TreeNode parent = selectedNode.Parent;
				TreeNode parent2 = parent.Parent;
				TreeNode parent3 = parent2.Parent;
				if (parent.Index == 0)
				{
					if (this.richTextBoxDataDump.Enabled)
					{
						string[] array = this.richTextBoxDataDump.Text.Split(new char[]
						{
							'-'
						});
						this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].length = array.Length + 8;
						this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data = new byte[this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].length - 8];
						for (int num = 0; num != array.Length; num++)
						{
							this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data[num] = byte.Parse(array[num], NumberStyles.HexNumber);
						}
					}
					else
					{
						string[] array2 = new string[0];
						string[] array3 = new string[0];
						Condition condition = new Condition();
						condition.part_count("0x" + this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].command.ToString("X"), ref array2, ref array3, this.executableDirectoryName);
						int num2 = 0;
						for (int num = 0; num != array3.Length; num++)
						{
							if (array3[num] == "Int32")
							{
								int value = Convert.ToInt32(this.dataGridView.Rows[0].Cells[num].Value);
								byte[] bytes = BitConverter.GetBytes(value);
								for (int num3 = 0; num3 != 4; num3++)
								{
									this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data[num2] = bytes[num3];
									num2++;
								}
							}
							else if (array3[num] == "Int16")
							{
								short value2 = Convert.ToInt16(this.dataGridView.Rows[0].Cells[num].Value);
								byte[] bytes2 = BitConverter.GetBytes(value2);
								for (int num3 = 0; num3 != 2; num3++)
								{
									this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data[num2] = bytes2[num3];
									num2++;
								}
							}
							else if (array3[num] == "Byte")
							{
								this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data[num2] = Convert.ToByte(this.dataGridView.Rows[0].Cells[num].Value);
								num2++;
							}
							else if (array3[num] == "Operator32")
							{
								this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data[num2] = this.operator_to_byte(this.dataGridView.Rows[0].Cells[num].Value.ToString());
								num2 += 4;
							}
							else if (array3[num] == "Operator16")
							{
								this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data[num2] = this.operator_to_byte(this.dataGridView.Rows[0].Cells[num].Value.ToString());
								num2 += 2;
							}
							else if (array3[num] == "Operator")
							{
								this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data[num2] = this.operator_to_byte(this.dataGridView.Rows[0].Cells[num].Value.ToString());
								num2++;
							}
							else if (array3[num] == "Trigger")
							{
								short num4 = Convert.ToInt16(this.dataGridView.Rows[0].Cells[num].Value.ToString().Length + 1);
								byte[] data = this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data;
								this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data = new byte[num2 + 2 + (int)num4 + 1];
								for (int num5 = 0; num5 != num2; num5++)
								{
									this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data[num5] = data[num5];
								}
								char[] array4 = this.dataGridView.Rows[0].Cells[num].Value.ToString().ToCharArray();
								byte[] bytes3 = BitConverter.GetBytes(num4);
								for (int num3 = 0; num3 != 2; num3++)
								{
									this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data[num2] = bytes3[num3];
									num2++;
								}
								for (int num3 = 0; num3 != this.dataGridView.Rows[0].Cells[num].Value.ToString().Length; num3++)
								{
									int value3 = Convert.ToInt32(array4[num3].ToString()) + 48;
									this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].data[num2] = Convert.ToByte(value3);
									num2++;
								}
								this.block[parent3.Index].record[parent2.Index].condition[selectedNode.Index].length = num2 + 2 + 8;
							}
						}
					}
				}
				else if (parent.Index == 1)
				{
					if (this.richTextBoxDataDump.Enabled)
					{
						string[] array = this.richTextBoxDataDump.Text.Split(new char[]
						{
							'-'
						});
						this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].length = array.Length + 8;
						this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data = new byte[this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].length - 8];
						for (int num = 0; num != array.Length; num++)
						{
							this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data[num] = Convert.ToByte(array[num]);
						}
					}
					else
					{
						string[] array2 = new string[0];
						string[] array3 = new string[0];
						Action action = new Action();
						action.part_count("0x" + this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].command.ToString("X"), ref array2, ref array3, this.executableDirectoryName);
						int num2 = 0;
						for (int num = 0; num != array3.Length; num++)
						{
							if (array3[num] == "Int32")
							{
								int value = Convert.ToInt32(this.dataGridView.Rows[0].Cells[num].Value);
								byte[] bytes = BitConverter.GetBytes(value);
								for (int num3 = 0; num3 != 4; num3++)
								{
									this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data[num2] = bytes[num3];
									num2++;
								}
							}
							else if (array3[num] == "Int16")
							{
								short value2 = Convert.ToInt16(this.dataGridView.Rows[0].Cells[num].Value);
								byte[] bytes2 = BitConverter.GetBytes(value2);
								for (int num3 = 0; num3 != 2; num3++)
								{
									this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data[num2] = bytes2[num3];
									num2++;
								}
							}
							else if (array3[num] == "Byte")
							{
								this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data[num2] = Convert.ToByte(this.dataGridView.Rows[0].Cells[num].Value);
								num2++;
							}
							else if (array3[num] == "Operator32")
							{
								this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data[num2] = this.operator_to_byte(this.dataGridView.Rows[0].Cells[num].Value.ToString());
								num2 += 4;
							}
							else if (array3[num] == "Operator16")
							{
								this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data[num2] = this.operator_to_byte(this.dataGridView.Rows[0].Cells[num].Value.ToString());
								num2 += 2;
							}
							else if (array3[num] == "Operator")
							{
								this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data[num2] = this.operator_to_byte(this.dataGridView.Rows[0].Cells[num].Value.ToString());
								num2++;
							}
							else if (array3[num] == "Trigger")
							{
								short num4 = Convert.ToInt16(this.dataGridView.Rows[0].Cells[num].Value.ToString().Length + 1);
								byte[] data = this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data;
								this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data = new byte[num2 + 2 + (int)num4 + 1];
								for (int num5 = 0; num5 != num2; num5++)
								{
									this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data[num5] = data[num5];
								}
								char[] array4 = this.dataGridView.Rows[0].Cells[num].Value.ToString().ToCharArray();
								byte[] bytes3 = BitConverter.GetBytes(num4);
								for (int num3 = 0; num3 != 2; num3++)
								{
									this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data[num2] = bytes3[num3];
									num2++;
								}
								for (int num3 = 0; num3 != this.dataGridView.Rows[0].Cells[num].Value.ToString().Length; num3++)
								{
									int value3 = Convert.ToInt32(array4[num3].ToString()) + 48;
									this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].data[num2] = Convert.ToByte(value3);
									num2++;
								}
								this.block[parent3.Index].record[parent2.Index].action[selectedNode.Index].length = num2 + 2 + 8;
							}
						}
					}
				}
			}
		}

		private void textBoxQSDName_TextChanged(object sender, EventArgs e)
		{
			this.qsd_name = this.textBoxQSDName.Text;
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.StatusLabel.Text = "Statut : New qsd created";
			this.file_version = 0;
			this.textBoxQSDName.Text = "no name";
			this.qsd_name = "no name";
			this.treeView.Nodes.Clear();
			this.block_count = 1;
			this.block = new AIPEditorForm.Blck[1];
			this.treeView.Nodes.Add("New block");
			this.block[0].block_name = "New block";
			this.block[0].record_count = 0;
			this.block[0].record = new AIPEditorForm.rcrd[0];
			this.contextMenuStripAction.Enabled = true;
			this.contextMenuStripCondition.Enabled = true;
			this.contextMenuStripData.Enabled = true;
			this.contextMenuStripRecord.Enabled = true;
			this.contextMenuStripBlock.Enabled = true;
			this.textBoxQSDName.Enabled = true;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog.FileName != null)
			{
				this.save_qsd(this.openFileDialog.FileName);
				this.StatusLabel.Text = "Statut : Save " + this.openFileDialog.FileName;
			}
		}

		private string byte_to_operator(byte operator_byte)
		{
			string result;
			if (operator_byte == 0)
			{
				result = "==";
			}
			else if (operator_byte == 1)
			{
				result = ">";
			}
			else if (operator_byte == 2)
			{
				result = ">=";
			}
			else if (operator_byte == 3)
			{
				result = "<";
			}
			else if (operator_byte == 4)
			{
				result = "<=";
			}
			else if (operator_byte == 5)
			{
				result = "=";
			}
			else if (operator_byte == 6)
			{
				result = "+=";
			}
			else if (operator_byte == 7)
			{
				result = "-=";
			}
			else if (operator_byte == 8)
			{
				result = "OP8";
			}
			else if (operator_byte == 9)
			{
				result = "OP9";
			}
			else if (operator_byte == 10)
			{
				result = "OP10";
			}
			else
			{
				result = "Unknow Operator";
			}
			return result;
		}

		private byte operator_to_byte(string Operator_string)
		{
			byte result;
			if (Operator_string == "==")
			{
				result = 0;
			}
			else if (Operator_string == ">")
			{
				result = 1;
			}
			else if (Operator_string == ">=")
			{
				result = 2;
			}
			else if (Operator_string == "<")
			{
				result = 3;
			}
			else if (Operator_string == "<=")
			{
				result = 4;
			}
			else if (Operator_string == "=")
			{
				result = 5;
			}
			else if (Operator_string == "+=")
			{
				result = 6;
			}
			else if (Operator_string == "-=")
			{
				result = 7;
			}
			else if (Operator_string == "OP8")
			{
				result = 8;
			}
			else if (Operator_string == "OP9")
			{
				result = 9;
			}
			else if (Operator_string == "OP10")
			{
				result = 10;
			}
			else
			{
				result = 0;
			}
			return result;
		}

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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AIPEditorForm));
			this.menuStrip = new MenuStrip();
			this.fileToolStripMenuItem = new ToolStripMenuItem();
			this.openToolStripMenuItem = new ToolStripMenuItem();
			this.newToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.saveToolStripMenuItem = new ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.exitToolStripMenuItem = new ToolStripMenuItem();
			this.toolsToolStripMenuItem = new ToolStripMenuItem();
			this.searchToolStripMenuItem = new ToolStripMenuItem();
			this.statusStrip1 = new StatusStrip();
			this.StatusLabel = new ToolStripStatusLabel();
			this.labelQSDName = new Label();
			this.textBoxQSDName = new TextBox();
			this.treeView = new TreeView();
			this.contextMenuStripBlock = new ContextMenuStrip(this.components);
			this.addBlockToolStripMenuItem = new ToolStripMenuItem();
			this.renameToolStripMenuItem = new ToolStripMenuItem();
			this.deletedToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator3 = new ToolStripSeparator();
			this.addToolStripMenuItem = new ToolStripMenuItem();
			this.labelFileVersion = new Label();
			this.labelBlockCount = new Label();
			this.groupBoxData = new GroupBox();
			this.buttonConditionApply = new Button();
			this.dataGridView = new DataGridView();
			this.labelDataDump2 = new Label();
			this.richTextBoxDataDump = new RichTextBox();
			this.menuStrip1 = new MenuStrip();
			this.groupBoxInfo = new GroupBox();
			this.openFileDialog = new OpenFileDialog();
			this.contextMenuStripRecord = new ContextMenuStrip(this.components);
			this.RenameRecordtoolStripMenuItem = new ToolStripMenuItem();
			this.DeletedRecordtoolStripMenuItem = new ToolStripMenuItem();
			this.contextMenuStripCondition = new ContextMenuStrip(this.components);
			this.AddConditiontoolStripMenuItem = new ToolStripMenuItem();
			this.contextMenuStripAction = new ContextMenuStrip(this.components);
			this.toolStripMenuItem4 = new ToolStripMenuItem();
			this.saveFileDialog = new SaveFileDialog();
			this.contextMenuStripData = new ContextMenuStrip(this.components);
			this.changeByToolStripMenuItem = new ToolStripMenuItem();
			this.deletedToolStripMenuItem1 = new ToolStripMenuItem();
			this.menuStrip.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.contextMenuStripBlock.SuspendLayout();
			this.groupBoxData.SuspendLayout();
			((ISupportInitialize)this.dataGridView).BeginInit();
			this.groupBoxInfo.SuspendLayout();
			this.contextMenuStripRecord.SuspendLayout();
			this.contextMenuStripCondition.SuspendLayout();
			this.contextMenuStripAction.SuspendLayout();
			this.contextMenuStripData.SuspendLayout();
			base.SuspendLayout();
			this.menuStrip.AllowMerge = false;
			this.menuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.fileToolStripMenuItem,
				this.toolsToolStripMenuItem
			});
			this.menuStrip.Location = new Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new Size(694, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.openToolStripMenuItem,
				this.newToolStripMenuItem,
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
			this.openToolStripMenuItem.Size = new Size(124, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.Size = new Size(124, 22);
			this.newToolStripMenuItem.Text = "New";
			this.newToolStripMenuItem.Click += new EventHandler(this.newToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(121, 6);
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new Size(124, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new Size(124, 22);
			this.saveAsToolStripMenuItem.Text = "Save As";
			this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(121, 6);
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new Size(124, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.searchToolStripMenuItem
			});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new Size(44, 20);
			this.toolsToolStripMenuItem.Text = "Tools";
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new Size(118, 22);
			this.searchToolStripMenuItem.Text = "Search";
			this.statusStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.StatusLabel
			});
			this.statusStrip1.Location = new Point(0, 554);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new Size(694, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			this.StatusLabel.BackColor = SystemColors.Control;
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new Size(44, 17);
			this.StatusLabel.Text = "Statut :";
			this.labelQSDName.AutoSize = true;
			this.labelQSDName.Location = new Point(12, 33);
			this.labelQSDName.Name = "labelQSDName";
			this.labelQSDName.Size = new Size(67, 13);
			this.labelQSDName.TabIndex = 2;
			this.labelQSDName.Text = "QSD Name :";
			this.textBoxQSDName.Enabled = false;
			this.textBoxQSDName.Location = new Point(85, 30);
			this.textBoxQSDName.Name = "textBoxQSDName";
			this.textBoxQSDName.Size = new Size(212, 20);
			this.textBoxQSDName.TabIndex = 3;
			this.textBoxQSDName.TextChanged += new EventHandler(this.textBoxQSDName_TextChanged);
			this.treeView.ContextMenuStrip = this.contextMenuStripBlock;
			this.treeView.LabelEdit = true;
			this.treeView.Location = new Point(12, 56);
			this.treeView.Name = "treeView";
			this.treeView.Size = new Size(285, 317);
			this.treeView.TabIndex = 4;
			this.treeView.AfterSelect += new TreeViewEventHandler(this.treeView_AfterSelect);
			this.contextMenuStripBlock.Items.AddRange(new ToolStripItem[]
			{
				this.addBlockToolStripMenuItem,
				this.renameToolStripMenuItem,
				this.deletedToolStripMenuItem,
				this.toolStripSeparator3,
				this.addToolStripMenuItem
			});
			this.contextMenuStripBlock.Name = "contextMenuStripBlock";
			this.contextMenuStripBlock.Size = new Size(152, 98);
			this.addBlockToolStripMenuItem.Name = "addBlockToolStripMenuItem";
			this.addBlockToolStripMenuItem.Size = new Size(151, 22);
			this.addBlockToolStripMenuItem.Text = "Add block";
			this.addBlockToolStripMenuItem.Click += new EventHandler(this.addBlockToolStripMenuItem_Click);
			this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
			this.renameToolStripMenuItem.Size = new Size(151, 22);
			this.renameToolStripMenuItem.Text = "Rename Block";
			this.renameToolStripMenuItem.Click += new EventHandler(this.renameToolStripMenuItem_Click);
			this.deletedToolStripMenuItem.Name = "deletedToolStripMenuItem";
			this.deletedToolStripMenuItem.Size = new Size(151, 22);
			this.deletedToolStripMenuItem.Text = "Deleted Block";
			this.deletedToolStripMenuItem.Click += new EventHandler(this.deletedToolStripMenuItem_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new Size(148, 6);
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new Size(151, 22);
			this.addToolStripMenuItem.Text = "Add Record";
			this.addToolStripMenuItem.Click += new EventHandler(this.addToolStripMenuItem_Click);
			this.labelFileVersion.AutoSize = true;
			this.labelFileVersion.Location = new Point(6, 16);
			this.labelFileVersion.Name = "labelFileVersion";
			this.labelFileVersion.Size = new Size(66, 13);
			this.labelFileVersion.TabIndex = 5;
			this.labelFileVersion.Text = "File version :";
			this.labelBlockCount.AutoSize = true;
			this.labelBlockCount.Location = new Point(127, 16);
			this.labelBlockCount.Name = "labelBlockCount";
			this.labelBlockCount.Size = new Size(70, 13);
			this.labelBlockCount.TabIndex = 6;
			this.labelBlockCount.Text = "Block count :";
			this.groupBoxData.BackColor = SystemColors.Window;
			this.groupBoxData.BackgroundImageLayout = ImageLayout.None;
			this.groupBoxData.Controls.Add(this.buttonConditionApply);
			this.groupBoxData.Controls.Add(this.dataGridView);
			this.groupBoxData.Controls.Add(this.labelDataDump2);
			this.groupBoxData.Controls.Add(this.richTextBoxDataDump);
			this.groupBoxData.Controls.Add(this.menuStrip1);
			this.groupBoxData.ForeColor = SystemColors.ControlText;
			this.groupBoxData.Location = new Point(303, 56);
			this.groupBoxData.Name = "groupBoxData";
			this.groupBoxData.Size = new Size(379, 317);
			this.groupBoxData.TabIndex = 7;
			this.groupBoxData.TabStop = false;
			this.groupBoxData.Text = "Data :";
			this.buttonConditionApply.Location = new Point(102, 164);
			this.buttonConditionApply.Name = "buttonConditionApply";
			this.buttonConditionApply.Size = new Size(167, 26);
			this.buttonConditionApply.TabIndex = 5;
			this.buttonConditionApply.Text = "Apply change";
			this.buttonConditionApply.TextImageRelation = TextImageRelation.TextBeforeImage;
			this.buttonConditionApply.UseVisualStyleBackColor = true;
			this.buttonConditionApply.Click += new EventHandler(this.buttonConditionApply_Click);
			this.dataGridView.AllowUserToDeleteRows = false;
			this.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new Point(11, 17);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.Size = new Size(350, 141);
			this.dataGridView.TabIndex = 4;
			this.labelDataDump2.AutoSize = true;
			this.labelDataDump2.Location = new Point(3, 236);
			this.labelDataDump2.Name = "labelDataDump2";
			this.labelDataDump2.Size = new Size(65, 13);
			this.labelDataDump2.TabIndex = 3;
			this.labelDataDump2.Text = "Data dump :";
			this.richTextBoxDataDump.Enabled = false;
			this.richTextBoxDataDump.Location = new Point(6, 252);
			this.richTextBoxDataDump.Name = "richTextBoxDataDump";
			this.richTextBoxDataDump.Size = new Size(367, 59);
			this.richTextBoxDataDump.TabIndex = 0;
			this.richTextBoxDataDump.Text = "";
			this.menuStrip1.Location = new Point(3, 16);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new Size(373, 24);
			this.menuStrip1.TabIndex = 6;
			this.menuStrip1.Text = "menuStrip1";
			this.groupBoxInfo.BackColor = SystemColors.ActiveCaptionText;
			this.groupBoxInfo.Controls.Add(this.labelBlockCount);
			this.groupBoxInfo.Controls.Add(this.labelFileVersion);
			this.groupBoxInfo.Location = new Point(12, 379);
			this.groupBoxInfo.Name = "groupBoxInfo";
			this.groupBoxInfo.Size = new Size(670, 172);
			this.groupBoxInfo.TabIndex = 9;
			this.groupBoxInfo.TabStop = false;
			this.groupBoxInfo.Text = "Info :";
			this.openFileDialog.Filter = "Fichier QSD|*.qsd";
			this.contextMenuStripRecord.Items.AddRange(new ToolStripItem[]
			{
				this.RenameRecordtoolStripMenuItem,
				this.DeletedRecordtoolStripMenuItem
			});
			this.contextMenuStripRecord.Name = "contextMenuStripBlock";
			this.contextMenuStripRecord.Size = new Size(125, 48);
			this.RenameRecordtoolStripMenuItem.Name = "RenameRecordtoolStripMenuItem";
			this.RenameRecordtoolStripMenuItem.Size = new Size(124, 22);
			this.RenameRecordtoolStripMenuItem.Text = "Rename";
			this.RenameRecordtoolStripMenuItem.Click += new EventHandler(this.RenameRecordtoolStripMenuItem_Click);
			this.DeletedRecordtoolStripMenuItem.Name = "DeletedRecordtoolStripMenuItem";
			this.DeletedRecordtoolStripMenuItem.Size = new Size(124, 22);
			this.DeletedRecordtoolStripMenuItem.Text = "Deleted";
			this.DeletedRecordtoolStripMenuItem.Click += new EventHandler(this.DeletedRecordtoolStripMenuItem_Click);
			this.contextMenuStripCondition.Items.AddRange(new ToolStripItem[]
			{
				this.AddConditiontoolStripMenuItem
			});
			this.contextMenuStripCondition.Name = "contextMenuStripBlock";
			this.contextMenuStripCondition.Size = new Size(151, 26);
			this.AddConditiontoolStripMenuItem.Name = "AddConditiontoolStripMenuItem";
			this.AddConditiontoolStripMenuItem.Size = new Size(150, 22);
			this.AddConditiontoolStripMenuItem.Text = "Add condition";
			this.AddConditiontoolStripMenuItem.Click += new EventHandler(this.AddConditiontoolStripMenuItem_Click);
			this.contextMenuStripAction.Items.AddRange(new ToolStripItem[]
			{
				this.toolStripMenuItem4
			});
			this.contextMenuStripAction.Name = "contextMenuStripBlock";
			this.contextMenuStripAction.Size = new Size(137, 26);
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new Size(136, 22);
			this.toolStripMenuItem4.Text = "Add action";
			this.toolStripMenuItem4.Click += new EventHandler(this.toolStripMenuItem4_Click);
			this.saveFileDialog.Filter = "Fichier QSD|*.qsd";
			this.contextMenuStripData.Items.AddRange(new ToolStripItem[]
			{
				this.changeByToolStripMenuItem,
				this.deletedToolStripMenuItem1
			});
			this.contextMenuStripData.Name = "contextMenuStripData";
			this.contextMenuStripData.Size = new Size(138, 48);
			this.changeByToolStripMenuItem.Name = "changeByToolStripMenuItem";
			this.changeByToolStripMenuItem.Size = new Size(137, 22);
			this.changeByToolStripMenuItem.Text = "Change by";
			this.changeByToolStripMenuItem.Click += new EventHandler(this.changeByToolStripMenuItem_Click);
			this.deletedToolStripMenuItem1.Name = "deletedToolStripMenuItem1";
			this.deletedToolStripMenuItem1.Size = new Size(137, 22);
			this.deletedToolStripMenuItem1.Text = "Deleted";
			this.deletedToolStripMenuItem1.Click += new EventHandler(this.deletedToolStripMenuItem1_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.ButtonHighlight;
			base.ClientSize = new Size(694, 576);
			base.Controls.Add(this.groupBoxInfo);
			base.Controls.Add(this.groupBoxData);
			base.Controls.Add(this.textBoxQSDName);
			base.Controls.Add(this.treeView);
			base.Controls.Add(this.labelQSDName);
			base.Controls.Add(this.statusStrip1);
			base.Controls.Add(this.menuStrip);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.menuStrip;
			base.Name = "AIPEditorForm";
			this.Text = "ShinQSD Editor";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.contextMenuStripBlock.ResumeLayout(false);
			this.groupBoxData.ResumeLayout(false);
			this.groupBoxData.PerformLayout();
			((ISupportInitialize)this.dataGridView).EndInit();
			this.groupBoxInfo.ResumeLayout(false);
			this.groupBoxInfo.PerformLayout();
			this.contextMenuStripRecord.ResumeLayout(false);
			this.contextMenuStripCondition.ResumeLayout(false);
			this.contextMenuStripAction.ResumeLayout(false);
			this.contextMenuStripData.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
