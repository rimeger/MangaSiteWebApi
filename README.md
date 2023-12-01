# Web api for manga website 

## Table of Contents

* [About the Project](#about-the-project)
  * [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Admin Credentials](#admin-credentials)

## About the project

Web api built using ASP.NET Core Web api, having JWT authentication and role based access control with static separation of roles(user can be logged in only with one role at a time). 
Back-end was created using clean architecture and unit tests.

In this web api, user can read, create, update and delete:
* Titles
* Chapters
* Pages

### Built with
* ASP.NET Core Web api
* SqlServer
* AutoMapper
* MediatR
* Fluent Validation
* xUnit
* Fluent Assertions
* NSubstitute   

## Getting Started
These instructions will get you a copy of this project up and running on your local machine, for development and testing purposes.

### Prerequisites
- .NET 7.0 

#### Clone repository
```
git clone https://github.com/rimeger/MangaSiteWebApi
```
#### Visual Studio or Rider
Open .sln file and run/debug project
#### Docker
```
cd MangaSiteWebApi
docker-compose up -d
```

### Admin Credentials
username:
```
admin
```
password:
```
!@#$%^&*(admin)1128
```
