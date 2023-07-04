using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageProject.WebApi.Models
{
    public class MessageView
    {
        public int SenderId { get; set; }
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool IsEdited { get; set; }

        public MessageView(Message message)
        {
            SenderId = message.SenderId;
            Text = message.Text;
            CreationTime = message.CreationTime;
            UpdateTime = message.CreationTime;
            IsEdited = message.CreationTime != message.UpdateTime;
        }
    }
}