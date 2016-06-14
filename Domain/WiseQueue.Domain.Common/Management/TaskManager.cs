﻿using System;
using System.Linq.Expressions;
using WiseQueue.Core.Common.Converters;
using WiseQueue.Core.Common.DataContexts;
using WiseQueue.Core.Common.Logging;
using WiseQueue.Core.Common.Management;
using WiseQueue.Core.Common.Models;
using WiseQueue.Core.Common.Models.Tasks;

namespace WiseQueue.Domain.Common.Management
{
    public class TaskManager: BaseLoggerObject, ITaskManager
    {
        /// <summary>
        /// The <see cref="IExpressionConverter"/> instance.
        /// </summary>
        private readonly IExpressionConverter expressionConverter;

        /// <summary>
        /// The <see cref="ITaskDataContext"/> instance.
        /// </summary>
        private readonly ITaskDataContext taskDataContext;

        /// <summary>
        /// The <see cref="IQueueManager"/> instance.
        /// </summary>
        private readonly IQueueManager queueManager;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="expressionConverter">The <see cref="IExpressionConverter"/> instance.</param>
        /// <param name="taskDataContext">The <see cref="ITaskDataContext"/> instance.</param>
        /// <param name="queueManager">The <see cref="IQueueManager"/> instance.</param>
        /// <param name="loggerFactory">The <see cref="IWiseQueueLoggerFactory"/> instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="expressionConverter"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="taskDataContext"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="queueManager"/> is <see langword="null" />.</exception>
        public TaskManager(IExpressionConverter expressionConverter, ITaskDataContext taskDataContext, IQueueManager queueManager, IWiseQueueLoggerFactory loggerFactory)
            : base(loggerFactory)
        {
            if (expressionConverter == null) 
                throw new ArgumentNullException("expressionConverter");
            if (taskDataContext == null)
                throw new ArgumentNullException("taskDataContext");
            if (queueManager == null)
                throw new ArgumentNullException("queueManager");

            this.expressionConverter = expressionConverter;
            this.taskDataContext = taskDataContext;
            this.queueManager = queueManager;
        }

        #region Implementation of ITaskManager

        /// <summary>
        /// StartTask a new <c>task</c>.
        /// </summary>
        /// <param name="task">The <c>task</c>.</param>
        /// <returns>The task's identifier.</returns>
        public Int64 StartTask(Expression<Action> task)
        {
            QueueModel defaultQueue = queueManager.GetDefaultQueue();

            TaskActivationDetailsModel taskActivationDetails = expressionConverter.Convert(task);
            TaskModel taskModel = new TaskModel(defaultQueue.Id, taskActivationDetails);

            Int64 taskId = taskDataContext.InsertTask(taskModel);
            return taskId;
        }

        #endregion
    }
}