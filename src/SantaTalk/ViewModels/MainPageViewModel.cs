﻿using System;
using System.ComponentModel;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Forms;

namespace SantaTalk
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            SendLetterCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new ResultsPage(KidsName, LetterText));
            }, () =>
            {
                // Avoid blank result by blank letter.
                return !string.IsNullOrWhiteSpace(LetterText);
            });

            PropertyChanged += (object sender, PropertyChangedEventArgs e) => (SendLetterCommand as Command).ChangeCanExecute();
        }

        string kidsName;
        public string KidsName
        {
            get => kidsName;
            set => SetProperty(ref kidsName, value);
        }

        string letterText = "Dear Santa...";
        public string LetterText
        {
            get => letterText;
            set => SetProperty(ref letterText, value);
        }

        public ICommand SendLetterCommand { get; }
    }
}
