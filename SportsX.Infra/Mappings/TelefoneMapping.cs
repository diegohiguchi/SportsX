using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SportsX.Domain.Entities;

namespace SportsX.Infra.Mappings
{
    public class TelefoneMapping : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Numero)
                .IsRequired();

            builder.HasOne(f => f.PessoaFisica)
                .WithMany(p => p.Telefones)
                .HasForeignKey(x => x.PessoaFisicaId);

            builder.HasOne(f => f.PessoaJuridica)
                .WithMany(p => p.Telefones)
                .HasForeignKey(x => x.PessoaJuridicaId);

            builder.ToTable("Telefone");
        }
    }
}
