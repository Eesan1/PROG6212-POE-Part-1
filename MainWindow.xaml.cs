using System.Windows;
using CMCS.Views;

namespace CMCS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new LecturerSubmitClaim();
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new LecturerSubmitClaim();
        }

        private void ViewClaims_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new LecturerClaims();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
