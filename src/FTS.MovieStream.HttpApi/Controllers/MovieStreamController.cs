using FTS.MovieStream.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FTS.MovieStream.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MovieStreamController : AbpControllerBase
{
    protected MovieStreamController()
    {
        LocalizationResource = typeof(MovieStreamResource);
    }
}
