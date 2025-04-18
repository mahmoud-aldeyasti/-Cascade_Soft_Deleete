using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Save_Changes_interceptors.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Save_Changes_interceptors.Data.Configuration
{
    public class PostEntityTypeConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(b => b.Id);
            
            builder.Property(b => b.Title)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            builder.Property(b => b.author)
                .IsRequired().
                HasColumnName("nvarchar(100)" ) ;

            builder.HasQueryFilter(b => !b.IsDeleted); 
        }
    }
}
