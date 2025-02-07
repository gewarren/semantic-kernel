// Copyright (c) Microsoft. All rights reserved.

using System.Text.Json.Serialization;

namespace Microsoft.SemanticKernel.Connectors.Amazon;

/// <summary>
/// Describes penalties for AI21 Jurassic.
/// https://docs.ai21.com/reference/j2-complete-ref
/// </summary>
public sealed class AI21JurassicPenalties
{
    /// <summary>
    /// Gets or sets the scale of the penalty.
    /// </summary>
    [JsonPropertyName("scale")]
    internal double Scale { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether to apply penalty to white spaces.
    /// </summary>
    [JsonPropertyName("applyToWhitespaces")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    internal bool? ApplyToWhitespaces { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether to apply penalty to punctuation.
    /// </summary>
    [JsonPropertyName("applyToPunctuations")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    internal bool? ApplyToPunctuations { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether to apply penalty to numbers.
    /// </summary>
    [JsonPropertyName("applyToNumbers")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    internal bool? ApplyToNumbers { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether to apply penalty to stop words.
    /// </summary>
    [JsonPropertyName("applyToStopwords")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    internal bool? ApplyToStopwords { get; set; }

    /// <summary>
    /// Gets or sets a value that indicates whether to apply penalty to emojis.
    /// </summary>
    [JsonPropertyName("applyToEmojis")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    internal bool? ApplyToEmojis { get; set; }
}
