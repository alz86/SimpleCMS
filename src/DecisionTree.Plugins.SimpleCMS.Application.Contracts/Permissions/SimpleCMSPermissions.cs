using Volo.Abp.Reflection;

namespace DecisionTree.Plugins.SimpleCMS.Permissions;

public class SimpleCMSPermissions
{
    public const string GroupName = "SimpleCMS";

    public const string EditContentPermission = $"{GroupName}.Edit_Content";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(SimpleCMSPermissions));
    }
}
