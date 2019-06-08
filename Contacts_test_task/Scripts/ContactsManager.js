var ContactsManager = (function () {
    function ContactsManager() {
        this.loader = new LoaderAnimation();
        this.searchFormElem = $('#searchForm');
        this.updateFormElem = $('#updateForm');
        this.resultsTarget = $('#results');
        this.pageNumberHiddenInput = $('#pageNumberHidden');
    }
    Object.defineProperty(ContactsManager.prototype, "pagination", {
        get: function () {
            if (!this._pagination) {
                this._pagination = new Pagination(10);
            }
            return this._pagination;
        },
        enumerable: true,
        configurable: true
    });
    ContactsManager.prototype.formSerialize = function (searchFormElem) {
        var result = null, inputsArray = searchFormElem.find('input[name][value!=""]');
        if (inputsArray.length > 0) {
            result = inputsArray.first().attr('name') + '=' + inputsArray.first().val();
            for (var i = 1; i < inputsArray.length; i++) {
                var item = $(inputsArray[i]);
                result += '&' + item.attr('name') + '=' + item.val();
            }
        }
        return result;
    };
    ContactsManager.prototype.search = function (refreshPagination) {
        if (refreshPagination === void 0) { refreshPagination = true; }
        var _this = this;
        var requestDataRow = _this.formSerialize(this.searchFormElem);
        this.loader.start();
        if (_this.ajaxRequest) {
            _this.ajaxRequest.abort();
        }
        _this.ajaxRequest = $.ajax("Search", {
            data: requestDataRow,
            success: function (data) {
                _this.resultsTarget.html(data);
                if (refreshPagination) {
                    _this.pagination.setTotalCount($('#TotalCount').val());
                }
            },
            complete: function () {
                _this.loader.stop();
            }
        });
    };
    ContactsManager.prototype.errorFunction = function () {
        alert('sorry, an error occurred while loading data');
    };
    ContactsManager.prototype.remove = function (id) {
        var _this = this;
        $.ajax("Remove", {
            data: { id: id },
            success: function () {
                $('li[data-lp][class="active"]').removeClass("active").click();
            },
            complete: function () {
                _this.loader.stop();
            }
        });
    };
    ContactsManager.prototype.init = function () {
        var _this = this;
        $.ajaxSetup({
            error: _this.errorFunction
        });
        this.pagination.setPageFunction(function (e, pageNumber) {
            _this.pageNumberHiddenInput.val((pageNumber - 1) + "");
            _this.search(false);
        });
        this.searchFormElem.submit(function () {
            _this.search();
            return false;
        });
        this.searchFormElem.submit();
        this.resultsTarget.on('click', 'button[data-remove]', function () {
            var isConfirmed = confirm("Are you sure? Contact will be removed.");
            if (isConfirmed) {
                _this.remove($(this).data('id'));
            }
        });
        // there is crutches
        this.resultsTarget.on('click', 'button[data-change]', function () {
            var id = $(this).data('id');
            var currentCard = $('#' + id);
            _this.updateFormElem.find('input[name="id"]').val(id);
            currentCard.find('input[type="hidden"]').each(function (index, elem) {
                var _elem = $(elem);
                _this.updateFormElem.find('input[name="' + _elem.attr("name") + '"]').val(_elem.val());
            });
            $('#openUpdateModal').click();
        });
        this.updateFormElem.submit(function () {
            var requestDataRow = _this.formSerialize($(this));
            _this.loader.start();
            $.ajax("Update", {
                data: requestDataRow,
                success: function (data) {
                    alert("success");
                    _this.search(false);
                },
                complete: function () {
                    _this.loader.stop();
                }
            });
            _this.closeModal();
            return false;
        });
        $('#addForm').submit(function () {
            var requestDataRow = _this.formSerialize($(this));
            $.ajax("Update", {
                data: requestDataRow,
                success: function (data) {
                    alert("success");
                }
            });
            _this.closeModal();
            return false;
        });
    };
    ContactsManager.prototype.closeModal = function () {
        $('button[data-dismiss="modal"]').click();
    };
    return ContactsManager;
})();
//# sourceMappingURL=ContactsManager.js.map