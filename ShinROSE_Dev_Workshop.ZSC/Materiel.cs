using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ShinROSE_Dev_Workshop.ZSC
{
	public class Materiel
	{
		public string path;

		private short is_skin;

		private short alpha_enabled;

		private short two_sided;

		private short alpha_test_enabled;

		private short alpha_ref_enabled;

		private short z_write_enabled;

		private short z_test_enabled;

		private short blending_mode;

		private short specular_enabled;

		private float alpha;

		private short glow_type;

		private float red;

		private float green;

		private float blue;

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter the path of the Materiel"), DisplayName("Materiel path :")]
		public string Materiel_path
		{
			get
			{
				return this.path;
			}
			set
			{
				this.path = value;
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter if it's Skin"), DisplayName("Is skin :")]
		public short Is_Skin
		{
			get
			{
				return this.is_skin;
			}
			set
			{
				this.is_skin = value;
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter if the Alpha is enabled"), DisplayName("Alpha Enable :")]
		public bool Alpha_Enable
		{
			get
			{
				return Convert.ToBoolean(this.alpha_enabled);
			}
			set
			{
				this.alpha_enabled = Convert.ToInt16(value);
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter if there is two sided"), DisplayName("Two sided :")]
		public short Two_Sided
		{
			get
			{
				return this.two_sided;
			}
			set
			{
				this.two_sided = value;
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter if there is an alpha test"), DisplayName("Alpha test:")]
		public bool Alpha_test
		{
			get
			{
				return Convert.ToBoolean(this.alpha_test_enabled);
			}
			set
			{
				this.alpha_test_enabled = Convert.ToInt16(value);
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter if there is an alpha ref"), DisplayName("Alpha ref:")]
		public bool Alpha_ref
		{
			get
			{
				return Convert.ToBoolean(this.alpha_ref_enabled);
			}
			set
			{
				this.alpha_ref_enabled = Convert.ToInt16(value);
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter if there is z write"), DisplayName("z write:")]
		public bool z_Write
		{
			get
			{
				return Convert.ToBoolean(this.z_write_enabled);
			}
			set
			{
				this.z_write_enabled = Convert.ToInt16(value);
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter if there is z test"), DisplayName("z test:")]
		public bool z_Test
		{
			get
			{
				return Convert.ToBoolean(this.z_test_enabled);
			}
			set
			{
				this.z_test_enabled = Convert.ToInt16(value);
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter the blending mode"), DisplayName("Blending mode:")]
		public short Blending_Mode
		{
			get
			{
				return this.blending_mode;
			}
			set
			{
				this.blending_mode = value;
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter if the Specular is enabled"), DisplayName("Specular :")]
		public short Specular_enabled
		{
			get
			{
				return this.specular_enabled;
			}
			set
			{
				this.specular_enabled = value;
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter the alpha"), DisplayName("Alpha :")]
		public float Alpha
		{
			get
			{
				return this.alpha;
			}
			set
			{
				this.alpha = value;
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Enter the glow type"), DisplayName("Glow type :")]
		public short Glow_type
		{
			get
			{
				return this.glow_type;
			}
			set
			{
				this.glow_type = value;
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Red"), DisplayName("Red :")]
		public float Red
		{
			get
			{
				return this.red;
			}
			set
			{
				this.red = value;
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Green"), DisplayName("Green :")]
		public float Green
		{
			get
			{
				return this.green;
			}
			set
			{
				this.green = value;
			}
		}

		[Category("Materiel-DDS"), DefaultValue(0), Description("Blue"), DisplayName("Blue :")]
		public float Blue
		{
			get
			{
				return this.blue;
			}
			set
			{
				this.blue = value;
			}
		}

		public void read(ref BinaryReader br)
		{
			this.path = "";
			while (true)
			{
				byte b = br.ReadByte();
				if (b == 0)
				{
					break;
				}
				this.path += (char)b;
			}
			this.is_skin = br.ReadInt16();
			this.alpha_enabled = br.ReadInt16();
			this.two_sided = br.ReadInt16();
			this.alpha_test_enabled = br.ReadInt16();
			this.alpha_ref_enabled = br.ReadInt16();
			this.z_write_enabled = br.ReadInt16();
			this.z_test_enabled = br.ReadInt16();
			this.blending_mode = br.ReadInt16();
			this.specular_enabled = br.ReadInt16();
			this.alpha = br.ReadSingle();
			this.glow_type = br.ReadInt16();
			this.red = br.ReadSingle();
			this.green = br.ReadSingle();
			this.blue = br.ReadSingle();
		}

		public void save(ref BinaryWriter bw)
		{
			byte[] bytes = Encoding.Default.GetBytes(this.path);
			bw.Write(bytes, 0, bytes.Length);
			bw.Write(0);
			bw.Write(this.is_skin);
			bw.Write(this.alpha_enabled);
			bw.Write(this.two_sided);
			bw.Write(this.alpha_test_enabled);
			bw.Write(this.alpha_ref_enabled);
			bw.Write(this.z_write_enabled);
			bw.Write(this.z_test_enabled);
			bw.Write(this.blending_mode);
			bw.Write(this.specular_enabled);
			bw.Write(this.alpha);
			bw.Write(this.glow_type);
			bw.Write(this.red);
			bw.Write(this.green);
			bw.Write(this.blue);
		}
	}
}
