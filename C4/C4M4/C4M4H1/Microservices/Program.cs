// See https://aka.ms/new-console-template for more information
// 定義根日誌器
using C4M4H1;
using Microservices.Logger;

// (1)
var root = new Logger(LevelType.DEBUG, exporter: new ConsoleExporter(), layout: new StandardLayout());

// 定義 app.game 日誌器，繼承根日誌器並覆寫分級門檻和輸出器
var gameLogger = new Logger(LevelType.INFO, parent: root, name: "app.game",
    exporter: new CompositeExporter(
        new ConsoleExporter(),
        new CompositeExporter(new FileExporter("game.log"), new FileExporter("game.backup.log"))
    ));

// 定義 app.game.ai 日誌器，繼承 app.game 日誌器並覆寫分級門檻
var aiLogger = new Logger(LevelType.TRACE, parent: gameLogger, name: "app.game.ai", layout: new StandardLayout());

// 配置剛定義好的三個日誌器
Logger.DeclareLoggers(root, gameLogger, aiLogger);

//// (2)
//Logger.GenerateFormConfig("appsettings.json");

// 創建遊戲物件，並執行遊戲
var game = new Game();
game.Start();

