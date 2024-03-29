﻿using System.ComponentModel.DataAnnotations;

namespace universityApiBackend.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Createby { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string Updateby { get; set; } = string.Empty;
        public DateTime UpdateAt { get; set; }
        public string Deleteby { get; set; } = string.Empty;
        public DateTime DeleteAt { get; set; } 
        public bool IsDeleted { get; set; } = false;
    }
}
