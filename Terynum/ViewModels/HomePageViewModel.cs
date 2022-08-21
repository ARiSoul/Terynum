using CommunityToolkit.Mvvm.Input;
using Terynum.Pages;

namespace Terynum.ViewModels;

public partial class HomePageViewModel : BaseViewModel
{
    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task PlayGameAsync()
    {
        await Shell.Current.GoToAsync(nameof(ConfigNewMatchPage));
    }
}
