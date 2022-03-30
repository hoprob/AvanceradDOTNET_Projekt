# AvanceradDOTNET_Projekt
## About
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
PUT `https://localhost:44318/api/employees/8`  (/api/employees/{employeeId})
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
DELETE `https://localhost:44318/api/employees/8`  (/api/employees/{employeeId})
### <ins>Add, Update and Delete projects</ins>
POST `https://localhost:44318/api/projects`<br>
Body:<br>
```
{
    "projectName": "Kvarteret Test",
    "projectNumber": "55-2645"
}
```
PUT `https://localhost:44318/api/projects/7`  (/api/projects/{projectId})
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
PUT `https://localhost:44318/api/timereports/12`  (/api/timereports/{timereportId})
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
## Reflektion(In Swedish)
