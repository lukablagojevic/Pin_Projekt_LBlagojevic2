using System.ComponentModel.DataAnnotations;

namespace Pin_Projekt_LBlagojevic2.Models
{
    public class Streamer
    {
        [Key]
        public int StreamerId { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string ChannelUrl { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Description { get; set; }
    }
}
