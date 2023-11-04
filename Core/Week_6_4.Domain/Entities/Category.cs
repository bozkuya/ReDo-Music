using Week_6_4.Domain.Common;
using Week_6_4.Domain.Enums;
using System.Collections.Generic;

namespace Week_6_4.Domain.Entities{
    public class Category : EntityBase<Guid>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

    }
}