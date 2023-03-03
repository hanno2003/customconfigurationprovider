using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomConfigurationProvider;

public partial class TestConfigurationProviderContext : DbContext, IDisposable
{
    public TestConfigurationProviderContext()
    {
    }

    public TestConfigurationProviderContext(DbContextOptions<TestConfigurationProviderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TestConfig> TestConfigs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TestConfigurationProvider;User Id=sa;Password=MyPass@word; Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestConfig>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Label });

            entity.ToTable("TestConfig");

            entity.Property(e => e.Key)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("key");
            entity.Property(e => e.Label)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("label");
            entity.Property(e => e.Value)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("value");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
