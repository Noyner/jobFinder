﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.DAL.Models.DatabaseModels.Files
{
    public class File
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string OriginalName { get; set; }

        public string ContentType { get; set; }

        public string Base64Content { get; set; }

        public DateTime? CreatedAt { get; set; }

        public bool IsDeleted { get; set; }
        
        public FileType Type { get; set; }
        
    }
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> item)
        {

        }
    }
}