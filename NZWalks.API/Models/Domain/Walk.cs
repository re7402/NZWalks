namespace NZWalks.API.Models.Domain
{
    public class Walk
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageURL { get; set; }

        public Guid RegionId { get; set; }

        public Guid DifficultyId { get; set; }

        //Navigation property
        public Difficulty difficulty { get; set; }

        public Region region { get; set; }
    }
}
