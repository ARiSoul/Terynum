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

/// <summary>
/// The view model to use in <see cref="ConfigNewMatchPage"/>.
/// </summary>
public partial class ConfigNewMatchViewModel : BaseViewModel
{
    /// <summary>
    /// A collection of players that will join the match.
    /// </summary>
    public ObservableCollection<MatchPlayer> MatchPlayers { get; private set; }

    /// <summary>
    /// The match manager.
    /// </summary>
    [ObservableProperty]
    IMatchManager _matchManager;

    /// <summary>
    /// The selected player to be able to remove.
    /// </summary>
    [ObservableProperty]
    MatchPlayer _selectedMatchPlayer;

    /// <summary>
    /// A flag to hide and show the play button (start match) whether there are players or not.
    /// </summary>
    [ObservableProperty]
    bool _showPlayButton;

    /// <summary>
    /// Creates a new instance of ConfigNewMatchViewModel.
    /// </summary>
    public ConfigNewMatchViewModel()
    {
        MatchManager = new MatchManager();
        MatchPlayers = new ObservableCollection<MatchPlayer>(MatchManager.Match.Players);
        MatchPlayers.CollectionChanged += MatchPlayers_CollectionChanged;
    }

    /// <summary>
    /// Manages the <see cref="ShowPlayButton"/> flag.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MatchPlayers_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        ShowPlayButton = MatchPlayers.Any();
    }

    /// <summary>
    /// Command to add players to the match.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Command to remove a selected player.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Command to start the match.
    /// </summary>
    /// <returns></returns>
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
