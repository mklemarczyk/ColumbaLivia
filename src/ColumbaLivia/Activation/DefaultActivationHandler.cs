using Microsoft.UI.Xaml;

using Trogon.ColumbaLivia.Contracts.Services;
using Trogon.ColumbaLivia.ViewModels;

namespace Trogon.ColumbaLivia.Activation;

public class DefaultActivationHandler : ActivationHandler<LaunchActivatedEventArgs>
{
    private readonly INavigationService _navigationService;

    public DefaultActivationHandler(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    protected override bool CanHandleInternal(LaunchActivatedEventArgs args)
    {
        // None of the ActivationHandlers has handled the activation.
        return _navigationService.Frame?.Content == null;
    }

    protected async override Task HandleInternalAsync(LaunchActivatedEventArgs args)
    {
        _navigationService.NavigateTo(typeof(MailDetailsViewModel).FullName!, args.Arguments);

        await Task.CompletedTask;
    }
}
