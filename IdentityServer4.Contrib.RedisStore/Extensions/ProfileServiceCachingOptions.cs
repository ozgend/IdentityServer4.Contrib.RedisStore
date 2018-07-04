﻿using System;
using System.Linq;
using IdentityServer4.Models;
using IdentityServer4.Services;

namespace IdentityServer4.Armut.RedisStore.Extensions
{
    ///<summary>
    /// Represents the Profile Service caching options.
    ///</summary>
    public class ProfileServiceCachingOptions<T>
        where T : class, IProfileService
    {
        ///<summary>
        /// Key selector for IsActiveContext, defaults select the Subject (sub) claim value.
        /// </summary>
        public Func<IsActiveContext, string> KeySelector { get; set; } = (context) => context.Subject.Claims.First(_ => _.Type == "sub").Value;

        ///<summary>
        /// Expiration of the cache entry of IsActiveContext, defaults to 10 minutes.
        /// </summary>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(10);

        private string _keyPrefix = string.Empty;

        /// <summary>
        /// The Prefix to add to each key stored on Redis Cache, default is Empty.
        /// </summary>
        public string KeyPrefix
        {
            get
            {
                return string.IsNullOrEmpty(_keyPrefix) ? _keyPrefix : $"{_keyPrefix}:";
            }
            set
            {
                _keyPrefix = value;
            }
        }
    }
}