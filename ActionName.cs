using System;
using System.Diagnostics;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

namespace Serilog
{
    public class ActionName : ILogEventEnricher
    {
        public const string ActionNamePropertyName = "ActionName";

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddPropertyIfAbsent(new LogEventProperty(ActionNamePropertyName, new ScalarValue(new StackTrace().GetFrame(13).GetMethod().Name)));
        }
    }
}
namespace Serilog.Enrichers
{
    public static class ActionNameExtension
    {
        /// <summary>
        /// How to use
        ///     .Enrich.WithActionName() and {ActionName}
        /// </summary>
        /// <param name="enrichmentConfiguration"></param>
        /// <returns></returns>
        public static LoggerConfiguration WithActionName(
            this LoggerEnrichmentConfiguration enrichmentConfiguration
        )
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<ActionName>();
        }
    }
}
