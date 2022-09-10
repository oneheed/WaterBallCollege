// See https://aka.ms/new-console-template for more information
using C3M1H1_Youtube.Models;

var pewDiePie = new Channel("PewDiePie");
var waterBallCollege = new Channel("水球軟體學院");

var channels = new List<Channel> {
    pewDiePie,
    waterBallCollege,
};

var subscribeies = new List<Subscriber>
{
    new Subscriber("水球", (subscriber, video) => {
        if(video.Length >= TimeSpan.FromMinutes(3))
            video.Like(subscriber.Name);
    }),
    new Subscriber("火球", (subscriber, video) => {
        if(video.Length <= TimeSpan.FromMinutes(1))
            video.GetChannel().Unsubscribe(subscriber);
    }),
};

foreach (var subscriber in subscribeies)
{
    foreach (var channel in channels)
    {
        channel.Subscribe(subscriber);
    }
}

waterBallCollege.Upload(new Video("C1M1S2", "這個世界正是物件導向的呢！", TimeSpan.FromMinutes(4)));
pewDiePie.Upload(new Video("Hello guys", "Clickbait", TimeSpan.FromSeconds(30)));
waterBallCollege.Upload(new Video("C1M1S3", "物件 vs. 類別", TimeSpan.FromMinutes(1)));
pewDiePie.Upload(new Video("Minecraft", "Let’s play Minecraft", TimeSpan.FromMinutes(30)));