þ
ZC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.DemoDataSeeder\Commands\SeedUsers.cs
	namespace 	

HRMOptimus
 
. 
DemoDataSeeder #
.# $
Commands$ ,
{ 
public 

class 
	SeedUsers 
: 
ICustomiseCommand .
{		 
private

 
readonly

 '
DemoDataSeederCustomization

 4(
_demoDataSeederCustomization

5 Q
;

Q R
public 
	SeedUsers 
( '
DemoDataSeederCustomization 4'
demoDataSeederCustomization5 P
)P Q
{ 	(
_demoDataSeederCustomization (
=) *'
demoDataSeederCustomization+ F
;F G
} 	
public 
void 
Execute 
( 
) 
{ 	
PopulateAddressData 
(  
)  !
;! "
} 	
private 
void 
PopulateAddressData (
(( )
)) *
{ 	(
_demoDataSeederCustomization (
.( )
_context) 1
.1 2
ApplicationUsers2 B
.B C
AddRangeC K
(K L
NemDemoUsersL X
(X Y
)Y Z
)Z [
;[ \
} 	
private 
IEnumerable 
< 
ApplicationUser +
>+ ,
NemDemoUsers- 9
(9 :
): ;
{ 	
System 
. 
Console 
. 
	WriteLine $
($ %
$str% 0
)0 1
;1 2
return 
new 
List 
< 
ApplicationUser +
>+ ,
(, -
)- .
;. /
} 	
}   
}!! Í
kC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.DemoDataSeeder\Common\Interfaces\ICustomiseCommand.cs
	namespace 	

HRMOptimus
 
. 
DemoDataSeeder #
.# $
Common$ *
.* +

Interfaces+ 5
{ 
public 

	interface 
ICustomiseCommand &
{ 
public 
	interface 
ICustomiseCommand *
{ 	
void 
Execute 
( 
) 
; 
} 	
}		 
}

 ‡
rC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.DemoDataSeeder\Customizations\DemoDataSeederCustomization.cs
	namespace 	

HRMOptimus
 
. 
DemoDataSeeder #
.# $
Customizations$ 2
{ 
public 

class '
DemoDataSeederCustomization ,
{ 
internal 
readonly  
IHRMOptimusDbContext .
_context/ 7
;7 8
public

 '
DemoDataSeederCustomization

 *
(

* + 
IHRMOptimusDbContext

+ ?
context

@ G
)

G H
{ 	
_context 
= 
context 
; 
} 	
public 
void 
Run 
( 
) 
{ 	
new 
	SeedUsers 
( 
this 
) 
.  
Execute  '
(' (
)( )
;) *
} 	
} 
} ö
[C:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.DemoDataSeeder\DependencyInjection.cs
	namespace 	

HRMOptimus
 
. 
DemoDataSeeder #
{ 
public 

static 
class 
DependencyInjection +
{		 
public

 
static

 
IServiceCollection

 (
AddCustomizations

) :
(

: ;
this

; ?
IServiceCollection

@ R
services

S [
)

[ \
{ 	
services 
. 
	AddScoped 
< '
DemoDataSeederCustomization :
>: ;
(; <
)< =
;= >
services 
. 
	AddScoped 
<  
IHRMOptimusDbContext 3
,3 4
HRMOptimusDbContext5 H
>H I
(I J
)J K
;K L
return 
services 
; 
} 	
} 
} ï
OC:\Users\kdura\source\repos\HRMOptimus\src\HRMOptimus.DemoDataSeeder\Program.cs
	namespace		 	

HRMOptimus		
 
.		 
DemoDataSeeder		 #
{

 
internal 
static 
class 
Program !
{ 
private 
static 
void 
Main  
(  !
)! "
{ 	
try 
{ 
Execute 
( 
) 
; 
} 
catch 
( 
	Exception 
ex 
)  
{ 
Console 
. 
	WriteLine !
(! "
ex" $
.$ %
ToString% -
(- .
). /
,/ 0
ex1 3
.3 4
Message4 ;
); <
;< =
Environment 
. 
ExitCode $
=% &
$num' (
;( )
} 
} 	
private 
static 
void 
Execute #
(# $
)$ %
{ 	
var 
configuration 
= 
new  # 
ConfigurationBuilder$ 8
(8 9
)9 :
. 
SetBasePath 
( 
Path  
.  !
GetDirectoryName! 1
(1 2
Assembly2 :
.: ; 
GetExecutingAssembly; O
(O P
)P Q
.Q R
LocationR Z
)Z [
)[ \
. 
AddJsonFile 
( 
$str .
). /
. 
Build 
( 
) 
; 
var!! 
services!! 
=!! 
new!! 
ServiceCollection!! 0
(!!0 1
)!!1 2
;!!2 3
services"" 
."" 
AddCustomizations"" &
(""& '
)""' (
;""( )
services## 
.## 
AddPersistance## #
(### $
configuration##$ 1
)##1 2
;##2 3
using%% 
(%% 
var%% 
serviceProvider%% &
=%%' (
services%%) 1
.%%1 2 
BuildServiceProvider%%2 F
(%%F G
)%%G H
)%%H I
{&& 
serviceProvider'' 
.''  

GetService''  *
<''* +'
DemoDataSeederCustomization''+ F
>''F G
(''G H
)''H I
.''I J
Run''J M
(''M N
)''N O
;''O P
}(( 
})) 	
}** 
}++ 