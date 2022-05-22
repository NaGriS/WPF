using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM
{
    public class ApplicationViewModel    : INotifyPropertyChanged
    {

        private Phone _selectedPhone;

        private RelayCommand _addCommand;
        private RelayCommand _removeCommand;
        private RelayCommand _copyCommand;
        
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??= new RelayCommand(obj =>
                  {
                      Phone phone = new Phone { Company = "Please fill in the company", Title = "Please fill in the title", Price = 0};
                      Phones.Insert(0, phone);
                      SelectedPhone = phone;
                  });
            }
        } 
        
        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??= new RelayCommand(obj =>
                  {
                      if (obj is Phone phone)
                      {
                          var index = Phones.IndexOf(phone);
                          Phones.Remove(phone);
                          if (Phones.Count > 0)
                          {
                              SelectedPhone = Phones[index];
                          }
                      }
                  }, (obj) => Phones.Count > 0);
            }
        }
        
        public RelayCommand CopyCommand
        {
            get
            {
                return _copyCommand ??= new RelayCommand(obj =>
                  {
                      if (obj is Phone phone)
                      {
                          Phones.Insert(0, phone);
                          SelectedPhone = phone;
                      }    
                  });
            }
        }

        public ObservableCollection<Phone> Phones { get; set; }

        public Phone SelectedPhone 
        { 
            get { return _selectedPhone; }
            set {
                _selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone
                {
                    Title = "iPhone 7",
                    Company = "Apple",
                    Price = 100000
                },
                new Phone
                {
                    Title = "Galaxy S20",
                    Company = "Samsung",
                    Price = 70000
                },
                new Phone
                {
                    Title = "Mi5S",
                    Company = "Xiaomi",
                    Price = 20000
                },
            };

            SelectedPhone = Phones[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
