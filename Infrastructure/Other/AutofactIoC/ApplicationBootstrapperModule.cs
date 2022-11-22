using ApplicationCore.DomainServices.Implementation;
using ApplicationCore.DomainServices.Interfaces;
using Autofac;
using DomainServices.Repositories;
using Infrastructure.Persistence.InMemoryDB.Repositories;


namespace Infrastructure.Other.AutofactIoC
{
    public class ApplicationBootstrapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContentModerator>()
                .As<IContentModerator>()
                .InstancePerDependency();

            builder.RegisterType<PostManager>()
                .As<IPostManager>()
                .InstancePerDependency();

            builder.RegisterType<PostRetriever>()
                .As<IPostRetriever>()
                .InstancePerDependency();

            builder.RegisterType<PostInMemoryRepository>()
                .As<IPostRepository>()
                .SingleInstance();
        }
    }
}
