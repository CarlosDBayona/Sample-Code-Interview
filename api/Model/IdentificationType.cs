using System.Collections;
using System.Collections.Generic;

namespace api.Model
{
    public class IdentificationType
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}