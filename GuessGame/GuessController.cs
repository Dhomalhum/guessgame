using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android;

namespace GuessGame
{
    public class GuessController
    {
        private List<Question> _guesses;
        private List<int> _used;
        private int _currentIdx;
        private int _correctAnswer;

        public Question Current { get { return _guesses[_currentIdx]; } }
        public int CorrectAnswers { get { return _correctAnswer; } }

        public GuessController()
        {
            _used = new List<int>();
            _currentIdx = 0;
            _correctAnswer = 0;
            Init();
        }

        public GuessController(List<int> used)
        {
            _used = used;
            Init();
        }

        private void Init()
        {
            _guesses = new List<Question>();
            _guesses.Add(new Question(Resource.Drawable.android, "android"));
            _guesses.Add(new Question(Resource.Drawable.apple, "apple"));
            _guesses.Add(new Question(Resource.Drawable.australia, "australia"));
            _guesses.Add(new Question(Resource.Drawable.iphone, "iphone"));
            _guesses.Add(new Question(Resource.Drawable.linux, "linux"));
            _guesses.Add(new Question(Resource.Drawable.samsung, "samsung"));
            _guesses.Add(new Question(Resource.Drawable.win7, "windows"));
            _guesses.Add(new Question(Resource.Drawable.xamarin, "xamarin"));
        }

        public void NewQuestion()
        {
            Random rnd = new Random();
            var idx = 0;

            //don't repeat pictures
            do
            {
                idx = rnd.Next(_guesses.Count);
            }
            while (_used.Contains(idx));

            _used.Add(idx);
            _currentIdx = idx;
        }        

        public List<int> GetUsed()
        {
            return _used;
        }

        public void Check(string answer)
        {
            if (Current.Check(answer))
                _correctAnswer++;
        }

        public int GetGuessCount()
        {
            return _used.Count;
        }
    }
}