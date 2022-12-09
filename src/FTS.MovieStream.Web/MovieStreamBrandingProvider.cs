using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FTS.MovieStream.Web;

[Dependency(ReplaceServices = true)]
public class MovieStreamBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MovieStream";
}
