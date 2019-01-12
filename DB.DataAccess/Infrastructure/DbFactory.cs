namespace DB.DataAccess.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        public DbFactory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly ApplicationDbContext _dbContext;

        public ApplicationDbContext Init()
        {
            return _dbContext;
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
