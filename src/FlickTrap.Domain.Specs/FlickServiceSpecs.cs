using System;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Domain.Specs
{
    namespace FlickServiceSpecs
    {
        [Subject(typeof (FlickService))]
        public class when_a_flick_is_requested_by_id
        {
            static FlickService _flickService;
            static Flick _result;
            static Mock<IFlickRepository> _flickRepository;

            Establish context = () =>
                {
                    var flick = new Flick
                                    {
                                        Name = "Star Wars: Empire Strikes Back",
                                        Description = "The best movie ever.",
                                        Rating = "PG",
                                        UserRating = 9.8M,
                                        TheaterReleaseDate = new DateTime(1974, 11, 2),
                                        RentalReleaseDate = new DateTime(1987, 6,20),
                                        ThumbnailUrl = "http://www.lucas.com/empire.jpg"
                                    };

                    _flickRepository = new Mock<IFlickRepository>();
                    _flickRepository.Setup(x => x.Get(1)).Returns(flick);

                    _flickService = new FlickService(_flickRepository.Object);
                };

            Because of = () => _result = _flickService.GetFlick(1);

            It should_return_a_flick = () => _result.ShouldNotBeNull();
            It should_return_a_flick_with_correct_name = () => _result.Name.ShouldEqual("Star Wars: Empire Strikes Back");
            It should_return_a_flick_with_correct_rating = () => _result.Rating.ShouldEqual( "PG" );
            It should_return_a_flick_with_correct_user_rating = () => _result.UserRating.ShouldEqual( 9.8M );
            It should_return_a_flick_with_correct_description = () => _result.Description.ShouldEqual( "The best movie ever." );
            It should_return_a_flick_with_correct_theater_release_date = () => _result.TheaterReleaseDate.ShouldEqual(new DateTime(1974, 11, 2));
            It should_return_a_flick_with_correct_rental_release_date = () => _result.RentalReleaseDate.ShouldEqual( new DateTime(1987, 6, 20));
            It should_return_a_flick_with_correct_thumbnail_url = () => _result.ThumbnailUrl.ShouldEqual( "http://www.lucas.com/empire.jpg" );
        }
    }
}