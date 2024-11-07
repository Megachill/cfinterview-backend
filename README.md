# Baseline Interview Project

## Setup

### Pre-requisites
- Docker for Desktop (Windows/Mac) ++ docker-compose
- ASP .NET Core 8 SDK

### Notes:
- The project is setup to run on a docker container with a PostgresSQL database.
- The DataContext is located in our Context Project
- The API is located in the API Project

### Installation
- Clone the repository

```bash
git clone 
```

- Navigate to the project main directory and start the docker containers via docker-compose

```bash
docker-compose up -d
```

- Setup the database by running the migrations with dotnet ef tools

```bash
dotnet ef database update --project=Context --startup-project=API --context=Context.DataContext
```

- Seed the database with the initial data

```bash
dotnet run --project=API --seed
```

## Running the application

- Navigate to the API project directory and run the application

```bash
dotnet run
```
or simply if using an IDE run via your IDE of choice.

## The Task
