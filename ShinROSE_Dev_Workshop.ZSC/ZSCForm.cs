using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop.ZSC
{
	public class ZSCForm : Form
	{
		private List<Mesh> list_mesh = new List<Mesh>();

		private List<Materiel> list_materiel = new List<Materiel>();

		private List<Effect> list_effect = new List<Effect>();

		private List<Object> list_object = new List<Object>();

		private Object copy_object;

		private Graphics graphics;

		private GraphicsStream gs;

		private IContainer components = null;

		private MenuStrip menuStrip;

		private ToolStripMenuItem fileToolStripMenuItem;

		private ToolStripMenuItem OpenToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem saveToolStripMenuItem;

		private ToolStripMenuItem saveAsToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem exitToolStripMenuItem;

		private TreeView treeView;

		private TreeView treeViewObject;

		private StatusStrip statusStrip;

		private ToolStripStatusLabel StatusLabel;

		private PropertyGrid propertyGrid;

		private Label label;

		private PictureBox pictureBox;

		private OpenFileDialog openFileDialog;

		private ContextMenuStrip contextMenuStrip;

		private ToolStripMenuItem addPathToolStripMenuItem;

		private ToolStripMenuItem deletedPathToolStripMenuItem;

		private ContextMenuStrip contextMenuObject;

		private ToolStripMenuItem addEntryToolStripMenuItem;

		private ToolStripMenuItem removeEntryToolStripMenuItem;

		private ToolStripMenuItem importEntryToolStripMenuItem;

		private ToolStripMenuItem copyEntryToolStripMenuItem;

		private ToolStripMenuItem pasteEntryToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripMenuItem addToolStripMenuItem;

		private ToolStripMenuItem removeToolStripMenuItem;

		private ToolStripMenuItem optionToolStripMenuItem;

		private ToolStripMenuItem clientPathToolStripMenuItem;

		private TextBox textBoxpreviewpath;

		private SaveFileDialog saveFileDialog;

		public ZSCForm()
		{
			this.InitializeComponent();
		}

		public void load_zsc(string path)
		{
			this.treeView.Nodes.Clear();
			this.treeViewObject.Nodes.Clear();
			this.list_mesh.Clear();
			this.list_effect.Clear();
			this.list_materiel.Clear();
			this.list_object.Clear();
			BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open));
			int num = (int)binaryReader.ReadInt16();
			this.treeView.Nodes.Add("Mesh-ZMS [" + num + "]");
			for (int num2 = 0; num2 != num; num2++)
			{
				Mesh mesh = new Mesh();
				mesh.read(ref binaryReader);
				this.treeView.Nodes[0].Nodes.Add(string.Concat(new object[]
				{
					"[",
					num2,
					"]",
					mesh.path
				}));
				this.list_mesh.Add(mesh);
			}
			int num3 = (int)binaryReader.ReadInt16();
			this.treeView.Nodes.Add("Materiel-DDS [" + num3 + "]");
			for (int num2 = 0; num2 != num3; num2++)
			{
				Materiel materiel = new Materiel();
				materiel.read(ref binaryReader);
				this.treeView.Nodes[1].Nodes.Add(string.Concat(new object[]
				{
					"[",
					num2,
					"]",
					materiel.path
				}));
				this.list_materiel.Add(materiel);
			}
			int num4 = (int)binaryReader.ReadInt16();
			this.treeView.Nodes.Add("Effect-eft [" + num4 + "]");
			for (int num2 = 0; num2 != num4; num2++)
			{
				Effect effect = new Effect();
				effect.read(ref binaryReader);
				this.treeView.Nodes[2].Nodes.Add(string.Concat(new object[]
				{
					"[",
					num2,
					"]",
					effect.path
				}));
				this.list_effect.Add(effect);
			}
			int num5 = (int)binaryReader.ReadInt16();
			for (int num2 = 0; num2 != num5; num2++)
			{
				Object @object = new Object();
				@object.read(ref binaryReader);
				this.list_object.Add(@object);
				this.treeViewObject.Nodes.Add("Entry [" + num2 + "] : ");
				this.treeViewObject.Nodes[num2].Nodes.Add("Meshs [" + @object.list_mesh.Count + "]");
				for (int num6 = 0; num6 != @object.list_mesh.Count; num6++)
				{
					this.treeViewObject.Nodes[num2].Nodes[0].Nodes.Add(string.Concat(new object[]
					{
						"Model [",
						@object.list_mesh[num6].mesh_id,
						"] with Texture [",
						@object.list_mesh[num6].material_id,
						"]"
					}));
				}
				this.treeViewObject.Nodes[num2].Nodes.Add("Effects [" + @object.list_effect.Count + "]");
				for (int num6 = 0; num6 != @object.list_effect.Count; num6++)
				{
					this.treeViewObject.Nodes[num2].Nodes[1].Nodes.Add("Effect[" + @object.list_effect[num6].effect_id + "]");
				}
			}
			binaryReader.Close();
		}

		public void save_zsc(string path)
		{
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create));
			binaryWriter.Write((short)this.list_mesh.Count);
			for (int num = 0; num != this.list_mesh.Count; num++)
			{
				this.list_mesh[num].save(ref binaryWriter);
			}
			binaryWriter.Write((short)this.list_materiel.Count);
			for (int num = 0; num != this.list_materiel.Count; num++)
			{
				this.list_materiel[num].save(ref binaryWriter);
			}
			binaryWriter.Write((short)this.list_effect.Count);
			for (int num = 0; num != this.list_effect.Count; num++)
			{
				this.list_effect[num].save(ref binaryWriter);
			}
			binaryWriter.Write((short)this.list_object.Count);
			for (int num = 0; num != this.list_object.Count; num++)
			{
				this.list_object[num].save(ref binaryWriter);
			}
			binaryWriter.Close();
		}

		private void ZSC_Form_Load(object sender, EventArgs e)
		{
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.load_zsc(this.openFileDialog.FileName);
			}
			this.Text = "ZSC : \"" + this.openFileDialog.FileName + "\"";
		}

		private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (this.treeView.SelectedNode.Level == 1)
			{
				this.deletedPathToolStripMenuItem.Enabled = true;
				TreeNode parent = this.treeView.SelectedNode.Parent;
				if (parent.Index == 0)
				{
					this.propertyGrid.SelectedObject = this.list_mesh[this.treeView.SelectedNode.Index];
				}
				else if (parent.Index == 1)
				{
					this.propertyGrid.SelectedObject = this.list_materiel[this.treeView.SelectedNode.Index];
					this.load_image("C:\\jeux\\Map\\" + this.list_materiel[this.treeView.SelectedNode.Index].path);
					this.textBoxpreviewpath.Text = "C:\\jeux\\Map\\" + this.list_materiel[this.treeView.SelectedNode.Index].path;
				}
				else if (parent.Index == 2)
				{
					this.propertyGrid.SelectedObject = this.list_effect[this.treeView.SelectedNode.Index];
				}
			}
			else
			{
				this.deletedPathToolStripMenuItem.Enabled = false;
			}
		}

		public void load_image(string DDS)
		{
			if (this.gs != null)
			{
				this.gs.Dispose();
			}
			try
			{
				PresentParameters presentParameters = new PresentParameters();
				presentParameters.SwapEffect = SwapEffect.Discard;
				Format format = Manager.Adapters[0].CurrentDisplayMode.Format;
				presentParameters.Windowed = true;
				Device device = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, new PresentParameters[]
				{
					presentParameters
				});
				Texture texture = TextureLoader.FromFile(device, DDS);
				this.gs = TextureLoader.SaveToStream(ImageFileFormat.Png, texture);
				texture.Dispose();
				this.pictureBox.Image = Image.FromStream(this.gs);
				device.Dispose();
				this.gs.Close();
			}
			catch (Exception var_4_B4)
			{
			}
		}

		private void addPathToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.treeView.SelectedNode.Level == 1)
			{
				TreeNode treeNode = this.treeView.SelectedNode.Parent;
				if (treeNode.Index == 0)
				{
					this.treeView.Nodes[0].Nodes.Add("[" + this.list_mesh.Count + "]New Mesh link");
					Mesh mesh = new Mesh();
					mesh.path = "path";
					this.list_mesh.Add(mesh);
					this.treeView.Nodes[0].Text = "Mesh-ZMS [" + this.list_mesh.Count + "]";
				}
				else if (treeNode.Index == 1)
				{
					this.treeView.Nodes[1].Nodes.Add("[" + this.list_materiel.Count + "]New Materiel link");
					Materiel materiel = new Materiel();
					materiel.path = "path";
					this.list_materiel.Add(materiel);
					this.treeView.Nodes[1].Text = "Materiel-DDS [" + this.list_materiel.Count + "]";
				}
				else if (treeNode.Index == 2)
				{
					this.treeView.Nodes[2].Nodes.Add("[" + this.list_effect.Count + "]New Effect link");
					Effect effect = new Effect();
					effect.path = "path";
					this.list_effect.Add(effect);
					this.treeView.Nodes[2].Text = "Effect-eft [" + this.list_effect.Count + "]";
				}
			}
			else
			{
				TreeNode treeNode = this.treeView.SelectedNode;
				if (treeNode.Index == 0)
				{
					this.treeView.Nodes[0].Nodes.Add("[" + this.list_mesh.Count + "]New Mesh link");
					Mesh mesh = new Mesh();
					mesh.path = "path";
					this.list_mesh.Add(mesh);
					this.treeView.Nodes[0].Text = "Mesh-ZMS [" + this.list_mesh.Count + "]";
				}
				else if (treeNode.Index == 1)
				{
					this.treeView.Nodes[1].Nodes.Add("[" + this.list_materiel.Count + "]New Materiel link");
					Materiel materiel = new Materiel();
					materiel.path = "path";
					this.list_materiel.Add(materiel);
					this.treeView.Nodes[1].Text = "Materiel-DDS [" + this.list_materiel.Count + "]";
				}
				else if (treeNode.Index == 2)
				{
					this.treeView.Nodes[2].Nodes.Add("[" + this.list_effect.Count + "]New Effect link");
					Effect effect = new Effect();
					effect.path = "path";
					this.list_effect.Add(effect);
					this.treeView.Nodes[2].Text = "Effect-eft [" + this.list_effect.Count + "]";
				}
			}
		}

		private void deletedPathToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode parent = this.treeView.SelectedNode.Parent;
			if (parent.Index == 0)
			{
				this.list_mesh.RemoveAt(this.treeView.SelectedNode.Index);
				this.treeView.SelectedNode.Remove();
				this.treeView.Nodes[0].Text = "Mesh-ZMS [" + this.list_mesh.Count + "]";
			}
			else if (parent.Index == 1)
			{
				this.list_materiel.RemoveAt(this.treeView.SelectedNode.Index);
				this.treeView.SelectedNode.Remove();
				this.treeView.Nodes[1].Text = "Materiel-DDS [" + this.list_materiel.Count + "]";
			}
			else if (parent.Index == 2)
			{
				this.list_effect.RemoveAt(this.treeView.SelectedNode.Index);
				this.treeView.SelectedNode.Remove();
				this.treeView.Nodes[2].Text = "Effect-eft [" + this.list_effect.Count + "]";
			}
		}

		private void treeViewCharacter_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (this.treeViewObject.SelectedNode.Level == 0)
			{
				this.propertyGrid.SelectedObject = this.list_object[this.treeViewObject.SelectedNode.Index];
				this.addEntryToolStripMenuItem.Enabled = true;
				this.removeEntryToolStripMenuItem.Enabled = true;
				this.copyEntryToolStripMenuItem.Enabled = true;
				this.pasteEntryToolStripMenuItem.Enabled = true;
				this.importEntryToolStripMenuItem.Enabled = true;
				this.addToolStripMenuItem.Enabled = false;
				this.removeToolStripMenuItem.Enabled = false;
			}
			else if (this.treeViewObject.SelectedNode.Level == 1)
			{
				this.addEntryToolStripMenuItem.Enabled = false;
				this.removeEntryToolStripMenuItem.Enabled = false;
				this.copyEntryToolStripMenuItem.Enabled = false;
				this.pasteEntryToolStripMenuItem.Enabled = false;
				this.addToolStripMenuItem.Enabled = true;
				this.importEntryToolStripMenuItem.Enabled = false;
				this.removeToolStripMenuItem.Enabled = false;
			}
			else if (this.treeViewObject.SelectedNode.Level == 2)
			{
				this.addEntryToolStripMenuItem.Enabled = false;
				this.removeEntryToolStripMenuItem.Enabled = false;
				this.copyEntryToolStripMenuItem.Enabled = false;
				this.pasteEntryToolStripMenuItem.Enabled = false;
				this.addToolStripMenuItem.Enabled = true;
				this.importEntryToolStripMenuItem.Enabled = false;
				this.removeToolStripMenuItem.Enabled = true;
				TreeNode selectedNode = this.treeViewObject.SelectedNode;
				TreeNode parent = selectedNode.Parent;
				TreeNode parent2 = parent.Parent;
				if (parent.Index == 0)
				{
					this.propertyGrid.SelectedObject = this.list_object[parent2.Index].list_mesh[selectedNode.Index];
				}
				else if (parent.Index == 1)
				{
					this.propertyGrid.SelectedObject = this.list_object[parent2.Index].list_effect[selectedNode.Index];
				}
			}
		}

		private void addEntryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Object item = new Object();
			this.list_object.Add(item);
			TreeNode treeNode = new TreeNode();
			treeNode.Text = "Entry [" + (this.list_object.Count - 1) + "] :";
			treeNode.Nodes.Add("Meshs [0]");
			treeNode.Nodes.Add("Effects [0]");
			this.treeViewObject.Nodes.Add(treeNode);
		}

		private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			if (this.propertyGrid.SelectedObject.GetType() == typeof(Mesh))
			{
				Mesh mesh = (Mesh)this.propertyGrid.SelectedObject;
				this.treeView.SelectedNode.Text = string.Concat(new object[]
				{
					"[",
					this.treeView.SelectedNode.Index,
					"]",
					mesh.path
				});
			}
			else if (this.propertyGrid.SelectedObject.GetType() == typeof(Materiel))
			{
				Materiel materiel = (Materiel)this.propertyGrid.SelectedObject;
				this.treeView.SelectedNode.Text = string.Concat(new object[]
				{
					"[",
					this.treeView.SelectedNode.Index,
					"]",
					materiel.path
				});
			}
			else if (this.propertyGrid.SelectedObject.GetType() == typeof(Effect))
			{
				Effect effect = (Effect)this.propertyGrid.SelectedObject;
				this.treeView.SelectedNode.Text = string.Concat(new object[]
				{
					"[",
					this.treeView.SelectedNode.Index,
					"]",
					effect.path
				});
			}
			else if (this.propertyGrid.SelectedObject.GetType() == typeof(Object.Mesh))
			{
				Object.Mesh mesh2 = (Object.Mesh)this.propertyGrid.SelectedObject;
				this.treeViewObject.SelectedNode.Text = string.Concat(new object[]
				{
					"Model [",
					mesh2.mesh_id,
					"] with Texture [",
					mesh2.material_id,
					"]"
				});
			}
			else if (this.propertyGrid.SelectedObject.GetType() == typeof(Object.Effect))
			{
				Object.Effect effect2 = (Object.Effect)this.propertyGrid.SelectedObject;
				this.treeViewObject.SelectedNode.Text = "Effect [" + effect2.effect_id + "]";
			}
		}

		private void removeEntryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.list_object.RemoveAt(this.treeViewObject.SelectedNode.Index);
			this.treeViewObject.Nodes.Remove(this.treeViewObject.SelectedNode);
		}

		private void copyEntryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.copy_object = this.list_object[this.treeViewObject.SelectedNode.Index];
		}

		private void pasteEntryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.copy_object != null)
			{
				this.treeViewObject.SelectedNode.Nodes.Clear();
				this.list_object[this.treeViewObject.SelectedNode.Index] = this.copy_object;
				this.treeViewObject.SelectedNode.Nodes.Add("Meshs [" + this.copy_object.list_mesh.Count + "]");
				for (int num = 0; num != this.copy_object.list_mesh.Count; num++)
				{
					this.treeViewObject.SelectedNode.Nodes[0].Nodes.Add(string.Concat(new object[]
					{
						"Model [",
						this.copy_object.list_mesh[num].mesh_id,
						"] with Texture [",
						this.copy_object.list_mesh[num].material_id,
						"]"
					}));
				}
				this.treeViewObject.SelectedNode.Nodes.Add("Effects [" + this.copy_object.list_effect.Count + "]");
				for (int num = 0; num != this.copy_object.list_effect.Count; num++)
				{
					this.treeViewObject.SelectedNode.Nodes[1].Nodes.Add("Effect[" + this.copy_object.list_effect[num].effect_id + "]");
				}
			}
		}

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.treeViewObject.SelectedNode.Level == 1)
			{
				TreeNode parent = this.treeViewObject.SelectedNode.Parent;
				if (this.treeViewObject.SelectedNode.Index == 0)
				{
					Object.Mesh item = new Object.Mesh();
					this.list_object[parent.Index].list_mesh.Add(item);
					this.treeViewObject.SelectedNode.Text = "Meshs [" + this.list_object[parent.Index].list_mesh.Count + "]";
					this.treeViewObject.SelectedNode.Nodes.Add("Model [0] with Texture [0]");
				}
				else if (this.treeViewObject.SelectedNode.Index == 1)
				{
					Object.Effect item2 = new Object.Effect();
					this.list_object[parent.Index].list_effect.Add(item2);
					this.treeViewObject.SelectedNode.Text = "Effects [" + this.list_object[parent.Index].list_effect.Count + "]";
					this.treeViewObject.SelectedNode.Nodes.Add("Effect [0]");
				}
			}
			if (this.treeViewObject.SelectedNode.Level == 2)
			{
				TreeNode parent2 = this.treeViewObject.SelectedNode.Parent;
				TreeNode parent = parent2.Parent;
				if (parent2.Index == 0)
				{
					Object.Mesh item = new Object.Mesh();
					this.list_object[parent.Index].list_mesh.Add(item);
					parent2.Text = "Meshs [" + this.list_object[parent.Index].list_mesh.Count + "]";
					parent2.Nodes.Add("Model [0] with Texture [0]");
				}
				else if (parent2.Index == 1)
				{
					Object.Effect item2 = new Object.Effect();
					this.list_object[parent.Index].list_effect.Add(item2);
					parent2.Text = "Effects [" + this.list_object[parent.Index].list_effect.Count + "]";
					parent2.Nodes.Add("Effect [0]");
				}
			}
		}

		private void removeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode parent = this.treeViewObject.SelectedNode.Parent;
			TreeNode parent2 = parent.Parent;
			if (parent.Index == 0)
			{
				this.list_object[parent2.Index].list_mesh.RemoveAt(this.treeViewObject.SelectedNode.Index);
				parent.Text = "Meshs [" + this.list_object[parent2.Index].list_mesh.Count + "]";
				parent.Nodes.Remove(this.treeViewObject.SelectedNode);
			}
			else if (parent.Index == 1)
			{
				this.list_object[parent2.Index].list_effect.RemoveAt(this.treeViewObject.SelectedNode.Index);
				parent.Text = "Effects [" + this.list_object[parent2.Index].list_effect.Count + "]";
				parent.Nodes.Remove(this.treeViewObject.SelectedNode);
			}
		}

		private void importEntryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ImportForm importForm = new ImportForm();
			if (importForm.ShowDialog() == DialogResult.OK)
			{
				Object @object = importForm.list_object[importForm.listBox.SelectedIndex];
				this.treeViewObject.SelectedNode.Nodes.Clear();
				for (int num = 0; num != @object.list_mesh.Count; num++)
				{
					TreeNode treeNode = new TreeNode();
					treeNode.Text = string.Concat(new object[]
					{
						"[",
						this.list_mesh.Count,
						"]",
						importForm.list_mesh[(int)@object.list_mesh[num].mesh_id].path
					});
					treeNode.BackColor = Color.Red;
					this.treeView.Nodes[0].Nodes.Add(treeNode);
					this.list_mesh.Add(importForm.list_mesh[(int)@object.list_mesh[num].mesh_id]);
					this.treeView.Nodes[0].Text = "Mesh-ZMS [" + this.list_mesh.Count + "]";
					@object.list_mesh[num].mesh_id = Convert.ToInt16(this.list_mesh.Count - 1);
					TreeNode treeNode2 = new TreeNode();
					treeNode2.Text = string.Concat(new object[]
					{
						"[",
						this.list_materiel.Count,
						"]",
						importForm.list_materiel[(int)@object.list_mesh[num].material_id].path
					});
					treeNode2.BackColor = Color.Red;
					this.treeView.Nodes[1].Nodes.Add(treeNode2);
					this.list_materiel.Add(importForm.list_materiel[(int)@object.list_mesh[num].material_id]);
					this.treeView.Nodes[1].Text = "Materiel-DDS [" + this.list_materiel.Count + "]";
					@object.list_mesh[num].material_id = Convert.ToInt16(this.list_materiel.Count - 1);
				}
				for (int num = 0; num != @object.list_effect.Count; num++)
				{
					TreeNode treeNode = new TreeNode();
					treeNode.Text = string.Concat(new object[]
					{
						"[",
						this.list_effect.Count,
						"]",
						importForm.list_effect[(int)@object.list_effect[num].effect_id].path
					});
					treeNode.BackColor = Color.Red;
					this.treeView.Nodes[2].Nodes.Add(treeNode);
					this.list_effect.Add(importForm.list_effect[(int)@object.list_effect[num].effect_id]);
					this.treeView.Nodes[2].Text = "Effect-eft [" + this.list_effect.Count + "]";
					@object.list_effect[num].effect_id = Convert.ToInt16(this.list_effect.Count - 1);
				}
				this.treeViewObject.SelectedNode.Nodes.Add("Meshs [" + @object.list_mesh.Count + "]");
				for (int num2 = 0; num2 != @object.list_mesh.Count; num2++)
				{
					this.treeViewObject.SelectedNode.Nodes[0].Nodes.Add(string.Concat(new object[]
					{
						"Model [",
						@object.list_mesh[num2].mesh_id,
						"] with Texture [",
						@object.list_mesh[num2].material_id,
						"]"
					}));
				}
				this.treeViewObject.SelectedNode.Nodes.Add("Effects [" + @object.list_effect.Count + "]");
				for (int num2 = 0; num2 != @object.list_effect.Count; num2++)
				{
					this.treeViewObject.SelectedNode.Nodes[1].Nodes.Add("Effect[" + @object.list_effect[num2].effect_id + "]");
				}
				this.list_object[this.treeViewObject.SelectedNode.Index] = @object;
				this.propertyGrid.Refresh();
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.save_zsc(this.saveFileDialog.FileName);
			}
			this.Text = "ZSC : \"" + this.saveFileDialog.FileName + "\"";
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string[] array = this.Text.Split(new char[]
			{
				'"'
			});
			this.save_zsc(array[1]);
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
			this.menuStrip = new MenuStrip();
			this.fileToolStripMenuItem = new ToolStripMenuItem();
			this.OpenToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.saveToolStripMenuItem = new ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.exitToolStripMenuItem = new ToolStripMenuItem();
			this.optionToolStripMenuItem = new ToolStripMenuItem();
			this.clientPathToolStripMenuItem = new ToolStripMenuItem();
			this.treeView = new TreeView();
			this.contextMenuStrip = new ContextMenuStrip(this.components);
			this.addPathToolStripMenuItem = new ToolStripMenuItem();
			this.deletedPathToolStripMenuItem = new ToolStripMenuItem();
			this.treeViewObject = new TreeView();
			this.contextMenuObject = new ContextMenuStrip(this.components);
			this.addEntryToolStripMenuItem = new ToolStripMenuItem();
			this.removeEntryToolStripMenuItem = new ToolStripMenuItem();
			this.importEntryToolStripMenuItem = new ToolStripMenuItem();
			this.copyEntryToolStripMenuItem = new ToolStripMenuItem();
			this.pasteEntryToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator3 = new ToolStripSeparator();
			this.addToolStripMenuItem = new ToolStripMenuItem();
			this.removeToolStripMenuItem = new ToolStripMenuItem();
			this.statusStrip = new StatusStrip();
			this.StatusLabel = new ToolStripStatusLabel();
			this.propertyGrid = new PropertyGrid();
			this.label = new Label();
			this.pictureBox = new PictureBox();
			this.openFileDialog = new OpenFileDialog();
			this.textBoxpreviewpath = new TextBox();
			this.saveFileDialog = new SaveFileDialog();
			this.menuStrip.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.contextMenuObject.SuspendLayout();
			this.statusStrip.SuspendLayout();
			((ISupportInitialize)this.pictureBox).BeginInit();
			base.SuspendLayout();
			this.menuStrip.AllowMerge = false;
			this.menuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.fileToolStripMenuItem,
				this.optionToolStripMenuItem
			});
			this.menuStrip.Location = new Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new Size(692, 24);
			this.menuStrip.TabIndex = 2;
			this.menuStrip.Text = "menuStrip1";
			this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.OpenToolStripMenuItem,
				this.toolStripSeparator1,
				this.saveToolStripMenuItem,
				this.saveAsToolStripMenuItem,
				this.toolStripSeparator2,
				this.exitToolStripMenuItem
			});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new Size(35, 20);
			this.fileToolStripMenuItem.Text = "File";
			this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
			this.OpenToolStripMenuItem.Size = new Size(152, 22);
			this.OpenToolStripMenuItem.Text = "Open";
			this.OpenToolStripMenuItem.Click += new EventHandler(this.OpenToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(149, 6);
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new Size(152, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new Size(152, 22);
			this.saveAsToolStripMenuItem.Text = "Save as";
			this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(149, 6);
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new Size(152, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
			this.optionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
			{
				this.clientPathToolStripMenuItem
			});
			this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
			this.optionToolStripMenuItem.Size = new Size(51, 20);
			this.optionToolStripMenuItem.Text = "Option";
			this.clientPathToolStripMenuItem.Name = "clientPathToolStripMenuItem";
			this.clientPathToolStripMenuItem.Size = new Size(137, 22);
			this.clientPathToolStripMenuItem.Text = "Client path";
			this.treeView.ContextMenuStrip = this.contextMenuStrip;
			this.treeView.Location = new Point(4, 27);
			this.treeView.Name = "treeView";
			this.treeView.Size = new Size(335, 250);
			this.treeView.TabIndex = 3;
			this.treeView.AfterSelect += new TreeViewEventHandler(this.treeView_AfterSelect);
			this.contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.addPathToolStripMenuItem,
				this.deletedPathToolStripMenuItem
			});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new Size(148, 48);
			this.addPathToolStripMenuItem.Name = "addPathToolStripMenuItem";
			this.addPathToolStripMenuItem.Size = new Size(147, 22);
			this.addPathToolStripMenuItem.Text = "Add Path";
			this.addPathToolStripMenuItem.Click += new EventHandler(this.addPathToolStripMenuItem_Click);
			this.deletedPathToolStripMenuItem.Enabled = false;
			this.deletedPathToolStripMenuItem.Name = "deletedPathToolStripMenuItem";
			this.deletedPathToolStripMenuItem.Size = new Size(147, 22);
			this.deletedPathToolStripMenuItem.Text = "Deleted Path";
			this.deletedPathToolStripMenuItem.Click += new EventHandler(this.deletedPathToolStripMenuItem_Click);
			this.treeViewObject.ContextMenuStrip = this.contextMenuObject;
			this.treeViewObject.Location = new Point(4, 283);
			this.treeViewObject.Name = "treeViewObject";
			this.treeViewObject.Size = new Size(335, 250);
			this.treeViewObject.TabIndex = 5;
			this.treeViewObject.AfterSelect += new TreeViewEventHandler(this.treeViewCharacter_AfterSelect);
			this.contextMenuObject.Items.AddRange(new ToolStripItem[]
			{
				this.addEntryToolStripMenuItem,
				this.removeEntryToolStripMenuItem,
				this.importEntryToolStripMenuItem,
				this.copyEntryToolStripMenuItem,
				this.pasteEntryToolStripMenuItem,
				this.toolStripSeparator3,
				this.addToolStripMenuItem,
				this.removeToolStripMenuItem
			});
			this.contextMenuObject.Name = "contextMenuCharacter";
			this.contextMenuObject.Size = new Size(154, 164);
			this.addEntryToolStripMenuItem.Enabled = false;
			this.addEntryToolStripMenuItem.Name = "addEntryToolStripMenuItem";
			this.addEntryToolStripMenuItem.Size = new Size(153, 22);
			this.addEntryToolStripMenuItem.Text = "Add Entry";
			this.addEntryToolStripMenuItem.Click += new EventHandler(this.addEntryToolStripMenuItem_Click);
			this.removeEntryToolStripMenuItem.Enabled = false;
			this.removeEntryToolStripMenuItem.Name = "removeEntryToolStripMenuItem";
			this.removeEntryToolStripMenuItem.Size = new Size(153, 22);
			this.removeEntryToolStripMenuItem.Text = "Remove Entry";
			this.removeEntryToolStripMenuItem.Click += new EventHandler(this.removeEntryToolStripMenuItem_Click);
			this.importEntryToolStripMenuItem.Enabled = false;
			this.importEntryToolStripMenuItem.Name = "importEntryToolStripMenuItem";
			this.importEntryToolStripMenuItem.Size = new Size(153, 22);
			this.importEntryToolStripMenuItem.Text = "Import Entry";
			this.importEntryToolStripMenuItem.Click += new EventHandler(this.importEntryToolStripMenuItem_Click);
			this.copyEntryToolStripMenuItem.Enabled = false;
			this.copyEntryToolStripMenuItem.Name = "copyEntryToolStripMenuItem";
			this.copyEntryToolStripMenuItem.Size = new Size(153, 22);
			this.copyEntryToolStripMenuItem.Text = "Copy Entry";
			this.copyEntryToolStripMenuItem.Click += new EventHandler(this.copyEntryToolStripMenuItem_Click);
			this.pasteEntryToolStripMenuItem.Enabled = false;
			this.pasteEntryToolStripMenuItem.Name = "pasteEntryToolStripMenuItem";
			this.pasteEntryToolStripMenuItem.Size = new Size(153, 22);
			this.pasteEntryToolStripMenuItem.Text = "Paste Entry";
			this.pasteEntryToolStripMenuItem.Click += new EventHandler(this.pasteEntryToolStripMenuItem_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new Size(150, 6);
			this.addToolStripMenuItem.Enabled = false;
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new Size(153, 22);
			this.addToolStripMenuItem.Text = "Add";
			this.addToolStripMenuItem.Click += new EventHandler(this.addToolStripMenuItem_Click);
			this.removeToolStripMenuItem.Enabled = false;
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new Size(153, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new EventHandler(this.removeToolStripMenuItem_Click);
			this.statusStrip.Items.AddRange(new ToolStripItem[]
			{
				this.StatusLabel
			});
			this.statusStrip.Location = new Point(0, 546);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new Size(692, 22);
			this.statusStrip.TabIndex = 6;
			this.statusStrip.Text = "statusStrip1";
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new Size(44, 17);
			this.StatusLabel.Text = "Statut :";
			this.propertyGrid.Cursor = Cursors.Cross;
			this.propertyGrid.Location = new Point(348, 27);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new Size(335, 280);
			this.propertyGrid.TabIndex = 7;
			this.propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
			this.label.AutoSize = true;
			this.label.Location = new Point(345, 317);
			this.label.Name = "label";
			this.label.Size = new Size(51, 13);
			this.label.TabIndex = 8;
			this.label.Text = "Preview :";
			this.pictureBox.BackColor = SystemColors.InactiveCaptionText;
			this.pictureBox.Cursor = Cursors.Cross;
			this.pictureBox.Location = new Point(348, 333);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new Size(332, 200);
			this.pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			this.pictureBox.TabIndex = 9;
			this.pictureBox.TabStop = false;
			this.openFileDialog.Filter = "ZSC Files|*.zsc|All Files|*.*";
			this.textBoxpreviewpath.Enabled = false;
			this.textBoxpreviewpath.Location = new Point(402, 310);
			this.textBoxpreviewpath.Name = "textBoxpreviewpath";
			this.textBoxpreviewpath.Size = new Size(278, 20);
			this.textBoxpreviewpath.TabIndex = 10;
			this.saveFileDialog.Filter = "ZSC Files|*.zsc|All Files|*.*";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(692, 568);
			base.Controls.Add(this.textBoxpreviewpath);
			base.Controls.Add(this.pictureBox);
			base.Controls.Add(this.label);
			base.Controls.Add(this.statusStrip);
			base.Controls.Add(this.treeViewObject);
			base.Controls.Add(this.treeView);
			base.Controls.Add(this.menuStrip);
			base.Controls.Add(this.propertyGrid);
			base.Name = "ZSCForm";
			this.Text = "ZSC :";
			base.Load += new EventHandler(this.ZSC_Form_Load);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.contextMenuStrip.ResumeLayout(false);
			this.contextMenuObject.ResumeLayout(false);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			((ISupportInitialize)this.pictureBox).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
