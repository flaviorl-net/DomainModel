using DomainModel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Infra.Data.EntityConfigurations
{
    public class PedidoEntityTypeConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(o => o.Id);

            builder.Ignore(b => b.DomainEvents);

            builder
                .OwnsOne(o => o.Endereco, a =>
                {
                    // Explicit configuration of the shadow key property in the owned type 
                    // as a workaround for a documented issue in EF Core 5: https://github.com/dotnet/efcore/issues/20740
                    a.Property<int>("PedidoId")
                    .UseHiLo("pedidoseq");
                    a.WithOwner();
                });

            builder
                .Property<DateTime>("Data")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Data")
                .IsRequired();

            builder.Property<string>("Descricao").IsRequired(false);
        }
    }
}
