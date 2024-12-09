using CS.Report.Grains.Data.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClickHouseWithCSharp.Model.MapConfig
{
    public class FleetEventMapper : IEntityTypeConfiguration<FleetEvent>
    {
        public void Configure(EntityTypeBuilder<FleetEvent> builder)
        {
            builder.ToTable(nameof(FleetEvent).ToLower());
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName(nameof(FleetEvent.Id).ToLower());

            builder.Property(x => x.DelayActivity).HasColumnName(nameof(FleetEvent.DelayActivity).ToLower());
            builder.Property(x => x.CourierRequestType).HasColumnName(nameof(FleetEvent.CourierRequestType).ToLower());
            builder.Property(x => x.DeliveryCode).HasColumnName(nameof(FleetEvent.DeliveryCode).ToLower());
            builder.Property(x => x.DeliveryServiceProviderId).HasColumnName(nameof(FleetEvent.DeliveryServiceProviderId).ToLower());
            builder.Property(x => x.DispatchRequestId).HasColumnName(nameof(FleetEvent.DispatchRequestId).ToLower());
            builder.Property(x => x.DistanceMeter).HasColumnName(nameof(FleetEvent.DistanceMeter).ToLower());
            builder.Property(x => x.DriverId).HasColumnName(nameof(FleetEvent.DriverId).ToLower());
            builder.Property(x => x.EstimatedDeliveryDateTime).HasColumnName(nameof(FleetEvent.EstimatedDeliveryDateTime).ToLower());
            builder.Property(x => x.ExceptionDescription).HasColumnName(nameof(FleetEvent.ExceptionDescription).ToLower());
            builder.Property(x => x.FleetEventType).HasColumnName(nameof(FleetEvent.FleetEventType).ToLower());
            builder.Property(x => x.FleetId).HasColumnName(nameof(FleetEvent.FleetId).ToLower());
            builder.Property(x => x.IsComputable).HasColumnName(nameof(FleetEvent.IsComputable).ToLower());
            builder.Property(x => x.IsDeliveredOnTimeByDriver).HasColumnName(nameof(FleetEvent.IsDeliveredOnTimeByDriver).ToLower());
            builder.Property(x => x.IsOperationStaff).HasColumnName(nameof(FleetEvent.IsOperationStaff).ToLower());
            builder.Property(x => x.IsReassignmentRequested).HasColumnName(nameof(FleetEvent.IsReassignmentRequested).ToLower());
            builder.Property(x => x.LocationLatitude).HasColumnName(nameof(FleetEvent.LocationLatitude).ToLower());
            builder.Property(x => x.LocationLongitude).HasColumnName(nameof(FleetEvent.LocationLongitude).ToLower());
            builder.Property(x => x.OnTimeActivity).HasColumnName(nameof(FleetEvent.OnTimeActivity).ToLower());
            builder.Property(x => x.ParcelReferenceCode).HasColumnName(nameof(FleetEvent.ParcelReferenceCode).ToLower());
            builder.Property(x => x.PartitionDate).HasColumnName(nameof(FleetEvent.PartitionDate).ToLower());
            builder.Property(x => x.RealDeliveryDateTime).HasColumnName(nameof(FleetEvent.RealDeliveryDateTime).ToLower());
            builder.Property(x => x.ReturnParcelReferenceCode).HasColumnName(nameof(FleetEvent.ReturnParcelReferenceCode).ToLower());
            builder.Property(x => x.ShiftId).HasColumnName(nameof(FleetEvent.ShiftId).ToLower());
            builder.Property(x => x.ShipmentId).HasColumnName(nameof(FleetEvent.ShipmentId).ToLower());
            builder.Property(x => x.ShipmentNumber).HasColumnName(nameof(FleetEvent.ShipmentNumber).ToLower());
            builder.Property(x => x.StoreId).HasColumnName(nameof(FleetEvent.StoreId).ToLower());
            builder.Property(x => x.UnsuccessfulOperationReasonId).HasColumnName(nameof(FleetEvent.UnsuccessfulOperationReasonId).ToLower());
            builder.Property(x => x.VendorId).HasColumnName(nameof(FleetEvent.VendorId).ToLower());
            builder.Property(x => x.ZapDispatchRequestId).HasColumnName(nameof(FleetEvent.ZapDispatchRequestId).ToLower());
            builder.Property(x => x.CreateDate).HasColumnName(nameof(FleetEvent.CreateDate).ToLower());
        }
    }
}
