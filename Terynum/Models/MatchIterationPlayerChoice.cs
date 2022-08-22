using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terynum.Models;

/// <summary>
/// The information of a player's choice during a match.
/// </summary>
public partial class MatchIterationPlayerChoice : ObservableValidator
{
    /// <summary>
    /// The match reference.
    /// </summary>
    [ObservableProperty]
    Guid _MatchID;
    [ForeignKey(nameof(MatchID))]
    public Match Match { get; set; }

    /// <summary>
    /// The match iteration reference.
    /// </summary>
    [ObservableProperty]
    Guid _matchIterationID;
    [ForeignKey(nameof(MatchIterationID))]
    public MatchIteration MatchIteration { get; set; }

    /// <summary>
    /// The player reference.
    /// </summary>
    [ObservableProperty]
    Guid _playerID;
    [ForeignKey(nameof(PlayerID))]
    public Player Player { get; set; }

    /// <summary>
    /// The value of the player's choice itself.
    /// </summary>
    [ObservableProperty]
    int _choice;
}
