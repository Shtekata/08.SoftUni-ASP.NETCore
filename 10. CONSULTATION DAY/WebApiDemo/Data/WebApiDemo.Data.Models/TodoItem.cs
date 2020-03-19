﻿namespace WebApiDemo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using WebApiDemo.Data.Common.Models;

    public class TodoItem : BaseDeletableModel<int>
    {
        [Required]
        public string Title { get; set; }

        public bool IsDone { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }
    }
}
