ç
bC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.API\Controllers\BaseController.cs
	namespace 	

ClientInfo
 
. 
API 
. 
Controllers $
{ 
[ 
Produces 
( 
$str  
)  !
]! "
[ 
ApiController 
] 
public		 

class		 
BaseController		 
:		  !
ControllerBase		" 0
{

 
	protected 
readonly 
	IMediator $
	_mediator% .
;. /
	protected 
readonly 
IBasePresenter )

_presenter* 4
;4 5
	protected 
readonly 
int 
DEFAULT_PAGE_NUMBER 2
=3 4
$num5 6
;6 7
	protected 
readonly 
int 
DEFAULT_PAGE_SIZE 0
=1 2
$num3 5
;5 6
public 
BaseController 
( 
	IMediator '
mediator( 0
,0 1
IBasePresenter2 @
basePresenterA N
)N O
{ 	

_presenter 
= 
basePresenter &
;& '
	_mediator 
= 
mediator  
;  !
} 	
} 
} ∑
dC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.API\Controllers\ClientController.cs
	namespace 	
API
 
. 
Controllers 
{ 
public 

class 
ClientController !
:" #
BaseController$ 2
{ 
public 
ClientController 
(  
	IMediator  )
mediator* 2
,2 3
IBasePresenter4 B
basePresenterC P
)P Q
: 
base 
( 
mediator 
, 
basePresenter *
)* +
{+ ,
}, -
[ 	
HttpGet	 
( 
$str 
)  
]  !
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status200OK* 5
,5 6
Type7 ;
=< =
typeof> D
(D E
IEnumerableE P
<P Q

ClientFullQ [
>[ \
)\ ]
)] ^
]^ _
public 
async 
Task 
< 
IActionResult '
>' (
GetById) 0
(0 1
Guid1 5
id6 8
)8 9
=> 

_presenter 
. 
GetActionResult )
() *
await 
	_mediator 
.  
Send  $
($ %
new% (
ClientFullRequest) :
(: ;
id; =
)= >
)> ?
)? @
;@ A
[ 	
HttpGet	 
( 
$str 
) 
] 
[ 	 
ProducesResponseType	 
( 
StatusCodes )
.) *
Status200OK* 5
,5 6
Type7 ;
=< =
typeof> D
(D E
IEnumerableE P
<P Q
ClientShortQ \
>\ ]
)] ^
)^ _
]_ `
public 
async 
Task 
< 
IActionResult '
>' (
GetAll) /
(/ 0
int0 3
?3 4

pageNumber5 ?
,? @
intA D
?D E
pageSizeF N
)N O
=> 

_presenter 
. 
GetActionResult )
() *
await 
	_mediator 
.  
Send  $
($ %
new% (
ClientShortRequest) ;
(; <

pageNumber< F
??G I
DEFAULT_PAGE_NUMBERJ ]
,] ^
pageSize_ g
??h j
DEFAULT_PAGE_SIZEk |
)| }
)} ~
)~ 
;	 Ä
[   	
HttpPost  	 
(   
$str   
)   
]   
public!! 
async!! 
Task!! 
<!! 
IActionResult!! '
>!!' (
Add!!) ,
(!!, -
[!!- .
FromBody!!. 6
]!!6 7
ClientAddRequest!!7 G
request!!H O
)!!O P
{"" 	
return## 

_presenter## 
.## 
GetActionResult## -
(##- .
await##. 3
	_mediator##4 =
.##= >
Send##> B
(##B C
request##C J
)##J K
)##K L
;##L M
}$$ 	
}%% 
}&& ±
`C:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.API\Presenters\BasePresenter.cs
	namespace 	

ClientInfo
 
. 
API 
. 

Presenters #
{ 
public 

class 
BasePresenter 
:  
IBasePresenter! /
{ 
public		 
IActionResult		 
GetActionResult		 ,
<		, -
T		- .
>		. /
(		/ 0
Response		0 8
<		8 9
T		9 :
>		: ;
response		< D
)		D E
where		F K
T		L M
:		N O
class		P U
=>

 
response

 
.

 
Invalid

 
(

  
)

  !
?

" #
CreateErrorResult

$ 5
(

5 6
response

6 >
)

> ?
:

@ A
new

B E
OkObjectResult

F T
(

T U
response

U ]
.

] ^
Result

^ d
)

d e
;

