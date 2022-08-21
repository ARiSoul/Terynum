using Terynum.Models;

namespace Terynum.Services;

public interface IGameManager
{
    Game Game { get; }
    GameIteration CurrentIteration { get; }
    GamePlayer CurrentPlayer { get; }
    Task StartGame(ICollection<GamePlayer> players);
    Task EndGame();
    Task AddGameIteration();
    Task AddPlayerChoice();
    void ResetGame();
    Task SelectNextPlayer();
}
