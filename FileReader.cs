using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComApTest
{
	class FileReader
	{
		private File file;		

		public FileReader(string fileName)
		{
			try
			{
				string[] lines = System.IO.File.ReadAllLines(fileName);
				file = new File(lines);
			}
			catch(Exception e)
			{
				Console.WriteLine("Invalid filepath");
			}			
		}

		public File Process()
		{
			return file;
		}
	}
}
