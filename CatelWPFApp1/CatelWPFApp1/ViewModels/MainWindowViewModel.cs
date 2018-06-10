namespace CatelWPFApp1.ViewModels
{
    using Catel.Data;
    using Catel.IoC;
    using Catel.MVVM;
    using Catel.Services;
    using System.Threading.Tasks;

    public class MainWindowViewModel : ViewModelBase
    {
        private IMessageService messageService;

        public MainWindowViewModel()
        {
            var dependencyResolver = this.GetDependencyResolver();
            messageService = dependencyResolver.Resolve<IMessageService>();
            //await messageService.Show("My first message via the service");

            ClickMeCommand = new Command(OnClickMeCommandExecute);
        }

        public override string Title { get { return "CatelWPFApp1"; } }

        public string Hello
        {
            get { return GetValue<string>(HelloProperty); }
            set { SetValue(HelloProperty, value); }
        }

        public static readonly PropertyData HelloProperty = RegisterProperty(nameof(Hello), typeof(string), null);

        public Command ClickMeCommand { get; private set; }


        private void OnClickMeCommandExecute()
        {
            messageService.ShowAsync("My first message via the service");
        }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
