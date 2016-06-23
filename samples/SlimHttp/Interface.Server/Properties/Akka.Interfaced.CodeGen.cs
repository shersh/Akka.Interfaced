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

#region SlimHttp.Interface.ICalculator

namespace SlimHttp.Interface
{
    [PayloadTable(typeof(ICalculator), PayloadTableKind.Request)]
    public static class ICalculator_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(Concat_Invoke), typeof(Concat_Return) },
                { typeof(Sum_Invoke), typeof(Sum_Return) },
            };
        }

        public class Concat_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.String a;
            public System.String b;

            public Type GetInterfaceType()
            {
                return typeof(ICalculator);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((ICalculator)__target).Concat(a, b);
                return (IValueGetable)(new Concat_Return { v = __v });
            }
        }

        public class Concat_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.String v;

            public Type GetInterfaceType()
            {
                return typeof(ICalculator);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class Sum_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.Int32 a;
            public System.Int32 b;

            public Type GetInterfaceType()
            {
                return typeof(ICalculator);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((ICalculator)__target).Sum(a, b);
                return (IValueGetable)(new Sum_Return { v = __v });
            }
        }

        public class Sum_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Int32 v;

            public Type GetInterfaceType()
            {
                return typeof(ICalculator);
            }

            public object Value
            {
                get { return v; }
            }
        }
    }

    public interface ICalculator_NoReply
    {
        void Concat(System.String a, System.String b);
        void Sum(System.Int32 a, System.Int32 b);
    }

    public class CalculatorRef : InterfacedActorRef, ICalculator, ICalculator_NoReply
    {
        public CalculatorRef() : base(null)
        {
        }

        public CalculatorRef(IRequestTarget target) : base(target)
        {
        }

        public CalculatorRef(IRequestTarget target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
        }

        public CalculatorRef(IActorRef actor) : base(new AkkaActorTarget(actor))
        {
        }

        public CalculatorRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(new AkkaActorTarget(actor), requestWaiter, timeout)
        {
        }

        public static implicit operator CalculatorRef(TypedActorRef typedActor)
        {
            InterfacedActorOfExtensions.CheckIfActorImplementsOrThrow(typedActor.Type, typeof(ICalculator));
            return new CalculatorRef(typedActor.Actor);
        }

        public IActorRef Actor => ((AkkaActorTarget)Target)?.Actor;

        public ICalculator_NoReply WithNoReply()
        {
            return this;
        }

        public CalculatorRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new CalculatorRef(Target, requestWaiter, Timeout);
        }

        public CalculatorRef WithTimeout(TimeSpan? timeout)
        {
            return new CalculatorRef(Target, RequestWaiter, timeout);
        }

        public Task<System.String> Concat(System.String a, System.String b)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICalculator_PayloadTable.Concat_Invoke { a = a, b = b }
            };
            return SendRequestAndReceive<System.String>(requestMessage);
        }

        public Task<System.Int32> Sum(System.Int32 a, System.Int32 b)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICalculator_PayloadTable.Sum_Invoke { a = a, b = b }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }

        void ICalculator_NoReply.Concat(System.String a, System.String b)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICalculator_PayloadTable.Concat_Invoke { a = a, b = b }
            };
            SendRequest(requestMessage);
        }

        void ICalculator_NoReply.Sum(System.Int32 a, System.Int32 b)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICalculator_PayloadTable.Sum_Invoke { a = a, b = b }
            };
            SendRequest(requestMessage);
        }
    }

    [AlternativeInterface(typeof(ICalculator))]
    public interface ICalculatorSync : IInterfacedActorSync
    {
        System.String Concat(System.String a, System.String b);
        System.Int32 Sum(System.Int32 a, System.Int32 b);
    }
}

#endregion
#region SlimHttp.Interface.ICounter

