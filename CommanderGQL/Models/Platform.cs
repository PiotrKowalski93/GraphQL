using HotChocolate;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    // Used to add documentation for our models
    //[GraphQLDescription("Any software or service")] <- moved to Type
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        // Used to add documentation for our properties
        //[GraphQLDescription("Purchased Licence Key")]
        public string LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
