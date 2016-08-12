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
    [Activity(Label = "Guess")]
    public class GuessActivity : Activity
    {
        private const int MAX = 5;
        private GuessGame.GuessController _controller;
        private TextView _characterTxtVw;
        private ImageView _imageVw;
        private EditText _answerTxt;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Guess);
            var submitBtn = FindViewById<Button>(Resource.Id.SubmitBtn);
            _characterTxtVw = FindViewById<TextView>(Resource.Id.CharacterTxtVw);
            _imageVw = FindViewById<ImageView>(Resource.Id.ImageVw);
            _answerTxt = FindViewById<EditText>(Resource.Id.AnswerTxt);
            _controller = new GuessGame.GuessController();

            //display new question
            InitQuestion();

            submitBtn.Click += (object sender, EventArgs e) =>
            {
                _controller.Check(_answerTxt.Text);
                //show result activity if the user has 5 guesses.
                if (_controller.GetGuessCount() == MAX)
                {
                    var intent = new Intent(this, typeof(ResultActivity));
                    intent.PutExtra("score", _controller.CorrectAnswers);
                    StartActivity(intent);
                }
                else
                {
                    //display another question.
                    InitQuestion();
                }
            };
        }

        private void InitQuestion()
        {
            //get new question and display hint and image
            _controller.NewQuestion();
            _characterTxtVw.Text = _controller.Current.Answer.Count() + " characters";
            _imageVw.SetImageResource(_controller.Current.Image);
            _answerTxt.Text = "";
        }
    }
}