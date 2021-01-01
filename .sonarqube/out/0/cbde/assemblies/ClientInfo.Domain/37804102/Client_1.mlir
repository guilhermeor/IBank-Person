func @_ClientInfo.Domain.Client.WithAddress$ClientInfo.Domain.Address$(none) -> none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :23 :8) {
^entry (%_address : none):
%0 = cbde.alloca none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :23 :34)
cbde.store %_address, %0 : memref<none> loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :23 :34)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :25 :22) // Not a variable of known type: address
%2 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :26 :19) // this (ThisExpression)
return %2 : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :26 :12)

^1: // ExitBlock
cbde.unreachable

}
func @_ClientInfo.Domain.Client.WithDocuments$System.Collections.Generic.IEnumerable$ClientInfo.Domain.Document$$(none) -> none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :28 :8) {
^entry (%_documents : none):
%0 = cbde.alloca none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :28 :36)
cbde.store %_documents, %0 : memref<none> loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :28 :36)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :30 :24) // Not a variable of known type: documents
%2 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :31 :19) // this (ThisExpression)
return %2 : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Domain\\Client.cs" :31 :12)

^1: // ExitBlock
cbde.unreachable

}
