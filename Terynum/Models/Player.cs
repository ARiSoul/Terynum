using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Terynum.Models;

public partial class Player : BaseID
{
    public Player()
    {
        Games = new List<Game>();
    }

    [ObservableProperty]
    [StringLength(100)]
    string _name;

    public virtual ICollection<Game> Games { get; set; }
}
