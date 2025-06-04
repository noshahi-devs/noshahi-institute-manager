using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace NIM.Controllers
{
    public abstract class NIMControllerBase : AbpController
    {
        protected NIMControllerBase()
        {
            LocalizationSourceName = NIMConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
