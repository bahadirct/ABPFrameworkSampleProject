using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace FTS.MovieStream;

[DependsOn(
    typeof(MovieStreamApplicationModule),
    typeof(MovieStreamDomainTestModule),
    typeof(AbpAutofacModule)

    )]
public class MovieStreamApplicationTestModule : AbpModule
{
}
