// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

// Copied from https://raw.githubusercontent.com/dotnet/aspnetcore/main/src/Http/Http.Extensions/src/ProblemDetails.cs.

using System.Text.Json.Serialization;

namespace Jimmys20.ProblemDetails
{
    /// <summary>
    /// A machine-readable format for specifying errors in HTTP API responses based on <see href="https://tools.ietf.org/html/rfc7807"/>.
    /// </summary>
    public class ProblemDetails
    {
        /// <summary>
        /// A URI reference [RFC3986] that identifies the problem type. This specification encourages that, when
        /// dereferenced, it provide human-readable documentation for the problem type
        /// (e.g., using HTML [W3C.REC-html5-20141028]). When this member is not present, its value is assumed to be
        /// "about:blank".
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// A short, human-readable summary of the problem type. It SHOULD NOT change from occurrence to occurrence
        /// of the problem, except for purposes of localization(e.g., using proactive content negotiation;
        /// see[RFC7231], Section 3.4).
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }

        /// <summary>
        /// The HTTP status code([RFC7231], Section 6) generated by the origin server for this occurrence of the problem.
        /// </summary>
        [JsonPropertyName("status")]
        public int? Status { get; set; }

        /// <summary>
        /// A human-readable explanation specific to this occurrence of the problem.
        /// </summary>
        [JsonPropertyName("detail")]
        public string Detail { get; set; }

        /// <summary>
        /// A URI reference that identifies the specific occurrence of the problem. It may or may not yield further information if dereferenced.
        /// </summary>
        [JsonPropertyName("instance")]
        public string Instance { get; set; }

        /// <summary>
        /// Gets the <see cref="Dictionary{TKey, TValue}"/> for extension members.
        /// <para>
        /// Problem type definitions MAY extend the problem details object with additional members. Extension members appear in the same namespace as
        /// other members of a problem type.
        /// </para>
        /// </summary>
        /// <remarks>
        /// The round-tripping behavior for <see cref="Extensions"/> is determined by the implementation of the Input \ Output formatters.
        /// In particular, complex types or collection types may not round-trip to the original type when using the built-in JSON or XML formatters.
        /// </remarks>
        [JsonExtensionData]
        public Dictionary<string, object> Extensions { get; set; }
    }
}
