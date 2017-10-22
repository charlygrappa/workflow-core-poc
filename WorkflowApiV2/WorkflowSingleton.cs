using System;
using WorkflowCore.Interface;

namespace WorkflowApiV2
{
    public static class WorkflowSingleton
    {
        public static IWorkflowHost WorkflowHost { get; set; }  
    }
}
