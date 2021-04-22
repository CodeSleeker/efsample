using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfCore;

namespace EFSample
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ICommand Create { get; set; }
        public ICommand View { get; set; }
        public MainWindowViewModel()
        {
            Create = new RelayCommand(() =>
            {
                new CreatePerson().Show();
            });
            View = new RelayCommand(() =>
            {
                if (App.Persons.Count > 0)
                    new ViewPersons().Show();
                else
                    MessageBox.Show("No records found");
            });
        }
    }
}
