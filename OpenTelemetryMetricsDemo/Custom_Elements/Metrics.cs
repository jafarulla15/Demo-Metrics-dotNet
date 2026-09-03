using System.Diagnostics.Metrics;


namespace OpenTelemetryMetricsDemo.Custom_Elements
{
    // ==================================================
    // Custom Metrics
    // ==================================================

    public static class Metrics
    {
        private static readonly Meter Meter =
            new("OpenTelemetryMetricsDemo", "1.0.0");

        public static readonly Counter<long> OrdersCreated =
            Meter.CreateCounter<long>(
                "orders.created",
                description: "Number of orders created");

        public static readonly Counter<long> OrdersFailed =
            Meter.CreateCounter<long>(
                "orders.failed",
                description: "Number of failed orders");

        public static readonly Histogram<double> OrderProcessingTime =
            Meter.CreateHistogram<double>(
                "orders.processing.duration",
                unit: "ms",
                description: "Order processing duration");
    }
}
