﻿using IDWallet.ViewModels;
using IDWallet.Views.BaseId.PopUps;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IDWallet.Views.DDL.Content
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DdlStartView : ContentView
    {
        public DdlStartView()
        {
            InitializeComponent();
            privacyClick.CommandParameter = WalletParams.DdlDataPrivacy;
            termsClick.CommandParameter = WalletParams.DdlTerms;
            privacyConsentClick.CommandParameter = WalletParams.DdlUsage;
            GoToNextButton.IsEnabled = false;
        }

        private Command<string> _linkTappedCommand;
        public Command LinkTappedCommand =>
            _linkTappedCommand ??= new Command<string>(LinkTapped);

        private async void LinkTapped(string url)
        {
            await Launcher.OpenAsync(new Uri(url));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ((DdlViewModel)BindingContext).GoToNext();
            PrivacyCheckbox.IsChecked = false;
            UserAgreementCheckbox.IsChecked = false;
        }

        private void CheckboxChecked(object sender, EventArgs e)
        {
            if (PrivacyCheckbox.IsChecked && UserAgreementCheckbox.IsChecked)
            {
                GoToNextButton.IsEnabled = true;
            }
            else
            {
                GoToNextButton.IsEnabled = false;
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!GoToNextButton.IsEnabled)
            {
                OuterScrollView.ScrollToAsync(InnerStack, ScrollToPosition.End, true);
            }
        }

        private async void Info1_Tapped(object sender, EventArgs e)
        {
            StartInfoPopUp1 popUp = new StartInfoPopUp1();
            await popUp.ShowPopUp();
        }

        private async void Info2_Tapped(object sender, EventArgs e)
        {
            StartInfoPopUp2 popUp = new StartInfoPopUp2();
            await popUp.ShowPopUp();
        }

        private async void Second_Button_Clicked(object sender, EventArgs e)
        {
            MissingInformationPopUp popUp = new MissingInformationPopUp();
            await popUp.ShowPopUp();
        }
    }
}