using System.ComponentModel.DataAnnotations;

namespace eBusiness.Areas.Admin.ViewModels
{
    public class AdminLoginViewModel
    {
        [StringLength(maximumLength: 50)]
        public string UserName { get; set; }
        [StringLength(maximumLength: 20),DataType(DataType.Password)]

        public string Password { get; set; }

    }
}
