# 5010_Finance
## Personal Finance Tracker using .NET MAUI (Mac & Windows)

The Personal Finance Tracker App aims to simplify personal financial management, offering a user-friendly interface that empowers users to make better financial decisions.

## Introduction
This is a cross-platform **Personal Finance Tracker** built using **.NET MAUI**. It allows users to manage their expenses, set budgets, and track financial goals on both macOS and Windows.

## Features
- **Cross-Platform**: Works on macOS and Windows
- **Expense Tracking**: Log income and expenses
- **Budgeting System**: Set and manage monthly budgets
- **Financial Reports**: Generate charts and insights
- **SQLite Database**: Store transaction data locally

---

## 🔹 Step 1: Install Required Tools
Before setting up the project, ensure you have:
✅ **.NET 8 or 9 SDK** installed
✅ **VS Code or Visual Studio 2022** (Mac/Windows)
✅ **.NET MAUI Workload** installed
✅ **SQLite for database storage**

### 📌 Install .NET MAUI Workload
```sh
dotnet workload install maui
```
Verify installation:
```sh
dotnet workload list
```
If installed correctly, you should see `.NET MAUI` listed.

---

## 🔹 Step 2: Set Up the Project
### 📌 Create a New .NET MAUI App
```sh
dotnet new maui -o PersonalFinanceTracker
```
#### **Navigate to the Project Folder**
```sh
cd PersonalFinanceTracker
```
#### **Open the project in VS Code**
```sh
code .
```

---

## 🔹 Step 3: Run the Application
### 📌 Restore Dependencies
```sh
dotnet restore
```
### 📌 Build the Project
```sh
dotnet build
```
### 📌 Run the App (Mac & Windows)
```sh
dotnet run
```
✅ Your .NET MAUI app should now launch on macOS or Windows!

---

## 🔹 Step 4: Project Structure
📂 **PersonalFinanceTracker**  
├── 📂 **Views** *(UI Screens - XAML files)*  
│   ├── `MainPage.xaml` → Dashboard  
│   ├── `TransactionsPage.xaml` → Add/Edit Transactions  
│   ├── `BudgetPage.xaml` → Budget Management  
│   ├── `ReportsPage.xaml` → Analytics & Charts  
│  
├── 📂 **ViewModels** *(Handles UI Logic - MVVM Pattern)*  
│   ├── `MainViewModel.cs`  
│   ├── `TransactionsViewModel.cs`  
│   ├── `BudgetViewModel.cs`  
│   ├── `ReportsViewModel.cs`  
│  
├── 📂 **Models** *(Data Structures & Database Models)*  
│   ├── `Transaction.cs`  
│   ├── `Category.cs`  
│   ├── `Budget.cs`  
│   ├── `User.cs`  
│  
├── 📂 **Database** *(SQLite DB & Data Access Layer)*  
│   ├── `FinanceDbContext.cs`  
│  
├── `App.xaml` → Entry point  
├── `App.xaml.cs` → App startup logic  
├── `MainPage.xaml` → Main UI  

---

## 🔹 Step 5: Database Setup (SQLite)
### 📌 Install Entity Framework Core SQLite
```sh
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
### 📌 Create Database Context
1. **Create a folder named `Database`**
2. **Inside `Database`, create a file `FinanceDbContext.cs`**
3. **Add the following code:**
```csharp
using Microsoft.EntityFrameworkCore;

namespace PersonalFinanceTracker.Database
{
    public class FinanceDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=finance.db");
        }
    }
}
```
### 📌 Run Database Migrations
```sh
dotnet ef migrations add InitialCreate
```
```sh
dotnet ef database update
```
✅ This will create `finance.db` to store all transaction data.

---

## 🔹 Step 6: Next Steps
Now that the core setup is complete, you can:
✅ **Design the Main Page UI (`MainPage.xaml`)**
✅ **Implement Transaction & Budget Management Features**
✅ **Integrate Database with UI**

🚀 Happy Coding! 🎯

