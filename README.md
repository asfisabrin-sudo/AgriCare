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

## ✅ Functional Requirements:

### Manager
1. The Manager shall be able to view and approve pending Doctor registrations.
2. The Manager shall be able to set Doctor consultation fees (Online Advice / Farm Visit).
3. The Manager shall be able to view and block/unblock Doctor or Farmer accounts.
4. The Manager shall be able to monitor reported animal problems.
5. The Manager shall be able to monitor all service requests end-to-end.
6. The Manager shall be able to manage and view payment records.

### Doctor
1. The Doctor shall be able to view animal problems assigned to them.
2. The Doctor shall be able to mark a service as completed after treatment/advice.
3. The Doctor shall be able to transfer a problem to another available Doctor.
4. The Doctor shall be able to manage their profile (specialization, experience, fees).
5. The Doctor shall be able to receive ratings and reviews from Farmers.

### Farmer
1. The Farmer shall be able to register and log in.
2. The Farmer shall be able to report an animal health problem.
3. The Farmer shall be able to browse available Doctors by specialization, experience, and rating.
4. The Farmer shall be able to select a Doctor and a service type.
5. The Farmer shall be able to make a payment for the selected service.
6. The Farmer shall be able to track the status of their service request.
7. The Farmer shall be able to rate and review a Doctor after service completion.

## 📝 User Stories:

### Manager
- As a Manager, I want to approve Doctor registrations so that only verified Doctors can offer services.
- As a Manager, I want to set Doctor fees so that consultation charges are properly managed.
- As a Manager, I want to monitor all service requests so I can track system-wide activity.
- As a Manager, I want to manage payment records so financial data stays organized.

### Doctor
- As a Doctor, I want to view my assigned cases so I know which problems need my attention.
- As a Doctor, I want to mark a case as completed so the Farmer knows the service is done.
- As a Doctor, I want to transfer a case to another Doctor when I'm unavailable, so the Farmer still gets help.
- As a Doctor, I want to receive ratings so I can understand my service quality.

### Farmer
- As a Farmer, I want to report my animal's problem so I can get professional help.
- As a Farmer, I want to filter Doctors by specialization and rating so I can find the best fit.
- As a Farmer, I want to pay for a service so my request gets processed.
- As a Farmer, I want to track my request status so I know what's happening.
- As a Farmer, I want to rate my Doctor so I can give feedback on the service.

## 🛠️ Tech Stack:

| Layer | Technology |
|---|---|
| UI | C# Windows Forms (.NET Framework 4.7.2). |
| Database | Microsoft SQL Server (SQL Server Express). |
| Data Access | ADO.NET (SqlConnection, SqlCommand). |
| IDE | Visual Studio 2022. |

## 🗄️ Database Schema:

Full script: [Docs/script.sql](Docs/script.sql)
Diagrams: [ER Diagram](sql%20sceme.png) | [UI Navigation](ui.png) | [Use Case Diagram](use%20case.png)
- Users: Every account UserID, Name, Gmail, Password, Role, Status.
- DoctorProfile: Doctor-specific info: specialization, experience, fees, ratings.
- ServiceRequests: A Farmer's request: animal, problem, service type, amount, status.
- AnimalProblems: Reported problem + assigned Doctor + status.
- DoctorReviews: Farmer's rating/review for a Doctor after service.
- DoctorPayments: Manager's payment records to Doctors.

### Column-Level Table Details

**Users**
| Column   | Data Type | Constraint         |
|----------|-----------|---------------------|
| UserID   | VARCHAR   | Primary Key        |
| Name     | VARCHAR   | NOT NULL           |
| Gmail    | VARCHAR   | NOT NULL, UNIQUE   |
| Password | VARCHAR   | NOT NULL           |
| Role     | VARCHAR   | NOT NULL           |
| Status   | VARCHAR   | NOT NULL           |

**DoctorProfile**
| Column          | Data Type | Constraint                        |
|-----------------|-----------|-------------------------------------|
| DoctorID        | VARCHAR   | Primary Key, Foreign Key → Users  |
| Specialization  | VARCHAR   | NULL                              |
| Experience      | INT       | NULL                              |
| OnlineAdviceFee | DECIMAL   | NULL                              |
| FarmVisitFee    | DECIMAL   | NULL                              |
| Rating          | DECIMAL   | NULL                              |
| TotalReviews    | INT       | NULL                              |

