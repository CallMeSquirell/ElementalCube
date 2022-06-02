using Framework.UI.MVP.Views.Core;

namespace Project.Scripts.GamePlay.UI.Settings
{
    public class SettingsPresenter : Presenter<SettingsView>
    {
        public SettingsPresenter(SettingsView view) : base(view)
        {
            
        }

        public override void Initialise()
        {
            View.CloseClicked += OnCloseClicked;
        }

        private void OnCloseClicked()
        {
            View.CloseView();
        }

        public override void Dispose()
        {
            View.CloseClicked -= OnCloseClicked;
        }
    }
}