using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfo.Application.Mediators.Client.GetById
{
    public class ClientFullHandler : IBaseHandler<ClientFullRequest, IEnumerable<ClientFull>>
    {
        public Task<IEnumerable<ClientFull>> Handle(ClientFullRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
