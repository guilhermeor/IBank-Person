func @_ClientInfo.Application.Mediators.Clients.Add.ClientAddHandler.Handle$ClientInfo.Application.Mediators.Clients.Add.ClientAddRequest.System.Threading.CancellationToken$(none, none) -> none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :17 :8) {
^entry (%_request : none, %_cancellationToken : none):
%0 = cbde.alloca none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :17 :45)
cbde.store %_request, %0 : memref<none> loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :17 :45)
%1 = cbde.alloca none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :17 :71)
cbde.store %_cancellationToken, %1 : memref<none> loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :17 :71)
br ^0

^0: // JumpBlock
%2 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :19 :36) // Not a variable of known type: request
%3 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :19 :36) // request.Name (SimpleMemberAccessExpression)
%4 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :19 :50) // Not a variable of known type: request
%5 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :19 :50) // request.BirthDay (SimpleMemberAccessExpression)
%6 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :19 :25) // new Client(request.Name, request.BirthDay) (ObjectCreationExpression)
%8 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :20 :16) // Not a variable of known type: _clientRepository
%9 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :20 :39) // Not a variable of known type: client
%10 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :20 :16) // _clientRepository.Save(client) (InvocationExpression)
// Entity from another assembly: Task
%11 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :21 :35) // new Response<object>() (ObjectCreationExpression)
%12 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :21 :19) // Task.FromResult(new Response<object>()) (InvocationExpression)
return %12 : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClienAddHandler.cs" :21 :12)

^1: // ExitBlock
cbde.unreachable

}
