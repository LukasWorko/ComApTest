using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComApTest
{
	class Program
	{
		static void Main(string[] args)
		{
			bool run = true;
			FileReader fileReader = null;
			string filePath = "";			

			while (run)
			{
				Console.Write("> ");
				string line = Console.ReadLine();
				string[] tokens = line.Split(' ');
				tokens = tokens.Where(s => s.Length > 1).ToArray();

				switch (tokens[0])
				{
					case "exit":
						run = false;
						break;

					case "read":
						filePath = "";
						for(int i = 0; i < tokens.Length; i++)
						{
							if (i > 0)
							{
								filePath += tokens[i] + " ";								
							}
						}						
						fileReader = new FileReader(filePath);						
						break;

					case "write":
						if(fileReader == null)
						{
							Console.WriteLine("No file read");
							break;
						}
						File f = fileReader.Process();
						FileWriter fWrite = null;
						if (tokens[1] == "json")
							fWrite = new JsonFileWriter(f);
						else
							fWrite = new XmlFileWriter(f);

						string[] tokens1 = filePath.Split('\'');
						string folderDest = "";
						for(int i = 0; i < tokens1.Length-1; i++)
						{
							folderDest += tokens1[i];
						}
						fWrite.WriteToFile(folderDest, "res");
						break;

					default:
						Console.WriteLine("Invalid command");
						break;
				}												
			}
		}
	}
}
