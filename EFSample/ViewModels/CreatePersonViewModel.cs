using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfCore;
using static EFSample.Services;

namespace EFSample
{
    public class CreatePersonViewModel : BaseViewModel
    {
        public ICommand Create { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        bool _ClearInput;
        public bool ClearInput { get { return _ClearInput; } set { _ClearInput = value;OnPropertyChanged(); } }
        public CreatePersonViewModel()
        {
            Create = new RelayCommand(async() =>
            {
                ClearInput = false;
                var person = new Person
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    MiddleName = MiddleName
                };
                await PersonStore.AddPerson(person);
                App.Persons.Add(person);
                ClearInput = true;
            });
        }
    }
}
