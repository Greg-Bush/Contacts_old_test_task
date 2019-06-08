class Pagination {
    private _paginationElem: JQuery;

    constructor(totalCount: number, page: number= 1) {
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

    public setTotalCount(count: number): void {
        if (count > 100)
            count = 100;
        this._paginationElem.bootpag({
            total: count,
            page: 1
        });
    }

    public setPage(page: number): void {
        this._paginationElem.bootpag({
            page: page
        });
    }

    public setPageFunction(operation: (event: JQueryEventObject, pageNumber: number) => void): void {
        this._paginationElem.on("page", operation);
    }
}