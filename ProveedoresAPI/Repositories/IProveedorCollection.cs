using ProveedoresAPI.Models;

namespace ProveedoresAPI.Repositories
{
    public interface IProveedorCollection
    {
        Task InsertProveedor(Proveedor proveedor);
        Task UpdateProveedor(Proveedor proveedor);
        Task DeleteProveedor(string id);

        Task<List<Proveedor>> GetAllProveedors();
        Task<Proveedor> GetProveedorById(string id); 
    }
}
