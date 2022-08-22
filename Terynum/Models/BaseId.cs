using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Terynum.Models;

/// <summary>
/// A base class that provides the ID property and includes CommunityToolkit.Mvvm funcionalities to it's inheritances.
/// </summary>
public partial class BaseID : ObservableValidator
{
    public BaseID()
    {
        ID = Guid.NewGuid();
    }

    /// <summary>
    /// Guid instead of int, to manage in memory values in a simper way, since the system has no database management... yet.
    /// </summary>
    [ObservableProperty]
    [Key]
    Guid _iD;
}
