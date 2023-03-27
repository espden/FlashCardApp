using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Data;

public partial class FlashcardAppDbContext : DbContext
{
    public FlashcardAppDbContext()
    {
    }

    public FlashcardAppDbContext(DbContextOptions<FlashcardAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Card> Cards { get; set; }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Card__3214EC0780DDBD38");

            entity.ToTable("Card");

            entity.Property(e => e.Answer)
                .HasMaxLength(2048)
                .IsUnicode(false);
            entity.Property(e => e.Question)
                .HasMaxLength(2048)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
