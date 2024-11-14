using Microsoft.Extensions.DependencyInjection;

namespace MVVMTemplate.Helpers
{
    /// <summary>
    /// Provides a mechanism for locating and retrieving ViewModel instances.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Retrieves an instance of the specified ViewModel type from the application's service provider.
        /// </summary>
        /// <param name="viewModelType">The type of the ViewModel to retrieve.</param>
        /// <returns>An instance of the requested ViewModel.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the specified ViewModel type cannot be resolved by the service provider.
        /// </exception>
        public object GetRequiredViewModel(Type viewModelType)
        {
            return App.ServiceProvider.GetRequiredService(viewModelType);
        }
    }
}