using System;
using System.Collections.Generic;
using System.Linq;
using FlickTrap.Domain.Abstract;
using FlickTrap.Domain.Exceptions;
using Machine.Specifications;
using Moq;
using It = Machine.Specifications.It;

namespace FlickTrap.Domain.Specs
{
    namespace FlickInfoServiceSpecs
    {
        public abstract class given_a_flick_info_service_context
        {
            protected static Mock<IFlickInfoWebServiceFacade> _mockFlickInfoWebServiceFacade;
            protected static Mock<IUserProfileRepository> _mockUserProfileRepository;
            protected static FlickInfoService _flickInfoService;
            protected static Mock<IFlickRepository> _mockFlickRepository;

            Establish context = () =>
                {
                    _mockFlickRepository = new Mock<IFlickRepository>();

                    _mockFlickInfoWebServiceFacade = new Mock<IFlickInfoWebServiceFacade>();

                    _mockUserProfileRepository = new Mock<IUserProfileRepository>();

                    _flickInfoService = new FlickInfoService(_mockFlickInfoWebServiceFacade.Object,
                                                             _mockUserProfileRepository.Object,
                                                             _mockFlickRepository.Object);
                };
        }

        namespace when_requesting_flick_lists
        {
            [Subject(typeof (FlickInfoService))]
            public class when_requesting_unreleased_flicks : given_a_flick_info_service_context
            {
                static IEnumerable<Flick> _result;

