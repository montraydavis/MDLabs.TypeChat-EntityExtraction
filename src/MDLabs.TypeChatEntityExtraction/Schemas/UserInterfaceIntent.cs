using System.Text.Json.Serialization;

using Microsoft.TypeChat.Schema;

namespace MDLabs.TypeChatEntityExtraction.Schemas
{
    [method: JsonConstructor]
    public class NamedEntitiesSchema(
        string[]? persons = null,
        string[]? organizations = null,
        string[]? locations = null,
        string[]? dates = null,
        string[]? products = null,
        float[]? monies = null,
        float[]? percentages = null,
        string[]? jobTitles = null,
        string[]? medicalConditions = null,
        string[]? medications = null,
        string[]? dosages = null,
        string[]? medicalProcedures = null,
        //string[]? anatomy = null,
        string[]? symptoms = null
    )
    {
        [Comment("Persons mentioned in the text")]
        public string[]? Persons { get; set; } = persons;

        [Comment("Organizations mentioned in the text")]
        public string[]? Organizations { get; set; } = organizations;

        [Comment("Locations mentioned in the text")]
        public string[]? Locations { get; set; } = locations;

        [Comment("Dates mentioned in the text")]
        public string[]? Dates { get; set; } = dates;

        [Comment("Products mentioned in the text")]
        public string[]? Products { get; set; } = products;

        [Comment("Monetary values mentioned in the text")]
        public float[]? Monies { get; set; } = monies;

        [Comment("Percentages mentioned in the text")]
        public float[]? Percentages { get; set; } = percentages;

        [Comment("Job titles mentioned in the text")]
        public string[]? JobTitles { get; set; } = jobTitles;

        [Comment("Medical conditions mentioned in the text")]
        public string[]? MedicalConditions { get; set; } = medicalConditions;

        [Comment("Medications mentioned in the text")]
        public string[]? Medications { get; set; } = medications;

        [Comment("Dosages mentioned in the text")]
        public string[]? Dosages { get; set; } = dosages;

        [Comment("Medical procedures mentioned in the text")]
        public string[]? MedicalProcedures { get; set; } = medicalProcedures;

        //[Comment("Anatomical terms mentioned in the text")]
        //public string[]? ANATOMY { get; set; } = anatomy;

        [Comment("Symptoms mentioned in the text")]
        public string[]? Symptoms { get; set; } = symptoms;
    }
}

