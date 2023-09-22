using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Api_Crud_EF.Application.Domain;

namespace Api_Crud_EF.Data.Mappings
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(p => p.Id);                   
             
            // 1 : N => Empresa : Enderecos
            builder.HasMany(f => f.Enderecos);

            builder.ToTable("Empresas");
        }
    }
}
