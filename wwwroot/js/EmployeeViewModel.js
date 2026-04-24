var ViewModel = function () {
    var self = this;

    // --- CONFIGURATION ---
    var backendApiUrl = 'https://localhost:7081'; // backend API URL

    // --- OBSERVABLES ---
    self.employees = ko.observableArray([]);
    self.departments = ko.observableArray([]);
    self.isLoading = ko.observable(false);
    self.modalTitle = ko.observable("");
    //self.testMessage = ko.observable("");

    self.currentEmployee = {
        employee_Id: ko.observable(0),
        name: ko.observable(""),
        departmentId: ko.observable(null)
    };

     //--- TEST API ---
    //self.runTest = function () {
    //    self.testMessage("Checking API...");

    //    $.get(backendApiUrl + '/api/Values')
    //        .done(function (data) {
    //            self.testMessage("Success: " + data);
    //        })
    //        .fail(function () {
    //            self.testMessage("Error calling the API.");
    //        });
    //};

    // --- FETCH FUNCTIONS ---

    function fetchEmployees() {
        self.isLoading(true);

        $.getJSON(backendApiUrl + '/api/Employee')
            .done(function (data) {
                self.employees(data);
            })
            .fail(function (err) {
                alert("Failed to fetch employees: " + err.statusText);
            })
            .always(function () {
                self.isLoading(false);
            });
    }
 //Function to fetch department from backend
    function fetchDepartments() {

        self.isLoading(true);

        $.getJSON(backendApiUrl + '/api/Department')
            .done(function (data) {
                self.departments(data);
            })
            .fail(function (err) {
                alert("Failed to fetch departments: " + err.statusText);
            })
            .always(function () {
                self.isLoading(false);
            });;
    }

    // --- UI FUNCTIONS ---
    self.showAddDialog = function () {
        self.modalTitle("Add New Employee");
        self.currentEmployee.employee_Id(0);
        self.currentEmployee.name("");
        self.currentEmployee.departmentId(null);
        $('#employeeModal').modal('show');
    };

    self.showEditDialog = function (employeeToEdit) {
        self.modalTitle("Edit Employee");
        self.currentEmployee.employee_Id(employeeToEdit.employee_Id);
        self.currentEmployee.name(employeeToEdit.name);
        self.currentEmployee.departmentId(employeeToEdit.dep_Id);

        $('#employeeModal').modal('show');
    };

    self.saveEmployee = function () {
        var depId = parseInt(self.currentEmployee.departmentId());
        if (isNaN(depId)) {
            alert("Please select a valid department.");
            return;
        }

        var employeeData = {
            Emp_Id: self.currentEmployee.employee_Id(),
            Name: self.currentEmployee.name(),
            Dep_Id:self.currentEmployee.departmentId()
        };

        var isNew = employeeData.Emp_Id === 0;
        var apiUrl = isNew
            ? backendApiUrl + '/api/Employee'
            : backendApiUrl + '/api/Employee/updateEmployee/' + employeeData.Emp_Id;
        var httpMethod = isNew ? 'POST' : 'PUT';

        $.ajax({
            type: httpMethod,
            url: apiUrl,
            contentType: 'application/json',
            data: JSON.stringify(employeeData)
        })
            .done(function () {
                fetchEmployees();
                $('#employeeModal').modal('hide');
            })
            .fail(function (err) {
                alert("Error saving employee: " + (err.responseText || err.statusText));
            });

        console.log("Saving employee:", JSON.stringify(employeeData));

    };


    self.deleteEmployee = function (employeeToDelete) {
        if (confirm('Are you sure you want to delete this employee?')) {
            $.ajax({
                type: 'DELETE',
                url: backendApiUrl + '/api/Employee/' + employeeToDelete.employee_Id
            })
                .done(function () {
                    fetchEmployees();
                })
                .fail(function (err) {
                    alert("Error deleting employee: " + (err.responseText || err.statusText));
                });
        }
    };

    // --- INITIAL LOAD ---
    fetchDepartments();
    fetchEmployees();
};


ko.applyBindings(new ViewModel());
