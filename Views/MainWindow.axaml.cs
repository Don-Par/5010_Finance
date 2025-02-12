using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PersonalFinanceTracker.Views;

namespace PersonalFinanceTracker.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenTransactionsPage(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ContentArea.Content = new TransactionsView();
        }

        private void OpenBudgetsPage(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ContentArea.Content = new BudgetsView();
        }

        private void OpenReportsPage(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            ContentArea.Content = new ReportsView();
        }
    }
}
