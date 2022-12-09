using FTS.MovieStream.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace FTS.MovieStream.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MovieStreamEntityFrameworkCoreModule),
    typeof(MovieStreamApplicationContractsModule)
    )]
public class MovieStreamDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
