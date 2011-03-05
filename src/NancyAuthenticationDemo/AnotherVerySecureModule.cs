namespace NancyAuthenticationDemo
{
    using Nancy.Security;
    using Models;
    using Nancy;

    /// <summary>
    /// A module that only people with SuperSecure clearance are allowed to access
    /// </summary>
    public class AnotherVerySecureModule : NancyModule
    {
        public AnotherVerySecureModule() : base("/superSecure")
        {
            this.RequiresClaims(new[] { "SuperSecure" });

            Get["/"] = x =>
            {
                var model = new UserModel(Context.Items[SecurityConventions.AuthenticatedUsernameKey].ToString());
                return View["superSecure.cshtml", model];
            };
        }
    }
}