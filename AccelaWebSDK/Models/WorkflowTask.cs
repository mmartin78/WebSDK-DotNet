using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class ActionbyDepartment
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class AssignedUser
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class ActionbyUser
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class AssignedToDepartment
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class WorkflowTask
    {
        public string comment { get; set; }
        public Status status { get; set; }
        public string assignEmailDisplay { get; set; }
        public string nextTaskId { get; set; }
        public string processCode { get; set; }
        public string estimatedDueDate { get; set; }
        public string dueDate { get; set; }
        public string currentTaskId { get; set; }
        public RecordId recordId { get; set; }
        public ActionbyDepartment actionbyDepartment { get; set; }
        public string id { get; set; }
        public string trackStartDate { get; set; }
        public string billable { get; set; }
        public string statusDate { get; set; }
        public double estimatedHours { get; set; }
        public string isCompleted { get; set; }
        public string description { get; set; }
        public double inPossessionTime { get; set; }
        public string overTime { get; set; }
        public List<string> commentPublicVisible { get; set; }
        public string startTime { get; set; }
        public string assignedDate { get; set; }
        public string approval { get; set; }
        public string isActive { get; set; }
        public string dispositionNote { get; set; }
        public AssignedUser assignedUser { get; set; }
        public string serviceProviderCode { get; set; }
        public string commentDisplay { get; set; }
        public ActionbyUser actionbyUser { get; set; }
        public AssignedToDepartment assignedToDepartment { get; set; }
        public double hoursSpent { get; set; }
        public int daysDue { get; set; }
        public string endTime { get; set; }
    }

    public class UpdateWorkflowTaskRequest
    {
        public string commentDisplay { get; set; }
        public List<string> commentPublicVisible { get; set; }
        public Status status { get; set; }
        public string comment { get; set; }
        public double hoursSpent { get; set; }
        public string billable { get; set; }
        public string overTime { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string assignEmailDisplay { get; set; }
        public string dueDate { get; set; }
        public string statusDate { get; set; }
        public ActionbyUser actionbyUser { get; set; }
        public ActionbyDepartment actionbyDepartment { get; set; }
    }
}
