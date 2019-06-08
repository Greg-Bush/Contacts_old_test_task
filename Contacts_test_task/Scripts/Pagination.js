var Pagination = (function () {
    function Pagination(totalCount, page) {
        if (page === void 0) { page = 1; }
        // init bootpag
        this._paginationElem = $('#page-selection').bootpag({
            total: totalCount,
            page: page,
            maxVisible: 10,
            leaps: true,
            firstLastUse: true,
            first: '←',
            last: '→',
            wrapClass: 'pagination',
            activeClass: 'active',
            disabledClass: 'disabled',
            nextClass: 'next',
            prevClass: 'prev',
            lastClass: 'last',
            firstClass: 'first'
        });
    }
    Pagination.prototype.setTotalCount = function (count) {
        if (count > 100)
            count = 100;
        this._paginationElem.bootpag({
            total: count,
            page: 1
        });
    };
    Pagination.prototype.setPage = function (page) {
        this._paginationElem.bootpag({
            page: page
        });
    };
    Pagination.prototype.setPageFunction = function (operation) {
        this._paginationElem.on("page", operation);
    };
    return Pagination;
})();
//# sourceMappingURL=Pagination.js.map