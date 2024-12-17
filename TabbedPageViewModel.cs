using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiTabbedApp
{
	public partial class TabbedPageViewModel : ObservableObject
	{
		private List<Page> tabs;

		/// <summary>
		/// Gets or sets the selected tab color.
		/// </summary>
		[ObservableProperty] private Color selectedTabColor;
        
        /// <summary>
        /// Gets or sets the unselected tab color.
        /// </summary>
        [ObservableProperty] private Color unselectedTabColor;

		/// <summary>
		/// Gets the list of tabs.
		/// </summary>
		public List<Page> Tabs
		{
			get
			{
				if (this.tabs == null || !this.tabs.Any())
				{
					this.CreateTabPages();
				}

				return this.tabs;
			}
		}

		/// <summary>
		/// Gets the tabs to display.
		/// </summary>
		private void CreateTabPages()
		{
			var navPage1 = new NavigationPage(new ContentPage())
			{
				Title = "Title 1",
				IconImageSource = new FontImageSource
				{
					Glyph = "\ue061",
					Size = 25,
					Color = Colors.Grey
				}
			};
			
			var navPage2 = new NavigationPage(new ContentPage())
			{
				Title = "Title 2",
				IconImageSource = new FontImageSource
				{
					Glyph = "\ue061",
					Size = 25,
					Color = Colors.Grey
				}
			};

			var navPage3 = new NavigationPage(new ContentPage())
			{
				Title = "Title 3",
				IconImageSource = new FontImageSource
				{
					Glyph = "\ue061",
					Size = 25,
					Color = Colors.Grey
				}
			};
			
			this.tabs = new List<Page>
			{
				navPage1,
				navPage2,
				navPage3
			};
		}

		/// <summary>
		/// Updates the icon for each tab if it is selected or deselected.
		/// </summary>
		/// <param name="currentPage">The current page.</param>
		/// <param name="pageChildren">The tabbed view's children.</param>
		public void UpdateIconsIfSelected(Page currentPage, IList<Page> pageChildren)
		{
			foreach (var child in pageChildren)
			{
				if (child.Title.Equals(currentPage.Title))
				{
					this.SetSelectedTabColor(child);
				}
				else
				{
					this.SetUnselectedTabColor(child);
				}
			}
		}

		private void SetSelectedTabColor(Page child)
		{
			var iconImageSource = child.IconImageSource as FontImageSource;
			
			var color = child.Title == "Title 3"
				? Colors.Red
				: Colors.DodgerBlue;
			
			child.IconImageSource = new FontImageSource
			{
				Glyph = iconImageSource.Glyph,
				Size = iconImageSource.Size,
				FontFamily = "FA-S",
				Color = color
			};
			
			this.SelectedTabColor = color;
		}

		private void SetUnselectedTabColor(Page child)
		{
			var iconImageSource = child.IconImageSource as FontImageSource;
			
			var color = child.Title == "Title 3"
				? Colors.Red
				: Colors.DodgerBlue;
			
			child.IconImageSource = new FontImageSource
			{
				Glyph = iconImageSource.Glyph,
				Size = iconImageSource.Size,
				FontFamily = "FA-L",
				Color = color
			};
		}
	}
}