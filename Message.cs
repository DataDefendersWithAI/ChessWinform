using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

/// <summary>
/// Usages:
/// From object to JSON:
/// Message message = new Message("TableCode", "type", "from", "to", "message", DateTime.Now);
/// string json = message.ToJson();
/// From JSON to object:
/// Message message = Message.FromJson(json);
/// Console.WriteLine(message.TableCode);
/// </summary>

namespace winforms_chat
{
    /// <summary>
    /// Represents a chat message.
    /// </summary>
    public class Message
    {
        public string TableCode { get; set; }
        public string type { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="TableCode">The table code.</param>
        /// <param name="type">The message type.</param>
        /// <param name="from">The sender of the message.</param>
        /// <param name="to">The recipient of the message.</param>
        /// <param name="message">The message content.</param>
        /// <param name="date">The date and time of the message.</param>
        public Message(string TableCode, string type, string from, string to, string message, DateTime date)
        {
            this.TableCode = TableCode;
            this.type = type;
            this.from = from;
            this.to = to;
            this.message = message;
            this.date = date;
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <returns>The JSON representation of the object.</returns>
        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        /// <summary>
        /// Deserializes the JSON to an object.
        /// </summary>
        /// <param name="json">The JSON string.</param>
        /// <returns>The deserialized object.</returns>
        public static Message FromJson(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentNullException(nameof(json));
            }
            return JsonSerializer.Deserialize<Message>(json);
        }
    }
}
