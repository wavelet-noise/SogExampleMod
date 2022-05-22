using System;
using Sog;
using Ecs;

namespace TestMod
{
    public class ResourceLoadDescription
    {
        public static void Load()
        {
            var zom = LoadZombie();

            var com_cre = Database<CreaturePool>.Get("common_creatures");
            com_cre.Add(zom);

            com_cre = Database<CreaturePool>.Get("heroes");
            com_cre.Add(zom);
        }

        public static CreatureProto CreatureLoadHelper(string name)
        {
            var idle_sprite = Database<Sprite>.Get(name + "_walk");
            idle_sprite.main = Sprite.LoadPng("sprites/" + name + "_walk.png");
            idle_sprite.normal = Sprite.LoadPng("sprites/" + name + "_walk_n.png");

            var walk_animation = Database<Animation>.Get(name + "_walk");
            walk_animation.sprite = idle_sprite;

            var creature_set = Database<AnimationSet>.Get(name);
            creature_set.Add("walk", walk_animation);

            idle_sprite = Database<Sprite>.Get(name + "_idle");
            idle_sprite.main = Sprite.LoadPng("sprites/" + name + "_idle.png");
            idle_sprite.normal = Sprite.LoadPng("sprites/" + name + "_idle_n.png");

            creature_set.Add("idle", walk_animation);

            var creature = Database<CreatureProto>.Get(name);
            creature.animation = creature_set;
            creature.AddComponent(new Ecs.Position());
            creature.AddComponent(new Ecs.Render());
            creature.AddComponent(new Ecs.Trace());

            return creature;
        }

        public static CreatureProto LoadZombie()
        {
            var zomb = Database<Sprite>.Get("zombie_walk");
            zomb.main = Sprite.LoadPng("sprites/zombie_walk.png");
            zomb.normal = Sprite.LoadPng("sprites/zombie_walk_n.png");

            var zomb_a = Database<Animation>.Get("zombie_walk");
            zomb_a.sprite = zomb;

            var zomb_set = Database<AnimationSet>.Get("zombie");
            zomb_set.Add("walk", zomb_a);

            zomb = Database<Sprite>.Get("zombie_idle");
            zomb.main = Sprite.LoadPng("sprites/zombie_idle.png");
            zomb.normal = Sprite.LoadPng("sprites/zombie_idle_n.png");

            zomb_set.Add("idle", zomb_a);

            var zombie = Database<CreatureProto>.Get("zombie");
            zombie.animation = zomb_set;
            zombie.AddComponent(new Ecs.Position());
            zombie.AddComponent(new Ecs.Render());
            zombie.AddComponent(new Ecs.Trace());

            return zombie;
        }
    }
}
