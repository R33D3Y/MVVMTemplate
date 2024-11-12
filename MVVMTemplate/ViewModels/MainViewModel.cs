using MVVMTemplate.Commands;
using MVVMTemplate.Models;
using MVVMTemplate.NotifyPropertyChanged;
using System.Windows.Input;

namespace MVVMTemplate.ViewModels
{
    /// <summary>
    /// ViewModel for the main window that handles user interactions and manages data for the view.
    /// It provides a property <see cref="GreetingMessage"/> and a command <see cref="ButtonClickCommand"/>.
    /// </summary>
    public class MainViewModel : NotifyPropertyChangedBase
    {
        /// <summary>
        /// Gets or sets the person object associated with this view model.
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Gets a greeting message based on the person's name.
        /// This property uses the <see cref="Person.Name"/> to generate a personalized greeting.
        /// </summary>
        public string GreetingMessage => $"Hello, {Person.Name}!";

        /// <summary>
        /// Gets the command that is executed when a button is clicked.
        /// This command triggers the <see cref="ButtonClick"/> method.
        /// </summary>
        public ICommand ButtonClickCommand => new RelayCommand(ButtonClick);

        /// <summary>
        /// Method executed when the button is clicked. It notifies that the <see cref="GreetingMessage"/>
        /// property has changed, triggering UI updates.
        /// </summary>
        public void ButtonClick()
        {
            // Notify that GreetingMessage property has changed.
            OnPropertyChanged(nameof(GreetingMessage));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// The constructor sets up a default <see cref="Person"/> object with a name.
        /// </summary>
        public MainViewModel()
        {
            // Initialize the Person property with a default name.
            Person = new Person
            {
                Name = "John Doe"
            };
        }
    }
}
