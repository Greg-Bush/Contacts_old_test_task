var LoaderAnimation = (function () {
    function LoaderAnimation() {
        this.diabledString = "disabled";
        this.blockedString = "blocked";
        this._loaderElem = $('#loader');
        this._contentElem = $('#dinamic-section');
    }
    LoaderAnimation.prototype.start = function (id) {
        this._loaderElem.removeClass(this.diabledString);
        var target = id ? $('#' + id) : this._contentElem;
        target.addClass(this.blockedString);
    };
    LoaderAnimation.prototype.stop = function (id) {
        this._loaderElem.addClass(this.diabledString);
        var target = id ? $('#' + id) : this._contentElem;
        target.removeClass(this.blockedString);
    };
    return LoaderAnimation;
})();
//# sourceMappingURL=LoaderAnimation.js.map