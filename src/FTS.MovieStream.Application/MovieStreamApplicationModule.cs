using FTS.MovieStream.EntityFrameworkCore.Movies;
using FTS.MovieStream.Movies;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace FTS.MovieStream;

[DependsOn(
    typeof(MovieStreamDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(MovieStreamApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]

public class MovieStreamApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<MovieStreamApplicationModule>();

        context.Services.AddTransient<IMovieCastMemberRepository, EfCoreCastMemberRepository>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<MovieStreamApplicationModule>();
        });
    }
}
