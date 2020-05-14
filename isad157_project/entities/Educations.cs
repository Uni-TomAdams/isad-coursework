using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isad157_project.entities
{
    class Educations
    {
        /* 
            ATTRIBUTE(s)
        */
        private int educationID;
        private string educationName;
        private DateTime educationStartDate;
        private DateTime educationEndDate;

        /* 
            CONSTRUCTOR(s)
        */
        public Educations(int _educationID, string _educationName, DateTime _educatrionStartDate, DateTime _educationEndDate)
        {
            educationID = _educationID;
            educationName = _educationName;
            educationStartDate = _educatrionStartDate;
            educationEndDate = _educationEndDate;
        }
        
        // ASSUMPTION: Note there would be GETTERS and SETTERS for all attributes here normally.
    }
}
