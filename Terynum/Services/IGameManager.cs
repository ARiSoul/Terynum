using Terynum.Models;

namespace Terynum.Services;

public interface IGameManager
{
    Game Game { get; }
    GameIteration CurrentIteration { get; }
    GamePlayer CurrentPlayer { get; }
    void StartGame();
    void EndGame();
    void AddGameIteration();
    void AddPlayerChoice(int choice);
}
