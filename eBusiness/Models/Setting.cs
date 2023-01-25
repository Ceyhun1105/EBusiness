using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace eBusiness.Models
{
    public class Setting
    {
        public int Id { get; set; }
       
        [StringLength(maximumLength: 50)]
        public string? Key { get; set; }
        [StringLength(maximumLength: 350)]
        public string Value { get; set; }
    }
}
