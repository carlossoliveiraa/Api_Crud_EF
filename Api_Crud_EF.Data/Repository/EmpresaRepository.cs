using Api_Crud_EF.Application.Domain;
using Api_Crud_EF.Application.Interfaces;
using Api_Crud_EF.Data.Context;

namespace Api_Crud_EF.Data.Repository
{

    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(MeuDbContext context) : base(context)
        {
        }               
    }
}
