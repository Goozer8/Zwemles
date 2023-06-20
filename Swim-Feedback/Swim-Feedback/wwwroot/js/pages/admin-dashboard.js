adminDashboard = {};

adminDashboard.init = function() {
    adminDashboard.logTable = new DataTable("#log-table", {
        pageLength: 5,
        order: [[ 0, 'desc' ]]
    });
};
