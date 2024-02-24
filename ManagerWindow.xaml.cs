using Module_13_WPF_Delegat_HomeWork.BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Module_13_WPF_Delegat_HomeWork
{
    /// <summary>
    /// Логика взаимодействия для ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {   
        Manager manager = new Manager();
        List<Manager> managers = new List<Manager>();
        StandartAccount account = new StandartAccount();
        List<StandartAccount> accounts = new List<StandartAccount>();
        public static event Func<string, string, string> LogingEvent;
        public ManagerWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = manager.GetAllClient();
            LogingEvent += account.LogingFunction;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            manager.SearchClients(txtSearch.Text);
        }

        private void dataGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            manager = dataGrid.SelectedItem as Manager;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            manager.UpdateAllData(txtId.Text, txtLastName.Text, txtName.Text, txtSurname.Text, txtPhone.Text, txtPasport.Text);
            string log = LogingEvent?.Invoke("Manager", "Update Data Client");
            MessageBox.Show(log, this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            manager.CreateNewClient(txtLastName.Text, txtName.Text, txtSurname.Text, txtPhone.Text, txtPasport.Text);

            dataGrid.ItemsSource = manager.GetAllClient();

            string log = LogingEvent?.Invoke("Manager", "Create Client");
            MessageBox.Show(log, this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void dataGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            dataGridAcc.ItemsSource = account.GetAllAccountsClientId(txtId.Text);
        }

        private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            account.CreateAccount(txtId.Text, txtTotalSumAcc.Text, "standart");
            dataGridAcc.ItemsSource = account.GetAllAccountsClientId(txtId.Text);

            string log = LogingEvent?.Invoke("Manager", "Create account");
            MessageBox.Show(log, this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            TransferWindow transferWindow = new TransferWindow();
            transferWindow.Show();
        }

        private void btnDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            account.DeleteAccount(txtIdAcc.Text);
            dataGridAcc.ItemsSource = account.GetAllAccounts("standart");

            string log = LogingEvent?.Invoke("Manager", "Delete Account");
            MessageBox.Show(log, this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
