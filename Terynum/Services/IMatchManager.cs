using Terynum.Models;

namespace Terynum.Services;

/// <summary>
/// Provides functionality to manage each match functions.
/// </summary>
public interface IMatchManager
{
    /// <summary>
    /// The match being managed.
    /// </summary>
    Match Match { get; }
    /// <summary>
    /// The current iteration object.
    /// </summary>
    MatchIteration CurrentIteration { get; }
    /// <summary>
    /// The current player object.
    /// </summary>
    MatchPlayer CurrentPlayer { get; }
    /// <summary>
    /// The current choice value.
    /// </summary>
    int CurrentChoice { get; }

    /// <summary>
    /// Starts the match with the players received.
    /// </summary>
    /// <param name="players">The players of the match.</param>
    /// <returns></returns>
    Task StartMatch(ICollection<MatchPlayer> players);
    /// <summary>
    /// Ends the match.
    /// </summary>
    /// <returns></returns>
    Task EndMatch();
    /// <summary>
    /// Adds an iteration to the match.
    /// </summary>
    /// <returns></returns>
    Task AddMatchIteration();
    /// <summary>
    /// Adds the choice of the current player.
    /// </summary>
    /// <returns></returns>
    Task AddPlayerChoice();
    /// <summary>
    /// Resets all values of the match.
    /// </summary>
    void ResetMatch();
    /// <summary>
    /// Selects the next player, if there's one.
    /// </summary>
    /// <returns></returns>
    Task SelectNextPlayer();
    /// <summary>
    /// Sets the winner of the match.
    /// </summary>
    /// <returns></returns>
    Task SetMatchWinner();
}
