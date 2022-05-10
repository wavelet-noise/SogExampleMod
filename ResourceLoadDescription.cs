using System;
using Sog;
using Ecs;

namespace TestMod
{
    public class ResourceLoadDescription
    {
        public static void Load()
        {
            var sp = new Sprite("Data/test.png", "Data/test_n.png");
            Database<Sprite>.Reg("test", sp);
            var anim = Database<Animation>.Reg("test_walk");

            var pref = Database<EntityPrefab>.Reg("test");
            var render = new Render();

            render.texture = sp.main;

            pref.AddComponent(new Position());
            pref.AddComponent(render);

            anim.MakeRegular(4, 1);
        }
    }
}
