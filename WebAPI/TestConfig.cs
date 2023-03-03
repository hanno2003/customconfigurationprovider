using System;
using System.Collections.Generic;

namespace CustomConfigurationProvider;

public partial class TestConfig
{
    public string Key { get; set; } = null!;

    public string Label { get; set; } = null!;

    public string? Value { get; set; }
}
