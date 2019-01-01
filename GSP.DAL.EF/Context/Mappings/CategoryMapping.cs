﻿using GSP.DAL.EF.Context.Mappings.Contract;
using GSP.Domain.Games;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GSP.DAL.EF.Context.Mappings
{
    public class CategoryMapping : IMappingContract<Category>
    {
        public void MapEntity(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", "core");

            builder.HasKey(x => x.CategoryId);
        }
    }
}