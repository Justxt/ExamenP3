using Newtonsoft.Json;
using RestSharp;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Storage;
using ExamenP3.Models;


namespace ExamenP3.ViewModels
{
    public class ChisteViewModel : INotifyPropertyChanged
    {
        private const string api = "https://api.chucknorris.io/jokes/random";
        private ObservableCollection<Chiste> chistess;
        private Chiste bromaselec;
        private SQLiteAsyncConnection database;

        public ObservableCollection<Chiste> chistes
        {
            get { return chistess; }
            set { chistess = value; OnPropertyChanged(nameof(chistes)); }
        }

        public Chiste broma
        {
            get { return bromaselec; }
            set { bromaselec = value; OnPropertyChanged(nameof(broma)); }
        }

        public ICommand FetchBroma { get; }
        public ICommand GuardarBroma { get; }

        public ChisteViewModel()
        {
            FetchBroma = new Command(async () => await FetchJoke());
            GuardarBroma = new Command(async () => await SaveJoke());
            chistes = new ObservableCollection<Chiste>();
            InitializeDatabase();
        }

        private async Task FetchJoke()
        {
            var client = new RestClient(api);
            var request = new RestRequest();
            request.Method = Method.Get;

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var joke = JsonConvert.DeserializeObject<Chiste>(response.Content);
                chistes.Add(joke);
            }
        }

        private async Task SaveJoke()
        {
            if (broma == null) return;

            await database.InsertAsync(broma);
        }

        private async void InitializeDatabase()
        {
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "jokes.db");
            database = new SQLiteAsyncConnection(databasePath);
            await database.CreateTableAsync<Chiste>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}