namespace DragonAidLib.Data.Model
{
    public sealed class Party
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }

        // Intentionally unrelated to the internal userId
        public string GameMasterName { get; set; }
    }
}