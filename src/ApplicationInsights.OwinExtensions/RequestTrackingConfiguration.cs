﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Owin;

namespace ApplicationInsights.OwinExtensions
{
    public class RequestTrackingConfiguration
    {
        public TelemetryConfiguration TelemetryConfiguration { get; set; }

        public Func<IOwinContext, Task<bool>> ShouldTrackRequest { get; set; } = _ => Task.FromResult(true);

        public Func<IOwinContext, Exception, Task<bool>> ShouldTraceException { get; set; } 
            = DefaultFilters.ShouldTraceException;

        public Func<IOwinContext, Task<IEnumerable<KeyValuePair<string, string>>>> GetAdditionalContextProperties { get; set; }
            = _ => Task.FromResult(Enumerable.Empty<KeyValuePair<string, string>>());

        public Func<IOwinContext, string> RequestIdFactory { get; set; } = IdFactory.NewGuid;
    }
}
