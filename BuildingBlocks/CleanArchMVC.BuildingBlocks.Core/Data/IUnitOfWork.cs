using System;
using System.Threading.Tasks;

namespace CleanArchMVC.BuildingBlocks.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
