using Abp.Authorization;
using Abp.Runtime.Session;
using NIM.Configuration.Dto;
using System.Threading.Tasks;

namespace NIM.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : NIMAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
