using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_EFCore_CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_EFCore_CodeFirst.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.Property(p => p.ID)
                .ValueGeneratedNever(); //nunca gerar automaticamente

            builder.Property(p => p.Titulo)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(p => p.Autor)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(p => p.Preco)
                .HasColumnType("numeric(38,2)");

            builder.Property(p => p.DataEntrada)
                .HasColumnType("datetime");

            builder.HasIndex(p => p.Titulo)
                .HasDatabaseName("IX_Livro_Titulo");

            builder.HasOne(p => p.Categoria)
                .WithMany(p => p.Livros)
                .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(p => p.Categoria)
            //    .WithMany()
            //    .HasForeignKey(p => p.CategoriaID);

            //Populando Tabelas
            builder.HasData(
                new Livro(1, 1, "O Silêncio dos Inocentes", "Tomas Harris", 10, 40.20m),
                new Livro(2, 1, "Clean Code", "Robert Cecil Martin", 15, 78.10m),
                new Livro(3, 1, "Refatoração: Aperfeiçoando o Projeto de Código Existente", "Kent Beck e Martin Fowler", 10, 40.20m)
                );



        }
    }
}
