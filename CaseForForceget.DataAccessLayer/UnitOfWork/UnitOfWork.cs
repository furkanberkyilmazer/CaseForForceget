
using CaseForForceget.DataAccess.UnitOfWork;
using CaseForForceget.DataAccessLayer.Context;

namespace CaseForRanna_BackEnd.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork  
    {
        private readonly DbContextForceget _dbContextForCase;

        public UnitOfWork(DbContextForceget dbContextForCase)
        {
            _dbContextForCase = dbContextForCase;
        }

        public void Commit()
        {
            _dbContextForCase.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContextForCase.SaveChangesAsync();
        }
    }
}
