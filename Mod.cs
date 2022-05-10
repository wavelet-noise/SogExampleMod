using System;
using System.Collections.Generic;
using Leopotam.EcsLite;

namespace TestMod
{
    public class Mod : Sog.Mod
    {
        public override List<IEcsSystem> GetSystems()
        {
            var list = new List<IEcsSystem>();

            list.Add(new ExampleSystem());

            return list;
        }

        public override void Register()
        {
            base.Register();

            ResourceLoadDescription.Load();
        }
    }
}
