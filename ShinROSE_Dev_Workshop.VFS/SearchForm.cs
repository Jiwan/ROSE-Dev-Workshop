using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop.VFS
{
	public class SearchForm : Form
	{
		public string fichier;

		private IContainer components = null;

		private Label labelSearch;

		private TextBox textBoxSearch;

		private Button buttonGo;

		public SearchForm()
		{
			this.InitializeComponent();
		}

		private void buttonGo_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void textBoxSearch_TextChanged(object sender, EventArgs e)
		{
			this.fichier = this.textBoxSearch.Text;
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
			this.labelSearch = new Label();
			this.textBoxSearch = new TextBox();
			this.buttonGo = new Button();
			base.SuspendLayout();
			this.labelSearch.AutoSize = true;
			this.labelSearch.Location = new Point(12, 29);
			this.labelSearch.Name = "labelSearch";
			this.labelSearch.Size = new Size(47, 13);
			this.labelSearch.TabIndex = 0;
			this.labelSearch.Text = "Search :";
			this.textBoxSearch.Location = new Point(65, 26);
			this.textBoxSearch.Name = "textBoxSearch";
			this.textBoxSearch.Size = new Size(183, 20);
			this.textBoxSearch.TabIndex = 1;
			this.textBoxSearch.TextChanged += new EventHandler(this.textBoxSearch_TextChanged);
			this.buttonGo.Location = new Point(264, 26);
			this.buttonGo.Name = "buttonGo";
			this.buttonGo.Size = new Size(47, 20);
			this.buttonGo.TabIndex = 2;
			this.buttonGo.Text = "Go";
			this.buttonGo.UseVisualStyleBackColor = true;
			this.buttonGo.Click += new EventHandler(this.buttonGo_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(321, 83);
			base.Controls.Add(this.buttonGo);
			base.Controls.Add(this.textBoxSearch);
			base.Controls.Add(this.labelSearch);
			base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
			base.Name = "SearchForm";
			this.Text = "Search";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
