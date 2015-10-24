using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ShinROSE_Dev_Workshop.CHR
{
	public class Mesh
	{
		public string path;

		[Category("Skeleton-ZMD"), DefaultValue(0), Description("Enter the path of the Mesh"), DisplayName("Mesh path :")]
		public string Mesh_path
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
		}

		public void save(ref BinaryWriter bw)
		{
			byte[] bytes = Encoding.Default.GetBytes(this.path);
			bw.Write(bytes, 0, bytes.Length);
			bw.Write(0);
		}
	}
}
