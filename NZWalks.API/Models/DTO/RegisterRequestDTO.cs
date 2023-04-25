using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class RegisterRequestDTO
    {
        [Required]
        //email can be used as Username
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public string[] Roles { get; set; }

    }
}
