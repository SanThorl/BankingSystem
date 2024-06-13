
namespace BlazorFrontend.App.Pages.UserAndAccount.User;

public partial class User : ComponentBase
{
    private UserListResponseModel _model;

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

    private async Task List(int pageNo=1, int pageSize=10)
    {
        await InjectService.EnableLoading();
        _model = await ApiService.GetUserList(pageNo, pageSize);
        if (_model.Response.IsError)
            return;
        StateHasChanged();
        await InjectService.DisableLoading();
    }

    private async Task PageChanged(int i)
    {
        pageSetting.PageNo = i;
        await List(pageSetting.PageNo, pageSetting.PageSize);
    }

    #region Dialog la lang ai hku
    private async Task DeleteUser(string userCode)
    {
        var parameters = new DialogParameters<Dialog>();
        parameters.Add(x => x.ContentText,
        "Sure to Delete?");

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

        var dialog = await DialogService.ShowAsync<Dialog>("Confirm", parameters, options);
        var result = await dialog.Result;
        if (result.Canceled) return;

        var response = await ApiService.DeleteUser(userCode);
        if(result is not null)
        {
            await InjectService.EnableLoading();
            await List(pageSetting.PageNo, pageSetting.PageSize);
            await InjectService.DisableLoading();
        }
    }
    #endregion
}
