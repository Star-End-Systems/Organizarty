namespace Organizarty.UI.Helpers;

public class AuthenticationHelper{
    private HttpResponse Response {get; set;}
    public AuthenticationHelper(HttpResponse response){
        Response = response;
    }

    public void WriteToken(string token){
        Response.Cookies.Append(
            "JWT_TOKEN",
            token ?? "nada",
            new CookieOptions()
            {
                Path = "/"
            }
        );
    }

}