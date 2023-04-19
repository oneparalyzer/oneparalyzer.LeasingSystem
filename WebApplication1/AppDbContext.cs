﻿using Microsoft.EntityFrameworkCore;

namespace WebApplication1;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Class> Classes  { get; set; }
}
