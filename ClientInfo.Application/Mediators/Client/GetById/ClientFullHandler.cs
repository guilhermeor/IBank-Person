using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientInfo.Application.Mediators.Client.GetById
{
    public class ClientFullHandler : IBaseHandler<ClientFullRequest, Response<IEnumerable<ClientFull>>>
    {
        public Task<Response<IEnumerable<ClientFull>>> Handle(ClientFullRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
