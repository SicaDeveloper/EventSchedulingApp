using HorizonCalender.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace HorizonCalender.Data;

public class HorizonCalenderDbContext(DbContextOptions<HorizonCalenderDbContext> options)
    : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    
}