using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CQRS
{
    //unit represents a void type
    public interface ICommand : ICommand<Unit>
    { }
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
