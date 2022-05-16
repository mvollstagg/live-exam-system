using Autofac;
using LiveExamSystemWebApp.Business.Abstract;
using LiveExamSystemWebApp.Business.Concrete;
using LiveExamSystemWebApp.DataAccess.Abstract;
using LiveExamSystemWebApp.DataAccess.Concrete.EntityFramework;

namespace LiveExamSystemWebApp.Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        #region Answer
        builder.RegisterType<AnswerManager>().As<IAnswerService>();
        builder.RegisterType<EfAnswerDal>().As<IAnswerDal>();
        #endregion

        #region AppConfig
        builder.RegisterType<AppConfigManager>().As<IAppConfigService>();
        builder.RegisterType<EfAppConfigDal>().As<IAppConfigDal>();
        #endregion

        #region AppSeo
        builder.RegisterType<SeoManager>().As<ISeoService>();
        builder.RegisterType<EfSeoDal>().As<ISeoDal>();
        #endregion

        #region AppUser
        builder.RegisterType<AppUserManager>().As<IAppUserService>();
        builder.RegisterType<EfAppUserDal>().As<IAppUserDal>();
        #endregion

        #region Category
        builder.RegisterType<CategoryManager>().As<ICategoryService>();
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();
        #endregion

        #region Document
        builder.RegisterType<DocumentManager>().As<IDocumentService>();
        builder.RegisterType<EfDocumentDal>().As<IDocumentDal>();
        #endregion

        #region Exam
        builder.RegisterType<ExamManager>().As<IExamService>();
        builder.RegisterType<EfExamDal>().As<IExamDal>();
        #endregion

        #region Letter
        builder.RegisterType<LetterManager>().As<ILetterService>();
        builder.RegisterType<EfLetterDal>().As<ILetterDal>();
        #endregion

        #region Question
        builder.RegisterType<QuestionManager>().As<IQuestionService>();
        builder.RegisterType<EfQuestionDal>().As<IQuestionDal>();
        #endregion
    }
}