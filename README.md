#  Garage Management System

Full-stack project including a .NET Core backend, MongoDB database, and
Angular frontend for managing garage data fetched from
the Israeli government API.

##  Project Overview

This system includes two main parts:

### 1. Backend -- ASP.NET Core + MongoDB

-   Fetch garage data from the official IL government API
    (data.gov.il)
-   Parse and map the received data
-   Store garage records in a MongoDB collection
-   Provide REST API endpoints for the frontend
-   Add new garages manually through an API endpoint
-   All database operations are asynchronous (Async/Await)

### 2. Frontend -- Angular 17 + Angular Material

-   Display garages retrieved from the government API
-   Multi-select component for choosing garages to add to the database
-   Separate table displaying garages stored in MongoDB
-   Full validation: skip existing, add only new, instant UI update
-   Smooth animations
-   Filtering options
-   HttpClient communication

##  Technologies Used

### Backend

-   ASP.NET Core 8
-   MongoDB + MongoDB.Driver
-   HttpClient
-   Clean layering: Controller + Service + Models

### Frontend

-   Angular 17+
-   Angular Material
-   HttpClientModule
-   FormsModule
-   MatTable, MatSelect, MatFormField, MatButton
-   Custom CSS animations

##  API Endpoints

  Action                   Method   Endpoint
  ------------------------ -------- ----------------------------
  Fetch and save garages   GET      /api/garages/sync-from-gov
  Get all garages          GET      /api/garages
  Add a new garage         POST     /api/garages

##  Backend Folder Structure

    GarageApi/
    ├── Controllers/
    │   └── GaragesController.cs
    ├── Services/
    │   └── GaragesService.cs
    ├── Models/
    │   ├── Garage.cs
    │   └── GovApiResponse.cs
    ├── Settings/
    │   └── MongoDbSettings.cs
    ├── appsettings.json
    └── Program.cs

##  Frontend Folder Structure

    garages-client/
    ├── src/app/
    │   ├── components/
    │   │   └── garages/
    │   │       ├── garages.component.ts
    │   │       ├── garages.component.html
    │   │       └── garages.component.css
    │   ├── services/
    │   │   └── garages.service.ts
    │   ├── models/
    │   │   └── garage.ts
    │   └── app.module.ts
    └── angular.json

##  How to Run

### Backend

    cd GarageApi
    dotnet restore
    dotnet run

Runs on: http://localhost:5000

### Frontend

    cd garages-client
    npm install
    ng serve --open

Runs on: http://localhost:4200

##  Key Features

-   Government API integration\
-   Multi-select import\
-   Separate tables (gov + DB)\
-   UI animations
