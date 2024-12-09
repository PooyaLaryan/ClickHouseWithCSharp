using System.ComponentModel;

namespace ClickHouseWithCSharp.Infrastructure;

public enum FleetEventType : byte
{
    None = 0,
    Delivery = 1,
    UnsuccessfulDelivery = 2,
    UnsuccessfulPickup = 3,
}

public enum CourierRequestTypes : byte
{
    [Description("ارسال فوری")]
    OnDemandDelivery = 5,
    [Description("ارسال زمانبندی دو ساعته")]
    ScheduledTwoHourDelivery = 10,
    [Description("ارسال زمانبندی تلفیق شده")]
    ConsolidateScheduledDelivery = 11,
    [Description("ارسال زمانبندی یک ساعته")]
    ScheduledOneHourDelivery = 15,
    [Description("لغو حمل")]
    Cancel = 20,
    [Description("مرجوعی فوری")]
    OnDemandReturn = 25,
    [Description("مرجوعی فوری پس از تحویل")]
    OnDemandReturnForDelivered = 26,
    [Description("مرجوعی برنامه ریزی شده تکی")]
    ScheduledSingleReturn = 30,
    [Description("مرجوعی برنامه ریزی شده چندگانه")]
    ScheduledMultipleReturn = 35,
    [Description("جایگزینی فوری")]
    OnDemandReplacement = 40,
    [Description("جایگزینی برنامه ریزی شده تکی")]
    ScheduledSingleReplacement = 45,
    [Description("جایگزینی برنامه ریزی شده چندگانه")]
    ScheduledMultipleReplacement = 50,
    [Description("مرجوعی جایگزینی")]
    ReturnOfReplacement = 51,
    [Description("ارسال نیاز به تایید")]
    RequiredConfirmationDelivery = 55,
    [Description("جایگزینی بدون مرجوعی فوری")]
    OnDemandReplacementWithoutReturn = 60,
    [Description("جایگزینی بدون مرجوعی زمانبندی شده تکی")]
    ScheduledSingleReplacementWithoutReturn = 65,
    [Description("جایگزینی بدون مرجوعی زمانبندی شده چندتایی")]
    ScheduledMultipleReplacementWithoutReturn = 70
}
