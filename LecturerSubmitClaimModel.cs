using System.ComponentModel;

namespace CMCS.Models
{
    public class LecturerSubmitClaimModel : INotifyPropertyChanged
    {
        private string? _totalHoursWorked;
        private string? _claimPeriod;
        private string? _uploadedDocument;

        public string? TotalHoursWorked
        {
            get => _totalHoursWorked;
            set
            {
                _totalHoursWorked = value;
                OnPropertyChanged(nameof(TotalHoursWorked));
            }
        }

        public string? ClaimPeriod
        {
            get => _claimPeriod;
            set
            {
                _claimPeriod = value;
                OnPropertyChanged(nameof(ClaimPeriod));
            }
        }

        public string? UploadedDocument
        {
            get => _uploadedDocument;
            set
            {
                _uploadedDocument = value;
                OnPropertyChanged(nameof(UploadedDocument));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
