using Sanatorium.DAL.Context;

namespace Sanatorium.DAL
{
    public static class DbInitialaizer
    {
        public static async void Initialize(EFContext db, CancellationToken cancellationToken)
        {
            await db.Database.EnsureDeletedAsync(cancellationToken);
            await db.Database.EnsureCreatedAsync(cancellationToken);
        }
    }
}
