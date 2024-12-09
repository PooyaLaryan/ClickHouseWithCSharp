using ClickHouseWithCSharp.Infrastructure;

namespace ClickHouseWithCSharp.Dto;

public class FleetEventMetricDto
{
    public int FleetId { get; set; }
    public IEnumerable<FleetEventMetricDetailDto> FleetEventMetricDetails { get; set; }
}

public class FleetEventMetricDetailDto
{
    public int Count { get; set; }
    public FleetEventType FleetEventType { get; set; }
}