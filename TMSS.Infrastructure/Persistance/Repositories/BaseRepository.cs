using TMSS.DataAccess.DataContext;

namespace TMSS.Infrastructure.Persistance.Repositories
{
    public class BaseRepository
    {
        protected readonly TMSSDbContext _tmssDbContext;
        public BaseRepository(TMSSDbContext tmssDbContext)
        {
            _tmssDbContext = tmssDbContext ?? throw new ArgumentNullException(nameof(tmssDbContext));
        }
        public BaseRepository() : base()
        {
                
        }
    }
}
