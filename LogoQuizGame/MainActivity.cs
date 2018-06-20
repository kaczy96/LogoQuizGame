using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using System.Collections.Generic;

namespace LogoQuizGame
{
    [Activity(Label = "LogoQuizGame", MainLauncher = true, Icon = "@drawable/icon",Theme="@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        public List<string> suggestSource = new List<string>();

        public GridViewAnswerAdapter answerAdapter;
        public GridViewSuggestAdapter suggestAdapter;

        public Button btnSubmit;

        public GridView gvAnswer, gvSuggest;

        public ImageView imgLogo;

        int[] image_list =
        {
            Resource.Drawable.facebook,
            Resource.Drawable.instagram,
            Resource.Drawable.whatsapp,
            Resource.Drawable.youtube

        };

        public char[] answer;
        string correct_answer;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            InitViews();
        }

        private void InitViews()
        {
            gvAnswer = FindViewById<GridView>(Resource.Id.gvAnswer);
            gvSuggest = FindViewById<GridView>(Resource.Id.gvSuggest);

            imgLogo = FindViewById<ImageView>(Resource.Id.imgLogo);

            SetupList();

            btnSubmit = FindViewById<Button>(Resource.Id.btnSubmit);
            btnSubmit.Click += delegate
            {
                string result = new string(Common.Common.user_submit_answer);

                if(result.Equals(correct_answer))
                {
                    Toast.MakeText(ApplicationContext, "Finish! This is "+result.ToUpper(),ToastLength.Short).Show();

                    //Reset
                    Common.Common.user_submit_answer = new char[correct_answer.Length];

                    //Update UI
                    GridViewAnswerAdapter answerAdapter = new GridViewAnswerAdapter(SetupNullList(), this);
                    gvAnswer.Adapter = answerAdapter;
                    answerAdapter.NotifyDataSetChanged();

                    GridViewAnswerAdapter suggestAdapter = new GridViewSuggestAdapter(suggestSource, this, this);
                    gvSuggest.Adapter = suggestAdapter;
                    suggestAdapter.NotifyDataSetChanged();

                    SetupList();
                }
            }

        }

        private object SetupNullList()
        {
            throw new NotImplementedException();
        }
    }
}

