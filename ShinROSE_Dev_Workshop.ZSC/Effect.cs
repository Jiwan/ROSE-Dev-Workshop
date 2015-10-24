using System;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace ShinROSE_Dev_Workshop.ZSC
{
	public class Effect
	{
		public string path;

		[Category("Effect-eft"), DefaultValue(0), Description("Enter the path of the Effect"), DisplayName("Effect path :")]
		public string Effect_path
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
