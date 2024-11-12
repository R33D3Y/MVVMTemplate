using System.ComponentModel;

namespace MVVMTemplate.NotifyPropertyChanged
{
    /// <summary>
    /// A base class that provides the implementation of the <see cref="INotifyPropertyChanged"/> interface.
    /// This allows derived classes to notify subscribers when a property value has changed.
    /// </summary>
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes in the class.
        /// This event is raised whenever a property in a derived class changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event to notify subscribers that a property has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            // Trigger the PropertyChanged event if there are any subscribers.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
