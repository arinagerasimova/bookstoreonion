namespace BookStore.Domain.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderItems
    {
        public int BookId { get; set; }

        public int OrderId { get; set; }
    }
}
