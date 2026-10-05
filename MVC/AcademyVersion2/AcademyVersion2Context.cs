using Microsoft.EntityFrameworkCore;

public class AcademyVersion2Context(DbContextOptions<AcademyVersion2Context> options) : DbContext(options)
{
    public DbSet<AcademyVersion2.Models.Direction> Directions { get; set; } = default!;
    public DbSet<AcademyVersion2.Models.Discipline> Disciplines { get; set; } = default!;
    public DbSet<AcademyVersion2.Models.Group> Groups { get; set; } = default!;
    public DbSet<AcademyVersion2.Models.Student> Students { get; set; } = default!;
    public DbSet<AcademyVersion2.Models.Teacher> Teachers { get; set; } = default!;
}
