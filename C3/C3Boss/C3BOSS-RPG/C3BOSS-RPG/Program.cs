// See https://aka.ms/new-console-template for more information
using C3BOSS_RPG;
using C3BOSS_RPG.Roles;
using C3BOSS_RPG.Skills;

// cheerup
//var ally = new Troop("軍隊-1", new List<Role>());
//ally.Join(new Hero(500, 10000, 30, "英雄", new List<Skill> { new Cheerup() }));
//ally.Join(new Role(1000, 0, 0, "Servant1", new List<Skill> { }));
//ally.Join(new Role(1000, 0, 0, "Servant2", new List<Skill> { }));
//ally.Join(new Role(1000, 0, 0, "Servant3", new List<Skill> { }));
//ally.Join(new Role(1000, 0, 0, "Servant4", new List<Skill> { }));
//ally.Join(new Role(1000, 0, 0, "Servant5", new List<Skill> { }));

//var enemy = new Troop("軍隊-2", new List<Role>());
//enemy.Join(new Role(500, 0, 0, "Slime1", new List<Skill> { }));

// curse
var ally = new Troop("軍隊-1", new List<Role>());
ally.Join(new Hero(300, 10000, 100, "英雄", new List<Skill> { new Curse() }));
ally.Join(new Role(600, 100, 30, "Ally", new List<Skill> { new Curse(), new Curse() }));

var enemy = new Troop("軍隊-2", new List<Role>());
enemy.Join(new Role(200, 999, 50, "Slime1", new List<Skill> { }));
enemy.Join(new Role(200, 999, 100, "Slime2", new List<Skill> { }));

// only-basic-attack
//var ally = new Troop("軍隊-1", new List<Role>());
//ally.Join(new Hero(500, 500, 100, "英雄", new List<Skill> { }));
//ally.Join(new Role(200, 200, 70, "WaterTA", new List<Skill> { }));

//var enemy = new Troop("軍隊-2", new List<Role>());
//enemy.Join(new Role(200, 90, 50, "Slime1", new List<Skill> { }));
//enemy.Join(new Role(200, 90, 50, "Slime2", new List<Skill> { }));
//enemy.Join(new Role(200, 9000, 50, "Slime3", new List<Skill> { }));

// petrochemical
//var ally = new Troop("軍隊-1", new List<Role>());
//ally.Join(new Hero(400, 99999, 30, "英雄", new List<Skill> { new Petrochemical() }));

//var enemy = new Troop("軍隊-2", new List<Role>());
//enemy.Join(new Role(270, 9999, 399, "攻擊力超強的BOSS", new List<Skill> { new Petrochemical() }));

// poison
//var ally = new Troop("軍隊-1", new List<Role>());
//ally.Join(new Hero(1000, 500, 0, "英雄", new List<Skill> { new Poison() }));

//var enemy = new Troop("軍隊-2", new List<Role>());
//enemy.Join(new Role(120, 90, 50, "Slime1", new List<Skill> { }));
//enemy.Join(new Role(120, 90, 50, "Slime2", new List<Skill> { }));
//enemy.Join(new Role(120, 9000, 50, "Slime3", new List<Skill> { }));

// self-explosion
//var ally = new Troop("軍隊-1", new List<Role>());
//ally.Join(new Hero(999999, 500, 30, "英雄", new List<Skill> { new SelfExplosion() }));
//ally.Join(new Role(100, 1000, 15, "A", new List<Skill> { }));
//ally.Join(new Role(100, 1000, 15, "B", new List<Skill> { }));
//ally.Join(new Role(100, 1000, 15, "C", new List<Skill> { }));
//ally.Join(new Role(100, 1000, 15, "D", new List<Skill> { }));
//ally.Join(new Role(100, 1000, 15, "E", new List<Skill> { }));
//ally.Join(new Role(100, 1000, 15, "F", new List<Skill> { }));
//ally.Join(new Role(100, 1000, 15, "G", new List<Skill> { }));
//ally.Join(new Role(100, 1000, 15, "H", new List<Skill> { }));
//ally.Join(new Role(100, 1000, 15, "I", new List<Skill> { }));

//var enemy = new Troop("軍隊-2", new List<Role>());
//enemy.Join(new Role(100, 1000, 15, "A", new List<Skill> { }));
//enemy.Join(new Role(100, 1000, 15, "B", new List<Skill> { }));
//enemy.Join(new Role(100, 1000, 15, "C", new List<Skill> { }));
//enemy.Join(new Role(100, 1000, 15, "D", new List<Skill> { }));
//enemy.Join(new Role(100, 1000, 15, "E", new List<Skill> { }));
//enemy.Join(new Role(100, 1000, 15, "F", new List<Skill> { }));
//enemy.Join(new Role(100, 1000, 15, "G", new List<Skill> { }));
//enemy.Join(new Role(100, 1000, 15, "H", new List<Skill> { }));
//enemy.Join(new Role(100, 1000, 15, "I", new List<Skill> { }));

// self-healing
//var ally = new Troop("軍隊-1", new List<Role>());
//ally.Join(new Hero(500, 500, 40, "英雄", new List<Skill> { }));

//var enemy = new Troop("軍隊-2", new List<Role>());
//enemy.Join(new Role(100, 100, 30, "Slime1", new List<Skill> { new SelfHealing() }));

// summon
//var ally = new Troop("軍隊-1", new List<Role>());
//ally.Join(new Hero(500, 10000, 30, "英雄", new List<Skill> { new Summon() }));

//var enemy = new Troop("軍隊-2", new List<Role>());
//enemy.Join(new Role(1000, 0, 99, "Slime1", new List<Skill> { }));


// waterball-and-fireball-1v2
//var ally = new Troop("軍隊-1", new List<Role>());
//ally.Join(new Hero(300, 500, 100, "英雄", new List<Skill> { new Fireball(), new Waterball() }));

//var enemy = new Troop("軍隊-2", new List<Role>());
//enemy.Join(new Role(200, 60, 49, "Slime1", new List<Skill> { new Fireball() }));
//enemy.Join(new Role(200, 200, 50, "Slime2", new List<Skill> { new Fireball(), new Waterball() }));

var troops = new Troop[2]
{
    ally,
    enemy
};

var battle = new Battle(troops);
battle.BattlStart();