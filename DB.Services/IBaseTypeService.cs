using System.Linq;
using System.Threading.Tasks;
using CG.Services;
using DB.Entity.ServiceResp;

namespace DB.Services
{
    public interface IBaseTypeService<T, in T1> where T : class
    {
        ServiceResponse<IQueryable<T>> GetAll(FilterReq req);
        Task<ServiceResponse<T>> CreateAsync(T model);
        Task<ServiceResponse<T>> EditAsync(T model);
        ServiceResponse<T> Detail(T1 id);
        Task<ServiceResponse> DeleteAsync(T1 id);
    }
}
