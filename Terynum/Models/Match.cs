using CommunityToolkit.Mvvm.ComponentModel;

namespace Terynum.Models;

/// <summary>
/// Represents a match being played.
/// </summary>
public partial class Match : BaseID
{
    public Match()
    {
        Players = new List<MatchPlayer>();
        Iterations = new List<MatchIteration>();
        
        Options = new MatchOptions
        {
            MinNumber = 0,
            MaxNumber = 100,
            MaxIterations = 10
        };
    }

    /// <summary>
    /// The random mystery number of the match calculated by the system so the users can try to guess.
    /// </summary>
    [ObservableProperty]
    int _mysteryNumber;

    /// <summary>
    /// The id of the player that won the match. 
    /// </summary>
    [ObservableProperty]
    Guid _winnerPlayerId;

    /// <summary>
    /// An object of multiple match options, such as min and max number allowed, etc.
    /// </summary>
    [ObservableProperty]
    MatchOptions _options;

    /// <summary>
    /// The dateTime the match has began.
    /// </summary>
    [ObservableProperty]
    DateTime _startedDate;

    /// <summary>
    /// The dateTime the match has finished.
    /// </summary>
    [ObservableProperty]
    DateTime _finishedDate;

    /// <summary>
    /// The players of this match
    /// </summary>
    public virtual ICollection<MatchPlayer> Players { get; set; }

    /// <summary>
    /// The iterations (turns) of the match, where the information of each player choice is stored.
    /// </summary>
    public virtual ICollection<MatchIteration> Iterations { get; set; }
}
