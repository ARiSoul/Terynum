using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terynum.Models;
using Terynum.Pages;
using Terynum.Services;

namespace Terynum.ViewModels;

public partial class ConfigNewGameViewModel : BaseViewModel
{
    public ObservableCollection<GamePlayer> GamePlayers { get; private set; }

    [ObservableProperty]
    GameManager _gameManager;

    [ObservableProperty]
    GamePlayer _selectedGamePlayer;

    [ObservableProperty]
    bool _showPlayButton;

    public ConfigNewGameViewModel()
    {
        GameManager = new GameManager(new Game());
        GamePlayers = new ObservableCollection<GamePlayer>(GameManager.Game.Players);
        GamePlayers.CollectionChanged += GamePlayers_CollectionChanged;
    }

    private void GamePlayers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        ShowPlayButton = GamePlayers.Any();
    }

    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task AddPlayerAsync()
    {
        var player = await Shell.Current.DisplayPromptAsync("Add Player", "Enter name of new player to add", initialValue: $"Player {GamePlayers.Count + 1}");

        if (string.IsNullOrWhiteSpace(player))
            return;

        if (GamePlayers.FirstOrDefault(p => p.Player.Name == player) == null)
            GamePlayers.Add(new GamePlayer
            {
                PlayerNumber = GamePlayers.Count + 1,
                Player = new Player
                {
                    Name = player
                }
            });
        else
            await Shell.Current.DisplayAlert("Invalid player", $"Player '{player}' already added. Choose another name.", "OK");
    }

    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task RemovePlayerAsync()
    {
        if (SelectedGamePlayer == null)
            await Shell.Current.DisplayAlert("Invalid player", $"No player selected to remove!", "OK");
        else
        {
            GamePlayers.Remove(SelectedGamePlayer);
            int number = 1;
            foreach (var player in GamePlayers)
            {
                player.PlayerNumber = number;
                number++;
            }
        }
    }

    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task PlayAsync()
    {
        GameManager.Game.Players = GamePlayers;
        GameManager.StartGame();

        await Shell.Current.GoToAsync(nameof(GamePage), true, new Dictionary<string, object>
        {
            { nameof(GameManager), GameManager }
        });
    }
}
