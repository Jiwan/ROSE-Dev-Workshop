using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.XPath;

namespace ShinROSE_Dev_Workshop.QSD
{
	public class ChangeDataDialog : Form
	{
		public string data_select = "";

		public string opcode_select = "";

		private string[] Opcode_type;

		private IContainer components = null;

		private Button buttonApply;

		private Label labelChangeBy;

		private ListBox listBoxData;

		private TextBox textBoxOpcode;

		private Label labelOpcode;

		public ChangeDataDialog()
		{
			this.InitializeComponent();
			this.listBoxData.Items.Add("Unknow Opcode");
		}

		public void import_opcode_condition(string app_path)
		{
			XPathDocument xPathDocument = new XPathDocument(app_path + "\\ConditionQSD.xml");
			XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
			string xpath = ".//Opcode";
			XPathNodeIterator xPathNodeIterator = xPathNavigator.Select(xPathNavigator.Compile(xpath));
			this.Opcode_type = new string[xPathNodeIterator.Count];
			for (int num = 0; num != xPathNodeIterator.Count; num++)
			{
				xPathNodeIterator.MoveNext();
				this.Opcode_type[num] = xPathNodeIterator.Current.GetAttribute("id", "");
				xPathNodeIterator.Current.MoveToFirstChild();
				this.listBoxData.Items.Add(xPathNodeIterator.Current.Value);
			}
		}

		public void import_opcode_action(string app_path)
		{
			XPathDocument xPathDocument = new XPathDocument(app_path + "\\ActionQSD.xml");
			XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
			string xpath = ".//Opcode";
			XPathNodeIterator xPathNodeIterator = xPathNavigator.Select(xPathNavigator.Compile(xpath));
			this.Opcode_type = new string[xPathNodeIterator.Count];
			for (int num = 0; num != xPathNodeIterator.Count; num++)
			{
				xPathNodeIterator.MoveNext();
				this.Opcode_type[num] = xPathNodeIterator.Current.GetAttribute("id", "");
				xPathNodeIterator.Current.MoveToFirstChild();
				this.listBoxData.Items.Add(xPathNodeIterator.Current.Value);
			}
		}

		private void buttonApply_Click(object sender, EventArgs e)
		{
			this.data_select = this.listBoxData.SelectedItem.ToString();
			this.opcode_select = this.textBoxOpcode.Text;
			base.DialogResult = DialogResult.OK;
		}

		private void listBoxData_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBoxData.SelectedItem.ToString() == "Unknow Opcode")
			{
				this.textBoxOpcode.Text = "0x30";
				this.textBoxOpcode.Enabled = true;
			}
			else
			{
				this.textBoxOpcode.Enabled = false;
				this.textBoxOpcode.Text = this.Opcode_type[this.listBoxData.SelectedIndex - 1];
			}
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
			this.buttonApply = new Button();
			this.labelChangeBy = new Label();
			this.listBoxData = new ListBox();
			this.textBoxOpcode = new TextBox();
			this.labelOpcode = new Label();
			base.SuspendLayout();
			this.buttonApply.Location = new Point(82, 158);
			this.buttonApply.Name = "buttonApply";
			this.buttonApply.Size = new Size(128, 38);
			this.buttonApply.TabIndex = 0;
			this.buttonApply.Text = "Apply";
			this.buttonApply.UseVisualStyleBackColor = true;
			this.buttonApply.Click += new EventHandler(this.buttonApply_Click);
			this.labelChangeBy.AutoSize = true;
			this.labelChangeBy.Location = new Point(12, 12);
			this.labelChangeBy.Name = "labelChangeBy";
			this.labelChangeBy.Size = new Size(64, 13);
			this.labelChangeBy.TabIndex = 1;
			this.labelChangeBy.Text = "Change by :";
			this.listBoxData.FormattingEnabled = true;
			this.listBoxData.Location = new Point(82, 12);
			this.listBoxData.Name = "listBoxData";
			this.listBoxData.Size = new Size(128, 95);
			this.listBoxData.TabIndex = 2;
			this.listBoxData.SelectedIndexChanged += new EventHandler(this.listBoxData_SelectedIndexChanged);
			this.textBoxOpcode.Enabled = false;
			this.textBoxOpcode.Location = new Point(82, 122);
			this.textBoxOpcode.Name = "textBoxOpcode";
			this.textBoxOpcode.Size = new Size(128, 20);
			this.textBoxOpcode.TabIndex = 3;
			this.labelOpcode.AutoSize = true;
			this.labelOpcode.Location = new Point(12, 125);
			this.labelOpcode.Name = "labelOpcode";
			this.labelOpcode.Size = new Size(51, 13);
			this.labelOpcode.TabIndex = 4;
			this.labelOpcode.Text = "Opcode :";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.ActiveCaptionText;
			base.ClientSize = new Size(292, 208);
			base.Controls.Add(this.labelOpcode);
			base.Controls.Add(this.textBoxOpcode);
			base.Controls.Add(this.listBoxData);
			base.Controls.Add(this.labelChangeBy);
			base.Controls.Add(this.buttonApply);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ChangeDataDialog";
			this.Text = "ChangeDataDialog";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
