# :tada: Welcome to `NekosAPI.NET` repository
[![wakatime](https://wakatime.com/badge/user/17f322c9-222a-48b4-9e15-983c41f7aed4/project/018e56c4-387c-49e7-adbb-0492e1297ae3.svg)](https://wakatime.com/badge/user/17f322c9-222a-48b4-9e15-983c41f7aed4/project/018e56c4-387c-49e7-adbb-0492e1297ae3)
[![GH_UserCount](https://badgen.net/github/dependents-repo/MarkenJaden/NekosAPI.NET)](https://github.com/MarkenJaden/NekosAPI.NET/network/dependents)
[![NG_LatestVersion](https://badgen.net/nuget/v/NekosAPI.NET/latest)](https://www.nuget.org/packages/NekosAPI.NET/)
[![NG_DLCount](https://badgen.net/nuget/dt/NekosAPI.NET)](https://www.nuget.org/packages/NekosAPI.NET/)
[![Discord_MemberCount](https://badgen.net/discord/members/ZZGTwCZprC)](https://discord.gg/ZZGTwCZprC)

`NekosAPI.NET` is an asynchronous library to interact with [NekosAPI](https://nekosapi.com/) API, currently
supporting v3 API. If you love this repo, consider giving it a star :star:

# :question: How to use
### Version 3
```c#
namespace Hello.There.Nekos;

public class Program
{
    public async Task ExecuteMeAsync()
    {
        //for more infos about the possible options check https://nekosapi.com/docs/images/random#parameters
        //tag 8 = catgirls
        var images = await _client.ImagesAsync(rating: ["safe"], tag: [8], limit: 3);
        foreach (var item in images.Items)
        {
            //Do whatever you want to do with this
            Console.WriteLine(item.Image_url);
        }
    }
}
```
