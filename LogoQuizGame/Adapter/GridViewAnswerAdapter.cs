﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LogoQuizGame.Adapter
{
    class GridViewAnswerAdapter : BaseAdapter
    {
        private char[] answerCharacters;
        private Context context;
        private object v;
        private MainActivity mainActivity;

        public GridViewAnswerAdapter(char[] answerCharacters, Context context)
        {
            this.answerCharacters = answerCharacters;
            this.context = context;
        }

        public GridViewAnswerAdapter(object v, MainActivity mainActivity)
        {
            this.v = v;
            this.mainActivity = mainActivity;
        }

        public override int Count
        {
            get
            {
                return answerCharacters.Length;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return answerCharacters[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Button button;
            if(convertView == null)
            {
                button = new Button(context);
                button.LayoutParameters = new GridView.LayoutParams(85, 85);
                button.SetPadding(8, 8, 8, 8);
                button.SetBackgroundColor(Color.DarkGray);
                button.SetTextColor(Color.Yellow);
                button.Text = Convert.ToString(answerCharacters[position]);
            }
            else
            {
                button = (Button)convertView;
            }
            return button;
        }
    }
}