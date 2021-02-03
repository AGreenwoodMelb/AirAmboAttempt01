using System;
using System.Collections.Generic;
using System.Text;
using AirAmboAttempt01;
using Xunit;

namespace AirAmboAttempt01Test
{
    public class PatientBloodTest
    {
        #region BloodTransfusionCompatibility
        [Fact]
        public void BloodTransfusionSameTypeSameRhesusCompatible()
        {
            //Arrange
            Blood blood = new Blood(BloodGroup.AB, BloodRhesus.Negative);
            //Assess

            //Assert
            Assert.True(blood.BloodTransfusion(BloodGroup.AB, BloodRhesus.Negative, 600));
        }

        [Fact]
        public void BloodTransfusionSameTypeDifferentRhesusCompatible()
        {
            Blood blood = new Blood(BloodGroup.AB, BloodRhesus.Positive);


            Assert.True(blood.BloodTransfusion(BloodGroup.AB, BloodRhesus.Negative, 600));
        }

        [Fact]
        public void BloodTransfusionDifferentTypeSameRhesusCompatible()
        {
            Blood blood = new Blood(BloodGroup.A, BloodRhesus.Positive);

            Assert.True(blood.BloodTransfusion(BloodGroup.O, BloodRhesus.Positive, 600));
        }
        [Fact]
        public void BloodTransfusionDifferentTypeDifferentRhesusCompatible()
        {
            Blood blood = new Blood(BloodGroup.A, BloodRhesus.Positive);

            Assert.True(blood.BloodTransfusion(BloodGroup.O, BloodRhesus.Negative, 600));
        }
        [Fact]
        public void BloodTransFusionSameTypeDifferentRhesusIncompatible()
        {
            Blood blood = new Blood(BloodGroup.A, BloodRhesus.Negative);

            Assert.False(blood.BloodTransfusion(BloodGroup.A, BloodRhesus.Positive, 600));
        }
        [Fact]
        public void BloodTransfusionDifferentTypeSameRhesusIncompatible()
        {
            Blood blood = new Blood(BloodGroup.B, BloodRhesus.Positive);

            Assert.False(blood.BloodTransfusion(BloodGroup.A, BloodRhesus.Positive, 600));
        }
        [Fact]
        public void BloodTransfusionDifferentTypeDifferentRhesusIncompatible()
        {
            Blood blood = new Blood(BloodGroup.A, BloodRhesus.Positive);

            Assert.False(blood.BloodTransfusion(BloodGroup.B, BloodRhesus.Negative, 600));
        }
        #endregion 

        [Fact]
        public void BloodTransfusionHematocritNormalPlus10pcValid()
        {
            Blood b = new Blood();
           
            b.BloodTransfusion(BloodGroup.O, BloodRhesus.Negative, 600); //10% increase in TBV at 40%

            Assert.True(b.Hematocrit == 0.4f);
        }

        [Fact]
        public void BloodTransfusionHematocritAbnormalPlus100pcValid()
        {
            Blood b = new Blood(0.0f);

            b.BloodTransfusion(BloodGroup.O, BloodRhesus.Negative, 6000);

            Assert.Equal(0.2f, b.Hematocrit);
        }


    }
}
