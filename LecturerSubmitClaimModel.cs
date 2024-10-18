using System.ComponentModel;
namespace CMCS.Models
{
    public class LecturerSubmitClaimModel : INotifyPropertyChanged
    {
        private string? _totalHoursWorked;
        private string? _claimPeriod;
        private string? _uploadedDocument;
        private double _claimAmount;
        private const double HourlyRate = 50.0;
        private string? _lecturerName;
        private string? _lecturerSurname;
        public int ClaimID { get; set; }

        public string? LecturerName
        {
            get => _lecturerName;
            set
            {
                _lecturerName = value;
                OnPropertyChanged(nameof(LecturerName));
            }
        }

        public string? LecturerSurname
        {
            get => _lecturerSurname;
            set
            {
                _lecturerSurname = value;
                OnPropertyChanged(nameof(LecturerSurname));
            }
        }

        public string? TotalHoursWorked
        {
            get => _totalHoursWorked;
            set
            {
                _totalHoursWorked = value;
                OnPropertyChanged(nameof(TotalHoursWorked));
                CalculateClaimAmount();
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
        public double ClaimAmount
        {
            get => _claimAmount;
            set
            {
                _claimAmount = value;
                OnPropertyChanged(nameof(ClaimAmount));
            }
        }
        
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        private string _status = "Pending";


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CalculateClaimAmount()
        {
            if (double.TryParse(TotalHoursWorked, out double hours))
            {
                ClaimAmount = hours * HourlyRate;
            }
            else
            {
                ClaimAmount = 0;
            }
        }
    }
}
