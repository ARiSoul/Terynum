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

    [ObservableProperty]
    int _currentChoice;

    private int _iterationNumber;

    public GameManager()
    {
        Game = new();
        ResetGame();
    }

    public void ResetGame()
    {
        Game.Iterations.Clear();
        _iterationNumber = 1;
    }

    public async Task StartGame(ICollection<GamePlayer> players)
    {
        Game.Players = players;
        Game.MysteryNumber = new Random().Next(Game.Options.MinNumber, Game.Options.MaxNumber);
        await AddGameIteration();
        CurrentPlayer = Game.Players.FirstOrDefault();
        Game.StartedDate = DateTime.Now;
        CurrentChoice = Game.Options.MinNumber;
    }

    public async Task SelectNextPlayer()
    {
        if (Game.Players.Count > CurrentPlayer.PlayerNumber)
            CurrentPlayer = Game.Players.FirstOrDefault(x => x.PlayerNumber == CurrentPlayer.PlayerNumber + 1);
        else
        {
            CurrentPlayer = Game.Players.FirstOrDefault();
            await AddGameIteration();
        }
    }

    public async Task EndGame()
    {
        await Shell.Current.GoToAsync("..");
        Game.FinishedDate = DateTime.Now;
        ResetGame();
    }

    public async Task AddGameIteration()
    {
        if (Game.Iterations.Count < Game.Options.MaxIterations)
        {
            Game.Iterations.Add(new GameIteration
            {
                GameID = Game.ID,
                Iteration = _iterationNumber++
            });

            CurrentIteration = Game.Iterations.LastOrDefault();
        }
        else
        {
            // TODO: when max iterations over, set the winner by proximity
            // TODO: improve everything, add database management, allow see results and ranking, etc
            // TODO: add comments

            await Shell.Current.DisplayAlert("GAME OVER", "Max iterations reached!", "OK");
            await EndGame();

            return;
        }
    }

    public async Task AddPlayerChoice()
    {
        // first add the player choice
        CurrentIteration.PlayerChoices.Add(new GameIterationPlayerChoice
        {
            Choice = CurrentChoice,
            GameID = Game.ID,
            GameIterationID = CurrentIteration.ID,
            PlayerID = CurrentPlayer.PlayerId
        });

        // then add the current iteration to the current player
        CurrentPlayer.Iterations++;
        CurrentPlayer.LastIterationChoice = CurrentChoice;

        // then check the player's choice if it's hi or lo
        if (CurrentChoice > Game.MysteryNumber)
            await Shell.Current.DisplayAlert("Try again", "LO", "OK");
        else if (CurrentChoice < Game.MysteryNumber)
            await Shell.Current.DisplayAlert("Try again", "HI", "OK");
        else
        {
            await Shell.Current.DisplayAlert($"WINNER - {CurrentPlayer.Player.Name}", $"Congratulations, you have guessed the mystery number: {Game.MysteryNumber}!", "OK");

            // mystery number was found
            await EndGame();

            return;
        }

        // set next player and/or iteration
        await SelectNextPlayer();
    }
}
