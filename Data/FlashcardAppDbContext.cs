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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    {
        string connectionString = "Server=tcp:de-server.database.windows.net,1433;Initial Catalog=FlashcardAppDb;Persist Security Info=False;User ID=de-server-admin;Password=ssL42VLE9e#Fw4Uz@V;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        optionsBuilder.UseSqlServer(connectionString);
    }
        

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
