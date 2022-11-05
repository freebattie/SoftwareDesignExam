namespace Model.Base.Player
{
    public class User
    {
        private string? _name;
        private int _level;
        private int _topscore;

        public User()
        {
        }

        public User(string? name, int level, int topscore)
        {
            this._name = name;
            this._level = level;
            this._topscore = topscore;
        }

        public string? Name
        {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Level
        {
            get => _level;
            set => _level = value;
        }

        public int Topscore
        {
            get => _topscore;
            set => _topscore = value;
        }
        public int CurrentScore { get; internal set; }
    }
}
