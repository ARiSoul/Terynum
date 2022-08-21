using CommunityToolkit.Mvvm.ComponentModel;

namespace Terynum.Models;

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

    [ObservableProperty]
    int _mysteryNumber;

    [ObservableProperty]
    Guid _winnerPlayerId;

    [ObservableProperty]
    MatchOptions _options;

    [ObservableProperty]
    DateTime _startedDate;

    [ObservableProperty]
    DateTime _finishedDate;

    public virtual ICollection<MatchPlayer> Players { get; set; }
    public virtual ICollection<MatchIteration> Iterations { get; set; }
}
