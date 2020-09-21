using nMind.Controls;

namespace nMind.ViewModels
{
    public delegate void AddCallback();

    public class MainViewModel
    {
        private string[] args;
        private AddControlCallback addControlCallback;

        public MainViewModel(string[] args, AddControlCallback handler)
        {
            this.args = args;
            this.addControlCallback = handler;
        }

        MapViewModel _currentMapViewModel;

        public MapViewModel CurrentMap
        {
            get {
                if (_currentMapViewModel == null)
                    _currentMapViewModel = new MapViewModel(this.addControlCallback);

                return _currentMapViewModel; 
            }

            set
            {
                _currentMapViewModel = value;
            }
        }

    }
}