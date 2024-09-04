
using System.ComponentModel.DataAnnotations;

namespace MovieWeb.Models
{
    public enum Category
    {
        [Display(Name ="Thriller")]
        thriller = 1,
        [Display(Name ="Horror")]
        horror = 2,
        [Display(Name ="Drama")]
        drama = 3,
        [Display(Name ="Comedy")]
        comedy = 4,
        [Display(Name ="Action")]
        action = 5
    }
}
