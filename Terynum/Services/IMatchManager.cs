using Terynum.Models;

namespace Terynum.Services;

/// <summary>
/// Provides functionality to manage each match functions.
/// </summary>
public interface IMatchManager
{
    Match Match { get; }
    MatchIteration CurrentIteration { get; }
    MatchPlayer CurrentPlayer { get; }
    Task StartMatch(ICollection<MatchPlayer> players);
    Task EndMatch();
    Task AddMatchIteration();
    Task AddPlayerChoice();
    void ResetMatch();
    Task SelectNextPlayer();
    Task SetMatchWinner();
}
