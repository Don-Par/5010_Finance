# 5010_Finance
## Personal Finance Tracker using Avalonia UI (Windows & macOS)

The Personal Finance Tracker App aims to simplify personal financial management, offering a user-friendly interface that empowers users to make better financial decisions.

## Introduction
This is a cross-platform **Personal Finance Tracker** built using **Avalonia UI**. It allows users to manage their expenses, set budgets, and track financial goals on both macOS and Windows.

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
✅ **Avalonia UI Templates installed**
✅ **SQLite for database storage**

### 📌 Install Avalonia UI Templates
```sh
dotnet new install Avalonia.Templates
```
Verify installation:
```sh
dotnet new list | grep Avalonia
```
If installed correctly, you should see templates like `avalonia.app`, `avalonia.mvvm`, etc.

---

## 🔹 Step 2: Set Up the Project
### 📌 Create a New Avalonia UI Project
```sh
dotnet new avalonia.app -o PersonalFinanceTracker
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
✅ Your Avalonia UI app should now launch on macOS or Windows!

---

## 🔹 Step 4: Project Structure
📂 **PersonalFinanceTracker**  
├── 📂 **Views** *(UI Screens - XAML files)*  
│   ├── `MainWindow.axaml` → Dashboard  
│   ├── `TransactionsView.axaml` → Add/Edit Transactions  
│   ├── `BudgetView.axaml` → Budget Management  
│   ├── `ReportsView.axaml` → Analytics & Charts  
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
├── `App.axaml` → Entry point  
├── `App.axaml.cs` → App startup logic  
├── `MainWindow.axaml` → Main UI  

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
✅ **Design the Main Window UI (`MainWindow.axaml`)**
✅ **Implement Transaction & Budget Management Features**
✅ **Integrate Database with UI**

🚀 Happy Coding! 🎯


