using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Terynum.Services;

namespace Terynum.ViewModels;

[QueryProperty(nameof(GameManager), nameof(GameManager))]
public partial class GameViewModel : BaseViewModel
{
    [ObservableProperty]
    GameManager _gameManager;

    [ObservableProperty]
    int _iteration;

    public GameViewModel()
    {
        
    }

    [RelayCommand]
    async Task SubmitChoiceAsync(int number)
    {
        GameManager.AddPlayerChoice(number);
    }
}
