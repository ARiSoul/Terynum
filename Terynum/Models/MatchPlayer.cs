using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terynum.Models;

/// <summary>
/// A representation of a player in a match.
/// </summary>
public partial class MatchPlayer : ObservableValidator
{
    /// <summary>
    /// The match reference.
    /// </summary>
    [ObservableProperty]
    Guid _matchId;
    [ForeignKey(nameof(MatchId))]
    public Match Match { get; set; }

    /// <summary>
    /// The player reference.
    /// </summary>
    [ObservableProperty]
    Guid _playerId;
    [ForeignKey(nameof(PlayerId))]
    public Player Player { get; set; }

    /// <summary>
    /// The player number in the match.
    /// </summary>
    [ObservableProperty]
    int _playerNumber;

    /// <summary>
    /// How many iterations the player had used.
    /// </summary>
    [ObservableProperty]
    int _iterations;

    /// <summary>
    /// The value of the last iteration's choice.
    /// </summary>
    [ObservableProperty]
    int _lastIterationChoice;
}
