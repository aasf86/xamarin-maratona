using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyApp.ViewModels
{
    public class MainVM : BaseVM
    {
        private string _searchTerm;       

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                if (SetProperty(ref _searchTerm, value))
                    SearchCommand.ChangeCanExecute();
            }
        }

        public Command SearchCommand { get; }

        public MainVM()
        {
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);
        }

        bool CanExecuteSearchCommand(object arg)
        {
            return !string.IsNullOrWhiteSpace(SearchTerm);
        }

        async void ExecuteSearchCommand(object obj)
        {
            await Task.Delay(2000);

            await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou por '{SearchTerm}'.", "OK");

            Debug.WriteLine($"Clicou em {DateTime.Now}");
        }
    }
}
