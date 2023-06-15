using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Model;

public partial class WebSharpContext : DbContext
{
    #pragma warning disable
    public WebSharpContext()
    {
    }

    #pragma warning disable
    public WebSharpContext(DbContextOptions<WebSharpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }

    public virtual DbSet<TopicsXnews> TopicsXnews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning Trocar o Data Source e tambem o Initial Catalog
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0013K\\SQLEXPRESS01;Initial Catalog=WebSharp;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cities__3214EC0789D221E6");

            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdStateNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdState)
                .HasConstraintName("FK__Cities__IdState__29572725");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Countrie__3214EC079B178BC1");

            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3214EC07606F4DCB");

            entity.Property(e => e.Content).IsUnicode(false);
            entity.Property(e => e.Thumbnail).IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.News)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("FK__News__IdCity__2C3393D0");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__States__3214EC07952CF1C8");

            entity.Property(e => e.StateName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.States)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK__States__IdCountr__267ABA7A");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Topics__3214EC07AF0CA99C");

            entity.Property(e => e.TopicName)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TopicsXnews>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TopicsXN__3214EC072120BC06");

            entity.ToTable("TopicsXNews");

            entity.HasOne(d => d.IdNewsNavigation).WithMany(p => p.TopicsXnews)
                .HasForeignKey(d => d.IdNews)
                .HasConstraintName("FK__TopicsXNe__IdNew__31EC6D26");

            entity.HasOne(d => d.IdTopicNavigation).WithMany(p => p.TopicsXnews)
                .HasForeignKey(d => d.IdTopic)
                .HasConstraintName("FK__TopicsXNe__IdTop__30F848ED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
