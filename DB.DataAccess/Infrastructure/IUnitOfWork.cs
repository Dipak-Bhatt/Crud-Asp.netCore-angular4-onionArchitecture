using System.Threading.Tasks;

namespace DB.DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
