using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using CMCS.Models;

namespace CMCS.Views
{
    public partial class LecturerSubmitClaim : UserControl
    {
        private LecturerSubmitClaimModel _submitClaimModel;

        public LecturerSubmitClaim()
        {
            InitializeComponent();
            _submitClaimModel = new LecturerSubmitClaimModel();
            DataContext = _submitClaimModel;
        }

        private void UploadDocument_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Document files (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx",
                    Title = "Select a document",
                    Multiselect = false
                };

                bool? result = openFileDialog.ShowDialog();

                if (result == true)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    FileInfo fileInfo = new FileInfo(selectedFilePath);
                    if (fileInfo.Length > 5 * 1024 * 1024)
                    {
                        MessageBox.Show("The file size exceeds the 5 MB limit.", "File Size Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    _submitClaimModel.UploadedDocument = fileInfo.Name;
                    MessageBox.Show($"File '{fileInfo.Name}' uploaded successfully!", "Upload Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while uploading the document: {ex.Message}", "Upload Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_submitClaimModel.TotalHoursWorked) || _submitClaimModel.ClaimAmount == 0)
            {
                ErrorMessage.Text = "Please enter a correct amount of hours worked";
                ErrorMessage.Visibility = Visibility.Visible;
                return;
            }

            ErrorMessage.Visibility = Visibility.Collapsed;

            MessageBox.Show($"Claim submitted successfully for {_submitClaimModel.LecturerName} {_submitClaimModel.LecturerSurname}. Claim Amount: {_submitClaimModel.ClaimAmount:C}");

            _submitClaimModel.TotalHoursWorked = string.Empty;
            _submitClaimModel.UploadedDocument = string.Empty;
            _submitClaimModel.ClaimPeriod = string.Empty;
            _submitClaimModel.LecturerName = string.Empty;
            _submitClaimModel.LecturerSurname = string.Empty;
        }
    }
}
