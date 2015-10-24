using ShinROSE_Dev_Workshop.AIP;
using ShinROSE_Dev_Workshop.CHR;
using ShinROSE_Dev_Workshop.LTB;
using ShinROSE_Dev_Workshop.QSD;
using ShinROSE_Dev_Workshop.STB;
using ShinROSE_Dev_Workshop.STL;
using ShinROSE_Dev_Workshop.TSI;
using ShinROSE_Dev_Workshop.VFS;
using ShinROSE_Dev_Workshop.ZSC;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop
{
	public class MyForm : Form
	{
		private IContainer components = null;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem File_ToolStripMenuItem;

		private ToolStripMenuItem LoadButton;

		private ToolStripMenuItem ExitButton;

		private ToolStripMenuItem Help_ToolStripMenuItem;

		private ToolStripMenuItem About_ToolStripMenuItem;

		private OpenFileDialog openFileDialog;

		private ToolStripMenuItem windowToolStripMenuItem;

		private ToolStripMenuItem NewSTBFormpMenuItem;

		private ToolStripMenuItem NewQSDMenuItem;

		private ToolStripMenuItem newAIPMenuItem;

		private StatusStrip statusStrip;

		private ToolStripStatusLabel StatusLabel;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripMenuItem newIDXMenuItem;

		private ToolStripMenuItem newLTBToolStripMenuItem;

		private ToolStripMenuItem newSTLToolStripMenuItem;

		private NotifyIcon notifyIcon;

		private ToolStripMenuItem newZSCToolStripMenuItem;

		private ToolStripMenuItem newTSIToolStripMenuItem;

		private ToolStripMenuItem newCHRToolStripMenuItem;

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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MyForm));
			this.menuStrip1 = new MenuStrip();
			this.File_ToolStripMenuItem = new ToolStripMenuItem();
			this.LoadButton = new ToolStripMenuItem();
			this.ExitButton = new ToolStripMenuItem();
			this.windowToolStripMenuItem = new ToolStripMenuItem();
			this.NewSTBFormpMenuItem = new ToolStripMenuItem();
			this.newSTLToolStripMenuItem = new ToolStripMenuItem();
			this.newLTBToolStripMenuItem = new ToolStripMenuItem();
			this.NewQSDMenuItem = new ToolStripMenuItem();
			this.newAIPMenuItem = new ToolStripMenuItem();
			this.newIDXMenuItem = new ToolStripMenuItem();
			this.newZSCToolStripMenuItem = new ToolStripMenuItem();
			this.newTSIToolStripMenuItem = new ToolStripMenuItem();
			this.newCHRToolStripMenuItem = new ToolStripMenuItem();
			this.Help_ToolStripMenuItem = new ToolStripMenuItem();
			this.About_ToolStripMenuItem = new ToolStripMenuItem();
			this.openFileDialog = new OpenFileDialog();
			this.statusStrip = new StatusStrip();
			this.StatusLabel = new ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new ToolStripStatusLabel();
			this.notifyIcon = new NotifyIcon(this.components);
			this.menuStrip1.SuspendLayout();
			this.statusStrip.SuspendLayout();
			base.SuspendLayout();
			this.menuStrip1.Items.AddRange(new ToolStripItem[]
			{
				this.File_ToolStripMenuItem,
				this.windowToolStripMenuItem,
				this.Help_ToolStripMenuItem
			});
			this.menuStrip1.Location = new Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new Size(992, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.File_ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.LoadButton,
				this.ExitButton
			});
			this.File_ToolStripMenuItem.Name = "File_ToolStripMenuItem";
			this.File_ToolStripMenuItem.Size = new Size(35, 20);
			this.File_ToolStripMenuItem.Text = "File";
			this.LoadButton.Name = "LoadButton";
			this.LoadButton.Size = new Size(152, 22);
			this.LoadButton.Text = "Load";
			this.LoadButton.Click += new EventHandler(this.Load_ToolStripMenuItem_Click);
			this.ExitButton.Name = "ExitButton";
			this.ExitButton.Size = new Size(152, 22);
			this.ExitButton.Text = "Exit";
			this.ExitButton.Click += new EventHandler(this.ExitButton_Click);
			this.windowToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.NewSTBFormpMenuItem,
				this.newSTLToolStripMenuItem,
				this.newLTBToolStripMenuItem,
				this.NewQSDMenuItem,
				this.newAIPMenuItem,
				this.newIDXMenuItem,
				this.newZSCToolStripMenuItem,
				this.newTSIToolStripMenuItem,
				this.newCHRToolStripMenuItem
			});
			this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
			this.windowToolStripMenuItem.Size = new Size(62, 20);
			this.windowToolStripMenuItem.Text = "Windows";
			this.NewSTBFormpMenuItem.Name = "NewSTBFormpMenuItem";
			this.NewSTBFormpMenuItem.Size = new Size(149, 22);
			this.NewSTBFormpMenuItem.Text = "New STB";
			this.NewSTBFormpMenuItem.Click += new EventHandler(this.NewSTBFormpMenuItem_Click);
			this.newSTLToolStripMenuItem.Name = "newSTLToolStripMenuItem";
			this.newSTLToolStripMenuItem.Size = new Size(149, 22);
			this.newSTLToolStripMenuItem.Text = "New STL";
			this.newSTLToolStripMenuItem.Click += new EventHandler(this.newSTLToolStripMenuItem_Click);
			this.newLTBToolStripMenuItem.Name = "newLTBToolStripMenuItem";
			this.newLTBToolStripMenuItem.Size = new Size(149, 22);
			this.newLTBToolStripMenuItem.Text = "New LTB";
			this.newLTBToolStripMenuItem.Click += new EventHandler(this.newLTBToolStripMenuItem_Click);
			this.NewQSDMenuItem.Name = "NewQSDMenuItem";
			this.NewQSDMenuItem.Size = new Size(149, 22);
			this.NewQSDMenuItem.Text = "New QSD";
			this.NewQSDMenuItem.Click += new EventHandler(this.NewQSDMenuItem_Click);
			this.newAIPMenuItem.Name = "newAIPMenuItem";
			this.newAIPMenuItem.Size = new Size(149, 22);
			this.newAIPMenuItem.Text = "New AIP";
			this.newAIPMenuItem.Click += new EventHandler(this.newAIPMenuItem_Click);
			this.newIDXMenuItem.Name = "newIDXMenuItem";
			this.newIDXMenuItem.Size = new Size(149, 22);
			this.newIDXMenuItem.Text = "New IDX(vfs)";
			this.newIDXMenuItem.Click += new EventHandler(this.newIDXMenuItem_Click);
			this.newZSCToolStripMenuItem.Name = "newZSCToolStripMenuItem";
			this.newZSCToolStripMenuItem.Size = new Size(149, 22);
			this.newZSCToolStripMenuItem.Text = "New ZSC";
			this.newZSCToolStripMenuItem.Click += new EventHandler(this.newZSCToolStripMenuItem_Click);
			this.newTSIToolStripMenuItem.Name = "newTSIToolStripMenuItem";
			this.newTSIToolStripMenuItem.Size = new Size(149, 22);
			this.newTSIToolStripMenuItem.Text = "New TSI";
			this.newTSIToolStripMenuItem.Click += new EventHandler(this.newTSIToolStripMenuItem_Click);
			this.newCHRToolStripMenuItem.Name = "newCHRToolStripMenuItem";
			this.newCHRToolStripMenuItem.Size = new Size(149, 22);
			this.newCHRToolStripMenuItem.Text = "New CHR ";
			this.newCHRToolStripMenuItem.Click += new EventHandler(this.newCHRToolStripMenuItem_Click);
			this.Help_ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.About_ToolStripMenuItem
			});
			this.Help_ToolStripMenuItem.Name = "Help_ToolStripMenuItem";
			this.Help_ToolStripMenuItem.Size = new Size(40, 20);
			this.Help_ToolStripMenuItem.Text = "Help";
			this.About_ToolStripMenuItem.Name = "About_ToolStripMenuItem";
			this.About_ToolStripMenuItem.Size = new Size(114, 22);
			this.About_ToolStripMenuItem.Text = "About";
			this.About_ToolStripMenuItem.Click += new EventHandler(this.About_ToolStripMenuItem_Click);
			this.openFileDialog.Filter = "All Files|*.*|STB Files|*.stb|STL Files|*.stl|LTB Files|*.ltb|QSD Files|*.qsd|AIP Files|*.aip|IDX Files(vfs)|*.idx|TSI files|*.tsi|CHR files|*.chr|ZSC files|*.zsc";
			this.statusStrip.Items.AddRange(new ToolStripItem[]
			{
				this.StatusLabel,
				this.toolStripStatusLabel1
			});
			this.statusStrip.Location = new Point(0, 644);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new Size(992, 22);
			this.statusStrip.TabIndex = 2;
			this.statusStrip.Text = "statusStrip1";
			this.StatusLabel.BackColor = SystemColors.Control;
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new Size(44, 17);
			this.StatusLabel.Text = "Statut :";
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new Size(0, 17);
			this.notifyIcon.Icon = (Icon)componentResourceManager.GetObject("notifyIcon.Icon");
			this.notifyIcon.Text = "ShinWorkshop";
			this.notifyIcon.Visible = true;
			this.notifyIcon.MouseClick += new MouseEventHandler(this.notifyIcon_MouseClick);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.Window;
			base.ClientSize = new Size(992, 666);
			base.Controls.Add(this.statusStrip);
			base.Controls.Add(this.menuStrip1);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.IsMdiContainer = true;
			base.MainMenuStrip = this.menuStrip1;
			base.Name = "MyForm";
			this.Text = "ShinROSE Dev Workshop";
			base.Load += new EventHandler(this.MyForm_Load);
			base.Resize += new EventHandler(this.MyForm_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public MyForm()
		{
			this.InitializeComponent();
		}

		private void ExitButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MyForm_Load(object sender, EventArgs e)
		{
		}

		private void About_ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox aboutBox = new AboutBox();
			aboutBox.ShowDialog();
		}

		private void Load_ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog.ShowDialog() == DialogResult.OK)
			{
				string[] array = this.openFileDialog.FileName.Split(new char[]
				{
					'.'
				});
				string text = array[array.Length - 1].ToUpper();
				switch (text)
				{
				case "STB":
				{
					STBForm sTBForm = new STBForm();
					sTBForm.MdiParent = this;
					sTBForm.Show();
					sTBForm.BringToFront();
					sTBForm.Text = "STB : \"" + this.openFileDialog.FileName + "\"";
					sTBForm.Load_STB(this.openFileDialog.FileName);
					break;
				}
				case "LTB":
				{
					LTBForm lTBForm = new LTBForm();
					lTBForm.MdiParent = this;
					lTBForm.Show();
					lTBForm.BringToFront();
					lTBForm.Text = "LTB : \"" + this.openFileDialog.FileName + "\"";
					lTBForm.Load_LTB(this.openFileDialog.FileName);
					break;
				}
				case "STL":
				{
					STLForm sTLForm = new STLForm();
					sTLForm.MdiParent = this;
					sTLForm.Show();
					sTLForm.BringToFront();
					sTLForm.Text = "STL : \"" + this.openFileDialog.FileName + "\"";
					sTLForm.Load_STL(this.openFileDialog.FileName);
					break;
				}
				case "IDX":
				{
					MainForm mainForm = new MainForm();
					mainForm.MdiParent = this;
					mainForm.OpenFileDialog.FileName = this.openFileDialog.FileName;
					mainForm.Show();
					mainForm.BringToFront();
					mainForm.Text = "IDX : \"" + this.openFileDialog.FileName + "\"";
					mainForm.load_VFS(this.openFileDialog.FileName);
					break;
				}
				case "QSD":
				{
					ShinROSE_Dev_Workshop.QSD.AIPEditorForm aIPEditorForm = new ShinROSE_Dev_Workshop.QSD.AIPEditorForm();
					aIPEditorForm.MdiParent = this;
					aIPEditorForm.Show();
					aIPEditorForm.BringToFront();
					aIPEditorForm.Text = "QSD : \"" + this.openFileDialog.FileName + "\"";
					aIPEditorForm.load_qsd_info(this.openFileDialog.FileName);
					break;
				}
				case "AIP":
				{
					ShinROSE_Dev_Workshop.AIP.AIPEditorForm aIPEditorForm2 = new ShinROSE_Dev_Workshop.AIP.AIPEditorForm();
					aIPEditorForm2.MdiParent = this;
					aIPEditorForm2.Show();
					aIPEditorForm2.BringToFront();
					aIPEditorForm2.Text = "AIP : \"" + this.openFileDialog.FileName + "\"";
					aIPEditorForm2.load_aip_info(this.openFileDialog.FileName);
					break;
				}
				case "TSI":
				{
					TSIForm tSIForm = new TSIForm();
					tSIForm.MdiParent = this;
					tSIForm.Show();
					tSIForm.BringToFront();
					tSIForm.Text = "TSI : \"" + this.openFileDialog.FileName + "\"";
					tSIForm.load_tsi(this.openFileDialog.FileName);
					break;
				}
				case "CHR":
				{
					CHRForm cHRForm = new CHRForm();
					cHRForm.MdiParent = this;
					cHRForm.Show();
					cHRForm.BringToFront();
					cHRForm.Text = "CHR : \"" + this.openFileDialog.FileName + "\"";
					cHRForm.load_chr(this.openFileDialog.FileName);
					break;
				}
				case "ZSC":
				{
					ZSCForm zSCForm = new ZSCForm();
					zSCForm.MdiParent = this;
					zSCForm.Show();
					zSCForm.BringToFront();
					zSCForm.Text = "ZSC : \"" + this.openFileDialog.FileName + "\"";
					zSCForm.load_zsc(this.openFileDialog.FileName);
					break;
				}
				}
			}
		}

		private void NewSTBFormpMenuItem_Click(object sender, EventArgs e)
		{
			STBForm sTBForm = new STBForm();
			sTBForm.MdiParent = this;
			sTBForm.Show();
			sTBForm.Text = "STB : ";
		}

		private void NewQSDMenuItem_Click(object sender, EventArgs e)
		{
			ShinROSE_Dev_Workshop.QSD.AIPEditorForm aIPEditorForm = new ShinROSE_Dev_Workshop.QSD.AIPEditorForm();
			aIPEditorForm.MdiParent = this;
			aIPEditorForm.Show();
			aIPEditorForm.Text = "QSD : ";
		}

		private void newAIPMenuItem_Click(object sender, EventArgs e)
		{
			ShinROSE_Dev_Workshop.AIP.AIPEditorForm aIPEditorForm = new ShinROSE_Dev_Workshop.AIP.AIPEditorForm();
			aIPEditorForm.MdiParent = this;
			aIPEditorForm.Show();
			aIPEditorForm.Text = "AIP : ";
		}

		private void newIDXMenuItem_Click(object sender, EventArgs e)
		{
			MainForm mainForm = new MainForm();
			mainForm.MdiParent = this;
			mainForm.Show();
			mainForm.Text = "IDX : ";
		}

		private void newLTBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			LTBForm lTBForm = new LTBForm();
			lTBForm.MdiParent = this;
			lTBForm.Show();
			lTBForm.Text = "LTB : ";
		}

		private void newSTLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			STLForm sTLForm = new STLForm();
			sTLForm.MdiParent = this;
			sTLForm.Show();
			sTLForm.Text = "STL : ";
		}

		private void MainPanel_Paint(object sender, PaintEventArgs e)
		{
		}

		private void MyForm_Resize(object sender, EventArgs e)
		{
		}

		private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
		{
		}

		private void newZSCToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ZSCForm zSCForm = new ZSCForm();
			zSCForm.MdiParent = this;
			zSCForm.Show();
			zSCForm.Text = "ZSC : ";
		}

		private void newTSIToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TSIForm tSIForm = new TSIForm();
			tSIForm.MdiParent = this;
			tSIForm.Show();
			tSIForm.Text = "TSI : ";
		}

		private void newCHRToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CHRForm cHRForm = new CHRForm();
			cHRForm.MdiParent = this;
			cHRForm.Show();
			cHRForm.Text = "CHR : ";
		}
	}
}
