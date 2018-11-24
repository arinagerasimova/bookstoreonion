namespace BookStore.Domain.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserProfile")]
    public partial class UserProfile
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string Password { get; set; }

        [Key]
        [Column(Order = 1)]
        public string UserName { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
