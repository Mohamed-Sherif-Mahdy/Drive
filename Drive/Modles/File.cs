﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Drive.Modles
{
    public class File
    {
        [Key]
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
