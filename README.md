# app-insights-correlation

This repo is meant to demonstrate the automatic correlation of logs between two separate ASP.NET Core Web APIs which log to separate Application Insights instances.

It contains two very simple ASP.NET Core Web APIs, Api1 & Api2. The endpoint 'GET /api/values' on Api1 calls the same endpoint on Api2. Both APIs perform some custom logging.

The operation_Id in Application Insights is automatically preserved across the two Application Insights instances and so it's possible to execute a query that returns all relevant telemetry and logging for an operation:

```
union 
    requests, dependencies, traces, 
    app('AppInsightsApi2').requests, app('AppInsightsApi2').dependencies, app('AppInsightsApi2').traces 
| where operation_Id == '9804df6dcb4d3240a0ff8321face0533' 
| order by timestamp asc
```

The above query assumes it is executed in the Application Insights instance for Api1. It then references the Application Insights instance for Api2 using its resource name. This relies the resource name being unique among the resources you have access to. If this is not the case, more verbose methods of identifying the resource are available as can be seen [here](https://azure.microsoft.com/en-gb/blog/query-across-resources/).
