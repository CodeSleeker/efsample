using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfCore;
using static EFSample.Services;

namespace EFSample
{
    public class ViewPersonsViewModel : BaseViewModel
    {
        public ICommand Previous { get; set; }
        public ICommand Next { get; set; }
        public ICommand Remove { get; set; }
        string _FirstName;
        public string FirstName { get { return _FirstName; } set { _FirstName = value;OnPropertyChanged(); } }
        string _MiddleName;
        public string MiddleName { get { return _MiddleName; } set { _MiddleName = value; OnPropertyChanged(); } }
        string _LastName;
        public string LastName { get { return _LastName; } set { _LastName = value; OnPropertyChanged(); } }

        int count;
        public ViewPersonsViewModel(Window window)
        {
            FirstName = App.Persons[0].FirstName;
            MiddleName = App.Persons[0].MiddleName;
            LastName = App.Persons[0].LastName;
            Next = new RelayCommand(() =>
            {
                if (App.Persons.Count -1 == count) return;
                count += 1;
                FirstName = App.Persons[count].FirstName;
                MiddleName = App.Persons[count].MiddleName;
                LastName = App.Persons[count].LastName;
            });
            Previous = new RelayCommand(() =>
            {
                if (count == 0) return;
                count -= 1;
                FirstName = App.Persons[count].FirstName;
                MiddleName = App.Persons[count].MiddleName;
                LastName = App.Persons[count].LastName;
            });
            Remove = new RelayCommand(async ()=>
            {
                await PersonStore.RemovePerson(App.Persons[count]);
                App.Persons.RemoveAt(count);
                if (App.Persons.Count == count) count -= 1;
                if (App.Persons.Count > 0)
                {
                    FirstName = App.Persons[count].FirstName;
                    MiddleName = App.Persons[count].MiddleName;
                    LastName = App.Persons[count].LastName;
                }
                else
                {
                    MessageBox.Show("No records found.");
                    window.Close();
                }
            });
        }
    }
}
