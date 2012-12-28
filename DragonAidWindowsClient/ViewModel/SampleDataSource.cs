using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonAidLib.Data.Model;

namespace DragonAidWindowsClient.ViewModel
{
    public sealed class SampleDataSource
    {
        private List<Character> _sampleCharacters = new List<Character>
            {
                new Character
                    {
                        Id = 1,
                        Name = "Bob",
                        Title = "Conjurer of Gas",
                        Description = "A man from a place",
                        ImageUri = null,
                        PlayerName = "Me",
                        IsMine = true,
                        PartyId = 3,
                    },
                new Character
                    {
                        Id = 2,
                        Name = "Carl",
                        Title = "Hitter of things",
                        Description = "A man from a slightly different place",
                        ImageUri = null,
                        PlayerName = "Me",
                        IsMine = false,
                        PartyId = 3,
                    },
                new Character
                    {
                        Id = 3,
                        Name = "Duncan",
                        Title = "Smiter of dudes",
                        Description = "A man from a a third different place",
                        ImageUri = null,
                        PlayerName = "Me",
                        IsMine = true,
                        PartyId = 4,
                    },
                new Character
                    {
                        Id = 4,
                        Name = "Muscles",
                        Title = "Nazi Hunter",
                        Description = "Unknown and at large",
                        ImageUri = null,
                        PlayerName = "Dan",
                        IsMine = false,
                        PartyId = 1,
                    },
                new Character
                    {
                        Id = 5,
                        Name = "That new guy",
                        Title = "Mind Twister",
                        Description = "Unknown and at hobbling pace",
                        ImageUri = null,
                        PlayerName = "Matt",
                        IsMine = false,
                        PartyId = 1,
                    },
                new Character
                    {
                        Id = 6,
                        Name = "Pirate A",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 1",
                        IsMine = false,
                        PartyId = 2,
                    },
                new Character
                    {
                        Id = 7,
                        Name = "Pirate B",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 2",
                        IsMine = false,
                        PartyId = 2,
                    },
                new Character
                    {
                        Id = 8,
                        Name = "Pirate C",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 3",
                        IsMine = false,
                        PartyId = 2,
                    },
                new Character
                    {
                        Id = 9,
                        Name = "Pirate D",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 4",
                        IsMine = false,
                        PartyId = 2,
                    },
                new Character
                    {
                        Id = 10,
                        Name = "Pirate E",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 5",
                        IsMine = false,
                        PartyId = 2,
                    },
                new Character
                    {
                        Id = 11,
                        Name = "Pirate F",
                        Title = "Pirate",
                        Description = "He swashbuckles and stuff",
                        ImageUri = null,
                        PlayerName = "Player 6",
                        IsMine = false,
                        PartyId = 2,
                    },
            };

        private List<Party> _sampleParties = new List<Party>
            {
                new Party
                    {
                        Id = 1,
                        Title = "Our Tuesday Game",
                        Description = "Fun Tuesday fun times",
                        GameMasterName = "Me",
                        ImageUri = null
                    },
                new Party
                    {
                        Id = 2,
                        Title = "The Land Of Moordoor",
                        Description = "Where the shadows (of sunken boats) lie",
                        GameMasterName = "Me",
                        ImageUri = null
                    }
            };

        public SampleDataSource()
        {
            AllParties = new AllPartiesViewModel(_sampleParties, _sampleCharacters);
        }

        public AllPartiesViewModel AllParties { get; private set; }
    }
}
