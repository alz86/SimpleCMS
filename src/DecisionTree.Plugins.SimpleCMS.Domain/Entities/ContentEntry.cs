using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace DecisionTree.Plugins.SimpleCMS.Entities
{
    /// <summary>
    /// Entity representing an entry
    /// in the CMS system.
    /// </summary>
    public class ContentEntry : AuditedAggregateRoot<Guid>
    {
        public ContentEntry()
        {
        }

        public ContentEntry(Guid id) : base(id)
        {
        }

        /// <summary>
        /// Gets or sets the name of the entry, 
        /// meant to act as internal reference for
        /// the users.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the title of the entry, 
        /// which acts as the display text for the entry.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the HTML content of 
        /// the entry.
        /// </summary>
        public string Content { get; set; } = string.Empty;
    }
}
