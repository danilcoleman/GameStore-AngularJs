﻿using System.Collections.Generic;
using System.Linq;
using GSP.DAL.Context;
using GSP.DAL.Repositories.Contracts;
using GSP.Domain.Games;

namespace GSP.DAL.Repositories
{
    public class CategoryRepository : GameStoreRepository<Category>, ICategoryRepository
    {
        private readonly GameStoreContext _dbContext;

        public CategoryRepository(GameStoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _dbContext.Categories.AsEnumerable();
        }

        public Category GetCategoryByName(string name)
        {
            return _dbContext.Categories.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
