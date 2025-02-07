// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel.Text;

namespace Microsoft.SemanticKernel.Connectors.Amazon;

/// <summary>
/// Provides prompt execution settings for Cohere Command Text Generation.
/// </summary>
[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
public class AmazonCommandExecutionSettings : PromptExecutionSettings
{
    private double? _temperature;
    private double? _topP;
    private double? _topK;
    private int? _maxTokens;
    private List<string>? _stopSequences;
    private string? _returnLikelihoods;
    private bool? _stream;
    private int? _numGenerations;
    private Dictionary<int, double>? _logitBias;
    private string? _truncate;

    /// <summary>
    /// Gets or sets the sampling temperature to use.
    /// </summary>
    /// <remarks>
    /// Use a lower value to decrease randomness in the response.
    /// </remarks>
    [JsonPropertyName("temperature")]
    public double? Temperature
    {
        get => this._temperature;
        set
        {
            this.ThrowIfFrozen();
            this._temperature = value;
        }
    }

    /// <summary>
    /// Gets or sets the probability mass of tokens whose results are considered in nucleus sampling.
    /// </summary>
    /// <remarks>
    /// Use a lower value to ignore less probable options. Set to 0 or 1.0 to disable. If both p and k are enabled, p acts after k.
    /// </remarks>
    [JsonPropertyName("p")]
    public double? TopP
    {
        get => this._topP;
        set
        {
            this.ThrowIfFrozen();
            this._topP = value;
        }
    }

    /// <summary>
    /// Gets or sets the number of token choices the model uses to generate the next token.
    /// </summary>
    /// <remarks>
    /// If both p and k are enabled, p acts after k.
    /// </remarks>
    [JsonPropertyName("k")]
    public double? TopK
    {
        get => this._topK;
        set
        {
            this.ThrowIfFrozen();
            this._topK = value;
        }
    }

    /// <summary>
    /// Gets or sets the maximum number of tokens to use in the generated response.
    /// </summary>
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
    /// Gets or sets the sequences that cause the model to stop generating.
    /// </summary>
    /// <remarks>
    /// Configure up to four sequences that the model recognizes. After a stop sequence, the model stops generating further tokens. The returned text doesn't contain the stop sequence.
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
    /// Gets or sets a value that indicates which token likelihoods are returned with the response.
    /// </summary>
    /// <value>
    /// <see langword="GENERATION"/>, <see langword="ALL"/>, or <see langword="NONE"/>.
    /// </value>
    [JsonPropertyName("return_likelihoods")]
    public string? ReturnLikelihoods
    {
        get => this._returnLikelihoods;
        set
        {
            this.ThrowIfFrozen();
            this._returnLikelihoods = value;
        }
    }

    /// <summary>
    /// Gets or sets a value that indicates whether the response is returned piece-by-piece or when it's complete.
    /// </summary>
    /// <value>
    /// <see langword="true"/> to return the response piece-by-piece in real-time. <see langword="false"/> to return the complete response after the process finishes.
    /// </value>
    /// <remarks>
    /// This property is required to support streaming.
    /// </remarks>
    [JsonPropertyName("stream")]
    public bool? Stream
    {
        get => this._stream;
        set
        {
            this.ThrowIfFrozen();
            this._stream = value;
        }
    }

    /// <summary>
    /// Gets or sets the maximum number of generations that the model should return.
    /// </summary>
    [JsonPropertyName("num_generations")]
    public int? NumGenerations
    {
        get => this._numGenerations;
        set
        {
            this.ThrowIfFrozen();
            this._numGenerations = value;
        }
    }

    /// <summary>
    /// Gets or sets the bias for preventing generation of unwanted tokens or including desired tokens in the model.
    /// </summary>
    /// <value>
    /// The format is {token_id: bias}, where bias is a float between -10 and 10.
    /// </value>
    /// <remarks>
    /// Tokens can be obtained from text using any tokenization service, such as Cohere's Tokenize endpoint.
    /// </remarks>
    [JsonPropertyName("logit_bias")]
    public Dictionary<int, double>? LogitBias
    {
        get => this._logitBias;
        set
        {
            this.ThrowIfFrozen();
            this._logitBias = value;
        }
    }

    /// <summary>
    /// Gets or sets a value that specifies how the API handles inputs that are longer than the maximum token length.
    /// </summary>
    /// <value>
    /// <see langword="NONE"/>, <see langword="START"/>, or <see langword="END"/>.
    /// </value>
    [JsonPropertyName("truncate")]
    public string? Truncate
    {
        get => this._truncate;
        set
        {
            this.ThrowIfFrozen();
            this._truncate = value;
        }
    }

    /// <summary>
    /// Converts PromptExecutionSettings to AmazonCommandExecutionSettings.
    /// </summary>
    /// <param name="executionSettings">The Kernel standard PromptExecutionSettings.</param>
    /// <returns>Model-specific execution settings.</returns>
    public static AmazonCommandExecutionSettings FromExecutionSettings(PromptExecutionSettings? executionSettings)
    {
        switch (executionSettings)
        {
            case null:
                return new AmazonCommandExecutionSettings();
            case AmazonCommandExecutionSettings settings:
                return settings;
        }

        var json = JsonSerializer.Serialize(executionSettings);
        return JsonSerializer.Deserialize<AmazonCommandExecutionSettings>(json, JsonOptionsCache.ReadPermissive)!;
    }
}
