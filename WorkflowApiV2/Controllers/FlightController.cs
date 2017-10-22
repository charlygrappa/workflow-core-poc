using System;
using Microsoft.AspNetCore.Mvc;
using WorkflowCore.Interface;
using WorkFlowCore.Workflows.ManualWorkflow.Data;

namespace WorkflowApiV2.Controllers
{
    [Route("api/[controller]")]
    public class FlightController
    {
      
        private static int id = 0;
        public FlightController()
        {
        }

        [HttpGet("{id}")]
        public IActionResult GetStatus(String id){
            var wf = WorkflowSingleton.WorkflowHost.PersistenceStore.GetWorkflowInstance(id);
            return new ObjectResult(wf.Result.Data);
        }

        [HttpPost]
        public IActionResult Start(){
            id++;
            var wf = WorkflowSingleton.WorkflowHost.StartWorkflow<Flight>("ManualWorkflow", new Flight() { Name = "Vuelo - " + id });
            return new ObjectResult(wf.Result);

        }

        [HttpPut("{id}")]
        public IActionResult Update(){
            WorkflowSingleton.WorkflowHost.PublishEvent("ApproveFlight","1","Hola Tarolas");
            return new ObjectResult("ok");

        }
    }
}
