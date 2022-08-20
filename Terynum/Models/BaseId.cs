using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Terynum.Models;

public partial class BaseID : ObservableValidator
{
    public BaseID()
    {
        ID = Guid.NewGuid();
    }

    [ObservableProperty]
    [Key]
    Guid _iD;
}
