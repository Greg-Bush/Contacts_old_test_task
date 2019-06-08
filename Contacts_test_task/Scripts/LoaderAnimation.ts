class LoaderAnimation {

    private _loaderElem: JQuery;
    private _contentElem: JQuery;

    private diabledString: string = "disabled";
    private blockedString: string = "blocked";


    constructor() {
        this._loaderElem = $('#loader');
        this._contentElem = $('#dinamic-section');
    }

    public start(id?: string): void {
        this._loaderElem.removeClass(this.diabledString);
        var target = id ? $('#' + id) : this._contentElem;
        target.addClass(this.blockedString);
    }

    public stop(id?: string): void {
        this._loaderElem.addClass(this.diabledString);
        var target = id ? $('#' + id) : this._contentElem;
        target.removeClass(this.blockedString);
    }
}