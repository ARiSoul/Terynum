using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Terynum.Models;

internal partial class BaseID : ObservableValidator
{
    [ObservableProperty]
    [Key]
    int _id;
}
