using System;

namespace FlickTrap.Domain
{
    public class FlickService
    {
        readonly IFlickRepository _flickRepository;

        public FlickService(IFlickRepository flickRepository)
        {
            _flickRepository = flickRepository;
        }

        public Flick GetFlick(int id)
        {
            return _flickRepository.Get(id);
        }
    }
}