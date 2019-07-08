using TesteSuperoCS.DAO.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace TesteSuperoCS.DAO
{
    public class SuperoDbContext : DbContext
    {
        public SuperoDbContext(DbContextOptions options)
      : base(options)
        {
            Database.EnsureCreated();
        }

     
        protected SuperoDbContext()
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
        
    }
}