// See https://aka.ms/new-console-template for more information
using RpgBattleGame;
using RpgBattleGame.Utilities;

//var battle = TestCaseUtility.ConvertBattleByFile("Sources/cheerup.in");
//var battle = TestCaseUtility.ConvertBattleByFile("Sources/curse.in");
//var battle = TestCaseUtility.ConvertBattleByFile("Sources/one-punch.in");
//var battle = TestCaseUtility.ConvertBattleByFile("Sources/only-basic-attack.in");
//var battle = TestCaseUtility.ConvertBattleByFile("Sources/petrochemical.in");
//var battle = TestCaseUtility.ConvertBattleByFile("Sources/poison.in");
//var battle = TestCaseUtility.ConvertBattleByFile("Sources/self-explosion.in");
//var battle = TestCaseUtility.ConvertBattleByFile("Sources/self-healing.in");
//var battle = TestCaseUtility.ConvertBattleByFile("Sources/summon.in");
var battle = TestCaseUtility.ConvertBattleByFile("Sources/waterball-and-fireball-1v2.in");

var rpgGame = new RpgGame(battle);
rpgGame.Start();

