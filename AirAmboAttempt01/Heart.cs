namespace PatientManagementSystem.Patients.PatientOrgans
{

    public enum VesselState
    {
        Normal,
        Narrowed,
        Blocked,
    }
    public enum TissueState
    {
        Normal,
        Ishaemic,
        Dead,
    }
    public enum OrganSize
    {
        Normal,
        Smaller,
        Larger,
    }

    public class HeartStructures
    {
        public HeartVessels Vessels;
        public HeartTissues Tissues;

        public HeartStructures(HeartVessels vessels = null, HeartTissues tissues = null)
        {
            Vessels = vessels ?? new HeartVessels();
            Tissues = tissues ?? new HeartTissues();
        }
    }

    public class HeartVessels
    {
        #region LeftCoronaryArteries
        public VesselState LCA { get; set; }
        public VesselState LAD { get; set; }
        public VesselState LCircA { get; set; }
        #endregion

        #region RightCoronaryArteries
        public VesselState RCA { get; set; }
        public VesselState PDA { get; set; }
        public VesselState RMA { get; set; }
        #endregion

        public HeartVessels(VesselState lCA = VesselState.Normal, VesselState lAD = VesselState.Normal, VesselState lCircA = VesselState.Normal, VesselState pDA = VesselState.Normal, VesselState rCA = VesselState.Normal, VesselState rMA = VesselState.Normal)
        {
            LCA = lCA;
            LAD = lAD;
            LCircA = lCircA;
            PDA = pDA;
            RCA = rCA;
            RMA = rMA;
        }
    }

    public class HeartTissues
    {
        #region HeartTissue
        public TissueState Septum { get; set; }
        public TissueState LeftAnteriorWall { get; set; }
        public TissueState LeftPosteriorInferiorWall { get; set; }
        public TissueState FreeWall { get; set; }
        public TissueState RightVentricle { get; set; }
        #endregion

        public HeartTissues(TissueState septum = TissueState.Normal, TissueState leftAnteriorWall = TissueState.Normal, TissueState leftPosteriorInferiorWall = TissueState.Normal, TissueState freeWall = TissueState.Normal, TissueState rightVentricle = TissueState.Normal)
        {
            Septum = septum;
            LeftAnteriorWall = leftAnteriorWall;
            LeftPosteriorInferiorWall = leftPosteriorInferiorWall;
            FreeWall = freeWall;
            RightVentricle = rightVentricle;
        }
    }
}
