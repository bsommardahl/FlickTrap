using System.Web.Mvc;
using AutoMapper;
using FlickTrap.Domain;
using FlickTrap.Web.Controllers;
using FlickTrap.Web.Models;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Web.Specs
{
    [Subject(typeof (UserProfileController))]
    public class when_creating_a_user_profile
    {
        static UserProfileController UserProfileController;
        static ActionResult _result;
        static Mock<IUserProfileService> _mockUserProfileService;

        Establish an_account_controller_context = () =>
            {
                new RegisterAutoMaps().Execute();

                _mockUserProfileService = new Mock<IUserProfileService>();
                _mockUserProfileService.Setup(x => x.CreateUserProfile(Moq.It.IsAny<UserProfile>())).Returns(new UserProfile
                                                                                                                 {
                                                                                                                     Username = "username",
                                                                                                                     FirstName = "first",
                                                                                                                     LastName = "last",
                                                                                                                     
                                                                                                                 });
                UserProfileController = new UserProfileController(_mockUserProfileService.Object);
            };

        Because the_user_attempts_to_create_an_account = 
            () => _result = UserProfileController.CreateUserProfile(new UserProfileCreateRequest());

        It should_use_the_service_to_create_the_user_profile = () => _mockUserProfileService.Verify( x => x.CreateUserProfile( Moq.It.IsAny<UserProfile>() ) );
        It should_map_request_to_user_profile = () => Mapper.AssertConfigurationIsValid( "UserProfileCreateRequest_to_UserProfile" );
        It should_map_new_profile_to_view_model = () => Mapper.AssertConfigurationIsValid("UserProfile_to_UserProfileViewModel");
        It should_return_a_result = () => _result.ShouldNotBeNull();
        It should_return_a_view = () => _result.ShouldBeOfType(typeof (ViewResult));
        It should_return_a_view_model = () => ((ViewResult) _result).ViewData.Model.ShouldNotBeNull();
        
        It should_return_a_view_model_with_a_user_profile_with_the_correct_username =
            () => ( ( UserProfileViewModel ) ( ( ViewResult ) _result ).ViewData.Model ).Username.ShouldEqual( "username" );
        It should_return_a_view_model_with_a_user_profile_with_the_correct_name =
            () => ( ( UserProfileViewModel ) ( ( ViewResult ) _result ).ViewData.Model ).Name.ShouldEqual( "first last" );
        
    }

    [Subject(typeof (UserProfileController))]
    public class when_editing_a_user_profile
    {
        Establish context;

        Because of;

        It should_return_a_result;
    }

}