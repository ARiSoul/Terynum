using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terynum.Models;

public partial class MatchIterationPlayerChoice : ObservableValidator
{
    [ObservableProperty]
    Guid _MatchID;
    [ForeignKey(nameof(MatchID))]
    public Match Match { get; set; }

    [ObservableProperty]
    Guid _matchIterationID;
    [ForeignKey(nameof(MatchIterationID))]
    public MatchIteration MatchIteration { get; set; }

    [ObservableProperty]
    Guid _playerID;
    [ForeignKey(nameof(PlayerID))]
    public Player Player { get; set; }

    [ObservableProperty]
    int _choice;
}
