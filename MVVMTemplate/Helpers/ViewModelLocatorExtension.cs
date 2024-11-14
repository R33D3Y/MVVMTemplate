using System.Windows.Markup;
using Microsoft.Extensions.DependencyInjection;

namespace MVVMTemplate.Helpers
{
    /// <summary>
    /// A markup extension that retrieves a specified ViewModel instance using the <see cref="ViewModelLocator"/>.
    /// Enables ViewModel resolution directly from XAML by specifying the <see cref="ViewModelType"/>.
    /// </summary>
    public class ViewModelLocatorExtension : MarkupExtension
    {
        /// <summary>
        /// Gets or sets the type of the ViewModel to be retrieved.
        /// </summary>
        public Type ViewModelType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelLocatorExtension"/> class.
        /// </summary>
        public ViewModelLocatorExtension()
        {
        }

        /// <summary>
        /// Provides the requested ViewModel instance based on the specified <see cref="ViewModelType"/>.
        /// </summary>
        /// <param name="serviceProvider">A service provider for resolving services.</param>
        /// <returns>The requested ViewModel instance.</returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown if <see cref="ViewModelType"/> is not set.
        /// </exception>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (ViewModelType == null)
            {
                throw new InvalidOperationException("ViewModelType must be set.");
            }

            // Call ViewModelLocator to get the ViewModel based on the provided ViewModelType
            var locator = App.ServiceProvider.GetRequiredService<ViewModelLocator>();
            return locator.GetRequiredViewModel(ViewModelType);
        }
    }
}