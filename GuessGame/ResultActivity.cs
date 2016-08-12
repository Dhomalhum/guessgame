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
    [Activity(Label = "Result")]
    public class ResultActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Result);
            var playBtn = FindViewById<Button>(Resource.Id.PlayAgainBtn);
            var scoreTxt = FindViewById<TextView>(Resource.Id.ScoreTxt);

            //get player name
            var contextPref = Application.Context.GetSharedPreferences
                  ("GuessGame", FileCreationMode.Private);
            var contextEdit = contextPref.Edit();
            var name = contextPref.GetString("name", "");

            //display score
            scoreTxt.Text = string.Format("{0}, your score is {1}/5", name, Intent.GetIntExtra("score", 0));

            playBtn.Click += (object sender, EventArgs e) =>
            {
                //play again
                Intent intent = new Intent( this, typeof(GuessActivity) );
                StartActivity(intent);
            };
        }
    }
}