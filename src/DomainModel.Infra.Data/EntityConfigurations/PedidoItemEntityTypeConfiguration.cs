using DomainModel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainModel.Infra.Data.EntityConfigurations
{
    public class PedidoItemEntityTypeConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("orderItems");

            builder.HasKey(o => o.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(o => o.Id)
                .UseHiLo("pedidoitemseq");

            builder.Property<int>("PedidoId")
                .IsRequired();

            builder
            .Property<decimal>("Desconto")
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("Desconto")
            .IsRequired();

            builder.Property<int>("ProdutoId")
                .IsRequired();

            builder
                .Property<string>("Produto")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Produto")
                .IsRequired();

            builder
                .Property<decimal>("PrecoUnitario")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("PrecoUnitario")
                .IsRequired();

            builder
                .Property<int>("Quantidade")
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                .HasColumnName("Quantidade")
                .IsRequired();
        }
    }
}
