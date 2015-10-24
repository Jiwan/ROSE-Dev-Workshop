using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop.ZSC
{
	public class ImportForm : Form
	{
		public List<Mesh> list_mesh = new List<Mesh>();

		public List<Materiel> list_materiel = new List<Materiel>();

		public List<Effect> list_effect = new List<Effect>();

		public List<Object> list_object = new List<Object>();

		private IContainer components = null;

		private Label label;

		private TextBox textBoxInputPath;

		private Button buttonOpenInput;

		private Button buttonImport;

		public ListBox listBox;

		private OpenFileDialog openFileDialog;

		private Button buttonLoad;

		public ImportForm()
		{
			this.InitializeComponent();
		}

		private void buttonOpenInput_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.textBoxInputPath.Text = this.openFileDialog.FileName;
			}
		}

		public void load_chr(string path)
		{
			this.listBox.Items.Clear();
			BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open), Encoding.GetEncoding("EUC-KR"));
			int num = (int)binaryReader.ReadInt16();
			for (int num2 = 0; num2 != num; num2++)
			{
				Mesh mesh = new Mesh();
				mesh.read(ref binaryReader);
				this.list_mesh.Add(mesh);
			}
			int num3 = (int)binaryReader.ReadInt16();
			for (int num2 = 0; num2 != num3; num2++)
			{
				Materiel materiel = new Materiel();
				materiel.read(ref binaryReader);
				this.list_materiel.Add(materiel);
			}
			int num4 = (int)binaryReader.ReadInt16();
			for (int num2 = 0; num2 != num4; num2++)
			{
				Effect effect = new Effect();
				effect.read(ref binaryReader);
				this.list_effect.Add(effect);
			}
			int num5 = (int)binaryReader.ReadInt16();
			for (int num2 = 0; num2 != num5; num2++)
			{
				Object @object = new Object();
				@object.read(ref binaryReader);
				this.list_object.Add(@object);
				this.listBox.Items.Add("Entry [" + num2 + "] : ");
			}
			binaryReader.Close();
		}

		private void buttonImport_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
		}

		private void buttonLoad_Click(object sender, EventArgs e)
		{
			this.load_chr(this.textBoxInputPath.Text);
			this.buttonImport.Enabled = true;
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
			this.label = new Label();
			this.textBoxInputPath = new TextBox();
			this.buttonOpenInput = new Button();
			this.buttonImport = new Button();
			this.listBox = new ListBox();
			this.openFileDialog = new OpenFileDialog();
			this.buttonLoad = new Button();
			base.SuspendLayout();
			this.label.AutoSize = true;
			this.label.Location = new Point(12, 46);
			this.label.Name = "label";
			this.label.Size = new Size(58, 13);
			this.label.TabIndex = 0;
			this.label.Text = "ZSC path :";
			this.textBoxInputPath.Location = new Point(78, 43);
			this.textBoxInputPath.Name = "textBoxInputPath";
			this.textBoxInputPath.Size = new Size(159, 20);
			this.textBoxInputPath.TabIndex = 4;
			this.buttonOpenInput.Location = new Point(243, 43);
			this.buttonOpenInput.Name = "buttonOpenInput";
			this.buttonOpenInput.Size = new Size(41, 20);
			this.buttonOpenInput.TabIndex = 6;
			this.buttonOpenInput.Text = "Open";
			this.buttonOpenInput.UseVisualStyleBackColor = true;
			this.buttonOpenInput.Click += new EventHandler(this.buttonOpenInput_Click);
			this.buttonImport.Enabled = false;
			this.buttonImport.Location = new Point(88, 216);
			this.buttonImport.Name = "buttonImport";
			this.buttonImport.Size = new Size(126, 40);
			this.buttonImport.TabIndex = 7;
			this.buttonImport.Text = "Import";
			this.buttonImport.UseVisualStyleBackColor = true;
			this.buttonImport.Click += new EventHandler(this.buttonImport_Click);
			this.listBox.FormattingEnabled = true;
			this.listBox.Location = new Point(88, 106);
			this.listBox.Name = "listBox";
			this.listBox.Size = new Size(126, 95);
			this.listBox.TabIndex = 8;
			this.openFileDialog.Filter = "Fichier ZSC|*.zsc";
			this.buttonLoad.Location = new Point(102, 69);
			this.buttonLoad.Name = "buttonLoad";
			this.buttonLoad.Size = new Size(98, 25);
			this.buttonLoad.TabIndex = 9;
			this.buttonLoad.Text = "Load";
			this.buttonLoad.UseVisualStyleBackColor = true;
			this.buttonLoad.Click += new EventHandler(this.buttonLoad_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(292, 268);
			base.Controls.Add(this.buttonLoad);
			base.Controls.Add(this.listBox);
			base.Controls.Add(this.buttonImport);
			base.Controls.Add(this.buttonOpenInput);
			base.Controls.Add(this.textBoxInputPath);
			base.Controls.Add(this.label);
			base.MaximizeBox = false;
			base.Name = "ImportForm";
			this.Text = "Import :";
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
