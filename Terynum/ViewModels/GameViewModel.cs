using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Terynum.Services;

namespace Terynum.ViewModels;

[QueryProperty(nameof(GameManager), nameof(GameManager))]
public partial class GameViewModel : BaseViewModel
{
    [ObservableProperty]
    GameManager _gameManager;

    public GameViewModel()
    {
        
    }

    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task SubmitChoiceAsync()
    {        
        await GameManager.AddPlayerChoice();
    }
}
