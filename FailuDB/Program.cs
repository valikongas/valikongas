using Microsoft.EntityFrameworkCore;

namespace FailuDB
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            string startFolder = @"C:\Program Files (x86)\Admirals Group MT4 Terminal";
            Folder katalogas = ScanCatalog(startFolder);
            using var dbContext = new FailuContext();
            bool folderExist = false;
            folderExist = KatalogoTikrinimas(katalogas, dbContext);
        
                WriteDataBaseFile(katalogas, dbContext);
         
        }

        public static Folder ScanCatalog(string path)
        {
            string[] files = Directory.GetFiles(path);
            var failusarasas = new List<Failai>();
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                var failas = new Failai();
                failas.Name = fileInfo.Name;
                failas.Size = fileInfo.Length;
                failas.Path = fileInfo.FullName;
                failusarasas.Add(failas);
            }
            var katalogas = new Folder();
            katalogas.Name = path;
            katalogas.Failais1 = failusarasas;
            return katalogas;
        }

        public static void WriteDataBaseFile(Folder katalogas, FailuContext dbContext)
        {
            var rastasKatalogas = dbContext.FailuFolders.Include(c => c.Failais1).FirstOrDefault(c => c.Name == katalogas.Name);
            if (rastasKatalogas != null)
            {
                foreach (var naujasFailas in katalogas.Failais1)
                {
                    var esamasFailas = rastasKatalogas.Failais1.FirstOrDefault(f => f.Name == naujasFailas.Name);
                    if (esamasFailas == null)
                    {
                        rastasKatalogas.Failais1.Add(naujasFailas);                 
                    }
                    else if (esamasFailas.Size != naujasFailas.Size)
                    {
                        esamasFailas.Size = naujasFailas.Size;    
                    }
                }
            }
            else
            {
                dbContext.FailuFolders.Add(katalogas);
            }
            dbContext.SaveChanges();
            string[] subDirectories = Directory.GetDirectories(katalogas.Name);
            foreach (string subDirectory in subDirectories)
            {
                var subKatalogas = ScanCatalog(subDirectory);
                WriteDataBaseFile(subKatalogas, dbContext); 
            }
            dbContext.SaveChanges();
        }

        public static bool KatalogoTikrinimas(Folder katalogas, FailuContext dbContext)
        {
            var rastasKatalogas = dbContext.FailuFolders.Include(c => c.Failais1).FirstOrDefault(c => c.Name == katalogas.Name);
            if (rastasKatalogas != null)
            {
                 FailuTikrinimas(rastasKatalogas, katalogas, dbContext);
            }
            else
            {
                return false;
            }
            return true;
        }

        public static void FailuTikrinimas(Folder rastasKatalogas, Folder katalogas, FailuContext dbContext)
        {
            {
                foreach (var naujasFailas in katalogas.Failais1)
                {
                        var esamasFailas = rastasKatalogas.Failais1.FirstOrDefault(f => f.Name == naujasFailas.Name);
                    if (esamasFailas == null)
                    {
                        rastasKatalogas.Failais1.Add(naujasFailas);
                    }
                    else
                    {
                        if (esamasFailas.Size != naujasFailas.Size)
                        {
                            esamasFailas.Size = naujasFailas.Size;
                        }
                    }
                }
                dbContext.SaveChanges();
            }
        }
    }
}
