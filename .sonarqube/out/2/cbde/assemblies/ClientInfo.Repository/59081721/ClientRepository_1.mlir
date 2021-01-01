func @_ClientInfo.Repository.Queries.ClientRepository.Delete$string$(none) -> none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Repository\\Queries\\ClientRepository.cs" :20 :8) {
^entry (%_id : none):
%0 = cbde.alloca none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Repository\\Queries\\ClientRepository.cs" :20 :27)
cbde.store %_id, %0 : memref<none> loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Repository\\Queries\\ClientRepository.cs" :20 :27)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Repository\\Queries\\ClientRepository.cs" :22 :18) // new System.NotImplementedException() (ObjectCreationExpression)
cbde.throw %1 :  none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Repository\\Queries\\ClientRepository.cs" :22 :12)

^1: // ExitBlock
cbde.unreachable

}
// Skipping function GetAll(i32, i32), it contains poisonous unsupported syntaxes

// Skipping function Save(none), it contains poisonous unsupported syntaxes

func @_ClientInfo.Repository.Queries.ClientRepository.Update$ClientInfo.Domain.Client$(none) -> none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Repository\\Queries\\ClientRepository.cs" :38 :8) {
^entry (%_client : none):
%0 = cbde.alloca none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Repository\\Queries\\ClientRepository.cs" :38 :27)
cbde.store %_client, %0 : memref<none> loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Repository\\Queries\\ClientRepository.cs" :38 :27)
br ^0

^0: // JumpBlock
%1 = cbde.unknown : none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Repository\\Queries\\ClientRepository.cs" :40 :18) // new System.NotImplementedException() (ObjectCreationExpression)
cbde.throw %1 :  none loc("C:\\Users\\guilh\\Documents\\repos\\ibank\\ibank-clientinfo\\ClientInfo.Repository\\Queries\\ClientRepository.cs" :40 :12)

^1: // ExitBlock
cbde.unreachable

}
