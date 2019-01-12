using System;
using Microsoft.AspNetCore.Http;

namespace DB.Entity
{
    /// <summary>
    /// Represents a web helper
    /// </summary>
    public partial interface IWebHelper
    {
       

        /// <summary>
        /// Get IP address from HTTP context
        /// </summary>
        /// <returns>String of IP address</returns>
        string GetCurrentIpAddress();

    

        DateTime CurrentDateUtc { get; }
        string CurrentUser { get; }
    }
}
