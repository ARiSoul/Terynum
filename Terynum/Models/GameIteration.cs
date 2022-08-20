using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terynum.Models;

public partial class GameIteration : BaseID
{
    public GameIteration()
    {
        PlayerChoices = new List<GameIterationPlayerChoice>();
    }

    [ObservableProperty]
    Guid _gameID;
    [ForeignKey(nameof(GameID))]
    public Game Game { get; set; }

    [ObservableProperty]
    int _iteration;

    public virtual ICollection<GameIterationPlayerChoice> PlayerChoices { get; set; }
}
