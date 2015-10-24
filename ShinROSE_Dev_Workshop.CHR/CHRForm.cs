using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ShinROSE_Dev_Workshop.CHR
{
	public class CHRForm : Form
	{
		public enum type_action
		{
			Warning,
			Walking,
			Attack,
			Hit,
			Dieing,
			Running,
			Unknow6,
			Unknow7,
			Unknow8,
			Unknow9,
			Unknow10,
			Unknow11,
			Unknow12,
			Unknow = -1
		}

		private List<Mesh> list_mesh = new List<Mesh>();

		private List<Motion> list_motion = new List<Motion>();

		private List<Effect> list_effect = new List<Effect>();

		private List<Character> list_character = new List<Character>();

		private Character copy_character;

		private IContainer components = null;

		private StatusStrip statusStrip;

		private ToolStripStatusLabel StatusLabel;

		private MenuStrip menuStrip;

		private ToolStripMenuItem fileToolStripMenuItem;

		private ToolStripMenuItem OpenToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem saveToolStripMenuItem;

		private ToolStripMenuItem saveAsToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripMenuItem exitToolStripMenuItem;

		private TreeView treeView;

		private PropertyGrid propertyGrid;

		private OpenFileDialog openFileDialog;

		private TreeView treeViewCharacter;

		private ContextMenuStrip contextMenuStrip;

		private ToolStripMenuItem addPathToolStripMenuItem;

		private ToolStripMenuItem deletedPathToolStripMenuItem;

		private ContextMenuStrip contextMenuCharacter;

		private ToolStripMenuItem addCharacterToolStripMenuItem;

		private ToolStripMenuItem removeCharacterToolStripMenuItem;

		private ToolStripMenuItem copyCharacterToolStripMenuItem;

		private ToolStripMenuItem pasteCharacterToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripMenuItem addToolStripMenuItem;

		private ToolStripMenuItem removeToolStripMenuItem;

		private SaveFileDialog saveFileDialog;

		private ToolStripMenuItem importMobToolStripMenuItem;

		public CHRForm()
		{
			this.InitializeComponent();
		}

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.load_chr(this.openFileDialog.FileName);
			}
			this.Text = "CHR : \"" + this.openFileDialog.FileName + "\"";
		}

		public void load_chr(string path)
		{
			this.treeView.Nodes.Clear();
			this.list_mesh.Clear();
			this.list_character.Clear();
			this.list_effect.Clear();
			this.list_motion.Clear();
			BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open), Encoding.GetEncoding("EUC-KR"));
			int num = (int)binaryReader.ReadInt16();
			this.treeView.Nodes.Add("Skeleton-ZMD [" + num + "]");
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
			this.treeView.Nodes.Add("Motion-ZMO [" + num3 + "]");
			for (int num2 = 0; num2 != num3; num2++)
			{
				Motion motion = new Motion();
				motion.read(ref binaryReader);
				this.treeView.Nodes[1].Nodes.Add(string.Concat(new object[]
				{
					"[",
					num2,
					"]",
					motion.path
				}));
				this.list_motion.Add(motion);
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
				Character character = new Character();
				character.read(ref binaryReader);
				if (character.is_active == 1)
				{
					this.treeViewCharacter.Nodes.Add(string.Concat(new object[]
					{
						"Mob [",
						num2,
						"] : \"",
						character.name,
						"\""
					}));
					this.treeViewCharacter.Nodes[num2].Nodes.Add("Parts [" + character.List_Mesh.Count + "]");
					for (int num6 = 0; num6 != character.List_Mesh.Count; num6++)
					{
						this.treeViewCharacter.Nodes[num2].Nodes[0].Nodes.Add(Convert.ToString(character.List_Mesh[num6].zscobjid));
					}
					this.treeViewCharacter.Nodes[num2].Nodes.Add("Animations [" + character.List_Motion.Count + "]");
					for (int num6 = 0; num6 != character.List_Motion.Count; num6++)
					{
						this.treeViewCharacter.Nodes[num2].Nodes[1].Nodes.Add(Convert.ToString((CHRForm.type_action)character.List_Motion[num6].id));
					}
					this.treeViewCharacter.Nodes[num2].Nodes.Add("Effects [" + character.List_Effect.Count + "]");
					for (int num6 = 0; num6 != character.List_Effect.Count; num6++)
					{
						this.treeViewCharacter.Nodes[num2].Nodes[2].Nodes.Add(Convert.ToString((CHRForm.type_action)character.List_Effect[num6].id));
					}
				}
				else
				{
					this.treeViewCharacter.Nodes.Add("Mob [" + num2 + "] : inactivate");
				}
				this.list_character.Add(character);
			}
			binaryReader.Close();
		}

		public void save_chr(string path)
		{
			BinaryWriter binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create));
			binaryWriter.Write((short)this.list_mesh.Count);
			for (int num = 0; num != this.list_mesh.Count; num++)
			{
				this.list_mesh[num].save(ref binaryWriter);
			}
			binaryWriter.Write((short)this.list_motion.Count);
			for (int num = 0; num != this.list_motion.Count; num++)
			{
				this.list_motion[num].save(ref binaryWriter);
			}
			binaryWriter.Write((short)this.list_effect.Count);
			for (int num = 0; num != this.list_effect.Count; num++)
			{
				this.list_effect[num].save(ref binaryWriter);
			}
			binaryWriter.Write((short)this.list_character.Count);
			for (int num = 0; num != this.list_character.Count; num++)
			{
				this.list_character[num].save(ref binaryWriter);
			}
			binaryWriter.Close();
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
					this.propertyGrid.SelectedObject = this.list_motion[this.treeView.SelectedNode.Index];
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

		private void treeViewCharacter_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (this.treeViewCharacter.SelectedNode.Level == 0)
			{
				this.propertyGrid.SelectedObject = this.list_character[this.treeViewCharacter.SelectedNode.Index];
				this.addCharacterToolStripMenuItem.Enabled = true;
				this.removeCharacterToolStripMenuItem.Enabled = true;
				this.copyCharacterToolStripMenuItem.Enabled = true;
				this.pasteCharacterToolStripMenuItem.Enabled = true;
				this.importMobToolStripMenuItem.Enabled = true;
				this.addToolStripMenuItem.Enabled = false;
				this.removeToolStripMenuItem.Enabled = false;
			}
			else if (this.treeViewCharacter.SelectedNode.Level == 1)
			{
				this.addCharacterToolStripMenuItem.Enabled = false;
				this.removeCharacterToolStripMenuItem.Enabled = false;
				this.copyCharacterToolStripMenuItem.Enabled = false;
				this.pasteCharacterToolStripMenuItem.Enabled = false;
				this.addToolStripMenuItem.Enabled = true;
				this.importMobToolStripMenuItem.Enabled = false;
				this.removeToolStripMenuItem.Enabled = false;
			}
			else if (this.treeViewCharacter.SelectedNode.Level == 2)
			{
				this.addCharacterToolStripMenuItem.Enabled = false;
				this.removeCharacterToolStripMenuItem.Enabled = false;
				this.copyCharacterToolStripMenuItem.Enabled = false;
				this.pasteCharacterToolStripMenuItem.Enabled = false;
				this.addToolStripMenuItem.Enabled = true;
				this.importMobToolStripMenuItem.Enabled = false;
				this.removeToolStripMenuItem.Enabled = true;
				TreeNode selectedNode = this.treeViewCharacter.SelectedNode;
				TreeNode parent = selectedNode.Parent;
				TreeNode parent2 = parent.Parent;
				if (parent.Index == 0)
				{
					this.propertyGrid.SelectedObject = this.list_character[parent2.Index].List_Mesh[selectedNode.Index];
				}
				else if (parent.Index == 1)
				{
					this.propertyGrid.SelectedObject = this.list_character[parent2.Index].List_Motion[selectedNode.Index];
				}
				else if (parent.Index == 2)
				{
					this.propertyGrid.SelectedObject = this.list_character[parent2.Index].List_Effect[selectedNode.Index];
				}
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
					this.treeView.Nodes[0].Text = "Skeleton-ZMD [" + this.list_mesh.Count + "]";
				}
				else if (treeNode.Index == 1)
				{
					this.treeView.Nodes[1].Nodes.Add("[" + this.list_motion.Count + "]New Motion link");
					Motion motion = new Motion();
					motion.path = "path";
					this.list_motion.Add(motion);
					this.treeView.Nodes[1].Text = "Motion-ZMO [" + this.list_motion.Count + "]";
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
					this.treeView.Nodes[0].Text = "Skeleton-ZMD [" + this.list_mesh.Count + "]";
				}
				else if (treeNode.Index == 1)
				{
					this.treeView.Nodes[1].Nodes.Add("[" + this.list_motion.Count + "]New Motion link");
					Motion motion = new Motion();
					motion.path = "path";
					this.list_motion.Add(motion);
					this.treeView.Nodes[1].Text = "Motion-ZMO [" + this.list_motion.Count + "]";
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
				this.treeView.Nodes[0].Text = "Skeleton-ZMD [" + this.list_mesh.Count + "]";
			}
			else if (parent.Index == 1)
			{
				this.list_motion.RemoveAt(this.treeView.SelectedNode.Index);
				this.treeView.SelectedNode.Remove();
				this.treeView.Nodes[1].Text = "Motion-ZMO [" + this.list_motion.Count + "]";
			}
			else if (parent.Index == 2)
			{
				this.list_effect.RemoveAt(this.treeView.SelectedNode.Index);
				this.treeView.SelectedNode.Remove();
				this.treeView.Nodes[2].Text = "Effect-eft [" + this.list_effect.Count + "]";
			}
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
			else if (this.propertyGrid.SelectedObject.GetType() == typeof(Motion))
			{
				Motion motion = (Motion)this.propertyGrid.SelectedObject;
				this.treeView.SelectedNode.Text = string.Concat(new object[]
				{
					"[",
					this.treeView.SelectedNode.Index,
					"]",
					motion.path
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
			else if (this.propertyGrid.SelectedObject.GetType() == typeof(Character))
			{
				Character character = (Character)this.propertyGrid.SelectedObject;
				if (character.is_active == 1)
				{
					this.treeViewCharacter.SelectedNode.Nodes.Clear();
					this.treeViewCharacter.SelectedNode.Text = string.Concat(new object[]
					{
						"Mob [",
						this.treeViewCharacter.SelectedNode.Index,
						"] : \"",
						character.name,
						"\""
					});
					this.treeViewCharacter.SelectedNode.Nodes.Add("Parts [" + character.List_Mesh.Count + "]");
					for (int num = 0; num != character.List_Mesh.Count; num++)
					{
						this.treeViewCharacter.SelectedNode.Nodes[0].Nodes.Add(Convert.ToString(character.List_Mesh[num].zscobjid));
					}
					this.treeViewCharacter.SelectedNode.Nodes.Add("Animations [" + character.List_Motion.Count + "]");
					for (int num = 0; num != character.List_Motion.Count; num++)
					{
						this.treeViewCharacter.SelectedNode.Nodes[1].Nodes.Add(Convert.ToString((CHRForm.type_action)character.List_Motion[num].id));
					}
					this.treeViewCharacter.SelectedNode.Nodes.Add("Effects [" + character.List_Effect.Count + "]");
					for (int num = 0; num != character.List_Effect.Count; num++)
					{
						this.treeViewCharacter.SelectedNode.Nodes[2].Nodes.Add(Convert.ToString((CHRForm.type_action)character.List_Effect[num].id));
					}
				}
				else
				{
					this.treeViewCharacter.SelectedNode.Text = "Mob [" + this.treeViewCharacter.SelectedNode.Index + "] : inactivate";
					this.treeViewCharacter.SelectedNode.Nodes.Clear();
				}
			}
			else if (this.propertyGrid.SelectedObject.GetType() == typeof(Character.Mesh))
			{
				Character.Mesh mesh2 = (Character.Mesh)this.propertyGrid.SelectedObject;
				this.treeViewCharacter.SelectedNode.Text = mesh2.zscobjid.ToString();
			}
			else if (this.propertyGrid.SelectedObject.GetType() == typeof(Character.Motion))
			{
				Character.Motion motion2 = (Character.Motion)this.propertyGrid.SelectedObject;
				this.treeViewCharacter.SelectedNode.Text = Convert.ToString((CHRForm.type_action)motion2.id);
			}
			else if (this.propertyGrid.SelectedObject.GetType() == typeof(Character.Effect))
			{
				Character.Effect effect2 = (Character.Effect)this.propertyGrid.SelectedObject;
				this.treeViewCharacter.SelectedNode.Text = Convert.ToString((CHRForm.type_action)effect2.id);
			}
		}

		private void addCharacterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Character character = new Character();
			character.is_active = 0;
			character.name = "New mob";
			character.bone_id = 0;
			this.list_character.Add(character);
			this.treeViewCharacter.Nodes.Add("Mob [" + (this.list_character.Count - 1) + "] : inactivate");
		}

		private void removeCharacterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.list_character.RemoveAt(this.treeViewCharacter.SelectedNode.Index);
			this.treeViewCharacter.Nodes.Remove(this.treeViewCharacter.SelectedNode);
		}

		private void copyCharacterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.copy_character = this.list_character[this.treeViewCharacter.SelectedNode.Index];
		}

		private void pasteCharacterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.copy_character != null)
			{
				this.list_character[this.treeViewCharacter.SelectedNode.Index] = this.copy_character;
				if (this.copy_character.is_active == 1)
				{
					this.treeViewCharacter.SelectedNode.Nodes.Clear();
					this.treeViewCharacter.SelectedNode.Text = string.Concat(new object[]
					{
						"Mob [",
						this.treeViewCharacter.SelectedNode.Index,
						"] : \"",
						this.copy_character.name,
						"\""
					});
					this.treeViewCharacter.SelectedNode.Nodes.Add("Parts [" + this.copy_character.List_Mesh.Count + "]");
					for (int num = 0; num != this.copy_character.List_Mesh.Count; num++)
					{
						this.treeViewCharacter.SelectedNode.Nodes[0].Nodes.Add(Convert.ToString(this.copy_character.List_Mesh[num].zscobjid));
					}
					this.treeViewCharacter.SelectedNode.Nodes.Add("Animations [" + this.copy_character.List_Motion.Count + "]");
					for (int num = 0; num != this.copy_character.List_Motion.Count; num++)
					{
						this.treeViewCharacter.SelectedNode.Nodes[1].Nodes.Add(Convert.ToString((CHRForm.type_action)this.copy_character.List_Motion[num].id));
					}
					this.treeViewCharacter.SelectedNode.Nodes.Add("Effects [" + this.copy_character.List_Effect.Count + "]");
					for (int num = 0; num != this.copy_character.List_Effect.Count; num++)
					{
						this.treeViewCharacter.SelectedNode.Nodes[2].Nodes.Add(Convert.ToString((CHRForm.type_action)this.copy_character.List_Effect[num].id));
					}
				}
				else
				{
					this.treeViewCharacter.SelectedNode.Text = "Mob [" + this.treeViewCharacter.SelectedNode.Index + "] : inactivate";
					this.treeViewCharacter.SelectedNode.Nodes.Clear();
				}
				this.propertyGrid.Refresh();
			}
		}

		private void addToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.treeViewCharacter.SelectedNode.Level == 1)
			{
				TreeNode parent = this.treeViewCharacter.SelectedNode.Parent;
				if (this.treeViewCharacter.SelectedNode.Index == 0)
				{
					Character.Mesh mesh = new Character.Mesh();
					mesh.zscobjid = 0;
					this.list_character[parent.Index].List_Mesh.Add(mesh);
					this.treeViewCharacter.SelectedNode.Text = "Parts [" + this.list_character[parent.Index].List_Mesh.Count + "]";
					this.treeViewCharacter.SelectedNode.Nodes.Add("0");
				}
				else if (this.treeViewCharacter.SelectedNode.Index == 1)
				{
					Character.Motion motion = new Character.Motion();
					motion.id = 0;
					motion.zscmotionid = 0;
					this.list_character[parent.Index].List_Motion.Add(motion);
					this.treeViewCharacter.SelectedNode.Text = "Animations [" + this.list_character[parent.Index].List_Motion.Count + "]";
					this.treeViewCharacter.SelectedNode.Nodes.Add("Warning");
				}
				else if (this.treeViewCharacter.SelectedNode.Index == 2)
				{
					Character.Effect effect = new Character.Effect();
					effect.id = 0;
					effect.zsceffectid = 0;
					this.list_character[parent.Index].List_Effect.Add(effect);
					this.treeViewCharacter.SelectedNode.Text = "Effects [" + this.list_character[parent.Index].List_Effect.Count + "]";
					this.treeViewCharacter.SelectedNode.Nodes.Add("Warning");
				}
			}
			if (this.treeViewCharacter.SelectedNode.Level == 2)
			{
				TreeNode parent2 = this.treeViewCharacter.SelectedNode.Parent;
				TreeNode parent = parent2.Parent;
				if (parent2.Index == 0)
				{
					Character.Mesh mesh = new Character.Mesh();
					mesh.zscobjid = 0;
					this.list_character[parent.Index].List_Mesh.Add(mesh);
					parent2.Text = "Parts [" + this.list_character[parent.Index].List_Mesh.Count + "]";
					parent2.Nodes.Add("0");
				}
				else if (parent2.Index == 1)
				{
					Character.Motion motion = new Character.Motion();
					motion.id = 0;
					motion.zscmotionid = 0;
					this.list_character[parent.Index].List_Motion.Add(motion);
					parent2.Text = "Animations [" + this.list_character[parent.Index].List_Motion.Count + "]";
					parent2.Nodes.Add("Warning");
				}
				else if (parent2.Index == 2)
				{
					Character.Effect effect = new Character.Effect();
					effect.id = 0;
					effect.zsceffectid = 0;
					this.list_character[parent.Index].List_Effect.Add(effect);
					parent2.Text = "Effects [" + this.list_character[parent.Index].List_Effect.Count + "]";
					parent2.Nodes.Add("Warning");
				}
			}
		}

		private void removeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode parent = this.treeViewCharacter.SelectedNode.Parent;
			TreeNode parent2 = parent.Parent;
			if (parent.Index == 0)
			{
				this.list_character[parent2.Index].List_Mesh.RemoveAt(this.treeViewCharacter.SelectedNode.Index);
				parent.Text = "Parts [" + this.list_character[parent2.Index].List_Mesh.Count + "]";
				parent.Nodes.Remove(this.treeViewCharacter.SelectedNode);
			}
			else if (parent.Index == 1)
			{
				this.list_character[parent2.Index].List_Motion.RemoveAt(this.treeViewCharacter.SelectedNode.Index);
				parent.Text = "Animations [" + this.list_character[parent2.Index].List_Motion.Count + "]";
				parent.Nodes.Remove(this.treeViewCharacter.SelectedNode);
			}
			else if (parent.Index == 2)
			{
				this.list_character[parent2.Index].List_Effect.RemoveAt(this.treeViewCharacter.SelectedNode.Index);
				parent.Text = "Effects [" + this.list_character[parent2.Index].List_Effect.Count + "]";
				parent.Nodes.Remove(this.treeViewCharacter.SelectedNode);
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.save_chr(this.saveFileDialog.FileName);
			}
			this.Text = "CHR : \"" + this.saveFileDialog.FileName + "\"";
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			string[] array = this.Text.Split(new char[]
			{
				'"'
			});
			this.save_chr(array[1]);
		}

		private void importMobToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ImportForm importForm = new ImportForm();
			if (importForm.ShowDialog() == DialogResult.OK)
			{
				Character character = importForm.list_character[importForm.listBox.SelectedIndex];
				TreeNode treeNode = new TreeNode();
				treeNode.Text = string.Concat(new object[]
				{
					"[",
					this.list_mesh.Count,
					"]",
					importForm.list_mesh[(int)character.bone_id].path
				});
				treeNode.BackColor = Color.Red;
				this.treeView.Nodes[0].Nodes.Add(treeNode);
				this.list_mesh.Add(importForm.list_mesh[(int)character.bone_id]);
				this.treeView.Nodes[0].Text = "Skeleton-ZMD [" + this.list_mesh.Count + "]";
				character.bone_id = Convert.ToInt16(this.list_mesh.Count - 1);
				for (int num = 0; num != character.List_Motion.Count; num++)
				{
					TreeNode treeNode2 = new TreeNode();
					treeNode2.Text = string.Concat(new object[]
					{
						"[",
						this.list_motion.Count,
						"]",
						importForm.list_motion[(int)character.List_Motion[num].zscmotionid].path
					});
					treeNode2.BackColor = Color.Red;
					this.treeView.Nodes[1].Nodes.Add(treeNode2);
					this.list_motion.Add(importForm.list_motion[(int)character.List_Motion[num].zscmotionid]);
					character.List_Motion[num].zscmotionid = Convert.ToInt16(this.list_motion.Count - 1);
				}
				this.treeView.Nodes[1].Text = "Motion-ZMO [" + this.list_motion.Count + "]";
				for (int num = 0; num != character.List_Effect.Count; num++)
				{
					TreeNode treeNode3 = new TreeNode();
					treeNode3.Text = string.Concat(new object[]
					{
						"[",
						this.list_effect.Count,
						"]",
						importForm.list_effect[(int)character.List_Effect[num].zsceffectid].path
					});
					treeNode3.BackColor = Color.Red;
					this.treeView.Nodes[2].Nodes.Add(treeNode3);
					this.list_effect.Add(importForm.list_effect[(int)character.List_Effect[num].zsceffectid]);
					character.List_Effect[num].zsceffectid = Convert.ToInt16(this.list_effect.Count - 1);
				}
				this.treeView.Nodes[2].Text = "Effect-eft [" + this.list_effect.Count + "]";
				this.list_character[this.treeViewCharacter.SelectedNode.Index] = character;
				if (character.is_active == 1)
				{
					this.treeViewCharacter.SelectedNode.Nodes.Clear();
					this.treeViewCharacter.SelectedNode.Text = string.Concat(new object[]
					{
						"Mob [",
						this.treeViewCharacter.SelectedNode.Index,
						"] : \"",
						character.name,
						"\""
					});
					this.treeViewCharacter.SelectedNode.Nodes.Add("Parts [" + character.List_Mesh.Count + "]");
					for (int num2 = 0; num2 != character.List_Mesh.Count; num2++)
					{
						this.treeViewCharacter.SelectedNode.Nodes[0].Nodes.Add(Convert.ToString(character.List_Mesh[num2].zscobjid));
					}
					this.treeViewCharacter.SelectedNode.Nodes.Add("Animations [" + character.List_Motion.Count + "]");
					for (int num2 = 0; num2 != character.List_Motion.Count; num2++)
					{
						this.treeViewCharacter.SelectedNode.Nodes[1].Nodes.Add(Convert.ToString((CHRForm.type_action)character.List_Motion[num2].id));
					}
					this.treeViewCharacter.SelectedNode.Nodes.Add("Effects [" + character.List_Effect.Count + "]");
					for (int num2 = 0; num2 != character.List_Effect.Count; num2++)
					{
						this.treeViewCharacter.SelectedNode.Nodes[2].Nodes.Add(Convert.ToString((CHRForm.type_action)character.List_Effect[num2].id));
					}
				}
				else
				{
					this.treeViewCharacter.SelectedNode.Text = "Mob [" + this.treeViewCharacter.SelectedNode.Index + "] : inactivate";
					this.treeViewCharacter.SelectedNode.Nodes.Clear();
				}
				this.propertyGrid.Refresh();
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
			this.components = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(CHRForm));
			this.statusStrip = new StatusStrip();
			this.StatusLabel = new ToolStripStatusLabel();
			this.menuStrip = new MenuStrip();
			this.fileToolStripMenuItem = new ToolStripMenuItem();
			this.OpenToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator1 = new ToolStripSeparator();
			this.saveToolStripMenuItem = new ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator2 = new ToolStripSeparator();
			this.exitToolStripMenuItem = new ToolStripMenuItem();
			this.treeView = new TreeView();
			this.contextMenuStrip = new ContextMenuStrip(this.components);
			this.addPathToolStripMenuItem = new ToolStripMenuItem();
			this.deletedPathToolStripMenuItem = new ToolStripMenuItem();
			this.propertyGrid = new PropertyGrid();
			this.openFileDialog = new OpenFileDialog();
			this.treeViewCharacter = new TreeView();
			this.contextMenuCharacter = new ContextMenuStrip(this.components);
			this.addCharacterToolStripMenuItem = new ToolStripMenuItem();
			this.removeCharacterToolStripMenuItem = new ToolStripMenuItem();
			this.importMobToolStripMenuItem = new ToolStripMenuItem();
			this.copyCharacterToolStripMenuItem = new ToolStripMenuItem();
			this.pasteCharacterToolStripMenuItem = new ToolStripMenuItem();
			this.toolStripSeparator3 = new ToolStripSeparator();
			this.addToolStripMenuItem = new ToolStripMenuItem();
			this.removeToolStripMenuItem = new ToolStripMenuItem();
			this.saveFileDialog = new SaveFileDialog();
			this.statusStrip.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.contextMenuCharacter.SuspendLayout();
			base.SuspendLayout();
			this.statusStrip.Items.AddRange(new ToolStripItem[]
			{
				this.StatusLabel
			});
			this.statusStrip.Location = new Point(0, 546);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new Size(692, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new Size(44, 17);
			this.StatusLabel.Text = "Statut :";
			this.menuStrip.AllowMerge = false;
			this.menuStrip.Items.AddRange(new ToolStripItem[]
			{
				this.fileToolStripMenuItem
			});
			this.menuStrip.Location = new Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new Size(692, 24);
			this.menuStrip.TabIndex = 1;
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
			this.OpenToolStripMenuItem.Size = new Size(123, 22);
			this.OpenToolStripMenuItem.Text = "Open";
			this.OpenToolStripMenuItem.Click += new EventHandler(this.OpenToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new Size(120, 6);
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new Size(123, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new Size(123, 22);
			this.saveAsToolStripMenuItem.Text = "Save as";
			this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new Size(120, 6);
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new Size(123, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
			this.treeView.ContextMenuStrip = this.contextMenuStrip;
			this.treeView.Location = new Point(4, 27);
			this.treeView.Name = "treeView";
			this.treeView.Size = new Size(335, 250);
			this.treeView.TabIndex = 2;
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
			this.propertyGrid.Location = new Point(345, 27);
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.Size = new Size(335, 520);
			this.propertyGrid.TabIndex = 3;
			this.propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
			this.openFileDialog.Filter = "CHR Files|*.chr|All Files|*.*";
			this.treeViewCharacter.ContextMenuStrip = this.contextMenuCharacter;
			this.treeViewCharacter.Location = new Point(4, 293);
			this.treeViewCharacter.Name = "treeViewCharacter";
			this.treeViewCharacter.Size = new Size(335, 250);
			this.treeViewCharacter.TabIndex = 4;
			this.treeViewCharacter.AfterSelect += new TreeViewEventHandler(this.treeViewCharacter_AfterSelect);
			this.contextMenuCharacter.Items.AddRange(new ToolStripItem[]
			{
				this.addCharacterToolStripMenuItem,
				this.removeCharacterToolStripMenuItem,
				this.importMobToolStripMenuItem,
				this.copyCharacterToolStripMenuItem,
				this.pasteCharacterToolStripMenuItem,
				this.toolStripSeparator3,
				this.addToolStripMenuItem,
				this.removeToolStripMenuItem
			});
			this.contextMenuCharacter.Name = "contextMenuCharacter";
			this.contextMenuCharacter.Size = new Size(148, 164);
			this.addCharacterToolStripMenuItem.Enabled = false;
			this.addCharacterToolStripMenuItem.Name = "addCharacterToolStripMenuItem";
			this.addCharacterToolStripMenuItem.Size = new Size(147, 22);
			this.addCharacterToolStripMenuItem.Text = "Add Mob";
			this.addCharacterToolStripMenuItem.Click += new EventHandler(this.addCharacterToolStripMenuItem_Click);
			this.removeCharacterToolStripMenuItem.Enabled = false;
			this.removeCharacterToolStripMenuItem.Name = "removeCharacterToolStripMenuItem";
			this.removeCharacterToolStripMenuItem.Size = new Size(147, 22);
			this.removeCharacterToolStripMenuItem.Text = "Remove Mob";
			this.removeCharacterToolStripMenuItem.Click += new EventHandler(this.removeCharacterToolStripMenuItem_Click);
			this.importMobToolStripMenuItem.Enabled = false;
			this.importMobToolStripMenuItem.Name = "importMobToolStripMenuItem";
			this.importMobToolStripMenuItem.Size = new Size(147, 22);
			this.importMobToolStripMenuItem.Text = "Import Mob";
			this.importMobToolStripMenuItem.Click += new EventHandler(this.importMobToolStripMenuItem_Click);
			this.copyCharacterToolStripMenuItem.Enabled = false;
			this.copyCharacterToolStripMenuItem.Name = "copyCharacterToolStripMenuItem";
			this.copyCharacterToolStripMenuItem.Size = new Size(147, 22);
			this.copyCharacterToolStripMenuItem.Text = "Copy Mob";
			this.copyCharacterToolStripMenuItem.Click += new EventHandler(this.copyCharacterToolStripMenuItem_Click);
			this.pasteCharacterToolStripMenuItem.Enabled = false;
			this.pasteCharacterToolStripMenuItem.Name = "pasteCharacterToolStripMenuItem";
			this.pasteCharacterToolStripMenuItem.Size = new Size(147, 22);
			this.pasteCharacterToolStripMenuItem.Text = "Paste Mob";
			this.pasteCharacterToolStripMenuItem.Click += new EventHandler(this.pasteCharacterToolStripMenuItem_Click);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new Size(144, 6);
			this.addToolStripMenuItem.Enabled = false;
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new Size(147, 22);
			this.addToolStripMenuItem.Text = "Add";
			this.addToolStripMenuItem.Click += new EventHandler(this.addToolStripMenuItem_Click);
			this.removeToolStripMenuItem.Enabled = false;
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new Size(147, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new EventHandler(this.removeToolStripMenuItem_Click);
			this.saveFileDialog.Filter = "CHR Files|*.chr|All Files|*.*";
			base.AutoScaleMode = AutoScaleMode.Inherit;
			base.ClientSize = new Size(692, 568);
			base.Controls.Add(this.treeViewCharacter);
			base.Controls.Add(this.propertyGrid);
			base.Controls.Add(this.treeView);
			base.Controls.Add(this.statusStrip);
			base.Controls.Add(this.menuStrip);
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.MainMenuStrip = this.menuStrip;
			base.Name = "CHRForm";
			this.Text = "CHRForm";
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.contextMenuStrip.ResumeLayout(false);
			this.contextMenuCharacter.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
