using CleanArchMVC.Application.Commands;
using System.Threading.Tasks;

namespace CleanArchMVC.BuildingBlocks.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task<bool> EnviarComando<T>(T comando) where T : Command;
    }
}
