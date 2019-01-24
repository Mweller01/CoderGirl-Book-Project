using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CoderGirl_Book_Project.Models;
using CoderGirl_Book_Project.ViewModels;

namespace CoderGirl_Book_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<BookAuthor> BookAuthor { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BooksCategory> BooksCategory { get; set; }
        public virtual DbSet<BooksRating> BooksRating { get; set; }
        public virtual DbSet<BooksTags> BooksTags { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Ratings> Ratings { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");
             
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasIndex(e => e.Author1)
                    .HasName("AK_Author_Column")
                    .IsUnique();

                entity.Property(e => e.Author1)
                    .IsRequired()
                    .HasColumnName("Author")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.AuthorId })
                    .HasName("Book_Author_pk");

                entity.ToTable("Book_Author");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.BookAuthor)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Author");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthor)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book");
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.Property(e => e.Cover).HasColumnType("image");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BooksCategory>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.CategoryId })
                    .HasName("PK__Books_Ca__34F8CB6279506F07");

                entity.ToTable("Books_Category");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BooksCategory)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Books_Cat__Book___55BFB948");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BooksCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Books_Cat__Categ__6F7F8B4B");
            });

            modelBuilder.Entity<BooksRating>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.RatingId })
                    .HasName("Book_Rating_pk");

                entity.ToTable("Books_Rating");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.RatingId).HasColumnName("Rating_Id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BooksRating)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Books_Rat__Book___2116E6DF");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.BooksRating)
                    .HasForeignKey(d => d.RatingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Books_Rat__Ratin__220B0B18");
            });

            modelBuilder.Entity<BooksTags>(entity =>
            {
                entity.HasKey(e => new { e.BookId, e.TagId })
                    .HasName("PK__Books_Ta__EF29367506627FBC");

                entity.ToTable("Books_Tags");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.TagId).HasColumnName("Tag_Id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BooksTags)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Books_Tag__Book___56B3DD81");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.BooksTags)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Books_Tag__Tag_I__7073AF84");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasIndex(e => e.Category)
                    .HasName("AK_Category_Column")
                    .IsUnique();

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ratings>(entity =>
            {
                entity.HasIndex(e => e.Rating)
                    .HasName("AK_Ratings_Column")
                    .IsUnique();

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.HasIndex(e => e.Tag)
                    .HasName("AK_Tag_Column")
                    .IsUnique();

                entity.Property(e => e.Tag)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }


        public DbSet<CoderGirl_Book_Project.ViewModels.NewBook> NewBook { get; set; }

        /* I think this is important but I don't know how.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        */
    }
}
