﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Akka.Interfaced CodeGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Akka.Interfaced;
using Akka.Actor;
using ProtoBuf;
using TypeAlias;
using System.ComponentModel;

#region Protobuf.Interface.IHelloWorld

namespace Protobuf.Interface
{
    [PayloadTable(typeof(IHelloWorld), PayloadTableKind.Request)]
    public static class IHelloWorld_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(GetHelloCount_Invoke), typeof(GetHelloCount_Return) },
                { typeof(SayHello_Invoke), typeof(SayHello_Return) },
            };
        }

        [ProtoContract, TypeAlias]
        public class GetHelloCount_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType()
            {
                return typeof(IHelloWorld);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IHelloWorld)__target).GetHelloCount();
                return (IValueGetable)(new GetHelloCount_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class GetHelloCount_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public System.Int32 v;

            public Type GetInterfaceType()
            {
                return typeof(IHelloWorld);
            }

            public object Value
            {
                get { return v; }
            }
        }

        [ProtoContract, TypeAlias]
        public class SayHello_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public System.String name;

            public Type GetInterfaceType()
            {
                return typeof(IHelloWorld);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IHelloWorld)__target).SayHello(name);
                return (IValueGetable)(new SayHello_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class SayHello_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public System.String v;

            public Type GetInterfaceType()
            {
                return typeof(IHelloWorld);
            }

            public object Value
            {
                get { return v; }
            }
        }
    }

    public interface IHelloWorld_NoReply
    {
        void GetHelloCount();
        void SayHello(System.String name);
    }

    public class HelloWorldRef : InterfacedActorRef, IHelloWorld, IHelloWorld_NoReply
    {
        public HelloWorldRef() : base(null)
        {
        }

        public HelloWorldRef(IRequestTarget target) : base(target)
        {
        }

        public HelloWorldRef(IRequestTarget target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
        }

        public HelloWorldRef(IActorRef actor) : base(new AkkaActorTarget(actor))
        {
        }

        public HelloWorldRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(new AkkaActorTarget(actor), requestWaiter, timeout)
        {
        }

        public static implicit operator HelloWorldRef(TypedActorRef typedActor)
        {
            InterfacedActorOfExtensions.CheckIfActorImplementsOrThrow(typedActor.Type, typeof(IHelloWorld));
            return new HelloWorldRef(typedActor.Actor);
        }

        public IActorRef Actor => ((AkkaActorTarget)Target)?.Actor;

        public IHelloWorld_NoReply WithNoReply()
        {
            return this;
        }

        public HelloWorldRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new HelloWorldRef(Target, requestWaiter, Timeout);
        }

        public HelloWorldRef WithTimeout(TimeSpan? timeout)
        {
            return new HelloWorldRef(Target, RequestWaiter, timeout);
        }

        public Task<System.Int32> GetHelloCount()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IHelloWorld_PayloadTable.GetHelloCount_Invoke {  }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }

        public Task<System.String> SayHello(System.String name)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IHelloWorld_PayloadTable.SayHello_Invoke { name = name }
            };
            return SendRequestAndReceive<System.String>(requestMessage);
        }

        void IHelloWorld_NoReply.GetHelloCount()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IHelloWorld_PayloadTable.GetHelloCount_Invoke {  }
            };
            SendRequest(requestMessage);
        }

        void IHelloWorld_NoReply.SayHello(System.String name)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IHelloWorld_PayloadTable.SayHello_Invoke { name = name }
            };
            SendRequest(requestMessage);
        }
    }

    [ProtoContract]
    public class SurrogateForIHelloWorld
    {
        [ProtoMember(1)] public IRequestTarget Target;

        [ProtoConverter]
        public static SurrogateForIHelloWorld Convert(IHelloWorld value)
        {
            if (value == null) return null;
            return new SurrogateForIHelloWorld { Target = ((HelloWorldRef)value).Target };
        }

        [ProtoConverter]
        public static IHelloWorld Convert(SurrogateForIHelloWorld value)
        {
            if (value == null) return null;
            return new HelloWorldRef(value.Target);
        }
    }

    [AlternativeInterface(typeof(IHelloWorld))]
    public interface IHelloWorldSync : IInterfacedActorSync
    {
        System.Int32 GetHelloCount();
        System.String SayHello(System.String name);
    }
}

#endregion
#region Protobuf.Interface.IPedantic

