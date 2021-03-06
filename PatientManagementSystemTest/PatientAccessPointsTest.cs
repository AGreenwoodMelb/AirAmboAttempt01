using PatientManagementSystem.Patients.PatientAccessPoints;
using Xunit;

namespace PatientManagementSystemTest
{
    public class PatientAccessPointsTest
    {
        AccessPoints APs;

        private void Setup()
        {
            APs = new AccessPoints();
        }

        [Fact]
        public void DefaultAccessPointsValid()
        {
            Setup();

            Assert.NotNull(APs);

            Assert.NotNull(APs.ArtificialAirway);
            Assert.NotNull(APs.UrinaryCatheter);
            Assert.NotNull(APs.IVs);
        }

        [Fact]
        public void DefaultCerebralShuntValid()
        {
            Setup();
            Assert.NotNull(APs.CerebralShunt);
            Assert.False(APs.CerebralShunt.IsInserted);
            Assert.False(APs.CerebralShunt.IsBlocked);
        }

        [Fact]
        public void CerebralShuntAddRemoveValid()
        {
            Setup();
            Assert.False(APs.CerebralShunt.IsInserted);
            APs.CerebralShunt.IsInserted = true;
            Assert.True(APs.CerebralShunt.IsInserted);
            APs.CerebralShunt.Remove();
            Assert.False(APs.CerebralShunt.IsInserted);
            Assert.Equal(-1f, APs.CerebralShunt.OpeningCerebralPressure);
        }

        [Fact]
        public void DefaultArtificialAirwayValid()
        {
            Setup();
            Assert.NotNull(APs.ArtificialAirway);
            Assert.False(APs.ArtificialAirway.IsInserted);
            Assert.False(APs.ArtificialAirway.IsBlocked);
        }

        [Fact]
        public void ArtificialAirwayInsertRemoveValid()
        {
            Setup();
            Assert.False(APs.ArtificialAirway.IsInserted);
            APs.ArtificialAirway.Insert(ArtificialAirwayType.LaryngealMask);
            Assert.Equal(ArtificialAirwayType.LaryngealMask, APs.ArtificialAirway.AirwayType);
            Assert.NotEqual(ArtificialAirwayType.FaceMask, APs.ArtificialAirway.AirwayType);
            APs.ArtificialAirway.Remove();
            Assert.Equal(ArtificialAirwayType.None, APs.ArtificialAirway.AirwayType);
        }

        [Fact]
        public void DefaultUrinaryCatheter()
        {
            Setup();
            Assert.NotNull(APs.UrinaryCatheter);
            Assert.False(APs.UrinaryCatheter.IsInserted);
            Assert.False(APs.UrinaryCatheter.IsBlocked);
        }

        [Fact]
        public void UrinaryCatheterAddRemoveValid()
        {
            Setup();
            Assert.False(APs.UrinaryCatheter.IsInserted);
            APs.UrinaryCatheter.IsInserted = true;
            Assert.True(APs.UrinaryCatheter.IsInserted);
            APs.UrinaryCatheter.Remove();
            Assert.False(APs.UrinaryCatheter.IsInserted);
        }

        [Fact]
        public void DefaultIVsValid()
        {
            Setup();
            Assert.False(APs.IVs[IVTargetLocation.ArmLeft].IsInserted);
            Assert.False(APs.IVs[IVTargetLocation.ArmLeft].IsBlocked);
            Assert.False(APs.HasIVAccess);
        }

        [Fact]
        public void IVsAddRemoveValid()
        {
            Setup();
            Assert.False(APs.IVs[IVTargetLocation.CentralLine].IsInserted);
            Assert.False(APs.HasIVAccess);
            APs.IVs[IVTargetLocation.CentralLine].IsInserted = true;
            Assert.True(APs.IVs[IVTargetLocation.CentralLine].IsInserted);
            Assert.True(APs.HasIVAccess);
        }
    }
}
