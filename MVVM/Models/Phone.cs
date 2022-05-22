using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVM
{
    public class Phone : INotifyPropertyChanged
    {

        private string _title;
        private string _company;
        private int _price;

        public string Title 
        { 
            get { return _title; }
            set {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        
        public string Company
        { 
            get { return _company; }
            set {
                _company = value;
                OnPropertyChanged("Company");
            }
        }
        
        public int Price
        { 
            get { return _price; }
            set {
                _price = value;
                OnPropertyChanged("Price");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
