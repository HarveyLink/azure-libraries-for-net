// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// </auto-generated>

namespace Microsoft.Azure.Management.Network.Fluent.Models
{
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.ResourceManager.Fluent;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// VirtualWAN Resource.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class VirtualWANInner : Management.ResourceManager.Fluent.Resource
    {
        /// <summary>
        /// Initializes a new instance of the VirtualWANInner class.
        /// </summary>
        public VirtualWANInner()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the VirtualWANInner class.
        /// </summary>
        /// <param name="disableVpnEncryption">Vpn encryption to be disabled or
        /// not.</param>
        /// <param name="virtualHubs">List of VirtualHubs in the
        /// VirtualWAN.</param>
        /// <param name="vpnSites">List of VpnSites in the VirtualWAN.</param>
        /// <param name="allowBranchToBranchTraffic">True if branch to branch
        /// traffic is allowed.</param>
        /// <param name="allowVnetToVnetTraffic">True if Vnet to Vnet traffic
        /// is allowed.</param>
        /// <param name="office365LocalBreakoutCategory">The office local
        /// breakout category. Possible values include: 'Optimize',
        /// 'OptimizeAndAllow', 'All', 'None'</param>
        /// <param name="provisioningState">The provisioning state of the
        /// virtual WAN resource. Possible values include: 'Succeeded',
        /// 'Updating', 'Deleting', 'Failed'</param>
        /// <param name="virtualWANType">The type of the VirtualWAN.</param>
        /// <param name="etag">A unique read-only string that changes whenever
        /// the resource is updated.</param>
        public VirtualWANInner(string location = default(string), string id = default(string), string name = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), bool? disableVpnEncryption = default(bool?), IList<Management.ResourceManager.Fluent.SubResource> virtualHubs = default(IList<Management.ResourceManager.Fluent.SubResource>), IList<Management.ResourceManager.Fluent.SubResource> vpnSites = default(IList<Management.ResourceManager.Fluent.SubResource>), bool? allowBranchToBranchTraffic = default(bool?), bool? allowVnetToVnetTraffic = default(bool?), OfficeTrafficCategory office365LocalBreakoutCategory = default(OfficeTrafficCategory), ProvisioningState provisioningState = default(ProvisioningState), string virtualWANType = default(string), string etag = default(string))
            : base(location, id, name, type, tags)
        {
            DisableVpnEncryption = disableVpnEncryption;
            VirtualHubs = virtualHubs;
            VpnSites = vpnSites;
            AllowBranchToBranchTraffic = allowBranchToBranchTraffic;
            AllowVnetToVnetTraffic = allowVnetToVnetTraffic;
            Office365LocalBreakoutCategory = office365LocalBreakoutCategory;
            ProvisioningState = provisioningState;
            VirtualWANType = virtualWANType;
            Etag = etag;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets vpn encryption to be disabled or not.
        /// </summary>
        [JsonProperty(PropertyName = "properties.disableVpnEncryption")]
        public bool? DisableVpnEncryption { get; set; }

        /// <summary>
        /// Gets list of VirtualHubs in the VirtualWAN.
        /// </summary>
        [JsonProperty(PropertyName = "properties.virtualHubs")]
        public IList<Management.ResourceManager.Fluent.SubResource> VirtualHubs { get; private set; }

        /// <summary>
        /// Gets list of VpnSites in the VirtualWAN.
        /// </summary>
        [JsonProperty(PropertyName = "properties.vpnSites")]
        public IList<Management.ResourceManager.Fluent.SubResource> VpnSites { get; private set; }

        /// <summary>
        /// Gets or sets true if branch to branch traffic is allowed.
        /// </summary>
        [JsonProperty(PropertyName = "properties.allowBranchToBranchTraffic")]
        public bool? AllowBranchToBranchTraffic { get; set; }

        /// <summary>
        /// Gets or sets true if Vnet to Vnet traffic is allowed.
        /// </summary>
        [JsonProperty(PropertyName = "properties.allowVnetToVnetTraffic")]
        public bool? AllowVnetToVnetTraffic { get; set; }

        /// <summary>
        /// Gets or sets the office local breakout category. Possible values
        /// include: 'Optimize', 'OptimizeAndAllow', 'All', 'None'
        /// </summary>
        [JsonProperty(PropertyName = "properties.office365LocalBreakoutCategory")]
        public OfficeTrafficCategory Office365LocalBreakoutCategory { get; set; }

        /// <summary>
        /// Gets the provisioning state of the virtual WAN resource. Possible
        /// values include: 'Succeeded', 'Updating', 'Deleting', 'Failed'
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public ProvisioningState ProvisioningState { get; private set; }

        /// <summary>
        /// Gets or sets the type of the VirtualWAN.
        /// </summary>
        [JsonProperty(PropertyName = "properties.type")]
        public string VirtualWANType { get; set; }

        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated.
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
        }
    }
}
