using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terynum.Models;

namespace Terynum.ViewModels;

internal partial class SelectPlayersViewModel : BaseViewModel
{
    public ObservableCollection<GamePlayer> GamePlayers { get; } = new();

    [ObservableProperty]
    GamePlayer _selectedGamePlayer;

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
    async Task RemovePlayer()
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

    // TODO: add button to play (only visible when there are players)
}
