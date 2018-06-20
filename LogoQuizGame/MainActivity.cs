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

                if (result.Equals(correct_answer))
                {
                    Toast.MakeText(ApplicationContext, "Finish! This is " + result.ToUpper(), ToastLength.Short).Show();

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
                else
                    answer.MakeText(this, "Incorrect!!!", answerLength.Short).Show();
            };

        }

        private object SetupNullList()
        {
            char[] result = new char[answer.Length];
            return result;
        }

        private void SetupList()
        {
            Random random = new Random();
            int imageSelected = image_list[random.Next(image_list.Length)];
            imgLogo.SetImageResource(imageSelected);

            correct_answer = Resources.GetResourceName(imageSelected);
            correct_answer = correct_answer.Substring(correct_answer.LastIndexOf("/") + 1);

            answer = correct_answer.ToCharArray();

            Common.Common.user_submit_answer = new char[answer.Length];

            suggestSource.Clear();
            foreach (char item in answer)
                suggestSource.Add(Convert.ToString(item));

            for (int i=answer.Length; i<answer.Length*2; i++)
            {
                suggestSource.Add(Common.Common.alphabet_charaters[random.Next(Common.Common.alphabet_characters.Length));

                suggestSource = suggestSourceSource.OrderBy(x => Guid.NewGuid()).ToList();

                answerAdapter = new GridViewAnswerAdapter(SetupNullList(), this);
                suggestAdapter = new GridViewSuggestAdapter(suggestSource, this, this);

                answerAdapter.NotifyDataSetChanged();
                suggestAdapter.NotifyDataSetChanged();

                gvAnswer.Adapter = answerAdapter;
                gvSuggest.Adapter = suggestAdapter;
            }
        }
    }
}

