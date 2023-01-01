using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;

namespace LMS.Models
{
    public enum Status
    {
        Available,
        [Description("Not Available")]
        [Display(Name = "Not Available")]
        NotAvailable
    }
}
