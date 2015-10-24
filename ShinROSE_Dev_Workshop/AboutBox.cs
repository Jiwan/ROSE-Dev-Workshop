using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop
{
	internal class AboutBox : Form
	{
		private IContainer components = null;

		private TableLayoutPanel tableLayoutPanel;

		private PictureBox logoPictureBox;

		private Label labelProductName;

		private Label labelVersion;

		private Label labelCopyright;

		private Label labelCompanyName;

		private TextBox textBoxDescription;

		private Button okButton;

		public string AssemblyTitle
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				string result;
				if (customAttributes.Length > 0)
				{
					AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
					if (assemblyTitleAttribute.Title != "")
					{
						result = assemblyTitleAttribute.Title;
						return result;
					}
				}
				result = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
				return result;
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				string result;
				if (customAttributes.Length == 0)
				{
					result = "";
				}
				else
				{
					result = ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
				}
				return result;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				string result;
				if (customAttributes.Length == 0)
				{
					result = "";
				}
				else
				{
					result = ((AssemblyProductAttribute)customAttributes[0]).Product;
				}
				return result;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				string result;
				if (customAttributes.Length == 0)
				{
					result = "";
				}
				else
				{
					result = ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
				}
				return result;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				string result;
				if (customAttributes.Length == 0)
				{
					result = "";
				}
				else
				{
					result = ((AssemblyCompanyAttribute)customAttributes[0]).Company;
				}
				return result;
			}
		}

		public AboutBox()
		{
			this.InitializeComponent();
		}

		private void AboutBox_Load(object sender, EventArgs e)
		{
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void textBoxDescription_TextChanged(object sender, EventArgs e)
		{
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
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(AboutBox));
			this.tableLayoutPanel = new TableLayoutPanel();
			this.logoPictureBox = new PictureBox();
			this.labelProductName = new Label();
			this.labelVersion = new Label();
			this.labelCopyright = new Label();
			this.labelCompanyName = new Label();
			this.textBoxDescription = new TextBox();
			this.okButton = new Button();
			this.tableLayoutPanel.SuspendLayout();
			((ISupportInitialize)this.logoPictureBox).BeginInit();
			base.SuspendLayout();
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33f));
			this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67f));
			this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
			this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
			this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
			this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
			this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
			this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
			this.tableLayoutPanel.Dock = DockStyle.Fill;
			this.tableLayoutPanel.Location = new Point(9, 9);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 6;
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
			this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
			this.tableLayoutPanel.Size = new Size(417, 265);
			this.tableLayoutPanel.TabIndex = 0;
			this.logoPictureBox.Dock = DockStyle.Fill;
			this.logoPictureBox.Image = (Image)componentResourceManager.GetObject("logoPictureBox.Image");
			this.logoPictureBox.InitialImage = (Image)componentResourceManager.GetObject("logoPictureBox.InitialImage");
			this.logoPictureBox.Location = new Point(3, 3);
			this.logoPictureBox.Name = "logoPictureBox";
			this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
			this.logoPictureBox.Size = new Size(131, 259);
			this.logoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			this.logoPictureBox.TabIndex = 12;
			this.logoPictureBox.TabStop = false;
			this.labelProductName.Dock = DockStyle.Fill;
			this.labelProductName.Location = new Point(143, 0);
			this.labelProductName.Margin = new Padding(6, 0, 3, 0);
			this.labelProductName.MaximumSize = new Size(0, 17);
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.Size = new Size(271, 17);
			this.labelProductName.TabIndex = 19;
			this.labelProductName.Text = "ShinROSE Dev Workshop by Juan";
			this.labelProductName.TextAlign = ContentAlignment.MiddleLeft;
			this.labelVersion.Dock = DockStyle.Fill;
			this.labelVersion.Location = new Point(143, 26);
			this.labelVersion.Margin = new Padding(6, 0, 3, 0);
			this.labelVersion.MaximumSize = new Size(0, 17);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new Size(271, 17);
			this.labelVersion.TabIndex = 0;
			this.labelVersion.Text = "Version BETA (1.00)";
			this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
			this.labelCopyright.Dock = DockStyle.Fill;
			this.labelCopyright.Location = new Point(143, 52);
			this.labelCopyright.Margin = new Padding(6, 0, 3, 0);
			this.labelCopyright.MaximumSize = new Size(0, 17);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new Size(271, 17);
			this.labelCopyright.TabIndex = 21;
			this.labelCopyright.Text = "ShinROSE";
			this.labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
			this.labelCompanyName.Dock = DockStyle.Fill;
			this.labelCompanyName.Location = new Point(143, 78);
			this.labelCompanyName.Margin = new Padding(6, 0, 3, 0);
			this.labelCompanyName.MaximumSize = new Size(0, 17);
			this.labelCompanyName.Name = "labelCompanyName";
			this.labelCompanyName.Size = new Size(271, 17);
			this.labelCompanyName.TabIndex = 22;
			this.labelCompanyName.Text = "Shinra Gaming";
			this.labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
			this.textBoxDescription.Dock = DockStyle.Fill;
			this.textBoxDescription.Location = new Point(143, 107);
			this.textBoxDescription.Margin = new Padding(6, 3, 3, 3);
			this.textBoxDescription.Multiline = true;
			this.textBoxDescription.Name = "textBoxDescription";
			this.textBoxDescription.ReadOnly = true;
			this.textBoxDescription.ScrollBars = ScrollBars.Both;
			this.textBoxDescription.Size = new Size(271, 126);
			this.textBoxDescription.TabIndex = 23;
			this.textBoxDescription.TabStop = false;
			this.textBoxDescription.Text = "Credits to : - Tohma :D\r\n- Brett & Exjam for files formats .<3\r\n- 7H staff for somes opcodes... \r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n*joke*Lmame suck badly*joke*";
			this.textBoxDescription.TextChanged += new EventHandler(this.textBoxDescription_TextChanged);
			this.okButton.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
			this.okButton.DialogResult = DialogResult.Cancel;
			this.okButton.Location = new Point(339, 239);
			this.okButton.Name = "okButton";
			this.okButton.Size = new Size(75, 23);
			this.okButton.TabIndex = 24;
			this.okButton.Text = "&OK";
			this.okButton.Click += new EventHandler(this.okButton_Click);
			base.AcceptButton = this.okButton;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(435, 283);
			base.Controls.Add(this.tableLayoutPanel);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AboutBox";
			base.Padding = new Padding(9);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "AboutBox";
			base.Load += new EventHandler(this.AboutBox_Load);
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			((ISupportInitialize)this.logoPictureBox).EndInit();
			base.ResumeLayout(false);
		}
	}
}
