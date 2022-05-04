using Framework.Promises;
using Framework.UI.MVP.Views.Core;
using Framework.UI.MVP.Views.Data;
using UnityEngine;

namespace Framework.UI.MVP.DI
{
    public interface IViewFactory
    {
        IPromise<TView> Create<TView>(IViewDefinition data, Transform parent = null) 
            where TView : ScreenBaseView;
    }
}