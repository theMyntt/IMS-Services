#!/bin/bash

dotnet run --project ./src/Services/Users.API/Users.API.csproj & 
dotnet run --project ./src/Services/Items.API/Items.API.csproj & 
dotnet run --project ./src/Services/Movement.API/Movement.API.csproj &
dotnet run --project ./src/Services/Reports.API/Reports.API.csproj & 
dotnet run --project ./src/Gateway/Bridge.API/Bridge.API.csproj