using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComApTest
{
	class JsonFileWriter : FileWriter
	{
		public JsonFileWriter(File file) : base(file) { }

		public override void WriteToFile(string folderName, string fileName)
		{
			//TODO to implement JSON output structure
		}
	}
}
