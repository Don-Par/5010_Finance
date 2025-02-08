# 5010_Finance
Personal Finance Tracker using Avalonia UI

The Personal Finance Tracker App aims to simplify personal financial management, offering a user-friendly interface that empowers users to make better financial decisions.

Introduction

This is a cross-platform Personal Finance Tracker built using Avalonia UI. It allows users to manage their expenses, set budgets, and track financial goals.

Features

Cross-Platform: Works on macOS, Windows, and Linux

Expense Tracking: Log income and expenses

Budgeting System: Set and manage monthly budgets

Financial Reports: Generate charts and insights

SQLite Database: Store transaction data locally

🔹 Step 1: Install Required Tools

Before setting up the project, ensure you have:
✅ .NET 6, 8, or 9 SDK installed
✅ VS Code with C# Dev Kit
✅ SQLite for database storage

📌 Install Avalonia UI Templates

dotnet new install Avalonia.Templates

🔹 Step 2: Set Up the Project

📌 Create a New Avalonia UI Project

dotnet new avalonia -o PersonalFinanceTracker
cd PersonalFinanceTracker
code .

🔹 Step 3: Run the Application

📌 Restore Dependencies

dotnet restore

📌 Build the Project

dotnet build

📌 Run the App

dotnet run

✅ Your Avalonia UI app should now launch on macOS, Windows, or Linux!

🔹 Step 4: Project Structure

📂 PersonalFinanceTracker├── 📂 Views (UI Screens - XAML files)│   ├── MainWindow.axaml → Dashboard│   ├── TransactionsView.axaml → Add/Edit Transactions│   ├── BudgetView.axaml → Budget Management│   ├── ReportsView.axaml → Analytics & Charts│├── 📂 ViewModels (Handles UI Logic - MVVM Pattern)│   ├── MainViewModel.cs│   ├── TransactionsViewModel.cs│   ├── BudgetViewModel.cs│   ├── ReportsViewModel.cs│├── 📂 Models (Data Structures & Database Models)│   ├── Transaction.cs│   ├── Category.cs│   ├── Budget.cs│   ├── User.cs│├── 📂 Database (SQLite DB & Data Access Layer)│   ├── FinanceDbContext.cs│├── App.axaml → Entry point├── App.axaml.cs → App startup logic├── MainWindow.axaml → Main UI

🔹 Step 5: Database Setup (SQLite)

📌 Install Entity Framework Core SQLite

dotnet add package Microsoft.EntityFrameworkCore.Sqlite

📌 Create Database Context

Create a folder named Database

Inside Database, create a file FinanceDbContext.cs

Add the following code:

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

📌 Run Database Migrations

dotnet ef migrations add InitialCreate

dotnet ef database update

✅ This will create finance.db to store all transaction data.

🔹 Step 6: Next Steps

Now that the core setup is complete, you can:
✅ Design the Main Window UI (MainWindow.axaml)
✅ Implement Transaction & Budget Management Features
✅ Integrate Database with UI

🚀 Happy Coding! 🎯

