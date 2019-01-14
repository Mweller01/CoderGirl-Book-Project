using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoderGirl_Book_Project.Models
{
    public partial class BooksContext : DbContext
    {
        public BooksContext()
        {
        }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
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
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

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
    }
}
