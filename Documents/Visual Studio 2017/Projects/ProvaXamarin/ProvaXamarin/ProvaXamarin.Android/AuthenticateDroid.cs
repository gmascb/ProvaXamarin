using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace ProvaXamarin.Droid
{
  public class AuthenticateDroid : IAuthenticate
  {
    public AuthenticateDroid()
    { }

    public async Task<MobileServiceUser> Authenticate(MobileServiceClient client,  MobileServiceAuthenticationProvider provider)
    {
      try
      {
        return await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);
      }
      catch (Exception ex)
      {
        return null;
      }
    }
  }
}