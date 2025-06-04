using NIM.Configuration.Dto;
using System.Threading.Tasks;

namespace NIM.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
