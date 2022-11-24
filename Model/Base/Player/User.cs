namespace Model.Base.Player
{
    /// <summary>
    /// used to store and read data from database on the user level and score
    /// </summary>
    public class User
    {
        #region private filds
        private string _name ="";
        private int _level;
        private int _topscore;
        private int _currentscore;
        #endregion

        #region props
        public string Name {
            get => _name;
            set => _name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Level {
            get => _level;
            set => _level = value;
        }

        public int Topscore {
            get => _topscore;
            set => _topscore = value;
        }

        public int CurrentScore {
            get => _currentscore;
            set => _currentscore = value;
        }
        #endregion

        #region constructor
        public User()
        {
        }

        public User(string name, int level, int topscore, int currentscore)
        {
            this._name = name;
            this._level = level;
            this._topscore = topscore;
            this._currentscore = currentscore;
        }
        #endregion

    }
}