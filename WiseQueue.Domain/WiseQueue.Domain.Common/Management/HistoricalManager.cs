﻿using System;
using Common.Core.Logging;
using WiseQueue.Core.Common.Management.Implementation;
using WiseQueue.Core.Server.Management;

namespace WiseQueue.Domain.Common.Management
{
    public class HistoricalManager : BaseManager, IHistoricalManager
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="loggerFactory">The <see cref="ICommonLoggerFactory"/> instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="loggerFactory"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentException">Value cannot be null or empty.</exception>
        public HistoricalManager(ICommonLoggerFactory loggerFactory) : base("HistoricalManager", loggerFactory)
        {
        }

        #region Implementation of IExecutable

        /// <summary>
        /// Occurs when object should do its action.
        /// </summary>
        public void Execute()
        {
            //TODO: Do some historical activities.
            throw new NotImplementedException();
        }

        #endregion
    }
}
