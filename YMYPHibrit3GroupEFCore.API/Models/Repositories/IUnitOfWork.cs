using Microsoft.EntityFrameworkCore.Storage;

namespace YMYPHibrit3GroupEFCore.API.Models.Repositories
{
    public interface IUnitOfWork
    {

        Task<int> SaveChangesAsync();

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitAsync();
    }
}
