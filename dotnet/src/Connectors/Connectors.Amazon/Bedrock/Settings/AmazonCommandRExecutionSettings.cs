// Copyright (c) Microsoft. All rights reserved.

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.SemanticKernel.Text;

namespace Microsoft.SemanticKernel.Connectors.Amazon;

/// <summary>
/// Provides prompt execution settings for Cohere Command-R.
/// </summary>
[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
public class AmazonCommandRExecutionSettings : PromptExecutionSettings
{
    private List<CohereCommandRTools.ChatMessage>? _chatHistory;
    private List<CohereCommandRTools.Document>? _documents;
    private bool? _searchQueriesOnly;
    private string? _preamble;
    private int? _maxTokens;
    private float? _temperature;
    private float? _topP;
    private float? _topK;
    private string? _promptTruncation;
    private float? _frequencyPenalty;
    private float? _presencePenalty;
    private int? _seed;
    private bool? _returnPrompt;
    private List<CohereCommandRTools.Tool>? _tools;
    private List<CohereCommandRTools.ToolResult>? _toolResults;
    private List<string>? _stopSequences;
    private bool? _rawPrompting;

    /// <summary>
    /// Gets or sets a list of previous messages between the user and the model.
    /// </summary>
    /// <remarks>
    /// The list gives the model conversational context for responding to the user's message.
    /// </remarks>
    [JsonPropertyName("chat_history")]
    public List<CohereCommandRTools.ChatMessage>? ChatHistory
    {
        get => this._chatHistory;
        set
        {
            this.ThrowIfFrozen();
            this._chatHistory = value;
        }
    }

    /// <summary>
    /// Gets or sets a list of texts that the model can cite to generate a more accurate reply.
    /// </summary>
    /// <remarks>
    /// Each document is a string-string dictionary. The resulting generation includes citations that reference some of these documents. We recommend that you keep the total word count of the strings in the dictionary to under 300 words. An _excludes field (array of strings) can be optionally supplied to omit some key-value pairs from being shown to the model.
    /// </remarks>
    [JsonPropertyName("documents")]
    public List<CohereCommandRTools.Document>? Documents
    {
        get => this._documents;
        set
        {
            this.ThrowIfFrozen();
            this._documents = value;
        }
    }

    /// <summary>
    /// Gets or sets a value that indicates whether the response only contains a list of generated search queries.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the response will only contain a list of generated search queries, but no search will take place. <see langword="false"/> if a reply from the model to the user's message will be generated. The default is <see langword="false"/>.
    /// </value>
    [JsonPropertyName("search_queries_only")]
    public bool? SearchQueriesOnly
    {
        get => this._searchQueriesOnly;
        set
        {
            this.ThrowIfFrozen();
            this._searchQueriesOnly = value;
        }
    }

    /// <summary>
    /// Gets or sets the default preamble for search query generation.
    /// </summary>
    /// <remarks>
    /// This value has no effect on tool use generations.
    /// </remarks>
    [JsonPropertyName("preamble")]
    public string? Preamble
    {
        get => this._preamble;
        set
        {
            this.ThrowIfFrozen();
            this._preamble = value;
        }
    }

    /// <summary>
    /// Gets or sets the maximum number of tokens the model should generate as part of the response.
    /// </summary>
    /// <remarks>
    /// Setting a low value might result in incomplete generations. Setting max_tokens might result in incomplete or no generations when used with the tools or documents fields.
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
    /// Gets or sets the sampling temperature to use.
    /// </summary>
    /// <remarks>
    /// Use a lower value to decrease randomness in the response. Randomness can be further maximized by increasing the value of <see cref="TopP"/>.
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
    [JsonPropertyName("p")]
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
    /// Gets or sets the number of token choices the model uses to generate the next token.
    /// </summary>
    [JsonPropertyName("k")]
    public float? TopK
    {
        get => this._topK;
        set
        {
            this.ThrowIfFrozen();
            this._topK = value;
        }
    }

    /// <summary>
    /// Gets or sets a value that dictates how the prompt is constructed.
    /// </summary>
    /// <value>
    /// <see langword="AUTO_PRESERVE_ORDER"/> if some elements from chat_history and documents are dropped to construct a prompt that fits within the model's context length limit. During this process, the order of the documents and chat history is preserved. <see langword="OFF"/> if no elements are dropped. The default is <see cref="OFF"/>.
    /// </value>
    [JsonPropertyName("prompt_truncation")]
    public string? PromptTruncation
    {
        get => this._promptTruncation;
        set
        {
            this.ThrowIfFrozen();
            this._promptTruncation = value;
        }
    }

    /// <summary>
    /// Gets or sets the penalty for repeated tokens proportional to how many times they've appeared.
    /// </summary>
    /// <remarks>
    /// You can modify this value to reduce the repetitiveness of generated tokens. The higher the value, the stronger a penalty is applied to previously present tokens, proportional to how many times they've already appeared in the prompt or prior generation.
    /// </remarks>
    [JsonPropertyName("frequency_penalty")]
    public float? FrequencyPenalty
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
    /// You can modify this value to reduce repetitiveness of generated tokens. Similar to <see cref="FrequencyPenalty"/>, except that this penalty is applied equally to all tokens that have already appeared, regardless of their exact frequencies.
    /// </remarks>
    [JsonPropertyName("presence_penalty")]
    public float? PresencePenalty
    {
        get => this._presencePenalty;
        set
        {
            this.ThrowIfFrozen();
            this._presencePenalty = value;
        }
    }

    /// <summary>
    /// Gets or sets a seed value to help make token sampling deterministic.
    /// </summary>
    /// <remarks>
    /// If specified, the backend makes a best effort to sample tokens deterministically, such that repeated requests with the same seed and parameters should return the same result. However, determinism cannot be totally guaranteed.
    /// </remarks>
    [JsonPropertyName("seed")]
    public int? Seed
    {
        get => this._seed;
        set
        {
            this.ThrowIfFrozen();
            this._seed = value;
        }
    }

    /// <summary>
    /// Gets or sets a value that indicates whether the full prompt that was sent to the model is returned.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the full prompt that was sent to the model is returned; <see cref="false"/> if the prompt isn't returned. The default value is <see langword="false"/>.
    /// </value>
    /// <remarks>
    /// In the response, the prompt is in the prompt field.
    /// </remarks>
    [JsonPropertyName("return_prompt")]
    public bool? ReturnPrompt
    {
        get => this._returnPrompt;
        set
        {
            this.ThrowIfFrozen();
            this._returnPrompt = value;
        }
    }

    /// <summary>
    /// Gets or sets a list of available tools (functions) that the model might suggest invoking before producing a text response.
    /// </summary>
    /// <remarks>
    /// When tools is passed (without tool_results), the text field in the response will be "" and the tool_calls field in the response will be populated with a list of tool calls that need to be made. If no calls need to be made, the tool_calls array will be empty.
    /// </remarks>
    [JsonPropertyName("tools")]
    public List<CohereCommandRTools.Tool>? Tools
    {
        get => this._tools;
        set
        {
            this.ThrowIfFrozen();
            this._tools = value;
        }
    }

    /// <summary>
    /// Gets or sets a list of results from invoking tools recommended by the model in the previous chat turn.
    /// </summary>
    /// <remarks>
    /// Results are used to produce a text response and are referenced in citations. When using tool_results, tools must be passed as well. Each tool_result contains information about how it was invoked, as well as a list of outputs in the form of dictionaries. Cohere's unique fine-grained citation logic requires the output to be a list. In case the output is just one item, such as {"status": 200}, you should still wrap it inside a list.
    /// </remarks>
    [JsonPropertyName("tool_results")]
    public List<CohereCommandRTools.ToolResult>? ToolResults
    {
        get => this._toolResults;
        set
        {
            this.ThrowIfFrozen();
            this._toolResults = value;
        }
    }

    /// <summary>
    /// Gets or sets the list of stop sequences.
    /// </summary>
    /// <remarks>
    /// After a stop sequence is detected, the model stops generating further tokens.
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
    /// Gets or sets a value that indicates whether the user's message is sent to the model without any preprocessing.
    /// </summary>
    /// <value>
    /// <see langword="true"/> to send the user's message to the model without any preprocessing; otherwise, <see langword="false"/>.
    /// </value>
    [JsonPropertyName("raw_prompting")]
    public bool? RawPrompting
    {
        get => this._rawPrompting;
        set
        {
            this.ThrowIfFrozen();
            this._rawPrompting = value;
        }
    }

    /// <summary>
    /// Converts PromptExecutionSettings to AmazonCommandExecutionSettings.
    /// </summary>
    /// <param name="executionSettings">The Kernel standard PromptExecutionSettings.</param>
    /// <returns>Model-specific execution settings.</returns>
    public static AmazonCommandRExecutionSettings FromExecutionSettings(PromptExecutionSettings? executionSettings)
    {
        switch (executionSettings)
        {
            case null:
                return new AmazonCommandRExecutionSettings();
            case AmazonCommandRExecutionSettings settings:
                return settings;
        }

        var json = JsonSerializer.Serialize(executionSettings);
        return JsonSerializer.Deserialize<AmazonCommandRExecutionSettings>(json, JsonOptionsCache.ReadPermissive)!;
    }
}
