(function ($) {
    $.fn.validate = function (groups) {

        //define collection of validators
        var required = new RequiredValidation();
        var group = new GroupValidation(groups);
        var futureDate = new FutureDateValidation();
        var oneChecked = new AtleastOneCheckedValidation();

        var validators = [required, futureDate, group, oneChecked];

        //Loop through validators and call the validate method
        for (var index = 0; index < validators.length; index++) {
            validators[index].validate();
        }


        //find all submit buttons
        var buttons = $(this).find('[type="submit"]');

        //Loop and attached to the click event on each button
        buttons.each(function () {
            var button = $(this);

            button.unbind('click.validation');
            button.bind('click.validation', function () {

                //reset the value, otherwise it's stuck in false mode forever.
                var isValid = true;
                var invalidFields = new Array();

                for (var i = 0; i < validators.length; i++) {

                    var is = validators[i].isValid(invalidFields);
                    isValid = isValid && is;
                }

                return isValid;
            });
        });

    };

    function createGuid() {
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) { var r = Math.random() * 16 | 0, v = c == 'x' ? r : r & 0x3 | 0x8; return v.toString(16); });
    }

    function hasItem(id, array) {

        for (var index = 0; index < array.length; index++) {

            if (id == array[index]) {
                return true;
            }
        }

        return false;
    }

    function removeErrorMessage(field) {
        var errorMessage = field.siblings('label[class~="field-validation-invalid"]').get(0);
        errorMessage = $(errorMessage);
        errorMessage.remove();
        errorMessage.text('');
    }

    function validateItem(item, invalidFields, validate) {

        var field = $(item);

        //get current Id.
        var val = field.attr('id');

        //if it has not failed previously, evaluate the value against the criteria
        if (!hasItem(val, invalidFields)) {
            var eval = validate(item);

            //if it fails we added it to the invalid field collection.
            if (!eval) {

                //checking for an id, if none exists, assign a value
                if (val == null || val.length == 0) {
                    val = createGuid();
                    field.attr('id', val);
                }

                invalidFields[invalidFields.length] = val;
            }

            return eval;
        }

        return true;
    }

    function setErrorMessage(field, message, resetfieldMessage) {

        var siblings = field.siblings('label[class~="field-validation-invalid"]');

        if (siblings.length == 0) {
            var error = $('<label>')
            .addClass('field-validation-invalid field-validation-error')
            .text(message);
            field.after(error);
        }
    }

    function GroupValidation(groups) {

        this.groups = groups;
        this.getItems = function () {
        };

        this.validate = function () {
            var self = this;
            var g = this.groups;

            if (g !== undefined) {
                var index = 0;
                while (g.groups[index] != null) {
                    self.attachBlur(g.groups[index]);
                    index++;
                }
            }
        };

        this.attachBlur = function (group) {
            var self = this;

            for (var i = 0; i < group.items.length; i++) {
                $('#' + group.items[i].id).blur(function () {
                    self.internalValidate(group);
                });
            }
        };

        this.isValid = function (invalidFields) {

            var self = this;
            var g = this.groups;

            var isValid = true;

            if (g !== undefined) {
                var index = 0;
                while (g.groups[index] != null) {
                    isValid = isValid && self.internalValidate(g.groups[index]);
                    index++;
                }
            }

            return isValid;
        };

        this.internalValidate = function (group) {

            var numberToWord = ['One', 'Two', 'Three', 'Four', 'Five'];
            var internalSelf = this;

            var min = group.requiredCount;
            var hasValue = 0;

            for (var iv = 0; iv < group.items.length; iv++) {

                var id = group.items[iv].id;
                var input = $('#' + id);
                if (input.val().length > 0 && input.attr('Name') != input.val()) {
                    hasValue++;
                }
            }

            if (min > hasValue) {

                var names = internalSelf.fieldNames(group);
                var errorMessageSet = true;

                for (var i = 0; i < group.items.length; i++) {
                    var inputId = group.items[i].id;
                    var inputControl = $('#' + inputId);

                    if (errorMessageSet) {
                        setErrorMessage(inputControl, numberToWord[min - 1] + ' or more are require: ' + names, false);
                        errorMessageSet = false;
                    }
                }

                return false;
            } else {

                for (var ir = 0; ir < group.items.length; ir++) {
                    var removeId = group.items[ir].id;
                    var removeControl = $('#' + removeId);
                    removeErrorMessage(removeControl);
                }
            }

            return true;
        };

        this.fieldNames = function (group) {

            var names = '';

            for (var index = 0; index < group.items.length; index++) {

                if (index == 0) {
                    names = group.items[index].friendlyName;
                } else {
                    names = names + ", " + group.items[index].friendlyName;
                }
            }
            return names;
        };

    };

    function RequiredValidation() {

        var items = [];

        this.getItems = function () {

            var fields = $('form').find('[class~="required"]');
            items = [];

            fields.each(function () {

                var contains = false;
                for (var indext = 0; indext < items.length; indext++) {

                    var key = $(items[indext]).attr('name') + $(items[indext]).attr('id');
                    var current = $(this).attr('name') + $(this).attr('id');

                    if (key == current) {
                        contains = true;
                    }
                }

                if (!contains && $(this).is(":visible")) {
                    items[items.length] = this;
                }
            });

        };

        this.isValid = function (invalidFields) {
            var page = this;
            this.getItems();

            var isValid = true;

            for (var index = 0; index < items.length; index++) {

                isValid = isValid && validateItem(items[index], invalidFields, page.internalValidate);
            }

            return isValid;
        };

        this.internalValidate = function (field) {

            field = $(field);
            var isValid = true;

            var title = field.attr('Name');
            var friendlyName = field.attr('title');
            
            if (friendlyName == null) {
                friendlyName = 'This field';
            }

            if (field.val().length === 0 || (title !== undefined && title == field.val())) {
                isValid = isValid && false;
                setErrorMessage(field, friendlyName + ' is required', true);
            } else {
                removeErrorMessage(field);
            }

            return isValid;
        };

        this.validate = function () {
            var page = this;
            this.getItems();

            for (var index = 0; index < items.length; index++) {

                var f = $(items[index]);
                f.blur(function () {
                    page.internalValidate(this);
                });
            }
        };
    }

    function FutureDateValidation() {

        var items = [];

        this.getItems = function () {

            var fields = $('form').find('[class~="futureDate"]');
            items = [];

            fields.each(function () {

                var contains = false;
                for (var indext = 0; indext < items.length; indext++) {

                    var key = $(items[indext]).attr('name') + $(items[indext]).attr('id');
                    var current = $(this).attr('name') + $(this).attr('id');

                    if (key == current) {
                        contains = true;
                    }
                }

                if (!contains && $(this).is(":visible")) {
                    items[items.length] = this;
                }
            });

        };

        this.isValid = function (invalidFields) {
            var page = this;
            this.getItems();

            var isValid = true;

            for (var index = 0; index < items.length; index++) {

                isValid = isValid && validateItem(items[index], invalidFields, page.internalValidate);
            }

            return isValid;
        };

        this.internalValidate = function (field) {

            field = $(field);
            var isValid = true;
            var val = Date.parse(field.val());


            if (val !== undefined && val !== null && new Date() > val) {
                isValid = isValid && false;
                setErrorMessage(field, 'A future date is required', true);
            } else {
                removeErrorMessage(field);
            }

            return isValid;
        };

        this.validate = function () {
            var page = this;
            this.getItems();

            for (var index = 0; index < items.length; index++) {

                var f = $(items[index]);
                f.keyup(function () {
                    page.internalValidate(this);
                });
            }
        };
    }

    function AtleastOneCheckedValidation() {

        var items = [];
        var messageSet = false;
        var messageField = null;

        this.getItems = function () {

            var fields = $('form').find('[class~="atleastOneChecked"]');
            items = [];

            fields.each(function () {

                var contains = false;
                for (var indext = 0; indext < items.length; indext++) {

                    var key = $(items[indext]).attr('name') + $(items[indext]).attr('id');
                    var current = $(this).attr('name') + $(this).attr('id');

                    if (key == current) {
                        contains = true;
                    }
                }

                if (!contains && $(this).is(":visible")) {
                    items[items.length] = this;
                }
            });

        };

        this.isValid = function (invalidFields) {
            var page = this;
            this.getItems();

            for (var index = 0; index < items.length; index++) {

                var isValid = validateItem(items[index], invalidFields, page.internalValidate);

                if (isValid) {
                    messageSet = false;
                    return true;
                }
            }

            //when there are no items to check, then true is returned. If we get here and there are items, then there is an error 
            //and we must return false.
            return (items.length == 0);
        };

        this.internalValidate = function (field) {

            var isValid = field.checked;

            if (!isValid) {

                if (!messageSet) {
                    messageField = field;
                    setErrorMessage($(field), 'One or more checkboxes must be checked.', true);
                }
                messageSet = true;
            } else {
                removeErrorMessage($(messageField));
            }

            return isValid;
        };

        this.validate = function () {
            var page = this;
            this.getItems();

            for (var index = 0; index < items.length; index++) {
                var f = $(items[index]);
                f.keyup(function () {
                    page.internalValidate(this);
                });
            }
        };
    }

})(jQuery);