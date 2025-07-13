using Biogenom.NutritionReport.Domain.Common.Serializers;
using Force.DeepCloner;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Biogenom.NutritionReport.Infrastructure.Common.Serializers;

public class JsonSerializationSettingsProvider : IJsonSerializationSettingsProvider
{
    private readonly JsonSerializerSettings _defaultSettings;
    private readonly JsonSerializerSettings _eventBusSettings;

    public JsonSerializationSettingsProvider()
    {
        _defaultSettings = Configure(new JsonSerializerSettings());
        _eventBusSettings = ConfigureForEventBus(new JsonSerializerSettings());
    }

    public JsonSerializerSettings Configure(JsonSerializerSettings settings)
    {
        settings.Formatting = Formatting.Indented;
        settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        settings.NullValueHandling = NullValueHandling.Ignore;

        return settings;
    }

    public JsonSerializerSettings ConfigureForEventBus(JsonSerializerSettings settings)
    {
        settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

        return settings;
    }

    public JsonSerializerSettings Get(bool clone = false) => clone ? _defaultSettings.DeepClone() : _defaultSettings;

    public JsonSerializerSettings GetForEventBus(bool clone = false) => clone ? _eventBusSettings.DeepClone() : _eventBusSettings;
}
