namespace NoughtsAndCrosses
{
    public class User
    {
        public User(char _myletter, bool _ismygo, int _roundswon = 0)
        {
            MyLetter = MyLetter;
            IsMyGo = _ismygo;
            RoundsWon = _roundswon;
        }

        public bool IsMyGo { get; set; }

        public char MyLetter { get; set; }

        public int RoundsWon { get; set; }

        public void NextGo()
        {
            if (IsMyGo == false)
            {
                IsMyGo = true;
            }
            else
            {
                IsMyGo = false;
            }
        }
    }
}