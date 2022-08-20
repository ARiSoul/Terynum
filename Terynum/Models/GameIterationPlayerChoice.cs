using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Terynum.Models;

public partial class GameIterationPlayerChoice : ObservableValidator
{
    [ObservableProperty]
    Guid _gameID;
    [ForeignKey(nameof(GameID))]
    public Game Game { get; set; }

    [ObservableProperty]
    Guid _gameIterationID;
    [ForeignKey(nameof(GameIterationID))]
    public GameIteration GameIteration { get; set; }

    [ObservableProperty]
    Guid _playerID;
    [ForeignKey(nameof(PlayerID))]
    public Player Player { get; set; }

    [ObservableProperty]
    int _choice;
}
