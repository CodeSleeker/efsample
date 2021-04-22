using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static EFSample.Services;

namespace EFSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string path = $@"{appData}\EFSample";
        public static string DB = $@"{path}\EFSample.db";
        public static List<Person> Persons = new List<Person>();
        protected async override void OnStartup(StartupEventArgs e)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            await InitializeData();
        }
        private async Task InitializeData()
        {
            try
            {
                await PersonStore.EnsurePersonStore();
                Persons = await PersonStore.GetPersons();
            }
            catch (Exception)
            {
                File.Delete(DB);
                await InitializeData();
            }
        }
    }
}