namespace Protobuf.Interface
{
    [PayloadTable(typeof(IPedantic), PayloadTableKind.Request)]
    public static class IPedantic_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(TestCall_Invoke), null },
                { typeof(TestOptional_Invoke), typeof(TestOptional_Return) },
                { typeof(TestParams_Invoke), typeof(TestParams_Return) },
                { typeof(TestPassClass_Invoke), typeof(TestPassClass_Return) },
                { typeof(TestReturnClass_Invoke), typeof(TestReturnClass_Return) },
                { typeof(TestTuple_Invoke), typeof(TestTuple_Return) },
            };
        }

        [ProtoContract, TypeAlias]
        public class TestCall_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((IPedantic)__target).TestCall();
                return null;
            }
        }

        [ProtoContract, TypeAlias]
        public class TestOptional_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public System.Nullable<System.Int32> value;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IPedantic)__target).TestOptional(value);
                return (IValueGetable)(new TestOptional_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class TestOptional_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public System.Nullable<System.Int32> v;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public object Value
            {
                get { return v; }
            }
        }

        [ProtoContract, TypeAlias]
        public class TestParams_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public System.Int32[] values;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IPedantic)__target).TestParams(values);
                return (IValueGetable)(new TestParams_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class TestParams_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public System.Int32[] v;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public object Value
            {
                get { return v; }
            }
        }

        [ProtoContract, TypeAlias]
        public class TestPassClass_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public Protobuf.Interface.TestParam param;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IPedantic)__target).TestPassClass(param);
                return (IValueGetable)(new TestPassClass_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class TestPassClass_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public System.String v;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public object Value
            {
                get { return v; }
            }
        }

        [ProtoContract, TypeAlias]
        public class TestReturnClass_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public System.Int32 value;
            [ProtoMember(2)] public System.Int32 offset;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IPedantic)__target).TestReturnClass(value, offset);
                return (IValueGetable)(new TestReturnClass_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class TestReturnClass_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public Protobuf.Interface.TestResult v;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public object Value
            {
                get { return v; }
            }
        }

        [ProtoContract, TypeAlias]
        public class TestTuple_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public System.Tuple<System.Int32, System.String> value;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IPedantic)__target).TestTuple(value);
                return (IValueGetable)(new TestTuple_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class TestTuple_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public System.Tuple<System.Int32, System.String> v;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public object Value
            {
                get { return v; }
            }
        }
    }

    public interface IPedantic_NoReply
    {
        void TestCall();
        void TestOptional(System.Nullable<System.Int32> value);
        void TestParams(params System.Int32[] values);
        void TestPassClass(Protobuf.Interface.TestParam param);
        void TestReturnClass(System.Int32 value, System.Int32 offset);
        void TestTuple(System.Tuple<System.Int32, System.String> value);
    }

    public class PedanticRef : InterfacedActorRef, IPedantic, IPedantic_NoReply
    {
        public PedanticRef() : base(null)
        {
        }

        public PedanticRef(IRequestTarget target) : base(target)
        {
        }

        public PedanticRef(IRequestTarget target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
        }

        public PedanticRef(IActorRef actor) : base(new AkkaActorTarget(actor))
        {
        }

        public PedanticRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(new AkkaActorTarget(actor), requestWaiter, timeout)
        {
        }

        public static implicit operator PedanticRef(TypedActorRef typedActor)
        {
            InterfacedActorOfExtensions.CheckIfActorImplementsOrThrow(typedActor.Type, typeof(IPedantic));
            return new PedanticRef(typedActor.Actor);
        }

        public IActorRef Actor => ((AkkaActorTarget)Target)?.Actor;

        public IPedantic_NoReply WithNoReply()
        {
            return this;
        }

        public PedanticRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new PedanticRef(Target, requestWaiter, Timeout);
        }

        public PedanticRef WithTimeout(TimeSpan? timeout)
        {
            return new PedanticRef(Target, RequestWaiter, timeout);
        }

        public Task TestCall()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestCall_Invoke {  }
            };
            return SendRequestAndWait(requestMessage);
        }

        public Task<System.Nullable<System.Int32>> TestOptional(System.Nullable<System.Int32> value)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestOptional_Invoke { value = value }
            };
            return SendRequestAndReceive<System.Nullable<System.Int32>>(requestMessage);
        }

        public Task<System.Int32[]> TestParams(params System.Int32[] values)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestParams_Invoke { values = values }
            };
            return SendRequestAndReceive<System.Int32[]>(requestMessage);
        }

        public Task<System.String> TestPassClass(Protobuf.Interface.TestParam param)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestPassClass_Invoke { param = param }
            };
            return SendRequestAndReceive<System.String>(requestMessage);
        }

        public Task<Protobuf.Interface.TestResult> TestReturnClass(System.Int32 value, System.Int32 offset)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestReturnClass_Invoke { value = value, offset = offset }
            };
            return SendRequestAndReceive<Protobuf.Interface.TestResult>(requestMessage);
        }

        public Task<System.Tuple<System.Int32, System.String>> TestTuple(System.Tuple<System.Int32, System.String> value)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestTuple_Invoke { value = value }
            };
            return SendRequestAndReceive<System.Tuple<System.Int32, System.String>>(requestMessage);
        }

        void IPedantic_NoReply.TestCall()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestCall_Invoke {  }
            };
            SendRequest(requestMessage);
        }

        void IPedantic_NoReply.TestOptional(System.Nullable<System.Int32> value)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestOptional_Invoke { value = value }
            };
            SendRequest(requestMessage);
        }

        void IPedantic_NoReply.TestParams(params System.Int32[] values)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestParams_Invoke { values = values }
            };
            SendRequest(requestMessage);
        }

        void IPedantic_NoReply.TestPassClass(Protobuf.Interface.TestParam param)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestPassClass_Invoke { param = param }
            };
            SendRequest(requestMessage);
        }

        void IPedantic_NoReply.TestReturnClass(System.Int32 value, System.Int32 offset)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestReturnClass_Invoke { value = value, offset = offset }
            };
            SendRequest(requestMessage);
        }

        void IPedantic_NoReply.TestTuple(System.Tuple<System.Int32, System.String> value)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestTuple_Invoke { value = value }
            };
            SendRequest(requestMessage);
        }
    }

    [ProtoContract]
    public class SurrogateForIPedantic
    {
        [ProtoMember(1)] public IRequestTarget Target;

        [ProtoConverter]
        public static SurrogateForIPedantic Convert(IPedantic value)
        {
            if (value == null) return null;
            return new SurrogateForIPedantic { Target = ((PedanticRef)value).Target };
        }

        [ProtoConverter]
        public static IPedantic Convert(SurrogateForIPedantic value)
        {
            if (value == null) return null;
            return new PedanticRef(value.Target);
        }
    }

    [AlternativeInterface(typeof(IPedantic))]
    public interface IPedanticSync : IInterfacedActorSync
    {
        void TestCall();
        System.Nullable<System.Int32> TestOptional(System.Nullable<System.Int32> value);
        System.Int32[] TestParams(params System.Int32[] values);
        System.String TestPassClass(Protobuf.Interface.TestParam param);
        Protobuf.Interface.TestResult TestReturnClass(System.Int32 value, System.Int32 offset);
        System.Tuple<System.Int32, System.String> TestTuple(System.Tuple<System.Int32, System.String> value);
    }
}

