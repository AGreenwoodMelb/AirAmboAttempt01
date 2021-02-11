using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AirAmboAttempt01.Patients.PatientOrgans;

namespace AirAmboAttempt01Test
{
    public class PatientOrganLungsTests
    {
        [Fact]
        public void CreateDefaultLungs()
        {
            Lungs lungs = new Lungs();

            Assert.True(lungs.LeftLung != null && lungs.RightLung != null);
        }

        [Fact]
        public void InsertLungCantPutRightLungInLeftSpot()
        {
            Lungs lungs = new Lungs();

            lungs.RemoveLung(true);
            Assert.False(lungs.InsertLung(new Lung(false)));
        } 

    }
}
