using System.Runtime.CompilerServices;

namespace Survey_SuCarnet;

public partial class SurveyDetailsView : ContentPage
{
	private readonly string[] teams =
	{
		"Alianza Lima",
		 "america",
		"boca junior",
		"caracas Fc",
		"colo-colo",
		"Peñalrol",
		"Real madrid",
		"saprissa",

	};

	public SurveyDetailsView()
	{
		InitializeComponent();
	}
	   private async void FavoriteTeamButton_Clicked(object sender, EventArgs e)
	{
		var FavoriteTeam = await DisplayActionSheet(Literals.FavoriteTeamTitle, null, null, teams);
		  if(!string .IsNullOrWhiteSpace(FavoriteTeam))
	   {
			FavoriteTeamLabel.Text = FavoriteTeam;
	  	}
       
    }

    [Obsolete]
    private async void OkButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameEntry.Text) || string.IsNullOrWhiteSpace(FavoriteTeamLabel.Text))
        {
            return;
        }

        var newSurvey = new Survey()
        {
            Name = NameEntry.Text,
            Birthdate = BirthdatePicker.Date,
            FavoriteTeam = FavoriteTeamLabel.Text

        };

        MessagingCenter.Send((ContentPage)this,
        Messages.NewSurveyComplete, newSurvey);
        await Navigation.PopAsync();
    }

}