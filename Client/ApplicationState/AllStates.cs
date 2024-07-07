namespace Client.ApplicationState
{
    public class AllStates
    {
        //SCOPE ACTION
        public Action? Action { get; set; }
        //GENERAL DEPARTMENT
        public bool ShowGeneralDepartment { get; set; }
        public void GeneralDepartmentClicked()
        {
            ResetAllDepartments();
            ShowGeneralDepartment = true;
            Action?.Invoke();
        }

        //DEPARTMENT
        public bool ShowDepartment { get; set; }
        public void DepartmentClicked()
        {
            ResetAllDepartments();
            ShowDepartment = true;
            Action?.Invoke();
        }

        //BRANCH
        public bool ShowBranch { get; set; }
        public void BranchClicked()
        {
            ResetAllDepartments();
            ShowBranch = true;
            Action?.Invoke();
        }

        //COUNTRY
        public bool ShowCountry { get; set; }
        public void CountryClicked()
        {
            ResetAllDepartments();
            ShowCountry = true;
            Action?.Invoke();
        }
        //CITY
        public bool ShowCity { get; set; }
        public void CityClicked()
        {
            ResetAllDepartments();
            ShowCity = true;
            Action?.Invoke();
        }
        //TOWN
        public bool ShowTown { get; set; }
        public void TownClicked()
        {
            ResetAllDepartments();
            ShowTown = true;
            Action?.Invoke();
        }

        //USER
        public bool ShowUser { get; set; }
        public void UserClicked()
        {
            ResetAllDepartments();
            ShowUser = true;
            Action?.Invoke();
        }

        //DOCTOR
        public bool ShowHealth { get; set; } = true;
        public void HealthClicked()
        {
            ResetAllDepartments();
            ShowHealth = true;
            Action?.Invoke();
        }
        //OVERTIME
        public bool ShowOvertime { get; set; } = true;
        public void OvertimeClicked()
        {
            ResetAllDepartments();
			ShowOvertime = true;
            Action?.Invoke();
        }
        //SANCTION
        public bool ShowSanction { get; set; } = true;
        public void SanctionClicked()
        {
            ResetAllDepartments();
			ShowSanction = true;
            Action?.Invoke();
        }
        //VACATION
        public bool ShowVacation { get; set; } = true;
        public void VacationClicked()
        {
            ResetAllDepartments();
			ShowVacation = true;
            Action?.Invoke();
        }
        //OVERTIMETYPE
        public bool ShowOvertimeType { get; set; } = true;
        public void OvertimeTypeClicked()
        {
            ResetAllDepartments();
			ShowOvertimeType = true;
            Action?.Invoke();
        }
        //SANCTIONTYPE
        public bool ShowSanctionType { get; set; } = true;
        public void SanctionTypeClicked()
        {
            ResetAllDepartments();
			ShowSanctionType = true;
            Action?.Invoke();
        }
        //VACATIONTYPE
        public bool ShowVacationType { get; set; } = true;
        public void VacationTypeClicked()
        {
            ResetAllDepartments();
			ShowVacationType = true;
            Action?.Invoke();
        }

		//EMPLOYEE
		public bool ShowEmployee { get; set; } = true;
		public void EmployeeClicked()
		{
			ResetAllDepartments();
			ShowEmployee = true;
			Action?.Invoke();
		}
		private void ResetAllDepartments()
        {
            ShowGeneralDepartment = false;
            ShowDepartment = false;
            ShowBranch = false;
            ShowCountry = false;
            ShowCity = false;
            ShowTown = false;
            ShowUser = false;
            ShowEmployee = false;
            ShowHealth = false;
            ShowOvertime = false;
            ShowOvertimeType = false;
            ShowSanction = false;
            ShowSanctionType = false;
            ShowVacation = false;
            ShowVacationType = false;

        }
    }
}
