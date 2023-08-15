using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GYMM.Core.Entities.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]
        Pending,
        [EnumMember(Value = "PaymentRecieved")]
        PaymentRecieved,
        [EnumMember(Value = "PaymentFailed")]
        PaymentFailed

    }
}
