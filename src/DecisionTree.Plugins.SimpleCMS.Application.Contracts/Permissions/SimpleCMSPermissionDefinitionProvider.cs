using DecisionTree.Plugins.SimpleCMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DecisionTree.Plugins.SimpleCMS.Permissions;

public class SimpleCMSPermissionDefinitionProvider : PermissionDefinitionProvider
{
    

    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SimpleCMSPermissions.GroupName, L(SimpleCMSConsts.LocalizedTexts.Permissions.GroupName));
        myGroup.AddPermission(SimpleCMSPermissions.EditContentPermission, L(SimpleCMSConsts.LocalizedTexts.Permissions.Edit));
    }

    private static LocalizableString L(string name) => LocalizableString.Create<SimpleCMSResource>(name);
}
