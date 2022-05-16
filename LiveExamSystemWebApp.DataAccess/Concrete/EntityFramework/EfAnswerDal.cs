using LiveExamSystemWebApp.Core.DataAccess.EntityFramework;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.DataAccess.Concrete.EntityFramework.Context;
using LiveExamSystemWebApp.Entities.Concrete;

namespace LiveExamSystemWebApp.DataAccess.Concrete.EntityFramework;

public class EfAnswerDal : EfEntityRepositoryBaseAsync<Answer, LiveExamSystemContext>, IAnswerDal
{
    
}