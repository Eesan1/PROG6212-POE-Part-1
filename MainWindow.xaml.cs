using System.Windows;
using CMCS.Views;

namespace CMCS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Load the Submit Claim view by default
            MainContent.Content = new LecturerSubmitClaim();
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the LecturerSubmitClaim view
            MainContent.Content = new LecturerSubmitClaim();
        }

        private void ViewClaims_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the LecturerClaims view
            MainContent.Content = new LecturerClaims();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Application.Current.Shutdown();
        }
    }
}
