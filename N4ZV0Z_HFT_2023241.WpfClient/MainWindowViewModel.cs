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
        public RestCollection<Game> Games { get; set; }

        private Game selectedGame;

        public Game SelectedGame
        {
            get { return selectedGame; }
            set 
            {
                if (value != null)
                {
                    selectedGame = new Game()
                    {
                        Title = value.Title,
                        GameID = value.GameID
                    };
                }
                OnPropertyChanged();
                (DeleteGameCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        } 



        public ICommand CreateGameCommand { get; set; } 
        public ICommand DeleteGameCommand { get; set; } 
        public ICommand UpdateGameCommand { get; set; } 

        public MainWindowViewModel()
        {
            Games = new RestCollection<Game>("http://localhost:35916/", "game");
            CreateGameCommand = new RelayCommand(() =>
            {
                Games.Add(new Game()
                {
                    Title = SelectedGame.Title
                }); 
            });

            UpdateGameCommand = new RelayCommand(() => 
            {
                Games.Update(selectedGame);
            });

            DeleteGameCommand = new RelayCommand(() =>
            {
                Games.Delete(SelectedGame.GameID);
            }, 
            () =>
            {
                return SelectedGame != null;
            });
            selectedGame = new Game();
        }
    }
}
