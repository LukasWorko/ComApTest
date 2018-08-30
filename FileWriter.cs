using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComApTest
{
	public class FileWriter
	{
		protected File file;		
		public List<Student> studentOutput { get; private set; } = new List<Student>();
		public List<Group> groupOutput { get; private set; } = new List<Group>();

		public FileWriter(File file)
		{
			this.file = file;			
			foreach (File.Student s in file.students)
			{
				Student so = new Student();
				so.Name = s.Name;
				so.Average = (s.MathScore * 0.45f + s.PhysicsScore * 0.25f + s.EnglishScore * 0.15f) / 3;
				studentOutput.Add(so);
			}
			
			var groupIDs = file.students.Select(s => s.Group).Distinct();
			for(int i = 0; i < groupIDs.Count(); i++)
			{
				Group group = new Group();
				var groupStudents = file.students.Where(s => s.Group == groupIDs.ElementAt(i)).ToList();
				CalculateStats(groupStudents, out group);				
				group.GroupID = groupIDs.ElementAt(i);
				groupOutput.Add(group);
			}

			Group total = new Group();
			total.GroupID = groupIDs.Count();			
			CalculateStats(file.students, out total);
			groupOutput.Add(total);
		}

		public virtual void WriteToFile(string folderName, string fileName) { }

		private void CalculateStats(List<File.Student> list, out Group g)
		{
			Group group = new Group();			
			group.Math.Average = Mean(list, s => s.MathScore);
			group.Math.Median = Median(list, s => s.MathScore);
			group.Math.Modus = Modus(list, s => s.MathScore);

			group.Physics.Average = Mean(list, s => s.PhysicsScore);
			group.Physics.Median = Median(list, s => s.PhysicsScore);
			group.Physics.Modus = Modus(list, s => s.PhysicsScore);

			group.English.Average = Mean(list, s => s.EnglishScore);
			group.English.Median = Median(list, s => s.EnglishScore);
			group.English.Modus = Modus(list, s => s.EnglishScore);

			g = group;
		}

		private double Mean(List<File.Student> students, Func<File.Student, int> f)
		{
			return students.Select(f).Average();
		}

		private int Median(List<File.Student> students, Func<File.Student, int> f)
		{
			var orderedList = students.OrderBy(f).Select(f);
			if (students.Count % 2 == 0)
				return (orderedList.ElementAt(orderedList.Count() / 2) + orderedList.ElementAt((orderedList.Count() / 2) - 1)) / 2;
			else
				return orderedList.ElementAt(orderedList.Count() / 2);
		}

		private int Modus(List<File.Student> students, Func<File.Student, int> f)
		{
			return students.GroupBy(f).OrderByDescending(gr => gr.Count()).Select(gr => gr.Key).FirstOrDefault();
		}

		public struct Group
		{
			public int GroupID;
			public SubjectStats Math;
			public SubjectStats Physics;
			public SubjectStats English;
		}

		public struct SubjectStats
		{
			public double Average;
			public int Median;
			public int Modus;
		}		

		public struct Student
		{
			public string Name;
			public float Average;			
		}
	}
}
