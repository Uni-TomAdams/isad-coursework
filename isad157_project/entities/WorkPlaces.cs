using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isad157_project.entities
{
    class WorkPlaces
    {
        /* 
            ATTRIBUTE(s)
        */
        private int workPlaceID;
        private String workPlaceName;
        private DateTime workPlaceStartDate;
        private DateTime workPlaceEndDate;

        /* 
            CONSTRUCTOR(s)
        */
        public WorkPlaces(int _workPlaceID, String _workPlaceName, DateTime _workPlaceStartDate, DateTime _workPlaceEndDate)
        {
            workPlaceID = _workPlaceID;
            workPlaceName = _workPlaceName;
            workPlaceStartDate = _workPlaceStartDate;
            workPlaceEndDate = _workPlaceEndDate;
        }

        /* 
            METHOD(s)

        public List<Educations> getWorkPlaces(int userID)
        {
            // QUERY: Gets all of users workplaces in the workplace / work_history tables using an inner join.
            string selectUsersWorkPlacesQuery = "SELECT * FROM work_history INNER JOIN workplaces ON (work_history.user_id_fk = " + userID + ") AND (work_history.workplace_id_fk = workplaces.workplace_id)";
        }
                */

        // ASSUMPTION: Note there would be GETTERS and SETTERS for all attributes here normally.
    }
}
