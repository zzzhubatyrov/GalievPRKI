using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRKI
{
    public class MusicBand
    {
        public string BandType { get; set; }
        public List<string> Members { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"BandType: {BandType}, Members: {string.Join(", ", Members)}";
        }
    }

    public interface IMusicBandBuilder
    {
        void SetBandType();
        void AddMembers();
        MusicBand GetBand();
    }

    public class SingingBandBuilder : IMusicBandBuilder
    {
        private MusicBand _band = new MusicBand();

        public void SetBandType()
        {
            _band.BandType = "Singing";
        }

        public void AddMembers()
        {
            _band.Members.Add("Singer 1");
            _band.Members.Add("Singer 2");
        }

        public MusicBand GetBand()
        {
            return _band;
        }
    }

    public class DancingBandBuilder : IMusicBandBuilder
    {
        private MusicBand _band = new MusicBand();

        public void SetBandType()
        {
            _band.BandType = "Dancing";
        }

        public void AddMembers()
        {
            _band.Members.Add("Dancer 1");
            _band.Members.Add("Dancer 2");
        }

        public MusicBand GetBand()
        {
            return _band;
        }
    }

    public class MixedBandBuilder : IMusicBandBuilder
    {
        private MusicBand _band = new MusicBand();

        public void SetBandType()
        {
            _band.BandType = "Mixed";
        }

        public void AddMembers()
        {
            _band.Members.Add("Singer 1");
            _band.Members.Add("Dancer 1");
        }

        public MusicBand GetBand()
        {
            return _band;
        }
    }

    public class BandDirector
    {
        public void Construct(IMusicBandBuilder bandBuilder)
        {
            bandBuilder.SetBandType();
            bandBuilder.AddMembers();
        }
    }
}
