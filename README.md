# Employee Remittance Management System

This is a web-based Employee Remittance Management System built using **ASP.NET MVC** as part of my internship at **Inficare Pvt. Ltd.**, a fintech company. The project was developed under the guidance of **Mr. Ankit Chamlagain**.

The system allows for efficient employee and qualification data management and provides powerful reporting features, including exporting employee data to Excel.

---

## 📌 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Project Structure](#project-structure)
- [Database Schema](#database-schema)
- [Setup & Installation](#setup--installation)
- [Usage](#usage)
- [Future Enhancements](#future-enhancements)
- [Acknowledgements](#acknowledgements)
- [License](#license)

---

## 📖 Overview

The Employee Remittance Management System enables administrative personnel to manage employee records, assign qualifications, and perform advanced reporting using various filters. The key modules include:

- **Employee Management**
- **Qualification Assignment**
- **Filtered Data Reporting**
- **Excel Exporting**

---

## 🚀 Features

- Create, Read, Update, and Delete (CRUD) operations for:
  - Employees
  - Qualifications
- Assign multiple qualifications to employees (many-to-many)
- Report filtering by:
  - Age
  - Phone Number
  - Zip Code
  - Created From / To (date range)
- Export filtered employee data to Excel using **ClosedXML**
- Uses **Dapper** for lightweight and fast data access

---

## 🧰 Technology Stack

| Category  | Technology               |
| --------- | ------------------------ |
| Framework | ASP.NET MVC 5            |
| Language  | C#                       |
| ORM       | Dapper                   |
| Database  | Microsoft SQL Server     |
| Frontend  | HTML, CSS, Bootstrap     |
| Reporting | ClosedXML (Excel Export) |
| DB Access | Stored Procedures        |

---

## 📂 Project Structure

### Controllers

- **EmployeeController** – Handles Employee CRUD operations
- **QualificationController** – Manages qualification records and mapping
- **ReportController** – Applies filters and exports data

### Models

#### Employee.cs

```csharp
public class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string? Email { get; set; }
    public string PhoneNumber { get; set; }
    public string State { get; set; }
    public string District { get; set; }
    public string Address { get; set; }
    public string? ZipCode { get; set; }
    public string? JobTitle { get; set; }
    public string? Department { get; set; }
    public decimal Salary { get; set; }
    public string Status { get; set; } = "Active";
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
```

#### Qualification.cs

```csharp
public class Qualification
{
    public int QualificationId { get; set; }
    public string QualificationName { get; set; }
}
```

---

## 🗃️ Database Schema

The system uses the following SQL Server schema:

### Tables

- `Employees`
- `Qualifications`
- `EmployeeQualifications` (Join Table)

### Stored Procedures

- `sp_InsertEmployee`
- `sp_InsertQualification`
- `sp_InsertEmployeeQualification`

These stored procedures handle the creation and mapping of many-to-many relationships.

---

## ⚙️ Setup & Installation

### 1. Clone the Repository

```bash
git clone https://github.com/your-username/employee-remittance.git
```

### 2. Configure the Database

- Create a new SQL Server database.
- Run the provided scripts to create tables and stored procedures.

### 3. Update the Connection String

Update your `web.config` file:

```xml
<connectionStrings>
  <add name="DefaultConnection" connectionString="Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;Integrated Security=True;" providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 4. Run the Project

- Open the solution in **Visual Studio**
- Build the project
- Run using **IIS Express**

---

## 🧪 Usage

Once running:

- Go to `/Employee` to manage employee records
- Go to `/Qualification` to manage qualifications and assign them
- Go to `/Report` to filter and export employee data

---

## 🌱 Future Enhancements

- Add authentication and authorization (Admin/User roles)
- Add photo upload for employees
- Implement advanced search and pagination
- Add frontend validation with JavaScript/jQuery
- Write unit and integration tests

---

## 🙏 Acknowledgements

- **Mr. Ankit Chamlagain** – Project Supervisor
- **Inficare Pvt. Ltd.** – Internship Organization

---

## 📜 License

This project was developed as part of an academic internship and is intended for learning and demonstration purposes only.