namespace SlimHttp.Interface
{
    [PayloadTable(typeof(ICounter), PayloadTableKind.Request)]
    public static class ICounter_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(GetCounter_Invoke), typeof(GetCounter_Return) },
                { typeof(IncCounter_Invoke), null },
            };
        }

        public class GetCounter_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType()
            {
                return typeof(ICounter);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((ICounter)__target).GetCounter();
                return (IValueGetable)(new GetCounter_Return { v = __v });
            }
        }

        public class GetCounter_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Int32 v;

            public Type GetInterfaceType()
            {
                return typeof(ICounter);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class IncCounter_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.Int32 delta;

            public Type GetInterfaceType()
            {
                return typeof(ICounter);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                await ((ICounter)__target).IncCounter(delta);
                return null;
            }
        }
    }

    public interface ICounter_NoReply
    {
        void GetCounter();
        void IncCounter(System.Int32 delta);
    }

    public class CounterRef : InterfacedActorRef, ICounter, ICounter_NoReply
    {
        public CounterRef() : base(null)
        {
        }

        public CounterRef(IRequestTarget target) : base(target)
        {
        }

        public CounterRef(IRequestTarget target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
        }

        public CounterRef(IActorRef actor) : base(new AkkaActorTarget(actor))
        {
        }

        public CounterRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(new AkkaActorTarget(actor), requestWaiter, timeout)
        {
        }

        public static implicit operator CounterRef(TypedActorRef typedActor)
        {
            InterfacedActorOfExtensions.CheckIfActorImplementsOrThrow(typedActor.Type, typeof(ICounter));
            return new CounterRef(typedActor.Actor);
        }

        public IActorRef Actor => ((AkkaActorTarget)Target)?.Actor;

        public ICounter_NoReply WithNoReply()
        {
            return this;
        }

        public CounterRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new CounterRef(Target, requestWaiter, Timeout);
        }

        public CounterRef WithTimeout(TimeSpan? timeout)
        {
            return new CounterRef(Target, RequestWaiter, timeout);
        }

        public Task<System.Int32> GetCounter()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICounter_PayloadTable.GetCounter_Invoke {  }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }

        public Task IncCounter(System.Int32 delta)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICounter_PayloadTable.IncCounter_Invoke { delta = delta }
            };
            return SendRequestAndWait(requestMessage);
        }

        void ICounter_NoReply.GetCounter()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICounter_PayloadTable.GetCounter_Invoke {  }
            };
            SendRequest(requestMessage);
        }

        void ICounter_NoReply.IncCounter(System.Int32 delta)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new ICounter_PayloadTable.IncCounter_Invoke { delta = delta }
            };
            SendRequest(requestMessage);
        }
    }

    [AlternativeInterface(typeof(ICounter))]
    public interface ICounterSync : IInterfacedActorSync
    {
        System.Int32 GetCounter();
        void IncCounter(System.Int32 delta);
    }
}

#endregion
#region SlimHttp.Interface.IGreeter

namespace SlimHttp.Interface
{
    [PayloadTable(typeof(IGreeter), PayloadTableKind.Request)]
    public static class IGreeter_PayloadTable
    {
        public static Type[,] GetPayloadTypes()
        {
            return new Type[,] {
                { typeof(GetCount_Invoke), typeof(GetCount_Return) },
                { typeof(Greet_Invoke), typeof(Greet_Return) },
            };
        }

