

using Azure.Core.GeoJson;
using Microsoft.EntityFrameworkCore;

namespace DB_baigiamasis
{
    public class StudentOperation
    {
        public static void CreateNewStudent()
        {

            var newObject = new Student();
            Console.Clear();
            Console.Write("Ivesk studento varda: ");
            newObject.Name = Console.ReadLine();
            Console.Write("Ivesk studento pavarde: ");
            newObject.Surname = Console.ReadLine();
            DateTime dateTime;
            bool isDateTime = false;
            do
            {
                Console.Write("Ivesk studento gimimo data: ");
                isDateTime = DateTime.TryParse(Console.ReadLine(), out dateTime);
                if (!isDateTime)
                {
                    Console.WriteLine("Blogai ivedei data, ivesk is naujo.");
                }
            }
            while (!isDateTime);
            newObject.Birdday = dateTime;

            using (var db = new Database())
            {
                db.Students.Add(newObject);
                db.SaveChanges();
                Console.WriteLine($"Studentas {newObject.Name} {newObject.Surname} pridetas.");
                Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                Console.ReadKey();
            }
        }

        public static void CorrectionStudentData()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti studento (vardo arba pavardes): ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Students.Where(d => d.Name.Contains(searchName) || d.Surname.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name} {objectFind[i - 1].Surname}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi studento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }

                Console.Write("Pasirink studento numeri kurio duomenis nori koreguoti: ");
                int index;
                string newName = "";
                string newSurname = "";
                DateTime newBirdday = default;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    Console.WriteLine("Ivesk varda, jei nori ji koreguoti, jei ne spausk ENTER: ");
                    newName = Console.ReadLine();
                    Console.WriteLine("Ivesk pavarde, jei nori ja koreguoti, jei ne spausk ENTER: ");
                    newSurname = Console.ReadLine();
                    Console.WriteLine("Ivesk gimimo data, jei nori ja koreguoti, jei ne spausk ENTER: ");
                    bool isDateTime = DateTime.TryParse(Console.ReadLine(), out newBirdday);
                    if (!isDateTime)
                    {
                        newBirdday = default;
                        Console.WriteLine("Blogai ivedei data.");
                    }
                    if (newName != "" || newSurname != "" || newBirdday != default)
                    {
                        if (newName != "")
                        {
                            objectFind[index - 1].Name = newName;
                        }
                        if (newSurname != "")
                        {
                            objectFind[index - 1].Surname = newSurname;
                        }
                        if (newBirdday != default)
                        {
                            objectFind[index - 1].Birdday = newBirdday;
                        }
                        db.SaveChanges();
                        Console.WriteLine($"Studento {objectFind[index - 1].Name} {objectFind[index - 1].Surname} duomenys pakeisti .");
                    }
                    else
                    {
                        Console.WriteLine("Nieko nepakeitei.");
                    }
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

        public static void RemoveStudent()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti studento (vardo arba pavardes): ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Students.Where(d => d.Name.Contains(searchName) || d.Surname.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name} {objectFind[i - 1].Surname}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi studentu nerasta.");
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
                    db.Students.Remove(objectFind[index - 1]);
                    db.SaveChanges();
                    Console.WriteLine($"Studentas {objectFind[index - 1].Name} {objectFind[index - 1].Surname} panaikintas."); ;
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

