namespace Histrio
{
    /// <summary>
    /// 
    /// </summary>
    public interface IObservable
    {
        /// <summary>
        /// Gets the handled by.
        /// </summary>
        /// <param name="observer">The observer.</param>
        void GetHandledBy(Observer observer);
    }
}