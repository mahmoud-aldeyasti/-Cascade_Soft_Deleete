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
    public class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired().
                HasColumnType("nvarchar(100)");


            builder.Property(b => b.Description)
                .IsRequired();

            builder.HasQueryFilter( b => !b.IsDeleted);

            builder.HasMany(b => b.Posts)
                .WithOne(p => p.Blog)
                .HasForeignKey(p => p.BlogId);

        }
    }
}