**AnimalProblems**
| Column             | Data Type | Constraint            |
|--------------------|-----------|-------------------------|
| ProblemId          | INT       | Primary Key, Identity  |
| FarmerId           | VARCHAR   | Foreign Key, NOT NULL  |
| AnimalName         | VARCHAR   | NOT NULL               |
| AnimalType         | VARCHAR   | NOT NULL               |
| ProblemDescription | VARCHAR   | NOT NULL               |
| DoctorId           | VARCHAR   | Foreign Key            |
| ProblemStatus      | VARCHAR   | NOT NULL               |
| ReportDate         | DATETIME  | DEFAULT                |

**ServiceRequests**
| Column        | Data Type | Constraint            |
|---------------|-----------|-------------------------|
| RequestID     | INT       | Primary Key, Identity  |
| FarmerID      | VARCHAR   | Foreign Key, NOT NULL  |
| DoctorID      | VARCHAR   | Foreign Key, NOT NULL  |
| ServiceType   | VARCHAR   | NOT NULL               |
| Amount        | DECIMAL   | NOT NULL               |
| PaymentStatus | VARCHAR   | NOT NULL               |
| RequestStatus | VARCHAR   | NOT NULL               |
| RequestDate   | DATETIME  | DEFAULT                |

**DoctorReviews**
| Column     | Data Type | Constraint            |
|------------|-----------|-------------------------|
| ReviewID   | INT       | Primary Key, Identity  |
| RequestID  | INT       | UNIQUE, NOT NULL       |
| FarmerID   | VARCHAR   | Foreign Key, NOT NULL  |
| DoctorID   | VARCHAR   | Foreign Key, NOT NULL  |
| Rating     | INT       | CHECK (1-5)            |
| Review     | VARCHAR   | NULL                   |
| ReviewDate | DATETIME  | DEFAULT                |

**DoctorPayments**
| Column        | Data Type | Constraint            |
|---------------|-----------|-------------------------|
| PaymentID     | INT       | Primary Key, Identity  |
| DoctorID      | VARCHAR   | Foreign Key, NOT NULL  |
| Amount        | DECIMAL   | NOT NULL               |
| PaymentDate   | DATETIME  | DEFAULT                |
| PaymentStatus | VARCHAR   | NOT NULL               |

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
  
## 🔍 Sample Queries

### JOIN Query
```sql
SELECT u.Name, u.Gmail, d.Specialization, d.OnlineAdviceFee, d.FarmVisitFee, d.Rating
FROM Users u
JOIN DoctorProfile d ON u.UserID = d.DoctorID
WHERE u.Role = 'Doctor';
```
This query joins the Users table with the DoctorProfile table using DoctorID, combining a doctor's name, email, specialization, fees, and rating into a single result.

### GROUP BY Query
```sql
SELECT DoctorID, COUNT(RequestID) AS TotalCompletedRequests
FROM ServiceRequests
WHERE RequestStatus = 'Completed'
GROUP BY DoctorID;
```
This query groups service requests by DoctorID and counts how many completed requests each doctor has handled.

## 🔑 Test Credentials:

| Role | User ID | Password | Notes |
|---|---|---|---|
| Farmar | (register a new one) | --- | Status becomes Active immediately. |
| Doctor | (register a new one) | --- | Status stays Pending until a Manager approves it. |
| Manager | (registration disabled -- seed directly in DB / via script) | --- | See Users table in script.sql |

## 🤖 AI Tools Used:

Claude AI was used to debug a runtime NullReferenceException that blocked Login/Register (root cause: the SQL connection string was not resolving correctly), to help generate the SQL export steps. All application logic, UI design, and SQL schema were written by the team.

## 🎥 Demo Video

[Watch the demo here](YOUR_YOUTUBE_LINK)

## 🧑‍🤝‍🧑 Team & Contributions:

- Lutfur Rahman [24-57054-1],Manager Module (Doctor approval, fee setting, user management, payment records)
- Md. Jubair Hasan Tamim [23-51855-2],Farmer Module (Problem reporting, Doctor selection, service booking, payment)
- Asfi Sabrin Neha [24-56321-1],Doctor Module (Doctor dashboard, rating, fee form, doctor selection, availability)
- Md Julfiker Ahmad Rafi [23-52116-2],Login/Register + Database (Authentication, database design, connection setup)

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
