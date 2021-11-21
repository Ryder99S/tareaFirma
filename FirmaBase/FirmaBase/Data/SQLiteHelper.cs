using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using FirmaBase.Models;
using System.Threading.Tasks;

namespace FirmaBase.Data
{
   public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Persona>().Wait();
        }

        public Task<int> SavePersona(Persona person)
        {
            if (person.Idpersona != 0)
            {
                return db.UpdateAsync(person);
                
            }
            else
            {
                return db.InsertAsync(person);
            }
        }
        /// <summary>
        /// Recuperar todos los personas
        /// </summary>
        /// <returns></returns>
        public Task<List<Persona>> GetPersonasAync()
        {
            return db.Table<Persona>().ToListAsync();
        }

    }
}
