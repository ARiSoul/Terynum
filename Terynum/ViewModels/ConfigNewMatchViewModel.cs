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

public partial class ConfigNewMatchViewModel : BaseViewModel
{
    public ObservableCollection<MatchPlayer> MatchPlayers { get; private set; }

    [ObservableProperty]
    IMatchManager _matchManager;

    [ObservableProperty]
    MatchPlayer _selectedMatchPlayer;

    [ObservableProperty]
    bool _showPlayButton;

    public ConfigNewMatchViewModel()
    {
        MatchManager = new MatchManager();
        MatchPlayers = new ObservableCollection<MatchPlayer>(MatchManager.Match.Players);
        MatchPlayers.CollectionChanged += MatchPlayers_CollectionChanged;
    }

    private void MatchPlayers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        ShowPlayButton = MatchPlayers.Any();
    }

    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task AddPlayerAsync()
    {
        var player = await Shell.Current.DisplayPromptAsync("Add Player", "Enter name of new player to add", initialValue: $"Player {MatchPlayers.Count + 1}");

        if (string.IsNullOrWhiteSpace(player))
            return;

        if (MatchPlayers.FirstOrDefault(p => p.Player.Name == player) == null)
        {
            Guid playerID = Guid.NewGuid();
            MatchPlayers.Add(new MatchPlayer
            {
                PlayerNumber = MatchPlayers.Count + 1,
                Player = new Player
                {
                    ID = playerID,
                    Name = player
                },
                MatchId = MatchManager.Match.ID,
                PlayerId = playerID
            });
        }
        else
            await Shell.Current.DisplayAlert("Invalid player", $"Player '{player}' already added. Choose another name.", "OK");
    }

    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task RemovePlayerAsync()
    {
        if (SelectedMatchPlayer == null)
            await Shell.Current.DisplayAlert("Invalid player", $"No player selected to remove!", "OK");
        else
        {
            MatchPlayers.Remove(SelectedMatchPlayer);
            int number = 1;
            foreach (var player in MatchPlayers)
            {
                player.PlayerNumber = number;
                number++;
            }
        }
    }

    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task PlayAsync()
    {
        await MatchManager.StartMatch(MatchPlayers);

        await Shell.Current.GoToAsync(nameof(MatchPage), true, new Dictionary<string, object>
        {
            { nameof(MatchManager), MatchManager }
        });
    }
}
