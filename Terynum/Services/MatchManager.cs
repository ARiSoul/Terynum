﻿using CommunityToolkit.Mvvm.ComponentModel;
using Terynum.Models;

namespace Terynum.Services;

public partial class MatchManager : ObservableValidator, IMatchManager
{
    [ObservableProperty]
    Match _match;

    [ObservableProperty]
    MatchIteration _currentIteration;

    [ObservableProperty]
    MatchPlayer _currentPlayer;

    [ObservableProperty]
    int _currentChoice;

    private int _iterationNumber;

    public MatchManager()
    {
        Match = new();
        ResetMatch();
    }

    public void ResetMatch()
    {
        Match.Iterations.Clear();
        _iterationNumber = 1;
    }

    public async Task StartMatch(ICollection<MatchPlayer> players)
    {
        Match.Players = players;
        Match.MysteryNumber = new Random().Next(Match.Options.MinNumber, Match.Options.MaxNumber);
        await AddMatchIteration();
        CurrentPlayer = Match.Players.FirstOrDefault();
        Match.StartedDate = DateTime.Now;
        CurrentChoice = Match.Options.MinNumber;
    }

    public async Task SelectNextPlayer()
    {
        if (Match.Players.Count > CurrentPlayer.PlayerNumber)
            CurrentPlayer = Match.Players.FirstOrDefault(x => x.PlayerNumber == CurrentPlayer.PlayerNumber + 1);
        else
        {
            CurrentPlayer = Match.Players.FirstOrDefault();
            await AddMatchIteration();
        }
    }

    public async Task EndMatch()
    {
        await SetMatchWinner();
        await Shell.Current.GoToAsync("..");
        Match.FinishedDate = DateTime.Now;
        ResetMatch();
    }

    public async Task SetMatchWinner()
    {
        // A player found the mystery number before game max iterations reached
        if (CurrentChoice == Match.MysteryNumber)
        {
            await Shell.Current.DisplayAlert($"WINNER - {CurrentPlayer.Player.Name}", $"Congratulations, you have guessed the mystery number: {Match.MysteryNumber}!", "OK");
            Match.WinnerPlayerId = CurrentPlayer.PlayerId;
        }
        else if (Match.Players.Count > 1)
        // Game max iterations reached with multiplayer: find winner by proximity
        {
            int closest = Match.Iterations.SelectMany(pc => pc.PlayerChoices)
                                         .Select(c => c.Choice)
                                         .Aggregate((x, y) => Math.Abs(x - Match.MysteryNumber) < Math.Abs(y - Match.MysteryNumber) ? x : y);

            var choices = Match.Iterations.OrderBy(i => i.Iteration)
                                         .SelectMany(pc => pc.PlayerChoices)
                                         .Where(c => c.Choice == closest).ToList();

            var winner = Match.Players.FirstOrDefault(p => p.PlayerId == choices.FirstOrDefault().PlayerID);

            await Shell.Current.DisplayAlert($"WINNER - {winner.Player.Name}", 
                $"Congratulations, you have the closest choice to mystery number!{Environment.NewLine}{Environment.NewLine}Mystery Number: {Match.MysteryNumber}{Environment.NewLine}Choice: {choices.FirstOrDefault().Choice}", "OK");
            Match.WinnerPlayerId = winner.PlayerId;
        }
        else
            // Game max iterations reached with single player: show what the mystery number was
            await Shell.Current.DisplayAlert($"UPS {CurrentPlayer.Player.Name}... FAIL", $"The mystery number was {Match.MysteryNumber}!", "OK");
    }

    public async Task AddMatchIteration()
    {
        if (Match.Iterations.Count < Match.Options.MaxIterations)
        {
            Match.Iterations.Add(new MatchIteration
            {
                MatchID = Match.ID,
                Iteration = _iterationNumber++
            });

            CurrentIteration = Match.Iterations.LastOrDefault();
        }
        else
        {
            // TODO: improve everything, add database management, allow see results and ranking, etc
            // TODO: add comments

            await Shell.Current.DisplayAlert("GAME OVER", "Max iterations reached!", "OK");
            await EndMatch();

            return;
        }
    }

    public async Task AddPlayerChoice()
    {
        // first add the player choice
        CurrentIteration.PlayerChoices.Add(new MatchIterationPlayerChoice
        {
            Choice = CurrentChoice,
            MatchID = Match.ID,
            MatchIterationID = CurrentIteration.ID,
            PlayerID = CurrentPlayer.PlayerId
        });

        // then add the current iteration to the current player
        CurrentPlayer.Iterations++;
        CurrentPlayer.LastIterationChoice = CurrentChoice;

        // then check the player's choice if it's hi or lo
        if (CurrentChoice > Match.MysteryNumber)
            await Shell.Current.DisplayAlert("Try again", "LO", "OK");
        else if (CurrentChoice < Match.MysteryNumber)
            await Shell.Current.DisplayAlert("Try again", "HI", "OK");
        else
        // mystery number was found
        {
            await EndMatch();
            return;
        }

        // set next player and/or iteration
        await SelectNextPlayer();
    }
}
