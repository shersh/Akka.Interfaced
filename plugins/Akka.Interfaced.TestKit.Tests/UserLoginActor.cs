﻿using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using Akka.Actor;

namespace Akka.Interfaced.TestKit.Tests
{
    public class UserLoginActor : InterfacedActor, IUserLogin
    {
        private readonly IActorRef _actorBoundChannel;

        public UserLoginActor(IActorRef actorBoundChannel)
        {
            _actorBoundChannel = actorBoundChannel;
        }

        public async Task<IUser> Login(string id, string password, IUserObserver observer)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            // Check account

            var ok = CheckAccount(id, password);
            if (ok == false)
                throw new InvalidCredentialException();

            // Make UserActor and bind it

            var user = Context.System.ActorOf(Props.Create(() => new UserActor(id, observer)));

            var reply = await _actorBoundChannel.Ask<ActorBoundChannelMessage.BindReply>(
                new ActorBoundChannelMessage.Bind(user, typeof(IUser)));

            return new UserRef(new BoundActorTarget(reply.ActorId));
        }

        private bool CheckAccount(string id, string password)
        {
            return id == password;
        }
    }
}
