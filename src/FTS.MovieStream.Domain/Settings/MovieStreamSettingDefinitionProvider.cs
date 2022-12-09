using Volo.Abp.Settings;

namespace FTS.MovieStream.Settings;

public class MovieStreamSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MovieStreamSettings.MySetting1));
    }
}
