$(function () {
    var $container = $('#new-entry-container');
    var $form = $('#new-entry-form');
    var $editorContainer = $container.find('.new-entry-editor');
    var $submitButton = $form.find('button[type=submit]');
    var $postTextInput = $form.find("input[name='ContentEntryInfo.Content']");

    var newPostEditor = new toastui.Editor({
        el: $editorContainer[0],
        usageStatistics: false,
        initialEditType: 'wysiwyg',
        height: 'auto',
        initialValue: $postTextInput.val(),
    });

    $form.submit(function (e) {

        var postText = newPostEditor.getHTML();
        $postTextInput.val(postText);

        if (!$form.valid()) {
            var validationResult = $form.validate();
            abp.message.warn(validationResult.errorList[0].message);
            e.preventDefault();
            return false; //for old browsers
        }

        $submitButton.buttonBusy();
        $(this).off('submit').submit();

        return true;

    });
});