using Microsoft.JSInterop;

namespace BlazorFrontend.App.Services;

public class InjectService
{
    private readonly IJSRuntime _jsRuntime;

    public InjectService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task EnableLoading()
    {
        await _jsRuntime.InvokeVoidAsync("enableloading", true);
    }

    public async Task DisableLoading()
    {
        await _jsRuntime.InvokeVoidAsync("enableloading", false);
    }

}
