using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace DecisionTree.Plugins.SimpleCMS.Pages;

public class IndexModel : SimpleCMSPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
