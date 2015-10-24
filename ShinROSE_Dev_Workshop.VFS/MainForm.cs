using ShinROSE_Dev_Workshop.AIP;
using ShinROSE_Dev_Workshop.CHR;
using ShinROSE_Dev_Workshop.LTB;
using ShinROSE_Dev_Workshop.QSD;
using ShinROSE_Dev_Workshop.STB;
using ShinROSE_Dev_Workshop.STL;
using ShinROSE_Dev_Workshop.TSI;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop.VFS
{
	public class MainForm : Form
	{
		private struct Fichier
		{
			public string File_Path;

			public int Offset;

			public int file_length;

			public int block_size;

			public byte deleted;

			public byte compressed_type;

			public byte encryption_type;

			public int Version;

			public int Checksum;
		}

		private struct VFS
		{
			public string VFS_Path;

			public int Data_Offset;

			public uint File_Count;

			public int Unk1;

			public int Unk2;

			public MainForm.Fichier[] Fichier;
		}

		private IContainer components = null;

		private MenuStrip menuStrip;

		private ToolStripMenuItem fichierToolStripMenuItem;

		private ToolStripMenuItem ouvrirToolStripMenuItem;

		private ToolStripMenuItem exitToolStripMenuItem;

		private SplitContainer splitContainer;

		private StatusStrip statusStrip;

		private ToolStripStatusLabel StatutLabel;

		private TreeView treeView;

		public OpenFileDialog OpenFileDialog;

		private Label LabelBaseVs;

		private Label LabelCurrentVs;

		private Label LabelFileCount;

		private Label LabelFileChecksum;

		private Label LabelFileSize;

		private ToolStripStatusLabel VFSBaseLabel;

		public new ContextMenuStrip ContextMenuStrip;

		private ToolStripMenuItem Extractmenuitem;

		private SaveFileDialog saveFileDialog;

		private ToolStripMenuItem extractFileAndOpenToolStripMenuItem;

		private ToolStripMenuItem extractFolderToolStripMenuItem;

		private FolderBrowserDialog folderBrowserDialog;

		public Control.ControlCollection mainpanel;

		private int VFS_Base_Version;

		private int VFS_Current_Version;

		private int VFS_Count;

		private MainForm.VFS[] vfs = new MainForm.VFS[6];

		private string VFS_Base_fichier_extraire;

		private int Offset_Fichier_extraire;

		private int enc_length_Fichier_extraire;

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		public void InitializeComponent()
		{
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));
			this.menuStrip = new MenuStrip();
			this.fichierToolStripMenuItem = new ToolStripMenuItem();
			this.ouvrirToolStripMenuItem = new ToolStripMenuItem();
			this.exitToolStripMenuItem = new ToolStripMenuItem();
			this.splitContainer = new SplitContainer();
			this.treeView = new TreeView();
			this.ContextMenuStrip = new ContextMenuStrip(this.components);
			this.Extractmenuitem = new ToolStripMenuItem();
			this.extractFileAndOpenToolStripMenuItem = new ToolStripMenuItem();
			this.extractFolderToolStripMenuItem = new ToolStripMenuItem();
			this.LabelFileSize = new Label();
			this.LabelFileChecksum = new Label();
			this.LabelFileCount = new Label();
			this.LabelCurrentVs = new Label();
			this.LabelBaseVs = new Label();
			this.statusStrip = new StatusStrip();
			this.StatutLabel = new ToolStripStatusLabel();
			this.VFSBaseLabel = new ToolStripStatusLabel();
			this.OpenFileDialog = new OpenFileDialog();
			this.saveFileDialog = new SaveFileDialog();
			this.folderBrowserDialog = new FolderBrowserDialog();
			this.menuStrip.SuspendLayout();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.ContextMenuStrip.SuspendLayout();
			this.statusStrip.SuspendLayout();
			base.SuspendLayout();
			this.menuStrip.AllowMerge = false;
			this.menuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.fichierToolStripMenuItem
			});
			this.menuStrip.Location = new Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new Size(392, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			this.fichierToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.ouvrirToolStripMenuItem,
				this.exitToolStripMenuItem
			});
			this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
			this.fichierToolStripMenuItem.Size = new Size(35, 20);
			this.fichierToolStripMenuItem.Text = "File";
			this.fichierToolStripMenuItem.Click += new EventHandler(this.fichierToolStripMenuItem_Click);
			this.ouvrirToolStripMenuItem.Name = "ouvrirToolStripMenuItem";
			this.ouvrirToolStripMenuItem.Size = new Size(111, 22);
			this.ouvrirToolStripMenuItem.Text = "Open";
			this.ouvrirToolStripMenuItem.Click += new EventHandler(this.ouvrirToolStripMenuItem_Click);
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new Size(111, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
			this.splitContainer.Dock = DockStyle.Fill;
			this.splitContainer.Location = new Point(0, 24);
			this.splitContainer.Name = "splitContainer";
			this.splitContainer.Orientation = Orientation.Horizontal;
			this.splitContainer.Panel1.BackColor = SystemColors.Window;
			this.splitContainer.Panel1.Controls.Add(this.treeView);
			this.splitContainer.Panel2.Controls.Add(this.LabelFileSize);
			this.splitContainer.Panel2.Controls.Add(this.LabelFileChecksum);
			this.splitContainer.Panel2.Controls.Add(this.LabelFileCount);
			this.splitContainer.Panel2.Controls.Add(this.LabelCurrentVs);
			this.splitContainer.Panel2.Controls.Add(this.LabelBaseVs);
			this.splitContainer.Panel2.Controls.Add(this.statusStrip);
			this.splitContainer.Size = new Size(392, 442);
			this.splitContainer.SplitterDistance = 333;
			this.splitContainer.TabIndex = 1;
			this.treeView.ContextMenuStrip = this.ContextMenuStrip;
			this.treeView.Location = new Point(3, 5);
			this.treeView.Name = "treeView";
			this.treeView.Size = new Size(386, 325);
			this.treeView.TabIndex = 0;
			this.treeView.MouseClick += new MouseEventHandler(this.treeView_MouseClick);
			this.treeView.AfterSelect += new TreeViewEventHandler(this.treeView_AfterSelect);
			this.ContextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.Extractmenuitem,
				this.extractFileAndOpenToolStripMenuItem,
				this.extractFolderToolStripMenuItem
			});
			this.ContextMenuStrip.Name = "ContextMenuStrip";
			this.ContextMenuStrip.Size = new Size(232, 92);
			this.Extractmenuitem.Enabled = false;
			this.Extractmenuitem.Name = "Extractmenuitem";
			this.Extractmenuitem.Size = new Size(231, 22);
			this.Extractmenuitem.Text = "Extract File";
			this.Extractmenuitem.Click += new EventHandler(this.toolStripMenuItem1_Click);
			this.extractFileAndOpenToolStripMenuItem.Enabled = false;
			this.extractFileAndOpenToolStripMenuItem.Name = "extractFileAndOpenToolStripMenuItem";
			this.extractFileAndOpenToolStripMenuItem.Size = new Size(231, 22);
			this.extractFileAndOpenToolStripMenuItem.Text = "Extract File and Open (In dev)";
			this.extractFileAndOpenToolStripMenuItem.Click += new EventHandler(this.extractFileAndOpenToolStripMenuItem_Click);
			this.extractFolderToolStripMenuItem.Enabled = false;
			this.extractFolderToolStripMenuItem.Name = "extractFolderToolStripMenuItem";
			this.extractFolderToolStripMenuItem.Size = new Size(231, 22);
			this.extractFolderToolStripMenuItem.Text = "Extract Folder";
			this.extractFolderToolStripMenuItem.Click += new EventHandler(this.extractFolderToolStripMenuItem_Click);
			this.LabelFileSize.AutoSize = true;
			this.LabelFileSize.Location = new Point(253, 15);
			this.LabelFileSize.Name = "LabelFileSize";
			this.LabelFileSize.Size = new Size(50, 13);
			this.LabelFileSize.TabIndex = 5;
			this.LabelFileSize.Text = "File size :";
			this.LabelFileChecksum.AutoSize = true;
			this.LabelFileChecksum.Location = new Point(128, 38);
			this.LabelFileChecksum.Name = "LabelFileChecksum";
			this.LabelFileChecksum.Size = new Size(81, 13);
			this.LabelFileChecksum.TabIndex = 4;
			this.LabelFileChecksum.Text = "File checksum :";
			this.LabelFileCount.AutoSize = true;
			this.LabelFileCount.Location = new Point(128, 14);
			this.LabelFileCount.Name = "LabelFileCount";
			this.LabelFileCount.Size = new Size(59, 13);
			this.LabelFileCount.TabIndex = 3;
			this.LabelFileCount.Text = "File count :";
			this.LabelCurrentVs.AutoSize = true;
			this.LabelCurrentVs.Location = new Point(12, 38);
			this.LabelCurrentVs.Name = "LabelCurrentVs";
			this.LabelCurrentVs.Size = new Size(85, 13);
			this.LabelCurrentVs.TabIndex = 2;
			this.LabelCurrentVs.Text = "Current Version :";
			this.LabelBaseVs.AutoSize = true;
			this.LabelBaseVs.Location = new Point(12, 14);
			this.LabelBaseVs.Name = "LabelBaseVs";
			this.LabelBaseVs.Size = new Size(75, 13);
			this.LabelBaseVs.TabIndex = 1;
			this.LabelBaseVs.Text = "Base Version :";
			this.statusStrip.Items.AddRange(new ToolStripItem[]
			{
				this.StatutLabel,
				this.VFSBaseLabel
			});
			this.statusStrip.Location = new Point(0, 83);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new Size(392, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			this.StatutLabel.Name = "StatutLabel";
			this.StatutLabel.Size = new Size(135, 17);
			this.StatutLabel.Text = "VFS Editor succeffuly open";
			this.VFSBaseLabel.Name = "VFSBaseLabel";
			this.VFSBaseLabel.Size = new Size(0, 17);
			this.OpenFileDialog.Filter = "Fichier idx|*.idx";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(392, 466);
			base.Controls.Add(this.splitContainer);
			base.Controls.Add(this.menuStrip);
			base.FormBorderStyle = FormBorderStyle.FixedSingle;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.menuStrip;
			base.MaximizeBox = false;
			base.Name = "MainForm";
			this.Text = "ShinVFS editor";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			this.splitContainer.Panel2.PerformLayout();
			this.splitContainer.ResumeLayout(false);
			this.ContextMenuStrip.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public MainForm()
		{
			this.InitializeComponent();
		}

		private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void ouvrirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.OpenFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (this.idxreader(this.OpenFileDialog.FileName))
				{
					this.MakeTree();
				}
			}
		}

		public void load_VFS(string path)
		{
			if (this.idxreader(path))
			{
				this.MakeTree();
			}
		}

		public bool idxreader(string path)
		{
			BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open));
			this.VFS_Base_Version = binaryReader.ReadInt32();
			this.LabelBaseVs.Text = "Base Version :" + this.VFS_Base_Version.ToString();
			this.VFS_Current_Version = binaryReader.ReadInt32();
			this.LabelCurrentVs.Text = "Base Version :" + this.VFS_Current_Version.ToString();
			this.VFS_Count = binaryReader.ReadInt32();
			this.StatutLabel.Text = this.VFS_Count.ToString() + " VFS load";
			for (int num = 0; num != this.VFS_Count; num++)
			{
				short count = binaryReader.ReadInt16();
				this.vfs[num].VFS_Path = Encoding.UTF7.GetString(binaryReader.ReadBytes((int)count));
				this.vfs[num].Data_Offset = binaryReader.ReadInt32();
			}
			for (int num = 0; num != this.VFS_Count - 1; num++)
			{
				binaryReader.BaseStream.Seek((long)this.vfs[num].Data_Offset, SeekOrigin.Begin);
				this.vfs[num].File_Count = binaryReader.ReadUInt32();
				this.vfs[num].Unk1 = binaryReader.ReadInt32();
				this.vfs[num].Unk2 = binaryReader.ReadInt32();
				this.vfs[num].Fichier = new MainForm.Fichier[this.vfs[num].File_Count];
				int num2 = 0;
				while ((long)num2 != (long)((ulong)this.vfs[num].File_Count))
				{
					short count = binaryReader.ReadInt16();
					string @string = Encoding.UTF7.GetString(binaryReader.ReadBytes((int)count));
					this.vfs[num].Fichier[num2].File_Path = this.vfs[num].Fichier[num2].File_Path + @string;
					this.vfs[num].Fichier[num2].Offset = binaryReader.ReadInt32();
					this.vfs[num].Fichier[num2].file_length = binaryReader.ReadInt32();
					this.vfs[num].Fichier[num2].block_size = binaryReader.ReadInt32();
					this.vfs[num].Fichier[num2].deleted = binaryReader.ReadByte();
					this.vfs[num].Fichier[num2].compressed_type = binaryReader.ReadByte();
					this.vfs[num].Fichier[num2].encryption_type = binaryReader.ReadByte();
					this.vfs[num].Fichier[num2].Version = binaryReader.ReadInt32();
					this.vfs[num].Fichier[num2].Checksum = binaryReader.ReadInt32();
					num2++;
				}
			}
			this.LabelFileCount.Text = "File count : " + this.vfs[0].File_Count.ToString();
			binaryReader.Close();
			return true;
		}

		public bool MakeTree()
		{
			this.StatutLabel.Text = "Tree build :D";
			long num = 0L;
			int num2 = 0;
			for (int i = 0; i != 5; i++)
			{
				int num3 = 0;
				while ((long)num3 != (long)((ulong)this.vfs[i].File_Count))
				{
					if (this.vfs[i].Fichier[num3].deleted == 0)
					{
						num += 1L;
					}
					num3++;
				}
			}
			string[] array = new string[num];
			for (int i = 0; i != 5; i++)
			{
				int num3 = 0;
				while ((long)num3 != (long)((ulong)this.vfs[i].File_Count))
				{
					if (this.vfs[i].Fichier[num3].deleted == 0)
					{
						array[num2] = this.vfs[i].Fichier[num3].File_Path;
						num2++;
					}
					num3++;
				}
			}
			TreeNode treeNode = null;
			string[] array2 = array;
			for (int j = 0; j < array2.Length; j++)
			{
				string text = array2[j];
				string[] array3 = text.Split(new char[]
				{
					'\\'
				});
				if (this.treeView.Nodes.Count == 0)
				{
					for (int i = 0; i < array3.Length; i++)
					{
						TreeNode treeNode2 = new TreeNode(array3[i]);
						if (treeNode == null)
						{
							this.treeView.Nodes.Add(treeNode2);
						}
						else
						{
							treeNode.Nodes.Add(treeNode2);
						}
						treeNode = treeNode2;
					}
				}
				else
				{
					TreeNodeCollection nodes = this.treeView.Nodes;
					for (int i = 0; i < array3.Length; i++)
					{
						bool flag = false;
						foreach (TreeNode treeNode3 in nodes)
						{
							if (treeNode3.Text.Equals(array3[i]))
							{
								flag = true;
								nodes = treeNode3.Nodes;
								break;
							}
						}
						if (!flag)
						{
							TreeNode treeNode2 = new TreeNode(array3[i]);
							nodes.Add(treeNode2);
							nodes = treeNode2.Nodes;
						}
					}
				}
			}
			return true;
		}

		public bool fileextract(string path)
		{
			string path2 = Directory.GetParent(this.OpenFileDialog.FileName) + "\\" + this.VFS_Base_fichier_extraire.Replace("\0", "");
			BinaryReader binaryReader = new BinaryReader(File.Open(path2, FileMode.Open));
			binaryReader.BaseStream.Seek((long)this.Offset_Fichier_extraire, SeekOrigin.Begin);
			byte[] buffer = binaryReader.ReadBytes(this.enc_length_Fichier_extraire);
			binaryReader.Close();
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create));
			binaryWriter.Write(buffer);
			binaryWriter.Close();
			this.StatutLabel.Text = "Extract " + path;
			return true;
		}

		private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			bool flag = false;
			uint num = 0u;
			int num2 = 0;
			string fullPath = this.treeView.SelectedNode.FullPath;
			this.StatutLabel.Text = fullPath;
			if (e.Node.Nodes.Count == 0)
			{
				this.Extractmenuitem.Enabled = true;
				this.extractFileAndOpenToolStripMenuItem.Enabled = true;
				this.extractFolderToolStripMenuItem.Enabled = false;
			}
			else
			{
				this.Extractmenuitem.Enabled = false;
				this.extractFileAndOpenToolStripMenuItem.Enabled = false;
				this.extractFolderToolStripMenuItem.Enabled = true;
			}
			try
			{
				while (!flag)
				{
					if (num >= this.vfs[num2].File_Count)
					{
						num2++;
						num = 0u;
					}
					else
					{
						if (this.vfs[num2].Fichier[(int)((UIntPtr)num)].File_Path == fullPath)
						{
							if (this.vfs[num2].Fichier[(int)((UIntPtr)num)].deleted == 0)
							{
								flag = true;
							}
						}
						else
						{
							flag = false;
						}
						num += 1u;
					}
				}
				num -= 1u;
				this.LabelFileChecksum.Text = "File checksum : " + this.vfs[num2].Fichier[(int)((UIntPtr)num)].Checksum;
				this.LabelFileSize.Text = "File size : " + (double)this.vfs[num2].Fichier[(int)((UIntPtr)num)].file_length * 0.001 + " kb";
				this.VFSBaseLabel.Text = "In " + this.vfs[num2].VFS_Path;
				this.VFS_Base_fichier_extraire = this.vfs[num2].VFS_Path;
				this.Offset_Fichier_extraire = this.vfs[num2].Fichier[(int)((UIntPtr)num)].Offset;
				this.enc_length_Fichier_extraire = this.vfs[num2].Fichier[(int)((UIntPtr)num)].file_length;
			}
			catch (Exception var_4_240)
			{
				this.LabelFileChecksum.Text = "File checksum : ";
				this.LabelFileSize.Text = "File size : ";
				this.VFSBaseLabel.Text = " ";
			}
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (this.treeView.SelectedNode.Nodes.Count == 0)
			{
				string[] array = this.StatutLabel.Text.Split(new char[]
				{
					'\\'
				});
				this.saveFileDialog.FileName = array[array.Length - 1];
				string[] array2 = array[array.Length - 1].Split(new char[]
				{
					'.'
				});
				this.saveFileDialog.Filter = "fichier " + array2[1] + " |*." + array2[1];
				if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.fileextract(this.saveFileDialog.FileName);
				}
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
		}

		private void treeView_MouseClick(object sender, MouseEventArgs e)
		{
		}

		private void extractFileAndOpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.treeView.SelectedNode.Nodes.Count == 0)
			{
				string[] array = this.StatutLabel.Text.Split(new char[]
				{
					'\\'
				});
				this.saveFileDialog.FileName = array[array.Length - 1];
				string[] array2 = array[array.Length - 1].Split(new char[]
				{
					'.'
				});
				this.saveFileDialog.Filter = "fichier " + array2[1] + " |*." + array2[1];
				if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					this.fileextract(this.saveFileDialog.FileName);
				}
				string text = array2[1].ToUpper();
				switch (text)
				{
				case "STB":
				{
					STBForm sTBForm = new STBForm();
					sTBForm.MdiParent = base.MdiParent;
					sTBForm.Show();
					sTBForm.BringToFront();
					sTBForm.Text = "STB : \"" + this.saveFileDialog.FileName + "\"";
					sTBForm.Load_STB(this.saveFileDialog.FileName);
					break;
				}
				case "LTB":
				{
					LTBForm lTBForm = new LTBForm();
					lTBForm.MdiParent = base.MdiParent;
					lTBForm.Show();
					lTBForm.BringToFront();
					lTBForm.Text = "LTB : \"" + this.saveFileDialog.FileName + "\"";
					lTBForm.Load_LTB(this.saveFileDialog.FileName);
					break;
				}
				case "STL":
				{
					STLForm sTLForm = new STLForm();
					sTLForm.MdiParent = base.MdiParent;
					sTLForm.Show();
					sTLForm.BringToFront();
					sTLForm.Text = "STL : \"" + this.saveFileDialog.FileName + "\"";
					sTLForm.Load_STL(this.saveFileDialog.FileName);
					break;
				}
				case "QSD":
				{
					ShinROSE_Dev_Workshop.QSD.AIPEditorForm aIPEditorForm = new ShinROSE_Dev_Workshop.QSD.AIPEditorForm();
					aIPEditorForm.MdiParent = base.MdiParent;
					aIPEditorForm.Show();
					aIPEditorForm.BringToFront();
					aIPEditorForm.Text = "QSD : \"" + this.saveFileDialog.FileName + "\"";
					aIPEditorForm.load_qsd_info(this.saveFileDialog.FileName);
					break;
				}
				case "AIP":
				{
					ShinROSE_Dev_Workshop.AIP.AIPEditorForm aIPEditorForm2 = new ShinROSE_Dev_Workshop.AIP.AIPEditorForm();
					aIPEditorForm2.MdiParent = base.MdiParent;
					aIPEditorForm2.Show();
					aIPEditorForm2.BringToFront();
					aIPEditorForm2.Text = "AIP : \"" + this.saveFileDialog.FileName + "\"";
					aIPEditorForm2.load_aip_info(this.saveFileDialog.FileName);
					break;
				}
				case "TSI":
				{
					TSIForm tSIForm = new TSIForm();
					tSIForm.MdiParent = base.MdiParent;
					tSIForm.Show();
					tSIForm.BringToFront();
					tSIForm.Text = "TSI : \"" + this.saveFileDialog.FileName + "\"";
					tSIForm.load_tsi(this.saveFileDialog.FileName);
					break;
				}
				case "CHR":
				{
					CHRForm cHRForm = new CHRForm();
					cHRForm.MdiParent = base.MdiParent;
					cHRForm.Show();
					cHRForm.BringToFront();
					cHRForm.Text = "CHR : \"" + this.saveFileDialog.FileName + "\"";
					cHRForm.load_chr(this.saveFileDialog.FileName);
					break;
				}
				}
			}
		}

		private void extractFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				string fullPath = this.treeView.SelectedNode.FullPath;
				for (int num = 0; num != this.VFS_Count; num++)
				{
					int num2 = 0;
					while ((long)num2 != (long)((ulong)this.vfs[num].File_Count))
					{
						if (this.vfs[num].Fichier[num2].File_Path.Contains(fullPath))
						{
							if (this.vfs[num].Fichier[num2].deleted == 0)
							{
								string path = Directory.GetParent(this.OpenFileDialog.FileName) + "\\" + this.vfs[num].VFS_Path.Replace("\0", "");
								BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open));
								binaryReader.BaseStream.Seek((long)this.vfs[num].Fichier[num2].Offset, SeekOrigin.Begin);
								byte[] buffer = binaryReader.ReadBytes(this.vfs[num].Fichier[num2].file_length);
								binaryReader.Close();
								string path2 = this.folderBrowserDialog.SelectedPath + "\\" + this.vfs[num].Fichier[num2].File_Path.Replace('\0', ' ');
								if (!Directory.Exists(this.folderBrowserDialog.SelectedPath + "\\" + this.treeView.SelectedNode.FullPath))
								{
									Directory.CreateDirectory(this.folderBrowserDialog.SelectedPath + "\\" + this.treeView.SelectedNode.FullPath);
								}
								for (int num3 = 0; num3 != this.treeView.SelectedNode.Nodes.Count; num3++)
								{
									if (this.treeView.SelectedNode.Nodes[num3].Nodes.Count != 0)
									{
										if (!Directory.Exists(this.folderBrowserDialog.SelectedPath + "\\" + this.treeView.SelectedNode.Nodes[num3].FullPath))
										{
											Directory.CreateDirectory(this.folderBrowserDialog.SelectedPath + "\\" + this.treeView.SelectedNode.Nodes[num3].FullPath);
										}
									}
								}
								try
								{
									BinaryWriter binaryWriter = new BinaryWriter(File.Open(path2, FileMode.CreateNew));
									binaryWriter.Write(buffer);
									binaryWriter.Close();
								}
								catch (Exception var_9_2CC)
								{
									this.StatutLabel.Text = "Error on a file";
								}
							}
						}
						num2++;
					}
				}
			}
			this.StatutLabel.Text = "Folder succefully extract";
		}
	}
}
