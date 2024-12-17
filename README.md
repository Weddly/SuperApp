# About

It's a Web Application that generates card decks based on third part API data. It's persisted in a MySQL storage database in AWS.
You can watch an overview of the project on Youtube [here](https://www.youtube.com/watch?v=2r4kw3fwDYg).
This is a study project for the development of the following concepts:

- DDD
- Clean Architecture
- SOLID
- .NET 9
- EF Core
- Hangfire Job
- MySQL
- AWS
- Vue.js

# Structure

This solution is divided into 3 main parts:

- The WebAPI in .NET 9 inside the SuperApp.API folder.
- The FrontEnd WebAPP in Vue 3 inside the SuperApp. Web folder.
- The Work Service jobs were developed using Hangfire inside the SuperApp.Work folder

# Running

To run the project, it will be necessary to configure an appsetting.json with connections to a MySql database.

You also need to get an Access Token to use the SuperHero API. Details are on the [link](https://superheroapi.com/index.html).

## SuperApp. Web

Project setup

```
npm install
```

Compiles and hot-reloads for development

```
dotnet run
```

## SuperApp.Worker

Build and run

```
dotnet run
```
