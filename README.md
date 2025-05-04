
# 🩺 CureX Health Management System

CureX is a complete health management system built using **ASP.NET Core Web API**. It provides functionalities for managing patients, appointments, billing, invoice generation in PDF, and insightful reports.

---

## 📚 Table of Contents

- [Features](#-features)
- [Tech Stack](#-tech-stack)
- [Getting Started](#-getting-started)
- [API Endpoints](#-api-endpoints)
- [Invoice Handling](#-invoice-handling)
- [Sample JSON Structures](#-sample-json-structures)
- [Database Models](#-database-models)
- [License](#-license)
- [Author](#-author)

---

## ✅ Features

- 👤 **Patient Management**  
  Create, view, and delete patients by name and contact number.

- 📅 **Appointment Scheduling**  
  Schedule appointments with date/time and associate them with patients.

- 💳 **Billing System**  
  Generate bills for appointments with details like total amount, payment status, and due date.

- 🧾 **Invoice PDF Generation**  
  Automatically generate downloadable invoices using [QuestPDF](https://www.questpdf.com/).

- 📈 **Reports and Analytics**  
  Monthly reports and analytics based on bill status (paid/pending).

---

## ⚙️ Tech Stack

- **ASP.NET Core Web API (.NET 9)**
- **Entity Framework Core**
- **SQL Server**
- **QuestPDF** for invoice PDF generation
- **LINQ** for querying data
- **Swagger**  for testing

---

## 🛠️ Getting Started

### Prerequisites

- [.NET SDK 6 or higher](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB or full)

### 1. Clone the repository

```bash
git clone https://github.com/your-username/curex.git
cd curex
```

### 2. Update Configuration

Edit `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=CureXDb;Trusted_Connection=True;"
}
```

### 3. Apply Migrations

```bash
dotnet ef database update
```

### 4. Run the API

```bash
dotnet run
```

API will run on `https://localhost:7070` (or similar based on launch settings).

---

## 🌐 API Endpoints

### 🔹 Patients

| Method | Endpoint                | Description                     |
|--------|-------------------------|---------------------------------|
| GET    | `/api/patients`         | Get all patients                |
| POST   | `/api/patients`         | Add a new patient               |
| DELETE | `/api/patients/{id}`    | Delete a patient by ID          |

### 🔹 Appointments

| Method | Endpoint                | Description                          |
|--------|-------------------------|--------------------------------------|
| GET    | `/api/appointments`     | Get all appointments                 |
| POST   | `/api/appointments`     | Create an appointment                |
| DELETE | `/api/appointments/{id}`| Delete an appointment by ID          |

### 🔹 Billing & Invoices

| Method | Endpoint                             | Description                              |
|--------|--------------------------------------|------------------------------------------|
| POST   | `/api/billing/generate`              | Generate bill and invoice                |
| GET    | `/api/billing/invoice/{billId}`      | Download PDF invoice by bill ID          |
| GET    | `/api/billing/patient/{contact}`     | Get all bills by patient contact number  |
| GET    | `/api/billing/report/monthly`        | Get billing report by month/year         |
| GET    | `/api/billing/analytics`             | Status-based analytics                   |

---

## 🧾 Invoice Handling

- PDF invoices are generated via QuestPDF and stored in `wwwroot/invo/`.
- Filenames follow: `Invoice_{BillId}_{Ticks}.pdf`.
- Files can be downloaded via `/api/billing/invoice/{billId}`.

---

## 📦 Sample JSON Structures

### ✅ Add a Patient

```json
{
  "name": "John Doe",
  "contact": "01012345678"
}
```

### 📅 Create Appointment

```json
{
  "patientContact": "01012345678",
  "appointmentDate": "2025-05-04T10:30:00"
}
```

### 💳 Generate Bill

```json
{
  "appointmentId": 3,
  "amount": 500.0,
  "dueDate": "2025-05-10",
  "isPaid": true
}
```

---

## 🧩 Database Models

- **Patient**
  - Id
  - Name
  - Contact
  - Appointments (Navigation)

- **Appointment**
  - Id
  - AppointmentDate
  - PatientId (FK)
  - Bill (Navigation)

- **Bill**
  - Id
  - AppointmentId (FK)
  - Amount
  - IsPaid
  - DueDate
  - GeneratedAt

---

## 📄 License

This project is licensed under the MIT License.

---

## 👨‍💻 Author

**Yahia** – [GitHub Profile](https://github.com/your-username)  
A backend developer passionate about clean architecture and efficient systems.
