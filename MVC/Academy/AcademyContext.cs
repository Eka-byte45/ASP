using Academy.Models;
using Microsoft.EntityFrameworkCore;

public class AcademyContext(DbContextOptions<AcademyContext> options) : DbContext(options)
{
    public DbSet<Direction> Directions { get; set; } = default!;
    public DbSet<Group> Groups { get; set; } = default!;
    public DbSet<Discipline> Disciplines { get; set; } = default!;
    public DbSet<Student> Students { get; set; } = default!;
    public DbSet<Teacher> Teachers { get; set; } = default!;
}
