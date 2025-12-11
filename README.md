# Northwind LINQ Exercises 🎓

A C# educational project focused on mastering **Entity Framework Core** and **LINQ**.
The goal is to solve classic SQL problems using modern .NET techniques, verifying the logic through unit tests.

> **Note:** This project is currently in the **Logic & Data Layer** phase. A REST API implementation is planned for the future (see Roadmap).

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_9-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![EF Core](https://img.shields.io/badge/EF_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![xUnit](https://img.shields.io/badge/xUnit-Testing-success?style=for-the-badge)

## 📝 About The Project

This repository acts as my coding playground. I am taking a list of SQL challenges and "translating" them into efficient C# LINQ queries.

* **The Exercises**: The challenges are based on the list found in this repository: [eirkostop/SQL-Northwind-exercises](https://github.com/eirkostop/SQL-Northwind-exercises).
* **The Database**: I am using the standard Microsoft Northwind sample database.

Instead of writing raw SQL, I focus on interacting with the database in a type-safe, object-oriented manner using **Entity Framework Core**.

## 🚀 Key Learning Goals

* **SQL to LINQ Translation**: Converting mental SQL models (`SELECT`, `WHERE`, `JOIN`, `GROUP BY`) into fluent LINQ syntax.
* **Database First Approach**: Generating C# models from an existing SQL Server database using Scaffolding.
* **Unit Testing**: Verifying database logic using **xUnit** and **EF Core InMemory Database**, ensuring that queries return correct results without hitting the production database.

## 🗺️ Roadmap & Future Plans

This project is a work in progress. My current and future goals are:

- [x] Setup Entity Framework Core (Database First).
- [ ] Do all Nortwind exercices 
- [ ] Create Unit Tests using InMemory Database.
- [ ] **Build a REST API (ASP.NET Core)** to expose these solutions as endpoints.

## 🧪 How to Verify (Testing)

Since there is no API interface yet, the best way to see the code in action is via Unit Tests.

1.  Open the project in Visual Studio.
2.  Open **Test Explorer** (`Test` -> `Test Explorer`).
3.  Run all tests to verify that the LINQ queries produce the expected results against the In-Memory database.

## ⚙️ Setup

1.  **Clone the repo**
    ```bash
    git clone [https://github.com/your-username/northwind-linq-exercises.git](https://github.com/your-username/northwind-linq-exercises.git)
    ```
2.  **Database (Optional for now)**
    * While the tests run In-Memory, to use the real context you need the [Northwind SQL Script](https://github.com/microsoft/sql-server-samples/tree/master/samples/databases/northwind-pubs).
    * Update `ConnectionStrings` in `appsettings.json`.

---
## 👤 Author

**Jan Kołodziej** 💼 .NET C# Developer  
📧 [jankolodziej@outlook.com](mailto:jankolodziej@outlook.com)  
🔗 [LinkedIn Profile](https://www.linkedin.com/in/jan-kolodziej-krk/)

---

>This project is dedicated to my colleague [Wiktor Janecki](https://github.com/WiktorJanecki) from Novomatic.
>The second you look at code you will know what it is about 😎
---
