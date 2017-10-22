using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;
using WorkFlowCore.Workflows.ManualWorkflow.Data;

namespace WorkFlowCore.Workflows.ManualWorkflow.Steps
{
    public class ApproveFlight : StepBody
    {
        public Flight _flight { get; set; }
        public String _message { get; set; }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Approving Flight");
            _flight.Name += (" " + _message);
            _flight.Approved = true;
            _flight.Status = "APPROVED";

            return ExecutionResult.Next();
        }
    }
}
