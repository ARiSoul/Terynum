using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Terynum.Pages;
using Terynum.Services;

namespace Terynum.ViewModels;

/// <summary>
/// The view model to use in <see cref="MatchPage"/>.
/// It receives the MatchManager by query property instantiated in the configuration of the match.
/// </summary>
[QueryProperty(nameof(MatchManager), nameof(MatchManager))]
public partial class MatchViewModel : BaseViewModel
{
    /// <summary>
    /// Match manager.
    /// </summary>
    [ObservableProperty]
    MatchManager _matchManager;

    /// <summary>
    /// Command to submit a player's choicein the current match iteration.
    /// </summary>
    /// <returns></returns>
    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task SubmitChoiceAsync()
    {        
        await MatchManager.AddPlayerChoice();
    }
}
