﻿using Chatham.Kit.ServiceDiscovery.Abstractions;
using Chatham.Kit.ServiceDiscovery.Cache.Internal;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Chatham.Kit.ServiceDiscovery.Cache.Tests
{
    public class CacheServiceSubscriberFixture
    {
        public IServiceSubscriber ServiceSubscriber { get; set; }
        public ICacheClient Cache { get; set; }

        public CacheServiceSubscriberFixture()
        {
            ServiceSubscriber = Substitute.For<IServiceSubscriber>();
            Cache = Substitute.For<ICacheClient>();
        }

        public IPollingServiceSubscriber CreateSut()
        {
            return new CacheServiceSubscriber(ServiceSubscriber, Cache);
        }
    }
}
