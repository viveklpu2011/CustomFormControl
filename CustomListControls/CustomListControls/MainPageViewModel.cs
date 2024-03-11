using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CustomListControls
{
	public class MainPageViewModel:INotifyPropertyChanged
	{
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public ObservableCollection<Country> Countries { get; set; } = new ObservableCollection<Country>();
        public ObservableCollection<ClsControls> PersonDataList { get; set; } = new ObservableCollection<ClsControls>();
        public Country SelectedCountry { get; set; }
        public bool IsSelectedCheckBox { get; set; }

        public ICommand SubmitCommand { get; }

        public MainPageViewModel()
		{
            SubmitCommand = new Command(ExecuteSave);

            LoadCountry();
		}

        private void ExecuteSave(object obj)
        {
            var personData = new ClsControls
            {
                FirstName = FirstName,
                LastName = LastName,
                IsSelected = IsSelectedCheckBox ? "True" : "False",
                CountryName = SelectedCountry.CountryName
            };
            PersonDataList.Add(personData);
        }

        private void LoadCountry()
        {
            List<Country> lstCountry = new List<Country>()
            {
                new Country
                {
                    CountryName = "India",
                    Id = 1
                },
                new Country
                {
                    CountryName = "Nepal",
                    Id = 2
                },
                new Country
                {
                    CountryName = "China",
                    Id = 2
                }
            };

            foreach (var item in lstCountry)
            {
                Countries.Add(item);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    

    public class Country
    {
        public string CountryName { get; set; }
        public int Id { get; set; }
    }

    public class ClsControls
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryName { get; set; }
        public string IsSelected { get; set; }
    }
}

