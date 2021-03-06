// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Rule condition of type network.
    /// </summary>
    public partial class NetworkRuleCondition : FirewallPolicyRuleCondition
    {
        /// <summary>
        /// Initializes a new instance of the NetworkRuleCondition class.
        /// </summary>
        public NetworkRuleCondition()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the NetworkRuleCondition class.
        /// </summary>
        /// <param name="name">Name of the rule condition.</param>
        /// <param name="description">Description of the rule
        /// condition.</param>
        /// <param name="ipProtocols">Array of
        /// FirewallPolicyRuleConditionNetworkProtocols.</param>
        /// <param name="sourceAddresses">List of source IP addresses for this
        /// rule.</param>
        /// <param name="destinationAddresses">List of destination IP addresses
        /// or Service Tags.</param>
        /// <param name="destinationPorts">List of destination ports.</param>
        public NetworkRuleCondition(string name = default(string), string description = default(string), IList<FirewallPolicyRuleConditionNetworkProtocol> ipProtocols = default(IList<FirewallPolicyRuleConditionNetworkProtocol>), IList<string> sourceAddresses = default(IList<string>), IList<string> destinationAddresses = default(IList<string>), IList<string> destinationPorts = default(IList<string>))
            : base(name, description)
        {
            IpProtocols = ipProtocols;
            SourceAddresses = sourceAddresses;
            DestinationAddresses = destinationAddresses;
            DestinationPorts = destinationPorts;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets array of FirewallPolicyRuleConditionNetworkProtocols.
        /// </summary>
        [JsonProperty(PropertyName = "ipProtocols")]
        public IList<FirewallPolicyRuleConditionNetworkProtocol> IpProtocols { get; set; }

        /// <summary>
        /// Gets or sets list of source IP addresses for this rule.
        /// </summary>
        [JsonProperty(PropertyName = "sourceAddresses")]
        public IList<string> SourceAddresses { get; set; }

        /// <summary>
        /// Gets or sets list of destination IP addresses or Service Tags.
        /// </summary>
        [JsonProperty(PropertyName = "destinationAddresses")]
        public IList<string> DestinationAddresses { get; set; }

        /// <summary>
        /// Gets or sets list of destination ports.
        /// </summary>
        [JsonProperty(PropertyName = "destinationPorts")]
        public IList<string> DestinationPorts { get; set; }

    }
}
