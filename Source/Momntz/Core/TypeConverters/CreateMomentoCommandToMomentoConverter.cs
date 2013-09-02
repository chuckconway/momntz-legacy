using AutoMapper;
using Momntz.Data.Repositories.Momentos.Parameters;
using Momntz.Data.Schema;


namespace Momntz.Core.TypeConverters
{
    public class CreateMomentoCommandToMomentoConverter : ITypeConverter<CreateMomentoParameters, Momento>
    {
        /// <summary>
        /// Converts the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Momento.</returns>
        public Momento Convert(ResolutionContext context)
        {
            var source = (CreateMomentoParameters)context.SourceValue;
            var momento = new Momento { User = new User { Username = source.Username } };

            return momento;
        }
    }
}
