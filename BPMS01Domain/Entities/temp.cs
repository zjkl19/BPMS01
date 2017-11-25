namespace BPMS01Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("temp")]
    public partial class temp
    {


        public Guid id { get; set; }

        /// <summary>
        /// ÇÅÁºÃû³Æ
        /// </summary>
        [Required]
        [StringLength(100)]
        public string name { get; set; }


    }
}
