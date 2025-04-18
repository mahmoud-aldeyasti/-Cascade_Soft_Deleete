# Cascade Soft Delete with SaveChangesInterceptor

This is a small demo project showcasing **soft delete with cascading behavior** using **Entity Framework Core** and **SaveChangesInterceptor**.

## 🛠️ Technologies Used
- Entity Framework Core
- SQL Server
- C#

## 📚 Project Description
This project demonstrates how to implement **soft delete** across related entities in a database while applying **cascade behavior**.

When a parent entity (e.g., `Blog`) is soft-deleted (i.e., its `IsDeleted` flag is set to `true`), all related child entities (e.g., `Posts`) are also soft-deleted automatically without physically removing records from the database.

Soft deletion is achieved by overriding the `SaveChanges` operation using an **EF Core SaveChangesInterceptor**, ensuring consistency and applying Domain-Driven Design principles.

## 🧠 Features
- Soft delete support with an `IsDeleted` flag and `DeletedAt` timestamp.
- Cascade soft delete from parent (`Blog`) to children (`Post`).
- Basic CRUD operations with query filters to exclude soft-deleted records automatically.
- Domain-Driven Design approach: accessing child entities (`Posts`) only through the aggregate root (`Blog`).

## 📌 Notes
- No hard delete is performed. Records are flagged as deleted instead of being physically removed.
- **Global Query Filters** are applied to `Blog` and `Post` entities to exclude soft-deleted records by default.
- Soft delete happens at the root entity (`Blog`) level; child entities (`Posts`) are soft-deleted automatically via cascade behavior.
- The SaveChangesInterceptor ensures that deletion logic is enforced across the entire DbContext automatically.

