namespace TestApp.Fundamentals;

// Testing Return Type of Methods
public class CustomersController
{
    public ActionResult GetCustomer(int id)
    {
        if (id == 0)
            return new NotFound();

        return new Ok();
    }
}


public class ActionResult { }
public class NotFound : ActionResult { }
public class Ok : ActionResult { }