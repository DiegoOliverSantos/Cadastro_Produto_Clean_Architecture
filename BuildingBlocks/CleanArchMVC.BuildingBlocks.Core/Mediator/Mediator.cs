using CleanArchMVC.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMVC.BuildingBlocks.Core.Mediator
{
    public class Mediator : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public Mediator(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task<object> EnviarComandoService<T>(T comando) where T : class
        {
            return await _mediator.Send(comando);
        }
    }
}
