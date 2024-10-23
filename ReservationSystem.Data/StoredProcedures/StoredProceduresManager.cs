using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace ReservationSystem.Data.StoredProcedures
{
    public class StoredProceduresManager:IStoredProceduresManager
    {
        private ReservationSystemContext _context;
        private string spDirectory;
        public StoredProceduresManager(ReservationSystemContext context)
        {
            _context = context;
            spDirectory = Path.GetDirectoryName(Environment.CurrentDirectory)
                + "\\ReservationSystem.Data\\StoredProcedures\\SQL\\";
            //cargar sql desde directorio
        }
        public void CreateProcedures()
        {
            Create("UpdateRanking");
        }
        private void Create(string spName)
        {
            string sqlPath= $"{spDirectory}{spName}.sql";
            if (File.Exists(sqlPath))
            {
                try
                {
                    string sql = File.ReadAllText(sqlPath);
                    string[] batches = sql.Split("\nGO");
                    foreach (string batch in batches)
                    {
                        if(!string.IsNullOrEmpty(batch))
                            _context.Database.ExecuteSqlRaw(batch);
                    }
                }
                catch (Exception)
                {
                    throw new FileLoadException("Error with database procedures. Contact your admin.");
                }
            }
        }
    }
}
