using CsvHelper.Configuration.Attributes;

namespace BoardGameAssistant.Entities.Planner;

public class BggGameData
{
    [Name("id")]
    public int Id { get; set; }

    [Name("name")]
    public string Name { get; set; }

    [Name("yearpublished")]
    public int YearPublished { get; set; }

    [Name("rank")]
    public int Rank { get; set; }

    [Name("bayesaverage")]
    public double? BayesAverage { get; set; }

    [Name("average")]
    public double? Average { get; set; }

    [Name("usersrated")]
    public double? UsersRated { get; set; }

    [Name("is_expansion")]
    public bool IsExpansion { get; set; }

    [Name("abstracts_rank")]
    public double? AbstractsRank { get; set; }

    [Name("cgs_rank")]
    public double? CgsRank { get; set; }

    [Name("childrensgames_rank")]
    public double? ChildrensGamesRank { get; set; }

    [Name("familygames_rank")]
    public double? FamilyGamesRank { get; set; }

    [Name("partygames_rank")]
    public double? PartyGamesRank { get; set; }

    [Name("strategygames_rank")]
    public double? StrategyGamesRank { get; set; }

    [Name("thematic_rank")]
    public double? ThematicRank { get; set; }

    [Name("wargames_rank")]
    public double? WarGamesRank { get; set; }
}