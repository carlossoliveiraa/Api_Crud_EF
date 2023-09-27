using Api_Crud_EF.Application.Domain;
using Api_Crud_EF.Application.Interfaces;
using Api_Crud_EF.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api_Crud_EF.Data.Repository
{

    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(MeuDbContext context) : base(context)
        {

        }

        public async Task<Empresa> ObterEmpresaComEndereco(int empresaId)
        {
            return await Db.Empresas.AsNoTracking()
                   .Include(c => c.Enderecos)
                   .FirstOrDefaultAsync(c => c.Id == empresaId);
        }
    }
}
