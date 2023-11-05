using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;

namespace DevFreela.Infrastructure;
public class UnityOfWork : IUnityOfWork
{
    private readonly DevFreelaDbContext _context;
    public UnityOfWork(DevFreelaDbContext context,IProjectRepository projects, IUserRepository users)
    {
        _context = context;
        Projects = projects;
        Users = users;
    }
    public IProjectRepository Projects { get; }

    public IUserRepository Users { get; }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose() 
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing) 
    {
        if (disposing)
        {
            _context.Dispose();
        }
    }
}
