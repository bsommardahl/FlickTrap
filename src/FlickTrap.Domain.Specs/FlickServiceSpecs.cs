using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;

namespace FlickTrap.Domain.Specs
{
    namespace FlickServiceSpecs
    {
        [Subject(typeof (FlickService))]
        public class when_a_flick_is_requested_by_id
        {
            Establish context;

            Because of;

            It should_return_a_flick;
        }

    }
}