using System;
using System.Collections.Generic;
using System.Text;
using FTS.MovieStream.Localization;
using Volo.Abp.Application.Services;

namespace FTS.MovieStream;

/* Inherit your application services from this class.
 */
public abstract class MovieStreamAppService : ApplicationService
{
    protected MovieStreamAppService()
    {
        LocalizationResource = typeof(MovieStreamResource);
    }
}
