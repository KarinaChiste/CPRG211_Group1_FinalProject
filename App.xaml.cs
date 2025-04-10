namespace CPRG211_Group1_FinalProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "CPRG211_Group1_FinalProject" };
        }
    }
}
