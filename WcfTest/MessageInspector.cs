using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace WcfTest
{
    public class MessageInspector : IClientMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();
            Console.WriteLine("Received:\n{0}", buffer.CreateMessage().ToString());
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
            reply = buffer.CreateMessage();
            Console.WriteLine("Sending:\n{0}", buffer.CreateMessage().ToString());
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();
            Console.WriteLine("Sending:\n{0}", buffer.CreateMessage().ToString());
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            MessageBuffer buffer = reply.CreateBufferedCopy(Int32.MaxValue);
            reply = buffer.CreateMessage();
            Console.WriteLine("Received:\n{0}", buffer.CreateMessage().ToString());
        }
    }
}