using System;
using WorkflowCore.Interface;
using WorkFlowCore.Workflows.ManualWorkflow.Data;
using WorkFlowCore.Workflows.ManualWorkflow.Steps;

namespace WorkFlowCore.Workflows.ManualWorkflow
{
    public class ManualWorkflow : IWorkflow<Flight>
    {
        public ManualWorkflow()
        {
        }

        public string Id => "ManualWorkflow";

        public int Version => 1;

        public void Build(IWorkflowBuilder<Flight> builder)
        {
            builder.StartWith<Steps.InitializeFlight>()
                   .Output(data => data.Status, s => s.Status)
                   .Output(data => data.Approved, step => step.Approved)
                   .WaitFor("ApproveFlight", x => "1").Output(d => d.Name, x=> x.EventData)
                   .Then<ApproveFlight>().Input(data => data._flight, s => s);
                   //.Then<ApproveFlight>().Output(data => data.Approved, x => true).Output(data=> data.Status, x=> "APPROVED");


        }
    }
}
