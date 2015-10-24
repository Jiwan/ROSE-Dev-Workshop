using System;
using System.IO;
using System.Text;
using System.Xml;

namespace ShinROSE_Dev_Workshop.STB.converter.Stb_to_xml_converter
{
	internal class Converter
	{
		public struct Column
		{
			public short columnwidth;

			public string columntitle;

			public bool selected;
		}

		private struct Row
		{
			public string rowdata;
		}

		private string format_code;

		private int data_offset;

		private int rowcount;

		public int columncount;

		private int rowheight;

		private string idcolumnname;

		private string[,] celldata;

		private Converter.Row[] row;

		public Converter.Column[] column;

		public void Load_STB(string path)
		{
			BinaryReader binaryReader = new BinaryReader(File.Open(path, FileMode.Open));
			this.format_code = new string(binaryReader.ReadChars(4));
			this.data_offset = binaryReader.ReadInt32();
			this.rowcount = binaryReader.ReadInt32();
			this.columncount = binaryReader.ReadInt32();
			this.rowheight = binaryReader.ReadInt32();
			this.column = new Converter.Column[this.columncount + 1];
			for (int num = 0; num != this.columncount + 1; num++)
			{
				this.column[num].columnwidth = binaryReader.ReadInt16();
			}
			for (int num = 0; num != this.columncount; num++)
			{
				short count = binaryReader.ReadInt16();
				this.column[num].columntitle = Encoding.UTF7.GetString(binaryReader.ReadBytes((int)count));
			}
			short count2 = binaryReader.ReadInt16();
			this.idcolumnname = Encoding.UTF7.GetString(binaryReader.ReadBytes((int)count2));
			this.row = new Converter.Row[this.rowcount];
			for (int num = 0; num != this.rowcount - 1; num++)
			{
				short count3 = binaryReader.ReadInt16();
				this.row[num].rowdata = Encoding.UTF7.GetString(binaryReader.ReadBytes((int)count3));
			}
			this.celldata = new string[this.rowcount, this.columncount];
			for (int num = 0; num != this.rowcount - 1; num++)
			{
				for (int num2 = 0; num2 != this.columncount - 1; num2++)
				{
					short count3 = binaryReader.ReadInt16();
					this.celldata[num, num2] = Encoding.UTF7.GetString(binaryReader.ReadBytes((int)count3));
				}
			}
			binaryReader.Close();
		}

		public void Save_XML(string path)
		{
			XmlTextWriter xmlTextWriter = new XmlTextWriter(path, null);
			xmlTextWriter.Formatting = Formatting.Indented;
			xmlTextWriter.WriteStartDocument(false);
			xmlTextWriter.WriteComment("Xml from Juan converter");
			xmlTextWriter.WriteStartElement("STB");
			for (int num = 0; num != this.rowcount; num++)
			{
				xmlTextWriter.WriteStartElement("Entry");
				xmlTextWriter.WriteAttributeString("id", num.ToString());
				for (int num2 = 0; num2 != this.columncount; num2++)
				{
					if (this.column[num2].selected)
					{
						xmlTextWriter.WriteStartElement("Data");
						xmlTextWriter.WriteAttributeString("type", this.column[num2].columntitle);
						xmlTextWriter.WriteString(this.celldata[num, num2]);
						xmlTextWriter.WriteEndElement();
					}
				}
				xmlTextWriter.WriteEndElement();
			}
			xmlTextWriter.WriteEndElement();
			xmlTextWriter.Flush();
			xmlTextWriter.Close();
			xmlTextWriter.Close();
		}
	}
}
