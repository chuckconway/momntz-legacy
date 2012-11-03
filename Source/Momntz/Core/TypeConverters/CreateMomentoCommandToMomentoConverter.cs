using AutoMapper;
using Momntz.Data.Commands.Momentos;
using Momntz.Model;

namespace Momntz.Core.TypeConverters
{
    public class CreateMomentoCommandToMomentoConverter : ITypeConverter<CreateMomentoCommand, Momento>
    {
        public Momento Convert(ResolutionContext context)
        {
            var source = (CreateMomentoCommand) context.SourceValue;
            var momento = new Momento {Username = source.Username};

            return momento;
        }
    }
}
