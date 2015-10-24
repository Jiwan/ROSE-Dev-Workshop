using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop.STB.converter.Stb_to_xml_converter
{
	public class MainForm : Form
	{
		private Converter converter = new Converter();

		private IContainer components = null;

		private Label labelInputPath;

		private Label labelOutputPath;

		private Button buttonConvert;

		private TextBox textBoxInputPath;

		private TextBox textBoxOutputPath;

		private Button buttonOpenInput;

		private Button buttonOpenOutput;

		private OpenFileDialog openFileDialog;

		private SaveFileDialog saveFileDialog;

		private CheckedListBox checkedListBox;

		private Label labelColumnSelect;

		public MainForm()
		{
			this.InitializeComponent();
		}

		private void buttonOpenInput_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.textBoxInputPath.Text = this.openFileDialog.FileName;
				this.converter.Load_STB(this.textBoxInputPath.Text);
				this.checkedListBox.Items.Clear();
				int columncount = this.converter.columncount;
				for (int num = 1; num != columncount; num++)
				{
					this.checkedListBox.Items.Add(this.converter.column[num].columntitle);
				}
			}
		}

		private void buttonOpenOutput_Click(object sender, EventArgs e)
		{
			if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.textBoxOutputPath.Text = this.saveFileDialog.FileName;
			}
		}

		private void buttonConvert_Click(object sender, EventArgs e)
		{
			CheckedListBox.CheckedIndexCollection checkedIndices = this.checkedListBox.CheckedIndices;
			for (int num = 0; num != checkedIndices.Count; num++)
			{
				this.converter.column[checkedIndices[num]].selected = true;
			}
			this.converter.Save_XML(this.textBoxOutputPath.Text);
			this.buttonConvert.Text = "Done!";
		}

		private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
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
			this.labelInputPath = new Label();
			this.labelOutputPath = new Label();
			this.buttonConvert = new Button();
			this.textBoxInputPath = new TextBox();
			this.textBoxOutputPath = new TextBox();
			this.buttonOpenInput = new Button();
			this.buttonOpenOutput = new Button();
			this.openFileDialog = new OpenFileDialog();
			this.saveFileDialog = new SaveFileDialog();
			this.checkedListBox = new CheckedListBox();
			this.labelColumnSelect = new Label();
			base.SuspendLayout();
			this.labelInputPath.AutoSize = true;
			this.labelInputPath.Location = new Point(12, 16);
			this.labelInputPath.Name = "labelInputPath";
			this.labelInputPath.Size = new Size(56, 13);
			this.labelInputPath.TabIndex = 0;
			this.labelInputPath.Text = "Input File :";
			this.labelOutputPath.AutoSize = true;
			this.labelOutputPath.Location = new Point(4, 55);
			this.labelOutputPath.Name = "labelOutputPath";
			this.labelOutputPath.Size = new Size(64, 13);
			this.labelOutputPath.TabIndex = 1;
			this.labelOutputPath.Text = "Output File :";
			this.buttonConvert.Location = new Point(93, 214);
			this.buttonConvert.Name = "buttonConvert";
			this.buttonConvert.Size = new Size(126, 40);
			this.buttonConvert.TabIndex = 2;
			this.buttonConvert.Text = "Convert";
			this.buttonConvert.UseVisualStyleBackColor = true;
			this.buttonConvert.Click += new EventHandler(this.buttonConvert_Click);
			this.textBoxInputPath.Location = new Point(74, 12);
			this.textBoxInputPath.Name = "textBoxInputPath";
			this.textBoxInputPath.Size = new Size(159, 20);
			this.textBoxInputPath.TabIndex = 3;
			this.textBoxOutputPath.Location = new Point(74, 52);
			this.textBoxOutputPath.Name = "textBoxOutputPath";
			this.textBoxOutputPath.Size = new Size(159, 20);
			this.textBoxOutputPath.TabIndex = 4;
			this.buttonOpenInput.Location = new Point(239, 12);
			this.buttonOpenInput.Name = "buttonOpenInput";
			this.buttonOpenInput.Size = new Size(41, 20);
			this.buttonOpenInput.TabIndex = 5;
			this.buttonOpenInput.Text = "Open";
			this.buttonOpenInput.UseVisualStyleBackColor = true;
			this.buttonOpenInput.Click += new EventHandler(this.buttonOpenInput_Click);
			this.buttonOpenOutput.Location = new Point(239, 51);
			this.buttonOpenOutput.Name = "buttonOpenOutput";
			this.buttonOpenOutput.Size = new Size(41, 21);
			this.buttonOpenOutput.TabIndex = 6;
			this.buttonOpenOutput.Text = "Open";
			this.buttonOpenOutput.UseVisualStyleBackColor = true;
			this.buttonOpenOutput.Click += new EventHandler(this.buttonOpenOutput_Click);
			this.openFileDialog.Filter = "Fichier STB|*.stb";
			this.saveFileDialog.Filter = "Fichier XML|*.xml";
			this.checkedListBox.FormattingEnabled = true;
			this.checkedListBox.Location = new Point(74, 84);
			this.checkedListBox.Name = "checkedListBox";
			this.checkedListBox.Size = new Size(159, 124);
			this.checkedListBox.TabIndex = 7;
			this.checkedListBox.SelectedIndexChanged += new EventHandler(this.checkedListBox_SelectedIndexChanged);
			this.labelColumnSelect.AutoSize = true;
			this.labelColumnSelect.Location = new Point(8, 92);
			this.labelColumnSelect.Name = "labelColumnSelect";
			this.labelColumnSelect.Size = new Size(53, 26);
			this.labelColumnSelect.TabIndex = 8;
			this.labelColumnSelect.Text = "Select \r\nColumns :\r\n";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(292, 266);
			base.Controls.Add(this.labelColumnSelect);
			base.Controls.Add(this.checkedListBox);
			base.Controls.Add(this.buttonOpenOutput);
			base.Controls.Add(this.buttonOpenInput);
			base.Controls.Add(this.textBoxOutputPath);
			base.Controls.Add(this.textBoxInputPath);
			base.Controls.Add(this.buttonConvert);
			base.Controls.Add(this.labelOutputPath);
			base.Controls.Add(this.labelInputPath);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MainForm";
			this.Text = "Stb to Xml";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
