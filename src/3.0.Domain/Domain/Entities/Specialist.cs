namespace Domain.Entities
{
    public class Specialist : Base
    {
        public string Name { get; set; }
        public AcademicFormation AcademicFormation { get; set; }

        public void DefineSpecialty(AcademicFormation academicFormation, Specialty specialty)
        {
            
        }
    }
}