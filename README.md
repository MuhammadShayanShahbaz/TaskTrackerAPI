# 🚀 NorthBay Task Tracker (3-Tier API Architecture)

## 💡 Why I Built This
I built this project to demonstrate my ability to engineer a strict, enterprise-grade **3-Tier Architecture**. I wanted to move away from tightly coupled web apps and prove that I can build a standalone, headless backend engine that any client—whether it's a mobile app, a desktop browser, or a third-party service—can securely plug into. 

This repository contains the complete lifecycle of that system: a C# .NET 10 REST API, a SQL Server database driven by Stored Procedures, and a completely decoupled Vanilla JavaScript client to prove the cross-network connectivity.

## 🏗️ How I Structured the Engine (The 3 Tiers)

* **Tier 1: Presentation Layer (The Client)**
  I built a lightweight HTML/JS/CSS client that lives completely outside the C# environment. It uses the modern `fetch()` API to send asynchronous CRUD requests to the backend. It has zero direct access to the database.
* **Tier 2: Business Logic Layer (The C# Web API)**
  This is the brain of the operation. I wrote a .NET 10 RESTful API that catches incoming HTTP requests (`GET`, `POST`, `PUT`, `DELETE`), validates the data, enforces CORS policies, and dictates how the application should respond.
* **Tier 3: Data Access Layer (SQL Server)**
  To ensure maximum security, the C# API never writes raw SQL queries. Instead, I engineered the database using **T-SQL Stored Procedures**. The API simply hands the validated data to the stored procedure, protecting the system from SQL injection attacks.

## 🛠️ The Tech Stack
* **Backend:** C# / .NET 10 Web API
* **Database:** Microsoft SQL Server / T-SQL
* **Frontend:** HTML5, CSS3, Vanilla JavaScript
* **Networking:** Cross-Origin Resource Sharing (CORS), Headless Local IP Binding

## 🧠 Core Features & Personal Learnings

* **Decoupled State Management:** I designed the frontend to update asynchronously. When a user marks a task as "Completed," the UI doesn't reload the whole page; it fires a `PUT` request to the API, waits for the 200 OK success code, and repaints the DOM.
* **Network & Mobile Testing:** I intentionally bound the C# server to listen on `http://0.0.0.0:5000`. This allowed me to break out of `localhost` and test the API live across my local Wi-Fi network using a mobile device, handling aggressive mobile browser caching along the way.
* **Linguist Overrides:** I configured a `.gitattributes` file to categorize the frontend as "vendored" code, ensuring that the repository statistics accurately reflect this as a **Backend/C#** project.

## ⚙️ How to Run This Project Locally

**1. Set up the Database:**
* Open Microsoft SQL Server Management Studio (SSMS).
* Run the scripts provided in `DatabaseSetup.sql` to generate the `Projects` and `Tasks` tables, along with all associated Stored Procedures.

**2. Start the Backend Engine:**
* Open a terminal inside the root project folder.
* Update the SQL connection string in the Data Access file to match your local machine.
* Run the following command to start the server headlessly:
  ```bash
  dotnet run --urls "[http://0.0.0.0:5000](http://0.0.0.0:5000)"
