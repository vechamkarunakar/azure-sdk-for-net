// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.17.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.DataLake.Store.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class EncryptionIdentity
    {
        /// <summary>
        /// Initializes a new instance of the EncryptionIdentity class.
        /// </summary>
        public EncryptionIdentity() { }

        /// <summary>
        /// Initializes a new instance of the EncryptionIdentity class.
        /// </summary>
        /// <param name="type">The type of encryption being used. Currently
        /// the only supported type is 'SystemAssigned'. Possible values
        /// include: 'SystemAssigned'</param>
        /// <param name="principalId">The principal identifier associated with
        /// the encryption.</param>
        /// <param name="tenantId">The tenant identifier associated with the
        /// encryption.</param>
        public EncryptionIdentity(EncryptionIdentityType? type = default(EncryptionIdentityType?), Guid? principalId = default(Guid?), Guid? tenantId = default(Guid?))
        {
            Type = type;
            PrincipalId = principalId;
            TenantId = tenantId;
        }

        /// <summary>
        /// Gets or sets the type of encryption being used. Currently the only
        /// supported type is 'SystemAssigned'. Possible values include:
        /// 'SystemAssigned'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public EncryptionIdentityType? Type { get; set; }

        /// <summary>
        /// Gets the principal identifier associated with the encryption.
        /// </summary>
        [JsonProperty(PropertyName = "principalId")]
        public Guid? PrincipalId { get; private set; }

        /// <summary>
        /// Gets the tenant identifier associated with the encryption.
        /// </summary>
        [JsonProperty(PropertyName = "tenantId")]
        public Guid? TenantId { get; private set; }

    }
}
