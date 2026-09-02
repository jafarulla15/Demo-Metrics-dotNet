# Demo-Metrics-dotNet

# observability

The Most Important Concept
You should remember this:
```
**Pillar	      Main Question**
Logs	         What happened?
Metrics	      How much/how often?
Traces	      Where did it happen?
```
**Together:**
```
              OBSERVABILITY
                   │
       ┌───────────┼───────────┐
       │           │           │
      Logs       Metrics     Traces
       │           │           │
    What?       How much?    Where?
  ```  

**Metrics — How much / how often?**

Metrics are numerical measurements.

For example:
```
HTTP Requests       = 50,000
Errors              = 120
CPU                  = 75%
Memory               = 2 GB
Request duration     = 250 ms
Database connections = 30
```
Your application can expose metrics such as:
```
http.server.request.duration
http.server.request.count
orders.created
orders.failed
```
Metrics answer:
```
How is my application performing?
```
Common tools:

**Prometheus → Grafana**
```
.NET API
   ↓
OpenTelemetry
   ↓
Prometheus
   ↓
Grafana
```

Think of OpenTelemetry as the standard instrumentation/collection layer.

```
                 .NET API
                    │
             OpenTelemetry
                    │
        ┌───────────┼───────────┐
        │           │           │
       Logs       Metrics      Traces
        │           │           │
        ▼           ▼           ▼
      Loki      Prometheus     Tempo
        │           │           │
        └───────────┼───────────┘
                    ▼
                 Grafana
```
**What is Prometheus?**

```
.NET API
   │
   │ metrics
   ▼
Prometheus
   │
   │ query
   ▼
Grafana
```

**What is Loki?**

Loki is a log aggregation system.

```
.NET API
   │
   │ logs
   ▼
   Loki
   │
   ▼
Grafana
```

**What is Tempo?**

Tempo is used for distributed tracing.

```
.NET API
   │
   │ traces
   ▼
Tempo
   │
   ▼
Grafana
```

**Then What is Alerting?**

Observability isn't only about looking at dashboards.

```
Metric
  │
  ▼
Prometheus
  │
  ▼
Alert Rule
  │
  ├── Error rate > 5%
  │
  ▼
Alertmanager
  │
  ├── Slack
  ├── Email
  └── PagerDuty
```

**The Complete Mental Model**

Remember this flow:

```
                    APPLICATION
                         │
                         ▼
                 INSTRUMENTATION
                         │
                  OpenTelemetry
                         │
          ┌──────────────┼──────────────┐
          │              │              │
          ▼              ▼              ▼
        LOGS          METRICS         TRACES
          │              │              │
          ▼              ▼              ▼
        Loki         Prometheus       Tempo
          │              │              │
          └──────────────┼──────────────┘
                         ▼
                      Grafana
                         │
              ┌──────────┴──────────┐
              ▼                     ▼
          Dashboard              Alerts
                                    │
                          Slack / Email / etc.
```
======================================
# Metrics
======================================


List of complete .NET 8 Web API that can exposes:
```
ASP.NET Core HTTP metrics
.NET runtime metrics
Process metrics
HTTP client metrics
Custom application metrics
Database/SQL metrics
Prometheus export
Prometheus scraping
Grafana visualization later
```
Needed Packages:
```
dotnet add package OpenTelemetry.Extensions.Hosting
dotnet add package OpenTelemetry.Exporter.Prometheus.AspNetCore
dotnet add package OpenTelemetry.Instrumentation.AspNetCore
dotnet add package OpenTelemetry.Instrumentation.Http
dotnet add package OpenTelemetry.Instrumentation.Runtime
dotnet add package OpenTelemetry.Instrumentation.Process
dotnet add package OpenTelemetry.Instrumentation.SqlClient
```

**The metrics we will collect:**
```
OpenTelemetry Metrics
│
├── 1. ASP.NET Core
│     ├── Request count
│     ├── Request duration
│     ├── HTTP status
│     ├── HTTP method
│     └── Route
│
├── 2. .NET Runtime
│     ├── GC
│     ├── Heap
│     ├── Thread pool
│     ├── Exceptions
│     ├── JIT
│     └── Timers
│
├── 3. Process
│     ├── CPU
│     ├── Memory
│     └── Process information
│
├── 4. HTTP Client
│     ├── Outgoing requests
│     ├── Duration
│     ├── Status
│     └── Request count
│
├── 5. Database
│     ├── DB calls
│     ├── Duration
│     └── DB connection metrics
│
└── 6. Application
      ├── Orders created
      ├── Orders failed
      ├── Payments
      └── Business metrics
```


      


