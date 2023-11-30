# Attendance Management System Web API

Welcome to the Attendance Management System Web API repository! This system is a comprehensive solution for managing attendance, leave requests, payroll, schedules, and reports for users. Built on the robust foundation of ASP.NET Core WebAPI, C#, Entity Framework Core, SQL Server, Jwt Bearer Tokens, and AutoMapper, this system offers powerful features for efficient workforce management.

## Table of Contents
- [Project Overview](#project-overview)
- [File Structure](#file-structure)
- [Relationships](#relationships)
- [Nuget Packages Used](#nuget-packages-used)
- [References](#references)
- [Getting Started](#getting-started)

## Project Overview

The Attendance Management System Web API provides a seamless experience for organizations to handle attendance-related tasks. It leverages ASP.NET Core WebAPI, ensuring scalability and performance. This system integrates seamlessly with a SQL Server database, employing Jwt Bearer Tokens for secure authentication and authorization. AutoMapper is used for efficient object mapping, enhancing code readability.

## File Structure

- **AttendanceManagementSystem.API**
  - **Controllers**
    - Version_1
      - Attendances
      - Authentication
      - LeaveRequests
      - Payrolls
      - Schedules
      - Users
      - Reports
  - **Extensions**
  - **Program.cs**

- **AttendanceManagementSystem.Authentication**
  - **Configurations**
  - **DTOs**
    - CreateDTOs
    - Generic
    - ReadDTOs
  - **Helper**

- **AttendanceManagementSystem.DataAccess**
  - **Data**
  - **Migrations**
  - **Repositories**

- **AttendanceManagementSystem.Domain**
  - **Conts**
  - **DTOs**
    - CreateDTOs
    - ReadDTOs
    - UpdateDTOs
  - **Helper**
  - **Interfaces**
  - **Models**
    - Enums

## Relationships

- (Schedule - User) One to many
- (Report - User) Many to Many
- (Report - LeaveRequest) Many to Many
- (LeaveRequest - User) Many to Many
- (Payroll - User) Many to Many
- (Attendance - User) Many to Many
- (Report - Payroll) Many to Many
- (Report - Attendance) Many to Many

## Nuget Packages Used

### In API Layer:
- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.AspNetCore.Identity.UI
- Microsoft.AspNetCore.Mvc.Versioning
- Microsoft.AspNetCore.OpenApi
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Swashbuckle.AspNetCore

### In DataAccess Layer:
- Microsoft.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.SqlServer

### In Domain Layer:
- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Microsoft.AspNetCore.Identity.UI

## References

- AttendanceManagementSystem.API => AttendanceManagementSystem.DataAccess
- AttendanceManagementSystem.API => AttendanceManagementSystem.Domain
- AttendanceManagementSystem.API => AttendanceManagementSystem.Authentication
- AttendanceManagementSystem.Authentication => AttendanceManagementSystem.Domain
- AttendanceManagementSystem.DataAccess => AttendanceManagementSystem.Domain

## Getting Started

To run the project, ensure you have [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed.

Open a terminal in the **AttendanceManagementSystem.API** directory and run the following commands:

```bash
dotnet restore
dotnet run
```

This will restore the necessary packages and start the API. Visit [https://localhost:7145/swagger](https://localhost:7145/swagger) to explore the API using Swagger documentation.

Feel free to explore the controllers and endpoints to understand the functionalities provided by the Attendance Management System Web API. If you encounter any issues or have questions, please refer to the documentation or reach out to the project maintainers.