using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDev4.Dawn
{
    public interface IActorEnterExitHandler
    {
        void ActorEnter(GameObject actor);
        void ActorExit(GameObject actor);
    }
}