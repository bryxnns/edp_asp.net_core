using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EDP.Models
{
    public class Donations
    {
        [Required, Key, Display(Name = "User Donation ID")]
        public string user_donation_id { get; set; } = string.Empty;

        [Required, Display(Name = "Address")]
        public string address { get; set; } = string.Empty;

        [Required, Display(Name = "Unit Number")]
        public string unit_no { get; set; } = string.Empty;

        [Required, DataType(DataType.PostalCode), Display(Name = "Postal Code")]
        public string postal_code { get; set; } = string.Empty;

        [Required, Display(Name = "Collection Date")]
        public string collection_date { get; set; } = string.Empty;

        [Required, Display(Name = "Collection Time")]
        public string collection_time { get; set; } = string.Empty;

        [Required, Display(Name = "Type of Waste")]
        public string type_of_waste { get; set; } = string.Empty;

        [Required, Display(Name = "Request")]
        public string request { get; set; } = string.Empty;

        [Required, Display(Name = "Status")]
        public string status { get; set; } = string.Empty;

        [Required]
        public string user_id { get; set; } = string.Empty;

        [Required, Display(Name = "Waste Weight")]
        public string waste_weight { get; set; } = string.Empty;

        [Required, Display(Name = "Waste Image")]
        public string waste_image { get; set; } = string.Empty;

        [Required, Display(Name = "Collection Done")]
        public bool collection_done { get; set; }

        [Required, Display(Name = "Drop Off Done")]
        public bool drop_off_done { get; set; }

        [Required, Display(Name = "Drop Off Point")]
        public string drop_off_point { get; set; } = string.Empty;

        public string volunteer_user_id { get; set; } = string.Empty;
    }
}
