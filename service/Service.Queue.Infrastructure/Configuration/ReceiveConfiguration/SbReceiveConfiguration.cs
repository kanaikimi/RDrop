﻿namespace RDrop.Service.Bus.Infrastructure.Configuration.ReceiveCnnfiguration
{

    using System;
    using System.Collections.Concurrent;
    using System.Reflection;

    public class SbReceiveConfiguration : SbReceiveConfigurationContext
    {

        internal Assembly HandlersAssembly { get; set; }
        internal ConcurrentBag<SbReceiveEndpointConfiguration> Endpoints { get; set; }

        internal SbReceiveConfiguration(SbConfiguration sbConfiguration, ServiceBus serviceBus)
            : base(sbConfiguration, serviceBus)
        {
        }

        public override SbReceiveEndpointConfiguration FromAmqpEndpoint(String amqpUri)
        {
            var endpointConfig = new SbReceiveEndpointConfiguration(amqpUri, this, this._serviceBusConfiguration, this._serviceBus);
            this.Endpoints.Add(endpointConfig);
            return endpointConfig;
        }

        public override SbReceiveConfiguration WithHandlersIn(Assembly assembly)
        {
            this.HandlersAssembly = assembly;
            return this;
        }

    }
}