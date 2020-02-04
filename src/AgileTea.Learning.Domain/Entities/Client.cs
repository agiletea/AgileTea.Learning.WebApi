using System;

namespace AgileTea.Learning.Domain.Entities
{
    /// <summary>
    /// Client details
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Gets or sets the Id of a client
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the first name(s) of the client
        /// </summary>
        public string FirstNames { get; set; } = default!;

        /// <summary>
        /// Gets or sets the last name/ surname of the client
        /// </summary>
        public string LastName { get; set; } = default!;

        /// <summary>
        /// Gets or sets the title (Mr, Mrs, Ms etc.) of the client
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets the salutation of the client (i.e. how the client wishes to be addressed)
        /// </summary>
        public string? Salutation { get; set; }
    }
}
