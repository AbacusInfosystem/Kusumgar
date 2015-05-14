using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.IO;
using log4net.Core;
using log4net.Appender;
using log4net.Layout;

namespace KusumgarCrossCutting.Logging
{
    public class MSMQAppender : AppenderSkeleton
    {
        private MessageQueue m_queue;
        private string m_queueName;
        private PatternLayout m_labelLayout;

        public MSMQAppender()
        {
        }

        public string QueueName
        {
            get { return m_queueName; }
            set { m_queueName = value; }
        }

        public PatternLayout LabelLayout
        {
            get { return m_labelLayout; }
            set { m_labelLayout = value; }
        }

        override protected void Append(LoggingEvent loggingEvent)
        {
            if (m_queue == null)
            {
                //if (MessageQueue.Exists(m_queueName))
                //{
                m_queue = new MessageQueue(m_queueName);
                //}
                //else
                //{
                //    ErrorHandler.Error("Queue [" + m_queueName + "] not found");
                //}
            }

            if (m_queue != null)
            {
                Message message = new Message();
                message.Formatter = new BinaryMessageFormatter(System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full, System.Runtime.Serialization.Formatters.FormatterTypeStyle.TypesAlways);
                message.Label = RenderLabel(loggingEvent);
                message.Body = (DBLogInfo)loggingEvent.MessageObject;
                m_queue.Send(message);
            }
        }

        private string RenderLabel(LoggingEvent loggingEvent)
        {
            if (m_labelLayout == null)
            {
                return null;
            }

            StringWriter writer = new StringWriter();
            m_labelLayout.Format(writer, loggingEvent);

            return writer.ToString();
        }

    }
}
