namespace ToDoList.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int User_id { get; set; }

        public int Status_id { get; set; }

        public DateTime? DeadLine { get; set; }

        public virtual Status Status { get; set; }

        public virtual Users Users { get; set; }
    }
}
