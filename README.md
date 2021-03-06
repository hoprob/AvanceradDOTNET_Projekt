# AvanceradDOTNET_Projekt
## Table of contents
* [ABOUT](#ABOUT)
* [URLs for calling the API](#URLs-for-calling-the-API)
* [Reflection (VG-Uppgift)](#Reflection)
* [ER-Model](#ER-Model)
## ABOUT
This is the final project in a course i'm taking that's called Advanced .NET. The purpose of this project is to build a Web-API and a database so that we can use it in our next course in Webdevelopement as the Backend part.
## URLs for calling the API
### <ins>Get all Employees</ins>
GET `https://localhost:44318/api/employees` (api/employees)
### <ins>Get detailed information about a specific employee and their timereports</ins>
GET `https://localhost:44318/api/employees/5/timereports` (api/employees/{employeeId}/timereports
### <ins>Get a list of employees at a specific project</ins>
GET `https://localhost:44318/api/projects/1/employees`  (/api/projects/{projectId}/employees)
### <ins>Get the amount of hours an employee has worked in a specific week</ins>
GET `https://localhost:44318/api/employees/4/hoursworked?year=2021&week=29`  (/api/employees/{employeeId}/hoursworked?year={year}&week={week})
### <ins>Add, Update and Delete employees</ins>
POST `https://localhost:44318/api/employees`<br>
Body:<br>
```
{
  "firstName": "Magnus",
  "lastName": "Hansson",
  "address": "Jaktgatan 5 , 43264 Rolfstorp",
  "phone": "0702356159"
}
```
PUT `https://localhost:44318/api/employees/8`  (/api/employees/{employeeId})<br>
Body:<br>
```
{
    "id": 8,
    "firstName": "Magnus",
    "lastName": "Hansson",
    "address": "Jaktgatan 6 , 43264 Rolfstorp",
    "phone": "0702356159"
}
```
DELETE `https://localhost:44318/api/employees/8`  (/api/employees/{employeeId})<br>
### <ins>Add, Update and Delete projects</ins>
POST `https://localhost:44318/api/projects`<br>
Body:<br>
```
{
    "projectName": "Kvarteret Test",
    "projectNumber": "55-2645"
}
```
PUT `https://localhost:44318/api/projects/7`  (/api/projects/{projectId})<br>
Body:<br>
```
{
    "id": 7,
    "projectName": "Test Test",
    "projectNumber": "55-5555"
}
```
DELETE `https://localhost:44318/api/projects/7`  (/api/projects/{projectId})

### <ins>Add, Update and Delete Timereports</ins>
POST `https://localhost:44318/api/timereports`<br>
Body:<br>
```
{
    "date": "2022-03-31T00:00:00",
    "hoursWorked": 2,
    "employeeId": 2,
    "projectId": 3
}
```
PUT `https://localhost:44318/api/timereports/12`  (/api/timereports/{timereportId})<br>
Body:<br>
```
{
    "id": 12,
    "date": "2022-03-28T00:00:00",
    "week": 13,
    "hoursWorked": 3,
    "employeeId": 2,
    "projectId": 3
}
```
DELETE `https://localhost:44318/api/timereports/12`  (/api/timereports/{timereportId})
## Reflection
### <ins>Skriva ett resonemang kring din arkitektur och dina val av tekniska metoder i din readme-fil i ditt GIT-repo. Detta resonemang ska vara nyanserat, dvs du ska resonera kring f??r och nackdelar med din l??sning i projektet.</ins>
Jag b??rjade projektet med att, genom kraven som fanns, modulera en databas via ett ER-diagram. Jag var f??rst inne p?? att ha 4 olika tabeller, Employee, Project, EmployeeProject (Kopplingstabell) och TimeReport. Men efter ??verv??gande s?? kom jag fram till att endast ha tre tabeller genom att ta bort den tillt??nkta kopplingstabeller mellan Employee och Project och ers??tta den med tabellen f??r TimeReport.
D?? jag s??g att data i princip skulle upprepa sig om jag haft kvar b??da tabellerna valde jag att bara ha kvar TimeReport. Jag s??g ocks?? att jag kunde nyttja denna modell b??ttre n??r jag skulle anropa databasen genom EntityFramework.
Nackdelen blev att databasen inte ??r ??ppen f??r fler tabeller mellan Employee och Project. Skulle det vara s?? att jag beh??ver n??gonting som knyter an till de b??da likt Timereport s?? hade jag valt att g??ra en ren kopplingstabell med nycklar till TimeReport m.fl.

N??r modelleringen av databasen k??ndes f??rdig s?? byggde jag upp databasens entiteter i ett klassbibliotek med mappen "models", dels f??r att det var kravet p?? projekten men ocks?? f??r att jag tycker att det ??r en tydlig och bra struktur. F??r att kunna arbeta effektivt med EntityFramework s?? lade jag till en lista av TimeReport i b??de Employee och Project, samt objekt av Employee och Project i TimeReport, f??r att skapa en m??nga till m??nga relation. Att ha listorna g??r det enklare att kunna h??mta exempelvis tidrapporter f??r en anst??lld eller anst??llda i ett projekt.
 En nackdel med listorna tycker jag ??r att JSON filen som returneras i Http protokollet inneh??ller en del data som inte beh??ver visas med tanke p?? vad man efterfr??gar. En m??jlig v??g att undvika detta ??r att skapa klasser f??r att returnera det man vill och exempelvis ha dem i en mapp som kallas ViewModel. Men ?? andra sidan s?? ??r det inte slutanv??ndaren sj??lv som kommer att l??sa JSON filen, utan det ??r upp till front-end sidan att presentera det som skall presenteras i slut??ndan. En annan m??jlighet som jag kommer att kolla vidare p?? ??r att anv??nda AutoMapper f??r att kunna styra vad som skickas i JSON och ej.
 
 *Update* 
 
 *Jag har nu l??st p?? om och implementerat AutoMapper i mitt projekt. AuttoMapper ??r verkligen anv??ndbart f??r att kunna forma och styra vilken data som skickas med i Json filen i en response. Det ??r bra dels f??r att man slipper on??dig dagta och f??r en resn och snygg Json till Frontend, men ocks?? f??r att inte beh??va visa data som kan vara k??nslig eller on??dig ??ver http protokollet. Med andra ord s?? kan man skapa en s??krare och tydligare applikation med hj??lp av AutoMapper. Det ??r en klar f??rdel att anv??nda AutoMapper f??r strukturen och klarheten i koden. Genom att skapa modeller och kopiera till desssa genom AutoMapepr s?? slipper man stegen att antingen kopiera property f??r property sj??lv mellan objekt eller att returnera alternativa objekt inom programmet. AutoMapper sk??ter mappningen i bara en rad och man kan anv??nda sina ordinarie objekt hela v??gen tills det att de skall skickas iv??g. Den enda nackdelen som jag ser med AutoMapper ??r att det blir fler klasser och mappar i projektet, vilket g??r att det kan bli mer komplicerat att f??rst?? och s??tta sig in i projektet. Men i det stora hela s?? tycker jag att f??rdelarna i detta fall ??vervinner nackdelarna.*
 
N??r alla relationer och entiteter var klara s?? skapade jag databasen code-first och b??rjade sedan att arbeta med Web-Api:t i ett nytt projekt i min solution som ??r ett ASP.NET CORE Web API projekt. Jag b??rjade bygga upp en modell enligt Repository pattern f??r att det var krav i projektet, men ocks?? f??r att jag inser att det ??r ett bra s??tt at skydda data p??, det blir flexibelt i framtiden och alla andra f??rdelar som kommer med att ha det loose-coupled.
 H??r b??rjade jag att skriva ett generiskt interface i mappen Services med de grundl??ggande CRUD operationerna som jag kallar f??r IRestAPI. Jag b??rjade sedan att bygga upp ett repository f??r varje entitet som jag kommer att h??mta data fr??n i API:et, detta i samma mapp. N??r jag implementerat mitt generiska interface s?? ins??g jag att Employee- och projectRepository beh??vde fler metoder ??n vad jag hade i IRestAPI och gjorde d??rf??r tv?? nya interface, IEmployee och IProject, som b??da ??rver av IRestAPI och d??rav har alla de grundl??ggande CRUD operationerna men ocks?? det som ??r specifikt f??r de olika entiteterna.
 
 Tack vare listorna i mina entiteter kunde jag ha stor nytta av Include och ThenInclude i mina repositories, vilket jag tycker ??r ett effektivt s??tt att kunna h??mta data. Jag valde ocks?? att i TimeReports anv??nda Employee- och ProjectId properties som komplement till deras objekt properties. Detta f??r att det l??ttare ska g?? att s??ka upp en enskild Employee eller Project utan att beh??va anv??nda Include n??r man s??ker mot databasen, vilket g??r att mindre data beh??ver laddas in.
 En del som jag har varit lite tveksam till ??r Week property:n i TimeReports, som returnerar veckonummer genom objektet i programmet. Det vill s??ga att veckonumret ej sparas i tabellen i databasen. Det g??r att jag beh??ver ladda in alla tidrapporter fr??n en anst??lld till minnet f??r att sedan kunna anv??nda Linq in-memory och kolla av veckonummer d?? jag beh??ver filtrera p?? dessa. Ett s??tt hade varit att beg??ra veckonumret i frontend f??r att kunna skicka rakt in i objektet. Eller att s??tta veckonumret i Create funktionen i TimeReportRepo. ?? andra sidan s?? ??r det endast i en request som vi anv??nder oss av veckonummer, vilket inte belastar minnet f??r mycket. 
 F??r att kunna veta vilket ??r man vill se veckan ifr??n s?? lade jag till ??r i request:en. Och kunde d??rf??r minska antalet tidrapporter som beh??ver in i minnet till de f??r det angivna ??ret.
 
Samtidigt som jag byggde upp mina repositories s?? byggde jag Controllers f??r att hantera Http-protokollet och requests utifr??n. Jag arbetade en del med att f?? till en tydlighet i hur man skall skriva sina request:s till API:t. Jag lade bland annat till nya routes p?? platser d??r jag tycker att de bidrar till en tydlighet.
Som exempel s?? f??r att f?? ut alla tidrapporter fr??n en specifik anst??lld s?? anv??nde jag mig av den vanliga url:en f??r specifik anst??lld, /api/employees/{id}, men lade till efter id:t "/timereports" , allts?? /api/employees/{id}/timereports, vilket jag tycker g??r det tydligt att man vill ??t tidrapporter f??r denna anst??llda och inte bara grundl??ggande info om den.
F??r att f?? ut antal arbetade timmar en viss vecka p?? en specifik anst??lld gjorde jag liknande l??sning f??r att f?? en kontinuitet i det "api/{id}/hoursworked", men beh??vde ocks?? f?? in veckonummer och ??r i requesten. D??rf??r valde jag att anv??nda mig av query i Url:en, vilket g??r att man beh??ver l??gga till "?week={veckonummer}&year={??r}" till URL:en.
Jag tycker att detta blir tydligt vad som beh??ver in i requesten, men det kan ocks?? bli sv??rt att f??rst?? om man inte uppr??ttar en dokumentation kring hur API:et skall anv??ndas.

??verlag ??r jag n??jd med mitt projekt och jag tycker att det har en tydlighet vilket g??r att det ??r l??ttare att bygga p?? i framtiden. Jag har ocks?? f??rs??kt h??lla en kontinuitet i hur API:et skall anropas vilket jag hoppas bidrar till att et blir enklare f??r front-end sidan att anv??nda.

## ER-Model
![ER-Diagram](ER.jpeg)
