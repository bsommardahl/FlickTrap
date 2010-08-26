using FlickTrap.Domain;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace FlickTrap.Web
{
    public class FlickOverride : IAutoMappingOverride<Flick>
    {
        public void Override(AutoMapping<Flick> mapping)
        {
            mapping.Map(x => x.Description).CustomSqlType("nvarchar(1000)");
        }
    }
}