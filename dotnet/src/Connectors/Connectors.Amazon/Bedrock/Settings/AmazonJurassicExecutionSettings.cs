// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel.Text;

namespace Microsoft.SemanticKernel.Connectors.Amazon;

/// <summary>
/// Provides prompt execution settings for AI21 Labs Jurassic Text Generation.
/// </summary>
[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
public class AmazonJurassicExecutionSettings : PromptExecutionSettings
{
    private float? _temperature;
    private float? _topP;
    private int? _maxTokens;
    private List<string>? _stopSequences;
    private AI21JurassicPenalties? _countPenalty;
    private AI21JurassicPenalties? _presencePenalty;
    private AI21JurassicPenalties? _frequencyPenalty;

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
    /// <remarks>
    /// Use a lower value to ignore less probable options.
    /// </remarks>
    [JsonPropertyName("topP")]
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
    [JsonPropertyName("maxTokens")]
    public int? MaxTokens
    {
        get => this._maxTokens;
        set
        {
            this.ThrowIfFrozen();
            this._maxTokens = value;
        }
    }

    /// <summary>
    /// Gets or sets a list of stop sequences that the model recognizes and after which it stops generating further tokens.
    /// </summary>
    /// <remarks>
    /// Press the Enter key to insert a newline character in a stop sequence. Use the Tab key to finish inserting a stop sequence.
    /// </remarks>
    [JsonPropertyName("stopSequences")]
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
    /// Gets or sets the penalty for generating new tokens that already appear in the prompt or completion, proportional to the number of appearances.
    /// </summary>
    /// <remarks>
    /// Use a higher value to lower the probability of generating new tokens that already appear at least once in the prompt or in the completion.
    /// </remarks>
    [JsonPropertyName("countPenalty")]
    public AI21JurassicPenalties? CountPenalty
    {
        get => this._countPenalty;
        set
        {
            this.ThrowIfFrozen();
            this._countPenalty = value;
        }
    }

    /// <summary>
    /// Gets or sets the penalty for generating new tokens that already appear in the prompt or completion.
    /// </summary>
    /// <remarks>
    /// Use a higher value to lower the probability of generating new tokens that already appear at least once in the prompt or in the completion.
    /// </remarks>
    [JsonPropertyName("presencePenalty")]
    public AI21JurassicPenalties? PresencePenalty
    {
        get => this._presencePenalty;
        set
        {
            this.ThrowIfFrozen();
            this._presencePenalty = value;
        }
    }

    /// <summary>
    /// Gets or sets the penalty for generating new tokens that already appear in the prompt or completion.
    /// </summary>
    /// <summary>
    /// Use a higher value to lower the probability of generating new tokens that already appear at least once in the prompt or in the completion. The value is proportional to the frequency of the token appearances (normalized to text length).
    /// </summary>
    [JsonPropertyName("frequencyPenalty")]
    public AI21JurassicPenalties? FrequencyPenalty
    {
        get => this._frequencyPenalty;
        set
        {
            this.ThrowIfFrozen();
            this._frequencyPenalty = value;
        }
    }

    /// <summary>
    /// Converts PromptExecutionSettings to AmazonJurassicExecutionSettings.
    /// </summary>
    /// <param name="executionSettings">The Kernel standard PromptExecutionSettings.</param>
    /// <returns>Model-specific execution settings.</returns>
    public static AmazonJurassicExecutionSettings FromExecutionSettings(PromptExecutionSettings? executionSettings)
    {
        switch (executionSettings)
        {
            case null:
                return new AmazonJurassicExecutionSettings();
            case AmazonJurassicExecutionSettings settings:
                return settings;
        }

        var json = JsonSerializer.Serialize(executionSettings);
        return JsonSerializer.Deserialize<AmazonJurassicExecutionSettings>(json, JsonOptionsCache.ReadPermissive)!;
    }
}
