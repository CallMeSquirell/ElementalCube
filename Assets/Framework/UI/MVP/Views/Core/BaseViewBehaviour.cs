using Framework.ResourceManagement;
using Project.Scripts.Configs;
using UnityEngine;
using Zenject;

namespace Framework.UI.MVP.Views.Core
{
    public class BaseViewBehaviour : MonoBehaviour
    {
        private IAssetManager _assetManager;
        private IConfig _config;

        protected IAssetManager AssetManager => _assetManager;

        protected IConfig Config => _config;

        [Inject]
        private void Construct(IConfig config,
            IAssetManager assetManager)
        {
            _config = config;
            _assetManager = assetManager;
        }
    }
}