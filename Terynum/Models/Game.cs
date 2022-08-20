using CommunityToolkit.Mvvm.ComponentModel;

namespace Terynum.Models;

public partial class Game : BaseID
{
    public Game()
    {
        Players = new List<GamePlayer>();
        Iterations = new List<GameIteration>();
        
        Options = new GameOptions
        {
            MinNumber = 0,
            MaxNumber = 100,
            MaxIterations = 10
        };
    }

    [ObservableProperty]
    int _mysteryNumber;

    [ObservableProperty]
    int _winnerPlayerId;

    [ObservableProperty]
    GameOptions _options;

    [ObservableProperty]
    DateTime _startedDate;

    [ObservableProperty]
    DateTime _finishedDate;

    public virtual ICollection<GamePlayer> Players { get; set; }
    public virtual ICollection<GameIteration> Iterations { get; set; }
}
