using CommunityToolkit.Mvvm.ComponentModel;

namespace Terynum.Models;

public partial class MatchOptions : ObservableValidator
{
    [ObservableProperty]
    int _maxIterations;

    [ObservableProperty]
    int _minNumber;

    [ObservableProperty]
    int _maxNumber;
}
