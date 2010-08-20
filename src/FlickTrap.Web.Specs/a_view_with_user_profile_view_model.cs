using System.Web.Mvc;
using FlickTrap.Web.Models;
using Machine.Specifications;

namespace FlickTrap.Web.Specs
{
    [Behaviors]
    public class a_view_with_user_profile_view_model
    {
        protected static ActionResult _result;
        
        It should_return_a_view_model_with_a_user_profile_with_the_correct_username =
            () => ( ( UserProfileViewModel ) ( ( ViewResult ) _result ).ViewData.Model ).Username.ShouldEqual( "username" );

        It should_return_a_view_model_with_a_user_profile_with_the_correct_name =
            () => ( ( UserProfileViewModel ) ( ( ViewResult ) _result ).ViewData.Model ).Name.ShouldEqual( "first last" );
    }
}