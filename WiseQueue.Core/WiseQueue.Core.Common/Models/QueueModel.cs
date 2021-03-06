﻿using System;

namespace WiseQueue.Core.Common.Models
{
    /// <summary>
    /// Queue model.
    /// </summary>
    public class QueueModel
    {
        #region Properties...

        /// <summary>
        /// Queue's identifier.
        /// </summary>
        public Int64 Id { get; private set; }
        /// <summary>
        /// Queue's name.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Queue's description.
        /// </summary>
        public string Description { get; private set; }

        #endregion

        #region Constructors...

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Queue's <c>name</c>.</param>
        public QueueModel(string name): this(name, string.Empty)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Queue's <c>name</c>.</param>
        /// <param name="description">Queue's <c>description</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null" />.</exception>
        public QueueModel(string name, string description)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            Name = name;
            Description = description;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">Queue's identifier.</param>
        /// <param name="name">Queue's <c>name</c>.</param>
        public QueueModel(Int64 id, string name): this(id, name, string.Empty)
        {
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">Queue's identifier.</param>
        /// <param name="name">Queue's <c>name</c>.</param>
        /// <param name="description">Queue's <c>description</c>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The identifier should be great than 0.</exception>
        public QueueModel(Int64 id, string name, string description)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException("id", "The identifier should be great than 0.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name");

            Id = id;
            Name = name;
            Description = description;
        }

        #endregion

        #region Overrides of Object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return string.Format("Id: {0}; Name: {1}; Description: {2}", Id, Name, Description);
        }

        #endregion
    }
}