#endregion
#region Protobuf.Interface.ISurrogate

namespace Protobuf.Interface
{
    [PayloadTable(typeof(ISurrogate), PayloadTableKind.Request)]
    public static class ISurrogate_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(GetAddress_Invoke), typeof(GetAddress_Return) },
                { typeof(GetPath_Invoke), typeof(GetPath_Return) },
                { typeof(GetSelf_Invoke), typeof(GetSelf_Return) },
            };
        }

        [ProtoContract, TypeAlias]
        public class GetAddress_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public Akka.Actor.Address address;

            public Type GetInterfaceType()
            {
                return typeof(ISurrogate);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((ISurrogate)__target).GetAddress(address);
                return (IValueGetable)(new GetAddress_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class GetAddress_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public Akka.Actor.Address v;

            public Type GetInterfaceType()
            {
                return typeof(ISurrogate);
            }

            public object Value
            {
                get { return v; }
            }
        }

        [ProtoContract, TypeAlias]
        public class GetPath_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            [ProtoMember(1)] public Akka.Actor.ActorPath path;

            public Type GetInterfaceType()
            {
                return typeof(ISurrogate);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((ISurrogate)__target).GetPath(path);
                return (IValueGetable)(new GetPath_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class GetPath_Return
            : IInterfacedPayload, IValueGetable
        {
            [ProtoMember(1)] public Akka.Actor.ActorPath v;

            public Type GetInterfaceType()
            {
                return typeof(ISurrogate);
            }

            public object Value
            {
                get { return v; }
            }
        }

        [ProtoContract, TypeAlias]
        public class GetSelf_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType()
            {
                return typeof(ISurrogate);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((ISurrogate)__target).GetSelf();
                return (IValueGetable)(new GetSelf_Return { v = __v });
            }
        }

        [ProtoContract, TypeAlias]
        public class GetSelf_Return
            : IInterfacedPayload, IValueGetable, IPayloadActorRefUpdatable
        {
            [ProtoMember(1)] public Protobuf.Interface.ISurrogate v;

            public Type GetInterfaceType()
            {
                return typeof(ISurrogate);
            }

            public object Value
            {
                get { return v; }
            }

            void IPayloadActorRefUpdatable.Update(Action<object> updater)
            {
                if (v != null)
                {
                    updater(v); 
                }
            }
        }
    }

    public interface ISurrogate_NoReply
    {
        void GetAddress(Akka.Actor.Address address);
        void GetPath(Akka.Actor.ActorPath path);
        void GetSelf();
    }

    public class SurrogateRef : InterfacedActorRef, ISurrogate, ISurrogate_NoReply
    {
        public SurrogateRef() : base(null)
        {
        }

        public SurrogateRef(IRequestTarget target) : base(target)
        {
        }

        public SurrogateRef(IRequestTarget target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
        }

        public SurrogateRef(IActorRef actor) : base(new AkkaActorTarget(actor))
        {
        }

        public SurrogateRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(new AkkaActorTarget(actor), requestWaiter, timeout)
        {
        }

        public static implicit operator SurrogateRef(TypedActorRef typedActor)
        {
            InterfacedActorOfExtensions.CheckIfActorImplementsOrThrow(typedActor.Type, typeof(ISurrogate));
            return new SurrogateRef(typedActor.Actor);
        }

        public IActorRef Actor => ((AkkaActorTarget)Target)?.Actor;

        public ISurrogate_NoReply WithNoReply()
        {
            return this;
        }

        public SurrogateRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new SurrogateRef(Target, requestWaiter, Timeout);
        }

        public SurrogateRef WithTimeout(TimeSpan? timeout)
        {
            return new SurrogateRef(Target, RequestWaiter, timeout);
        }

        public Task<Akka.Actor.Address> GetAddress(Akka.Actor.Address address)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ISurrogate_PayloadTable.GetAddress_Invoke { address = address }
            };
            return SendRequestAndReceive<Akka.Actor.Address>(requestMessage);
        }

        public Task<Akka.Actor.ActorPath> GetPath(Akka.Actor.ActorPath path)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ISurrogate_PayloadTable.GetPath_Invoke { path = path }
            };
            return SendRequestAndReceive<Akka.Actor.ActorPath>(requestMessage);
        }

        public Task<Protobuf.Interface.ISurrogate> GetSelf()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ISurrogate_PayloadTable.GetSelf_Invoke {  }
            };
            return SendRequestAndReceive<Protobuf.Interface.ISurrogate>(requestMessage);
        }

        void ISurrogate_NoReply.GetAddress(Akka.Actor.Address address)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ISurrogate_PayloadTable.GetAddress_Invoke { address = address }
            };
            SendRequest(requestMessage);
        }

        void ISurrogate_NoReply.GetPath(Akka.Actor.ActorPath path)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ISurrogate_PayloadTable.GetPath_Invoke { path = path }
            };
            SendRequest(requestMessage);
        }

        void ISurrogate_NoReply.GetSelf()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ISurrogate_PayloadTable.GetSelf_Invoke {  }
            };
            SendRequest(requestMessage);
        }
    }

    [ProtoContract]
    public class SurrogateForISurrogate
    {
        [ProtoMember(1)] public IRequestTarget Target;

        [ProtoConverter]
        public static SurrogateForISurrogate Convert(ISurrogate value)
        {
            if (value == null) return null;
            return new SurrogateForISurrogate { Target = ((SurrogateRef)value).Target };
        }

        [ProtoConverter]
        public static ISurrogate Convert(SurrogateForISurrogate value)
        {
            if (value == null) return null;
            return new SurrogateRef(value.Target);
        }
    }

    [AlternativeInterface(typeof(ISurrogate))]
    public interface ISurrogateSync : IInterfacedActorSync
    {
        Akka.Actor.Address GetAddress(Akka.Actor.Address address);
        Akka.Actor.ActorPath GetPath(Akka.Actor.ActorPath path);
        Protobuf.Interface.ISurrogate GetSelf();
    }
}

#endregion
