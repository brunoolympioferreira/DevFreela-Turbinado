using DevFreela.Core.Repositories;

namespace DevFreela.Infrastructure.Persistence;
public interface IUnityOfWork
{
    IProjectRepository Projects {  get; }
    IUserRepository Users { get; }
    ISkillRepository Skills { get; }
    Task<int> CompleteAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
}
