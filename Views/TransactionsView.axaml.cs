using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Interactivity;
using PersonalFinanceTracker.Models;
using PersonalFinanceTracker.Repositories;
using PersonalFinanceTracker.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Views
{
    public partial class TransactionsView : UserControl
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ObservableCollection<Transaction> Transactions { get; set; } = new();

        public TransactionsView()
        {
            InitializeComponent();
            var options = new DbContextOptionsBuilder<FinanceDbContext>()
                .UseSqlite("Data Source=finance.db")
                .Options;

            _transactionRepository = new TransactionRepository(new FinanceDbContext(options));
            _categoryRepository = new CategoryRepository(new FinanceDbContext(options));


            LoadTransactions();
            TransactionGrid.ItemsSource = Transactions;
        }

        private async void LoadTransactions()
        {
            var transactions = await _transactionRepository.GetAllTransactionsAsync();
            Transactions.Clear();
            foreach (var transaction in transactions)
            {
                Transactions.Add(transaction);
            }
        }

        private async void AddTransaction_Click(object? sender, RoutedEventArgs e)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(1);
            if (existingCategory == null)
            {
                existingCategory = new Category { Name = "Default" };
                await _categoryRepository.AddCategoryAsync(existingCategory);
            }


            // **Detach category before using it to avoid multiple tracking issues**
            using (var dbContext = new FinanceDbContextFactory().CreateDbContext(Array.Empty<string>()))
            {
                dbContext.Entry(existingCategory).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }

            // Now, create the transaction using the existing category
            var newTransaction = new Transaction
            {
                Description = "New Transaction",
                Amount = 100.0m,
                Date = System.DateTime.Now,
                CategoryId = existingCategory.Id,
                Category = existingCategory // Ensures the required property is set
            };


            // Assign category without tracking it
            newTransaction.Category = new Category { Id = existingCategory.Id, Name = existingCategory.Name };

            await _transactionRepository.AddTransactionAsync(newTransaction);
            LoadTransactions();


        }

        private async void EditTransaction_Click(object? sender, RoutedEventArgs e)
        {
            if (TransactionGrid.SelectedItem is Transaction selectedTransaction)
            {
                selectedTransaction.Amount += 10; // Example: Increment amount by 10
                await _transactionRepository.UpdateTransactionAsync(selectedTransaction);
                LoadTransactions();
            }
        }

        private async void DeleteTransaction_Click(object? sender, RoutedEventArgs e)
        {
            if (TransactionGrid.SelectedItem is Transaction selectedTransaction)
            {
                await _transactionRepository.DeleteTransactionAsync(selectedTransaction.Id);
                LoadTransactions();
            }
        }
    }
}
