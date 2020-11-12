using System.ComponentModel;

namespace IMDB_Storage.Core
{
    public enum Genre
    {
        Action,
        Animation,
        Adventure,
        Family,
        Musical,
        History,
        Mystery,
        Comedy, 
        Horror, 
        Drama, 
        Fantasy, 
        Romance, 
        Thriller, 
        Biography,
        War,
        Crime,
        News,
        Sport,
        Western,
        Documentary,
        [Description("Film-Noir")] FilmNoir,
        Music,
        [Description("Reality-Tv")] RealityTv,
        [Description("Talk-Show")] TalkShow,
        [Description("Game-Show")] GameShow,
        [Description("Sci-Fi")] SciFi,
    }
}
