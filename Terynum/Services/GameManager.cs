using CommunityToolkit.Mvvm.ComponentModel;
using Terynum.Models;

namespace Terynum.Services;

public partial class GameManager : ObservableValidator, IGameManager
{
    [ObservableProperty]
    Game _game;

    [ObservableProperty]
    GameIteration _currentIteration;

    [ObservableProperty]
    GamePlayer _currentPlayer;

    private int _iterationNumber;

    public GameManager(Game game)
    {
        Game = game;
        _iterationNumber = 0;
    }

    public void StartGame()
    {
        Game.MysteryNumber = new Random().Next(Game.Options.MinNumber, Game.Options.MaxNumber);
        AddGameIteration();
        CurrentPlayer = Game.Players.FirstOrDefault();
        Game.StartedDate = DateTime.Now;
    }

    public void SelectNextPlayer()
    {
        if (CurrentPlayer.PlayerNumber < Game.Players.Max(x => x.PlayerNumber))
            CurrentPlayer = Game.Players.FirstOrDefault(x => x.PlayerNumber == CurrentPlayer.PlayerNumber + 1);
        else
        {
            CurrentPlayer = Game.Players.FirstOrDefault();
        }
    }

    public void EndGame()
    {
        Game.FinishedDate = DateTime.Now;
    }

    public void AddGameIteration()
    {
        Game.Iterations.Add(new GameIteration
        {
            GameID = Game.ID,
            Iteration = _iterationNumber++
        });
    }

    public void AddPlayerChoice(int choice)
    {
        CurrentIteration.PlayerChoices.Add(new GameIterationPlayerChoice
        {
            Choice = choice,
            GameID = Game.ID,
            GameIterationID = CurrentIteration.ID,
            PlayerID = CurrentPlayer.PlayerId
        });

        CurrentPlayer = Game.Players.FirstOrDefault(x => x.PlayerNumber == CurrentPlayer.PlayerNumber + 1);
    }
}
