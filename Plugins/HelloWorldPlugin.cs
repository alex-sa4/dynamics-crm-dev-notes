// Required libraries from Dynamics SDK
using System;
using Microsoft.Xrm.Sdk;

namespace CRMPlugins // You can name this whatever you like
{
    // This is the class that will run when the plugin is triggered
    public class HelloWorldPlugin : IPlugin
    {
        // Dynamics will call this method automatically
        public void Execute(IServiceProvider serviceProvider)
        {
            // 1️⃣ Tracing service lets you write debug messages you can view in logs
            ITracingService tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            // 2️⃣ This gives you info about what triggered the plugin (like what record, what message, etc.)
            IPluginExecutionContext context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            // 3️⃣ Write something in the plugin trace log
            tracingService.Trace("HelloWorldPlugin executed.");

            // 4️⃣ Check if the thing being worked on is an Account entity
            if (context.InputParameters.Contains("Target") &&
                context.InputParameters["Target"] is Entity entity &&
                entity.LogicalName == "account")
            {
                tracingService.Trace("Account record triggered the plugin.");
            }
        }
    }
}
