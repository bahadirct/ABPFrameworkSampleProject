using FTS.MovieStream.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FTS.MovieStream;

[DependsOn(
    typeof(MovieStreamEntityFrameworkCoreTestModule)
    )]
public class MovieStreamDomainTestModule : AbpModule
{

}
