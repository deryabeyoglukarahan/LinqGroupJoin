namespace SchoolDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sınıflar listesi
            List<Class> classes = new List<Class>
            {
                new Class { ClassId = 1, ClassName = "Matematik" },
                new Class { ClassId = 2, ClassName = "Fizik" },
                new Class { ClassId = 3, ClassName = "Edebiyat" }
            };

            // Öğrenciler listesi
            List<Student> students = new List<Student>
            {
                new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
                new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 1 },
                new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 2 },
                new Student { StudentId = 4, StudentName = "Fatma", ClassId = 3 },
                new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 3 }
            };

            // Group Join LINQ sorgusu
            var query = from c in classes
                        join s in students on c.ClassId equals s.ClassId into studentGroup
                        select new
                        {
                            ClassName = c.ClassName,
                            Students = studentGroup
                        };

            // Sonuçları yazdır
            foreach (var item in query)
            {
                Console.WriteLine($"Sınıf: {item.ClassName}");
                if (item.Students.Any())
                {
                    foreach (var student in item.Students)
                    {
                        Console.WriteLine($"  - {student.StudentName}");
                    }
                }
                else
                {
                    Console.WriteLine("  (Bu sınıfa ait öğrenci yok)");
                }
                Console.WriteLine();
            }
        }
    }
}
