using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terynum.Models;

public partial class MatchIteration : BaseID
{
    public MatchIteration()
    {
        PlayerChoices = new List<MatchIterationPlayerChoice>();
    }

    [ObservableProperty]
    Guid _matchID;
    [ForeignKey(nameof(MatchID))]
    public Match Match { get; set; }

    [ObservableProperty]
    int _iteration;

    public virtual ICollection<MatchIterationPlayerChoice> PlayerChoices { get; set; }
}
