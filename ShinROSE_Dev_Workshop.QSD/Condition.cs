using System;
using System.Xml.XPath;

namespace ShinROSE_Dev_Workshop.QSD
{
	internal class Condition
	{
		public void condition()
		{
		}

		public string find_condition_name(string command, string app_path)
		{
			XPathDocument xPathDocument = new XPathDocument(app_path + "\\ConditionQSD.xml");
			XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
			string xpath = ".//Opcode[@id='" + command + "']";
			XPathNodeIterator xPathNodeIterator = xPathNavigator.Select(xPathNavigator.Compile(xpath));
			string result;
			if (xPathNodeIterator.Count != 0)
			{
				xPathNodeIterator.MoveNext();
				xPathNodeIterator.Current.MoveToFirstChild();
				string value = xPathNodeIterator.Current.Value;
				result = value + " (" + command + ")";
			}
			else
			{
				result = "unknow (" + command + ")";
			}
			return result;
		}

		public bool part_count(string command, ref string[] data_name, ref string[] data_lenght, string app_path)
		{
			XPathDocument xPathDocument = new XPathDocument(app_path + "\\ConditionQSD.xml");
			XPathNavigator xPathNavigator = xPathDocument.CreateNavigator();
			string xpath = "//Opcode[@id='" + command + "']/Struct/data";
			XPathNodeIterator xPathNodeIterator = xPathNavigator.Select(xPathNavigator.Compile(xpath));
			bool result;
			if (xPathNodeIterator.Count != 0)
			{
				data_name = new string[xPathNodeIterator.Count];
				data_lenght = new string[xPathNodeIterator.Count];
				for (int num = 0; num != xPathNodeIterator.Count; num++)
				{
					xPathNodeIterator.MoveNext();
					data_name[num] = xPathNodeIterator.Current.Value;
					data_lenght[num] = xPathNodeIterator.Current.GetAttribute("type", "");
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
	}
}
