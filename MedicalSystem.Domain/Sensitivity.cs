namespace MedicalSystem.Domain
{
    public class Sensitivity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MedicalHistoryId { get; set; }
    }
}