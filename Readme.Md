# Task Manager API

**Authors**: Luay Younus
**Version**: 1.0.0

## Overview
Task Manager API that deployed on Azure.


## Getting Started
The following are required to run the program locally.
- [Visual Studio 2017 Community with .NET Core 2.0 SDK](https://www.microsoft.com/net/core#windowscmd)
- [GitBash / Terminal](https://git-scm.com/downloads) or [GitHub Extension for Visual Studio](https://visualstudio.github.com)

1. Clone the repository to your local machine.
2. Cd into the application directory where the `AppName.sln` exist.
3. Open the application using `Open/Start AppName.sln`.
4. Click `Tools` -> `NuGet Package Manager` -> `Package Manager Console` then run the following commands in the console.
```css
- Install-Package Microsoft.EntityFrameworkCore.Tools
- Add-Migration Initial
- Update-Database
```

# API Endpoints

#### Link to deployment on Azure

[![APIEndPoint](https://raw.githubusercontent.com/MidTermProject/Monster-Hunter-API/master/Resources/azure-logo.png?raw=true) ](http://taskmanagerapi-cf.azurewebsites.net/api/)

Getting all Todos from the Database

```yaml
GET: api/TaskManager
```

Getting a single Todo by ID.

```yaml
GET: api/TaskManager/{id}
```

Post/Create a new Todo on the Database

```yaml
POST: api/TaskManager/
```

Update a Todo

```yaml
PUT: api/TaskManager/{id}
```

Delete a Todo from the Database

```yaml
DELETE: api/TaskManager/{id}
```


#### Todo JSON Example
```json
[
    {
        "id": 1,
        "description":"Buy groceries",
        "done": true
    },
    {
        "id": 2,
        "description":"Go to work",
        "done": false
    }
]
```


### Frameworks & Dependencies
- Entity Framework Core
- ASP.NET Core
- Xunit
- Test Host

## Architecture
C# ASP.NET Core MVC Application
