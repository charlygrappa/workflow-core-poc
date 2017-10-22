using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkFlowCore.Workflows.ManualWorkflow.Data;

namespace WorkFlowCore.Workflows.ManualWorkflow.Steps
{
    public class InitializeFlight : StepBody
    {
        public string Status { get; set; }
        public bool Approved { get; set; }

        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Initializing Flight");
            Status = "PENDING";
            Approved = false;
            return ExecutionResult.Next();
        }
    }
}
