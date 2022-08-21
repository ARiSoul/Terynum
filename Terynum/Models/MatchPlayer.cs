using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terynum.Models;

public partial class MatchPlayer : ObservableValidator
{
    [ObservableProperty]
    Guid _matchId;
    [ForeignKey(nameof(MatchId))]
    public Match Match { get; set; }

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
