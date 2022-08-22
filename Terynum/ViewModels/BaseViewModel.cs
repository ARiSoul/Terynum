using CommunityToolkit.Mvvm.ComponentModel;

namespace Terynum.ViewModels;

/// <summary>
/// A base view model that provides some common functionalities to the other view models.
/// </summary>
public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool _isBusy;

    [ObservableProperty]
    string _title;

    public bool IsNotBusy => !IsBusy;
}
