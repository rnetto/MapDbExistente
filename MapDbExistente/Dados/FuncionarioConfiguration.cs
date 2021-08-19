using MapDbExistente.Negocio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MapDbExistente.Dados
{
    public class FuncionarioConfiguration : PessoaConfiguration<Funcionario>
    {
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            base.Configure(builder);

            builder.ToTable("staff");

            builder.Property(f => f.Id)
                .HasColumnName("staff_id");

            builder.Property(f => f.UserName)
                .HasColumnName("username")
                .HasColumnType("varchar(16)")
                .IsRequired();

            builder.Property(f => f.Password)
                .HasColumnName("password")
                .HasColumnType("varchar(40)");
        }
    }
}