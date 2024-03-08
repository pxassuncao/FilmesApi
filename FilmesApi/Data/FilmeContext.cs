using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class FilmeContext : DbContext
{
    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema>Cinemas { get; set; }
    public DbSet<Endereco>Enderecos { get; set; }
    public FilmeContext(DbContextOptions<FilmeContext> options)
       : base(options)
    {
        
        
}
    protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlServer("Server=localhost;Database=Filmes;User Id=sa;Password=@Sql2022;MultipleActiveResultSets=true;Encrypt=YES;TrustServerCertificate=YES");




   

}
