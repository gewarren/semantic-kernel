// Copyright (c) Microsoft. All rights reserved.

using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel.Text;

namespace Microsoft.SemanticKernel.Connectors.Amazon;

/// <summary>
/// Provides prompt execution settings for Meta Llama 3 Text Generation.
/// </summary>
[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
public class AmazonLlama3ExecutionSettings : PromptExecutionSettings
{
    private float? _temperature;
    private float? _topP;
    private int? _maxGenLen;

    /// <summary>
    /// Gets or sets a value that indicates how much variation is provided in each answer.
    /// </summary>
    /// <remarks>
    /// Use a lower value to decrease randomness in the response.
    /// </remarks>
    [JsonPropertyName("temperature")]
    public float? Temperature
    {
        get => this._temperature;
        set
        {
            this.ThrowIfFrozen();
            this._temperature = value;
        }
    }

    /// <summary>
    /// Gets or sets the percentile of most-likely candidates that the model considers for the next token.
    /// </summary>
    /// <value>
    /// 0.0 to disable the setting. 1.0 to include all tokens.
    /// </value>
    /// <remarks>
    /// Use a lower value to ignore less probable options.
    /// </remarks>
    [JsonPropertyName("top_p")]
    public float? TopP
    {
        get => this._topP;
        set
        {
            this.ThrowIfFrozen();
            this._topP = value;
        }
    }

    /// <summary>
    /// Gets or sets the maximum number of tokens to use in the generated response.
    /// </summary>
    /// <remarks>
    /// The model truncates the response once the generated text exceeds this value.
    /// </remarks>
    [JsonPropertyName("max_gen_len")]
    public int? MaxGenLen
    {
        get => this._maxGenLen;
        set
        {
            this.ThrowIfFrozen();
            this._maxGenLen = value;
        }
    }

    /// <summary>
    /// Converts PromptExecutionSettings to AmazonLlama3ExecutionSettings.
    /// </summary>
    /// <param name="executionSettings">The Kernel standard PromptExecutionSettings.</param>
    /// <returns>Model-specific execution settings.</returns>
    public static AmazonLlama3ExecutionSettings FromExecutionSettings(PromptExecutionSettings? executionSettings)
    {
        switch (executionSettings)
        {
            case null:
                return new AmazonLlama3ExecutionSettings();
            case AmazonLlama3ExecutionSettings settings:
                return settings;
        }

        var json = JsonSerializer.Serialize(executionSettings);
        return JsonSerializer.Deserialize<AmazonLlama3ExecutionSettings>(json, JsonOptionsCache.ReadPermissive)!;
    }
}
