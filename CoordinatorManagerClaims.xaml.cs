using System.Windows;
using System.Windows.Controls;
using CMCS.Models;

namespace CMCS.Views
{
    public partial class CoordinatorManagerClaims : UserControl
    {
        public CoordinatorManagerClaims()
        {
            InitializeComponent();
            LoadPendingClaims();
        }

        private void LoadPendingClaims()
        {
            var pendingClaims = new[]
            {
                new LecturerSubmitClaimModel { ClaimID = 1, LecturerName = "Eesan Pather", TotalHoursWorked = "20", ClaimAmount = 1000, ClaimPeriod = "July 2024"},
                new LecturerSubmitClaimModel { ClaimID = 2, LecturerName = "Uveer Archary", TotalHoursWorked = "15", ClaimAmount = 750, ClaimPeriod = "August 2024"}
            };

            PendingClaimsDataGrid.ItemsSource = pendingClaims;
        }

        private void ApproveClaim_Click(object sender, RoutedEventArgs e)
        {
            var claim = (LecturerSubmitClaimModel)((Button)sender).DataContext;
            claim.Status = "Approved";
            MessageBox.Show($"Claim {claim.ClaimID} for {claim.LecturerName} has been approved.");
        }

        private void RejectClaim_Click(object sender, RoutedEventArgs e)
        {
            var claim = (LecturerSubmitClaimModel)((Button)sender).DataContext;
            claim.Status = "Rejected"; 
            MessageBox.Show($"Claim {claim.ClaimID} for {claim.LecturerName} has been rejected.");
        }
    }
}
