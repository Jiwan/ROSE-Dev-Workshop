using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop.AIP
{
	public class Description : Form
	{
		private IContainer components = null;

		public Label labelName;

		public TextBox textBox;

		private Button buttonChange;

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
			this.labelName = new Label();
			this.textBox = new TextBox();
			this.buttonChange = new Button();
			base.SuspendLayout();
			this.labelName.AutoSize = true;
			this.labelName.Location = new Point(12, 40);
			this.labelName.Name = "labelName";
			this.labelName.Size = new Size(122, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Rename(32 chars max) :";
			this.textBox.Location = new Point(140, 37);
			this.textBox.Name = "textBox";
			this.textBox.Size = new Size(169, 20);
			this.textBox.TabIndex = 1;
			this.buttonChange.Location = new Point(315, 33);
			this.buttonChange.Name = "buttonChange";
			this.buttonChange.Size = new Size(57, 26);
			this.buttonChange.TabIndex = 2;
			this.buttonChange.Text = "Change";
			this.buttonChange.UseVisualStyleBackColor = true;
			this.buttonChange.Click += new EventHandler(this.buttonChange_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = SystemColors.ActiveCaptionText;
			base.ClientSize = new Size(384, 100);
			base.Controls.Add(this.buttonChange);
			base.Controls.Add(this.textBox);
			base.Controls.Add(this.labelName);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Name = "Description";
			this.Text = "Description";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public Description()
		{
			this.InitializeComponent();
		}

		private void buttonChange_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}
	}
}
