# University Library Management System

## Table of Contents
- [Introduction](#introduction)
- [Architecture Overview](#architecture-overview)
- [Features](#features)
- [Core Concepts](#core-concepts)
- [System Design](#system-design)
  - [Domain Model](#domain-model)
  - [Use Cases](#use-cases)
  - [Database Schema](#database-schema)
- [Business Rules](#business-rules)
  - [Additional Rules](#additional-rules)
- [Technologies Used](#technologies-used)
- [How to Run the Project](#how-to-run-the-project)

## Introduction
The **University Library Management System** is a centralized application designed to manage book loans for students, professors, and staff at a university. The system allows users to borrow and return items, manage overdue alerts, and impose sanctions for late returns. The system is designed using the **Clean Architecture** principle, ensuring separation of concerns, scalability, and maintainability.

## Architecture Overview
This project is built on the principles of **Clean Architecture**, which organizes code into multiple layers:
- **Domain Layer (Entities)**: Contains the core business logic, independent of external dependencies.
- **Application Layer (Use Cases)**: Contains the application-specific business rules and logic.
- **Interface Layer (Adapters)**: Defines contracts for communication between the business logic and the external systems.
- **Infrastructure Layer**: Implements the interfaces, managing interactions with external services like databases.

This architecture ensures that business rules are decoupled from external services, providing flexibility in changing technologies (e.g., switching from one database provider to another) without impacting the core logic.

## Features
- Borrow and return books, CDs, theses, and other library items.
- Track overdue items and generate alerts.
- Automatically sanction users who fail to return items within a grace period.
- Support for various user roles: Students, Professors, and Staff.
- Enforce borrowing limits and loan durations.

## Core Concepts

### Entities:
- **User**: Represents a student, professor, or staff member with a unique library card.
- **Book**: Represents library items such as books, CDs, and theses, identified by an ISBN.
- **Loan**: Represents a borrowing transaction between a user and an item.
- **Alert**: Represents overdue notifications for late returns.
- **Sanction**: Represents penalties applied to users for violating loan rules.

### Use Cases:
- **BorrowBookUseCase**: Manages the logic for borrowing a book, ensuring limits and rules are enforced.
- **ReturnBookUseCase**: Handles book returns and evaluates whether an alert or sanction is required.
- **GenerateAlertUseCase**: Automatically generates overdue alerts when an item exceeds the borrowing period.
- **ApplySanctionUseCase**: Applies sanctions to users with overdue items for more than 3 days.

## System Design

### Domain Model

#### User
Represents the user who interacts with the library system.
- `Id`: Unique identifier.
- `Name`: Name of the user.
- `UserType`: Type of user (Student, Professor, Staff).
- `LibraryCardCode`: Unique library card code.
- `Loans`: List of active loans.

#### Book
Represents the items available for borrowing.
- `ISBN`: Unique identifier for the book (International Standard Book Number).
- `Title`: Title of the book.
- `Category`: Category of the book (e.g., Informatics, History, Mathematics).
- `IsOnSiteOnly`: Flag to indicate if the item is for on-site consultation only.

#### Loan
Represents a borrowing transaction.
- `LoanId`: Unique identifier for the loan.
- `Borrower`: Reference to the user who borrowed the item.
- `BorrowedBook`: Reference to the borrowed item.
- `BorrowDate`: Date the item was borrowed.
- `ReturnDate`: Expected return date (15 days after the borrow date).
- `IsReturned`: Flag to indicate whether the item has been returned.

#### Alert
Represents an overdue notification.
- `AlertId`: Unique identifier for the alert.
- `RelatedLoan`: Reference to the associated loan.
- `Message`: Custom alert message.
- `GeneratedOn`: Date the alert was generated.

#### Sanction
Represents penalties for overdue returns.
- `SanctionId`: Unique identifier for the sanction.
- `SanctionedUser`: Reference to the user penalized.
- `SanctionStartDate`: Start date of the sanction.
- `SanctionEndDate`: End date of the sanction.

### Use Cases

1. **Borrow Book**: Allows a user to borrow a book, provided they have not exceeded the borrowing limit (5 items), and the item is not restricted to on-site use only.
2. **Return Book**: Allows users to return borrowed items. If overdue, an alert is generated, and sanctions may apply.
3. **Generate Alert**: Generates alerts for overdue items in the database.
4. **Apply Sanction**: Applies sanctions if an item is overdue for more than 3 days.

### Database Schema

| Table Name     | Columns                                        |
|----------------|------------------------------------------------|
| **Users**      | `Id`, `Name`, `UserType`, `LibraryCardCode`     |
| **Books**      | `ISBN`, `Title`, `Category`, `IsOnSiteOnly`     |
| **Loans**      | `LoanId`, `BorrowerId`, `BookISBN`, `BorrowDate`, `ReturnDate`, `IsReturned` |
| **Alerts**     | `AlertId`, `LoanId`, `Message`, `GeneratedOn`   |
| **Sanctions**  | `SanctionId`, `UserId`, `SanctionStartDate`, `SanctionEndDate` |

## Business Rules

1. A user can borrow up to 5 items at a time.
2. Each loan has a maximum duration of 15 days.
3. Alerts are generated when items are overdue.
4. Users are sanctioned if items are overdue by more than 3 days (ban for 5 days).

### Additional Rules

1. **Overdue Fine**: Users are fined $5 per day for items overdue by more than 3 days.
2. **Renewal Option**: Users may renew an item once, extending the borrowing period by another 15 days, provided no other users have requested the item.
3. **Limit on Sanctions**: Users cannot have more than one active sanction at a time.

## Technologies Used
- **.NET 6**: Backend framework.
- **Entity Framework Core**: ORM for database interaction.
- **SQL Server**: Relational database.
- **xUnit**: Testing framework.
- **Clean Architecture Principles**: For scalable and maintainable code.

## How to Run the Project

1. Clone the repository.
2. Set up the SQL Server database with the provided schema.
3. Update the connection string in the `appsettings.json` file.
4. Run the migrations to set up the database tables.
```bash
dotnet ef database update
```
5. Build and run the project.
```bash
dotnet run
```
6. Use the testing project for unit and integration testing:
```bash
dotnet test
```
