using Api_Crud_EF.Application.Domain;

namespace Api_Crud_EF.Application.Interfaces
{
    public interface IEmpresaRepository : IRepository<Empresa>
    {
        Task<Empresa> ObterEmpresaComEndereco(int empresaId);
    }
}
