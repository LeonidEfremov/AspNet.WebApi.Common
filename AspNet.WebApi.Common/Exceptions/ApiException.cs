﻿using System;
using System.Runtime.Serialization;

namespace AspNet.WebApi.Common.Exceptions
{
    /// <summary>Exception wrapper for own ApiExceptions.</summary>
    [Serializable]
    public class ApiException : Exception
    {
        /// <summary>HttpStatusCode for Exception.</summary>
        public const int STATUS_CODE = 500;

        /// <summary>ReasonCode for Exception.</summary>
        public const string REASON_CODE = "EXCEPTION";

        /// <summary>Gets or sets StatusCode.</summary>
        public int StatusCode { get; set; }

        /// <summary>Gets or sets ReasonCode.</summary>
        public string ReasonCode { get; set; }

        /// <inheritdoc/>
        public ApiException() : this(STATUS_CODE, REASON_CODE, string.Empty) { }

        /// <inheritdoc cref="Exception(string)" />
        public ApiException(string message) : this(STATUS_CODE, REASON_CODE, message) { }

        /// <inheritdoc cref="Exception(string,Exception)" />
        public ApiException(string message, Exception innerException) : this(STATUS_CODE, REASON_CODE, message, innerException) { }

        /// <inheritdoc />
        /// <param name="statusCode">HttpStatusCode for server response.</param>
        /// <param name="reasonCode">ReasonCode for Exception.</param>
        /// <param name="message">Exception Message.</param>
        /// <param name="innerException">Original Exception.</param>
        public ApiException(int statusCode, string reasonCode, string message, Exception innerException = null) : base(message, innerException)
        {
            StatusCode = statusCode;
            ReasonCode = reasonCode;
        }

        /// <inheritdoc />
        public ApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            StatusCode = info.GetInt32(nameof(StatusCode));
            ReasonCode = info.GetString(nameof(ReasonCode));
        }

        /// <inheritdoc />
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(nameof(StatusCode), StatusCode, typeof(int));
            info.AddValue(nameof(ReasonCode), ReasonCode, typeof(string));
        }
    }
}