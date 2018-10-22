"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var http_1 = require("@angular/common/http");
var Page = /** @class */ (function () {
    function Page() {
    }
    return Page;
}());
exports.Page = Page;
function queryPaginated(http, baseUrl, urlOrFilter) {
    var params = new http_1.HttpParams();
    var url = baseUrl;
    if (typeof urlOrFilter === 'string') {
        url = urlOrFilter;
    }
    else if (typeof urlOrFilter === 'object') {
        Object.keys(urlOrFilter).sort().forEach(function (key) {
            var value = urlOrFilter[key];
            if (value !== null) {
                params = params.set(key, value);
            }
        });
    }
    return http.get(url, { params: params });
}
exports.queryPaginated = queryPaginated;
//# sourceMappingURL=page.js.map