

using Microsoft.EntityFrameworkCore;

namespace DB_baigiamasis
{
    public class LectureOperation
    {

        public static void CreateNewLecture()
        {

            var newObject = new Lecture();
            Console.Clear();
            Console.Write("Ivesk paskaitos pavadinima: ");
            newObject.Name = Console.ReadLine();
            using (var db = new Database())
            {
                db.Lectures.Add(newObject);
                db.SaveChanges();
                Console.WriteLine($"Paskaita {newObject.Name} prideta.");
                Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                Console.ReadKey();
            }
        }

        public static void CorrectionLectureName()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti paskaitos: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Lectures.Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi paskaitos nera.");
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
                    Console.WriteLine($"paskaitos pavadinimas pakeistas i {objectFind[index - 1].Name}.");
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

        public static void RemoveLecture()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti paskaitos: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Lectures.Include(a => a.Students).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi paskaitos nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Pasirink paskaitos numeri kuri nori istrinti: ");
                int index;
                string newName = "";
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    objectFind[index - 1].Students.Clear();
                    db.Lectures.Remove(objectFind[index - 1]);
                    db.SaveChanges();
                    Console.WriteLine($"Paskaita {objectFind[index - 1].Name} istrinta");
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
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti paskaitos: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Lectures.Include(a => a.Departaments).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi paskaitos nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink paskaitos numeri kuria noresi prideti prie departamento: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    var departamentsNotInLectures = db.Departaments
                 .Where(l => !db.Lectures
                 .Where(d => d.Name == objectFind[index - 1].Name)
                 .SelectMany(d => d.Departaments)
                 .Any(dl => dl.Id == l.Id))
                 .ToList();

                    if (departamentsNotInLectures.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Galite priskirti prie siu departamentu: ");
                        for (int i = 1; i <= departamentsNotInLectures.Count; i++)
                        {
                            Console.WriteLine($"{i}. {departamentsNotInLectures[i - 1].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Paskaita priskirta prie visu departamentu.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Ivesk departamento numeri prie kurio nori prideti: ");
                    int indexDepartament;
                    bool isIndexDepartament = int.TryParse(Console.ReadLine(), out indexDepartament);
                    if (isIndexDepartament && indexDepartament > 0 && indexDepartament <= departamentsNotInLectures.Count)
                    {
                        objectFind[index - 1].Departaments.Add(departamentsNotInLectures[indexDepartament - 1]);
                        db.SaveChanges();
                        Console.WriteLine($"Paskaita {objectFind[index - 1].Name} prideta prie departamento {departamentsNotInLectures[indexDepartament - 1].Name}");
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
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti paskaitos: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Lectures.Include(a => a.Departaments).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi paskaitos nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink paskaitos numeri  kuria nori atsieti nuo departamento: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {

                    if (objectFind[index - 1].Departaments.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Departamentas turi sias paskaitas: ");
                        for (int i = 1; i <= objectFind[index - 1].Departaments.Count; i++)
                        {
                            Console.WriteLine($"{i}. {objectFind[index - 1].Departaments[i - 1].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Paskaita nepriskirta nei vienam departamentui.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Ivesk departamento numeri nuo kurio nori atsieti paskaita: ");
                    int indexDepartament;
                    bool isIndexDepartament = int.TryParse(Console.ReadLine(), out indexDepartament);
                    if (isIndexDepartament && indexDepartament > 0 && indexDepartament <= objectFind[index - 1].Departaments.Count)
                    {
                        objectFind[index - 1].Departaments.Remove(objectFind[index - 1].Departaments[indexDepartament - 1]);
                        db.SaveChanges();
                        Console.WriteLine($"Paskaita {objectFind[index - 1].Name} atsieta nuo departamento");
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

        public static void AddStudentToLecture()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti paskaitos: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Lectures.Include(a => a.Students).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi paskaitos nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink paskaitos numeri prie kurios noresi prideti studenta: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    var studentNotInLectures = db.Students
                .Where(s => !db.Lectures
                .Where(l => l.Name == objectFind[index - 1].Name)
                .SelectMany(l => l.Students)
                .Any(ls => ls.Id == s.Id))
                .Where(s => db.Departaments
                .Where(d => d.Lectures.Any(l => l.Name == objectFind[index - 1].Name))
                .Any(d => d.Students.Any(ds => ds.Id == s.Id)))
                .ToList();

                    if (studentNotInLectures.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Galite prideti siuos studentus: ");
                        for (int i = 1; i <= studentNotInLectures.Count; i++)
                        {
                            Console.WriteLine($"{i}. {studentNotInLectures[i - 1].Name} {studentNotInLectures[i - 1].Surname}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Prie paskaitos nepriskirtu studentu nera.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Ivesk studento numeri kuri nori prideti: ");
                    int indexStudent;
                    bool isIndexDepartament = int.TryParse(Console.ReadLine(), out indexStudent);
                    if (isIndexDepartament && indexStudent > 0 && indexStudent <= studentNotInLectures.Count)
                    {
                        objectFind[index - 1].Students.Add(studentNotInLectures[indexStudent - 1]);
                        db.SaveChanges();
                        Console.WriteLine($"Studentas {studentNotInLectures[indexStudent - 1].Name} {studentNotInLectures[indexStudent - 1].Surname}  pridetas prie paskaitos {objectFind[index - 1].Name}");
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

        public static void RemoveStudentFromLecture()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti paskaitos: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Lectures.Include(a => a.Students).Where(d => d.Name.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi paskaitos nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink paskaitos numeri  prie kurios nori prideti studenta: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {

                    if (objectFind[index - 1].Students.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Prie paskaitos priskirti sie studentai: ");
                        for (int i = 1; i <= objectFind[index - 1].Students.Count; i++)
                        {
                            Console.WriteLine($"{i}. {objectFind[index - 1].Students[i - 1].Name} {objectFind[index - 1].Students[i - 1].Surname}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Prie paskaitos nepriskirtas nei vienas studentas.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Studento numeri, kuri nori atsieti nuo paskaitos: ");
                    int indexStudent;
                    bool isIndexDepartament = int.TryParse(Console.ReadLine(), out indexStudent);
                    if (isIndexDepartament && indexStudent > 0 && indexStudent <= objectFind[index - 1].Students.Count)
                    {
                        objectFind[index - 1].Students.Remove(objectFind[index - 1].Students[indexStudent - 1]);
                        db.SaveChanges();
                        Console.WriteLine($"Nuo paskaitos {objectFind[index - 1].Name} studentas atsietas.");
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
    }

}

