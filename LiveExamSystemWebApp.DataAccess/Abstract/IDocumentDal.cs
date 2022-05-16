﻿using LiveExamSystemWebApp.Core.DataAccess;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.DataAccess.Abstract;

public interface IDocumentDal : IEntityRepositoryAsync<Document>
{

}