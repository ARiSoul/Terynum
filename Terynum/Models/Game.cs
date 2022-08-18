using CommunityToolkit.Mvvm.ComponentModel;

namespace Terynum.Models;

internal partial class Game : BaseID
{
    public Game()
    {
        Players = new List<Player>();
    }

    [ObservableProperty]
    int _mysteryNumber;

    [ObservableProperty]
    int _maxIterations;

    [ObservableProperty]
    int _winnerPlayerId;

    [ObservableProperty]
    DateTime _startedDate;

    [ObservableProperty]
    DateTime _finishedDate;

    public virtual ICollection<Player> Players { get; set; }
}
