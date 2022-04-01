# AvanceradDOTNET_Projekt
## Table of contents
* [ABOUT](#ABOUT)
* [URL:s for calling the API](#URL:s---for---calling---the---API:)
* [Reflection (VG-Uppgift)](#Reflection)
## ABOUT
This is the final project in a course i'm taking that's called Advanced .NET. The purpose of this project is to build a Web-API and a database so that we can use it in our next course in Webdevelopement as the Backend part.
## URL:s for calling the API:
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
### <ins>Skriva ett resonemang kring din arkitektur och dina val av tekniska metoder i din readme-fil i ditt GIT-repo. Detta resonemang ska vara nyanserat, dvs du ska resonera kring för och nackdelar med din lösning i projektet.</ins>
Jag började projektet med att, genom kraven som fanns, modulera en databas via ett ER-diagram. Jag var först inne på att ha 4 olika tabeller, Employee, Project, EmployeeProject (Kopplingstabell) och TimeReport. Men efter övervägande så kom jag fram till att endast ha tre tabeller genom att ta bort den tilltänkta kopplingstabeller mellan Employee och Project och ersätta den med tabellen för TimeReport.
Då jag såg att data i princip skulle upprepa sig om jag haft kvar båda tabellerna valde jag att bara ha kvar TimeReport. Jag såg också att jag kunde nyttja denna modell bättre när jag skulle anropa databasen genom EntityFramework.
Nackdelen blev att databasen inte är öppen för fler tabeller mellan Employee och Project. Skulle det vara så att jag behöver någonting som knyter an till de båda likt Timereport så hade jag valt att göra en ren kopplingstabell med nycklar till TimeReport m.fl.

När modelleringen av databasen kändes färdig så byggde jag upp databasens entiteter i ett klassbibliotek med mappen "models", dels för att det var kravet på projekten men också för att jag tycker att det är en tydlig och bra struktur. För att kunna arbeta effektivt med EntityFramework så lade jag till en lista av TimeReport i både Employee och Project, samt objekt av Employee och Project i TimeReport, för att skapa en många till många relation. Att ha listorna gör det enklare att kunna hämta exempelvis tidrapporter för en anställd eller anställda i ett projekt.
 En nackdel med listorna tycker jag är att JSON filen som returneras i Http protokollet innehåller en del data som inte behöver visas med tanke på vad man efterfrågar. En möjlig väg att undvika detta är att skapa klasser för att returnera det man vill och exempelvis ha dem i en mapp som kallas ViewModel. Men å andra sidan så är det inte slutanvändaren själv som kommer att läsa JSON filen, utan det är upp till front-end sidan att presentera det som skall presenteras i slutändan. En annan möjlighet som jag kommer att kolla vidare på är att använda AutoMapper för att kunna styra vad som skickas i JSON och ej.
 
När alla relationer och entiteter var klara så skapade jag databasen code-first och började sedan att arbeta med Web-Api:t i ett nytt projekt i min solution som är ett ASP.NET CORE Web API projekt. Jag började bygga upp en modell enligt Repository pattern för att det var krav i projektet, men också för att jag inser att det är ett bra sätt at skydda data på, det blir flexibelt i framtiden och alla andra fördelar som kommer med att ha det loose-coupled.
 Här började jag att skriva ett generiskt interface i mappen Services med de grundläggande CRUD operationerna som jag kallar för IRestAPI. Jag började sedan att bygga upp ett repository för varje entitet som jag kommer att hämta data från i API:et, detta i samma mapp. När jag implementerat mitt generiska interface så insåg jag att Employee- och projectRepository behövde fler metoder än vad jag hade i IRestAPI och gjorde därför två nya interface, IEmployee och IProject, som båda ärver av IRestAPI och därav har alla de grundläggande CRUD operationerna men också det som är specifikt för de olika entiteterna.
 
 Tack vare listorna i mina entiteter kunde jag ha stor nytta av Include och ThenInclude i mina repositories, vilket jag tycker är ett effektivt sätt att kunna hämta data. Jag valde också att i TimeReports använda Employee- och ProjectId properties som komplement till deras objekt properties. Detta för att det lättare ska gå att söka upp en enskild Employee eller Project utan att behöva använda Include när man söker mot databasen, vilket gör att mindre data behöver laddas in.
 En del som jag har varit lite tveksam till är Week property:n i TimeReports, som returnerar veckonummer genom objektet i programmet. Det vill säga att veckonumret ej sparas i tabellen i databasen. Det gör att jag behöver ladda in alla tidrapporter från en anställd till minnet för att sedan kunna använda Linq in-memory och kolla av veckonummer då jag behöver filtrera på dessa. Ett sätt hade varit att begära veckonumret i frontend för att kunna skicka rakt in i objektet. Eller att sätta veckonumret i Create funktionen i TimeReportRepo. Å andra sidan så är det endast i en request som vi använder oss av veckonummer, vilket inte belastar minnet för mycket. 
 För att kunna veta vilket år man vill se veckan ifrån så lade jag till år i request:en. Och kunde därför minska antalet tidrapporter som behöver in i minnet till de för det angivna året.
 
Samtidigt som jag byggde upp mina repositories så byggde jag Controllers för att hantera Http-protokollet och requests utifrån. Jag arbetade en del med att få till en tydlighet i hur man skall skriva sina request:s till API:t. Jag lade bland annat till nya routes på platser där jag tycker att de bidrar till en tydlighet.
Som exempel så för att få ut alla tidrapporter från en specifik anställd så använde jag mig av den vanliga url:en för specifik anställd, /api/employees/{id}, men lade till efter id:t "/timereports" , alltså /api/employees/{id}/timereports, vilket jag tycker gör det tydligt att man vill åt tidrapporter för denna anställda och inte bara grundläggande info om den.
För att få ut antal arbetade timmar en viss vecka på en specifik anställd gjorde jag liknande lösning för att få en kontinuitet i det "api/{id}/hoursworked", men behövde också få in veckonummer och år i requesten. Därför valde jag att använda mig av query i Url:en, vilket gör att man behöver lägga till "?week={veckonummer}&year={år}" till URL:en.
Jag tycker att detta blir tydligt vad som behöver in i requesten, men det kan också bli svårt att förstå om man inte upprättar en dokumentation kring hur API:et skall användas.

Överlag är jag nöjd med mitt projekt och jag tycker att det har en tydlighet vilket gör att det är lättare att bygga på i framtiden. Jag har också försökt hålla en kontinuitet i hur API:et skall anropas vilket jag hoppas bidrar till att et blir enklare för front-end sidan att använda.

