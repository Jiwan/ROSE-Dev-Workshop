using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ShinROSE_Dev_Workshop.CHR
{
	public class Motion
	{
		public string path;

		[Category("Motion-ZMO"), DefaultValue(0), Description("Enter the path of the Motion"), DisplayName("Motion path :")]
		public string Motion_path
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
