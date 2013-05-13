using System.Collections.Generic;
using DragonAid.Lib.Data;
using DragonAid.Lib.Data.Model;

namespace DragonAid.WindowsClient.ViewModel
{
    public sealed class SampleDataSource
    {
        public SampleDataSource()
        {
            AllParties = new AllPartiesViewModel(HardCodedSampleData.SampleParties, HardCodedSampleData.SampleCharacters);
        }

        public AllPartiesViewModel AllParties { get; private set; }
    }
}
