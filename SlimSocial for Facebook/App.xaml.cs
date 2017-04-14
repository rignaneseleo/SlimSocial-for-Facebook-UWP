using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SlimSocial_for_Facebook
{
    sealed partial class App
    {
        public App()
        {
            InitializeComponent();

            UserAgentHelper.SetDefaultUserAgent("Mozilla/5.0 (BB10; Kbd) AppleWebKit/537.10+ (KHTML, like Gecko) Version/10.1.0.4633 Mobile Safari/537.10+");
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Non ripetere l'inizializzazione dell'applicazione se la finestra già dispone di contenuto,
            // assicurarsi solo che la finestra sia attiva
            if (rootFrame == null)
            {
                // Creare un frame che agisca da contesto di navigazione e passare alla prima pagina
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: caricare lo stato dall'applicazione sospesa in precedenza
                }

                // Posizionare il frame nella finestra corrente
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // Quando lo stack di esplorazione non viene ripristinato, passare alla prima pagina
                // e configurare la nuova pagina passando le informazioni richieste come parametro
                // parametro
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            // Assicurarsi che la finestra corrente sia attiva
            Window.Current.Activate();
        }

        private Frame CreateRootFrame()
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Non ripetere l'inizializzazione dell'app quando la schermata ha già un contenuto,
            // assicurarsi solo che la schermata sia aperta
            if (rootFrame == null)
            {
                // Creare un Frame per agire come contenuto di navigazione e navigare alla prima pagina
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                // Posizionare il Frame nella finestra corrente
                Window.Current.Content = rootFrame;
            }

            return rootFrame;
        }

        /// <summary>
        /// Chiamato quando la navigazione a una determinata pagina ha esito negativo
        /// </summary>
        /// <param name="sender">Frame la cui navigazione non è riuscita</param>
        /// <param name="e">Dettagli sull'errore di navigazione.</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }
    }
}