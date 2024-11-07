using CommunityToolkit.Maui.Views;
using timeTableApp.ViewModels;

namespace timeTableApp;

public partial class AddCategory : Popup
{
	public AddCategory()
	{
		InitializeComponent();
		BindingContext = new EventViewModel();
	}

	public void goBack(object sender, EventArgs e)
	{
		this.Close();
	}

}