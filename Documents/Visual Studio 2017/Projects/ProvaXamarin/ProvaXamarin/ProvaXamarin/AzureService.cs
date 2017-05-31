using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProvaXamarin
{
  class AzureService
  {
    static readonly string AppUrl = "http://gmbprovaxamarin.azurewebsites.net";

    public MobileServiceClient Client { get; set; } = null;

    public void Initialize()
    {
      Client = new MobileServiceClient(AppUrl);
    }

    public async Task<MobileServiceUser> LoginAsync()
    {
      Initialize();
      var auth = DependencyService.Get<IAuthenticate>();
      var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

      if (user == null)
      {
        Device.BeginInvokeOnMainThread(async () => {
          await Application.Current.MainPage.DisplayAlert("Ops!", 
                "Não conseguimos efetuar o seu login, tente Novamente",
                "OK");
        });
        return null;
      }
      return user;
    }


  }
}
