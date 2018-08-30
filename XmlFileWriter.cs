using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ComApTest
{
	public class XmlFileWriter : FileWriter
	{		
		public XmlFileWriter(File file) : base(file){}

		public override void WriteToFile(string folderName, string fileName)
		{
			XmlWriter xmlWriter = XmlWriter.Create(folderName + "\"" + fileName);

			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement("students");

			foreach (Student s in studentOutput)
			{
				xmlWriter.WriteStartElement("student");
				xmlWriter.WriteAttributeString("average", "" + s.Average);
				xmlWriter.WriteString(s.Name);
				xmlWriter.WriteEndElement();				
			}			

			xmlWriter.WriteStartElement("groups");

			foreach (Group g in groupOutput)
			{
				xmlWriter.WriteStartElement("group");
				xmlWriter.WriteAttributeString("MathAverage", "" + g.Math.Average);
				xmlWriter.WriteAttributeString("MathMedian", "" + g.Math.Median);
				xmlWriter.WriteAttributeString("MathModus", "" + g.Math.Modus);

				xmlWriter.WriteAttributeString("PhysicsAverage", "" + g.Physics.Average);
				xmlWriter.WriteAttributeString("PhysicsMedian", "" + g.Physics.Median);
				xmlWriter.WriteAttributeString("PhysicsModus", "" + g.Physics.Modus);

				xmlWriter.WriteAttributeString("EnglishAverage", "" + g.English.Average);
				xmlWriter.WriteAttributeString("EnglishMedian", "" + g.English.Median);
				xmlWriter.WriteAttributeString("EnglishModus", "" + g.English.Modus);

				xmlWriter.WriteString("" + g.GroupID);
				xmlWriter.WriteEndElement();
			}

			xmlWriter.WriteEndDocument();
			xmlWriter.Close();
		}
	}
}
