using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamenP3.ViewModels
{
    internal class PersonajeViewModel
    {
        public string MoreInfoUrl => "https://github.com/Justxt";
        public string Message => "A mi, Justin Mateo Mora Caizapasto, me gusta este insano porque es chevere, cool y tiene full poder 😎.";
        public ICommand JMShowMoreInfoCommand { get; }

        public PersonajeViewModel()
        {
            JMShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);
        }

        async Task ShowMoreInfo() =>
            await Launcher.Default.OpenAsync(MoreInfoUrl);
    }
}