e f
private 
static 
IActionResult $
CreateErrorResult% 6
<6 7
T7 8
>8 9
(9 :
Response: B
<B C
TC D
>D E
responseF N
)N O
whereP U
TV W
:X Y
classZ _
{ 	
var 
	errorBody 
= 
new 
ApiError  (
(( )
response) 1
.1 2
Message2 9
,9 :
response; C
.C D
ErrorsD J
)J K
;K L
return 
response 
. 

StatusCode &
switch' -
{ 
HttpStatusCode 
. 
NotFound '
=>( *
new+ . 
NotFoundObjectResult/ C
(C D
	errorBodyD M
)M N
,N O
HttpStatusCode 
. 
UnprocessableEntity 2
=>3 5
new6 9+
UnprocessableEntityObjectResult: Y
(Y Z
	errorBodyZ c
)c d
,d e
HttpStatusCode 
. 
Unauthorized +
=>, .
new/ 2$
UnauthorizedObjectResult3 K
(K L
	errorBodyL U
)U V
,V W
_ 
=> 
new "
BadRequestObjectResult /
(/ 0
	errorBody0 9
)9 :
,: ;
} 
; 
} 	
} 
} Ö
aC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.API\Presenters\IBasePresenter.cs
	namespace 	

ClientInfo
 
. 
API 
. 

Presenters #
{ 
public 

	interface 
IBasePresenter #
{ 
IActionResult 
GetActionResult %
<% &
T& '
>' (
(( )
Response) 1
<1 2
T2 3
>3 4
response5 =
)= >
where? D
TE F
:G H
classI N
;N O
}		 
}

 €

OC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.API\Program.cs
	namespace 	

ClientInfo
 
. 
API 
{ 
public 

static 
class 
Program 
{ 
public		 
static		 
void		 
Main		 
(		  
string		  &
[		& '
]		' (
args		) -
)		- .
{

 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} ´	
PC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.API\Settings.cs
	namespace 	

ClientInfo
 
. 
API 
{ 
public 
class 
Settings 
{ 
public 
DatabaseSettings	 
Database "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
class	 
DatabaseSettings 
{ 
public		 	
string		
 
[		 
]		 
Urls		 
{		 
get		 
;		 
set		 "
;		" #
}		$ %
public

 	
string


 
DatabaseName

 
{

 
get

  #
;

# $
set

% (
;

( )
}

* +
public 	
string
 
CertPath 
{ 
get 
;  
set! $
;$ %
}& '
public 	
string
 
CertPass 
{ 
get 
;  
set! $
;$ %
}& '
} 
} 
} è:
OC:\Users\guilh\Documents\repos\ibank\ibank-clientinfo\ClientInfo.API\Startup.cs
	namespace 	

ClientInfo
 
. 
API 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %
configuration& 3
)3 4
{ 	
Configuration 
= 
configuration )
;) *
} 	
public 
IConfiguration 
Configuration +
{, -
get. 1
;1 2
}3 4
public"" 
void"" 
ConfigureServices"" %
(""% &
IServiceCollection""& 8
services""9 A
)""A B
{## 	
services$$ 
.$$ 
AddSingleton$$ !
($$! "
typeof$$" (
($$( )
IClientRepository$$) :
)$$: ;
,$$; <
typeof$$= C
($$C D
ClientRepository$$D T
)$$T U
)$$U V
;$$V W
services%% 
.%% 
AddControllers%% #
(%%# $
)%%$ %
;%%% &
services&& 
.&& 
AddTransient&& !
<&&! "
IBasePresenter&&" 0
,&&0 1
BasePresenter&&2 ?
>&&? @
(&&@ A
)&&A B
;&&B C
services(( 
.(( 

AddMediatR(( 
(((  
typeof((  &
(((& '
IBaseHandler((' 3
<((3 4
,((4 5
>((5 6
)((6 7
)((7 8
;((8 9
services)) 
.)) 
	AddScoped)) 
()) 
typeof)) %
())% &
IPipelineBehavior))& 7
<))7 8
,))8 9
>))9 :
))): ;
,)); <
typeof))= C
())C D$
FailFastPipelineBehavior))D \
<))\ ]
,))] ^
>))^ _
)))_ `
)))` a
;))a b
services** 
.** 
	AddScoped** 
