using Sanatorium.DAL;
using Sanatorium.DAL.Context;

namespace temo
{
    public static class Program
    {
        static void Main(string[] args) 
        {
            EFContext db = new EFContext();

            DbInitialaizer.Initialize(db, CancellationToken.None);
        }
    }
}