# Demo-Metrics-dotNet

# observability

The Most Important Concept
You should remember this:

**Pillar	      Main Question**
Logs	         What happened?
Metrics	      How much/how often?
Traces	      Where did it happen?

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


