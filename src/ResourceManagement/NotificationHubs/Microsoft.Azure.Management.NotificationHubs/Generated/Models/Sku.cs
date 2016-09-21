// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.NotificationHubs.Models
{
    using System.Linq;

    /// <summary>
    /// The Sku description for a namespace
    /// </summary>
    public partial class Sku
    {
        /// <summary>
        /// Initializes a new instance of the Sku class.
        /// </summary>
        public Sku() { }

        /// <summary>
        /// Initializes a new instance of the Sku class.
        /// </summary>
        /// <param name="name">Name of the notification hub sku. Possible
        /// values include: 'Free', 'free', 'Basic', 'basic', 'Standard',
        /// 'standard'</param>
        /// <param name="tier">The tier of particular sku</param>
        /// <param name="size">The Sku size</param>
        /// <param name="family">The Sku Family</param>
        /// <param name="capacity">The capacity of the resource</param>
        public Sku(string name, string tier = default(string), string size = default(string), string family = default(string), int? capacity = default(int?))
        {
            Name = name;
            Tier = tier;
            Size = size;
            Family = family;
            Capacity = capacity;
        }

        /// <summary>
        /// Gets or sets name of the notification hub sku. Possible values
        /// include: 'Free', 'free', 'Basic', 'basic', 'Standard', 'standard'
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tier of particular sku
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "tier")]
        public string Tier { get; set; }

        /// <summary>
        /// Gets or sets the Sku size
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "size")]
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the Sku Family
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "family")]
        public string Family { get; set; }

        /// <summary>
        /// Gets or sets the capacity of the resource
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "capacity")]
        public int? Capacity { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "Name");
            }
        }
    }
}
