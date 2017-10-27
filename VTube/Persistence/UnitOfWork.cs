using System.Data.Entity.Validation;
using VTube.Core;
using VTube.Core.Repositories;
using VTube.Persistence.Repositories;

namespace VTube.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IVideoRepository Videos { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Videos = new VideoRepository(_context);
        }

        public void Complete()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                throw;
            }

        }
    }
}