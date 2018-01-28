using System.Threading.Tasks;
using ProcessHub.Core;

namespace ProcessHub.Persistence {
    public class UnitOfWork : IUnitOfWork {
        private readonly ProcessHubDbContext context;
        public UnitOfWork (ProcessHubDbContext context) {
            this.context = context;

        }
        public async Task CompleteAsync () {
            await context.SaveChangesAsync ();
        }
    }
}