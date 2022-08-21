using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terynum.Models;

public partial class GamePlayer : ObservableValidator
{
    [ObservableProperty]
    Guid _gameId;
    [ForeignKey(nameof(GameId))]
    public Game Game { get; set; }

    [ObservableProperty]
    Guid _playerId;
    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; }

    [ObservableProperty]
    int _playerNumber;

    [ObservableProperty]
    int _iterations;

    [ObservableProperty]
    int _lastIterationChoice;
}
