(function () {
    var moduleId = "utilService";
    var serviceId = "utilService";

    var app = angular.module(moduleId, []);
    app.factory(serviceId, ["$http", service]);

    function service() {

        function returnWrapper(data, hasError, errorType, additionalData, message) {
            this.data = data;
            this.hasError = hasError || false;
            this.error = errorType || null;
            this.additionalData = additionalData || null;
            this.message = message;
        }

        function InvalidParameters(message) {
            return new returnWrapper(null, true, ErrorTypes.InvalidParameters, null, message);
        }

        function HttpError(message) {
            return new returnWrapper(null, true, ErrorTypes.HttpError, null, message);
        }

        var ErrorTypes = {
            InvalidParameters: "Input parameters were incorrect",
            HttpError: "The http call failed."
        }

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
            InvalidParameters: InvalidParameters,
            HttpError: HttpError,
            ErrorTypes: ErrorTypes,
            returnWrapper: returnWrapper,
            printDate: printDate
        }
    }
})()

