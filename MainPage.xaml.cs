namespace MauiTabbedApp;

public partial class MainPage : TabbedPage
{
    public MainPage(TabbedPageViewModel viewModel)
    {
        InitializeComponent();

        this.BindingContext = viewModel;
        
        (this.BindingContext as TabbedPageViewModel)?.Tabs.ForEach(this.Children.Add);
			
        (this.BindingContext as TabbedPageViewModel)?.UpdateIconsIfSelected(this.CurrentPage, this.Children);
    }
    
    /// <inheritdoc/>
    protected override void OnCurrentPageChanged()
    {
        (this.BindingContext as TabbedPageViewModel)?.UpdateIconsIfSelected(this.CurrentPage, this.Children);
    
        base.OnCurrentPageChanged();
    }
}