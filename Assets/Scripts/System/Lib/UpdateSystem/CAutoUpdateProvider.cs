﻿using UnityEngine;
using CatLib.Container;
using CatLib.Base;
using CatLib.Contracts.UpdateSystem;
using CatLib.Contracts.Base;
using CapLib.Base;

namespace CatLib.UpdateSystem
{
    /// <summary>
    /// 自动更新服务提供商
    /// </summary>
    public class CAutoUpdateProvider : CServiceProvider
    {

        public CAutoUpdateProvider(IApplication app) : base(app)
        {
            app.Event.One(CApplication.Events.ON_INITED_CALLBACK, (sender, e) =>
            {

                app.Make<IAutoUpdate>().UpdateAsset();

            });
        }

        public override void Register()
        {
            application.Singleton<CAutoUpdate>().Alias<IAutoUpdate>();
        }

    }

}