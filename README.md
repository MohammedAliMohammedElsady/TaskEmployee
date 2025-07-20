# 📦 EmployeeApi  - .NET Core Api

This is a backend API built with **ASP.NET Core (.NET 8)**.


## ✅ Prerequisites

Ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022 or later (with ASP.NET & web development workload)
- SQL Server (Local or Remote)


## 🚀 Run the API

1. Open the project in Visual Studio.
2. Configure the connection string in `appsettings.json` under `DefaultConnection`.


### 🔐 Connection String Options

- **Windows Authentication** (default on local machines):

```json
"DefaultConnection": "Server=localhost;Database=EmployeeDb;Integrated Security=True;TrustServerCertificate=True;"

```

- **Sql Server Authentication** (default on local machines):

```json
"DefaultConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=True;"

```

### 🚀 Run Application

- Run the application using the HTTP launch profile.
- Application Run in http://localhost:5242



-----------------------------------------------------------------------------------------------------------------------------------------------------------------------


# 📦 EmployeeFrontEnd - Angular 20 + SSR

This is an Angular 20 project with Angular Material, Bootstrap 5, and server-side rendering (SSR) using Express.

---

## ✅ Prerequisites

Make sure you have the correct versions installed:

- **Node.js:** ^18.x (recommended for Angular 20)
- **npm:** Comes with Node.js, version ^9.x or ^10.x
---

## 🚀 Installation

```bash

# Clone the project
git clone <your-repo-url>
cd employee-front-end

# Install dependencies
npm install -g @angular/cli

npm install

```

## 🚀 Run Application


- Run This Command --> ng serve
- Application Run in http://localhost:4200/


