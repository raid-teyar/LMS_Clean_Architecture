# University Library Management System


## Overview
This project implements a Library Management System for a university, following the principles of Clean Architecture and Domain-Driven Design (DDD). The system allows users to borrow library items such as books, CDs, dictionaries, and theses. It enforces rules such as borrowing limits, loan periods, overdue alerts, and sanctions for late returns.

## Design Decisions
### 1. Clean Architecture
- **Domain Layer**: Contains the core business logic and domain models (Entities, Aggregates, Value Objects).
- **Application Layer**: Responsible for orchestration and use cases. (not implemented yet)
- **Infrastructure Layer**: Handles external concerns such as persistence, with repositories implementing the domain interfaces. (not implemented yet)
- **Presentation Layer**: serves as the **entry point** for user interaction. (not yet implemented)
### 2. Domain-Driven Design (DDD)
- **Entities**: Key domain objects such as Alerts, which have unique identities.
- **Aggregates**: User is an aggregate, ensuring that all user-related operations, such as borrowing items, are consistent and respect the business rules.
- **Value Objects**: Value objects like LoanPeriod represent domain concepts that have no identity but are critical to the business logic.

## Modelization Notes
- I intentionly didnt create seperate classes from **User** types (Stuedent, Professor, Staff) and i setteled for just using an *enum*, because even though these user types can have specific attributes they are not needed for the scope of this **Library Management System**
- In the database schema, all *value objects* have been inlined inside their owning entities, because you can't have them in seperate tables as they don't have an identity.
- Aggregates are the only type that can raise events, thats the reason why some types such as *LibraryMaterial* are **Aggregates** and not **Entities**.
- The `CheckOverdueLoans` method in the `LoanManagementService` needs to be called by a job schedule such as **Quartz.NET**, which will fire the method each day to trigger: checking for overdues, alerts and sanctions.

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


## Business Rules

1. A user can borrow up to 5 items at a time.
2. Each loan has a maximum duration of 15 days.
3. Alerts are generated when items are overdue.
4. Users are sanctioned if items are overdue by more than 3 days (ban for 5 days).

### Additional Rules
1. **Limit on Sanctions**: Users cannot have more than one active sanction at a time.
2. **Renewal Option**: Users may renew an item once, extending the borrowing period by another 15 days, provided no other users have requested the item.
*Note: The additional business rules can are labeled as TODOs in the codebase, to make them easier to find*

## Technologies Used
- **.NET 8**
