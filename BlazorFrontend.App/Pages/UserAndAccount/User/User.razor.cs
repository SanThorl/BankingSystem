using Microsoft.AspNetCore.Components;
using Models;
using Models.AdminUser;
using System.Runtime.InteropServices;

namespace BlazorFrontend.App.Pages.UserAndAccount.User;

public partial class User : ComponentBase
{
    private AdminUserListResponseModel _model;

    private PageSettingModel pageSetting = new()
    {
        PageNo =1,
        PageSize = 10
    };

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await List(pageSetting.PageNo, pageSetting.PageSize);
        }
    }

    private async void List(int pageNo=1, int pageSize=10)
    {
        await InjectService.EnableLoading();
        _model = await ApiService.GetUserList(pageNo, pageSize);
        if (_model.Response.IsError)
            return;
        StateHasChanged();
        await InjectService.DisableLoading();
    }


}
