using System;
using FlickTrap.Domain;
using FlickTrap.Domain.Abstract;
using FlickTrap.Web.Specs.MvcFakes;
using Machine.Specifications;
using Moq;

namespace FlickTrap.Web.Specs.FlickController
{
    public abstract class given_a_valid_flick_controller
    {
        protected static Mock<IFlickInfoService> _mockFlickInfoService;
        protected static Controllers.FlickController _controller;
        protected static Flick _valid_flick;

        Establish context = () =>
            {
                new RegisterAutoMaps().Execute();

                _valid_flick = new Flick
                                   {
                                       Name = "Avatar",
                                       Description = "Avatar Description",
                                       UserRating = 9.8M,
                                       Rating = "PG-13",
                                       ThumbnailUrl = "http://avatar.com/poster.jpg",
                                       RentalReleaseDate = new DateTime(2010, 5, 1),
                                       TheaterReleaseDate = new DateTime(2009, 11, 1),
                                       Revenue = 1000M,
                                       Budget = 500M,
                                       RemoteId = "123"
                                   };

                _mockFlickInfoService = new Mock<IFlickInfoService>();
                _mockFlickInfoService.Setup(x => x.GetFlick("username", "123")).Returns(_valid_flick);

                _controller = new Controllers.FlickController(_mockFlickInfoService.Object);
                _controller.ControllerContext = new FakeControllerContext(_controller, "username");
            };
    }
}