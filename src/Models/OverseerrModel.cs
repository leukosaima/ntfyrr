using System;
using System.ComponentModel.DataAnnotations;

namespace ntfyrr.Models;

/// <summary>
/// Model for the default Overseerr webhook payload.
/// https://docs.overseerr.dev/using-overseerr/notifications/webhooks#template-variables
/// </summary>
public class OverseerrModel
{
    public required string subject { get; set; }
    public required string message { get; set; }
}
