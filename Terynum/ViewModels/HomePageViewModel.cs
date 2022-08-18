using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terynum.Pages;

namespace Terynum.ViewModels;

internal partial class HomePageViewModel : BaseViewModel
{
    [RelayCommand(AllowConcurrentExecutions = true)]
    async Task PlayGameAsync()
    {
        await Shell.Current.GoToAsync(nameof(SelectPlayersPage));
    }
}
