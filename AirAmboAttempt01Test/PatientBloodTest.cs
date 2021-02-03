using System;
using System.Collections.Generic;
using System.Text;
using AirAmboAttempt01;
using Xunit;

namespace AirAmboAttempt01Test
{
    public class PatientBloodTest
    {
        #region BloodTransfusion
        [Fact]
        public void BloodTransfusionSameTypeSameRhesusCompatible()
        {
            //Arrange
            Blood blood = new Blood(BloodType.AB, false);
            //Assess

            //Assert
            Assert.True(blood.BloodTransfusion(BloodType.AB, false, 600));
        }

        [Fact]
        public void BloodTransfusionSameTypeDifferentRhesusCompatible()
        {
            Blood blood = new Blood(BloodType.AB, true);


            Assert.True(blood.BloodTransfusion(BloodType.AB, false, 600));
        }

        [Fact]
        public void BloodTransfusionDifferentTypeSameRhesusCompatible()
        {
            Blood blood = new Blood(BloodType.A, true);

            Assert.True(blood.BloodTransfusion(BloodType.O, true, 600));
        }
        [Fact]
        public void BloodTransfusionDifferentTypeDifferentRhesusCompatible()
        {
            Blood blood = new Blood(BloodType.A, true);

            Assert.True(blood.BloodTransfusion(BloodType.O, false, 600));
        }
        [Fact]
        public void BloodTransFusionSameTypeDifferentRhesusIncompatible()
        {
            Blood blood = new Blood(BloodType.A, false);

            Assert.False(blood.BloodTransfusion(BloodType.A, true, 600));
        }
        [Fact]
        public void BloodTransfusionDifferentTypeSameRhesusIncompatible()
        {
            Blood blood = new Blood(BloodType.B, true);

            Assert.False(blood.BloodTransfusion(BloodType.A, true, 600));
        }
        [Fact]
        public void BloodTransfusionDifferentTypeDifferentRhesusIncompatible()
        {
            Blood blood = new Blood(BloodType.A, true);

            Assert.False(blood.BloodTransfusion(BloodType.B, false, 600));
        }
        #endregion 

        [Fact]
        public void BloodTransfusionHematocritNormalPlus10pcValid()
        {
            Blood b = new Blood();
           
            b.BloodTransfusion(BloodType.O, false, 600); //10% increase in TBV at 40%

            Assert.True(b.Hematocrit == 0.4f);
        }

        [Fact]
        public void BloodTransfusionHematocritAbnormalPlus100pcValid()
        {
            Blood b = new Blood(0.0f);

            b.BloodTransfusion(BloodType.O, false, 6000);

            Assert.Equal(0.2f, b.Hematocrit);
        }


    }
}
