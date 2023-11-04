using Week_6_4.Domain.Common;
using Week_6_4.Domain.Enums;
using System.Collections.Generic;

namespace Week_6_4.Domain.Entities
{
    public class Artist : EntityBase<Guid>
    {
        public string Name { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Instrument> Instruments { get; set; } // Instruments

    
    }
}
