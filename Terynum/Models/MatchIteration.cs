using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terynum.Models;

/// <summary>
/// Provides information of a match iteration, where the information of each player choice is stored.
/// </summary>
public partial class MatchIteration : BaseID
{
    public MatchIteration()
    {
        PlayerChoices = new List<MatchIterationPlayerChoice>();
    }

    /// <summary>
    /// Reference to the match.
    /// </summary>
    [ObservableProperty]
    Guid _matchID;
    [ForeignKey(nameof(MatchID))]
    public Match Match { get; set; }

    /// <summary>
    /// The number of the iteration.
    /// </summary>
    [ObservableProperty]
    int _iteration;

    /// <summary>
    /// A collection of player choices, with the choice valu itself.
    /// </summary>
    public virtual ICollection<MatchIterationPlayerChoice> PlayerChoices { get; set; }
}
