
using ClickHouseWithCSharp.Infrastructure;

namespace CS.Report.Grains.Data.Domains;

public class FleetEvent
{
    public Guid Id { get; set; }
    public long ParcelReferenceCode { get; set; }
    public double? LocationLatitude { get; set; }
    public double? LocationLongitude { get; set; }
    public bool IsOperationStaff { get; set; }
    public int? DeliveryCode { get; set; }
    public int? VendorId { get; set; }
    public int? StoreId { get; set; }
    public long? ShipmentId { get; set; }
    public long? ShipmentNumber { get; set; }
    public int FleetId { get; set; }
    public int? ShiftId { get; set; }
    public int? DistanceMeter { get; set; }
    public bool? IsComputable { get; set; }
    public int? DriverId { get; set; }
    public DateTime? RealDeliveryDateTime { get; set; }
    public DateTime? EstimatedDeliveryDateTime { get; set; }
    public bool? IsDeliveredOnTimeByDriver { get; set; }
    public CourierRequestTypes? CourierRequestType { get; set; }
    public string ExceptionDescription { get; set; }
    public long? ReturnParcelReferenceCode { get; set; }
    public byte? UnsuccessfulOperationReasonId { get; set; }
    public int? OnTimeActivity { get; set; }
    public int? DelayActivity { get; set; }
    public long? DispatchRequestId { get; set; }
    public long? ZapDispatchRequestId { get; set; }
    public byte? DeliveryServiceProviderId { get; set; }
    public bool? IsReassignmentRequested { get; set; }
    public string PartitionDate { get; set; }
    public DateTime CreateDate { get; set; }
    public FleetEventType FleetEventType { get; set; }
}
