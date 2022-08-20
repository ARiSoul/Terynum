using CommunityToolkit.Mvvm.ComponentModel;

namespace Terynum.Models;

public partial class GameOptions : ObservableValidator
{
    [ObservableProperty]
    int _maxIterations;

    [ObservableProperty]
    int _minNumber;

    [ObservableProperty]
    int _maxNumber;
}
