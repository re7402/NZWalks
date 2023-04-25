using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class RegionDTO
    {
        [Required]
        public string Code { get; set; }

        public string Name { get; set; }

    }
}
