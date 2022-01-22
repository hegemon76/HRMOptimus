Æ
gC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\Login\LoginCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Account! (
.( )
Command) 0
.0 1
Login1 6
{ 
public 

class 
LoginCommand 
: 
IRequest '
<' (
LoginVm( /
>/ 0
{ 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
}		 
}

 Ñ
nC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\Login\LoginCommandHandler.cs
	namespace

 	

HRMOptimus
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
  !
Account

! (
.

( )
Command

) 0
.

0 1
Login

1 6
{ 
public 

class 
LoginCommandHandler $
:% &
IRequestHandler' 6
<6 7
LoginCommand7 C
,C D
LoginVmE L
>L M
{ 
private 
readonly 
TokenService %
_tokenService& 3
;3 4
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
public 
LoginCommandHandler "
(" #
TokenService# /
tokenService0 <
,< = 
IHRMOptimusDbContext> R
contextS Z
,Z [
UserManager\ g
<g h
ApplicationUserh w
>w x
userManager	y Ñ
)
Ñ Ö
{ 	
_tokenService 
= 
tokenService (
;( )
_context 
= 
context 
; 
_userManager 
= 
userManager &
;& '
} 	
public 
async 
Task 
< 
LoginVm !
>! "
Handle# )
() *
LoginCommand* 6
request7 >
,> ?
CancellationToken@ Q
cancellationTokenR c
)c d
{ 	
var 
user 
= 
await 
_userManager )
.) *
FindByEmailAsync* :
(: ;
request; B
.B C
EmailC H
)H I
;I J
var 
result 
= 
await 
_userManager +
.+ ,
CheckPasswordAsync, >
(> ?
user? C
,C D
requestE L
.L M
PasswordM U
)U V
;V W
if 
( 
result 
) 
{ 
var   
employee   
=   
_context   '
.  ' (
	Employees  ( 1
.  1 2
FirstOrDefault  2 @
(  @ A
x  A B
=>  C E
x  F G
.  G H
Id  H J
==  K M
user  N R
.  R S

EmployeeId  S ]
)  ] ^
;  ^ _
return"" 
new"" 
LoginVm"" "
(""" #
)""# $
{## 
	FirstName$$ 
=$$ 
employee$$  (
.$$( )
	FirstName$$) 2
,$$2 3
LastName%% 
=%% 
employee%% '
.%%' (
LastName%%( 0
,%%0 1
Gender&& 
=&& 
employee&& %
.&&% &
Gender&&& ,
,&&, -
Token'' 
='' 
_tokenService'' )
.'') *
CreateToken''* 5
(''5 6
user''6 :
.'': ;
Id''; =
,''= >
employee''? G
.''G H
Id''H J
.''J K
ToString''K S
(''S T
)''T U
,''U V
employee''W _
.''_ `
FullName''` h
,''h i
(''j k
(''k l
int''l o
)''o p
employee''p x
.''x y
Gender''y 
)	'' Ä
.
''Ä Å
ToString
''Å â
(
''â ä
)
''ä ã
)
''ã å
}(( 
;(( 
})) 
return** 
null** 
;** 
}++ 	
},, 
}-- Ä	
pC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\Login\LoginCommandValidator.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Account! (
.( )
Command) 0
.0 1
Login1 6
{ 
public		 

class		 !
LoginCommandValidator		 &
:		' (
AbstractValidator		) :
<		: ;
LoginCommand		; G
>		G H
{

 
public !
LoginCommandValidator $
($ %
)% &
{ 	
RuleFor 
( 
x 
=> 
x 
. 
Email  
)  !
.! "
NotEmpty" *
(* +
)+ ,
., -
EmailAddress- 9
(9 :
): ;
;; <
RuleFor 
( 
x 
=> 
x 
. 
Password #
)# $
.$ %
NotEmpty% -
(- .
). /
;/ 0
} 	
} 
} É
bC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\Login\LoginVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Account! (
.( )
Command) 0
.0 1
Login1 6
{ 
public 

class 
LoginVm 
{ 
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
Gender		 
Gender		 
{		 
get		 "
;		" #
set		$ '
;		' (
}		) *
public

 
string

 
Token
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
! "
set

# &
;

& '
}

( )
} 
} ¸
iC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\Logout\LogoutCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Account! (
.( )
Command) 0
.0 1
Logout1 7
{ 
public 

class 
LogoutCommand 
:  
IRequest! )
<) *
string* 0
>0 1
{ 
} 
} ö
pC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\Logout\LogoutCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Account! (
.( )
Command) 0
.0 1
Logout1 7
{ 
public 

class  
LogoutCommandHandler %
:& '
IRequestHandler( 7
<7 8
LogoutCommand8 E
,E F
stringG M
>M N
{ 
public		  
LogoutCommandHandler		 #
(		# $
)		$ %
{

 	
} 	
public 
async 
Task 
< 
string  
>  !
Handle" (
(( )
LogoutCommand) 6
request7 >
,> ?
CancellationToken@ Q
cancellationTokenR c
)c d
{ 	
return 
$str 
;  
} 	
} 
} ä
uC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\Registration\RegistrationCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Account! (
.( )
Command) 0
.0 1
Registration1 =
{ 
public 

class 
RegistrationCommand $
:% &
IRequest' /
{ 
public 
RegistrationVm 
Registration *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
} 
}		 ïH
|C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\Registration\RegistrationCommandHandler.cs
	namespace		 	

HRMOptimus		
 
.		 
Application		  
.		  !
Account		! (
.		( )
Command		) 0
.		0 1
Registration		1 =
{

 
public 

class &
RegistrationCommandHandler +
:, -
IRequestHandler. =
<= >
RegistrationCommand> Q
,Q R
UnitS W
>W X
{ 
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public &
RegistrationCommandHandler )
() *
UserManager* 5
<5 6
ApplicationUser6 E
>E F
userManagerG R
,R S 
IHRMOptimusDbContextT h
contexti p
)p q
{ 	
_userManager 
= 
userManager &
;& '
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '
RegistrationCommand' :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 	
Domain 
. 
Entities 
. 
Contract #
contract$ ,
=- .
new/ 2
Domain3 9
.9 :
Entities: B
.B C
ContractC K
(K L
)L M
{ 
ContractName 
= 
request &
.& '
Registration' 3
.3 4
ContractName4 @
,@ A
	LeaveDays 
= 
request #
.# $
Registration$ 0
.0 1
	LeaveDays1 :
,: ;
Payment 
= 
request !
.! "
Registration" .
.. /
Payment/ 6
,6 7
Rate 
= 
request 
. 
Registration +
.+ ,
Rate, 0
,0 1
WorkTime 
= 
request "
." #
Registration# /
./ 0
WorkTime0 8
,8 9
ContractType 
= 
request &
.& '
Registration' 3
.3 4
ContractType4 @
}   
;   
Address"" 
address"" 
="" 
new"" !
Address""" )
("") *
)""* +
{## 
ZipCode$$ 
=$$ 
request$$ !
.$$! "
Registration$$" .
.$$. /
ZipCode$$/ 6
,$$6 7
City%% 
=%% 
request%% 
.%% 
Registration%% +
.%%+ ,
City%%, 0
,%%0 1
Street&& 
=&& 
request&&  
.&&  !
Registration&&! -
.&&- .
Street&&. 4
,&&4 5
BuildingNumber'' 
=''  
request''! (
.''( )
Registration'') 5
.''5 6
BuildingNumber''6 D
,''D E
HouseNumber(( 
=(( 
request(( %
.((% &
Registration((& 2
.((2 3
HouseNumber((3 >
,((> ?
Country)) 
=)) 
request)) !
.))! "
Registration))" .
.)). /
Country))/ 6
}** 
;** 
var,, 
employee,, 
=,, 
new,, 
Domain,, %
.,,% &
Entities,,& .
.,,. /
Employee,,/ 7
(,,7 8
),,8 9
{-- 
	FirstName.. 
=.. 
request.. #
...# $
Registration..$ 0
...0 1
	FirstName..1 :
,..: ;
LastName// 
=// 
request// "
.//" #
Registration//# /
./// 0
LastName//0 8
,//8 9
	BirthDate00 
=00 
request00 #
.00# $
Registration00$ 0
.000 1
	BirthDate001 :
,00: ;
WorkingTime11 
=11 
$num11 
,11  
LeaveDaysLeft22 
=22 
(22  !
int22! $
)22$ %
contract22% -
.22- .
	LeaveDays22. 7
,227 8
Contract33 
=33 
contract33 #
,33# $
Gender44 
=44 
request44  
.44  !
Registration44! -
.44- .
Gender44. 4
,444 5
Address55 
=55 
address55 !
,55! "
FullName66 
=66 
$"66 
{66 
request66 %
.66% &
Registration66& 2
.662 3
	FirstName663 <
}66< =
$str66= >
{66> ?
request66? F
.66F G
Registration66G S
.66S T
LastName66T \
}66\ ]
"66] ^
,66^ _
Projects77 
=77 
new77 
List77 #
<77# $
Domain77$ *
.77* +
Entities77+ 3
.773 4
Project774 ;
>77; <
(77< =
)77= >
,77> ?
WorkRecords88 
=88 
new88 !
List88" &
<88& '
Domain88' -
.88- .
Entities88. 6
.886 7

WorkRecord887 A
>88A B
(88B C
)88C D
,88D E
LeavesRegister99 
=99  
new99! $
List99% )
<99) *
Domain99* 0
.990 1
Entities991 9
.999 :
LeaveRegister99: G
>99G H
(99H I
)99I J
}:: 
;:: 
_context<< 
.<< 
	Contracts<< 
.<< 
Add<< "
(<<" #
contract<<# +
)<<+ ,
;<<, -
_context== 
.== 
	Addresses== 
.== 
Add== "
(==" #
address==# *
)==* +
;==+ ,
employee?? 
.?? 

ContractId?? 
=??  !
contract??" *
.??* +
Id??+ -
;??- .
employee@@ 
.@@ 
	AddressId@@ 
=@@  
address@@! (
.@@( )
Id@@) +
;@@+ ,
_contextAA 
.AA 
	EmployeesAA 
.AA 
AddAA "
(AA" #
employeeAA# +
)AA+ ,
;AA, -
varCC 
newUserCC 
=CC 
newCC 
ApplicationUserCC -
(CC- .
)CC. /
{DD 
UserNameEE 
=EE 
requestEE "
.EE" #
RegistrationEE# /
.EE/ 0
EmailEE0 5
,EE5 6
EmailFF 
=FF 
requestFF 
.FF  
RegistrationFF  ,
.FF, -
EmailFF- 2
,FF2 3
PhoneNumberGG 
=GG 
requestGG %
.GG% &
RegistrationGG& 2
.GG2 3
PhoneNumberGG3 >
,GG> ?
EmployeeHH 
=HH 
employeeHH #
,HH# $
}II 
;II 
varKK 
userKK 
=KK 
awaitKK 
_userManagerKK )
.KK) *
CreateAsyncKK* 5
(KK5 6
newUserKK6 =
,KK= >
requestKK? F
.KKF G
RegistrationKKG S
.KKS T
PasswordKKT \
)KK\ ]
;KK] ^
ifMM 
(MM 
userMM 
.MM 
	SucceededMM 
)MM 
{NN 
ListOO 
<OO 
stringOO 
>OO 
	userRolesOO &
=OO' (
newOO) ,
ListOO- 1
<OO1 2
stringOO2 8
>OO8 9
(OO9 :
)OO: ;
;OO; <
foreachPP 
(PP 
varPP 
rolePP !
inPP" $
requestPP% ,
.PP, -
RegistrationPP- 9
.PP9 :
RolesPP: ?
)PP? @
{QQ 
	userRolesRR 
.RR 
AddRR !
(RR! "
roleRR" &
.RR& '
ToStringRR' /
(RR/ 0
)RR0 1
)RR1 2
;RR2 3
}SS 
awaitTT 
_userManagerTT "
.TT" #
AddToRolesAsyncTT# 2
(TT2 3
newUserTT3 :
,TT: ;
	userRolesTT< E
)TTE F
;TTF G
}UU 
awaitWW 
_contextWW 
.WW 
SaveChangesAsyncWW +
(WW+ ,
cancellationTokenWW, =
)WW= >
;WW> ?
returnYY 
UnitYY 
.YY 
ValueYY 
;YY 
}ZZ 	
}[[ 
}\\ Ø
pC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\Registration\RegistrationVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Account! (
.( )
Command) 0
.0 1
Registration1 =
{ 
public 

class 
RegistrationVm 
{		 
public

 
string

 
Email
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
! "
set

# &
;

& '
}

( )
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
PhoneNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
DateTime 
? 
	BirthDate "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
Gender 
Gender 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
ContractName "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
decimal 
	LeaveDays  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
decimal 
Payment 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
decimal 
Rate 
{ 
get !
;! "
set# &
;& '
}( )
public 
int 
WorkTime 
{ 
get !
;! "
set# &
;& '
}( )
public 
ContractType 
ContractType (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
string 
ZipCode 
{ 
get  #
;# $
set% (
;( )
}* +
public!! 
string!! 
City!! 
{!! 
get!!  
;!!  !
set!!" %
;!!% &
}!!' (
public"" 
string"" 
Street"" 
{"" 
get"" "
;""" #
set""$ '
;""' (
}"") *
public## 
string## 
BuildingNumber## $
{##% &
get##' *
;##* +
set##, /
;##/ 0
}##1 2
public$$ 
string$$ 
HouseNumber$$ !
{$$" #
get$$$ '
;$$' (
set$$) ,
;$$, -
}$$. /
public%% 
string%% 
Country%% 
{%% 
get%%  #
;%%# $
set%%% (
;%%( )
}%%* +
public(( 
List(( 
<(( 
	UserRoles(( 
>(( 
Roles(( $
{((% &
get((' *
;((* +
set((, /
;((/ 0
}((1 2
})) 
}** Ç
yC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\Registration\RegistrationVmValidator.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Account! (
.( )
Command) 0
.0 1
Registration1 =
{ 
public 

class #
RegistrationVmValidator (
:) *
AbstractValidator+ <
<< =
RegistrationVm= K
>K L
{ 
public		 #
RegistrationVmValidator		 &
(		& ' 
IHRMOptimusDbContext		' ;
	dbContext		< E
)		E F
{

 	
RuleFor 
( 
x 
=> 
x 
. 
Email  
)  !
.! "
NotEmpty" *
(* +
)+ ,
., -
EmailAddress- 9
(9 :
): ;
;; <
RuleFor 
( 
x 
=> 
x 
. 
Email  
)  !
. 
Custom 
( 
( 
value 
, 
context  '
)' (
=>) +
{ 
var 

emailInUse "
=# $
	dbContext% .
.. /
ApplicationUsers/ ?
.? @
Any@ C
(C D
eD E
=>F H
eI J
.J K
EmailK P
==Q S
valueT Y
)Y Z
;Z [
if 
( 

emailInUse "
)" #
context 
.  

AddFailure  *
(* +
$str+ 2
,2 3
$str4 I
)I J
;J K
} 
) 
; 
RuleFor 
( 
x 
=> 
x 
. 
Password #
)# $
.$ %
MinimumLength% 2
(2 3
$num3 4
)4 5
;5 6
RuleFor 
( 
x 
=> 
x 
. 
Password #
)# $
. 
Matches 
( 
$str  
)  !
.! "
WithMessage" -
(- .
$str. j
)j k
. 
Matches 
( 
$str  
)  !
.! "
WithMessage" -
(- .
$str. l
)l m
. 
Matches 
( 
$str 
) 
.  
WithMessage  +
(+ ,
$str, _
)_ `
. 
Matches 
( 
$str ?
)? @
.@ A
WithMessageA L
(L M
$str	M å
)
å ç
. 
MinimumLength 
( 
$num  
)  !
;! "
RuleFor 
( 
x 
=> 
x 
. 
	FirstName $
)$ %
.% &
NotEmpty& .
(. /
)/ 0
;0 1
RuleFor 
( 
x 
=> 
x 
. 
LastName #
)# $
.$ %
NotEmpty% -
(- .
). /
;/ 0
RuleFor!! 
(!! 
x!! 
=>!! 
x!! 
.!! 
Roles!!  
)!!  !
.!!! "
NotEmpty!!" *
(!!* +
)!!+ ,
;!!, -
}## 	
}$$ 
}%% •
mC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\SetRoles\SetRolesCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Account! (
.( )
Command) 0
.0 1
SetRoles1 9
{ 
public 

class 
SetRolesCommand  
:! "
IRequest# +
<+ ,
Unit, 0
>0 1
{ 
public 

SetRolesVm 
AddToRoleVm %
{& '
get( +
;+ ,
set- 0
;0 1
}2 3
} 
}		 ƒ
tC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\SetRoles\SetRolesCommandHandler.cs
	namespace

 	

HRMOptimus
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
  !
Account

! (
.

( )
Command

) 0
.

0 1
SetRoles

1 9
{ 
public 

class "
SetRolesCommandHandler '
:( )
IRequestHandler* 9
<9 :
SetRolesCommand: I
,I J
UnitK O
>O P
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
public "
SetRolesCommandHandler %
(% & 
IHRMOptimusDbContext& :
context; B
,B C
UserManagerD O
<O P
ApplicationUserP _
>_ `
userManagera l
)l m
{ 	
_context 
= 
context 
; 
_userManager 
= 
userManager &
;& '
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '
SetRolesCommand' 6
request7 >
,> ?
CancellationToken@ Q
cancellationTokenR c
)c d
{ 	
var 
employee 
= 
_userManager '
.' (
FindByNameAsync( 7
(7 8
request8 ?
.? @
AddToRoleVm@ K
.K L
EmailL Q
)Q R
;R S
if 
( 
employee 
. 
Result 
!=  "
null# '
)' (
{ 
var 
	userRoles 
= 
_userManager  ,
., -
GetRolesAsync- :
(: ;
employee; C
.C D
ResultD J
)J K
.K L
ResultL R
;R S
await 
_userManager "
." # 
RemoveFromRolesAsync# 7
(7 8
employee8 @
.@ A
ResultA G
,G H
	userRolesI R
)R S
;S T
List   
<   
string   
>   
requestRoles   )
=  * +
new  , /
List  0 4
<  4 5
string  5 ;
>  ; <
(  < =
)  = >
;  > ?
foreach!! 
(!! 
var!! 
role!! !
in!!" $
request!!% ,
.!!, -
AddToRoleVm!!- 8
.!!8 9
	UserRoles!!9 B
)!!B C
{"" 
requestRoles##  
.##  !
Add##! $
(##$ %
role##% )
.##) *
ToString##* 2
(##2 3
)##3 4
)##4 5
;##5 6
}$$ 
await%% 
_userManager%% "
.%%" #
AddToRolesAsync%%# 2
(%%2 3
employee%%3 ;
.%%; <
Result%%< B
,%%B C
requestRoles%%D P
)%%P Q
;%%Q R
}&& 
return(( 
Unit(( 
.(( 
Value(( 
;(( 
})) 	
}** 
}++ ±
oC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\SetRoles\SetRolesValidator.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Account! (
.( )
Command) 0
.0 1
SetRoles1 9
{ 
public 

class 
SetRolesValidator "
{ 
} 
} å
hC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Account\Command\SetRoles\SetRolesVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Account! (
.( )
Command) 0
.0 1
SetRoles1 9
{ 
public 

class 

SetRolesVm 
{ 
public 
string 
Email 
{ 
get !
;! "
set# &
;& '
}( )
public		 
List		 
<		 
	UserRoles		 
>		 
	UserRoles		 (
{		) *
get		+ .
;		. /
set		0 3
;		3 4
}		5 6
}

 
} ü
jC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Common\Exceptions\BadRequestException.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Common! '
.' (

Exceptions( 2
{ 
public 

class 
BadRequestException $
:% &
	Exception' 0
{ 
public 
BadRequestException "
(" #
string# )
message* 1
)1 2
:3 4
base5 9
(9 :
message: A
)A B
{ 	
}		 	
}

 
} ‹
hC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Common\Exceptions\NotFoundException.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Common! '
.' (

Exceptions( 2
{ 
public 

class 
NotFoundException "
:# $
	Exception% .
{ 
public 
NotFoundException  
(  !
)! "
: 
base 
( 
) 
{		 	
}

 	
public 
NotFoundException  
(  !
string! '
message( /
)/ 0
: 
base 
( 
message 
) 
{ 	
} 	
public 
NotFoundException  
(  !
string! '
message( /
,/ 0
	Exception1 :
innerException; I
)I J
: 
base 
( 
message 
, 
innerException *
)* +
{ 	
} 	
public 
NotFoundException  
(  !
string! '
name( ,
,, -
object. 4
key5 8
)8 9
: 
base 
( 
$" 
$str 
{ 
name #
}# $
$str$ (
{( )
key) ,
}, -
$str- =
"= >
)> ?
{ 	
} 	
} 
} å
kC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Common\Interfaces\IHRMOptimusDbContext.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Common! '
.' (

Interfaces( 2
{ 
public 

	interface  
IHRMOptimusDbContext )
{		 
public

 
DbSet

 
<

 
Domain

 
.

 
Entities

 $
.

$ %
Project

% ,
>

, -
Projects

. 6
{

7 8
get

9 <
;

< =
set

> A
;

A B
}

C D
public 
DbSet 
< 
Address 
> 
	Addresses '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
DbSet 
< 
Domain 
. 
Entities $
.$ %
Contract% -
>- .
	Contracts/ 8
{9 :
get; >
;> ?
set@ C
;C D
}E F
public 
DbSet 
< 
Domain 
. 
Entities $
.$ %
Employee% -
>- .
	Employees/ 8
{9 :
get; >
;> ?
set@ C
;C D
}E F
public 
DbSet 
< 
ApplicationUser $
>$ %
ApplicationUsers& 6
{7 8
get9 <
;< =
set> A
;A B
}C D
public 
DbSet 
< 
Domain 
. 
Entities $
.$ %
LeaveRegister% 2
>2 3
LeavesRegister4 B
{C D
getE H
;H I
setJ M
;M N
}O P
public 
DbSet 
< 
Domain 
. 
Entities $
.$ %

WorkRecord% /
>/ 0
WorkRecords1 <
{= >
get? B
;B C
setD G
;G H
}I J
Task 
< 
int 
> 
SaveChangesAsync "
(" #
CancellationToken# 4
cancellationToken5 F
)F G
;G H
} 
} À
jC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Common\Interfaces\IUserContextService.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Common! '
.' (

Interfaces( 2
{ 
public 

	interface 
IUserContextService (
{ 
public 
string 
	GetUserId 
{  !
get" %
;% &
}' (
public		 
int		 
?		 
GetEmployeeId		 !
{		" #
get		$ '
;		' (
}		) *
public

 
List

 
<

 
ClaimsPrincipal

 #
>

# $
Roles

% *
{

+ ,
get

- 0
;

0 1
}

2 3
} 
} ∏
nC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Common\Middleware\ErrorHandlingMiddleware.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Common! '
.' (

Middleware( 2
{ 
public		 

class		 #
ErrorHandlingMiddleware		 (
:		) *
IMiddleware		+ 6
{

 
private 
readonly 
ILogger  
<  !#
ErrorHandlingMiddleware! 8
>8 9
_logger: A
;A B
public #
ErrorHandlingMiddleware &
(& '
ILogger' .
<. /#
ErrorHandlingMiddleware/ F
>F G
loggerH N
)N O
{ 	
_logger 
= 
logger 
; 
} 	
public 
async 
Task 
InvokeAsync %
(% &
HttpContext& 1
context2 9
,9 :
RequestDelegate; J
nextK O
)O P
{ 	
try 
{ 
await 
next 
. 
Invoke !
(! "
context" )
)) *
;* +
} 
catch 
( 
BadRequestException &
badRequestException' :
): ;
{ 
context 
. 
Response  
.  !

StatusCode! +
=, -
$num. 1
;1 2
await 
context 
. 
Response &
.& '

WriteAsync' 1
(1 2
badRequestException2 E
.E F
MessageF M
)M N
;N O
} 
catch 
( 
NotFoundException $
notFoundException% 6
)6 7
{ 
context 
. 
Response  
.  !

StatusCode! +
=, -
$num. 1
;1 2
await   
context   
.   
Response   &
.  & '

WriteAsync  ' 1
(  1 2
notFoundException  2 C
.  C D
Message  D K
)  K L
;  L M
}!! 
catch"" 
("" 
	Exception"" 
e"" 
)"" 
{## 
_logger$$ 
.$$ 
LogError$$  
($$  !
e$$! "
,$$" #
e$$$ %
.$$% &
Message$$& -
)$$- .
;$$. /
context&& 
.&& 
Response&&  
.&&  !

StatusCode&&! +
=&&, -
$num&&. 1
;&&1 2
await'' 
context'' 
.'' 
Response'' &
.''& '

WriteAsync''' 1
(''1 2
$str''2 H
)''H I
;''I J
}(( 
})) 	
}** 
}++ ˘
mC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Common\Middleware\RequestTimeMiddleware .cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Common! '
.' (

Middleware( 2
{ 
public 

class !
RequestTimeMiddleware &
:' (
IMiddleware) 4
{		 
private

 
readonly

 
ILogger

  
<

  !!
RequestTimeMiddleware

! 6
>

6 7
_loger

8 >
;

> ?
private 
	Stopwatch 
_stoper !
;! "
public !
RequestTimeMiddleware $
($ %
ILogger% ,
<, -!
RequestTimeMiddleware- B
>B C
logerD I
)I J
{ 	
_loger 
= 
loger 
; 
_stoper 
= 
new 
	Stopwatch #
(# $
)$ %
;% &
} 	
public 
async 
Task 
InvokeAsync %
(% &
HttpContext& 1
context2 9
,9 :
RequestDelegate; J
nextK O
)O P
{ 	
_stoper 
. 
Start 
( 
) 
; 
await 
next 
. 
Invoke 
( 
context %
)% &
;& '
_stoper 
. 
Stop 
( 
) 
; 
if 
( 
_stoper 
. 
ElapsedMilliseconds +
>, -
$num. 2
)2 3
_loger 
. 

LogWarning !
(! "
$"" $
$str$ 1
{1 2
context2 9
.9 :
Request: A
.A B
MethodB H
}H I
$strI M
{M N
contextN U
.U V
RequestV ]
.] ^
Path^ b
}b c
$strc i
{i j
_stoperj q
.q r 
ElapsedMilliseconds	r Ö
/
Ü á
$num
à å
}
å ç
$str
ç è
"
è ê
)
ê ë
;
ë í
} 	
} 
} ﬁ
]C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Common\Models\PageResult.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Common! '
.' (
Models( .
{ 
public 

class 

PageResult 
< 
T 
> 
{ 
public 
IEnumerable 
< 
T 
> 
Items #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public		 
int		 

TotalPages		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
int

 
	ItemsFrom

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
int 
ItemsTo 
{ 
get  
;  !
set" %
;% &
}' (
public 
int 
TotalItemsCount "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 

PageResult 
( 
IEnumerable %
<% &
T& '
>' (
items) .
,. /
int0 3

totalCount4 >
,> ?
int@ C
pageSizeD L
,L M
intN Q

pageNumberR \
)\ ]
{ 	
Items 
= 
items 
; 
TotalItemsCount 
= 

totalCount (
;( )
	ItemsFrom 
= 
pageSize  
*! "
(# $

pageNumber$ .
-/ 0
$num1 2
)2 3
+4 5
$num6 7
;7 8
ItemsTo 
= 
	ItemsFrom 
+  !
pageSize" *
-+ ,
$num- .
;. /

TotalPages 
= 
( 
int 
) 
Math "
." #
Ceiling# *
(* +

totalCount+ 5
/6 7
(8 9
double9 ?
)? @
pageSize@ H
)H I
;I J
} 	
} 
} â	
^C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Common\Models\SearchQuery.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Common! '
.' (
Models( .
{ 
public 

class 
SearchQuery 
{ 
public 
string 
SearchPhrase "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
int 

PageNumber 
{ 
get  #
;# $
set% (
;( )
}* +
public		 
int		 
PageSize		 
{		 
get		 !
;		! "
set		# &
;		& '
}		( )
public

 
string

 
SortBy

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
SortDirection 
SortDirection *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
} 
} æ-
aC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Common\Services\TokenService.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Common! '
.' (
Services( 0
{ 
public 

class 
TokenService 
{ 
private 
readonly  
SymmetricSecurityKey -
_key. 2
;2 3
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
public 
TokenService 
( 
IConfiguration *
config+ 1
,1 2 
IHRMOptimusDbContext3 G
contextH O
,O P
UserManagerQ \
<\ ]
ApplicationUser] l
>l m
userManagern y
)y z
{ 	
_key 
= 
new  
SymmetricSecurityKey +
(+ ,
Encoding, 4
.4 5
UTF85 9
.9 :
GetBytes: B
(B C
configC I
[I J
$strJ T
]T U
)U V
)V W
;W X
_context 
= 
context 
; 
_userManager 
= 
userManager &
;& '
} 	
public 
string 
CreateToken !
(! "
string" (
userId) /
,/ 0
string1 7

employeeId8 B
,B C
stringD J
fullNameK S
,S T
stringU [
gender\ b
)b c
{   	
var!! 
user!! 
=!! 
_context!! 
.!!  
ApplicationUsers!!  0
."" 
Include"" 
("" 
x"" 
=>"" 
x"" 
.""  
Employee""  (
)""( )
.## 
FirstOrDefault## 
(##  
x##  !
=>##" $
x##% &
.##& '
Id##' )
==##* ,
userId##- 3
)##3 4
;##4 5
var%% 
roles%% 
=%% 
_userManager%% $
.%%$ %
GetRolesAsync%%% 2
(%%2 3
user%%3 7
)%%7 8
;%%8 9
var&& 
claims&& 
=&& 
new&& 
List&& !
<&&! "
Claim&&" '
>&&' (
(&&( )
)&&) *
;&&* +
claims'' 
.'' 
Add'' 
('' 
new'' 
Claim''  
(''  !
$str''! )
,'') *
userId''+ 1
)''1 2
)''2 3
;''3 4
claims(( 
.(( 
Add(( 
((( 
new(( 
Claim((  
(((  !
$str((! -
,((- .
user((/ 3
.((3 4
Employee((4 <
.((< =
Id((= ?
.((? @
ToString((@ H
(((H I
)((I J
)((J K
)((K L
;((L M
claims)) 
.)) 
Add)) 
()) 
new)) 
Claim))  
())  !
$str))! +
,))+ ,
user))- 1
.))1 2
Employee))2 :
.)): ;
FullName)); C
.))C D
ToString))D L
())L M
)))M N
)))N O
)))O P
;))P Q
claims** 
.** 
Add** 
(** 
new** 
Claim**  
(**  !
$str**! )
,**) *
(**+ ,
(**, -
int**- 0
)**0 1
user**1 5
.**5 6
Employee**6 >
.**> ?
Gender**? E
)**E F
.**F G
ToString**G O
(**O P
)**P Q
)**Q R
)**R S
;**S T
foreach,, 
(,, 
var,, 
role,, 
in,,  
roles,,! &
.,,& '
Result,,' -
),,- .
{-- 
claims.. 
... 
Add.. 
(.. 
new.. 
Claim.. $
(..$ %
$str..% +
,..+ ,
role.., 0
)..0 1
)..1 2
;..2 3
}// 
var11 
creds11 
=11 
new11 
SigningCredentials11 .
(11. /
_key11/ 3
,113 4
SecurityAlgorithms115 G
.11G H
HmacSha512Signature11H [
)11[ \
;11\ ]
var33 
tokenDescriptor33 
=33  !
new33" %#
SecurityTokenDescriptor33& =
{44 
Subject55 
=55 
new55 
ClaimsIdentity55 ,
(55, -
claims55- 3
)553 4
,554 5
Expires66 
=66 
DateTime66 "
.66" #
Now66# &
.66& '
AddDays66' .
(66. /
$num66/ 0
)660 1
,661 2
SigningCredentials77 "
=77# $
creds77% *
}88 
;88 
var:: 
tokenHandler:: 
=:: 
new:: "#
JwtSecurityTokenHandler::# :
(::: ;
)::; <
;::< =
var<< 
token<< 
=<< 
tokenHandler<< $
.<<$ %
CreateToken<<% 0
(<<0 1
tokenDescriptor<<1 @
)<<@ A
;<<A B
return>> 
tokenHandler>> 
.>>  

WriteToken>>  *
(>>* +
token>>+ 0
)>>0 1
;>>1 2
}?? 	
}@@ 
}AA –
gC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Common\Services\UserContextService.cs
	namespace

 	

HRMOptimus
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
  !
Common

! '
.

' (
Services

( 0
{ 
public 

class 
UserContextService #
:$ %
IUserContextService& 9
{ 
private 
readonly 
string 
_token  &
;& '
private 
int 
? 
_employeeId  
;  !
private 
string 
_userId 
; 
public 
UserContextService !
(! " 
IHttpContextAccessor" 6
httpContextAccessor7 J
)J K
{ 	
_token 
= 
httpContextAccessor (
.( )
HttpContext) 4
.4 5
Request5 <
.< =
Headers= D
[D E
HeaderNamesE P
.P Q
AuthorizationQ ^
]^ _
._ `
ToString` h
(h i
)i j
.j k
Replacek r
(r s
$strs |
,| }
$str	~ Ä
)
Ä Å
;
Å Ç
if 
( 
! 
string 
. 
IsNullOrWhiteSpace *
(* +
_token+ 1
)1 2
)2 3
decodeToken 
( 
) 
; 
} 	
private 
void 
decodeToken  
(  !
)! "
{ 	
var 
handler 
= 
new #
JwtSecurityTokenHandler 5
(5 6
)6 7
;7 8
var 
	jsonToken 
= 
handler #
.# $
ReadJwtToken$ 0
(0 1
_token1 7
)7 8
;8 9
_employeeId 
= 
int 
. 
Parse #
(# $
	jsonToken$ -
.- .
Payload. 5
.5 6
First6 ;
(; <
claim< A
=>B D
claimE J
.J K
KeyK N
==O Q
$strR ^
)^ _
._ `
Value` e
.e f
ToStringf n
(n o
)o p
)p q
;q r
_userId 
= 
	jsonToken 
.  
Payload  '
.' (
First( -
(- .
claim. 3
=>4 6
claim7 <
.< =
Key= @
==A C
$strD L
)L M
.M N
ValueN S
.S T
ToStringT \
(\ ]
)] ^
;^ _
} 	
public!! 
string!! 
	GetUserId!! 
=>!!  "
string!!# )
.!!) *
IsNullOrWhiteSpace!!* <
(!!< =
_userId!!= D
)!!D E
?!!F G
null!!H L
:!!M N
_userId!!O V
;!!V W
public## 
int## 
?## 
GetEmployeeId## !
=>##" $
_employeeId##% 0
==##1 3
$num##4 5
||##6 8
_employeeId##9 D
==##E G
null##H L
?##M N
$num##O P
:##Q R
(##S T
int##T W
)##W X
_employeeId##X c
;##c d
public%% 
List%% 
<%% 
ClaimsPrincipal%% #
>%%# $
Roles%%% *
{%%+ ,
get%%- 0
=>%%1 3
throw%%4 9
new%%: =#
NotImplementedException%%> U
(%%U V
)%%V W
;%%W X
set%%Y \
=>%%] _
throw%%` e
new%%f i$
NotImplementedException	%%j Å
(
%%Å Ç
)
%%Ç É
;
%%É Ñ
}
%%Ö Ü
}&& 
}'' é
vC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Contract\Command\EditContract\EditContractCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Contract! )
.) *
Command* 1
.1 2
EditContract2 >
{ 
public 

class 
EditContractCommand $
:% &
IRequest' /
{ 
public 
EditContractVm 
EditContractVm ,
{- .
get/ 2
;2 3
set4 7
;7 8
}9 :
} 
}		 „&
}C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Contract\Command\EditContract\EditContractCommandHandler.cs
	namespace

 	

HRMOptimus
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
  !
Contract

! )
.

) *
Command

* 1
.

1 2
EditContract

2 >
{ 
public 

class &
EditContractCommandHandler +
:, -
IRequestHandler. =
<= >
EditContractCommand> Q
,Q R
UnitS W
>W X
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public &
EditContractCommandHandler )
() * 
IHRMOptimusDbContext* >
context? F
)F G
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '
EditContractCommand' :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 	
var 
contractToEdit 
=  
_context! )
.) *
	Contracts* 3
.3 4
FirstOrDefault4 B
(B C
xC D
=>E G
xH I
.I J
IdJ L
==M O
requestP W
.W X
EditContractVmX f
.f g

ContractIdg q
)q r
;r s
contractToEdit 
. 
ContractName '
=( )
! 
string 
. 
IsNullOrWhiteSpace *
(* +
request+ 2
.2 3
EditContractVm3 A
.A B
ContractNameB N
)N O
?P Q
requestR Y
.Y Z
EditContractVmZ h
.h i
ContractNamei u
:v w
contractToEdit	x Ü
.
Ü á
ContractName
á ì
;
ì î
contractToEdit 
. 
	LeaveDays $
=% &
request 
. 
EditContractVm %
.% &
	LeaveDays& /
./ 0
HasValue0 8
?9 :
request; B
.B C
EditContractVmC Q
.Q R
	LeaveDaysR [
.[ \
Value\ a
:b c
contractToEditd r
.r s
	LeaveDayss |
;| }
contractToEdit 
. 
Payment "
=# $
request 
. 
EditContractVm &
.& '
Payment' .
.. /
HasValue/ 7
?8 9
request: A
.A B
EditContractVmB P
.P Q
PaymentQ X
.X Y
ValueY ^
:_ `
contractToEdita o
.o p
Paymentp w
;w x
contractToEdit!! 
.!! 
Rate!! 
=!!  !
request"" 
."" 
EditContractVm"" &
.""& '
Rate""' +
.""+ ,
HasValue"", 4
?""5 6
request""7 >
.""> ?
EditContractVm""? M
.""M N
Rate""N R
.""R S
Value""S X
:""Y Z
contractToEdit""[ i
.""i j
Rate""j n
;""n o
contractToEdit$$ 
.$$ 
WorkTime$$ #
=$$$ %
request%% 
.%% 
EditContractVm%% &
.%%& '
WorkTime%%' /
.%%/ 0
HasValue%%0 8
?%%9 :
request%%; B
.%%B C
EditContractVm%%C Q
.%%Q R
WorkTime%%R Z
.%%Z [
Value%%[ `
:%%a b
contractToEdit%%c q
.%%q r
WorkTime%%r z
;%%z {
contractToEdit'' 
.'' 
ContractType'' '
=''( )
request(( 
.(( 
EditContractVm(( &
.((& '
ContractType((' 3
!=((4 6
contractToEdit((7 E
.((E F
ContractType((F R
?((S T
request((U \
.((\ ]
EditContractVm((] k
.((k l
ContractType((l x
:((y z
contractToEdit	(({ â
.
((â ä
ContractType
((ä ñ
;
((ñ ó
_context** 
.** 
	Contracts** 
.** 
Update** %
(**% &
contractToEdit**& 4
)**4 5
;**5 6
await,, 
_context,, 
.,, 
SaveChangesAsync,, +
(,,+ ,
cancellationToken,,, =
),,= >
;,,> ?
return.. 
Unit.. 
... 
Value.. 
;.. 
}// 	
}00 
}11 ö
xC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Contract\Command\EditContract\EditContractValidator.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Contract! )
.) *
Command* 1
.1 2
EditContract2 >
{ 
public 

class !
EditContractValidator &
:' (
AbstractValidator) :
<: ;
EditContractVm; I
>I J
{ 
public		 !
EditContractValidator		 $
(		$ % 
IHRMOptimusDbContext		% 9
	dbContext		: C
)		C D
{

 	
RuleFor 
( 
x 
=> 
x 
. 

ContractId %
)% &
.& '
NotEmpty' /
(/ 0
)0 1
.1 2
Custom2 8
(8 9
(9 :
value: ?
,? @
contextA H
)H I
=>J L
{ 
var 
contract 
= 
	dbContext (
.( )
	Contracts) 2
.2 3
Any3 6
(6 7
e7 8
=>9 ;
e< =
.= >
Id> @
==A C
valueD I
&&J L
eM N
.N O
EnabledO V
)V W
;W X
if 
( 
! 
contract 
) 
context 
. 

AddFailure &
(& '
$str' +
,+ ,
$str- E
+F G
valueH M
+N O
$strP `
)` a
;a b
} 
) 
; 
} 	
} 
} æ
qC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Contract\Command\EditContract\EditContractVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Contract! )
.) *
Command* 1
.1 2
EditContract2 >
{ 
public 

class 
EditContractVm 
{ 
public 
int 

ContractId 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
ContractName "
{# $
get% (
;( )
set* -
;- .
}/ 0
public		 
decimal		 
?		 
	LeaveDays		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
public

 
decimal

 
?

 
Payment

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
decimal 
? 
Rate 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 
? 
WorkTime 
{ 
get "
;" #
set$ '
;' (
}) *
public 
ContractType 
ContractType (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
} »+
XC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\DependencyInjection.cs
	namespace 	

HRMOptimus
 
. 
Application  
{ 
public 

static 
class 
DependencyInjection +
{ 
public 
static 
IServiceCollection (
AddApplication) 7
(7 8
this8 <
IServiceCollection= O
servicesP X
,X Y
IConfigurationZ h
configurationi v
)v w
{ 	
services 
. 
AddControllers #
(# $
)$ %
.% &
AddFluentValidation& 9
(9 :
): ;
;; <
services 
. 
AddAutoMapper "
(" #
Assembly# +
.+ , 
GetExecutingAssembly, @
(@ A
)A B
)B C
;C D
services 
. 

AddMediatR 
(  
Assembly  (
.( ) 
GetExecutingAssembly) =
(= >
)> ?
)? @
;@ A
services 
. 
	AddScoped 
< !
RequestTimeMiddleware 4
>4 5
(5 6
)6 7
;7 8
services   
.   
	AddScoped   
<   #
ErrorHandlingMiddleware   6
>  6 7
(  7 8
)  8 9
;  9 :
services!! 
.!! "
AddHttpContextAccessor!! +
(!!+ ,
)!!, -
;!!- .
services"" 
."" 
	AddScoped"" 
<"" 
IUserContextService"" 2
,""2 3
UserContextService""4 F
>""F G
(""G H
)""H I
;""I J
services## 
.## 
	AddScoped## 
<## 
TokenService## +
>##+ ,
(##, -
)##- .
.##. /
	Configure##/ 8
<##8 9
IConfiguration##9 G
>##G H
(##H I
(##I J
config##J P
)##P Q
=>##R T
{$$ 
configuration%% 
.%% 

GetSection%% (
(%%( )
$str%%) 3
)%%3 4
.%%4 5
Bind%%5 9
(%%9 :
config%%: @
)%%@ A
;%%A B
}&& 
)&& 
;&& 
services(( 
.(( 
	AddScoped(( 
<(( 

IValidator(( )
<(() *
RegistrationVm((* 8
>((8 9
,((9 :#
RegistrationVmValidator((; R
>((R S
(((S T
)((T U
;((U V
services)) 
.)) 
	AddScoped)) 
<)) 

IValidator)) )
<))) *
UpdateProjectVm))* 9
>))9 :
,)): ;$
UpdateProjectVmValidator))< T
>))T U
())U V
)))V W
;))W X
services** 
.** 
	AddScoped** 
<** 

IValidator** )
<**) *
AddProjectVm*** 6
>**6 7
,**7 8!
AddProjectVmValidator**9 N
>**N O
(**O P
)**P Q
;**Q R
services++ 
.++ 
	AddScoped++ 
<++ 

IValidator++ )
<++) *
AddWorkRecordVm++* 9
>++9 :
,++: ;$
AddWorkRecordVmValidator++< T
>++T U
(++U V
)++V W
;++W X
services,, 
.,, 
	AddScoped,, 
<,, 

IValidator,, )
<,,) *
UpdateWorkRecordVm,,* <
>,,< =
,,,= >'
UpdateWorkRecordVmValidator,,? Z
>,,Z [
(,,[ \
),,\ ]
;,,] ^
services-- 
.-- 
	AddScoped-- 
<-- 

IValidator-- )
<--) *
EditEmployeeVm--* 8
>--8 9
,--9 :#
EditEmployeeVmValidator--; R
>--R S
(--S T
)--T U
;--U V
services.. 
... 
	AddScoped.. 
<.. 

IValidator.. )
<..) *#
RemoveWorkRecordCommand..* A
>..A B
,..B C,
 RemoveWorkRecordCommandValidator..D d
>..d e
(..e f
)..f g
;..g h
services// 
.// 
	AddScoped// 
<// 

IValidator// )
<//) *
AddEmployeeVm//* 7
>//7 8
,//8 9"
AddEmployeeVmValidator//: P
>//P Q
(//Q R
)//R S
;//S T
services00 
.00 
	AddScoped00 
<00 

IValidator00 )
<00) * 
RemoveProjectCommand00* >
>00> ?
,00? @)
RemoveProjectCommandValidator00A ^
>00^ _
(00_ `
)00` a
;00a b
services11 
.11 
	AddScoped11 
<11 

IValidator11 )
<11) *'
ChangeStatusLeaveRegisterVm11* E
>11E F
,11F G0
$ChangeStatusLeaveRegisterVmValidator11H l
>11l m
(11m n
)11n o
;11o p
services22 
.22 
	AddScoped22 
<22 

IValidator22 )
<22) *
EditContractVm22* 8
>228 9
,229 :!
EditContractValidator22; P
>22P Q
(22Q R
)22R S
;22S T
return44 
services44 
;44 
}55 	
}66 
}77 à
vC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Command\EditEmployee\EditEmployeeCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Command* 1
.1 2
EditEmployee2 >
{ 
public 

class 
EditEmployeeCommand $
:% &
IRequest' /
{ 
public 
EditEmployeeVm 
Employee &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
}		 
}

 √E
}C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Command\EditEmployee\EditEmployeeCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Command* 1
.1 2
EditEmployee2 >
{		 
public

 

class

 &
EditEmployeeCommandHandler

 +
:

, -
IRequestHandler

. =
<

= >
EditEmployeeCommand

> Q
,

Q R
Unit

S W
>

W X
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public &
EditEmployeeCommandHandler )
() * 
IHRMOptimusDbContext* >
context? F
)F G
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '
EditEmployeeCommand' :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 	
var 
user 
= 
_context 
.  
	Employees  )
. 
Include 
( 
a 
=> 
a 
.  
Address  '
)' (
. 
Include 
( 
app 
=> 
app  #
.# $
ApplicationUser$ 3
)3 4
. 
FirstOrDefault 
(  
x  !
=>" $
x% &
.& '
Id' )
==* ,
request- 4
.4 5
Employee5 =
.= >

EmployeeId> H
)H I
;I J
var "
updatedApplicationUser &
=' (
user) -
.- .
ApplicationUser. =
;= >"
updatedApplicationUser "
." #
PhoneNumber# .
=/ 0
! 
string 
. 
IsNullOrWhiteSpace *
(* +
request+ 2
.2 3
Employee3 ;
.; <
PhoneNumber< G
)G H
?I J
requestK R
.R S
EmployeeS [
.[ \
PhoneNumber\ g
:h i#
updatedApplicationUser	j Ä
.
Ä Å
PhoneNumber
Å å
;
å ç
var 
updatedEmployee 
=  !
user" &
;& '
updatedEmployee 
. 
	FirstName %
=& '
!   
string   
.   
IsNullOrWhiteSpace   *
(  * +
request  + 2
.  2 3
Employee  3 ;
.  ; <
	FirstName  < E
)  E F
?  G H
request  I P
.  P Q
Employee  Q Y
.  Y Z
	FirstName  Z c
:  d e
updatedEmployee  f u
.  u v
	FirstName  v 
;	   Ä
updatedEmployee"" 
."" 
LastName"" $
=""% &
!## 
string## 
.## 
IsNullOrWhiteSpace## )
(##) *
request##* 1
.##1 2
Employee##2 :
.##: ;
LastName##; C
)##C D
?##E F
request##G N
.##N O
Employee##O W
.##W X
LastName##X `
:##a b
updatedEmployee##c r
.##r s
LastName##s {
;##{ |
updatedEmployee%% 
.%% 
	BirthDate%% %
=%%& '
request&& 
.&& 
Employee&&  
.&&  !
	BirthDate&&! *
.&&* +
HasValue&&+ 3
?&&4 5
request&&6 =
.&&= >
Employee&&> F
.&&F G
	BirthDate&&G P
.&&P Q
Value&&Q V
:&&W X
updatedEmployee&&Y h
.&&h i
	BirthDate&&i r
;&&r s
updatedEmployee(( 
.(( 
Gender(( "
=((# $
request)) 
.)) 
Employee))  
.))  !
Gender))! '
.))' (
HasValue))( 0
?))1 2
request))3 :
.)): ;
Employee)); C
.))C D
Gender))D J
.))J K
Value))K P
:))Q R
updatedEmployee))S b
.))b c
Gender))c i
;))i j
var++ 
updatedAddress++ 
=++  
updatedEmployee++! 0
.++0 1
Address++1 8
;++8 9
updatedAddress-- 
.-- 
ZipCode-- "
=--# $
!.. 
string.. 
... 
IsNullOrWhiteSpace.. )
(..) *
request..* 1
...1 2
Employee..2 :
...: ;
ZipCode..; B
)..B C
?..D E
request..F M
...M N
Employee..N V
...V W
ZipCode..W ^
:.._ `
updatedAddress..a o
...o p
ZipCode..p w
;..w x
updatedAddress00 
.00 
City00 
=00  !
!11 
string11 
.11 
IsNullOrWhiteSpace11 (
(11( )
request11) 0
.110 1
Employee111 9
.119 :
City11: >
)11> ?
?11@ A
request11B I
.11I J
Employee11J R
.11R S
City11S W
:11X Y
updatedAddress11Z h
.11h i
City11i m
;11m n
updatedAddress33 
.33 
Street33 !
=33" #
!44 
string44 
.44 
IsNullOrWhiteSpace44 (
(44( )
request44) 0
.440 1
Employee441 9
.449 :
Street44: @
)44@ A
?44B C
request44D K
.44K L
Employee44L T
.44T U
Street44U [
:44\ ]
updatedAddress44^ l
.44l m
Street44m s
;44s t
updatedAddress66 
.66 
BuildingNumber66 )
=66* +
!77 
string77 
.77 
IsNullOrWhiteSpace77 (
(77( )
request77) 0
.770 1
Employee771 9
.779 :
BuildingNumber77: H
)77H I
?77J K
request77L S
.77S T
Employee77T \
.77\ ]
BuildingNumber77] k
:77l m
updatedAddress77n |
.77| }
BuildingNumber	77} ã
;
77ã å
updatedAddress99 
.99 
HouseNumber99 &
=99' (
!:: 
string:: 
.:: 
IsNullOrWhiteSpace:: (
(::( )
request::) 0
.::0 1
Employee::1 9
.::9 :
HouseNumber::: E
)::E F
?::G H
request::I P
.::P Q
Employee::Q Y
.::Y Z
HouseNumber::Z e
:::f g
updatedAddress::h v
.::v w
HouseNumber	::w Ç
;
::Ç É
updatedAddress<< 
.<< 
Country<< "
=<<# $
!== 
string== 
.== 
IsNullOrWhiteSpace== (
(==( )
request==) 0
.==0 1
Employee==1 9
.==9 :
Country==: A
)==A B
?==C D
request==E L
.==L M
Employee==M U
.==U V
Country==V ]
:==^ _
updatedAddress==` n
.==n o
Country==o v
;==v w
var?? 
employee?? 
=?? 
_context?? #
.??# $
	Employees??$ -
.??- .
FirstOrDefault??. <
(??< =
e??= >
=>??? A
e??B C
.??C D
Id??D F
==??G I
updatedEmployee??J Y
.??Y Z
Id??Z \
)??\ ]
;??] ^
_contextAA 
.AA 
	EmployeesAA 
.AA 
UpdateAA %
(AA% &
updatedEmployeeAA& 5
)AA5 6
;AA6 7
_contextBB 
.BB 
	AddressesBB 
.BB 
UpdateBB %
(BB% &
updatedEmployeeBB& 5
.BB5 6
AddressBB6 =
)BB= >
;BB> ?
_contextCC 
.CC 
ApplicationUsersCC %
.CC% &
UpdateCC& ,
(CC, -"
updatedApplicationUserCC- C
)CCC D
;CCD E
awaitEE 
_contextEE 
.EE 
SaveChangesAsyncEE +
(EE+ ,
cancellationTokenEE, =
)EE= >
;EE> ?
returnFF 
UnitFF 
.FF 
ValueFF 
;FF 
}GG 	
}HH 
}II ®
qC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Command\EditEmployee\EditEmployeeVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Command* 1
.1 2
EditEmployee2 >
{ 
public 

class 
EditEmployeeVm 
{ 
public 
int 

EmployeeId 
{ 
get  #
;# $
set% (
;( )
}* +
public

 
string

 
	FirstName

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
DateTime 
? 
	BirthDate "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
Gender 
? 
Gender 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
ZipCode 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
City 
{ 
get  
;  !
set" %
;% &
}' (
public 
string 
Street 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
BuildingNumber $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public 
string 
HouseNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
string 
Country 
{ 
get  #
;# $
set% (
;( )
}* +
public 
string 
PhoneNumber !
{" #
get$ '
;' (
set) ,
;, -
}. /
} 
} ¡
zC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Command\EditEmployee\EditEmployeeVmValidator.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Command* 1
.1 2
EditEmployee2 >
{ 
public 

class #
EditEmployeeVmValidator (
:) *
AbstractValidator+ <
<< =
EditEmployeeVm= K
>K L
{		 
public

 #
EditEmployeeVmValidator

 &
(

& ' 
IHRMOptimusDbContext

' ;
	dbContext

< E
)

E F
{ 	
RuleFor 
( 
x 
=> 
x 
. 

EmployeeId %
)% &
.& '
NotEmpty' /
(/ 0
)0 1
.1 2
Custom2 8
(8 9
(9 :
value: ?
,? @
contextA H
)H I
=>J L
{ 
var 
employee 
= 
	dbContext (
.( )
	Employees) 2
.2 3
Any3 6
(6 7
e7 8
=>9 ;
e< =
.= >
Id> @
==A C
valueD I
&&J L
eM N
.N O
EnabledO V
)V W
;W X
if 
( 
! 
employee 
) 
context 
. 

AddFailure &
(& '
$str' +
,+ ,
$str- E
+F G
valueH M
+N O
$strP `
)` a
;a b
} 
) 
; 
RuleFor 
( 
x 
=> 
x 
. 
Gender !
)! "
." #
Custom# )
() *
(* +
gender+ 1
,1 2
context3 :
): ;
=>< >
{ 
if 
( 
! 
Enum 
. 
	IsDefined #
(# $
gender$ *
.* +
Value+ 0
)0 1
)1 2
context 
. 

AddFailure &
(& '
$"' )
$str) @
{@ A
genderA G
.G H
ValueH M
}M N
$strN ]
"] ^
)^ _
;_ `
} 
) 
; 
} 	
} 
} á
zC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Command\RemoveEmployee\RemoveEmployeeCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Command* 1
.1 2
RemoveEmployee2 @
{ 
public 

class !
RemoveEmployeeCommand &
:' (
IRequest) 1
{ 
public 
int 

EmployeeId 
{ 
get  #
;# $
set% (
;( )
}* +
} 
}		 ∆
ÅC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Command\RemoveEmployee\RemoveEmployeeCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Command* 1
.1 2
RemoveEmployee2 @
{		 
public

 

class

 (
RemoveEmployeeCommandHandler

 -
:

. /
IRequestHandler

0 ?
<

? @!
RemoveEmployeeCommand

@ U
>

U V
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public (
RemoveEmployeeCommandHandler +
(+ , 
IHRMOptimusDbContext, @
contextA H
)H I
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '!
RemoveEmployeeCommand' <
request= D
,D E
CancellationTokenF W
cancellationTokenX i
)i j
{ 	
var 
employee 
= 
await  
_context! )
.) *
	Employees* 3
.3 4
FirstOrDefaultAsync4 G
(G H
xH I
=>J L
xM N
.N O
IdO Q
==R T
requestU \
.\ ]

EmployeeId] g
)g h
;h i
var 
applicationUser 
=  !
await" '
_context( 0
.0 1
ApplicationUsers1 A
.A B
FirstOrDefaultAsyncB U
(U V
xV W
=>X Z
x[ \
.\ ]

EmployeeId] g
==h j
requestk r
.r s

EmployeeIds }
)} ~
;~ 
if 
( 
employee 
== 
null  
||! #
applicationUser$ 3
==4 6
null7 ;
); <
throw 
new 
NotFoundException +
(+ ,
$str, L
+M N
requestO V
.V W

EmployeeIdW a
)a b
;b c
_context 
. 
	Employees 
. 
Remove %
(% &
employee& .
). /
;/ 0
_context 
. 
ApplicationUsers %
.% &
Remove& ,
(, -
applicationUser- <
)< =
;= >
await 
_context 
. 
SaveChangesAsync +
(+ ,
cancellationToken, =
)= >
;> ?
return 
Unit 
. 
Value 
; 
}   	
}!! 
}"" Á
xC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Query\EmployeeDetails\EmployeeDetailsQuery.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Query* /
./ 0
EmployeeDetails0 ?
{ 
public 

class  
EmployeeDetailsQuery %
:& '
IRequest( 0
<0 1
EmployeeDetailsVm1 B
>B C
{ 
public 
int 
? 

EmployeeId 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
}		 
}

 ∞3
C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Query\EmployeeDetails\EmployeeDetailsQueryHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Query* /
./ 0
EmployeeDetails0 ?
{ 
public 

class !
EmployeesQueryHandler &
:' (
IRequestHandler) 8
<8 9 
EmployeeDetailsQuery9 M
,M N
EmployeeDetailsVmO `
>` a
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
private 
readonly 
UserManager $
<$ %
ApplicationUser% 4
>4 5
_userManager6 B
;B C
private 
Domain 
. 
Entities 
.  
Employee  (
	_employee) 2
;2 3
public !
EmployeesQueryHandler $
($ % 
IHRMOptimusDbContext% 9
context: A
,A B
UserManagerC N
<N O
ApplicationUserO ^
>^ _
userManager` k
)k l
{ 	
_context 
= 
context 
; 
_userManager 
= 
userManager &
;& '
} 	
public 
async 
Task 
< 
EmployeeDetailsVm +
>+ ,
Handle- 3
(3 4 
EmployeeDetailsQuery4 H
requestI P
,P Q
CancellationTokenR c
cancellationTokend u
)u v
{ 	
List 
< 
string 
> 
roles 
=  
new! $
List% )
<) *
string* 0
>0 1
(1 2
)2 3
;3 4
if 
( 
request 
. 

EmployeeId "
==# %
null& *
)* +
{ 
var 
fullName 
= 
request &
.& '
Name' +
.+ ,
ToLower, 3
(3 4
)4 5
;5 6
	_employee!! 
=!! 
await!! !
_context!!" *
.!!* +
	Employees!!+ 4
."" 
Where"" 
("" 
x"" 
=>"" 
x""  !
.""! "
Enabled""" )
)"") *
.## 
Include## 
(## 
x## 
=>## !
x##" #
.### $
Address##$ +
)##+ ,
.$$ 
Include$$ 
($$ 
x$$ 
=>$$ !
x$$" #
.$$# $
Contract$$$ ,
)$$, -
.%% 
Include%% 
(%% 
x%% 
=>%% !
x%%" #
.%%# $
ApplicationUser%%$ 3
)%%3 4
.&& 
FirstOrDefaultAsync&& (
(&&( )
x&&) *
=>&&+ -
x&&. /
.&&/ 0
FullName&&0 8
.&&8 9
ToLower&&9 @
(&&@ A
)&&A B
.&&B C
Contains&&C K
(&&K L
fullName&&L T
)&&T U
)&&U V
;&&V W
roles(( 
=(( 
_userManager(( $
.(($ %
GetRolesAsync((% 2
(((2 3
	_employee((3 <
.((< =
ApplicationUser((= L
)((L M
.((M N
Result((N T
.((T U
ToList((U [
((([ \
)((\ ]
;((] ^
})) 
else** 
{++ 
	_employee,, 
=,, 
await,, !
_context,," *
.,,* +
	Employees,,+ 4
.-- 
Where-- 
(-- 
x-- 
=>-- 
x--  
.--  !
Enabled--! (
)--( )
... 
Include.. 
(.. 
x.. 
=>..  
x..! "
..." #
Address..# *
)..* +
.// 
Include// 
(// 
x// 
=>//  
x//! "
.//" #
Contract//# +
)//+ ,
.00 
Include00 
(00 
x00 
=>00  
x00! "
.00" #
ApplicationUser00# 2
)002 3
.11 
FirstOrDefaultAsync11 '
(11' (
x11( )
=>11* ,
x11- .
.11. /
Id11/ 1
==112 4
request115 <
.11< =

EmployeeId11= G
)11G H
;11H I
roles33 
=33 
_userManager33 $
.33$ %
GetRolesAsync33% 2
(332 3
	_employee333 <
.33< =
ApplicationUser33= L
)33L M
.33M N
Result33N T
.33T U
ToList33U [
(33[ \
)33\ ]
;33] ^
}44 
if66 
(66 
	_employee66 
==66 
null66 !
)66! "
throw77 
new77 
NotFoundException77 +
(77+ ,
$str77, L
+77M N
request77O V
.77V W

EmployeeId77W a
+77b c
$str77d t
+77u v
request77w ~
.77~ 
Name	77 É
)
77É Ñ
;
77Ñ Ö
return99 
new99 
EmployeeDetailsVm99 (
(99( )
	_employee99) 2
.992 3
	FirstName993 <
,99< =
	_employee99> G
.99G H
LastName99H P
,99P Q
	_employee99R [
.99[ \
FullName99\ d
,99d e
	_employee99f o
.99o p
Gender99p v
,99v w
	_employee	99x Å
.
99Å Ç
	BirthDate
99Ç ã
,
99ã å
	_employee:: 
.:: 
LeaveDaysLeft:: 
,::  
	_employee::! *
.::* +
WorkingTime::+ 6
,::6 7
	_employee::8 A
.::A B
Contract::B J
,::J K
	_employee::L U
.::U V
Address::V ]
,::] ^
	_employee::_ h
.::h i
ApplicationUser::i x
.::x y
Email::y ~
,::~ 
	_employee;; 
.;; 
ApplicationUser;; !
.;;! "
PhoneNumber;;" -
,;;- .
roles;;. 3
);;3 4
;;;4 5
}<< 	
}== 
}>> ç

uC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Query\EmployeeDetails\EmployeeDetailsVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Query* /
./ 0
EmployeeDetails0 ?
{ 
public 

record 
EmployeeDetailsVm #
(# $
string$ *
	FirstName+ 4
,4 5
string6 <
LastName= E
,E F
stringG M
FullNameN V
,V W
GenderX ^
Gender_ e
,e f
DateTimeg o
?o p
	BirthDateq z
,z {
decimal		 
LeaveDaysLeft		 
,		 
decimal		 &
WorkingTime		' 2
,		2 3
Domain		4 :
.		: ;
Entities		; C
.		C D
Contract		D L
Contract		M U
,		U V
Address		W ^
Address		_ f
,		f g
string		h n
Email		o t
,		t u
string		v |
PhoneNumber			} à
,
		à â
List
		ä é
<
		é è
string
		è ï
>
		ï ñ
roles
		ó ú
)
		ú ù
;
		ù û
}

 ⁄
lC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Query\Employees\EmployeesQuery.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Query* /
./ 0
	Employees0 9
{ 
public 

class 
EmployeesQuery 
:  !
IRequest" *
<* +

PageResult+ 5
<5 6

EmployeeVm6 @
>@ A
>A B
{ 
public 
SearchQuery 
Query  
{! "
get# &
;& '
set( +
;+ ,
}- .
}		 
}

 €6
sC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Query\Employees\EmployeesQueryHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Query* /
./ 0
	Employees0 9
{ 
public 

class !
EmployeesQueryHandler &
:' (
IRequestHandler) 8
<8 9
EmployeesQuery9 G
,G H

PageResultI S
<S T

EmployeeVmT ^
>^ _
>_ `
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public !
EmployeesQueryHandler $
($ % 
IHRMOptimusDbContext% 9
context: A
)A B
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 

PageResult $
<$ %

EmployeeVm% /
>/ 0
>0 1
Handle2 8
(8 9
EmployeesQuery9 G
requestH O
,O P
CancellationTokenQ b
cancellationTokenc t
)t u
{ 	
var 
	baseQuery 
= 
_context $
. 
	Employees 
. 
Where 
( 
r 
=> 
r 
. 
Enabled %
)% &
. 
Include 
( 
x 
=> 
x 
.  
ApplicationUser  /
)/ 0
. 
Include 
( 
x 
=> 
x 
.  
Contract  (
)( )
. 
Where 
( 
r 
=> 
request #
.# $
Query$ )
.) *
SearchPhrase* 6
==7 9
null: >
||   
(   
r   
.   
FullName   "
.  " #
ToLower  # *
(  * +
)  + ,
.  , -
Contains  - 5
(  5 6
request  6 =
.  = >
Query  > C
.  C D
SearchPhrase  D P
.  P Q
ToLower  Q X
(  X Y
)  Y Z
)  Z [
||!! 
r!! 
.!! 
ApplicationUser!! (
.!!( )
Email!!) .
.!!. /
ToLower!!/ 6
(!!6 7
)!!7 8
.!!8 9
Contains!!9 A
(!!A B
request!!B I
.!!I J
Query!!J O
.!!O P
SearchPhrase!!P \
.!!\ ]
ToLower!!] d
(!!d e
)!!e f
)!!f g
)!!g h
)!!h i
;!!i j
if## 
(## 
!## 
string## 
.## 
IsNullOrEmpty## %
(##% &
request##& -
.##- .
Query##. 3
.##3 4
SortBy##4 :
)##: ;
)##; <
{$$ 
var%% 
columnsSelectors%% $
=%%% &
new%%' *

Dictionary%%+ 5
<%%5 6
string%%6 <
,%%< =

Expression%%> H
<%%H I
Func%%I M
<%%M N
Domain%%N T
.%%T U
Entities%%U ]
.%%] ^
Employee%%^ f
,%%f g
object%%h n
>%%n o
>%%o p
>%%p q
{&& 
{'' 
nameof'' 
('' 
Domain'' #
.''# $
Entities''$ ,
.'', -
Employee''- 5
.''5 6
FullName''6 >
)''> ?
,''? @
r''A B
=>''C E
r''F G
.''G H
FullName''H P
}''Q R
,''R S
}(( 
;(( 
var** 
selectedColumn** "
=**# $
columnsSelectors**% 5
[**5 6
request**6 =
.**= >
Query**> C
.**C D
SortBy**D J
]**J K
;**K L
	baseQuery,, 
=,, 
request,, #
.,,# $
Query,,$ )
.,,) *
SortDirection,,* 7
==,,8 :
SortDirection,,; H
.,,H I
ASC,,I L
?-- 
	baseQuery-- 
.--  
OrderBy--  '
(--' (
selectedColumn--( 6
)--6 7
:.. 
	baseQuery.. 
...  
OrderByDescending..  1
(..1 2
selectedColumn..2 @
)..@ A
;..A B
}// 
var11 
	employees11 
=11 
await11 !
	baseQuery11" +
.22 
Skip22 
(22 
request22 
.22 
Query22 #
.22# $
PageSize22$ ,
*22- .
(22/ 0
request220 7
.227 8
Query228 =
.22= >

PageNumber22> H
-22I J
$num22K L
)22L M
)22M N
.33 
Take33 
(33 
request33 
.33 
Query33 #
.33# $
PageSize33$ ,
)33, -
.44 
Select44 
(44 
x44 
=>44 
new44  

EmployeeVm44! +
(44+ ,
x44, -
.44- .
Id44. 0
,440 1
x442 3
.443 4
	FirstName444 =
,44= >
x44? @
.44@ A
LastName44A I
,44I J
x44K L
.44L M
FullName44M U
,44U V
x44W X
.44X Y
Gender44Y _
,44_ `
x44a b
.44b c
	BirthDate44c l
,44l m
x44n o
.44o p
ApplicationUser44p 
.	44 Ä
Email
44Ä Ö
,
44Ö Ü
x
44á à
.
44à â
ApplicationUser
44â ò
.
44ò ô
PhoneNumber
44ô §
,
44§ •
x
44¶ ß
.
44ß ®
Contract
44® ∞
.
44∞ ±
ContractName
44± Ω
)
44Ω æ
)
44æ ø
.55 
ToListAsync55 
(55 
)55 
;55 
var77 
totalItemsCount77 
=77  !
	employees77" +
.77+ ,
Count77, 1
(771 2
)772 3
;773 4
var99 
result99 
=99 
new99 

PageResult99 '
<99' (

EmployeeVm99( 2
>992 3
(993 4
	employees994 =
,99= >
totalItemsCount99? N
,99N O
request99P W
.99W X
Query99X ]
.99] ^
PageSize99^ f
,99f g
request99h o
.99o p
Query99p u
.99u v

PageNumber	99v Ä
)
99Ä Å
;
99Å Ç
return;; 
result;; 
;;; 
}<< 	
}== 
}>> ±
hC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Employee\Query\Employees\EmployeeVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Employee! )
.) *
Query* /
./ 0
	Employees0 9
{ 
public 

record 

EmployeeVm 
( 
int  
Id! #
,# $
string% +
	FirstName, 5
,5 6
string7 =
LastName> F
,F G
stringH N
FullNameO W
,W X
GenderY _
Gender` f
,f g
DateTime 
? 
	BirthDate 
, 
string #
Email$ )
,) *
string+ 1
PhoneNumber2 =
,= >
string? E
ContractNameF R
)R S
;S T
} ‡
ÉC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Command\AddLeaveRegister\AddLeaveRegisterCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Command/ 6
.6 7
AddLeaveRegister7 G
{ 
public 

class #
AddLeaveRegisterCommand (
:) *
IRequest+ 3
<3 4
int4 7
>7 8
{ 
public 
AddLeaveRegisterVm !
AddLeaveRegisterVm" 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
}		 
}

 ê-
äC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Command\AddLeaveRegister\AddLeaveRegisterCommandHandler.cs
	namespace

 	

HRMOptimus
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
  !
LeaveRegister

! .
.

. /
Command

/ 6
.

6 7
AddLeaveRegister

7 G
{ 
internal 
class *
AddLeaveRegisterCommandHandler 1
:2 3
IRequestHandler4 C
<C D#
AddLeaveRegisterCommandD [
,[ \
int] `
>` a
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public *
AddLeaveRegisterCommandHandler -
(- . 
IHRMOptimusDbContext. B
contextC J
)J K
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
int 
> 
Handle %
(% &#
AddLeaveRegisterCommand& =
request> E
,E F
CancellationTokenG X
cancellationTokenY j
)j k
{ 	
var 
daysList 
= 

Enumerable %
.% &
Range& +
(+ ,
$num, -
,- .
$num/ 0
+1 2
request3 :
.: ;
AddLeaveRegisterVm; M
.M N
LeaveEndN V
.V W
DateW [
. 
Subtract 
( 
request !
.! "
AddLeaveRegisterVm" 4
.4 5

LeaveStart5 ?
.? @
Date@ D
)D E
.E F
DaysF J
)J K
. 
Select 
( 
offset 
=> !
request" )
.) *
AddLeaveRegisterVm* <
.< =

LeaveStart= G
.G H
DateH L
.L M
AddDaysM T
(T U
offsetU [
)[ \
)\ ]
. 
ToArray 
( 
) 
; 
int 
duration 
= 
$num 
; 
foreach 
( 
var 
item 
in  
daysList! )
)) *
{ 
if   
(   
item   
.   
	DayOfWeek   "
!=  # %
	DayOfWeek  & /
.  / 0
Saturday  0 8
&&  9 ;
item  < @
.  @ A
	DayOfWeek  A J
!=  K M
	DayOfWeek  N W
.  W X
Sunday  X ^
)  ^ _
duration!! 
+=!! 
$num!!  !
;!!! "
}"" 
var## 
employee## 
=## 
await##  
_context##! )
.##) *
	Employees##* 3
.##3 4
Include##4 ;
(##; <
leaves##< B
=>##C E
leaves##F L
.##L M
LeavesRegister##M [
)##[ \
.$$ 
FirstOrDefaultAsync$$ $
($$$ %
x$$% &
=>$$' )
x$$* +
.$$+ ,
Id$$, .
==$$/ 1
request$$2 9
.$$9 :
AddLeaveRegisterVm$$: L
.$$L M

EmployeeId$$M W
)$$W X
;$$X Y
if&& 
(&& 
employee&& 
!=&& 
null&&  
)&&  !
{'' 
Domain(( 
.(( 
Entities(( 
.((  
LeaveRegister((  -
leaveRegister((. ;
=((< =
new((> A
Domain((B H
.((H I
Entities((I Q
.((Q R
LeaveRegister((R _
(((_ `
)((` a
{)) 
Duration** 
=** 
duration** '
,**' (
DateFrom++ 
=++ 
request++ &
.++& '
AddLeaveRegisterVm++' 9
.++9 :

LeaveStart++: D
.++D E
Date++E I
,++I J
DateTo,, 
=,, 
request,, $
.,,$ %
AddLeaveRegisterVm,,% 7
.,,7 8
LeaveEnd,,8 @
.,,@ A
Date,,A E
,,,E F

EmployeeId-- 
=--  
request--! (
.--( )
AddLeaveRegisterVm--) ;
.--; <

EmployeeId--< F
,--F G
Employee.. 
=.. 
employee.. '
,..' (

IsApproved// 
=//  

IsApproved//! +
.//+ ,
	UnChecked//, 5
,//5 6
LeaveRegisterType00 %
=00& '
request00( /
.00/ 0
AddLeaveRegisterVm000 B
.00B C
LeaveRegisterType00C T
}11 
;11 
employee33 
.33 
LeavesRegister33 '
.33' (
Add33( +
(33+ ,
leaveRegister33, 9
)339 :
;33: ;
_context44 
.44 
LeavesRegister44 '
.44' (
Add44( +
(44+ ,
leaveRegister44, 9
)449 :
;44: ;
_context66 
.66 
	Employees66 "
.66" #
Update66# )
(66) *
employee66* 2
)662 3
;663 4
await88 
_context88 
.88 
SaveChangesAsync88 /
(88/ 0
cancellationToken880 A
)88A B
;88B C
return99 
leaveRegister99 $
.99$ %
Id99% '
;99' (
}:: 
return;; 
$num;; 
;;; 
}<< 	
}== 
}>> ÿ
~C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Command\AddLeaveRegister\AddLeaveRegisterVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Command/ 6
.6 7
AddLeaveRegister7 G
{ 
public 

class 
AddLeaveRegisterVm #
{ 
public 
DateTime 

LeaveStart "
{# $
get% (
;( )
set* -
;- .
}/ 0
public		 
DateTime		 
LeaveEnd		  
{		! "
get		# &
;		& '
set		( +
;		+ ,
}		- .
public

 
int

 

EmployeeId

 
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
public 
LeaveRegisterType  
LeaveRegisterType! 2
{4 5
get6 9
;9 :
set; >
;> ?
}@ A
} 
} ó
ïC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Command\ChangeStatusLeaveRegister\ChangeStatusLeaveRegisterCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Command/ 6
.6 7%
ChangeStatusLeaveRegister7 P
{ 
public 

class ,
 ChangeStatusLeaveRegisterCommand 1
:2 3
IRequest4 <
<< =
Unit= A
>A B
{ 
public '
ChangeStatusLeaveRegisterVm *'
ChangeStatusLeaveRegisterVm+ F
{G H
getI L
;L M
setN Q
;Q R
}S T
} 
}		 Ó!
úC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Command\ChangeStatusLeaveRegister\ChangeStatusLeaveRegisterCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Command/ 6
.6 7%
ChangeStatusLeaveRegister7 P
{		 
public

 

class

 3
'ChangeStatusLeaveRegisterCommandHandler

 8
:

9 :
IRequestHandler

; J
<

J K,
 ChangeStatusLeaveRegisterCommand

K k
,

k l
Unit

m q
>

q r
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public 3
'ChangeStatusLeaveRegisterCommandHandler 6
(6 7 
IHRMOptimusDbContext7 K
contextL S
)S T
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& ',
 ChangeStatusLeaveRegisterCommand' G
requestH O
,O P
CancellationTokenQ b
cancellationTokenc t
)t u
{ 	
var 
user 
= 
await 
_context %
.% &
	Employees& /
./ 0
Include0 7
(7 8
x8 9
=>: <
x= >
.> ?
LeavesRegister? M
)M N
. 
FirstOrDefaultAsync $
($ %
x% &
=>' )
x* +
.+ ,
Id, .
==/ 1
request2 9
.9 :'
ChangeStatusLeaveRegisterVm: U
.U V

EmployeeIdV `
)` a
;a b
var 
leaveRegister 
= 
await  %
_context& .
.. /
LeavesRegister/ =
.= >
FirstOrDefaultAsync> Q
(Q R
xR S
=>T V
xW X
.X Y
IdY [
==\ ^
request_ f
.f g(
ChangeStatusLeaveRegisterVm	g Ç
.
Ç É
RecordId
É ã
)
ã å
;
å ç
if 
( 
request 
. '
ChangeStatusLeaveRegisterVm 3
.3 4
Status4 :
!=; =
leaveRegister> K
.K L

IsApprovedL V
)V W
{ 
if 
( 
request 
. '
ChangeStatusLeaveRegisterVm 7
.7 8
Status8 >
!=? A

IsApprovedB L
.L M
ApprovedM U
&&V X
leaveRegisterY f
.f g

IsApprovedg q
==r t

IsApprovedu 
.	 Ä
Approved
Ä à
)
à â
{ 
user 
. 
LeaveDaysLeft &
+=' )
leaveRegister* 7
.7 8
Duration8 @
;@ A
} 
else   
if   
(   
request    
.    !'
ChangeStatusLeaveRegisterVm  ! <
.  < =
Status  = C
==  D F

IsApproved  G Q
.  Q R
Approved  R Z
&&  [ ]
leaveRegister  ^ k
.  k l

IsApproved  l v
!=  w y

IsApproved	  z Ñ
.
  Ñ Ö
Approved
  Ö ç
)
  ç é
{!! 
user"" 
."" 
LeaveDaysLeft"" &
-=""' )
leaveRegister""* 7
.""7 8
Duration""8 @
;""@ A
}## 
leaveRegister%% 
.%% 

IsApproved%% (
=%%) *
request%%+ 2
.%%2 3'
ChangeStatusLeaveRegisterVm%%3 N
.%%N O
Status%%O U
;%%U V
await&& 
_context&& 
.&& 
SaveChangesAsync&& /
(&&/ 0
cancellationToken&&0 A
)&&A B
;&&B C
}'' 
return)) 
Unit)) 
.)) 
Value)) 
;)) 
}** 	
}++ 
},, ∆
êC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Command\ChangeStatusLeaveRegister\ChangeStatusLeaveRegisterVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Command/ 6
.6 7%
ChangeStatusLeaveRegister7 P
{ 
public 

class '
ChangeStatusLeaveRegisterVm ,
{ 
public 
int 
RecordId 
{ 
get !
;! "
set# &
;& '
}( )
public 
int 

EmployeeId 
{ 
get  #
;# $
set% (
;( )
}* +
public		 

IsApproved		 
Status		  
{		! "
get		# &
;		& '
set		( +
;		+ ,
}		- .
}

 
} ø
ôC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Command\ChangeStatusLeaveRegister\ChangeStatusLeaveRegisterVmValidator.cs
	namespace

 	

HRMOptimus
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
  !
LeaveRegister

! .
.

. /
Command

/ 6
.

6 7%
ChangeStatusLeaveRegister

7 P
{ 
public 

class 0
$ChangeStatusLeaveRegisterVmValidator 5
:6 7
AbstractValidator8 I
<I J'
ChangeStatusLeaveRegisterVmJ e
>e f
{ 
public 0
$ChangeStatusLeaveRegisterVmValidator 3
(3 4 
IHRMOptimusDbContext4 H
	dbContextI R
)R S
{ 	
RuleFor 
( 
x 
=> 
x 
. 
RecordId #
)# $
. 
Custom 
( 
( 
value 
, 
context  '
)' (
=>) +
{ 
var 
leaveRecord #
=$ %
	dbContext& /
./ 0
LeavesRegister0 >
.> ?
Any? B
(B C
eC D
=>E G
eH I
.I J
IdJ L
==M O
valueP U
&&V X
eY Z
.Z [
Enabled[ b
)b c
;c d
if 
( 
! 
leaveRecord $
)$ %
context 
.  

AddFailure  *
(* +
$str+ /
,/ 0
$str1 M
+N O
valueP U
+V W
$strX h
)h i
;i j
} 
) 
; 
RuleFor 
( 
x 
=> 
x 
. 

EmployeeId %
)% &
. 
Custom 
( 
( 
value 
, 
context &
)& '
=>( *
{ 
var 
employee 
=  !
	dbContext" +
.+ ,
	Employees, 5
.5 6
Any6 9
(9 :
e: ;
=>< >
e? @
.@ A
IdA C
==D F
valueG L
&&M O
eP Q
.Q R
EnabledR Y
)Y Z
;Z [
if 
( 
! 
employee  
)  !
context 
. 

AddFailure )
() *
$str* .
,. /
$str0 H
+I J
valueK P
+Q R
$strS c
)c d
;d e
} 
) 
; 
} 	
}   
}!! »
âC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Command\DeleteLeaveRegister\DeleteLeaveRegisterCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Command/ 6
.6 7
DeleteLeaveRegister7 J
{		 
public

 

class

 &
DeleteLeaveRegisterCommand

 +
:

, -
IRequest

. 6
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 
? 

EmployeeId 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
} À
êC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Command\DeleteLeaveRegister\DeleteLeaveRegisterCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Command/ 6
.6 7
DeleteLeaveRegister7 J
{		 
internal

 
class

 -
!DeleteLeaveRegisterCommandHandler

 4
:

5 6
IRequestHandler

7 F
<

F G&
DeleteLeaveRegisterCommand

G a
>

a b
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
private 
readonly 
IUserContextService ,
_userContextService- @
;@ A
public -
!DeleteLeaveRegisterCommandHandler 0
(0 1 
IHRMOptimusDbContext1 E
contextF M
,M N
IUserContextServiceO b
userContextServicec u
)u v
{ 	
_context 
= 
context 
; 
_userContextService 
=  !
userContextService" 4
;4 5
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '&
DeleteLeaveRegisterCommand' A
requestB I
,I J
CancellationTokenK \
cancellationToken] n
)n o
{ 	
var 
leaveRegister 
= 
_context  (
.( )
LeavesRegister) 7
.7 8
FirstOrDefault8 F
(F G
xG H
=>I K
xL M
.M N
IdN P
==Q S
requestT [
.[ \
Id\ ^
)^ _
;_ `
int 

employeeId 
= 
_userContextService 0
.0 1
GetEmployeeId1 >
.> ?
Value? D
;D E
if 
( 

employeeId 
== 
$num 
)  

employeeId 
= 
( 
int !
)! "
request" )
.) *

EmployeeId* 4
;4 5
var 
employee 
= 
_context #
.# $
	Employees$ -
.- .
FirstOrDefault. <
(< =
x= >
=>? A
xB C
.C D
IdD F
==G I

employeeIdJ T
)T U
;U V
if 
( 
leaveRegister 
. 

IsApproved (
==) +

IsApproved, 6
.6 7
Approved7 ?
)? @
employee   
.   
LeaveDaysLeft   &
+=  ' )
leaveRegister  * 7
.  7 8
Duration  8 @
;  @ A
_context"" 
."" 
	Employees"" 
."" 
Update"" %
(""% &
employee""& .
)"". /
;""/ 0
_context## 
.## 
LeavesRegister## #
.### $
Remove##$ *
(##* +
leaveRegister##+ 8
)##8 9
;##9 :
await$$ 
_context$$ 
.$$ 
SaveChangesAsync$$ +
($$+ ,
cancellationToken$$, =
)$$= >
;$$> ?
return%% 
Unit%% 
.%% 
Value%% 
;%% 
}&& 	
}'' 
}(( Í
wC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Query\GetByProject\GetByProjectQuery.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Query/ 4
.4 5
GetByProject5 A
{ 
public 

class 
GetByProjectQuery "
:# $
IRequest% -
<- .
List. 2
<2 3
GetByProjectVm3 A
>A B
>B C
{ 
public 
int 
	ProjectId 
{ 
get "
;" #
set$ '
;' (
}) *
}		 
}

 ¬
~C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Query\GetByProject\GetByProjectQueryHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Query/ 4
.4 5
GetByProject5 A
{ 
public 

class $
GetByProjectQueryHandler )
:* +
IRequestHandler, ;
<; <
GetByProjectQuery< M
,M N
ListO S
<S T
GetByProjectVmT b
>b c
>c d
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public $
GetByProjectQueryHandler '
(' ( 
IHRMOptimusDbContext( <
context= D
)D E
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
List 
< 
GetByProjectVm -
>- .
>. /
Handle0 6
(6 7
GetByProjectQuery7 H
requestI P
,P Q
CancellationTokenR c
cancellationTokend u
)u v
{ 	
try 
{ 
var 
project 
= 
await #
_context$ ,
., -
Projects- 5
.5 6
Include6 =
(= >
x> ?
=>@ B
xC D
.D E
ProjectMembersE S
)S T
. 
FirstOrDefaultAsync (
(( )
x) *
=>+ -
x. /
./ 0
Id0 2
==3 5
request6 =
.= >
	ProjectId> G
)G H
;H I
if 
( 
project 
== 
null #
)# $
return 
null 
;  
foreach   
(   
var   
item   !
in  " $
project  % ,
.  , -
ProjectMembers  - ;
)  ; <
{!! 
}## 
return%% 
null%% 
;%% 
}&& 
catch'' 
('' 
	Exception'' 
)'' 
{(( 
throw** 
;** 
}++ 
throw,, 
new,, #
NotImplementedException,, -
(,,- .
),,. /
;,,/ 0
}-- 	
}.. 
}// ﬂ

tC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Query\GetByProject\GetByProjectVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Query/ 4
.4 5
GetByProject5 A
{ 
public 

class 
GetByProjectVm 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public		 
string		 
FullName		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
public

 
int

 
Duration

 
{

 
get

 !
;

! "
set

# &
;

& '
}

( )
public 
DateTime 
DateFrom  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
DateTime 
DateTo 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 

IsApproved 

IsApproved $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} Ç
ôC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Query\GetLeavesRegisterByEmployeeId\GetLeavesRegisterByEmployeeIdQuery.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Query/ 4
.4 5)
GetLeavesRegisterByEmployeeId5 R
{		 
public

 

class

 .
"GetLeavesRegisterByEmployeeIdQuery

 3
:

4 5
IRequest

5 =
<

= >
LeavesRegisterVm

> N
>

N O
{ 
public 
int 

EmployeeId 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} ö&
†C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Query\GetLeavesRegisterByEmployeeId\GetLeavesRegisterByEmployeeIdQueryHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Query/ 4
.4 5)
GetLeavesRegisterByEmployeeId5 R
{ 
internal 
class 5
)GetLeavesRegisterByEmployeeIdQueryHandler <
:= >
IRequestHandler? N
<N O.
"GetLeavesRegisterByEmployeeIdQueryO q
,q r
LeavesRegisterVm	s É
>
É Ñ
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public 5
)GetLeavesRegisterByEmployeeIdQueryHandler 8
(8 9 
IHRMOptimusDbContext9 M
contextN U
,U V
IUserContextServiceW j
userContextServicek }
)} ~
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
LeavesRegisterVm *
>* +
Handle, 2
(2 3.
"GetLeavesRegisterByEmployeeIdQuery3 U
requestV ]
,] ^
CancellationToken_ p
cancellationToken	q Ç
)
Ç É
{ 	
try 
{ 
var 
employee 
= 
await $
_context% -
.- .
	Employees. 7
.7 8
Include8 ?
(? @
x@ A
=>B D
xE F
.F G
LeavesRegisterG U
)U V
. 
Include 
( 
p 
=> !
p" #
.# $
Contract$ ,
), -
. 
Where 
( 
x 
=> 
x  !
.! "
Enabled" )
==* ,
true- 1
)1 2
. 
FirstOrDefaultAsync (
(( )
u) *
=>+ -
u. /
./ 0
Id0 2
==3 5
request6 =
.= >

EmployeeId> H
)H I
;I J
if!! 
(!! 
employee!! 
!=!! 
null!!  $
&&!!% '
employee!!( 0
.!!0 1
LeavesRegister!!1 ?
!=!!@ B
null!!C G
)!!G H
{"" 
var## 
leavesRecord## $
=##% &
await##' ,
_context##- 5
.##5 6
LeavesRegister##6 D
.##D E
Where##E J
(##J K
x##K L
=>##M O
x##P Q
.##Q R

EmployeeId##R \
==##] _
employee##` h
.##h i
Id##i k
&&##l n
x##o p
.##p q
Enabled##q x
==##y {
true	##| Ä
)
##Ä Å
.$$ 
Select$$ 
($$  
x$$  !
=>$$" $
new$$% (
LeaveRecord$$) 4
{%% 
Id&& 
=&&  
x&&! "
.&&" #
Id&&# %
,&&% &
DateFrom'' $
=''% &
x''' (
.''( )
DateFrom'') 1
,''1 2
DateTo(( "
=((# $
x((% &
.((& '
DateTo((' -
,((- .
Duration)) $
=))% &
x))' (
.))( )
Duration))) 1
,))1 2

IsApproved** &
=**' (
x**) *
.*** +

IsApproved**+ 5
,**5 6
LeaveRegisterType++ -
=++. /
x++0 1
.++1 2
LeaveRegisterType++2 C
},, 
),, 
.,, 
ToListAsync,, &
(,,& '
),,' (
;,,( )
var.. 
leaves.. 
=..  
new..! $
LeavesRegisterVm..% 5
(..5 6
)..6 7
{// 
LeaveDaysLeft00 %
=00& '
(00( )
int00) ,
)00, -
employee00- 5
.005 6
LeaveDaysLeft006 C
,00C D
LeaveDaysByContract11 +
=11, -
(11. /
int11/ 2
)112 3
employee113 ;
.11; <
Contract11< D
.11D E
	LeaveDays11E N
,11N O
LeaveRecords22 $
=22% &
leavesRecord22' 3
,223 4
}33 
;33 
return55 
leaves55 !
;55! "
}66 
return77 
null77 
;77 
}88 
catch99 
(99 
	Exception99 
)99 
{:: 
return;; 
null;; 
;;; 
}<< 
}== 	
}>> 
}?? è
áC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\LeaveRegister\Query\GetLeavesRegisterByEmployeeId\LeavesRegisterVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
LeaveRegister! .
.. /
Query/ 4
.4 5)
GetLeavesRegisterByEmployeeId5 R
{ 
public 

class 
LeavesRegisterVm !
{ 
public		 
int		 
LeaveDaysByContract		 &
{		' (
get		) ,
;		, -
set		. 1
;		1 2
}		3 4
public

 
int

 
LeaveDaysLeft

  
{

! "
get

# &
;

& '
set

( +
;

+ ,
}

- .
public 
List 
< 
LeaveRecord 
>  
LeaveRecords! -
{. /
get/ 2
;2 3
set3 6
;6 7
}7 8
} 
public 

class 
LeaveRecord 
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
int 
Duration 
{ 
get !
;! "
set# &
;& '
}( )
public 
LeaveRegisterType  
LeaveRegisterType! 2
{3 4
get5 8
;8 9
set: =
;= >
}? @
public 
DateTime 
DateFrom  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
DateTime 
DateTo 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 

IsApproved 

IsApproved $
{% &
get' *
;* +
set, /
;/ 0
}1 2
} 
} Ü
sC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\AddEmployee\AddEmployeeCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1
AddEmployee1 <
{ 
public 

class 
AddEmployeeCommand #
:$ %
IRequest& .
{ 
public 
AddEmployeeVm 
AddEmployeeVm *
{+ ,
get- 0
;0 1
set2 5
;5 6
}7 8
} 
}		 ƒ
zC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\AddEmployee\AddEmployeeCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1
AddEmployee1 <
{		 
public

 

class

 %
AddEmployeeCommandHandler

 *
:

+ ,
IRequestHandler

- <
<

< =
AddEmployeeCommand

= O
,

O P
Unit

Q U
>

U V
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public %
AddEmployeeCommandHandler (
(( ) 
IHRMOptimusDbContext) =
context> E
)E F
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '
AddEmployeeCommand' 9
request: A
,A B
CancellationTokenC T
cancellationTokenU f
)f g
{ 	
var 
employee 
= 
_context #
.# $
	Employees$ -
.- .
FirstOrDefault. <
(< =
x= >
=>? A
xB C
.C D
IdD F
==G I
requestJ Q
.Q R
AddEmployeeVmR _
._ `

EmployeeId` j
)j k
;k l
var 
project 
= 
_context "
." #
Projects# +
.+ ,
Include, 3
(3 4
x4 5
=>6 8
x9 :
.: ;
ProjectMembers; I
)I J
. 
FirstOrDefault 
(  
p  !
=>" $
p% &
.& '
Id' )
==* ,
request- 4
.4 5
AddEmployeeVm5 B
.B C
	ProjectIdC L
)L M
;M N
project 
. 
ProjectMembers "
." #
Add# &
(& '
employee' /
)/ 0
;0 1
await 
_context 
. 
SaveChangesAsync +
(+ ,
cancellationToken, =
)= >
;> ?
return 
Unit 
. 
Value 
; 
} 	
}   
}!! ‰
nC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\AddEmployee\AddEmployeeVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1
AddEmployee1 <
{ 
public 

class 
AddEmployeeVm 
{ 
public 
int 
	ProjectId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 

EmployeeId 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} œ
wC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\AddEmployee\AddEmployeeVmValidator.cs
	namespace		 	

HRMOptimus		
 
.		 
Application		  
.		  !
Project		! (
.		( )
Command		) 0
.		0 1
AddEmployee		1 <
{

 
public 

class "
AddEmployeeVmValidator '
:( )
AbstractValidator* ;
<; <
AddEmployeeVm< I
>I J
{ 
public "
AddEmployeeVmValidator %
(% & 
IHRMOptimusDbContext& :
	dbContext; D
)D E
{ 	
RuleFor 
( 
x 
=> 
x 
. 
	ProjectId $
)$ %
. 
Custom 
( 
( 
value 
, 
context &
)& '
=>( *
{ 
var 
project 
=  
	dbContext! *
.* +
Projects+ 3
.3 4
Any4 7
(7 8
e8 9
=>: <
e= >
.> ?
Id? A
==B D
valueE J
&&K M
eN O
.O P
EnabledP W
)W X
;X Y
if 
( 
! 
project 
)  
context 
. 

AddFailure )
() *
$str* .
,. /
$str0 G
+H I
valueJ O
+P Q
$strR b
)b c
;c d
} 
) 
; 
RuleFor 
( 
x 
=> 
x 
. 

EmployeeId %
)% &
. 
Custom 
( 
( 
value 
, 
context &
)& '
=>( *
{ 
var 
project 
=  
	dbContext! *
.* +
	Employees+ 4
.4 5
Any5 8
(8 9
e9 :
=>; =
e> ?
.? @
Id@ B
==C E
valueF K
&&L N
eO P
.P Q
EnabledQ X
)X Y
;Y Z
if 
( 
! 
project 
)  
context 
. 

AddFailure )
() *
$str* .
,. /
$str0 H
+I J
valueK P
+Q R
$strS c
)c d
;d e
} 
) 
; 
} 	
} 
}   Ø
qC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\AddProject\AddProjectCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1

AddProject1 ;
{ 
public 

class 
AddProjectCommand "
:# $
IRequest% -
<- .
int. 1
>1 2
{ 
public 
AddProjectVm 
AddProjectVm (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
} 
}		 π
xC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\AddProject\AddProjectCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1

AddProject1 ;
{ 
public 

class $
AddProjectCommandHandler )
:* +
IRequestHandler, ;
<; <
AddProjectCommand< M
,M N
intO R
>R S
{		 
private

 
readonly

  
IHRMOptimusDbContext

 -
_context

. 6
;

6 7
public $
AddProjectCommandHandler '
(' ( 
IHRMOptimusDbContext( <
context= D
)D E
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
int 
> 
Handle %
(% &
AddProjectCommand& 7
request8 ?
,? @
CancellationTokenA R
cancellationTokenS d
)d e
{ 	
var 
project 
= 
new 
Domain $
.$ %
Entities% -
.- .
Project. 5
(5 6
)6 7
{ 
Name 
= 
request 
. 
AddProjectVm +
.+ ,
Name, 0
,0 1
DateFrom 
= 
request "
." #
AddProjectVm# /
./ 0
DateFrom0 8
,8 9
DateTo 
= 
request  
.  !
AddProjectVm! -
.- .
DateTo. 4
,4 5
Deadline 
= 
request "
." #
AddProjectVm# /
./ 0
Deadline0 8
,8 9
Description 
= 
request %
.% &
AddProjectVm& 2
.2 3
Description3 >
,> ?
ProjectMembers 
=  
request! (
.( )
AddProjectVm) 5
.5 6
ProjectMembers6 D
,D E
HoursBudget 
= 
request %
.% &
AddProjectVm& 2
.2 3
HoursBudget3 >
,> ?

ColorLabel 
= 
request $
.$ %
AddProjectVm% 1
.1 2

ColorLabel2 <
,< =
} 
; 
_context 
. 
Projects 
. 
Add !
(! "
project" )
)) *
;* +
await   
_context   
.   
SaveChangesAsync   +
(  + ,
cancellationToken  , =
)  = >
;  > ?
return!! 
project!! 
.!! 
Id!! 
;!! 
}"" 	
}## 
}$$ ™
lC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\AddProject\AddProjectVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1

AddProject1 ;
{ 
public 

class 
AddProjectVm 
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public		 
string		 
Description		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
public

 
decimal

 
HoursBudget

 "
{

# $
get

% (
;

( )
set

* -
;

- .
}

/ 0
public 
string 

ColorLabel  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
DateTime 
DateFrom  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
DateTime 
DateTo 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
DateTime 
? 
Deadline !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
ICollection 
< 
Domain !
.! "
Entities" *
.* +
Employee+ 3
>3 4
ProjectMembers5 C
{D E
getF I
;I J
setK N
;N O
}P Q
} 
} €
uC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\AddProject\AddProjectVmValidator.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1

AddProject1 ;
{ 
public 

class !
AddProjectVmValidator &
:' (
AbstractValidator) :
<: ;
AddProjectVm; G
>G H
{ 
public !
AddProjectVmValidator $
($ %
)% &
{ 	
RuleFor		 
(		 
x		 
=>		 
x		 
.		 
Name		 
)		  
.		  !
NotEmpty		! )
(		) *
)		* +
.		+ ,
MinimumLength		, 9
(		9 :
$num		: ;
)		; <
;		< =
RuleFor

 
(

 
x

 
=>

 
x

 
.

 
DateTo

 !
)

! "
.

" #
GreaterThan

# .
(

. /
x

/ 0
=>

1 3
x

4 5
.

5 6
DateFrom

6 >
)

> ?
.

? @
NotEmpty

@ H
(

H I
)

I J
;

J K
RuleFor 
( 
x 
=> 
x 
. 
DateTo !
)! "
." #
NotEmpty# +
(+ ,
), -
.- .
LessThanOrEqualTo. ?
(? @
x@ A
=>B D
xE F
.F G
DeadlineG O
)O P
;P Q
RuleFor 
( 
x 
=> 
x 
. 
HoursBudget &
)& '
.' (
NotEmpty( 0
(0 1
)1 2
.2 3
GreaterThan3 >
(> ?
$num? @
)@ A
;A B
} 	
} 
} Ä
wC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\RemoveProject\RemoveProjectCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1
RemoveProject1 >
{ 
public 

class  
RemoveProjectCommand %
:& '
IRequest( 0
{ 
public 
int 
	ProjectId 
{ 
get "
;" #
set$ '
;' (
}) *
} 
}		 •
~C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\RemoveProject\RemoveProjectCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1
RemoveProject1 >
{		 
public

 

class

 '
RemoveProjectCommandHandler

 ,
:

- .
IRequestHandler

/ >
<

> ? 
RemoveProjectCommand

? S
>

S T
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public '
RemoveProjectCommandHandler *
(* + 
IHRMOptimusDbContext+ ?
context@ G
)G H
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& ' 
RemoveProjectCommand' ;
request< C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 	
var 
project 
= 
await 
_context  (
.( )
Projects) 1
.1 2
FirstOrDefaultAsync2 E
(E F
xF G
=>H J
xK L
.L M
IdM O
==P R
requestS Z
.Z [
	ProjectId[ d
)d e
;e f
if 
( 
project 
== 
null 
)  
throw 
new 
NotFoundException +
(+ ,
$str, K
+L M
requestN U
.U V
	ProjectIdV _
)_ `
;` a
_context 
. 
Projects 
. 
Remove $
($ %
project% ,
), -
;- .
await 
_context 
. 
SaveChangesAsync +
(+ ,
cancellationToken, =
)= >
;> ?
return 
Unit 
. 
Value 
; 
} 	
} 
}   Ú
ÄC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\RemoveProject\RemoveProjectCommandValidator.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1
RemoveProject1 >
{ 
public 

class )
RemoveProjectCommandValidator .
:/ 0
AbstractValidator1 B
<B C 
RemoveProjectCommandC W
>W X
{ 
public		 )
RemoveProjectCommandValidator		 ,
(		, - 
IHRMOptimusDbContext		- A
	dbContext		B K
)		K L
{

 	
RuleFor 
( 
x 
=> 
x 
. 
	ProjectId $
)$ %
.% &
Custom& ,
(, -
(- .
value. 3
,3 4
context5 <
)< =
=>> @
{ 
var 
project 
= 
	dbContext '
.' (
Projects( 0
.0 1
Any1 4
(4 5
e5 6
=>7 9
e: ;
.; <
Id< >
==? A
valueB G
&&H J
eK L
.L M
EnabledM T
)T U
;U V
if 
( 
! 
project 
) 
context 
. 

AddFailure &
(& '
$str' +
,+ ,
$str- D
+E F
valueG L
+M N
$strO _
)_ `
;` a
} 
) 
; 
} 	
} 
} í
wC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\UpdateProject\UpdateProjectCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1
UpdateProject1 >
{ 
public 

class  
UpdateProjectCommand %
:& '
IRequest( 0
{ 
public 
UpdateProjectVm 
UpdateProjectVm .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
} 
}		 
~C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\UpdateProject\UpdateProjectCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1
UpdateProject1 >
{ 
public		 

class		 '
UpdateProjectCommandHandler		 ,
:		- .
IRequestHandler		/ >
<		> ? 
UpdateProjectCommand		? S
>		S T
{

 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public '
UpdateProjectCommandHandler *
(* + 
IHRMOptimusDbContext+ ?
context@ G
)G H
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& ' 
UpdateProjectCommand' ;
request< C
,C D
CancellationTokenE V
cancellationTokenW h
)h i
{ 	
var 
project 
= 
await 
_context  (
.( )
Projects) 1
.1 2
	FindAsync2 ;
(; <
request< C
.C D
UpdateProjectVmD S
.S T
IdT V
)V W
;W X
project 
. 
Name 
= 
request "
." #
UpdateProjectVm# 2
.2 3
Name3 7
;7 8
project 
. 
DateFrom 
= 
request &
.& '
UpdateProjectVm' 6
.6 7
DateFrom7 ?
;? @
project 
. 
DateTo 
= 
request $
.$ %
UpdateProjectVm% 4
.4 5
DateTo5 ;
;; <
project 
. 
Deadline 
= 
request &
.& '
UpdateProjectVm' 6
.6 7
Deadline7 ?
;? @
project 
. 
Description 
=  !
request" )
.) *
UpdateProjectVm* 9
.9 :
Description: E
;E F
project 
. 
ProjectMembers "
=# $
request% ,
., -
UpdateProjectVm- <
.< =
ProjectMembers= K
;K L
project 
. 
HoursBudget 
=  !
request" )
.) *
UpdateProjectVm* 9
.9 :
HoursBudget: E
;E F
_context 
. 
Projects 
. 
Update $
($ %
project% ,
), -
;- .
await 
_context 
. 
SaveChangesAsync +
(+ ,
cancellationToken, =
)= >
;> ?
return!! 
Unit!! 
.!! 
Value!! 
;!! 
}"" 	
}## 
}$$ ´
rC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\UpdateProject\UpdateProjectVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1
UpdateProject1 >
{ 
public 

class 
UpdateProjectVm  
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public		 
string		 
Name		 
{		 
get		  
;		  !
set		" %
;		% &
}		' (
public

 
string

 
Description

 !
{

" #
get

$ '
;

' (
set

) ,
;

, -
}

. /
public 
decimal 
HoursBudget "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
DateTime 
DateFrom  
{! "
get# &
;& '
set( +
;+ ,
}- .
public 
DateTime 
DateTo 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
DateTime 
? 
Deadline !
{" #
get$ '
;' (
set) ,
;, -
}. /
public 
ICollection 
< 
Domain !
.! "
Entities" *
.* +
Employee+ 3
>3 4
ProjectMembers5 C
{D E
getF I
;I J
setK N
;N O
}P Q
} 
} õ
{C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Command\UpdateProject\UpdateProjectVmValidator.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Command) 0
.0 1
UpdateProject1 >
{ 
public 

class $
UpdateProjectVmValidator )
:* +
AbstractValidator, =
<= >
UpdateProjectVm> M
>M N
{ 
public		 $
UpdateProjectVmValidator		 '
(		' ( 
IHRMOptimusDbContext		( <
	dbContext		= F
)		F G
{

 	
RuleFor 
( 
x 
=> 
x 
. 
Id 
) 
. 
Custom 
( 
( 
value 
, 
context  '
)' (
=>) +
{ 
var 
project 
=  !
	dbContext" +
.+ ,
Projects, 4
.4 5
Any5 8
(8 9
e9 :
=>; =
e> ?
.? @
Id@ B
==C E
valueF K
&&L N
eO P
.P Q
EnabledQ X
)X Y
;Y Z
if 
( 
! 
project  
)  !
context 
.  

AddFailure  *
(* +
$str+ /
,/ 0
$str1 H
+I J
valueK P
+Q R
$strS c
)c d
;d e
} 
) 
; 
RuleFor 
( 
x 
=> 
x 
. 
Name 
)  
.  !
NotEmpty! )
() *
)* +
.+ ,
MinimumLength, 9
(9 :
$num: ;
); <
;< =
RuleFor 
( 
x 
=> 
x 
. 
DateTo !
)! "
." #
GreaterThan# .
(. /
x/ 0
=>1 3
x4 5
.5 6
DateFrom6 >
)> ?
.? @
NotEmpty@ H
(H I
)I J
;J K
RuleFor 
( 
x 
=> 
x 
. 
DateTo !
)! "
." #
NotEmpty# +
(+ ,
), -
.- .
LessThanOrEqualTo. ?
(? @
x@ A
=>B D
xE F
.F G
DeadlineG O
)O P
;P Q
RuleFor 
( 
x 
=> 
x 
. 
HoursBudget &
)& '
.' (
NotEmpty( 0
(0 1
)1 2
.2 3
GreaterThan3 >
(> ?
$num? @
)@ A
;A B
} 	
} 
} ÷
lC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Query\ProjectDetails\EmployeeVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Query) .
.. /
ProjectDetails/ =
{ 
public 

record 

EmployeeVm 
( 
string #
	firstName$ -
,- .
string/ 5
lastName6 >
,> ?
string@ F
genderG M
)M N
;N O
}		 ∏
uC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Query\ProjectDetails\ProjectDetailsQuery.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Query) .
.. /
ProjectDetails/ =
{ 
public 

class 
ProjectDetailsQuery $
:% &
IRequest' /
</ 0
ProjectDetailsVm0 @
>@ A
{ 
public 
int 
	ProjectId 
{ 
get "
;" #
set$ '
;' (
}) *
} 
}		 Î
|C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Query\ProjectDetails\ProjectDetailsQueryHandler.cs
	namespace		 	

HRMOptimus		
 
.		 
Application		  
.		  !
Project		! (
.		( )
Query		) .
.		. /
ProjectDetails		/ =
{

 
public 

class &
ProjectDetailsQueryHandler +
:, -
IRequestHandler. =
<= >
ProjectDetailsQuery> Q
,Q R
ProjectDetailsVmS c
>c d
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public &
ProjectDetailsQueryHandler )
() * 
IHRMOptimusDbContext* >
context? F
)F G
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
ProjectDetailsVm *
>* +
Handle, 2
(2 3
ProjectDetailsQuery3 F
requestG N
,N O
CancellationTokenP a
cancellationTokenb s
)s t
{ 	
var 
project 
= 
await 
_context  (
.( )
Projects) 1
. 
Where 
( 
x 
=> 
x 
. 
Enabled %
)% &
. 
Include 
( 
x 
=> 
x 
.  
ProjectMembers  .
). /
. 
FirstOrDefaultAsync $
($ %
x% &
=>' )
x* +
.+ ,
Id, .
==/ 1
request2 9
.9 :
	ProjectId: C
)C D
;D E
if 
( 
project 
== 
null 
)  
throw 
new 
NotFoundException +
(+ ,
$str, K
+L M
requestN U
.U V
	ProjectIdV _
)_ `
;` a
return 
new 
ProjectDetailsVm '
(' (
project( /
./ 0
Name0 4
,4 5
project6 =
.= >
Description> I
,I J
projectK R
.R S
HoursBudgetS ^
,^ _
project` g
.g h
HoursWorkedh s
,s t
projectu |
.| }
DateFrom	} Ö
,
Ö Ü
project 
. 
DateTo 
, 
project  '
.' (
Deadline( 0
,0 1
project2 9
.9 :
ProjectMembers: H
,H I
projectJ Q
.Q R

ColorLabelR \
)\ ]
;] ^
}   	
}!! 
}"" ›
rC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Query\ProjectDetails\ProjectDetailsVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Query) .
.. /
ProjectDetails/ =
{ 
public 

record 
ProjectDetailsVm "
(" #
string# )
Name* .
,. /
string0 6
Description7 B
,B C
decimalD K
HoursBudgetL W
,W X
decimalY `
HoursWorkeda l
,l m
DateTimen v
DateFromw 
,	 Ä
DateTime 
DateTo 
, 
DateTime !
?! "
Deadline# +
,+ ,
ICollection- 8
<8 9
Domain9 ?
.? @
Entities@ H
.H I
EmployeeI Q
>Q R
ProjectMembersS a
,a b
stringc i

ColorLabelj t
)t u
;u v
} Ø
iC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Query\Projects\ProjectsQuery.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Query) .
.. /
Projects/ 7
{ 
public 

class 
ProjectsQuery 
:  
IRequest! )
<) *
List* .
<. /
	ProjectVm/ 8
>8 9
>9 :
{ 
} 
}		 …
pC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Query\Projects\ProjectsQueryHandler.cs
	namespace

 	

HRMOptimus
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
  !
Project

! (
.

( )
Query

) .
.

. /
Projects

/ 7
{ 
public 

class  
ProjectsQueryHandler %
:& '
IRequestHandler( 7
<7 8
ProjectsQuery8 E
,E F
ListG K
<K L
	ProjectVmL U
>U V
>V W
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public  
ProjectsQueryHandler #
(# $ 
IHRMOptimusDbContext$ 8
context9 @
)@ A
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
List 
< 
	ProjectVm (
>( )
>) *
Handle+ 1
(1 2
ProjectsQuery2 ?
request@ G
,G H
CancellationTokenI Z
cancellationToken[ l
)l m
{ 	
var 
projects 
= 
await  
_context! )
.) *
Projects* 2
. 
Where 
( 
x 
=> 
x 
. 
Enabled %
)% &
. 
Select 
( 
x 
=> 
new  
	ProjectVm! *
(* +
x+ ,
., -
Id- /
,/ 0
x1 2
.2 3
Name3 7
,7 8
x9 :
.: ;
Description; F
,F G
xH I
.I J
HoursBudgetJ U
,U V
xW X
.X Y
DateFromY a
,a b
xc d
.d e
DateToe k
,k l
xm n
.n o

ColorLabelo y
)y z
)z {
. 
ToListAsync 
( 
) 
; 
return 
projects 
; 
} 	
} 
} ´
eC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\Project\Query\Projects\ProjectVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !
Project! (
.( )
Query) .
.. /
Projects/ 7
{ 
public 

record 
	ProjectVm 
( 
int 
Id  "
," #
string$ *
Name+ /
,/ 0
string1 7
Description8 C
,C D
decimalE L
HoursWorkedM X
,X Y
DateTimeZ b
DateFromc k
,k l
DateTime 
DateTo 
, 
string 

ColorLabel  *
)* +
;+ ,
} «
zC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Command\AddWorkRecord\AddWorkRecordCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Command, 3
.3 4
AddWorkRecord4 A
{ 
public 

class  
AddWorkRecordCommand %
:& '
IRequest( 0
<0 1
int1 4
>4 5
{ 
public 
AddWorkRecordVm 
AddWorkRecordVm .
{/ 0
get1 4
;4 5
set6 9
;9 :
}; <
} 
}		 √
ÅC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Command\AddWorkRecord\AddWorkRecordCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Command, 3
.3 4
AddWorkRecord4 A
{ 
public		 

class		 '
AddWorkRecordCommandHandler		 ,
:		- .
IRequestHandler		/ >
<		> ? 
AddWorkRecordCommand		? S
,		S T
int		U X
>		X Y
{

 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public '
AddWorkRecordCommandHandler *
(* + 
IHRMOptimusDbContext+ ?
context@ G
)G H
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
int 
> 
Handle %
(% & 
AddWorkRecordCommand& :
request; B
,B C
CancellationTokenD U
cancellationTokenV g
)g h
{ 	
var 
duration 
= 
request "
." #
AddWorkRecordVm# 2
.2 3
WorkEnd3 :
.: ;
	TimeOfDay; D
-E F
requestG N
.N O
AddWorkRecordVmO ^
.^ _
	WorkStart_ h
.h i
	TimeOfDayi r
;r s
var 

workRecord 
= 
new  
Domain! '
.' (
Entities( 0
.0 1

WorkRecord1 ;
(; <
)< =
{ 
Name 
= 
request 
. 
AddWorkRecordVm .
.. /
Name/ 3
,3 4
	WorkStart 
= 
request #
.# $
AddWorkRecordVm$ 3
.3 4
	WorkStart4 =
,= >
WorkEnd 
= 
request !
.! "
AddWorkRecordVm" 1
.1 2
WorkEnd2 9
,9 :
Duration 
= 
duration #
,# $
	ProjectId 
= 
request #
.# $
AddWorkRecordVm$ 3
.3 4
	ProjectId4 =
,= >

EmployeeId 
= 
request $
.$ %
AddWorkRecordVm% 4
.4 5

EmployeeId5 ?
} 
; 
_context 
. 
WorkRecords  
.  !
Add! $
($ %

workRecord% /
)/ 0
;0 1
await!! 
_context!! 
.!! 
SaveChangesAsync!! +
(!!+ ,
cancellationToken!!, =
)!!= >
;!!> ?
return"" 

workRecord"" 
."" 
Id""  
;""  !
}## 	
}$$ 
}%% ∆	
uC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Command\AddWorkRecord\AddWorkRecordVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Command, 3
.3 4
AddWorkRecord4 A
{ 
public 

class 
AddWorkRecordVm  
{ 
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public 
DateTime 
	WorkStart !
{" #
get$ '
;' (
set) ,
;, -
}. /
public		 
DateTime		 
WorkEnd		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
public

 
int

 
	ProjectId

 
{

 
get

 "
;

" #
set

$ '
;

' (
}

) *
public 
int 

EmployeeId 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} Ä
~C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Command\AddWorkRecord\AddWorkRecordVmValidator.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Command, 3
.3 4
AddWorkRecord4 A
{ 
public 

class $
AddWorkRecordVmValidator )
:* +
AbstractValidator, =
<= >
AddWorkRecordVm> M
>M N
{		 
public

 $
AddWorkRecordVmValidator

 '
(

' ( 
IHRMOptimusDbContext

( <
	dbContext

= F
)

F G
{ 	
RuleFor 
( 
x 
=> 
x 
. 
Name 
)  
.  !
MinimumLength! .
(. /
$num/ 0
)0 1
;1 2
RuleFor 
( 
x 
=> 
x 
. 
Name 
)  
.  !
NotEmpty! )
() *
)* +
;+ ,
RuleFor 
( 
x 
=> 
x 
. 
	ProjectId $
)$ %
.% &
Custom& ,
(, -
(- .
value. 3
,3 4
context5 <
)< =
=>> @
{ 
var 
project 
= 
	dbContext '
.' (
Projects( 0
.0 1
Any1 4
(4 5
e5 6
=>7 9
e: ;
.; <
Id< >
==? A
valueB G
&&H J
eK L
.L M
EnabledM T
)T U
;U V
if 
( 
! 
project 
) 
context 
. 

AddFailure &
(& '
$str' +
,+ ,
$str- D
+E F
valueG L
+M N
$strO _
)_ `
;` a
} 
) 
; 
RuleFor 
( 
x 
=> 
x 
. 
	WorkStart $
)$ %
.% &
NotEmpty& .
(. /
)/ 0
;0 1
RuleFor 
( 
x 
=> 
x 
. 
WorkEnd "
)" #
.# $
NotEmpty$ ,
(, -
)- .
;. /
RuleFor 
( 
x 
=> 
x 
. 
WorkEnd "
)" #
.# $
GreaterThan$ /
(/ 0
x0 1
=>2 4
x5 6
.6 7
	WorkStart7 @
)@ A
;A B
} 	
} 
} ñ
ÄC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Command\RemoveWorkRecord\RemoveWorkRecordCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Command, 3
.3 4
RemoveWorkRecord4 D
{ 
public 

class #
RemoveWorkRecordCommand (
:) *
IRequest+ 3
{ 
public 
int 
WorkRecordId 
{  !
get" %
;% &
set' *
;* +
}, -
} 
}		 ÷
áC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Command\RemoveWorkRecord\RemoveWorkRecordCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Command, 3
.3 4
RemoveWorkRecord4 D
{		 
public

 

class

 *
RemoveWorkRecordCommandHandler

 /
:

0 1
IRequestHandler

2 A
<

A B#
RemoveWorkRecordCommand

B Y
>

Y Z
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public *
RemoveWorkRecordCommandHandler -
(- . 
IHRMOptimusDbContext. B
contextC J
)J K
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '#
RemoveWorkRecordCommand' >
request? F
,F G
CancellationTokenH Y
cancellationTokenZ k
)k l
{ 	
var 

workRecord 
= 
await "
_context# +
.+ ,
WorkRecords, 7
.7 8
FirstOrDefaultAsync8 K
(K L
xL M
=>N P
xQ R
.R S
IdS U
==V X
requestY `
.` a
WorkRecordIda m
)m n
;n o
if 
( 

workRecord 
== 
null "
)" #
throw 
new 
NotFoundException +
(+ ,
$str, O
+P Q
requestR Y
.Y Z
WorkRecordIdZ f
)f g
;g h
_context 
. 
WorkRecords  
.  !
Remove! '
(' (

workRecord( 2
)2 3
;3 4
await 
_context 
. 
SaveChangesAsync +
(+ ,
cancellationToken, =
)= >
;> ?
return 
Unit 
. 
Value 
; 
} 	
}   
}!! ñ
âC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Command\RemoveWorkRecord\RemoveWorkRecordCommandValidator.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Command, 3
.3 4
RemoveWorkRecord4 D
{ 
public 

class ,
 RemoveWorkRecordCommandValidator 1
:2 3
AbstractValidator4 E
<E F#
RemoveWorkRecordCommandF ]
>] ^
{ 
public		 ,
 RemoveWorkRecordCommandValidator		 /
(		/ 0 
IHRMOptimusDbContext		0 D
	dbContext		E N
)		N O
{

 	
RuleFor 
( 
x 
=> 
x 
. 
WorkRecordId '
)' (
.( )
Custom) /
(/ 0
(0 1
value1 6
,6 7
context8 ?
)? @
=>A C
{ 
var 

workRecord 
=  
	dbContext! *
.* +
WorkRecords+ 6
.6 7
Any7 :
(: ;
e; <
=>= ?
e@ A
.A B
IdB D
==E G
valueH M
&&N P
eQ R
.R S
EnabledS Z
)Z [
;[ \
if 
( 
! 

workRecord 
)  
context 
. 

AddFailure &
(& '
$str' +
,+ ,
$str- G
+H I
valueJ O
+P Q
$strR b
)b c
;c d
} 
) 
; 
} 	
} 
} ´
ÄC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Command\UpdateWorkRecord\UpdateWorkRecordCommand.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Command, 3
.3 4
UpdateWorkRecord4 D
{ 
public 

class #
UpdateWorkRecordCommand (
:) *
IRequest+ 3
{ 
public 
UpdateWorkRecordVm !
UpdateWorkRecordVm" 4
{5 6
get7 :
;: ;
set< ?
;? @
}A B
} 
}		 í
áC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Command\UpdateWorkRecord\UpdateWorkRecordCommandHandler.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Command, 3
.3 4
UpdateWorkRecord4 D
{ 
public		 

class		 *
UpdateWorkRecordCommandHandler		 /
:		0 1
IRequestHandler		2 A
<		A B#
UpdateWorkRecordCommand		B Y
>		Y Z
{

 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public *
UpdateWorkRecordCommandHandler -
(- . 
IHRMOptimusDbContext. B
contextC J
)J K
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
Unit 
> 
Handle  &
(& '#
UpdateWorkRecordCommand' >
request? F
,F G
CancellationTokenH Y
cancellationTokenZ k
)k l
{ 	
var 

workRecord 
= 
await "
_context# +
.+ ,
WorkRecords, 7
.7 8
	FindAsync8 A
(A B
requestB I
.I J
UpdateWorkRecordVmJ \
.\ ]
Id] _
)_ `
;` a
var 
duration 
= 
request "
." #
UpdateWorkRecordVm# 5
.5 6
WorkEnd6 =
.= >
	TimeOfDay> G
-H I
requestJ Q
.Q R
UpdateWorkRecordVmR d
.d e
	WorkStarte n
.n o
	TimeOfDayo x
;x y

workRecord 
. 
Name 
= 
request %
.% &
UpdateWorkRecordVm& 8
.8 9
Name9 =
;= >

workRecord 
. 
	WorkStart  
=! "
request# *
.* +
UpdateWorkRecordVm+ =
.= >
	WorkStart> G
;G H

workRecord 
. 
WorkEnd 
=  
request! (
.( )
UpdateWorkRecordVm) ;
.; <
WorkEnd< C
;C D

workRecord 
. 
Duration 
=  !
duration" *
;* +

workRecord 
. 
	ProjectId  
=! "
request# *
.* +
UpdateWorkRecordVm+ =
.= >
	ProjectId> G
;G H

workRecord 
. 

EmployeeId !
=" #
request$ +
.+ ,
UpdateWorkRecordVm, >
.> ?

EmployeeId? I
;I J
_context 
. 
WorkRecords  
.  !
Update! '
(' (

workRecord( 2
)2 3
;3 4
await   
_context   
.   
SaveChangesAsync   +
(  + ,
cancellationToken  , =
)  = >
;  > ?
return"" 
Unit"" 
."" 
Value"" 
;"" 
}## 	
}$$ 
}%% Â

{C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Command\UpdateWorkRecord\UpdateWorkRecordVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Command, 3
.3 4
UpdateWorkRecord4 D
{ 
public 

class 
UpdateWorkRecordVm #
{ 
public 
int 
Id 
{ 
get 
; 
set  
;  !
}" #
public 
string 
Name 
{ 
get  
;  !
set" %
;% &
}' (
public		 
DateTime		 
	WorkStart		 !
{		" #
get		$ '
;		' (
set		) ,
;		, -
}		. /
public

 
DateTime

 
WorkEnd

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
public 
int 
	ProjectId 
{ 
get "
;" #
set$ '
;' (
}) *
public 
int 

EmployeeId 
{ 
get  #
;# $
set% (
;( )
}* +
} 
} Ω
ÑC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Command\UpdateWorkRecord\UpdateWorkRecordVmValidator.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Command, 3
.3 4
UpdateWorkRecord4 D
{ 
public 

class '
UpdateWorkRecordVmValidator ,
:- .
AbstractValidator/ @
<@ A
UpdateWorkRecordVmA S
>S T
{ 
public		 '
UpdateWorkRecordVmValidator		 *
(		* + 
IHRMOptimusDbContext		+ ?
	dbContext		@ I
)		I J
{

 	
RuleFor 
( 
x 
=> 
x 
. 
Name 
)  
.  !
MinimumLength! .
(. /
$num/ 0
)0 1
;1 2
RuleFor 
( 
x 
=> 
x 
. 
Id 
) 
. 
Custom %
(% &
(& '
value' ,
,, -
context. 5
)5 6
=>7 9
{ 
var 

workRecord 
=  
	dbContext! *
.* +
WorkRecords+ 6
.6 7
Any7 :
(: ;
e; <
=>= ?
e@ A
.A B
IdB D
==E G
valueH M
&&N P
eQ R
.R S
EnabledS Z
)Z [
;[ \
if 
( 
! 

workRecord 
)  
context 
. 

AddFailure &
(& '
$str' +
,+ ,
$str- H
+I J
valueK P
+Q R
$strS c
)c d
;d e
} 
) 
; 
RuleFor 
( 
x 
=> 
x 
. 
	ProjectId $
)$ %
.% &
Custom& ,
(, -
(- .
value. 3
,3 4
context5 <
)< =
=>> @
{ 
var 
project 
= 
	dbContext '
.' (
Projects( 0
.0 1
Any1 4
(4 5
e5 6
=>7 9
e: ;
.; <
Id< >
==? A
valueB G
&&H J
eK L
.L M
EnabledM T
)T U
;U V
if 
( 
! 
project 
) 
context 
. 

AddFailure &
(& '
$str' +
,+ ,
$str- D
+E F
valueG L
+M N
$strO _
)_ `
;` a
} 
) 
; 
RuleFor 
( 
x 
=> 
x 
. 
	WorkStart $
)$ %
.% &
NotEmpty& .
(. /
)/ 0
;0 1
RuleFor 
( 
x 
=> 
x 
. 
WorkEnd "
)" #
.# $
NotEmpty$ ,
(, -
)- .
;. /
RuleFor 
( 
x 
=> 
x 
. 
WorkEnd "
)" #
.# $
GreaterThan$ /
(/ 0
x0 1
=>2 4
x5 6
.6 7
	WorkStart7 @
)@ A
;A B
} 	
} 
}   Ù
xC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Query\DayWorkRecords\DayWorkRecordsQuery.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Query, 1
.1 2
DayWorkRecords2 @
{ 
public 

class 
DayWorkRecordsQuery $
:% &
IRequest' /
</ 0
List0 4
<4 5
WorkRecordDetailsVm5 H
>H I
>I J
{ 
public		 
DateTime		 
DayWork		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
}

 
} €
C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Query\DayWorkRecords\DayWorkRecordsQueryHandler.cs
	namespace		 	

HRMOptimus		
 
.		 
Application		  
.		  !

WorkRecord		! +
.		+ ,
Query		, 1
.		1 2
DayWorkRecords		2 @
{

 
public 

class &
DayWorkRecordsQueryHandler +
:, -
IRequestHandler. =
<= >
DayWorkRecordsQuery> Q
,Q R
ListS W
<W X
WorkRecordDetailsVmX k
>k l
>l m
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public &
DayWorkRecordsQueryHandler )
() * 
IHRMOptimusDbContext* >
context? F
)F G
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
List 
< 
WorkRecordDetailsVm 2
>2 3
>3 4
Handle5 ;
(; <
DayWorkRecordsQuery< O
requestP W
,W X
CancellationTokenY j
cancellationTokenk |
)| }
{ 	
var 
workRecords 
= 
await #
_context$ ,
., -
WorkRecords- 8
. 
Where 
( 
x 
=> 
x 
. 
	WorkStart '
.' (
Date( ,
==- /
request0 7
.7 8
DayWork8 ?
.? @
Date@ D
&&E G
xH I
.I J
EnabledJ Q
)Q R
. 
Include 
( 
x 
=> 
x 
.  
Project  '
)' (
. 
Select 
( 
x 
=> 
new  
WorkRecordDetailsVm! 4
(4 5
x5 6
.6 7
Id7 9
,9 :
x; <
.< =
Name= A
,A B
xC D
.D E
	WorkStartE N
,N O
xP Q
.Q R
WorkEndR Y
,Y Z
x[ \
.\ ]
Duration] e
,e f
xg h
.h i
Projecti p
.p q
Nameq u
)u v
)v w
. 
ToListAsync 
( 
) 
; 
return!! 
workRecords!! 
;!! 
}"" 	
}## 
}$$ ó
xC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Query\DayWorkRecords\WorkRecordDetailsVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Query, 1
.1 2
DayWorkRecords2 @
{ 
public 

record 
WorkRecordDetailsVm %
(% &
int& )
Id* ,
,, -
string. 4
Name5 9
,9 :
DateTime; C
	WorkStartD M
,M N
DateTimeO W
WorkStopX `
,` a
TimeSpanb j
Durationk s
,s t
string 
ProjectName 
) 
; 
} ≠
xC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Query\MonthDaysRecords\DaysWorkRecordsVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Query, 1
.1 2
MonthDaysRecords2 B
{ 
public 

record 
DaysWorkRecordsVm #
(# $
TimeSpan$ ,
	StartHour- 6
,6 7
TimeSpan8 @
EndHourA H
,H I
DateTimeJ R
DayS V
,V W
TimeSpanX `

WorkedTimea k
)k l
;l m
} ÷
|C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Query\MonthDaysRecords\MonthDaysRecordsQuery.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Query, 1
.1 2
MonthDaysRecords2 B
{ 
public 

class !
MonthDaysRecordsQuery &
:' (
IRequest) 1
<1 2
List2 6
<6 7
DaysWorkRecordsVm7 H
>H I
>I J
{ 
public 
int 
? 
MonthFromCurrent $
{% &
get' *
;* +
set, /
;/ 0
}1 2
public		 
int		 
?		 
Month		 
{		 
get		 
;		  
set		! $
;		$ %
}		& '
public

 
int

 
?

 
Year

 
{

 
get

 
;

 
set

  #
;

# $
}

% &
} 
} ë>
ÉC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Query\MonthDaysRecords\MonthDaysRecordsQueryHandler.cs
	namespace

 	

HRMOptimus
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
  !

WorkRecord

! +
.

+ ,
Query

, 1
.

1 2
MonthDaysRecords

2 B
{ 
public 

class (
MonthDaysRecordsQueryHandler -
:. /
IRequestHandler0 ?
<? @!
MonthDaysRecordsQuery@ U
,U V
ListW [
<[ \
DaysWorkRecordsVm\ m
>m n
>n o
{ 
private 
readonly  
IHRMOptimusDbContext -
_context. 6
;6 7
public (
MonthDaysRecordsQueryHandler +
(+ , 
IHRMOptimusDbContext, @
contextA H
)H I
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
List 
< 
DaysWorkRecordsVm 0
>0 1
>1 2
Handle3 9
(9 :!
MonthDaysRecordsQuery: O
requestP W
,W X
CancellationTokenY j
cancellationTokenk |
)| }
{ 	
List 
< 
DaysWorkRecordsVm "
>" #
daysWorksRekords$ 4
=5 6
new7 :
List; ?
<? @
DaysWorkRecordsVm@ Q
>Q R
(R S
)S T
;T U
DateTime 
firstDay 
; 
if 
( 
request 
. 
MonthFromCurrent (
.( )
HasValue) 1
)1 2
{ 
firstDay 
= 
new 
DateTime '
(' (
DateTime( 0
.0 1
Now1 4
.4 5
Date5 9
.9 :
Year: >
,> ?
DateTime@ H
.H I
NowI L
.L M
DateM Q
.Q R
MonthR W
,W X
$numY Z
)Z [
.[ \
	AddMonths\ e
(e f
requestf m
.m n
MonthFromCurrentn ~
.~ 
Value	 Ñ
)
Ñ Ö
;
Ö Ü
} 
else   
if   
(   
request   
.   
Month   "
.  " #
HasValue  # +
&&  , .
request  / 6
.  6 7
Year  7 ;
.  ; <
HasValue  < D
)  D E
{!! 
firstDay"" 
="" 
new"" 
DateTime"" '
(""' (
request""( /
.""/ 0
Year""0 4
.""4 5
Value""5 :
,"": ;
request""< C
.""C D
Month""D I
.""I J
Value""J O
,""O P
$num""Q R
)""R S
;""S T
}## 
else$$ 
{%% 
firstDay&& 
=&& 
new&& 
DateTime&& '
(&&' (
DateTime&&( 0
.&&0 1
Now&&1 4
.&&4 5
Date&&5 9
.&&9 :
Year&&: >
,&&> ?
DateTime&&@ H
.&&H I
Now&&I L
.&&L M
Date&&M Q
.&&Q R
Month&&R W
,&&W X
$num&&Y Z
)&&Z [
;&&[ \
}'' 
var)) 
days)) 
=)) 
DateTime)) 
.))  
DaysInMonth))  +
())+ ,
firstDay)), 4
.))4 5
Year))5 9
,))9 :
firstDay)); C
.))C D
Month))D I
)))I J
;))J K
var** 
lastDay** 
=** 
new** 
DateTime** &
(**& '
firstDay**' /
.**/ 0
Year**0 4
,**4 5
firstDay**6 >
.**> ?
Month**? D
,**D E
days**F J
)**J K
;**K L
var,, 
workRecords,, 
=,, 
await,, #
_context,,$ ,
.,,, -
WorkRecords,,- 8
.-- 
Where-- 
(-- 
x-- 
=>-- 
(-- 
x-- 
.-- 
	WorkStart-- (
.--( )
Date--) -
>=--. 0
firstDay--1 9
||--: <
x--= >
.--> ?
	WorkStart--? H
.--H I
Date--I M
<=--N P
lastDay--Q X
)--X Y
&&--Z \
x--] ^
.--^ _
Enabled--_ f
)--f g
... 
Select.. 
(.. 
x.. 
=>.. 
new..  
WorkRecordVm..! -
(..- .
x... /
.../ 0
Id..0 2
,..2 3
x..4 5
...5 6
	WorkStart..6 ?
,..? @
x..A B
...B C
WorkEnd..C J
,..J K
x..L M
...M N
Duration..N V
)..V W
)..W X
.// 
ToListAsync// 
(// 
)// 
;// 
for11 
(11 
int11 
i11 
=11 
$num11 
;11 
i11 
<=11  
days11! %
;11% &
i11' (
++11( *
)11* +
{22 
TimeSpan33 

workedTime33 #
=33$ %
default33& -
;33- .
TimeSpan44 
	startHour44 "
=44# $
default44% ,
;44, -
TimeSpan55 
endHour55  
=55! "
default55# *
;55* +
var66 
day66 
=66 
new66 
DateTime66 &
(66& '
firstDay66' /
.66/ 0
Year660 4
,664 5
firstDay666 >
.66> ?
Month66? D
,66D E
i66F G
)66G H
;66H I
var77 
rekordsOfDay77  
=77! "
workRecords77# .
.77. /
Where77/ 4
(774 5
x775 6
=>777 9
x77: ;
.77; <
	WorkStart77< E
.77E F
Date77F J
==77K M
day77N Q
)77Q R
.77R S
ToList77S Y
(77Y Z
)77Z [
;77[ \
foreach99 
(99 
var99 
record99 #
in99$ &
rekordsOfDay99' 3
)993 4
{:: 
	startHour;; 
=;; 
	startHour;;  )
>;;* +
record;;, 2
.;;2 3
	WorkStart;;3 <
.;;< =
	TimeOfDay;;= F
||;;G I
	startHour;;J S
==;;T V
default;;W ^
?;;_ `
record;;a g
.;;g h
	WorkStart;;h q
.;;q r
	TimeOfDay;;r {
:;;| }
	startHour	;;~ á
;
;;á à
endHour<< 
=<< 
endHour<< %
<<<& '
record<<( .
.<<. /
WorkStop<</ 7
.<<7 8
	TimeOfDay<<8 A
||<<B D
	startHour<<E N
==<<O Q
default<<R Y
?<<Z [
record<<\ b
.<<b c
WorkStop<<c k
.<<k l
	TimeOfDay<<l u
:<<v w
endHour<<x 
;	<< Ä

workedTime== 
+=== !
record==" (
.==( )
Duration==) 1
;==1 2
}>> 
daysWorksRekords??  
.??  !
Add??! $
(??$ %
new??% (
DaysWorkRecordsVm??) :
(??: ;
	startHour??; D
,??D E
endHour??F M
,??M N
day??O R
,??R S

workedTime??T ^
)??^ _
)??_ `
;??` a
}@@ 
returnBB 
daysWorksRekordsBB #
;BB# $
}CC 	
}DD 
}EE ú
sC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.Application\WorkRecord\Query\MonthDaysRecords\WorkRecordVm.cs
	namespace 	

HRMOptimus
 
. 
Application  
.  !

WorkRecord! +
.+ ,
Query, 1
.1 2
MonthDaysRecords2 B
{ 
public 

record 
WorkRecordVm 
( 
int "
Id# %
,% &
DateTime' /
	WorkStart0 9
,9 :
DateTime; C
WorkStopD L
,L M
TimeSpanN V
DurationW _
)_ `
;` a
} 