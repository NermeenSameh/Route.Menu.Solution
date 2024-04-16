﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route.Menu.Core.Enities;

namespace Route.Menu.Infrastructure.Data.Config
{
	internal class ProductConfigurations : IEntityTypeConfiguration<Product>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
		{
			builder.Property(P => P.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(P => P.Description)
				.IsRequired();

			builder.Property(P => P.PictureUrl)
				.IsRequired();


			builder.Property(P => P.Price)
				.HasColumnType("decimal (12 , 2)");

			builder.HasOne(P => P.Brand)
				.WithMany()
				.HasForeignKey(P => P.BrandId);

			builder.HasOne(P => P.Category)
				.WithMany()
				.HasForeignKey(P =>P.CategoryId);


		}
	}
}
