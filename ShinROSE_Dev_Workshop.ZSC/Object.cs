using Microsoft.DirectX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ShinROSE_Dev_Workshop.ZSC
{
	public class Object
	{
		public class Mesh
		{
			public enum bone_type
			{
				Pelvis,
				Head = 4
			}

			public enum dummy_type
			{
				RightHand,
				LeftHand,
				LeftShield,
				Back,
				Feet,
				Face,
				Head
			}

			public short mesh_id;

			public short material_id;

			public Vector3 position;

			private bool position_enabled;

			public Quaternion rotation;

			private bool rotation_enabled;

			public Vector3 scale;

			private bool scale_enabled;

			public Quaternion axisrot;

			private bool axisrot_enabled;

			public short bone_index;

			private bool bone_index_enabled;

			public short dummy_index;

			private bool dummy_index_enabled;

			public short parent;

			private bool parent_enabled;

			public short collision_type;

			private bool collision_type_enabled;

			public string Motion_path;

			public bool Motion_path_enabled;

			public short range_set;

			public bool range_set_enabled;

			public short use_lightmap;

			public byte[] data;

			[Category(" Basic"), DefaultValue(0), Description("Enter the model id"), DisplayName("Model id :")]
			public short Mesh_id
			{
				get
				{
					return this.mesh_id;
				}
				set
				{
					this.mesh_id = value;
				}
			}

			[Category(" Basic"), DefaultValue(0), Description("Enter the texture id"), DisplayName("Texture id :")]
			public short Material_id
			{
				get
				{
					return this.material_id;
				}
				set
				{
					this.material_id = value;
				}
			}

			[Category("01 Position"), DefaultValue(0), Description("Enter the position"), DisplayName("X :")]
			public float Position_X
			{
				get
				{
					return this.position.X;
				}
				set
				{
					this.position.X = value;
				}
			}

			[Category("01 Position"), DefaultValue(0), Description("Enter the position"), DisplayName("Y :")]
			public float Position_Y
			{
				get
				{
					return this.position.Y;
				}
				set
				{
					this.position.Y = value;
				}
			}

			[Category("01 Position"), DefaultValue(0), Description("Enter the position"), DisplayName("Z :")]
			public float Position_Z
			{
				get
				{
					return this.position.Z;
				}
				set
				{
					this.position.Z = value;
				}
			}

			[Category("01 Position"), DefaultValue(0), Description("Enter the position"), DisplayName("Enabled :")]
			public bool Position_enabled
			{
				get
				{
					return this.position_enabled;
				}
				set
				{
					this.position_enabled = value;
				}
			}

			[Category("02 Rotation"), DefaultValue(0), Description("Enter the rotation"), DisplayName("X :")]
			public float Rotation_X
			{
				get
				{
					return this.rotation.X;
				}
				set
				{
					this.rotation.X = value;
				}
			}

			[Category("02 Rotation"), DefaultValue(0), Description("Enter the rotation"), DisplayName("Y :")]
			public float Rotation_Y
			{
				get
				{
					return this.rotation.Y;
				}
				set
				{
					this.rotation.Y = value;
				}
			}

			[Category("02 Rotation"), DefaultValue(0), Description("Enter the rotation"), DisplayName("Z :")]
			public float Rotation_Z
			{
				get
				{
					return this.rotation.Z;
				}
				set
				{
					this.rotation.Z = value;
				}
			}

			[Category("02 Rotation"), DefaultValue(0), Description("Enter the rotation"), DisplayName("W :")]
			public float Rotation_W
			{
				get
				{
					return this.rotation.W;
				}
				set
				{
					this.rotation.W = value;
				}
			}

			[Category("02 Rotation"), DefaultValue(0), Description("Enter the rotation"), DisplayName("Enabled :")]
			public bool Rotation_enable
			{
				get
				{
					return this.rotation_enabled;
				}
				set
				{
					this.rotation_enabled = value;
				}
			}

			[Category("03 Scale"), DefaultValue(0), Description("Enter the scale"), DisplayName("X :")]
			public float Scale_X
			{
				get
				{
					return this.scale.X;
				}
				set
				{
					this.scale.X = value;
				}
			}

			[Category("03 Scale"), DefaultValue(0), Description("Enter the scale"), DisplayName("Y :")]
			public float Scale_Y
			{
				get
				{
					return this.scale.Y;
				}
				set
				{
					this.scale.Y = value;
				}
			}

			[Category("03 Scale"), DefaultValue(0), Description("Enter the scale"), DisplayName("Z :")]
			public float Scale_Z
			{
				get
				{
					return this.scale.Z;
				}
				set
				{
					this.scale.Z = value;
				}
			}

			[Category("03 Scale"), DefaultValue(0), Description("Enter the scale"), DisplayName("Enabled :")]
			public bool Scale_enabled
			{
				get
				{
					return this.scale_enabled;
				}
				set
				{
					this.scale_enabled = value;
				}
			}

			[Category("04 Axisrot"), DefaultValue(0), Description("Enter axis rotation"), DisplayName("X :")]
			public float Axisrot_X
			{
				get
				{
					return this.axisrot.X;
				}
				set
				{
					this.axisrot.X = value;
				}
			}

			[Category("04 Axisrot"), DefaultValue(0), Description("Enter axis rotation"), DisplayName("Y :")]
			public float Axisrot_Y
			{
				get
				{
					return this.axisrot.Y;
				}
				set
				{
					this.axisrot.Y = value;
				}
			}

			[Category("04 Axisrot"), DefaultValue(0), Description("Enter axis rotation"), DisplayName("Z :")]
			public float Axisrot_Z
			{
				get
				{
					return this.axisrot.Z;
				}
				set
				{
					this.axisrot.Z = value;
				}
			}

			[Category("04 Axisrot"), DefaultValue(0), Description("Enter axis rotation"), DisplayName("W :")]
			public float Axisrot_W
			{
				get
				{
					return this.axisrot.W;
				}
				set
				{
					this.axisrot.W = value;
				}
			}

			[Category("04 Axisrot"), DefaultValue(0), Description("Enter axis rotation"), DisplayName("Enabled :")]
			public bool Axisrot_enabled
			{
				get
				{
					return this.axisrot_enabled;
				}
				set
				{
					this.axisrot_enabled = value;
				}
			}

			[Category("05 Bone index"), DefaultValue(0), Description("Enter the bone index"), DisplayName("Bone index :")]
			public Object.Mesh.bone_type Bone_index
			{
				get
				{
					return (Object.Mesh.bone_type)this.bone_index;
				}
				set
				{
					this.bone_index = Convert.ToInt16(value);
				}
			}

			[Category("05 Bone index"), DefaultValue(0), Description("Enter the bone index"), DisplayName(" Enabled :")]
			public bool Bone_index_enabled
			{
				get
				{
					return this.bone_index_enabled;
				}
				set
				{
					this.bone_index_enabled = value;
				}
			}

			[Category("06 Dummy Index"), DefaultValue(0), Description("Enter the dummy index"), DisplayName("Dummy index :")]
			public Object.Mesh.dummy_type Dummy_index
			{
				get
				{
					return (Object.Mesh.dummy_type)this.dummy_index;
				}
				set
				{
					this.dummy_index = Convert.ToInt16(value);
				}
			}

			[Category("06 Dummy Index"), DefaultValue(0), Description("Enter the dummy index"), DisplayName(" Enabled :")]
			public bool Dummy_index_enabled
			{
				get
				{
					return this.dummy_index_enabled;
				}
				set
				{
					this.dummy_index_enabled = value;
				}
			}

			[Category("07 Parent"), DefaultValue(0), Description("Enter the parent"), DisplayName("Parent :")]
			public short Parent
			{
				get
				{
					return this.parent;
				}
				set
				{
					this.parent = value;
				}
			}

			[Category("07 Parent"), DefaultValue(0), Description("Enter the parent"), DisplayName("Enabled :")]
			public bool Parent_enabled
			{
				get
				{
					return this.parent_enabled;
				}
				set
				{
					this.parent_enabled = value;
				}
			}

			[Category("08 Collision type"), DefaultValue(0), Description("Enter the collision type"), DisplayName("Collision type :")]
			public short Collision_type
			{
				get
				{
					return this.collision_type;
				}
				set
				{
					this.collision_type = value;
				}
			}

			[Category("08 Collision type"), DefaultValue(0), Description("Enter the collision type"), DisplayName(" Enabled :")]
			public bool Collision_type_enabled
			{
				get
				{
					return this.collision_type_enabled;
				}
				set
				{
					this.collision_type_enabled = value;
				}
			}

			[Category("09 Motion"), DefaultValue(0), Description("Enter the motion path"), DisplayName("Motion path :")]
			public string Motion_Path
			{
				get
				{
					return this.Motion_path;
				}
				set
				{
					this.Motion_path = value;
				}
			}

			[Category("09 Motion"), DefaultValue(0), Description("Enter the motion path"), DisplayName("Enabled :")]
			public bool Motion_Path_enabled
			{
				get
				{
					return this.Motion_path_enabled;
				}
				set
				{
					this.Motion_path_enabled = value;
				}
			}

			[Category("10 Range set"), DefaultValue(0), Description("Enter the range set"), DisplayName("Range set :")]
			public short Range_set
			{
				get
				{
					return this.range_set;
				}
				set
				{
					this.range_set = value;
				}
			}

			[Category("10 Range set"), DefaultValue(0), Description("Enter the range set"), DisplayName("Enabled :")]
			public bool Range_set_enabled
			{
				get
				{
					return this.range_set_enabled;
				}
				set
				{
					this.range_set_enabled = value;
				}
			}

			[Category("11 Lightmap"), DefaultValue(0), Description("Enter if it use the lightmap"), DisplayName("Use lightmap :")]
			public bool Use_lightmap
			{
				get
				{
					return Convert.ToBoolean(this.use_lightmap);
				}
				set
				{
					this.use_lightmap = Convert.ToInt16(value);
				}
			}

			[Category("12 Data"), DefaultValue(0), Description("Enter the Data"), DisplayName("Data :")]
			public byte[] Data
			{
				get
				{
					return this.data;
				}
				set
				{
					this.data = value;
				}
			}

			public void read(ref BinaryReader br)
			{
				this.mesh_id = br.ReadInt16();
				this.material_id = br.ReadInt16();
				while (true)
				{
					byte b = br.ReadByte();
					if (b == 0)
					{
						break;
					}
					byte count = br.ReadByte();
					if (b == 1)
					{
						this.position_enabled = true;
						this.position.X = br.ReadSingle();
						this.position.Y = br.ReadSingle();
						this.position.Z = br.ReadSingle();
					}
					else if (b == 2)
					{
						this.rotation_enabled = true;
						this.rotation.W = br.ReadSingle();
						this.rotation.X = br.ReadSingle();
						this.rotation.Y = br.ReadSingle();
						this.rotation.Z = br.ReadSingle();
					}
					else if (b == 3)
					{
						this.scale_enabled = true;
						this.scale.X = br.ReadSingle();
						this.scale.Y = br.ReadSingle();
						this.scale.Z = br.ReadSingle();
					}
					else if (b == 4)
					{
						this.axisrot_enabled = true;
						this.axisrot.X = br.ReadSingle();
						this.axisrot.Y = br.ReadSingle();
						this.axisrot.Z = br.ReadSingle();
						this.axisrot.W = br.ReadSingle();
					}
					else if (b == 5)
					{
						this.bone_index_enabled = true;
						this.bone_index = br.ReadInt16();
					}
					else if (b == 6)
					{
						this.dummy_index_enabled = true;
						this.dummy_index = br.ReadInt16();
					}
					else if (b == 7)
					{
						this.parent_enabled = true;
						this.parent = br.ReadInt16();
					}
					else if (b == 29)
					{
						this.collision_type_enabled = true;
						this.collision_type = br.ReadInt16();
					}
					else if (b == 30)
					{
						this.Motion_path_enabled = true;
						this.Motion_path = Encoding.UTF7.GetString(br.ReadBytes((int)count));
					}
					else if (b == 31)
					{
						this.range_set_enabled = true;
						this.range_set = br.ReadInt16();
					}
					else if (b == 32)
					{
						this.use_lightmap = br.ReadInt16();
					}
					else
					{
						this.data = br.ReadBytes((int)count);
					}
				}
			}

			public void save(ref BinaryWriter bw)
			{
				bw.Write(this.mesh_id);
				bw.Write(this.material_id);
				if (this.position_enabled)
				{
					bw.Write(1);
					bw.Write(this.position.X);
					bw.Write(this.position.Y);
					bw.Write(this.position.Z);
				}
				if (this.rotation_enabled)
				{
					bw.Write(2);
					bw.Write(this.rotation.W);
					bw.Write(this.rotation.X);
					bw.Write(this.rotation.Y);
					bw.Write(this.rotation.Z);
				}
				if (this.scale_enabled)
				{
					bw.Write(3);
					bw.Write(this.scale.X);
					bw.Write(this.scale.Y);
					bw.Write(this.scale.Z);
				}
				if (this.axisrot_enabled)
				{
					bw.Write(4);
					bw.Write(this.axisrot.W);
					bw.Write(this.axisrot.X);
					bw.Write(this.axisrot.Y);
					bw.Write(this.axisrot.Z);
				}
				if (this.bone_index_enabled)
				{
					bw.Write(5);
					bw.Write(this.bone_index);
				}
				if (this.dummy_index_enabled)
				{
					bw.Write(6);
					bw.Write(this.dummy_index);
				}
				if (this.parent_enabled)
				{
					bw.Write(7);
					bw.Write(this.parent);
				}
				if (this.collision_type_enabled)
				{
					bw.Write(29);
					bw.Write(this.collision_type);
				}
				if (this.Motion_path_enabled)
				{
					bw.Write(30);
					byte[] bytes = Encoding.Default.GetBytes(this.Motion_path);
					bw.Write(bytes, 0, bytes.Length);
					bw.Write(0);
				}
				if (this.range_set_enabled)
				{
					bw.Write(31);
					bw.Write(this.range_set);
				}
				if (Convert.ToBoolean(this.use_lightmap))
				{
					bw.Write(32);
					bw.Write(this.use_lightmap);
				}
				if (this.data != null)
				{
					bw.Write(this.use_lightmap);
					bw.Write(this.data, 0, this.data.Length);
				}
				bw.Write(0);
			}
		}

		public class Effect
		{
			public short effect_id;

			public short effect_type;

			public Vector3 position;

			private bool position_enabled;

			public Quaternion rotation;

			private bool rotation_enabled;

			public Vector3 scale;

			private bool scale_enabled;

			public short parent;

			private bool parent_enabled;

			public byte[] data;

			[Category(" Basic"), DefaultValue(0), Description("Enter the effect id"), DisplayName("effect id :")]
			public short Effect_id
			{
				get
				{
					return this.effect_id;
				}
				set
				{
					this.effect_id = value;
				}
			}

			[Category(" Basic"), DefaultValue(0), Description("Enter the effect type"), DisplayName("effect type :")]
			public short Effect_type
			{
				get
				{
					return this.effect_type;
				}
				set
				{
					this.effect_type = value;
				}
			}

			[Category("01 Position"), DefaultValue(0), Description("Enter the position"), DisplayName("X :")]
			public float Position_X
			{
				get
				{
					return this.position.X;
				}
				set
				{
					this.position.X = value;
				}
			}

			[Category("01 Position"), DefaultValue(0), Description("Enter the position"), DisplayName("Y :")]
			public float Position_Y
			{
				get
				{
					return this.position.Y;
				}
				set
				{
					this.position.Y = value;
				}
			}

			[Category("01 Position"), DefaultValue(0), Description("Enter the position"), DisplayName("Z :")]
			public float Position_Z
			{
				get
				{
					return this.position.Z;
				}
				set
				{
					this.position.Z = value;
				}
			}

			[Category("01 Position"), DefaultValue(0), Description("Enter the position"), DisplayName("Enabled :")]
			public bool Position_enabled
			{
				get
				{
					return this.position_enabled;
				}
				set
				{
					this.position_enabled = value;
				}
			}

			[Category("02 Rotation"), DefaultValue(0), Description("Enter the rotation"), DisplayName("X :")]
			public float Rotation_X
			{
				get
				{
					return this.rotation.X;
				}
				set
				{
					this.rotation.X = value;
				}
			}

			[Category("02 Rotation"), DefaultValue(0), Description("Enter the rotation"), DisplayName("Y :")]
			public float Rotation_Y
			{
				get
				{
					return this.rotation.Y;
				}
				set
				{
					this.rotation.Y = value;
				}
			}

			[Category("02 Rotation"), DefaultValue(0), Description("Enter the rotation"), DisplayName("Z :")]
			public float Rotation_Z
			{
				get
				{
					return this.rotation.Z;
				}
				set
				{
					this.rotation.Z = value;
				}
			}

			[Category("02 Rotation"), DefaultValue(0), Description("Enter the rotation"), DisplayName("W :")]
			public float Rotation_W
			{
				get
				{
					return this.rotation.W;
				}
				set
				{
					this.rotation.W = value;
				}
			}

			[Category("02 Rotation"), DefaultValue(0), Description("Enter the rotation"), DisplayName("Enabled :")]
			public bool Rotation_enable
			{
				get
				{
					return this.rotation_enabled;
				}
				set
				{
					this.rotation_enabled = value;
				}
			}

			[Category("03 Scale"), DefaultValue(0), Description("Enter the scale"), DisplayName("X :")]
			public float Scale_X
			{
				get
				{
					return this.scale.X;
				}
				set
				{
					this.scale.X = value;
				}
			}

			[Category("03 Scale"), DefaultValue(0), Description("Enter the scale"), DisplayName("Y :")]
			public float Scale_Y
			{
				get
				{
					return this.scale.Y;
				}
				set
				{
					this.scale.Y = value;
				}
			}

			[Category("03 Scale"), DefaultValue(0), Description("Enter the scale"), DisplayName("Z :")]
			public float Scale_Z
			{
				get
				{
					return this.scale.Z;
				}
				set
				{
					this.scale.Z = value;
				}
			}

			[Category("03 Scale"), DefaultValue(0), Description("Enter the scale"), DisplayName("Enabled :")]
			public bool Scale_enabled
			{
				get
				{
					return this.scale_enabled;
				}
				set
				{
					this.scale_enabled = value;
				}
			}

			[Category("07 Parent"), DefaultValue(0), Description("Enter the parent"), DisplayName("Parent :")]
			public short Parent
			{
				get
				{
					return this.parent;
				}
				set
				{
					this.parent = value;
				}
			}

			[Category("07 Parent"), DefaultValue(0), Description("Enter the parent"), DisplayName("Enabled :")]
			public bool Parent_enabled
			{
				get
				{
					return this.parent_enabled;
				}
				set
				{
					this.parent_enabled = value;
				}
			}

			[Category("12 Data"), DefaultValue(0), Description("Enter the Data"), DisplayName("Data :")]
			public byte[] Data
			{
				get
				{
					return this.data;
				}
				set
				{
					this.data = value;
				}
			}

			public void read(ref BinaryReader br)
			{
				this.effect_id = br.ReadInt16();
				this.effect_type = br.ReadInt16();
				while (true)
				{
					byte b = br.ReadByte();
					if (b == 0)
					{
						break;
					}
					byte count = br.ReadByte();
					if (b == 1)
					{
						this.position_enabled = true;
						this.position.X = br.ReadSingle();
						this.position.Y = br.ReadSingle();
						this.position.Z = br.ReadSingle();
					}
					else if (b == 2)
					{
						this.rotation_enabled = true;
						this.rotation.W = br.ReadSingle();
						this.rotation.X = br.ReadSingle();
						this.rotation.Y = br.ReadSingle();
						this.rotation.Z = br.ReadSingle();
					}
					else if (b == 3)
					{
						this.scale_enabled = true;
						this.scale.X = br.ReadSingle();
						this.scale.Y = br.ReadSingle();
						this.scale.Z = br.ReadSingle();
					}
					else if (b == 7)
					{
						this.parent_enabled = true;
						this.parent = br.ReadInt16();
					}
					else
					{
						this.data = br.ReadBytes((int)count);
					}
				}
			}

			public void save(ref BinaryWriter bw)
			{
				bw.Write(this.effect_id);
				bw.Write(this.effect_type);
				if (this.position_enabled)
				{
					bw.Write(1);
					bw.Write(this.position.X);
					bw.Write(this.position.Y);
					bw.Write(this.position.Z);
				}
				if (this.rotation_enabled)
				{
					bw.Write(2);
					bw.Write(this.rotation.W);
					bw.Write(this.rotation.X);
					bw.Write(this.rotation.Y);
					bw.Write(this.rotation.Z);
				}
				if (this.scale_enabled)
				{
					bw.Write(3);
					bw.Write(this.scale.X);
					bw.Write(this.scale.Y);
					bw.Write(this.scale.Z);
				}
				if (this.parent_enabled)
				{
					bw.Write(7);
					bw.Write(this.parent);
				}
				bw.Write(0);
			}
		}

		private int boundingsphere_radius;

		private int boundingsphere_x;

		private int boundingsphere_y;

		private Vector3 minbounds;

		private Vector3 maxbounds;

		public List<Object.Mesh> list_mesh = new List<Object.Mesh>();

		public List<Object.Effect> list_effect = new List<Object.Effect>();

		[Category(" Object"), DefaultValue(0), Description("Enter bounding sphere radius"), DisplayName("Bounding sphere radius :")]
		public int Boundingsphere_Radius
		{
			get
			{
				return this.boundingsphere_radius;
			}
			set
			{
				this.boundingsphere_radius = value;
			}
		}

		[Category(" Object"), DefaultValue(0), Description("Enter bounding sphere x"), DisplayName("Bounding sphere x :")]
		public int Boundingsphere_X
		{
			get
			{
				return this.boundingsphere_x;
			}
			set
			{
				this.boundingsphere_x = value;
			}
		}

		[Category(" Object"), DefaultValue(0), Description("Enter bounding sphere y"), DisplayName("Bounding sphere y :")]
		public int Boundingsphere_Y
		{
			get
			{
				return this.boundingsphere_y;
			}
			set
			{
				this.boundingsphere_y = value;
			}
		}

		[Category("Minbounds"), DefaultValue(0), Description("Enter the minbound"), DisplayName("X :")]
		public float Minbounds_X
		{
			get
			{
				return this.minbounds.X;
			}
			set
			{
				this.minbounds.X = value;
			}
		}

		[Category("Minbounds"), DefaultValue(0), Description("Enter the minbound"), DisplayName("Y :")]
		public float Minbounds_Y
		{
			get
			{
				return this.minbounds.Y;
			}
			set
			{
				this.minbounds.Y = value;
			}
		}

		[Category("Minbounds"), DefaultValue(0), Description("Enter the minbound"), DisplayName("Z :")]
		public float Minbounds_Z
		{
			get
			{
				return this.minbounds.Z;
			}
			set
			{
				this.minbounds.Z = value;
			}
		}

		[Category("Maxbounds"), DefaultValue(0), Description("Enter the maxbound"), DisplayName("X :")]
		public float Maxbounds_X
		{
			get
			{
				return this.maxbounds.X;
			}
			set
			{
				this.maxbounds.X = value;
			}
		}

		[Category("Maxbounds"), DefaultValue(0), Description("Enter the maxbound"), DisplayName("Y :")]
		public float Maxbounds_Y
		{
			get
			{
				return this.maxbounds.Y;
			}
			set
			{
				this.maxbounds.Y = value;
			}
		}

		[Category("Maxbounds"), DefaultValue(0), Description("Enter the maxbound"), DisplayName("Z :")]
		public float Maxbounds_Z
		{
			get
			{
				return this.maxbounds.Z;
			}
			set
			{
				this.maxbounds.Z = value;
			}
		}

		public void read(ref BinaryReader br)
		{
			this.boundingsphere_radius = br.ReadInt32();
			this.boundingsphere_x = br.ReadInt32();
			this.boundingsphere_y = br.ReadInt32();
			short num = br.ReadInt16();
			if (num > 0)
			{
				for (int num2 = 0; num2 != (int)num; num2++)
				{
					Object.Mesh mesh = new Object.Mesh();
					mesh.read(ref br);
					this.list_mesh.Add(mesh);
				}
				short num3 = br.ReadInt16();
				for (int num2 = 0; num2 != (int)num3; num2++)
				{
					Object.Effect effect = new Object.Effect();
					effect.read(ref br);
					this.list_effect.Add(effect);
				}
				this.minbounds.X = br.ReadSingle();
				this.minbounds.Y = br.ReadSingle();
				this.minbounds.Z = br.ReadSingle();
				this.maxbounds.X = br.ReadSingle();
				this.maxbounds.Y = br.ReadSingle();
				this.maxbounds.Z = br.ReadSingle();
			}
		}

		public void save(ref BinaryWriter bw)
		{
			bw.Write(this.boundingsphere_radius);
			bw.Write(this.boundingsphere_x);
			bw.Write(this.boundingsphere_y);
			bw.Write((short)this.list_mesh.Count);
			if (this.list_mesh.Count > 0)
			{
				for (int num = 0; num != this.list_mesh.Count; num++)
				{
					this.list_mesh[num].save(ref bw);
				}
				bw.Write((short)this.list_effect.Count);
				for (int num = 0; num != this.list_effect.Count; num++)
				{
					this.list_effect[num].save(ref bw);
				}
				bw.Write(this.minbounds.X);
				bw.Write(this.minbounds.Y);
				bw.Write(this.minbounds.Z);
				bw.Write(this.maxbounds.X);
				bw.Write(this.maxbounds.Y);
				bw.Write(this.maxbounds.Z);
			}
		}
	}
}
