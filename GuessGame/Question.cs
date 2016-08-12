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

namespace GuessGame
{
    public class Question
    {
        public int Image { get; set; }
        public string Answer { get; set; }

        public Question(int img, string answer)
        {
            Image = img;
            Answer = answer;
        }

        public bool Check(string guess)
        {
            return Answer.Equals(guess.Trim().ToLower());
        }
    }
}