(** 
typeof** %
(**% &$
IRequestExceptionHandler**& >
<**> ?
,**? @
,**@ A
>**A B
)**B C
,**C D
typeof**E K
(**K L!
BasePipelineException**L a
<**a b
,**b c
,**c d
>**d e
)**e f
)**f g
;**g h
services,, 
.,, 
AddMemoryCache,, #
(,,# $
),,$ %
;,,% &
services// 
.// 
AddMvc// 
(// 
)// 
.// 
AddJsonOptions// ,
(//, -
options//- 4
=>//5 7
{//8 9
options//: A
.//A B!
JsonSerializerOptions//B W
.//W X
IgnoreNullValues//X h
=//i j
true//k o
;//o p
}//q r
)//r s
.//s t 
AddFluentValidation	//t á
(
//á à
)
//à â
;
//â ä
services11 
.11 
AddSwaggerGen11 "
(11" #
c11# $
=>11% '
{22 
c33 
.33 

SwaggerDoc33 
(33 
$str33 !
,33! "
new33# &
OpenApiInfo33' 2
{333 4
Title335 :
=33; <
$str33= K
,33K L
Version33M T
=33U V
$str33W [
}33\ ]
)33] ^
;33^ _
}44 
)44 
;44 
services55 
.55 
	Configure55 
<55 
ClientSettings55 -
>55- .
(55. /
Configuration55/ <
.55< =

GetSection55= G
(55G H
$str55H Z
)55Z [
)55[ \
;55\ ]
services66 
.66 
AddSingleton66 !
<66! "
IMongoClient66" .
>66. /
(66/ 0
s660 1
=>662 4
new77 
MongoClient77 
(77 
Configuration77 )
.77) *
GetValue77* 2
<772 3
string773 9
>779 :
(77: ;
$str77; ^
)77^ _
)77_ `
)77` a
;77a b
ValidatorOptions99 
.99 
Global99 #
.99# $
LanguageManager99$ 3
=994 5
new996 9
FluentValidation99: J
.99J K
	Resources99K T
.99T U
LanguageManager99U d
(99d e
)99e f
{99g h
Culture99h o
=99p q
CultureInfo99r }
.99} ~
GetCultureInfo	99~ å
(
99å ç
$str
99ç î
)
99î ï
}
99ñ ó
;
99ó ò
services:: 
.:: 
AddTransient:: !
<::! "

IValidator::" ,
<::, -
ClientAddRequest::- =
>::= >
,::> ?
ClientAddValidator::@ R
>::R S
(::S T
)::T U
;::U V
services;; 
.;; 
AddTransient;; !
<;;! "

IValidator;;" ,
<;;, -
ClientFullRequest;;- >
>;;> ?
,;;? @
ClientFullValidator;;A T
>;;T U
(;;U V
);;V W
;;;W X
services<< 
.<< 
	Configure<< 
<<< 
ApiBehaviorOptions<< 1
><<1 2
(<<2 3
options<<3 :
=><<; =
{== 
options>> 
.>> +
SuppressModelStateInvalidFilter>> 7
=>>8 9
true>>: >
;>>> ?
}?? 
)?? 
;?? 
}@@ 	
publicCC 
voidCC 
	ConfigureCC 
(CC 
IApplicationBuilderCC 1
appCC2 5
,CC5 6
IWebHostEnvironmentCC7 J
envCCK N
)CCN O
{DD 	
ifEE 
(EE 
envEE 
.EE 
IsDevelopmentEE !
(EE! "
)EE" #
)EE# $
{FF 
appGG 
.GG %
UseDeveloperExceptionPageGG -
(GG- .
)GG. /
;GG/ 0
}HH 
appJJ 
.JJ 
UseHttpsRedirectionJJ #
(JJ# $
)JJ$ %
;JJ% &
appLL 
.LL 

UseRoutingLL 
(LL 
)LL 
;LL 
appNN 
.NN 
UseAuthorizationNN  
(NN  !
)NN! "
;NN" #
appPP 
.PP 
UseEndpointsPP 
(PP 
	endpointsPP &
=>PP' )
{QQ 
	endpointsRR 
.RR 
MapControllersRR (
(RR( )
)RR) *
;RR* +
}SS 
)SS 
;SS 
appTT 
.TT 

UseSwaggerTT 
(TT 
)TT 
;TT 
appUU 
.UU 
UseSwaggerUIUU 
(UU 
cUU 
=>UU !
{VV 
cWW 
.WW 
SwaggerEndpointWW !
(WW! "
$strWW" <
,WW< =
$strWW> S
)WWS T
;WWT U
cXX 
.XX 
RoutePrefixXX 
=XX 
stringXX  &
.XX& '
EmptyXX' ,
;XX, -
cYY 
.YY "
DisplayRequestDurationYY (
(YY( )
)YY) *
;YY* +
}ZZ 
)ZZ 
;ZZ 
}[[ 	
}\\ 
}]] 