                Establish additional_context = () =>
                    {
                        var unreleasedFlicks = new List<Flick>
                                                   {
                                                       new Flick {Name = "Avatar II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                       new Flick {Name = "My Movie II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                       new Flick {Name = "Love Hurts II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                       new Flick {Name = "Karate Kid VII", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                       new Flick {Name = "Star Wars X", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                       new Flick {Name = "Hitch II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                       new Flick {Name = "Hannibal II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                       new Flick {Name = "Epic Movie", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                   };

                        _mockFlickRepository.Setup(x => x.GetUnreleasedFlicks()).Returns(unreleasedFlicks);
                    };

                Because of = () => _result = _flickInfoService.GetUnreleasedFlicks();

                It should_return_a_list_of_flicks = () => _result.ShouldNotBeNull();
                It should_return_the_correct_number_of_flicks = () => _result.Count().ShouldEqual(8);
                It should_return_the_first_flick_with_the_correct_name = () => _result.First().Name.ShouldEqual("Avatar II");
            }

            [Subject(typeof (FlickInfoService))]
            public class when_requesting_recently_released_flicks : given_a_flick_info_service_context
            {
                static IEnumerable<Flick> _result;

                Establish additional_context = () =>
                    {
                        var recentlyReleasedFlicks = new List<Flick>
                                                         {
                                                             new Flick {Name = "Hitch", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                             new Flick {Name = "Immortal", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                             new Flick {Name = "Airbender", Rating = "PG", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                             new Flick {Name = "Avatar", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                             new Flick {Name = "Handy", Rating = "PG", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                             new Flick {Name = "The Horse", Rating = "G", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                             new Flick {Name = "Revenge of the Nerds VIII", Rating = "PG-13", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                             new Flick {Name = "Alien vs Predator", Rating = "R", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                             new Flick {Name = "Love Hurts", Rating = "PG", TheaterReleaseDate = new DateTime(2010, 1, 1)},
                                                         };

                        _mockFlickRepository.Setup(x => x.GetRecentlyReleased()).Returns(recentlyReleasedFlicks);
                    };

                Because of = () => _result = _flickInfoService.GetRecentlyReleasedFlicks();

                It should_return_a_list_of_flicks = () => _result.ShouldNotBeNull();
                It should_return_the_correct_number_of_flicks = () => _result.Count().ShouldEqual(9);
                It should_return_the_first_flick_with_the_correct_name = () => _result.First().Name.ShouldEqual("Hitch");
            }
        }

        namespace when_requesting_a_flick
        {
            [Subject(typeof (FlickInfoService))]
            public class when_flick_is_requested_with_failure : given_a_flick_info_service_context
            {
                static Flick _result;

                Because of = () => _result = _flickInfoService.GetFlick(null, "123-1");

                It should_return_null = () => _result.ShouldBeNull();
            }

            [Subject(typeof (FlickInfoService))]
            public class when_trapped_flick_is_requested_by_authenticated_user : given_a_flick_info_service_context
            {
                static UserProfile userProfile;
                static Flick _result;

                Establish additional_context = () =>
                    {
                        userProfile = new UserProfile
                                          {
                                              Trapped = new List<Flick> {new Flick {ImdbId = "123", Name = "Avatar"}}
                                          };
                        _mockUserProfileRepository.Setup(x => x.GetUserProfile("username")).Returns(userProfile);
                    };

                Because of = () => _result = _flickInfoService.GetFlick("username", "123");

                It should_return_correct_flick = () => _result.Name.ShouldEqual("Avatar");
            }

            [Subject(typeof (FlickInfoService))]
            public class when_untrapped_flick_is_requested_by_authenticated_user : given_a_flick_info_service_context
            {
                static UserProfile userProfile;
                static Flick _result;

                Establish additional_context = () =>
                    {
                        _mockFlickInfoWebServiceFacade.Setup(x => x.DownloadFlickInfo("123")).Returns(new Flick
                                                                                                          {
                                                                                                              Name = "Hitch"
                                                                                                          });
                        userProfile = new UserProfile();
                        _mockUserProfileRepository.Setup(x => x.GetUserProfile("username")).Returns(userProfile);
                    };

                Because of = () => _result = _flickInfoService.GetFlick("username", "123");

                It should_return_correct_flick = () => _result.Name.ShouldEqual("Hitch");
            }

            [Subject(typeof (FlickInfoService))]
            public class when_untrapped_flick_is_requested_by_invalid_user : given_a_flick_info_service_context
            {
                static UserProfile userProfile;
                static Flick _result;
                static Exception _exception;

                Establish additional_context = () =>
                    {
                        _mockFlickInfoWebServiceFacade.Setup(x => x.DownloadFlickInfo("123")).Returns(new Flick
                                                                                                          {
                                                                                                              Name = "Hitch"
                                                                                                          });
                        userProfile = new UserProfile();
                        _mockUserProfileRepository.Setup(x => x.GetUserProfile("username")).Returns(userProfile);
                    };

                Because of = () => _exception = Catch.Exception(() => _result = _flickInfoService.GetFlick("username-bad", "123"));

                It should_throw_an_exception = () => _exception.ShouldNotBeNull();
                It should_throw_the_correct_exception = () => _exception.ShouldBeOfType(typeof (UserProfileNotFoundException));
            }
        }

        namespace when_trapping_a_flick
        {
            [Subject(typeof (FlickInfoService))]
            public class when_trapping_a_flick_with_unauthenticated_user : given_a_flick_info_service_context
            {
                static Exception _exception;

                Because of = () => { _exception = Catch.Exception(() => _flickInfoService.Trap(null, "123")); };

                It should_throw_an_exception = () => _exception.ShouldNotBeNull();
                It should_throw_the_correct_exception = () => _exception.ShouldBeOfType(typeof (UserProfileNotFoundException));
            }

            [Subject(typeof (FlickInfoService))]
            public class when_trapping_an_invalid_flick : given_a_flick_info_service_context
            {
                static Exception _exception;
                Establish additional_context = () => { _mockUserProfileRepository.Setup(x => x.GetUserProfile("username")).Returns(new UserProfile()); };

                Because of = () => _exception = Catch.Exception(() => _flickInfoService.Trap("username", "123-bad"));

                It should_throw_an_exception = () => _exception.ShouldNotBeNull();
                It should_throw_the_correct_exception = () => _exception.ShouldBeOfType(typeof (FlickNotFoundException));
            }

            [Subject(typeof (FlickInfoService))]
            public class when_trapping_a_flick_with_an_authenticated_user : given_a_flick_info_service_context
            {
                static Flick _result;

                Establish additional_context = () =>
                    {
                        _mockUserProfileRepository.Setup(x => x.GetUserProfile("username")).Returns(new UserProfile());

                        _mockFlickInfoWebServiceFacade.Setup(x => x.DownloadFlickInfo("123")).Returns(new Flick
                                                                                                          {
                                                                                                              Name = "Hitch"
                                                                                                          });
                    };

                Because of = () => _flickInfoService.Trap("username", "123");

                It should_trap_the_flick_in_the_user_profile = () => _mockUserProfileRepository.Verify(x => x.Save(Moq.It.IsAny<UserProfile>()));
            }

            [Subject(typeof (FlickInfoService))]
            public class when_trapping_a_flick_that_is_already_trapped_for_this_user : given_a_flick_info_service_context
            {
                static Flick _result;

                Establish additional_context = () =>
                    {
                        _mockUserProfileRepository.Setup(x => x.GetUserProfile("username")).Returns(new UserProfile
                                                                                                        {
                                                                                                            Trapped = new List<Flick> {new Flick {ImdbId = "123"}}
                                                                                                        });
                    };

                Because of = () => _flickInfoService.Trap("username", "123");

                It should_not_add_the_flick_to_the_profile = () => _mockUserProfileRepository.Verify(x => x.Save(Moq.It.IsAny<UserProfile>()), Times.Never());
            }
        }

        namespace when_untrapping_a_flick
        {
            [Subject(typeof (FlickInfoService))]
            public class when_untrapping_a_flick_with_an_authenticated_user : given_a_flick_info_service_context
            {
                Establish additional_context = () => _mockUserProfileRepository.Setup(x => x.GetUserProfile("username"))
                                                         .Returns(new UserProfile
                                                                      {
                                                                          Trapped = new List<Flick> {new Flick {ImdbId = "123"}}
                                                                      });

                Because of = () => _flickInfoService.Untrap("username", "123");

                It should_remove_the_flick_from_the_users_trapped_list = () => _mockUserProfileRepository.Verify(x => x.Save(Moq.It.IsAny<UserProfile>()));
            }

            [Subject(typeof (FlickInfoService))]
            public class when_untrapping_a_flick_with_an_unauthenticated_user : given_a_flick_info_service_context
            {
                static Exception _exception;

                Because of = () => _exception = Catch.Exception(() => _flickInfoService.Untrap("username-bad", "123"));

                It should_throw_an_exception = () => _exception.ShouldNotBeNull();
                It should_throw_the_correct_exception = () => _exception.ShouldBeOfType(typeof (UserProfileNotFoundException));
            }

            [Subject(typeof (FlickInfoService))]
            public class when_untrapping_a_flick_that_is_not_already_trapped : given_a_flick_info_service_context
            {
                static Exception _exception;

                Establish additional_context = () => _mockUserProfileRepository.Setup(x => x.GetUserProfile("username"))
                                                         .Returns(new UserProfile
                                                                      {
                                                                          Trapped = new List<Flick> {new Flick {ImdbId = "123"}}
                                                                      });

                Because of = () => _exception = Catch.Exception(() => _flickInfoService.Untrap("username", "123-bad"));

                It should_throw_an_exception = () => _exception.ShouldNotBeNull();
                It should_throw_the_correct_exception = () => _exception.ShouldBeOfType(typeof (FlickNotFoundException));
            }
        }

        namespace when_searching_for_a_flick
        {
            [Subject(typeof (FlickInfoService))]
            public class when_searching_for_a_flick_with_no_results : given_a_flick_info_service_context
            {
                static IEnumerable<Flick> _result;

                Because of = () => _result = _flickInfoService.Search("a movie");

                It should_return_an_empty_list = () => _result.Count().ShouldEqual(0);
            }

            [Subject(typeof (FlickInfoService))]
            public class when_searching_for_a_flick_with_blank_search_text : given_a_flick_info_service_context
            {
                static IEnumerable<Flick> _result;
                
                Because of = () => _result = _flickInfoService.Search(" ");

                It should_return_an_empty_list = () => _result.Count().ShouldEqual(0);
            }

            [Subject(typeof (FlickInfoService))]
            public class when_searching_for_a_flick_with_results : given_a_flick_info_service_context
            {
                static IEnumerable<Flick> _result;

                Establish additional_context = () =>
                    {
                        var _a_list_of_flicks = new List<Flick>
                                                    {
                                                        new Flick {Name = "Avatar II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                        new Flick {Name = "My Movie II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                        new Flick {Name = "Love Hurts II", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                        new Flick {Name = "Karate Kid VII", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                        new Flick {Name = "Star Wars X", Rating = "PG-13", TheaterReleaseDate = new DateTime(2013, 1, 1)},
                                                    };

                        _mockFlickInfoWebServiceFacade.Setup(x => x.Search("a movie")).Returns(_a_list_of_flicks);
                    };

                Because of = () => _result = _flickInfoService.Search("a movie");

                It should_return_a_list_of_five_flicks = () => _result.Count().ShouldEqual(5);
                It should_return_a_list_of_flicks = () => _result.ShouldNotBeNull();
            }
        }
    }
}