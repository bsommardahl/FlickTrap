using System.Collections.Generic;
using System.Web.SessionState;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using FlickTrap.Web.Specs.MvcFakes;
using Machine.Specifications;
using Moq;

namespace FlickTrap.Web.Specs.HomeController
{
    public abstract class given_a_home_controller_context
    {
        protected static Controllers.HomeController _controller;
        protected static Mock<IFlickInfoService> _flickInfoService;
        protected static List<Flick> _list_of_flicks;

        Establish a_home_controller_context = () =>
            {
                new RegisterAutoMaps().Execute();
                    
                _flickInfoService = new Mock<IFlickInfoService>();

                _controller = new Controllers.HomeController(_flickInfoService.Object);
                _controller.ControllerContext = new FakeControllerContext(_controller, new SessionStateItemCollection());

                _list_of_unreleased_flicks = new List<Flick>
                                                 {
                                                     new Flick { Name = "Hitch", UserRating = 9.5M, Rating = "PG-13", ImdbId= "123", ThumbnailUrl = "http://hitch.com/poster.jpg" },
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                     new Flick(),
                                                 };

                _list_of_recent_flicks = new List<Flick>
                                             {
                                                 new Flick { Name = "Avatar", UserRating = 9.8M, Rating = "PG-13", ImdbId = "223", ThumbnailUrl = "http://avatar.com/poster.jpg" },
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                                 new Flick(),
                                             };

                _flickInfoService.Setup( x => x.GetRecentlyReleasedFlicks() ).Returns( _list_of_recent_flicks );

                _flickInfoService.Setup( x => x.GetUnreleasedFlicks() ).Returns( _list_of_unreleased_flicks );
            };

        static List<Flick> _list_of_recent_flicks;
        static List<Flick> _list_of_unreleased_flicks;
    }
}