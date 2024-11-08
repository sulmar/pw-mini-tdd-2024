using System;

namespace TestApp.Mocking
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }        
    }

    public class TokensController : BaseController
    {
        public ActionResult Create(LoginModel model)
        {
            // TODO: Authorize and return token

            throw new NotImplementedException();
        }
    }

    public class BaseController
    {
        public ActionResult Ok(object? value) => new Ok(value);
        public ActionResult Unauthorized() => new Unauthorized();
    }

    public abstract class ActionResult { }
    public class Ok(object? value) : ActionResult { }
    public class Unauthorized : ActionResult { }
    
}
