using CommunityToolkit.WinUI.UI.Controls;

using Microsoft.UI.Xaml.Controls;

using Trogon.ColumbaLivia.ViewModels;

namespace Trogon.ColumbaLivia.Views;

public sealed partial class MailDetailsPage : Page
{
    public MailDetailsViewModel ViewModel
    {
        get;
    }

    public MailDetailsPage()
    {
        ViewModel = App.GetService<MailDetailsViewModel>();
        InitializeComponent();
    }

    private void OnViewStateChanged(object sender, ListDetailsViewState e)
    {
        if (e == ListDetailsViewState.Both)
        {
            ViewModel.EnsureItemSelected();
        }
    }
}
