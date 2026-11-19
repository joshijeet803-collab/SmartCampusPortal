using Microsoft.EntityFrameworkCore; using SmartCampusPortal.Models;
namespace SmartCampusPortal.Data;
public class CampusDb(DbContextOptions<CampusDb> options):DbContext(options) { public DbSet<Student> Students=>Set<Student>(); public DbSet<ServiceRequest> Requests=>Set<ServiceRequest>(); }