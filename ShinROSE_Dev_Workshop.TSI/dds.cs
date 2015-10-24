using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ShinROSE_Dev_Workshop.TSI
{
	public class dds
	{
		public class dds_element
		{
			public short ownerid;

			public int x1;

			public int y1;

			public int x2;

			public int y2;

			public int colour;

			public string name;

			[Category("Element"), DefaultValue(0), Description("Selectionner l'id de l'owner"), DisplayName("Owner id :")]
			public short owner_id
			{
				get
				{
					return this.ownerid;
				}
				set
				{
					this.ownerid = value;
				}
			}

			[Category("Point (1)"), DefaultValue(0), Description("Entrer les coordonnées de x1")]
			public int X1
			{
				get
				{
					return this.x1;
				}
				set
				{
					this.x1 = value;
				}
			}

			[Category("Point (1)"), DefaultValue(0), Description("Entrer les coordonnées de y1")]
			public int Y1
			{
				get
				{
					return this.y1;
				}
				set
				{
					this.y1 = value;
				}
			}

			[Category("Point (2)"), DefaultValue(0), Description("Entrer les coordonnées de x2")]
			public int X2
			{
				get
				{
					return this.x2;
				}
				set
				{
					this.x2 = value;
				}
			}

			[Category("Point (2)"), DefaultValue(0), Description("Entrer les coordonnées de y2")]
			public int Y2
			{
				get
				{
					return this.y2;
				}
				set
				{
					this.y2 = value;
				}
			}

			[Category("Element"), DefaultValue(0), Description("Entrer la couleur"), DisplayName("Color :")]
			public int couleur
			{
				get
				{
					return this.colour;
				}
				set
				{
					this.colour = value;
				}
			}

			[Category("Element"), DefaultValue(0), Description("Entrer le nom (32 caractères maximum)"), DisplayName("Name :")]
			public string nom
			{
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
				}
			}

			public void Load_element(ref BinaryReader br)
			{
				this.ownerid = br.ReadInt16();
				this.x1 = br.ReadInt32();
				this.y1 = br.ReadInt32();
				this.x2 = br.ReadInt32();
				this.y2 = br.ReadInt32();
				this.colour = br.ReadInt32();
				this.name = Encoding.UTF7.GetString(br.ReadBytes(32));
			}
		}

		public string path;

		public int colour_key;

		public List<dds.dds_element> ListDDS_element = new List<dds.dds_element>();

		public short ddselement_count;

		[Category("DDS"), DefaultValue(0), Description("Entrer le chemin du DDS"), DisplayName("Name of dds :")]
		public string Nom_du_DDS
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

		[Category("DDS"), DefaultValue(0), Description("Entrer la colour key"), DisplayName("Color :")]
		public int Colour
		{
			get
			{
				return this.colour_key;
			}
			set
			{
				this.colour_key = value;
			}
		}
	}
}
