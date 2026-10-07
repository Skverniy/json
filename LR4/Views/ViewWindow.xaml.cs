using System.Windows;
using LR4.Classes;

namespace LR4.Views
{
    public partial class ViewWindow : Window
    {
        FileService fileService;

        public ViewWindow()
        {
            InitializeComponent();
            fileService = new FileService();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbUsers.ItemsSource = fileService.LoadUsers();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            lbUsers.ItemsSource = fileService.LoadUsers();
        }
    }
}