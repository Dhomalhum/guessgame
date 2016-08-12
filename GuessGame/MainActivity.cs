using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

namespace GuessGame
{
    [Activity(Label = "Guess Game", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button startBtn = FindViewById<Button>(Resource.Id.StartBtn);
            var errorTxt = FindViewById<TextView>(Resource.Id.ErrorTxtVw);
            var nameTxt = FindViewById<EditText>(Resource.Id.PlayerNameTxt);

            startBtn.Click += (object sender, EventArgs e) => {
                if (string.IsNullOrEmpty(nameTxt.Text))
                {
                    errorTxt.Text = "Please enter player name";
                    errorTxt.SetTextColor(Color.Red);
                }
                else
                {
                    //save player name
                    //http://www.developer.com/ws/android/data-storage-using-xamarin.html
                    var contextPref = Application.Context.GetSharedPreferences
                          ("GuessGame", FileCreationMode.Private);
                    var contextEdit = contextPref.Edit();
                    contextEdit.PutString("name", nameTxt.Text);
                    contextEdit.Commit();

                    //start guess activity
                    Intent guess = new Intent(this, typeof(GuessActivity));

                    StartActivity(guess);
                }
            };
        }
    }
}