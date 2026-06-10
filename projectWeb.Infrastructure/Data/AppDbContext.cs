

using Microsoft.EntityFrameworkCore;
using projectWeb.Domain.Entities;
using Task = projectWeb.Domain.Entities.Task;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    // declaro las tablas 
    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    
    
    //se diseñ el plano de la db 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // se configura las tablas 

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Name).IsRequired();
            entity.Property(u => u.Email).IsRequired();


        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Title).IsRequired();
            entity.Property(t => t.Description).IsRequired();
            entity.Property(t => t.Status).IsRequired();



            // hacemos relacion entre las tablas. 1 usuario tiene muchs tareas =>
            entity.HasOne(t => t.User) //  una tarea tiene un usuario 
                .WithMany(u => u.Tasks) // un usario tiene muchas tareas 
                .HasForeignKey(t =>t.UserId) // la columna que los une mysql userId
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}