using CommunityToolkit.Mvvm.Input;
using Terynum.Pages;

namespace Terynum.ViewModels;

/// <summary>
/// View model to use in <see cref="HomePage"/>
/// </summary>
public partial class HomePageViewModel : BaseViewModel
{
    /// <summary>
    /// Command to enter the game.
    /// </summary>
    /// <returns></returns>
    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task PlayGameAsync()
    {
        await Shell.Current.GoToAsync(nameof(ConfigNewMatchPage));
    }
}
