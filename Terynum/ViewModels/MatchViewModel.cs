using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Terynum.Services;

namespace Terynum.ViewModels;

[QueryProperty(nameof(MatchManager), nameof(MatchManager))]
public partial class MatchViewModel : BaseViewModel
{
    [ObservableProperty]
    MatchManager _matchManager;

    public MatchViewModel()
    {
        
    }

    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task SubmitChoiceAsync()
    {        
        await MatchManager.AddPlayerChoice();
    }
}
