using DatabaseTestWPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestWPF.DataAccess
{
    public class DataAccessor : DbContext
    {
        /// <summary>
        /// C'est ici que l'on vient déclarer les tables qu'on veut voir apparaitre dans la DB
        /// </summary>
        public DbSet<PersonModel> People { get; set; }

        /// <summary>
        /// Précision sur la DB à utiliser
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Application.sensy");
    }
}
