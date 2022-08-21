using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Terynum.Models;

public partial class Player : BaseID
{
    public Player()
    {
        Matches = new List<Match>();
    }

    [ObservableProperty]
    [StringLength(100)]
    string _name;

    public virtual ICollection<Match> Matches { get; set; }
}
