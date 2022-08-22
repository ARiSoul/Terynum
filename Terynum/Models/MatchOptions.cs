using CommunityToolkit.Mvvm.ComponentModel;

namespace Terynum.Models;

/// <summary>
/// Object with multiple options to be used in a single match.
/// </summary>
public partial class MatchOptions : ObservableValidator
{
    /// <summary>
    /// The max of iterations allowed in the match.
    /// </summary>
    [ObservableProperty]
    int _maxIterations;

    /// <summary>
    /// The min. number allowed in the match (used to calculated the mystery number too).
    /// </summary>
    [ObservableProperty]
    int _minNumber;

    /// <summary>
    /// The max. number allowed in the match (used to calculated the mystery number too).
    /// </summary>
    [ObservableProperty]
    int _maxNumber;
}
