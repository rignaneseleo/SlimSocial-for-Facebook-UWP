using System;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace SlimSocial_for_Facebook
{
    public sealed partial class SettingPage
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public SettingPage()
        {
            InitializeComponent();
            LoadSavedValue();

            PackageVersion number = Package.Current.Id.Version; // Get app version
            version.Text += string.Format(" {0}.{1}.{2}\r\n", number.Major, number.Minor, number.Build);

            SystemNavigationManager.GetForCurrentView().BackRequested += (s, a) => // add the back event
            {
                if (Frame.CanGoBack)
                {
                    Frame.GoBack();
                    a.Handled = true; // This block the app closing
                }
            };
        }

        private void LoadSavedValue()
        {
            if (localSettings.Values.ContainsKey("blockTopBar"))
                blockTopBar.IsOn = (bool)localSettings.Values["blockTopBar"];
            if (localSettings.Values.ContainsKey("showRecentNews"))
                showRecentNews.IsOn = (bool)localSettings.Values["showRecentNews"];
            if (localSettings.Values.ContainsKey("centerTextPosts"))
                centerTextPosts.IsOn = (bool)localSettings.Values["centerTextPosts"];
            if (localSettings.Values.ContainsKey("addSpaceBetweenPosts"))
                addSpaceBetweenPosts.IsOn = (bool)localSettings.Values["addSpaceBetweenPosts"];
            if (localSettings.Values.ContainsKey("darkTheme"))
                darkTheme.IsOn = (bool)localSettings.Values["darkTheme"];
        }

        private void SaveStatus_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ToggleSwitch thisToggle = ((ToggleSwitch)sender);
            bool isOn = thisToggle.IsOn;
            string toggleName = thisToggle.Name;

            if (!localSettings.Values.ContainsKey(toggleName))
                localSettings.Values.Add(toggleName, isOn); // add it
            else
                localSettings.Values[toggleName] = isOn; // edit it
        }

        private async void MichiBra_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var urlMichi = new Uri("https://www.linkedin.com/in/branchesimichele");
            await Windows.System.Launcher.LaunchUriAsync(urlMichi);
        }

        private async void LeoRigna_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var urlLeo = new Uri("https://github.com/rignaneseleo");
            await Windows.System.Launcher.LaunchUriAsync(urlLeo);
        }
    }
}