using ExamenP3.Views;

namespace ExamenP3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ChisteView();
        }
    }
}
