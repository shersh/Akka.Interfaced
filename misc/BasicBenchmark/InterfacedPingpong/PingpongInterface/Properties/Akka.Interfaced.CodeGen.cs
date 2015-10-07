// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Akka.Interfaced CodeGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.Interfaced;
using ProtoBuf;
using TypeAlias;
using System.ComponentModel;

#region PingpongInterface.IClient

namespace PingpongInterface
{
    [PayloadTableForInterfacedActor(typeof(IClient))]
    public static class IClient_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,]
            {
                {typeof(Start_Invoke), null},
            };
        }

        [ProtoContract, TypeAlias]
        public class Start_Invoke : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public System.Int32 count;

            public Type GetInterfaceType() { return typeof(IClient); }

            public async Task<IValueGetable> Invoke(object target)
            {
                await ((IClient)target).Start(count);
                return null;
            }
        }
    }

    public interface IClient_NoReply
    {
        void Start(System.Int32 count);
    }

    [ProtoContract, TypeAlias]
    public class ClientRef : InterfacedActorRef, IClient, IClient_NoReply
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private ClientRef()
            : base(null)
        {
        }

        public ClientRef(IActorRef actor)
            : base(actor)
        {
        }

        public ClientRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public IClient_NoReply WithNoReply()
        {
            return this;
        }

        public ClientRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new ClientRef(Actor, requestWaiter, Timeout);
        }

        public ClientRef WithTimeout(TimeSpan? timeout)
        {
            return new ClientRef(Actor, RequestWaiter, timeout);
        }

        public Task Start(System.Int32 count)
        {
            var requestMessage = new RequestMessage
            {
                InvokePayload = new IClient_PayloadTable.Start_Invoke { count = count }
            };
            return SendRequestAndWait(requestMessage);
        }

        void IClient_NoReply.Start(System.Int32 count)
        {
            var requestMessage = new RequestMessage
            {
                InvokePayload = new IClient_PayloadTable.Start_Invoke { count = count }
            };
            SendRequest(requestMessage);
        }
    }
}

#endregion

#region PingpongInterface.IServer

namespace PingpongInterface
{
    [PayloadTableForInterfacedActor(typeof(IServer))]
    public static class IServer_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,]
            {
                {typeof(Echo_Invoke), typeof(Echo_Return)},
            };
        }

        [ProtoContract, TypeAlias]
        public class Echo_Invoke : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public System.Int32 value;

            public Type GetInterfaceType() { return typeof(IServer); }

            public async Task<IValueGetable> Invoke(object target)
            {
                var __v = await((IServer)target).Echo(value);
                return (IValueGetable)(new Echo_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class Echo_Return : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public System.Int32 v;

            public Type GetInterfaceType() { return typeof(IServer); }

            public object Value { get { return v; } }
        }
    }

    public interface IServer_NoReply
    {
        void Echo(System.Int32 value);
    }

    [ProtoContract, TypeAlias]
    public class ServerRef : InterfacedActorRef, IServer, IServer_NoReply
    {
        [ProtoMember(1)] private ActorRefBase _actor
        {
            get { return (ActorRefBase)Actor; }
            set { Actor = value; }
        }

        private ServerRef()
            : base(null)
        {
        }

        public ServerRef(IActorRef actor)
            : base(actor)
        {
        }

        public ServerRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout)
            : base(actor, requestWaiter, timeout)
        {
        }

        public IServer_NoReply WithNoReply()
        {
            return this;
        }

        public ServerRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new ServerRef(Actor, requestWaiter, Timeout);
        }

        public ServerRef WithTimeout(TimeSpan? timeout)
        {
            return new ServerRef(Actor, RequestWaiter, timeout);
        }

        public Task<System.Int32> Echo(System.Int32 value)
        {
            var requestMessage = new RequestMessage
            {
                InvokePayload = new IServer_PayloadTable.Echo_Invoke { value = value }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }

        void IServer_NoReply.Echo(System.Int32 value)
        {
            var requestMessage = new RequestMessage
            {
                InvokePayload = new IServer_PayloadTable.Echo_Invoke { value = value }
            };
            SendRequest(requestMessage);
        }
    }
}

#endregion
