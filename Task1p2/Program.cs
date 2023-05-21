using Task1p2;

//to director
TaskManagment.Instance.Cases[0].dispatchCase();
TaskManagment.Instance.Cases[0].dispatchCase();
TaskManagment.Instance.Cases[0].dispatchCase();

//to account manager
TaskManagment.Instance.Cases[1].dispatchCase();
TaskManagment.Instance.Cases[1].dispatchCase();

//to account manager
TaskManagment.Instance.Cases[2].dispatchCase();
TaskManagment.Instance.Cases[2].dispatchCase();

//to account manager -> fail
TaskManagment.Instance.Cases[3].dispatchCase();
TaskManagment.Instance.Cases[3].dispatchCase();

//to backoffice
TaskManagment.Instance.Cases[4].dispatchCase();

//to backoffice -> fail
TaskManagment.Instance.Cases[5].dispatchCase();

Console.WriteLine(TaskManagment.Instance);