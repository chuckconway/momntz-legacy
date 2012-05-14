namespace Momntz.Data.ProjectionHandlers
{
    public interface IProjectionHandler<in TArgs, out TReturn>
    {
        /// <summary> Executes. </summary>
        /// <param name="args"> The arguments. </param>
        /// <returns> . </returns>
        TReturn Execute(TArgs args);
    }
}
