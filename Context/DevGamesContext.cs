using DevGamesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevGamesAPI.Context
{
    public class DevGamesContext : DbContext
    {
        public DevGamesContext(DbContextOptions<DevGamesContext> options) : base(options)
        {
            
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //primeiramente ja definindo as chave estrangeira (de cada classe ja para nao esquecer)
            modelBuilder.Entity<Board>()
                .HasKey(o => o.Id);

            //relacionamento
            modelBuilder.Entity<Board>()
                .HasMany(o => o.Posts)
                .WithOne()
                .HasForeignKey(o => o.BoardId);

            modelBuilder.Entity<Post>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Post>()
                .HasMany(o => o.Comentarios)
                .WithOne()
                .HasForeignKey(o => o.PostId);

            modelBuilder.Entity<Comentario>()
                .HasKey(o => o.Id);

        }
        
    }
}
