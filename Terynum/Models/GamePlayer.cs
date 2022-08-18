using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terynum.Models;

internal partial class GamePlayer : ObservableValidator
{
    [ObservableProperty]
    int _gameId;
    [ForeignKey(nameof(GameId))]
    public Game Game { get; set; }

    [ObservableProperty]
    int _playerId;
    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; }

    [ObservableProperty]
    int _playerNumber;

    [ObservableProperty]
    int _iterations;

    [ObservableProperty]
    int _lastIteration;
}
