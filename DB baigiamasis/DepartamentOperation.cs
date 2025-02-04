

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DB_baigiamasis
{
    public class DepartamentOperation
    {
        public static void CreateNewDepartament()
        {

            var newObject = new Departament();
            Console.Clear();
            Console.Write("Ivesk departamento pavadinima: ");
            newObject.Name = Console.ReadLine();
            using (var db = new Database())
            {
                db.Departaments.Add(newObject);
                db.SaveChanges();
                Console.WriteLine($"Departamentas {newObject.Name} pridetas.");
                Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                Console.ReadKey();
            }
        }

        public static void CorrectionDepartamentName()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti departamento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Departaments.Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi departamento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Pasirink paskaitos numeri kuri nori koreguoti: ");
                int index;
                string newName = "";
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    Console.WriteLine("Ivesk i koki pavadinima nori keisti: ");
                    newName = Console.ReadLine();
                    objectFind[index - 1].Name = newName;
                    db.SaveChanges();
                    Console.WriteLine($"Departamento pavadinimas pakeistas i {objectFind[index - 1].Name}.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Ivestas blogas skaicius");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
            }
        }


        public static void RemoveDepartament()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti departamento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Departaments.Include(a => a.Students).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi departamento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Pasirink departamento numeri kuri nori istrinti: ");
                int index;
                string newName = "";
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    objectFind[index - 1].Students.Clear();
                    db.Departaments.Remove(objectFind[index - 1]);

                    db.SaveChanges();
                    Console.WriteLine($"Departamentas {objectFind[index - 1].Name} istrintas");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Ivestas blogas skaicius");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
            }

        }

        public static void AddLectureToDepartament()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti departamento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Departaments.Include(a => a.Lectures).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi departamento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink departamento numeri prie kurio nori prideti paskaitas: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    var lecturesNotInDepartment = db.Lectures
                 .Where(l => !db.Departaments.Where(d => d.Name == objectFind[index - 1].Name)
                 .SelectMany(d => d.Lectures)
                 .Any(dl => dl.Id == l.Id))
                 .ToList();

                if (lecturesNotInDepartment.Any())
                {
                    Console.Clear();
                    Console.WriteLine("Galite prideti sias paskaitas: ");
                    for (int i = 1; i <= lecturesNotInDepartment.Count; i++)
                    {
                        Console.WriteLine($"{i}. {lecturesNotInDepartment[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Nepriskirtu paskaitu nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Ivesk paskaitos numeri kuria nori prideti: ");
                int indexLecture;
                bool isIndexLecture = int.TryParse(Console.ReadLine(), out indexLecture);
                if (isIndexLecture && indexLecture > 0 && indexLecture <= lecturesNotInDepartment.Count)
                {
                    objectFind[index - 1].Lectures.Add(lecturesNotInDepartment[indexLecture - 1]);
                    db.SaveChanges();
                    Console.WriteLine($"Departamentui {objectFind[index - 1].Name} prideta paskaita {lecturesNotInDepartment[indexLecture - 1].Name}");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Ivestas blogas skaicius");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
            }
                else
            {
                Console.WriteLine("Ivestas blogas skaicius");
                Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                Console.ReadKey();
            }
        }

        }

        public static void RemoveLectureFromDepartament()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti departamento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Departaments.Include(a => a.Lectures).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi departamento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink departamento numeri nuo kurio nori atsieti paskaitas: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {

                    if (objectFind[index - 1].Lectures.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Departamentas turi sias paskaitas: ");
                        for (int i = 1; i <= objectFind[index - 1].Lectures.Count; i++)
                        {
                            Console.WriteLine($"{i}. {objectFind[index - 1].Lectures[i - 1].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Departamentas paskaitu neturi.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Ivesk paskaitos numeri kuri nori pasalinti: ");
                    int indexLecture;
                    bool isIndexLecture = int.TryParse(Console.ReadLine(), out indexLecture);
                    if (isIndexLecture && indexLecture > 0 && indexLecture <= objectFind[index - 1].Lectures.Count)
                    {
                        objectFind[index - 1].Lectures.Remove(objectFind[index - 1].Lectures[indexLecture - 1]);
                        db.SaveChanges();
                        Console.WriteLine($"Is departamento {objectFind[index - 1].Name} pasalinta paskaita.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ivestas blogas skaicius");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Ivestas blogas skaicius");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
            }

        }

        public static void AddStudentToDepartament()
        {

            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti departamento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Departaments.Include(a => a.Students).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi departamento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink departamento numeri prie kurio nori prideti studenta: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    var studentsNotInDepartment = db.Students
                    .Where(s => s.DepartamentId == null).ToList();


                    if (studentsNotInDepartment.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Galite prideti siuos studentus: ");
                        for (int i = 1; i <= studentsNotInDepartment.Count; i++)
                        {
                            Console.WriteLine($"{i}. {studentsNotInDepartment[i - 1].Name} {studentsNotInDepartment[i - 1].Surname}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nepriskirtu paskaitu nera.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                        return;
                    }

                    Console.Write("Ivesk studento numeri kuri nori prideti: ");
                    int indexStudent;
                    bool isIndexStudent = int.TryParse(Console.ReadLine(), out indexStudent);
                    if (isIndexStudent && indexStudent > 0 && indexStudent <= studentsNotInDepartment.Count)
                    {
                        objectFind[index - 1].Students.Add(studentsNotInDepartment[indexStudent - 1]);
                        db.SaveChanges();
                        Console.WriteLine($"Departamentui {objectFind[index - 1].Name} priskirtas studentas {studentsNotInDepartment[indexStudent - 1].Name} {studentsNotInDepartment[indexStudent - 1].Surname}");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ivestas blogas skaicius");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Ivestas blogas skaicius");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
            }

        }

        public static void RemoveStudentFromDepartament()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti departamento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Departaments.Include(a => a.Students).ThenInclude(l=>l.Lectures).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi departamento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink departamento numeri nuo kurio nori atsieti studenta: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {

                    if (objectFind[index - 1].Students.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Departamentas turi siuos studentus: ");
                        for (int i = 1; i <= objectFind[index - 1].Students.Count; i++)
                        {
                            Console.WriteLine($"{i}. {objectFind[index - 1].Students[i - 1].Name} {objectFind[index - 1].Students[i - 1].Surname}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Departamentas studentu neturi.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Ivesk studento numeri kuri nori pasalinti is departamento: ");
                    int indexStudent;
                    bool isIndexStudent = int.TryParse(Console.ReadLine(), out indexStudent);
                    if (isIndexStudent && indexStudent > 0 && indexStudent <= objectFind[index - 1].Students.Count)
                    {
                        objectFind[index - 1].Students[indexStudent - 1].Lectures = new List<Lecture>();
                        objectFind[index - 1].Students.Remove(objectFind[index - 1].Students[indexStudent - 1]);
                        db.SaveChanges();
                        Console.WriteLine($"Is departamento {objectFind[index - 1].Name} studentas pasalintas.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Ivestas blogas skaicius");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Ivestas blogas skaicius");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
            }

        }

        public static void StudentView()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti departamento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Departaments.Include(a => a.Students).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi departamento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink departamento numeri: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Departamentas: {objectFind[index-1].Name} ");

                    if (objectFind[index-1].Students.Any())
                    {
                        Console.WriteLine("Studentai:");
                        foreach (var student in objectFind[index-1].Students)
                        {
                            Console.WriteLine($"\t{student.Name} {student.Surname}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Studentu departamente nera");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
            }
        }

        public static void LectureView()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti departamento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Departaments.Include(a => a.Lectures).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi departamento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink departamento numeri: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Departamentas: {objectFind[index - 1].Name} ");

                    if (objectFind[index - 1].Lectures.Any())
                    {
                        Console.WriteLine("Paskaitos:");
                        foreach (var lecture in objectFind[index - 1].Lectures)
                        {
                            Console.WriteLine($"\t{lecture.Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Pskaitu departamentui nepriskirta.");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
            }
        }

        public static void ViewTree()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti departamento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Departaments.Include(a => a.Lectures).Include(s=>s.Students).ThenInclude(l=>l.Lectures).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi departamento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink departamento numeri: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Departamentas: {objectFind[index - 1].Name}.");

                    if (objectFind[index - 1].Lectures.Any())
                    {
                    
                        foreach (var lecture in objectFind[index - 1].Lectures)
                        {
                            Console.WriteLine($"\t\t\tPaskaita {lecture.Name}");
                            if (objectFind[index-1].Students.Any())
                            {
                                var studentInThisLecture = objectFind[index - 1].Students.Where(s => s.Lectures.Any(l => l.Name == lecture.Name)).ToList();
                                foreach (var student in studentInThisLecture)
                                {
                                    Console.WriteLine($"\t\t\t\t\t {student.Name} {student.Surname}");
                                }

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Pskaitu departamentui nepriskirta.");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
            }
        }
    }
}
