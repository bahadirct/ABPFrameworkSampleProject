using FTS.MovieStream.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FTS.MovieStream.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MovieStreamPageModel : AbpPageModel
{
    protected MovieStreamPageModel()
    {
        LocalizationResourceType = typeof(MovieStreamResource);
    }
}
