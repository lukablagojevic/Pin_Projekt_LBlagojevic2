using System.ComponentModel.DataAnnotations;

public class Viewer
{
    [Key]
    public int ViewerId { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [EmailAddress]
    public string Email { get; set; }
    [Required(ErrorMessage = "This field is required.")]
    public bool Subscriber { get; set; }
    [Required(ErrorMessage = "This field is required.")]
    public bool Follower { get; set; }


}
