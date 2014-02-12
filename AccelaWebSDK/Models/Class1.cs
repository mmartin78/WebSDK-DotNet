using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
   
    public class RootObject // Record Filter
    {
        public Status status { get; set; }
        public string firstIssuedDate { get; set; }
        public string enforceOfficerId { get; set; }
        public string endAssignedDate { get; set; }
        public string enforceDepartment { get; set; }
        public string closedDate { get; set; }
        public string endOpenedDate { get; set; }
        public string inspectorName { get; set; }
        public string module { get; set; }
        public string estimatedDueDate { get; set; }
        public string assignedDate { get; set; }
        public double costPerUnit { get; set; }
        public string reportedDate { get; set; }
        public Owner owner { get; set; }
        public double actualProductionUnit { get; set; }
        public string appearanceDate { get; set; }
        public string id { get; set; }
        public string endClosedDate { get; set; }
        public string asLP { get; set; }
        public Severity severity { get; set; }
        public string scheduledDate { get; set; }
        public double totalJobCost { get; set; }
        public double estimatedProductionUnit { get; set; }
        public string completeDate { get; set; }
        public string name { get; set; }
        public Priority priority { get; set; }
        public double estimatedTotalJobCost { get; set; }
        public double estimatedCostPerUnit { get; set; }
        public int trackingId { get; set; }
        public string enforceOfficerName { get; set; }
        public string statusDate { get; set; }
        public string customId { get; set; }
        //public Asit asit { get; set; }
        public Type type { get; set; }
        public string openedDate { get; set; }
        public string recordClass { get; set; }
        public string assignedToStaff { get; set; }
        public string inspectorDepartment { get; set; }
        public int numberOfBuildings { get; set; }
        public string description { get; set; }
        public string closedByDepartment { get; set; }
        public double jobValue { get; set; }
        public double totalFee { get; set; }
        public ConstructionType constructionType { get; set; }
        public double totalPay { get; set; }
        public double inPossessionTime { get; set; }
        public StatusReason statusReason { get; set; }
        public string createdBy { get; set; }
        public Address address { get; set; }
        public string appearanceDayOfWeek { get; set; }
        //public Asi asi { get; set; }
        public string completedByDepartment { get; set; }
        public double undistributedCost { get; set; }
        public string endCompletedDate { get; set; }
        public string endReportedDate { get; set; }
        public string serviceProviderCode { get; set; }
        public string shortNotes { get; set; }
        public string assignedToDepartment { get; set; }
        public double overallApplicationTime { get; set; }
        public string asInspector { get; set; }
        public Contact contact { get; set; }
        public string closedByStaff { get; set; }
        public ReportedChannel reportedChannel { get; set; }
        public Professional professional { get; set; }
        public int housingUnits { get; set; }
        public double balance { get; set; }
        public string initiatedProduct { get; set; }
        public ReportedType reportedType { get; set; }
        public string inspectorId { get; set; }
    }
}
