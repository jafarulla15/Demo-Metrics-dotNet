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
,
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



