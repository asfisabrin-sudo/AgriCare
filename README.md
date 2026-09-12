# 🌾 AgriCare - Animal Healthcare Management System

- Course: CSC 2210: Object Oriented Programming 2 (Section D)
- Semester: Summer 2025–26; Course Teacher: Dr. Md Iftekharul Mobin
- Assignment: Final Project-Individual Submission

A Windows Forms (C#) desktop application, backed by SQL Server, that connects Farmers, Doctors, and a Manager on one platform to manage animal healthcare services end-to-end from reporting a problem to payment and review.

## 📖 Case Study:

Managing animal healthcare on a farm involves more than simply raising livestock. Farmers need to identify animal health problems, find suitable veterinary doctors, arrange appropriate services, make payments, and track the progress of each request. When this is handled manually (phone calls, paper records), problems get overlooked and payment records get lost.

AgriCare solves this with a centralized digital platform built around three roles:

- Manager: approves new Doctors, sets their service fees, manages user accounts, monitors problem reports, and maintains financial records.
- Doctor: views assigned animal problems, completes services or transfers a problem to another Doctor, and maintains a profile (specialization, experience, fees, rating).
- Farmer: reports animal problems, selects a Doctor and a service (Online Advice / Farm Visit), pays for it, tracks the request, and rates the Doctor afterward.

Doctors stay in "Pending" status until Manager approval; Farmers become "Active" immediately after registration.

## 👥 User Roles & Features:

### 🔴 Manager Feature Description:

- Doctor Management: Approves new Doctors, sets Online Advice or Farm Visit fees.
- User Management: Views & blocks Doctor or Farmer accounts.
- Report Management: Monitors animal health problem reports.
- Payment Management: Monitors Farmer payments, maintains Doctor payment records.
- Service Monitoring: Tracks service requests end-to-end.

### 🟠 Doctor Feature Description:

- Problem Management: Views animal problems assigned to them.
- Service Completion: Provides treatment/advice, marks problem completed.
- Problem Transfer: Transfers a problem to another available Doctor.
- Doctor Profile: Specialization, experience, fees, rating, total reviews.
- Service History: Tracks handled services.

### 🟢 Farmer Feature Description:

- Animal Problem Reporting: Reports animal name, type, problem description.
- Doctor Selection: Browses available Doctors by specialization/experience/rating.
- Service Selection & Payment: Chooses Online Advice or Farm Visit, pays.
- Tracking Request: Views request + payment status.
- Doctor Rating: Rates the Doctor after service completion.

## 🛠️ Tech Stack:

| Layer | Technology |
|---|---|
| UI | C# Windows Forms (.NET Framework 4.7.2). |
| Database | Microsoft SQL Server (SQL Server Express). |
| Data Access | ADO.NET (SqlConnection, SqlCommand). |
| IDE | Visual Studio 2022. |

## 🗄️ Database Schema:

Full script: Docs/script.sql

- Users: Every account UserID, Name, Gmail, Password, Role, Status.
- DoctorProfile: Doctor-specific info: specialization, experience, fees, ratings.
- ServiceRequests: A Farmer's request: animal, problem, service type, amount, status.
- AnimalProblems: Reported problem + assigned Doctor + status.
- DoctorReviews: Farmer's rating/review for a Doctor after service.
- DoctorPayments: Manager's payment records to Doctors.

## ▶️ How to Run:

- Restore the database: open SSMS, connect to your local SQL Server instance, and run Docs/script.sql This creates AgriCareDB with schema + sample data.
- Open the project: open AgriCare.sln in Visual Studio.
- Set your own SQL Server connection string: the connection string is currently hardcoded to the developer's machine (KOOKIE80\SQLEXPRESS).
- Update it to your own SQL Server instance name in every file below before running:

```
string connectionString = @"Data Source=<YOUR_PC_NAME>\SQLEXPRESS;Initial Catalog=AgriCareDB;Integrated Security=True;TrustServerCertificate=True";
```

| File: | Approx. Line: |
|---|---|
| Form1.cs | 49 |
| RegisterForm.cs | 76 |
| AvailableDoctorsForm.cs | 16 |

*(check other forms that call SqlConnection for the same line)*

💡 To find your SQL Server instance name: open SSMS → the name shown at connection time (e.g. YOURPC\SQLEXPRESS), or run sqlcmd -L in Command Prompt.

- Build & Run: Build → Rebuild Solution, then F5.

## 🔑 Test Credentials:

| Role | User ID | Password | Notes |
|---|---|---|---|
| Farmar | (register a new one) | --- | Status becomes Active immediately. |
| Doctor | (register a new one) | --- | Status stays Pending until a Manager approves it. |
| Manager | (registration disabled -- seed directly in DB / via script) | --- | See Users table in script.sql |

## 🤖 AI Tools Used:

Claude AI was used to debug a runtime NullReferenceException that blocked Login/Register (root cause: the SQL connection string was not resolving correctly), to help generate the SQL export steps. All application logic, UI design, and SQL schema were written by the team.

## 🧑‍🤝‍🧑 Team:

- Lutfur Rahman [24-57054-1]
- Md. Jubair Hasan Tamim [23-51855-2]
- Asfi Sabrin Neha [24-56321-1]
- Md Julfiker Ahmad Rafi [23-52116-2]

## 📂 Repository Structure:

```
AgriCare/
│
├── AgriCare/
│   ├── *.cs
│   ├── *.Designer.cs
│   ├── *.resx
│   ├── App.config
│   └── ...
│
├── Docs/
│   ├── script.sql
│   ├── Project_Report.pdf
│   ├── Diagrams/
│   │   ├── ERD.png
│   │   └── ...
│   └── Screenshots/
│       ├── Login.png
│       ├── Dashboard.png
│       └── ...
│
├── AgriCare.sln
│
├── README.md
│
└── .gitignore
```