        public static void AddStudentToDepartament()
        {

            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti studento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Students.Where(d => (d.Name.Contains(searchName) || d.Surname.Contains(searchName)) && d.DepartamentId == null).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name} {objectFind[i - 1].Surname}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi nepriskirtu departamentams studentu nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink studento numeri kuri nori prie departamento: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    var allDepartament = db.Departaments.ToList();
                    if (allDepartament.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Galite studenta prideti prie siu departamentu: ");
                        for (int i = 1; i <= allDepartament.Count; i++)
                        {
                            Console.WriteLine($"{i}. {allDepartament[i - 1].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Departamentu nera sukurta.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                        return;
                    }

                    Console.Write("Ivesk departamento numeri kuri nori prideti: ");
                    int indexDepartament;
                    bool isIndexDepartament = int.TryParse(Console.ReadLine(), out indexDepartament);
                    if (isIndexDepartament && indexDepartament > 0 && indexDepartament <= allDepartament.Count)
                    {

                        allDepartament[indexDepartament - 1].Students.Add(objectFind[index - 1]);
                        db.SaveChanges();
                        Console.WriteLine($"Departamentui {allDepartament[indexDepartament - 1].Name} priskirtas studentas {objectFind[index - 1].Name} {objectFind[index - 1].Surname}");
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

        public static void ChangeStudentDepartament()
        {

            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti studento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Students.Include(l => l.Lectures).Include(d => d.Departament).ThenInclude(b => b.Lectures).Where(d => (d.Name.Contains(searchName) || d.Surname.Contains(searchName)) && d.DepartamentId != null).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name} {objectFind[i - 1].Surname}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi studentu nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink studento numeri kurio departamenta nori pakeisti: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    var allDepartament = db.Departaments.Include(l => l.Lectures).Where(d => d.Id != objectFind[index - 1].DepartamentId).ToList();
                    if (allDepartament.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Galite studenta prideti prie siu departamentu: ");
                        for (int i = 1; i <= allDepartament.Count; i++)
                        {
                            Console.WriteLine($"{i}. {allDepartament[i - 1].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Departamentu nera sukurta arba yra tik vienas departamentas.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                        return;
                    }
                    // kazkas neveikia. Istrina visas paskaitas
                    Console.Write("Ivesk departamento numeri i kuri nori pervesti studenta: ");
                    int indexDepartament;
                    bool isIndexDepartament = int.TryParse(Console.ReadLine(), out indexDepartament);
                    if (isIndexDepartament && indexDepartament > 0 && indexDepartament <= allDepartament.Count)
                    {
                        objectFind[index - 1].DepartamentId = null;
                        var oldLectures = objectFind[index - 1].Lectures.ToList();
                        foreach (var oldLecture in oldLectures)
                        {
                            if (allDepartament[indexDepartament - 1].Lectures.All(l => l.Id != oldLecture.Id))
                            {
                                objectFind[index - 1].Lectures.Remove(oldLecture);
                            }
                        }
                        allDepartament[indexDepartament - 1].Students.Add(objectFind[index - 1]);

                        db.SaveChanges();
                        Console.WriteLine($"Departamentui {allDepartament[indexDepartament - 1].Name} priskirtas studentas {objectFind[index - 1].Name} {objectFind[index - 1].Surname}");
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
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti studento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Students.Include(l => l.Lectures).Where(d => (d.Name.Contains(searchName) || d.Surname.Contains(searchName)) && d.DepartamentId != null).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name} {objectFind[i - 1].Surname}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi studentu nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink studento numeri kuri nori atsieti nuo departamento: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    objectFind[index - 1].Lectures = new List<Lecture>();
                    objectFind[index - 1].DepartamentId = null;
                    db.SaveChanges();
                    Console.WriteLine($"studentas {objectFind[index - 1].Name} {objectFind[index - 1].Surname} pasalintas is departamento");
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

        public static void AddStudentToLecture()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti studento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Students.Include(a => a.Lectures).Where(d => d.Name.Contains(searchName) || d.Surname.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name} {objectFind[i - 1].Surname}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi studento  nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink studenta kuri prie paskaitu nori prideti: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    var availableLectures = db.Lectures
                    .Where(l => l.Departaments.Any(d => d.Students.Any(s => s.Id == objectFind[index - 1].Id)))
                    .Where(l => !l.Students.Any(s => s.Id == objectFind[index - 1].Id))
                    .ToList();

                    if (availableLectures.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Galite studenta prideti prie siu paskaitu: ");
                        for (int i = 1; i <= availableLectures.Count; i++)
                        {
                            Console.WriteLine($"{i}. {availableLectures[i - 1].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Studentui priskirtos visos galimos paskaitos arba studentas nepriskirtas prie departamento.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Ivesk paskaitos numeri prie kurios nori prideti: ");
                    int indexLecture;
                    bool isIndexDepartament = int.TryParse(Console.ReadLine(), out indexLecture);
                    if (isIndexDepartament && indexLecture > 0 && indexLecture <= availableLectures.Count)
                    {
                        availableLectures[indexLecture - 1].Students.Add(objectFind[index - 1]);
                        db.SaveChanges();
                        Console.WriteLine($"Studentas {objectFind[index - 1].Name} {objectFind[index - 1].Surname}  pridetas prie paskaitos {availableLectures[indexLecture - 1].Name}");
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
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti studento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Students.Include(a => a.Lectures).Where(d => d.Name.Contains(searchName) || d.Surname.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name} {objectFind[i - 1].Surname} ");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi studento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink studento numeri  kuri nori  atsieti nuo paskaitos: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    if (objectFind[index - 1].Lectures.Any())
                    {
                        Console.Clear();
                        Console.WriteLine("Studenta atsieti galime nuo siu paskaitu: ");
                        for (int i = 1; i <= objectFind[index - 1].Lectures.Count; i++)
                        {
                            Console.WriteLine($"{i}. {objectFind[index - 1].Lectures[i - 1].Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Studentas neturi paskaitu.");
                        Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                        Console.ReadKey();
                        return;
                    }
                    Console.Write("Pasirink paskaitos numeri: ");
                    int indexLecture;
                    bool isIndexLecture = int.TryParse(Console.ReadLine(), out indexLecture);
                    if (isIndexLecture && indexLecture > 0 && indexLecture <= objectFind[index - 1].Lectures.Count)
                    {
                        objectFind[index - 1].Lectures.Remove(objectFind[index - 1].Lectures[indexLecture - 1]);
                        db.SaveChanges();
                        Console.WriteLine($"Studentui {objectFind[index - 1].Name} {objectFind[index - 1].Surname} pasalinta paskaita.");
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

        public static void LectureByStudentView()
        {
            Console.Clear();
            Console.Write("Pagal koki raktini zodi, ar zodzio dali ieskoti studento: ");
            string searchName = Console.ReadLine();
            using (var db = new Database())
            {
                var objectFind = db.Students.Include(a => a.Lectures).Where(d => d.Name.Contains(searchName) || d.Surname.Contains(searchName)).ToList();

                if (objectFind.Any())
                {
                    for (int i = 1; i <= objectFind.Count; i++)
                    {
                        Console.WriteLine($"{i}. {objectFind[i - 1].Name} {objectFind[i - 1].Surname}");
                    }
                }
                else
                {
                    Console.WriteLine("Pagal toki raktini zodi studento nera.");
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                    return;
                }
                Console.Write("Pasirink studento numeri: ");
                int index;
                bool isIndex = int.TryParse(Console.ReadLine(), out index);
                if (isIndex && index > 0 && index <= objectFind.Count)
                {
                    Console.Clear();
                    Console.WriteLine($"Studentas {objectFind[index - 1].Name} {objectFind[index - 1].Surname}.");

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
                        Console.WriteLine("Paskaitu studentas neturi.");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Spausk bet koki mygtuka ir grizk i meniu.");
                    Console.ReadKey();
                }
            }
        }
    }
}
