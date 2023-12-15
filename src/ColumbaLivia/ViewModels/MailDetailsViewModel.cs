using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using Trogon.ColumbaLivia.Contracts.ViewModels;
using Trogon.ColumbaLivia.Core.Contracts.Services;
using Trogon.ColumbaLivia.Core.Models;

namespace Trogon.ColumbaLivia.ViewModels;

public partial class MailDetailsViewModel : ObservableRecipient, INavigationAware
{
    private readonly ISampleDataService _sampleDataService;

    [ObservableProperty]
    private SampleOrder? selected;

    public ObservableCollection<SampleOrder> SampleItems { get; private set; } = new ObservableCollection<SampleOrder>();

    public MailDetailsViewModel(ISampleDataService sampleDataService)
    {
        _sampleDataService = sampleDataService;
    }

    public async void OnNavigatedTo(object parameter)
    {
        SampleItems.Clear();

        // TODO: Replace with real data.
        var data = await _sampleDataService.GetListDetailsDataAsync();

        foreach (var item in data)
        {
            SampleItems.Add(item);
        }
    }

    public void OnNavigatedFrom()
    {
    }

    public void EnsureItemSelected()
    {
        Selected ??= SampleItems.First();
    }
}
