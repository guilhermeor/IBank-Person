Ú
XC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\ApiError.cs
	namespace 	

ClientInfo
 
. 
Application  
{ 
public 

class 
ApiError 
{ 
public 
ApiError 
( 
) 
{ 	
}

 	
public 
ApiError 
( 
string 
message &
,& '
IEnumerable( 3
<3 4
string4 :
>: ;
errors< B
)B C
=>D F
(G H
MessageH O
,O P
ErrorsQ W
)W X
=Y Z
([ \
message\ c
,c d
errorse k
)k l
;l m
public 
void 
AddFailureMessages &
(& '
IEnumerable' 2
<2 3
string3 9
>9 :
failureMessages; J
)J K
=>L N
ErrorsO U
=V W
failureMessagesX g
;g h
public 
string 
Message 
{ 
get  #
;# $
set% (
;( )
}* +
public 
IEnumerable 
< 
string !
>! "
Errors# )
{* +
get, /
;/ 0
set1 4
;4 5
}6 7
} 
} Ì
oC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\BasePipelineException.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
{ 
public		 

class		 !
BasePipelineException		 &
<		& '
TRequest		' /
,		/ 0
	TResponse		1 :
,		: ;

TException		< F
>		F G
:		H I$
IRequestExceptionHandler		K c
<		c d
TRequest		d l
,		l m
	TResponse		n w
,		w x

TException			y ƒ
>
		ƒ „
where

 
TRequest

 
:

 
IRequest

 %
<

% &
	TResponse

& /
>

/ 0
where 
	TResponse 
: 
ApiError &
,& '
new( +
(+ ,
), -
where 

TException 
: 
	Exception (
{ 
public 
Task 
Handle 
( 
TRequest #
request$ +
,+ ,

TException- 7
	exception8 A
,A B(
RequestExceptionHandlerStateC _
<_ `
	TResponse` i
>i j
statek p
,p q
CancellationToken	r ƒ
cancellationToken
„ •
)
• –
{ 	
var 
response 
= 
new 
	TResponse (
{ 
Message 
= 
	exception #
.# $
Source$ *
==+ -
$str. 5
?6 7
$str8 O
:P Q
	exceptionR [
.[ \
GetType\ c
(c d
)d e
.e f
Namef j
} 
; 
state 
. 

SetHandled 
( 
response %
)% &
;& '
return 
Task 
. 
CompletedTask %
;% &
} 	
} 
} á
uC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\Add\ClienAddHandler.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
Add3 6
{ 
public		 

class		 
ClientAddHandler		 !
:		" #
IRequestHandler		$ 3
<		3 4
ClientAddRequest		4 D
,		D E
Response		E M
<		M N
object		N T
>		T U
>		U V
{

 
private 
readonly 
IClientRepository *
_clientRepository+ <
;< =
public 
ClientAddHandler 
(  
IClientRepository  1
clientRepository2 B
)B C
{ 	
_clientRepository 
= 
clientRepository  0
;0 1
} 	
public 
Task 
< 
Response 
< 
object #
># $
>$ %
Handle& ,
(, -
ClientAddRequest- =
request> E
,E F
CancellationTokenG X
cancellationTokenY j
)j k
{ 	
var 
client 
= 
new 
Client #
(# $
request$ +
.+ ,
Name, 0
,0 1
request2 9
.9 :
BirthDay: B
)B C
;C D
_ 
= 
_clientRepository !
.! "
Save" &
(& '
client' -
)- .
;. /
return 
Task 
. 

FromResult "
(" #
new# &
Response' /
</ 0
object0 6
>6 7
(7 8
)8 9
)9 :
;: ;
} 	
} 
} ·
vC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\Add\ClientAddRequest.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
Add3 6
{ 
public 

class 
ClientAddRequest !
:" #
IRequest$ ,
<, -
Response- 5
<5 6
object6 <
>< =
>= >
{		 
public

 
string

 
Name

 
{

 
get

  
;

  !
set

" %
;

% &
}

' (
public 
string 
Alias 
{ 
get !
;! "
set# &
;& '
}( )
public 
DateTime 
BirthDay  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
int 
MonthlyIncome  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
Phone 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
DocumentRequest 
[ 
]  
	Documents! *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
public 
AddressRequest 
Address %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
public 
ClientAddRequest 
(  
)  !
{ 	
} 	
public 
ClientAddRequest 
(  
string  &
name' +
,+ ,
string- 3
alias4 9
,9 :
DateTime; C
birthDayD L
,L M
intN Q
monthlyIncomeR _
)_ `
=> 
( 
Name 
, 
Alias 
, 
BirthDay %
,% &
MonthlyIncome' 4
)4 5
=6 7
(8 9
name9 =
,= >
alias? D
,D E
birthDayF N
,N O
monthlyIncomeP ]
)] ^
;^ _
public 
ClientAddRequest 
WithDocuments  -
(- .
DocumentRequest. =
[= >
]> ?
	documents@ I
)I J
{ 	
	Documents 
= 
	documents !
;! "
return 
this 
; 
} 	
public!! 
ClientAddRequest!! 
WithContactInfo!!  /
(!!/ 0
string!!0 6
phone!!7 <
,!!< =
string!!> D
email!!E J
)!!J K
{"" 	
(## 
Phone## 
,## 
Email## 
)## 
=## 
(## 
phone## #
,### $
email##% *
)##* +
;##+ ,
return$$ 
this$$ 
;$$ 
}%% 	
public&& 
ClientAddRequest&& 
WithAddress&&  +
(&&+ ,
AddressRequest&&, :
address&&; B
)&&B C
{'' 	
Address(( 
=(( 
address(( 
;(( 
return)) 
this)) 
;)) 
}** 	
}++ 
},, «

xC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\Add\ClientAddValidator.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
Add3 6
{ 
public 

class 
ClientAddValidator #
:$ %
AbstractValidator& 7
<7 8
ClientAddRequest8 H
>H I
{ 
public 
ClientAddValidator	 
( 
) 
{ 
RuleFor		 

(		
 
x		 
=>		 
x		 
.		 
Name		 
)		 
.		 
NotEmpty		  
(		  !
)		! "
;		" #
RuleFor

 

(


 
x

 
=>

 
x

 
.

 
Email

 
)

 
.

 
EmailAddress

 %
(

% &
)

& '
;

' (
RuleFor 

(
 
x 
=> 
x 
. 
Alias 
) 
. 
MinimumLength &
(& '
$num' (
)( )
;) *
} 
} 
} Ñ
tC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\GetAll\ClientShort.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
GetAll3 9
{ 
public 

readonly 
struct 
ClientShort &
{ 
public 
Guid 
Id 
{ 
get 
; 
init "
;" #
}$ %
public		 
string		 
Name		 
{		 
get		  
;		  !
init		" &
;		& '
}		( )
public

 
string

 
Alias

 
{

 
get

 !
;

! "
init

# '
;

' (
}

) *
public 
string 
FullPhoneNumber %
{& '
get( +
;+ ,
init- 1
;1 2
}3 4
public 
string 
Email 
{ 
get !
;! "
init# '
;' (
}) *
public 
ClientShort 
( 
Client !
client" (
)( )
{ 	
Id 
= 
client 
. 
Id 
; 
Name 
= 
client 
. 
Name 
; 
Alias 
= 
client 
. 
Alias  
;  !
FullPhoneNumber 
= 
client $
.$ %
Phone% *
?* +
.+ ,
FullPhoneNumber, ;
(; <
)< =
;= >
Email 
= 
client 
. 
Email  
;  !
} 	
public 
static 
implicit 
operator '
ClientShort( 3
(3 4
Client4 :
client; A
)A B
=>C E
newF I
(I J
clientJ P
)P Q
;Q R
} 
} Å
{C:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\GetAll\ClientShortHandler.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
GetAll3 9
{ 
public		 

class		 
ClientShortHandler		 #
:		$ %
IBaseHandler		& 2
<		2 3
ClientShortRequest		3 E
,		E F
Response		G O
<		O P
IEnumerable		P [
<		[ \
ClientShort		\ g
>		g h
>		h i
>		i j
{

 
private 
readonly 
IClientRepository *
_clientRepository+ <
;< =
public 
ClientShortHandler !
(! "
IClientRepository" 3
clientRepository4 D
)D E
=>F H
_clientRepositoryI Z
=[ \
clientRepository] m
;m n
public 
async 
Task 
< 
Response "
<" #
IEnumerable# .
<. /
ClientShort/ :
>: ;
>; <
>< =
Handle> D
(D E
ClientShortRequestE W
requestX _
,_ `
CancellationTokena r
cancellationToken	s „
)
„ …
{ 	
var 
clients 
= 
_clientRepository /
./ 0
GetAll0 6
(6 7
request7 >
.> ?

PageNumber? I
,I J
requestK R
.R S
PageSizeS [
)[ \
;\ ]
return 
new 
Response #
<# $
IEnumerable$ /
</ 0
ClientShort0 ;
>; <
>< =
(= >
(> ?
await? D
clientsE L
)L M
.M N
SelectN T
(T U
cU V
=>W Y
(Z [
ClientShort[ f
)f g
cg h
)h i
)i j
;j k
} 	
} 
} ç

{C:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\GetAll\ClientShortRequest.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
GetAll3 9
{ 
public 

readonly 
struct 
ClientShortRequest -
:. /
IRequest0 8
<8 9
Response9 A
<A B
IEnumerableB M
<M N
ClientShortN Y
>Y Z
>Z [
>[ \
{ 
public 
int 

PageNumber 
{ 
get  #
;# $
init% )
;) *
}+ ,
public		 
int		 
PageSize		 
{		 
get		 !
;		! "
init		# '
;		' (
}		) *
public 
ClientShortRequest !
(! "
int" %

pageNumber& 0
,0 1
int2 5
pageSize6 >
)> ?
=> 
( 

PageNumber 
, 
PageSize $
)$ %
=& '
(( )

pageNumber) 3
,3 4
pageSize5 =
)= >
;> ?
} 
} Á
tC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\GetById\ClientFull.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
GetById3 :
{ 
public 

class 

ClientFull 
{		 
public

 
Guid

 
Id

 
{

 
get

 
;

 
set

 !
;

! "
}

# $
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Alias 
{ 
get !
;! "
set# &
;& '
}( )
public 
DateTime 
BirthDay  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
int 
MonthlyIncome  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
string 
Phone 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
IEnumerable 
< 
DocumentResponse +
>+ ,
	Documents- 6
{7 8
get9 <
;< =
set> A
;A B
}C D
public 
AddressResponse 
Address &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 

ClientFull 
( 
Client  
client! '
)' (
{ 	
Id 
= 
client 
. 
Id 
; 
Name 
= 
client 
. 
Name 
; 
Alias 
= 
client 
. 
Alias  
;  !
BirthDay 
= 
client 
. 
BirthDay &
;& '
MonthlyIncome 
= 
client "
." #
MonthlyIncome# 0
;0 1
Phone 
= 
client 
. 
Phone  
?  !
.! "
FullPhoneNumber" 1
(1 2
)2 3
;3 4
Email 
= 
client 
. 
Email  
;  !
} 	
public 
static 
implicit 
operator '

ClientFull( 2
(2 3
Client3 9
client: @
)@ A
=>B D
newE H
(H I
clientI O
)O P
;P Q
}   
}!! Ì
{C:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\GetById\ClientFullHandler.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
GetById3 :
{ 
public 

class 
ClientFullHandler "
:# $
IBaseHandler% 1
<1 2
ClientFullRequest2 C
,C D
ResponseE M
<M N

ClientFullN X
>X Y
>Y Z
{ 
private		 
readonly		 
IClientRepository		 *
_clientRepository		+ <
;		< =
public

 
ClientFullHandler

  
(

  !
IClientRepository

! 2
clientRepository

3 C
)

C D
=>

E G
_clientRepository

H Y
=

Z [
clientRepository

\ l
;

l m
public 
async 
Task 
< 
Response "
<" #

ClientFull# -
>- .
>. /
Handle0 6
(6 7
ClientFullRequest7 H
requestI P
,P Q
CancellationTokenR c
cancellationTokend u
)u v
{ 	
var 
client 
= 
await 
_clientRepository 0
.0 1
Get1 4
(4 5
request5 <
.< =
Id= ?
)? @
;@ A
return 
client 
is 
null !
?" #
new$ '
Response( 0
<0 1

ClientFull1 ;
>; <
(< =
)= >
:? @
newA D
ResponseE M
<M N

ClientFullN X
>X Y
(Y Z
clientZ `
)` a
;a b
} 	
} 
} ¢
{C:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\GetById\ClientFullRequest.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
GetById3 :
{ 
public 

class 
ClientFullRequest "
:# $
IRequest% -
<- .
Response. 6
<6 7

ClientFull7 A
>A B
>B C
{ 
public		 
Guid		 
Id		 
{		 
get		 
;		 
set		 !
;		! "
}		# $
public

 
ClientFullRequest

  
(

  !
Guid

! %
id

& (
)

( )
=>

* ,
Id

- /
=

0 1
id

2 4
;

4 5
} 
} ð
}C:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\GetById\ClientFullValidator.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
GetById3 :
{ 
public 

class 
ClientFullValidator $
:% &
AbstractValidator' 8
<8 9
ClientFullRequest9 J
>J K
{ 
public 
ClientFullValidator "
(" #
)# $
{ 	
RuleFor 
( 
x 
=> 
x 
. 
Id 
) 
. 
NotEmpty '
(' (
)( )
;) *
}		 	
}

 
} º
yC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\Requests\AddressRequest.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
Requests3 ;
{ 
public 

class 
AddressRequest 
{ 
}		 
}

 ¼
zC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\Requests\DocumentRequest.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
.2 3
Requests3 ;
{ 
public 

class 
DocumentRequest  
{ 
}		 
}

 ®

{C:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\Responses\AddressResponse.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
{ 
public 

class 
AddressResponse  
{ 
public 
string 
ZipCode 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
Street 
{ 
get "
;" #
set$ '
;' (
}) *
public		 
int		 
Number		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
public

 
string

 
District

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
public 
string 
City 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Uf 
{ 
get 
; 
set  #
;# $
}% &
} 
} Ì
|C:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\Clients\Responses\DocumentResponse.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
.* +
Clients+ 2
{ 
public 

class 
DocumentResponse !
{ 
public 
string 
Type 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Number 
{ 
get "
;" #
set$ '
;' (
}) *
}		 
}

 €
sC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\FailFastPipelineBehaviour.cs
	namespace

 	

ClientInfo


 
.

 
Application

  
.

  !
	Mediators

! *
{ 
[ #
ExcludeFromCodeCoverage 
] 
public 

class $
FailFastPipelineBehavior )
<) *
TRequest* 2
,2 3
	TResponse4 =
>= >
:? @
IPipelineBehaviorA R
<R S
TRequestS [
,[ \
	TResponse] f
>f g
where 
TRequest 
: 
IRequest %
<% &
	TResponse& /
>/ 0
where 
	TResponse 
: 
ApiError &
,& '
new( +
(+ ,
), -
{ 
private 
readonly 
IEnumerable $
<$ %

IValidator% /
</ 0
TRequest0 8
>8 9
>9 :
_validators; F
;F G
public $
FailFastPipelineBehavior '
(' (
IEnumerable( 3
<3 4

IValidator4 >
<> ?
TRequest? G
>G H
>H I

validatorsJ T
)T U
{ 	
_validators 
= 

validators $
;$ %
} 	
public 
Task 
< 
	TResponse 
> 
Handle %
(% &
TRequest& .
request/ 6
,6 7
CancellationToken8 I
cancellationTokenJ [
,[ \"
RequestHandlerDelegate] s
<s t
	TResponset }
>} ~
next	 ƒ
)
ƒ „
{ 	
if 
( 
! 
_validators 
. 
Any  
(  !
)! "
)" #
return 
next 
( 
) 
; 
var 
failures 
= 
_validators &
.   
Select   
(   
v   
=>   
v   
.   
Validate   '
(  ' (
request  ( /
)  / 0
)  0 1
.!! 

SelectMany!! 
(!! 
result!! "
=>!!# %
result!!& ,
.!!, -
Errors!!- 3
)!!3 4
."" 
Where"" 
("" 
f"" 
=>"" 
f"" 
!=""  
null""! %
)""% &
;""& '
return$$ 
failures$$ 
.$$ 
Any$$ 
($$  
)$$  !
?%% 
Task%% 
.%% 

FromResult%% !
(%%! "
Errors%%" (
(%%( )
failures%%) 1
)%%1 2
)%%2 3
:&& 
next&& 
(&& 
)&& 
;&& 
}(( 	
private** 
static** 
	TResponse**  
Errors**! '
(**' (
IEnumerable**( 3
<**3 4
ValidationFailure**4 E
>**E F
failures**G O
)**O P
{++ 	
var,, 
response,, 
=,, 
new,, 
	TResponse,, (
(,,( )
),,) *
;,,* +
response-- 
.-- 
AddFailureMessages-- '
(--' (
failures--( 0
.--0 1
Select--1 7
(--7 8
f--8 9
=>--: <
f--= >
.--> ?
ErrorMessage--? K
)--K L
)--L M
;--M N
return.. 
response.. 
;.. 
}// 	
}00 
}11 –
fC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\IBaseHandler.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
{ 
public 

	interface 
IBaseHandler !
<! "
T" #
,# $
K% &
>& '
:( )
IRequestHandler* 9
<9 :
T: ;
,; <
K= >
>> ?
where@ E
TF G
:H I
IRequestJ R
<R S
KS T
>T U
{ 
} 
} ß
rC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Mediators\IBaseNotificationHandler.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
	Mediators! *
{ 
public 

	interface $
IBaseNotificationHandler -
<- .
in. 0
T1 2
>2 3
:4 5 
INotificationHandler6 J
<J K
TK L
>L M
whereN S
TT U
:V W
INotificationX e
{ 
} 
} ³
XC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Response.cs
	namespace 	

ClientInfo
 
. 
Application  
{ 
public 

class 
Response 
< 
T 
> 
: 
ApiError '
where( -
T. /
:0 1
class2 7
{ 
public 
Response 
( 
) 
{ 	
}

 	
public 
Response 
( 
T 
result  
)  !
=>" $
Result% +
=, -
result. 4
;4 5
public 
string 
ErrorMessage "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
bool 
Invalid 
( 
) 
=>  
!! "
string" (
.( )
IsNullOrEmpty) 6
(6 7
Message7 >
)> ?
||@ B
ErrorsC I
!=J L
nullM Q
;Q R
public 
T 
Result 
{ 
get 
; 
}  
public 
HttpStatusCode 

StatusCode (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
=7 8
HttpStatusCode9 G
.G H
OKH J
;J K
} 
} Ä
gC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.Application\Settings\ClientSettings.cs
	namespace 	

ClientInfo
 
. 
Application  
.  !
Settings! )
{ 
public		 

class		 
ClientSettings		 
{

 
public 
string 
CollectionName $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string 
ConnectionString &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
public 
string 
DatabaseName "
{# $
get% (
;( )
set* -
;- .
}/ 0
} 
} 