namespace BPMS01Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]

        public Guid id { get; set; }

        /// <summary>
        /// ÄÚÈÝ
        /// </summary>
        [Required]
        public string content { get; set; }

        public virtual News News { get; set; }

    }
}
