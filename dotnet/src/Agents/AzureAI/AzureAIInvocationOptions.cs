// Copyright (c) Microsoft. All rights reserved.
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Microsoft.SemanticKernel.Agents.AzureAI;

/// <summary>
/// Defines per-invocation execution options that override the assistant definition.
/// </summary>
/// <remarks>
/// This class is not applicable to <see cref="AgentChat"/> usage.
/// </remarks>
public sealed class AzureAIInvocationOptions
{
    /// <summary>
    /// Gets the AI model targeted by the agent.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ModelName { get; init; }

    /// <summary>
    /// Gets the additional instructions.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? AdditionalInstructions { get; init; }

    /// <summary>
    /// Gets the additional messages to add to the thread.
    /// </summary>
    /// <remarks>
    /// Only supports messages with <see href="https://platform.openai.com/docs/api-reference/runs/createRun#runs-createrun-additional_messages">role = User or Assistant</see>.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyList<ChatMessageContent>? AdditionalMessages { get; init; }

    /// <summary>
    /// Gets a value that indicates whether the code_interpreter tool is enabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool EnableCodeInterpreter { get; init; }

    /// <summary>
    /// Gets a value that indicates whether the file_search tool is enabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public bool EnableFileSearch { get; init; }

    /// <summary>
    /// Gets a value that indicates whether the JSON response format is enabled.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? EnableJsonResponse { get; init; }

    /// <summary>
    /// Gets the maximum number of completion tokens that can be used over the course of the run.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxCompletionTokens { get; init; }

    /// <summary>
    /// Gets the maximum number of prompt tokens that can be used over the course of the run.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? MaxPromptTokens { get; init; }

    /// <summary>
    /// Gets a value that indicates whether the parallel function calling is enabled during tool use.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if parallel function calling is enabled during tool use; otherwise, <see langword="false"/>. The default is <see langword="true"/>.
    /// </value>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ParallelToolCallsEnabled { get; init; }

    /// <summary>
    /// Gets the number of recent messages that the thread is truncated to.
    /// </summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? TruncationMessageCount { get; init; }

    /// <summary>
    /// Gets the sampling temperature.
    /// </summary>
    /// <value>
    /// A value between 0.0 and 2.0.
    /// </value>
    /// <remarks>
    /// This value controls the randomness of predictions made by the model.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? Temperature { get; init; }

    /// <summary>
    /// Gets or sets the percentile of most-likely candidates that the model considers for the next token.
    /// </summary>
    /// <remarks>
    /// It's recommended to set this property or <see cref="Temperature"/>, but not both.
    ///
    /// Nucleus sampling is an alternative to sampling with temperature where the model
    /// considers the results of the tokens with <see cref="TopP"/> probability mass.
    /// For example, 0.1 means only the tokens comprising the top 10% probability mass are considered.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public float? TopP { get; init; }

    /// <summary>
    /// Gets a set of up to 16 key/value pairs that can be attached to an agent, used for
    /// storing additional information about that object in a structured format.
    /// </summary>
    /// <remarks>
    /// Keys can be up to 64 characters in length, and values can be up to 512 characters in length.
    /// </remarks>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public IReadOnlyDictionary<string, string>? Metadata { get; init; }
}
