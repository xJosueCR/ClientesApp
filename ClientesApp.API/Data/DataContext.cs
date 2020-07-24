using ClientesApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoCivil> EstadosCiviles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelbuilder){
            //identificacion en Cliente unique
            modelbuilder.Entity<Cliente>()
                .HasIndex(cliente => cliente.Identificacion).IsUnique();
        }
        
        

    }
}