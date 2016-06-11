﻿using Ninject.Modules;
using WiseQueue.Core.Common.Caching;
using WiseQueue.Core.Common.Converters;
using WiseQueue.Core.Common.Converters.EntityModelConverters;
using WiseQueue.Core.Common.Management;
using WiseQueue.Domain.Common.Converters;
using WiseQueue.Domain.Common.Converters.EntityModelConverters;
using WiseQueue.Domain.Common.Management;
using WiseQueue.Domain.MicrosoftExpressionCache;

namespace WiseQueue.Domain.Common
{
    class CommonNinjectModule : NinjectModule
    {
        #region Overrides of NinjectModule

        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<ITaskConverter>().To<TaskConverter>();
            Bind<IQueueConverter>().To<QueueConverter>();
            
            //TODO: CachedExpressionCompiler in another assembly. I guess it shouldn't be here.
            Bind<ICachedExpressionCompiler>().To<CachedExpressionCompiler>();

            Bind<IExpressionConverter>().To<ExpressionConverter>();
            Bind<IJsonConverter>().To<JsonConverter>();

            Bind<IQueueManager>().To<QueueManager>().InSingletonScope();
            Bind<ITaskManager>().To<TaskManager>().InSingletonScope();
        }

        #endregion
    }
}
