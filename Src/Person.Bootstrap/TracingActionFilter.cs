using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using OpenTracing;
using Person.Application.Extensions;
using System;

namespace Person.Bootstrap
{
    public class TracingActionFilter : IActionFilter
    {
        private readonly ITracer _tracer;
        private readonly ILogger<TracingActionFilter> _logger;
        public TracingActionFilter(ITracer tracer, ILogger<TracingActionFilter> logger)
        {
            _tracer = tracer;
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var operationName = context.HttpContext.Request.Path.Value;
            var spanBuilder = _tracer.BuildSpan(operationName);
            var scope = spanBuilder.StartActive();
            _logger.LogInformation($"ReceiveMessage: {DateTime.UtcNow} | {operationName} SpanId:{scope.Span.Context.SpanId} TraceId:{scope.Span.Context.TraceId}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.Response.StatusCode.IsSuccess())
                _tracer.ActiveSpan?.Log("Request successful!");
            else
                _tracer.ActiveSpan?.Log("Request unsuccessful!");

            _tracer.ActiveSpan.SetTag("ResultData", Newtonsoft.Json.JsonConvert.SerializeObject(context.Result)).Finish();
        }
    }
}