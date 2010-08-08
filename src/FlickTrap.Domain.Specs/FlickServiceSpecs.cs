using System;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Domain.Specs
{
    namespace FlickServiceSpecs
    {
        public abstract class given_a_flick_service_context
        {
            protected static FlickService _flickService;
            protected static Mock<IFlickRepository> _mockFlickRepository;
            protected static Flick _flick;

            Establish context = () =>
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

                    _mockFlickRepository = new Mock<IFlickRepository>();

                    _flickService = new FlickService(_mockFlickRepository.Object);
                };
        }

        namespace when_requesting_a_flick
        {
            [Subject(typeof (FlickService))]
            public class when_a_flick_is_requested_by_id : given_a_flick_service_context
            {
                static Flick _result;

                Establish additional_context = () => _mockFlickRepository.Setup(x => x.Get(1)).Returns(_flick);

                Because of = () => _result = _flickService.GetFlick(1);

                It should_return_a_flick = () => _result.ShouldNotBeNull();
                It should_return_a_flick_with_correct_description = () => _result.Description.ShouldEqual("The best movie ever.");
                It should_return_a_flick_with_correct_name = () => _result.Name.ShouldEqual("Star Wars: Empire Strikes Back");
                It should_return_a_flick_with_correct_rating = () => _result.Rating.ShouldEqual("PG");
                It should_return_a_flick_with_correct_rental_release_date = () => _result.RentalReleaseDate.ShouldEqual(new DateTime(1987, 6, 20));
                It should_return_a_flick_with_correct_theater_release_date = () => _result.TheaterReleaseDate.ShouldEqual(new DateTime(1974, 11, 2));
                It should_return_a_flick_with_correct_thumbnail_url = () => _result.ThumbnailUrl.ShouldEqual("http://www.lucas.com/empire.jpg");
                It should_return_a_flick_with_correct_user_rating = () => _result.UserRating.ShouldEqual(9.8M);
            }

            [Subject(typeof (FlickService))]
            public class when_a_flick_is_requested_with_invalid_id : given_a_flick_service_context
            {
                static Flick _result;

                Because of = () => _result = _flickService.GetFlick(1);

                It should_return_null = () => _result.ShouldBeNull();
            }
        }

        namespace when_trapping_a_flick
        {
            [Subject(typeof (FlickService))]
            public class when_trapping_a_flick_with_success : given_a_flick_service_context
            {
                static bool _result;

                Because of = () =>
                    {
                        _result = _flickService.TrapFlick(_flick);
                        
                    };

                It should_return_true = () => _result.ShouldBeTrue();
                It should_save_the_flick_to_the_repo = () => _mockFlickRepository.Verify(x => x.Add(_flick));
            }

        }
    }
}