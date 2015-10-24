using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop.STB
{
	public class Userdialog : Form
	{
		private IContainer components = null;

		public Label LabelInfo;

		public TextBox textBoxInfo;

		public new Button Update;

		public Button Cancel;

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
			this.LabelInfo = new Label();
			this.textBoxInfo = new TextBox();
			this.Update = new Button();
			this.Cancel = new Button();
			base.SuspendLayout();
			this.LabelInfo.AutoSize = true;
			this.LabelInfo.Location = new Point(12, 9);
			this.LabelInfo.Name = "LabelInfo";
			this.LabelInfo.Size = new Size(67, 13);
			this.LabelInfo.TabIndex = 1;
			this.LabelInfo.Text = "Rename by :";
			this.textBoxInfo.Location = new Point(12, 41);
			this.textBoxInfo.Name = "textBoxInfo";
			this.textBoxInfo.Size = new Size(276, 20);
			this.textBoxInfo.TabIndex = 3;
			this.Update.Location = new Point(123, 67);
			this.Update.Name = "Update";
			this.Update.Size = new Size(55, 23);
			this.Update.TabIndex = 1;
			this.Update.Text = "Update";
			this.Update.UseVisualStyleBackColor = true;
			this.Update.Click += new EventHandler(this.Update_Click);
			this.Cancel.Location = new Point(123, 103);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new Size(55, 23);
			this.Cancel.TabIndex = 4;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new EventHandler(this.Cancel_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(300, 138);
			base.Controls.Add(this.Cancel);
			base.Controls.Add(this.textBoxInfo);
			base.Controls.Add(this.Update);
			base.Controls.Add(this.LabelInfo);
			base.Name = "Rename";
			this.Text = "Rename";
			base.Load += new EventHandler(this.Rename_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public Userdialog()
		{
			this.InitializeComponent();
		}

		private void Rename_Load(object sender, EventArgs e)
		{
		}

		private void Update_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
		}
	}
}
