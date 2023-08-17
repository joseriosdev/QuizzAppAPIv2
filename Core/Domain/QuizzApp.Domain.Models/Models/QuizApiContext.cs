using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace QuizzApp.Server.Models;

public partial class QuizApiContext : DbContext
{
    public QuizApiContext()
    {
    }

    public QuizApiContext(DbContextOptions<QuizApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriesQuize> CategoriesQuizes { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<FillInBlankQuestion> FillInBlankQuestions { get; set; }

    public virtual DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quize> Quizes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    private IConfiguration configuration;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(QuizApiContext).Assembly);

        modelBuilder.Entity<CategoriesQuize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CATEGORI__3213E83F6A0EC5E1");

            entity.ToTable("CATEGORIES_QUIZES");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");

            entity.HasOne(d => d.Category).WithMany(p => p.CategoriesQuizes)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__CATEGORIE__categ__300424B4");

            entity.HasOne(d => d.Quiz).WithMany(p => p.CategoriesQuizes)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK__CATEGORIE__quiz___30F848ED");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CATEGORI__3213E83FB10EF8B5");

            entity.ToTable("CATEGORIES");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<FillInBlankQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FILL_IN___3213E83F13452C54");

            entity.ToTable("FILL_IN_BLANK_QUESTIONS");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.WordPosition).HasColumnName("word_position");

            entity.HasOne(d => d.Question).WithMany(p => p.FillInBlankQuestions)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__FILL_IN_B__quest__35BCFE0A");
        });

        modelBuilder.Entity<MultipleChoiceQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MULTIPLE__3213E83F0DC3EBE1");

            entity.ToTable("MULTIPLE_CHOICE_QUESTIONS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.Value1)
                .HasMaxLength(255)
                .HasColumnName("value_1");
            entity.Property(e => e.Value2)
                .HasMaxLength(255)
                .HasColumnName("value_2");
            entity.Property(e => e.Value3)
                .HasMaxLength(255)
                .HasColumnName("value_3");
            entity.Property(e => e.Value4)
                .HasMaxLength(255)
                .HasColumnName("value_4");

            entity.HasOne(d => d.Question).WithMany(p => p.MultipleChoiceQuestions)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__MULTIPLE___quest__36B12243");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QUESTION__3213E83F50F4D0B8");

            entity.ToTable("QUESTIONS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CorrectAnswer)
                .HasMaxLength(255)
                .HasColumnName("correct_answer");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .HasConstraintName("FK__QUESTIONS__quiz___34C8D9D1");
        });

        modelBuilder.Entity<Quize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__QUIZES__3213E83F3CEF75F7");

            entity.ToTable("QUIZES");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.LatestScore).HasColumnName("latest_score");
            entity.Property(e => e.LatestScoreBy).HasColumnName("latest_score_by");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.PossibleScore).HasColumnName("possible_score");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.QuizeCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__QUIZES__created___31EC6D26");

            entity.HasOne(d => d.LatestScoreByNavigation).WithMany(p => p.QuizeLatestScoreByNavigations)
                .HasForeignKey(d => d.LatestScoreBy)
                .HasConstraintName("FK__QUIZES__latest_s__33D4B598");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.QuizeUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK__QUIZES__updated___32E0915F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USERS__3213E83F2298CAFF");

            entity.ToTable("USERS");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.IsActive).HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
