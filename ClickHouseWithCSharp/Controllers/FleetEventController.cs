﻿using ClickHouseWithCSharp.Dto;
using ClickHouseWithCSharp.Infrastructure;
using CS.Report.Grains.Data.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClickHouseWithCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FleetEventController : ControllerBase
    {
        private readonly AppDbContext clickHouseDbContext;

        public FleetEventController(AppDbContext clickHouseDbContext)
        {
            this.clickHouseDbContext = clickHouseDbContext;
        }

        [HttpGet("GetClickHouseData")]
        public async Task<IActionResult> GetClickHouseData()
        {
            var data = await clickHouseDbContext.FleetEvents.Where(x => x.FleetId == 5).ToListAsync();
            return Ok(data);
        }


        [HttpGet("GetFleetEventMetricCountDto")]
        public async Task<IActionResult> GetFleetEventMetricCountDto()
        {
            List<int> fleetIds = new List<int>
            {
                6161
            };

            var startDate = new DateTime(2024, 12, 10, 08, 00, 00);
            var endDate = new DateTime(2024, 12, 10, 14, 00, 00);

            var fleetMetricsCount = await GetFleetMetricsCount(fleetIds, startDate, endDate);
            
            return Ok(fleetMetricsCount);
        }

        private async Task<IActionResult> GetFleetMetricsCount(IEnumerable<int> fleetIds, DateTime from, DateTime to, FleetEventType? fleetEventType = null)
        {
            var days = new List<string>();

            for (var i = 0; i <= to.Subtract(from).Days; i++)
            {
                days.Add(from.AddDays(i).ToString("yyyyMMdd"));
            }

            Expression<Func<FleetEvent, bool>> predicate = x =>
                            fleetIds.Contains(x.FleetId) &&
                            days.Contains(x.PartitionDate) &&
                            x.CreateDate >= from && x.CreateDate <= to;

            if (fleetEventType != null)
            {
                // Create the new condition expression
                var parameter = predicate.Parameters[0]; // Reuse the parameter from the existing predicate
                var fleetEventTypeCondition = Expression.Equal(
                    Expression.PropertyOrField(parameter, nameof(FleetEvent.FleetEventType)),
                    Expression.Constant(fleetEventType)
                );

                // Combine the existing predicate with the new condition
                var combinedBody = Expression.AndAlso(predicate.Body, fleetEventTypeCondition);

                // Create a new lambda with the combined body and original parameters
                predicate = Expression.Lambda<Func<FleetEvent, bool>>(combinedBody, parameter);
            }

            var fleetEvents = await clickHouseDbContext.FleetEvents
                .Where(predicate)
                .ToListAsync();

            var fleetEventsQuery = clickHouseDbContext.FleetEvents
                .Where(predicate).ToQueryString();

            var fleetEventMetric = fleetEvents
                .GroupBy(fleetGroup => fleetGroup.FleetId)
                .Select(x => new FleetEventMetricDto
                {
                    FleetId = x.Key,
                    FleetEventMetricDetails = x.GroupBy(typeGroup => typeGroup.FleetEventType)
                                               .Select(x => new FleetEventMetricDetailDto
                                               {
                                                   FleetEventType = x.Key,
                                                   Count = x.Count()
                                               }).ToList(),

                }).ToList();

            return Ok(fleetEventMetric);
        }

        [HttpGet("Insert1000RandomRecord")]
        public async Task<IActionResult> Insert1000RandomRecord()
        {
            IList<FleetEvent> fleetEvent = new List<FleetEvent>();

            List<byte> enumValues = Enum.GetValues(typeof(CourierRequestTypes))
                                        .Cast<byte>()
                                        .ToList();

            for (var i = 1; i <= 1000; i++)
            {
                DateTime date = DateTime.Now.AddDays(-Random.Shared.Next(0, 3)).AddHours(-Random.Shared.Next(0, 8));
                fleetEvent.Add(new FleetEvent
                {
                    CourierRequestType = (CourierRequestTypes)enumValues[Random.Shared.Next(0, enumValues.Count)],
                    CreateDate = date,
                    DelayActivity = Random.Shared.Next(0, 30),
                    DeliveryCode = Random.Shared.Next(100000, 999999),
                    DeliveryServiceProviderId = (byte)Random.Shared.Next(0, 5),
                    DispatchRequestId = (long)Random.Shared.Next(10000000, 99999999),
                    DistanceMeter = Random.Shared.Next(1000, 5000),
                    DriverId = Random.Shared.Next(10, 1000),
                    EstimatedDeliveryDateTime = date,
                    ExceptionDescription = string.Empty,
                    FleetEventType = (FleetEventType)Random.Shared.Next(1, 4),
                    FleetId = (byte)Random.Shared.Next(1, 20),
                    Id = Guid.NewGuid(),
                    IsComputable = Random.Shared.Next(0, 2) == 0 ? false : true,
                    IsDeliveredOnTimeByDriver = Random.Shared.Next(0, 2) == 0 ? false : true,
                    IsOperationStaff = Random.Shared.Next(0, 2) == 0 ? false : true,
                    IsReassignmentRequested = Random.Shared.Next(0, 2) == 0 ? false : true,
                    LocationLatitude = Random.Shared.Next(30, 40),
                    LocationLongitude = Random.Shared.Next(50, 60),
                    OnTimeActivity = Random.Shared.Next(100, 1000),
                    ParcelReferenceCode = Random.Shared.Next(100000000, 999999999),
                    PartitionDate = date.ToString("yyyyMMdd"),
                    RealDeliveryDateTime = date,
                    ReturnParcelReferenceCode = 0,
                    ShiftId = Random.Shared.Next(100, 1000),
                    ShipmentId = Random.Shared.Next(100, 1000),
                    ShipmentNumber = Random.Shared.Next(100, 1000),
                    StoreId = Random.Shared.Next(100, 1000),
                    UnsuccessfulOperationReasonId = 0,
                    VendorId = Random.Shared.Next(1, 9) * 5,
                    ZapDispatchRequestId = Random.Shared.Next(100, 1000)
                });
            }

            await clickHouseDbContext.FleetEvents.AddRangeAsync(fleetEvent);
            await clickHouseDbContext.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("RandomDataInsertFleetId6161")]
        public async Task<IActionResult> RandomDataInsertFleetId6161()
        {
            IList<FleetEvent> fleetEvent = new List<FleetEvent>();

            List<byte> enumValues = Enum.GetValues(typeof(CourierRequestTypes))
                                        .Cast<byte>()
                                        .ToList();

            for (var i = 1; i <= 100; i++)
            {
                DateTime date = DateTime.Now.AddHours(-Random.Shared.Next(0, 8));
                fleetEvent.Add(new FleetEvent
                {
                    CourierRequestType = (CourierRequestTypes)enumValues[Random.Shared.Next(0, enumValues.Count)],
                    CreateDate = date,
                    DelayActivity = Random.Shared.Next(0, 30),
                    DeliveryCode = Random.Shared.Next(100000, 999999),
                    DeliveryServiceProviderId = (byte)Random.Shared.Next(0, 5),
                    DispatchRequestId = (long)Random.Shared.Next(10000000, 99999999),
                    DistanceMeter = Random.Shared.Next(1000, 5000),
                    DriverId = Random.Shared.Next(10, 1000),
                    EstimatedDeliveryDateTime = date,
                    ExceptionDescription = string.Empty,
                    FleetEventType = (FleetEventType)Random.Shared.Next(1, 4),
                    FleetId = 6161,
                    Id = Guid.NewGuid(),
                    IsComputable = Random.Shared.Next(0, 2) == 0 ? false : true,
                    IsDeliveredOnTimeByDriver = Random.Shared.Next(0, 2) == 0 ? false : true,
                    IsOperationStaff = Random.Shared.Next(0, 2) == 0 ? false : true,
                    IsReassignmentRequested = Random.Shared.Next(0, 2) == 0 ? false : true,
                    LocationLatitude = Random.Shared.Next(30, 40),
                    LocationLongitude = Random.Shared.Next(50, 60),
                    OnTimeActivity = Random.Shared.Next(100, 1000),
                    ParcelReferenceCode = Random.Shared.Next(100000000, 999999999),
                    PartitionDate = date.ToString("yyyyMMdd"),
                    RealDeliveryDateTime = date,
                    ReturnParcelReferenceCode = 0,
                    ShiftId = Random.Shared.Next(100, 1000),
                    ShipmentId = Random.Shared.Next(100, 1000),
                    ShipmentNumber = Random.Shared.Next(100, 1000),
                    StoreId = Random.Shared.Next(100, 1000),
                    UnsuccessfulOperationReasonId = 0,
                    VendorId = Random.Shared.Next(1, 9) * 5,
                    ZapDispatchRequestId = Random.Shared.Next(100, 1000)
                });
            }

            await clickHouseDbContext.FleetEvents.AddRangeAsync(fleetEvent);
            await clickHouseDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