        public class GetCount_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public Type GetInterfaceType()
            {
                return typeof(IGreeter);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IGreeter)__target).GetCount();
                return (IValueGetable)(new GetCount_Return { v = __v });
            }
        }

        public class GetCount_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Int32 v;

            public Type GetInterfaceType()
            {
                return typeof(IGreeter);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class Greet_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.String name;

            public Type GetInterfaceType()
            {
                return typeof(IGreeter);
            }

            public async Task<IValueGetable> InvokeAsync(object __target)
            {
                var __v = await ((IGreeter)__target).Greet(name);
                return (IValueGetable)(new Greet_Return { v = __v });
            }
        }

        public class Greet_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.String v;

            public Type GetInterfaceType()
            {
                return typeof(IGreeter);
            }

            public object Value
            {
                get { return v; }
            }
        }
    }

    public interface IGreeter_NoReply
    {
        void GetCount();
        void Greet(System.String name);
    }

    public class GreeterRef : InterfacedActorRef, IGreeter, IGreeter_NoReply
    {
        public GreeterRef() : base(null)
        {
        }

        public GreeterRef(IRequestTarget target) : base(target)
        {
        }

        public GreeterRef(IRequestTarget target, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(target, requestWaiter, timeout)
        {
        }

        public GreeterRef(IActorRef actor) : base(new AkkaActorTarget(actor))
        {
        }

        public GreeterRef(IActorRef actor, IRequestWaiter requestWaiter, TimeSpan? timeout = null) : base(new AkkaActorTarget(actor), requestWaiter, timeout)
        {
        }

        public static implicit operator GreeterRef(TypedActorRef typedActor)
        {
            InterfacedActorOfExtensions.CheckIfActorImplementsOrThrow(typedActor.Type, typeof(IGreeter));
            return new GreeterRef(typedActor.Actor);
        }

        public IActorRef Actor => ((AkkaActorTarget)Target)?.Actor;

        public IGreeter_NoReply WithNoReply()
        {
            return this;
        }

        public GreeterRef WithRequestWaiter(IRequestWaiter requestWaiter)
        {
            return new GreeterRef(Target, requestWaiter, Timeout);
        }

        public GreeterRef WithTimeout(TimeSpan? timeout)
        {
            return new GreeterRef(Target, RequestWaiter, timeout);
        }

        public Task<System.Int32> GetCount()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IGreeter_PayloadTable.GetCount_Invoke {  }
            };
            return SendRequestAndReceive<System.Int32>(requestMessage);
        }

        public Task<System.String> Greet(System.String name)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IGreeter_PayloadTable.Greet_Invoke { name = name }
            };
            return SendRequestAndReceive<System.String>(requestMessage);
        }

        void IGreeter_NoReply.GetCount()
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IGreeter_PayloadTable.GetCount_Invoke {  }
            };
            SendRequest(requestMessage);
        }

        void IGreeter_NoReply.Greet(System.String name)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IGreeter_PayloadTable.Greet_Invoke { name = name }
            };
            SendRequest(requestMessage);
        }
    }

    [AlternativeInterface(typeof(IGreeter))]
    public interface IGreeterSync : IInterfacedActorSync
    {
        System.Int32 GetCount();
        System.String Greet(System.String name);
    }
}

#endregion
#region SlimHttp.Interface.IPedantic

namespace SlimHttp.Interface
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

        public class TestOptional_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.Nullable<System.Int32> value;

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

        public class TestOptional_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Nullable<System.Int32> v;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class TestParams_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.Int32[] values;

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

        public class TestParams_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Int32[] v;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class TestPassClass_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public SlimHttp.Interface.TestParam param;

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

        public class TestPassClass_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.String v;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class TestReturnClass_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.Int32 value;
            public System.Int32 offset;

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

        public class TestReturnClass_Return
            : IInterfacedPayload, IValueGetable
        {
            public SlimHttp.Interface.TestResult v;

            public Type GetInterfaceType()
            {
                return typeof(IPedantic);
            }

            public object Value
            {
                get { return v; }
            }
        }

        public class TestTuple_Invoke
            : IInterfacedPayload, IAsyncInvokable
        {
            public System.Tuple<System.Int32, System.String> value;

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

        public class TestTuple_Return
            : IInterfacedPayload, IValueGetable
        {
            public System.Tuple<System.Int32, System.String> v;

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
        void TestPassClass(SlimHttp.Interface.TestParam param);
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

        public Task<System.String> TestPassClass(SlimHttp.Interface.TestParam param)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestPassClass_Invoke { param = param }
            };
            return SendRequestAndReceive<System.String>(requestMessage);
        }

        public Task<SlimHttp.Interface.TestResult> TestReturnClass(System.Int32 value, System.Int32 offset)
        {
            var requestMessage = new RequestMessage {
                InvokePayload = new IPedantic_PayloadTable.TestReturnClass_Invoke { value = value, offset = offset }
            };
            return SendRequestAndReceive<SlimHttp.Interface.TestResult>(requestMessage);
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

        void IPedantic_NoReply.TestPassClass(SlimHttp.Interface.TestParam param)
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

    [AlternativeInterface(typeof(IPedantic))]
    public interface IPedanticSync : IInterfacedActorSync
    {
        void TestCall();
        System.Nullable<System.Int32> TestOptional(System.Nullable<System.Int32> value);
        System.Int32[] TestParams(params System.Int32[] values);
        System.String TestPassClass(SlimHttp.Interface.TestParam param);
        SlimHttp.Interface.TestResult TestReturnClass(System.Int32 value, System.Int32 offset);
        System.Tuple<System.Int32, System.String> TestTuple(System.Tuple<System.Int32, System.String> value);
    }
}

#endregion
