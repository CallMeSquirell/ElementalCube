using Framework.UI.MVP.Views.PopUp;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.GamePlay.UI.Settings
{
    public class SettingsView : PopUpView
    {
        [SerializeField] private Button _toggler;
        [SerializeField] private Image _on;
        [SerializeField] private Image _off;
        
        private AudioSource _soruce;

        protected override void Awake()
        {
            base.Awake();
            _soruce = FindObjectOfType<AudioSource>();
            _toggler.onClick.AddListener(OnChanged);
            UpdateView();
        }

        private void OnChanged()
        {
            var value = _soruce.mute;
            _soruce.mute = !value;
            UpdateView();
        }

        private void UpdateView()
        {
            _on.gameObject.SetActive(!_soruce.mute);
            _off.gameObject.SetActive(_soruce.mute);
        }
    }
}