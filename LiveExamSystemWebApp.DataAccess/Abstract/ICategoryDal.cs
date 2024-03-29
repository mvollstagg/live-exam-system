﻿using LiveExamSystemWebApp.Core.DataAccess;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.DataAccess.Abstract;

public interface ICategoryDal: IEntityRepositoryAsync<Category>
{
    Task<List<Category>> GetAllCategoriesFor(string predicate);
}