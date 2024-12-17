namespace MauiTabbedApp;

public partial class App : Application
{
    public App(TabbedPageViewModel tabbedPage)
    {
        InitializeComponent();

        MainPage = new MainPage(tabbedPage);
    }
}