// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel.Text;

namespace Microsoft.SemanticKernel.Connectors.Amazon;

/// <summary>
/// Provides prompt execution settings for AI21 Jamba Chat Completion.
/// </summary>
[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
public class AmazonJambaExecutionSettings : PromptExecutionSettings
{
    private float? _temperature;
    private float? _topP;
    private int? _maxTokens;
    private List<string>? _stop;
    private int? _n;
    private double? _frequencyPenalty;
    private double? _presencePenalty;

    /// <summary>
    /// Gets or sets a value that indicates how much variation is provided in each answer.
    /// </summary>
    /// <value>
    /// A number between 0.0 and 2.0 that indicates how much variation is provided in each answer. A value of 0.0 guarantees the same response to the same question every time. The default value is 1.0.
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
    /// <value>
    /// 1.0 if the pool consists of all possible tokens; 0.01 if the pool consists of only the most likely next tokens.
    /// </value>
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
    /// Gets or sets the maximum number of tokens to allow for each generated response message.
    /// </summary>
    /// <value>
    /// A value between 0 and 4096 that specifies the maximum number of tokens to allow for each generated response message. The default is 4096.
    /// </value>
    /// <remarks>
    /// Typically, the best way to limit output length is by providing a length limit in the system prompt (for example, "limit your answers to three sentences").
    /// </remarks>
    [JsonPropertyName("max_tokens")]
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
    /// Gets or sets the model-generated strings that cause the messaged to be ended.
    /// </summary>
    /// <remarks>
    /// The stop sequence is not included in the generated message. Each sequence can be up to 64K long, and can contain newlines as \n characters.
    /// </remarks>
    [JsonPropertyName("stop")]
    public List<string>? Stop
    {
        get => this._stop;
        set
        {
            this.ThrowIfFrozen();
            this._stop = value;
        }
    }

    /// <summary>
    /// Gets or sets the number of responses that are generated (one for text generation).
    /// </summary>
    [JsonPropertyName("n")]
    public int? NumberOfResponses
    {
        get => this._n;
        set
        {
            this.ThrowIfFrozen();
            this._n = value;
        }
    }

    /// <summary>
    /// Gets or sets the penalty for repeated tokens proportional to how many times they've appeared.
    /// </summary>
    /// <remarks>
    /// You can increase this value to reduce the frequency of repeated words within a single response message. This penalty gradually increases the more times a word appears during response generation. Setting to 2.0 will produce a string with few, if any repeated words.
    /// </remarks>
    [JsonPropertyName("frequency_penalty")]
    public double? FrequencyPenalty
    {
        get => this._frequencyPenalty;
        set
        {
            this.ThrowIfFrozen();
            this._frequencyPenalty = value;
        }
    }

    /// <summary>
    /// Gets or sets the penalty for all repeated tokens.
    /// </summary>
    /// <remarks>
    /// You can increase this value to reduce the frequency of repeated words within a single message. Unlike <see cref="FrequencyPenalty"/>, the presence penalty is applied equally no matter how many times a word appears.
    /// </remarks>
    [JsonPropertyName("presence_penalty")]
    public double? PresencePenalty
    {
        get => this._presencePenalty;
        set
        {
            this.ThrowIfFrozen();
            this._presencePenalty = value;
        }
    }

    /// <summary>
    /// Converts PromptExecutionSettings to AmazonJambaChatExecutionSettings.
    /// </summary>
    /// <param name="executionSettings">The Kernel standard PromptExecutionSettings.</param>
    /// <returns>Model-specific execution settings.</returns>
    public static AmazonJambaExecutionSettings FromExecutionSettings(PromptExecutionSettings? executionSettings)
    {
        switch (executionSettings)
        {
            case null:
                return new AmazonJambaExecutionSettings();
            case AmazonJambaExecutionSettings settings:
                return settings;
        }

        var json = JsonSerializer.Serialize(executionSettings);
        return JsonSerializer.Deserialize<AmazonJambaExecutionSettings>(json, JsonOptionsCache.ReadPermissive)!;
    }
}
