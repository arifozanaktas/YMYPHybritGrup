
using Microsoft.EntityFrameworkCore.Storage;
using YMYPHibrit3GroupEFCore.API.Models.Repositories.Entities;

namespace YMYPHibrit3GroupEFCore.API.Models.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }


        public  Task<IDbContextTransaction> BeginTransactionAsync()
        {

            return context.Database.BeginTransactionAsync();

        }


        public   async Task CommitAsync()
        {


           await  context.Database.CommitTransactionAsync();
        }
    }
}
