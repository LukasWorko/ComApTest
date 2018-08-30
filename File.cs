using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComApTest
{
	public class File
	{		
		public List<Student> students = new List<Student>();
		int scoreRange = 100;		

		public File(string[] lines)
		{
			int groupID = 0;
			for (int i = 1; i < lines.Length; i++)
			{					
				if (lines[i].Length >= 5 && lines[i].Substring(0, 5) == "Group")
				{					
					groupID = Int32.Parse(lines[i].Substring(5, 1));					
				}
				else if(lines[i].Length >= 1)
				{
					Student student = CreateStudent(lines[i]);
					student.Group = groupID;					
					students.Add(student);					
				}
			}			
		}

		private Student CreateStudent(string line)
		{
			Student student = new Student();
			string[] tokens = line.Split(';');
			student.Name = tokens[0];
			
			string[] math = tokens[1].Split('=');
			string[] physics = tokens[2].Split('=');
			string[] english = tokens[3].Split('=');
			
			try
			{
				student.MathScore = Int32.Parse(math[1]);
				student.PhysicsScore = Int32.Parse(physics[1]);
				student.EnglishScore = Int32.Parse(english[1]);				
			}
			catch (FormatException e)
			{
				Console.WriteLine(e.Message);
			}			

			if(student.MathScore < 0 || student.MathScore > scoreRange || student.PhysicsScore < 0 || 
				student.PhysicsScore > scoreRange || student.EnglishScore < 0 || student.EnglishScore > scoreRange)
			{
				Console.WriteLine("Score out of range");				
			}

			return student;
		}						

		public struct Student
		{
			public string Name;
			public int MathScore;
			public int PhysicsScore;
			public int EnglishScore;
			public int Group;			
		}		
	}
}
