namespace BookStore.Domain.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }

        public int LanguageId { get; set; }

        public int PublishHouseId { get; set; }

        [Column(TypeName = "date")]
        public DateTime PublishYears { get; set; }

        public int NumbetOfPage { get; set; }

        public string BookCharacteristic { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public virtual Author Author { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual Language Language { get; set; }

        public virtual PublishHouse PublishHouse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
