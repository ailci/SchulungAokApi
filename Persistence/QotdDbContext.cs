using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Persistence;

public class QotdDbContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Quote> Quotes => Set<Quote>();

    public QotdDbContext(DbContextOptions<QotdDbContext> options) : base(options)
    {

    }
}