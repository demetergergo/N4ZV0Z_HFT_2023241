using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using N4ZV0Z_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace N4ZV0Z_HFT_2023241.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
            public ICommand GameListCommand { get; set; }
            public ICommand PublisherlistListCommand { get; set; }
            public ICommand EmployeeListCommand { get; set; }


        public MainWindowViewModel()
        {
            GameListCommand = new RelayCommand(() =>
            {
                new GameWindow().ShowDialog();
            });

            PublisherlistListCommand = new RelayCommand(() =>
            {
                new PublisherWindow().ShowDialog();
            });

            EmployeeListCommand = new RelayCommand(() =>
            {
                new EmployeeWindow().ShowDialog();
            });
        }
    }
}
