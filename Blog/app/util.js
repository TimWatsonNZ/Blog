(function () {
    var moduleId = "util";
    var serviceId = "utilService";

    var app = angular.module(moduleId, []);
    app.factory(serviceId, ["$http", service]);

    function service() {
        //function returnWrapper(data, hasError, errorType, additionalData) {
        //    this.data = data;
        //    this.hasError = hasError || false;
        //    this.error = errorType || null;
        //    this.additionalData = additionalData || null;
        //}

        //var ErrorTypes = {
        //    InvalidParameters: "Input parameters were incorrect",
        //    HttpError: "The http call failed."
        //}

        function printDate(dateTime) {
            var monthNames = [
              "January", "February", "March",
              "April", "May", "June", "July",
              "August", "September", "October",
              "November", "December"
            ];

            var date = new Date(dateTime);
            var day = date.getDate();
            var monthIndex = date.getMonth();
            var year = date.getFullYear();

            return day + ' ' + monthNames[monthIndex] + ' ' + year;
        }

        return {
            printDate: printDate
        }
    }
})()

