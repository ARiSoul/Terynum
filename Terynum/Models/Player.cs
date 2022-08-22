using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Terynum.Models;

/// <summary>
/// A very simple representation of a player.
/// </summary>
public partial class Player : BaseID
{
    public Player()
    {
        Matches = new List<Match>();
    }

    /// <summary>
    /// The name of the player.
    /// </summary>
    [ObservableProperty]
    [StringLength(100)]
    string _name;

    /// <summary>
    /// A collection of matches the player had been in.
    /// </summary>
    public virtual ICollection<Match> Matches { get; set; }
}
