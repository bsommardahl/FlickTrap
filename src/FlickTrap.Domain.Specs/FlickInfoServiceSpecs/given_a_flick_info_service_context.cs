using FlickTrap.Domain.Abstract;
using Machine.Specifications;
using Moq;

namespace FlickTrap.Domain.Specs.FlickInfoServiceSpecs
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
}