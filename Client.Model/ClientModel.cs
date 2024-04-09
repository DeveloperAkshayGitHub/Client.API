using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class ClientModel
    {
        // Mandatory fields
        [Required]
        public required int Id { get; set; }
        [Required]
        public required string FirstName { get; set; } 
        [Required]
        public required string LastName { get; set; } 
        [Required]
        public required string IDNumber { get; set; } 

        // Optional fields
        public string? MobileNumber { get; set; } 
        public string? PhysicalAddress { get; set; } 
    }

}
