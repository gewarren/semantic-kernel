// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel.Text;

namespace Microsoft.SemanticKernel.Connectors.Amazon;

/// <summary>
/// Provides prompt execution settings for Anthropic Claude Text Generation.
/// </summary>
[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
public sealed class AmazonClaudeExecutionSettings : PromptExecutionSettings
{
    private int _maxTokensToSample;
    private List<string>? _stopSequences;
    private float? _temperature;
    private float? _topP;
    private int? _topK;

    /// <summary>
    /// Specifies the default maximum number of tokens for a text generation.
    /// </summary>
    private const int DefaultTextMaxTokens = 200;

    /// <summary>
    /// Gets or sets the maximum number of tokens to generate before stopping.
    /// </summary>
    /// <remarks>
    /// For optimal performance, a limit of 4,000 tokens is recommended.
    /// </remarks>
    [JsonPropertyName("max_tokens_to_sample")]
    public int MaxTokensToSample
    {
        get => this._maxTokensToSample;
        set
        {
            this.ThrowIfFrozen();
            this._maxTokensToSample = value;
        }
    }

    /// <summary>
    /// Gets or sets the sequences that cause the model to stop generating.
    /// </summary>
    /// <remarks>
    /// Anthropic Claude models stop on "\n\nHuman:", and might include additional built-in stop sequences in the future. Use the stop_sequences inference parameter to include additional strings that will signal the model to stop generating text.
    /// </remarks>
    [JsonPropertyName("stop_sequences")]
    public List<string>? StopSequences
    {
        get => this._stopSequences;
        set
        {
            this.ThrowIfFrozen();
            this._stopSequences = value;
        }
    }

    /// <summary>
    /// Gets or sets the amount of randomness injected into the response.
    /// </summary>
    /// <value>
    /// Use a value closer to 0.0 for analytical or multiple choice, and a value closer to 1.0 for creative and generative tasks.
    /// </value>
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
    /// <remarks>
    /// In nucleus sampling, Anthropic Claude computes the cumulative distribution over all the options for each subsequent token in decreasing probability order and cuts it off once it reaches a particular probability specified by <see cref="TopP"/>. You should set either <see cref="Temperature"/> or <see cref="TopP"/>, but not both.
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
    /// Gets or sets the number of most-likely candidates that the model considers for the next token.
    /// </summary>
    /// <remarks>
    /// Use TopK to remove long tail, low probability responses.
    /// </remarks>
    [JsonPropertyName("top_k")]
    public int? TopK
    {
        get => this._topK;
        set
        {
            this.ThrowIfFrozen();
            this._topK = value;
        }
    }

    /// <summary>
    /// Converts PromptExecutionSettings to ClaudeExecutionSettings.
    /// </summary>
    /// <param name="executionSettings">The Kernel standard PromptExecutionSettings.</param>
    /// <returns>Model-specific execution settings.</returns>
    public static AmazonClaudeExecutionSettings FromExecutionSettings(PromptExecutionSettings? executionSettings)
    {
        switch (executionSettings)
        {
            case null:
                return new AmazonClaudeExecutionSettings { MaxTokensToSample = DefaultTextMaxTokens };
            case AmazonClaudeExecutionSettings settings:
                return settings;
        }

        var json = JsonSerializer.Serialize(executionSettings);
        return JsonSerializer.Deserialize<AmazonClaudeExecutionSettings>(json, JsonOptionsCache.ReadPermissive)!;
    }
}
