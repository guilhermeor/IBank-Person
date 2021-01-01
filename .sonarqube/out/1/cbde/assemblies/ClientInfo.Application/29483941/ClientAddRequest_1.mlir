func @_ClientInfo.Application.Mediators.Clients.Add.ClientAddRequest.WithDocuments$ClientInfo.Application.Mediators.Clients.Requests.DocumentRequest$$$(none) -> none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :26 :8) {
^entry (%_documents : none):
%0 = cbde.alloca none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :26 :46)
cbde.store %_documents, %0 : memref<none> loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :26 :46)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :28 :24) // Not a variable of known type: documents
%2 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :29 :19) // this (ThisExpression)
return %2 : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :29 :12)

^1: // ExitBlock
cbde.unreachable

}
// Skipping function WithContactInfo(none, none), it contains poisonous unsupported syntaxes

func @_ClientInfo.Application.Mediators.Clients.Add.ClientAddRequest.WithAddress$ClientInfo.Application.Mediators.Clients.Requests.AddressRequest$(none) -> none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :37 :8) {
^entry (%_address : none):
%0 = cbde.alloca none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :37 :44)
cbde.store %_address, %0 : memref<none> loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :37 :44)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :39 :22) // Not a variable of known type: address
%2 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :40 :19) // this (ThisExpression)
return %2 : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Application\\Mediators\\Clients\\Add\\ClientAddRequest.cs" :40 :12)

^1: // ExitBlock
cbde.unreachable

}
