using Framework.Promises;
using Framework.ResourceManagement;
using Framework.UI.MVP.Views.Core;
using Framework.UI.MVP.Views.Data;
using UnityEngine;
using Zenject;

namespace Framework.UI.MVP.DI
{
    public class ViewFactory : IViewFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly IAssetManager _assetManager;

        public ViewFactory(IInstantiator instantiator,
            IAssetManager assetManager)
        {
            _instantiator = instantiator;
            _assetManager = assetManager;
        }

        public IPromise<TView> Create<TView>(IViewDefinition data, Transform parent)
            where TView : ScreenBaseView
        {
            var result = new Promise<TView>();
            _assetManager.LoadPrefabForComponent<ScreenBaseView>(data.ResourcePath)
                .Then(prefab =>
                    {
                        var view = _instantiator.InstantiatePrefabForComponent<TView>(prefab, parent);
                        result.Dispatch(view);
                    }
                )
                .Fail(result.Abort);
            return result;
        }
    }
}