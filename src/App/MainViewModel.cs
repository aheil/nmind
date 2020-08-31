namespace nMind
{
    public class MainViewModel
    {
        private string[] args;

        public MainViewModel(string[] args)
        {
            this.args = args;
        }

        MapViewModel _currentMapViewModel;

        public MapViewModel CurrentMap
        {
            get {
                if (_currentMapViewModel == null)
                    _currentMapViewModel = new MapViewModel();

                return _currentMapViewModel; 
            }
        }

    }
}