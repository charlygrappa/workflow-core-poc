using System;
namespace WorkFlowCore.Workflows.ManualWorkflow.Data
{
    public class Flight
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public bool Approved { get; set; }

        public Flight()
        {
        }
    }
}
