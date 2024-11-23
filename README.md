# IMS Application Services

Inventory Management System (IMS) is an application for Management of Items, I'm <br/>
building the Services with ASP.NET Core, .NET 8 and Microservices Arch.
- In `/src/Gateway` we have `Bridge.API` project for our Reverse Proxy.
- In `/tests` we have all `xUnit` projects

## Requirements

- Microsoft .NET 8 SDK
- Microsoft SQL Server

## Development Use

- Clone this Repo
- Run Restore with `dotnet restore`

### Windows
- Start all projects in dev mode with `.\start.ps1` (powershell only)

### Linux and macOS
- Start all projects in dev mode with `./start.sh` 
