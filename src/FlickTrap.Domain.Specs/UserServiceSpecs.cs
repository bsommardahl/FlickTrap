using System;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Domain.Specs
{
    namespace UserServiceSpecs
    {
        public abstract class given_a_user_profile_service_context
        {
            protected static UserProfileService _userProfileService;
            protected static Mock<IUserProfileRepository> _mockUserProfileRepository;

            Establish a_user_profile_service_context = () =>
                {
                    _mockUserProfileRepository = new Mock<IUserProfileRepository>();

                    _userProfileService = new UserProfileService(_mockUserProfileRepository.Object);
                };
        }

        [Subject(typeof (UserProfileService))]
        public class when_a_user_profile_is_requested_with_failure : given_a_user_profile_service_context
        {
            static UserProfile _result;

            Because of = () => _result = _userProfileService.Get(1);

            It should_return_null = () => _result.ShouldBeNull();
        }

        [Subject(typeof (UserProfileService))]
        public class when_a_user_profile_is_requested_with_success : given_a_user_profile_service_context
        {
            static UserProfile _result;
            static UserProfile _userProfile;
            static Flick _flick;

            Establish a_valid_context = () =>
                {
                    _flick = new Flick
                                 {
                                     Name = "Star Wars: Empire Strikes Back",
                                     Description = "The best movie ever.",
                                     Rating = "PG",
                                     UserRating = 9.8M,
                                     TheaterReleaseDate = new DateTime(1974, 11, 2),
                                     RentalReleaseDate = new DateTime(1987, 6, 20),
                                     ThumbnailUrl = "http://www.lucas.com/empire.jpg"
                                 };

                    _userProfile = new UserProfile
                                       {
                                           Name = "User Real Name",
                                           Trapped = new List<Flick>
                                                         {
                                                             _flick,
                                                             new Flick(),
                                                             new Flick(),
                                                         }
                                       };

                    _mockUserProfileRepository.Setup(x => x.Get(1)).Returns(_userProfile);
                };

            Because of = () => _result = _userProfileService.Get(1);

            It should_return_a_correct_name = () => _result.Name.ShouldEqual("User Real Name");
            It should_return_a_list_of_trapped_flicks = () => _result.Trapped.Count().ShouldEqual(3);
            It should_return_a_user_profile = () => _result.ShouldNotBeNull();
            It should_return_the_first_trapped_flick_correct_description = () => _result.Trapped.First().Description.ShouldEqual("The best movie ever.");
            It should_return_the_first_trapped_flick_with_correct_name = () => _result.Trapped.First().Name.ShouldEqual("Star Wars: Empire Strikes Back");
            It should_return_the_first_trapped_flick_with_correct_rating = () => _result.Trapped.First().Rating.ShouldEqual("PG");
            It should_return_the_first_trapped_flick_with_correct_rental_release_date = () => _result.Trapped.First().RentalReleaseDate.ShouldEqual(new DateTime(1987, 6, 20));
            It should_return_the_first_trapped_flick_with_correct_theater_release_date = () => _result.Trapped.First().TheaterReleaseDate.ShouldEqual(new DateTime(1974, 11, 2));
            It should_return_the_first_trapped_flick_with_correct_thumbnail_url = () => _result.Trapped.First().ThumbnailUrl.ShouldEqual("http://www.lucas.com/empire.jpg");
            It should_return_the_first_trapped_flick_with_correct_user_rating = () => _result.Trapped.First().UserRating.ShouldEqual(9.8M);
        }
    }
}