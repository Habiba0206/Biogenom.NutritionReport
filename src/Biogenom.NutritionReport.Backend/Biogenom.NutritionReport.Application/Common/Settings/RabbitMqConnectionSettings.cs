﻿namespace Biogenom.NutritionReport.Application.Common.Settings;

public class RabbitMqConnectionSettings
{
    public string HostName { get; set; } = default!;

    public int Port { get; set; }
}
