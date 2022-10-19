// See https://aka.ms/new-console-template for more information
using C3BOSS_RPG;
using C3BOSS_RPG.Enums;
using C3BOSS_RPG.Roles;
using C3BOSS_RPG.Skills;

var ally = new Troop();
ally.Join(new Hero(500, 10000, 30, "英雄", new List<Skill> { new Cheerup() }));
ally.Join(new Role(10000, 0, 0, "Servant1", new List<Skill> { }));
ally.Join(new Role(10000, 0, 0, "Servant2", new List<Skill> { }));
ally.Join(new Role(10000, 0, 0, "Servant3", new List<Skill> { }));

var enemy = new Troop();
enemy.Join(new Role(500, 0, 0, "Slime1", new List<Skill> { new Cheerup() }));

var troops = new Dictionary<TroopType, Troop>
{
    { TroopType.Ally, ally },
    { TroopType.Enemy, enemy },
};

var battle = new Battle(troops);
battle.BattlStart();
battle.BattlProcess();